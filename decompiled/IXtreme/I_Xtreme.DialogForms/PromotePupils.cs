using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraWizard;
using I_Xtreme.Properties;

namespace I_Xtreme.DialogForms;

public class PromotePupils : XtraForm
{
	private static SqlTransaction transaction;

	private int maximum = 0;

	private int k = 0;

	private string currentTask = string.Empty;

	private string currentTask_Promote = string.Empty;

	private int maxTransCandidates = 0;

	private int k_maxCandidate = 0;

	private IContainer components = null;

	private WizardControl wizardControl1;

	private WelcomeWizardPage welcomeWizardPage1;

	private WizardPage wizardPage1;

	private CompletionWizardPage completionWizardPage1;

	private WizardPage wizardPage2;

	private LabelControl labelControl1;

	private RadioGroup radioGroup1;

	private LabelControl lblDescription;

	private LabelControl labelControl3;

	private BackgroundWorker bgPromoteStudents;

	private LabelControl labelControl4;

	private TextEdit txtExitYear;

	private LabelControl lblTaskCandidates;

	private ProgressBarControl progressPromoteStudents;

	private ProgressBarControl progressTransferCandidates;

	private BackgroundWorker bgTransferCandidate;

	private LabelControl lblTaskPromote;

	private LabelControl labelControl5;

	private System.Windows.Forms.Timer timer1;

	private GridControl gridControl1;

	private GridView gridView1;

	private GridColumn bandedGridColClass;

	private GridColumn bandedGridColPromote;

	private GridColumn bandedGridColPOB;

	private GridColumn bandedGridColRepeat;

	private bool YearPromoted
	{
		get
		{
			bool flag = true;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_PromoStamps WHERE SemesterId='{txtExitYear.Text}'", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "PromotedYear");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				return false;
			}
			return true;
		}
	}

	public PromotePupils()
	{
		InitializeComponent();
	}

	private void DeleteTableData(string targetTable)
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = string.Format("DELETE FROM {0}"),
				CommandType = CommandType.Text
			};
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				sqlConnection.Close();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void TransferCandidates()
	{
		try
		{
			string[] array = new string[0];
			array = new string[1] { "P.7" };
			for (int i = 0; i < array.Length; i++)
			{
				currentTask = "Backing up " + array[i] + " students...";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT s.*, g.* FROM tbl_Stud s LEFT JOIN  tbl_Guardian g ON s.Oid = g.studentOid WHERE s.ClassId='{array[i]}'", DataConnection.ConnectToDatabase());
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "SourceTable");
				maxTransCandidates = dataSet.Tables[0].Rows.Count;
				k_maxCandidate = 0;
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection.Open();
					transaction = sqlConnection.BeginTransaction();
					string g = row["Oid"].ToString();
					Guid guid = new Guid(g);
					using (SqlCommand sqlCommand = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = "INSERT INTO tbl_oldStudents (StudentNumber,HouseId,StreamId,Oid,FormerSchool,StudyStatus,BursaryStatus,RequiredFees,BursaryProvider,AdmissionDate,Sex,Picture,Religion,HomeCountry,fullName,Status,Notes,cashOnAccount,ClassId,ExitYear)VALUES(@StudentNumber,@HouseId,@StreamId,@Oid,@FormerSchool,@StudyStatus,@BursaryStatus,@RequiredFees,@BursaryProvider,@AdmissionDate,@Sex,@Picture,@Religion,@HomeCountry,@fullName,@Status,@Notes,@cashOnAccount,@ClassId,@ExitYear)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter.Value = row["StudentNumber"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@HouseId", SqlDbType.VarChar, 25);
						sqlParameter.Value = row["HouseId"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@StreamId", SqlDbType.VarChar, 8);
						sqlParameter.Value = row["StreamId"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Oid", SqlDbType.UniqueIdentifier);
						sqlParameter.Value = guid;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@FormerSchool", SqlDbType.VarChar, 50);
						sqlParameter.Value = row["FormerSchool"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@StudyStatus", SqlDbType.VarChar, 1);
						sqlParameter.Value = row["StudyStatus"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@BursaryStatus", SqlDbType.VarChar, 7);
						sqlParameter.Value = row["BursaryStatus"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@RequiredFees", SqlDbType.Money);
						sqlParameter.Value = Convert.ToDouble(row["RequiredFees"]);
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@BursaryProvider", SqlDbType.VarChar, 50);
						sqlParameter.Value = row["BursaryProvider"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@AdmissionDate", SqlDbType.VarChar, 4);
						sqlParameter.Value = row["AdmissionDate"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Sex", SqlDbType.VarChar, 1);
						sqlParameter.Value = row["Sex"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Picture", SqlDbType.Image);
						sqlParameter.Value = row["Picture"];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Religion", SqlDbType.VarChar, 15);
						sqlParameter.Value = row["Religion"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@HomeCountry", SqlDbType.VarChar, 15);
						sqlParameter.Value = row["HomeCountry"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@fullName", SqlDbType.VarChar, 50);
						sqlParameter.Value = row["fullName"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Notes", SqlDbType.VarChar);
						sqlParameter.Value = row["Notes"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar, 15);
						sqlParameter.Value = row["Status"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@cashOnAccount", SqlDbType.Money);
						sqlParameter.Value = Convert.ToDouble(row["cashOnAccount"]);
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 3);
						sqlParameter.Value = array[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@ExitYear", SqlDbType.Int);
						sqlParameter.Value = Convert.ToInt16(txtExitYear.Text);
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand2 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = "INSERT INTO tbl_oldGuardians (studentOid,GuardianName,GuardianContact,GuardianAddress)VALUES(@studentOid,@GuardianName,@GuardianContact,@GuardianAddress)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@studentOid", SqlDbType.UniqueIdentifier);
						sqlParameter2.Value = guid;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@GuardianName", SqlDbType.VarChar, 50);
						sqlParameter2.Value = row["GuardianName"].ToString();
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@GuardianContact", SqlDbType.VarChar, 50);
						sqlParameter2.Value = row["GuardianContact"].ToString();
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@GuardianAddress", SqlDbType.VarChar, 50);
						sqlParameter2.Value = row["GuardianAddress"].ToString();
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand3 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = string.Format("DELETE FROM tbl_Stud WHERE StudentNumber='{0}'", row["StudentNumber"].ToString()),
						CommandType = CommandType.Text
					})
					{
						sqlCommand3.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand4 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = string.Format("DELETE FROM tbl_Scores_Primary WHERE StudentNumber='{0}'", row["StudentNumber"].ToString()),
						CommandType = CommandType.Text
					})
					{
						sqlCommand4.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand5 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = string.Format("DELETE FROM tbl_GeneralReports_Grading_Primary WHERE StudentNumber='{0}'", row["StudentNumber"].ToString()),
						CommandType = CommandType.Text
					})
					{
						sqlCommand5.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand6 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = string.Format("DELETE FROM tbl_GeneralReportCards_Primary WHERE StudentNumber='{0}'", row["StudentNumber"].ToString()),
						CommandType = CommandType.Text
					})
					{
						sqlCommand6.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand7 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = string.Format("DELETE FROM tbl_Scores_PrePrimary WHERE StudentNumber='{0}'", row["StudentNumber"].ToString()),
						CommandType = CommandType.Text
					})
					{
						sqlCommand7.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand8 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = string.Format("DELETE FROM tbl_GeneralReports_Grading_PrePrimary WHERE StudentNumber='{0}'", row["StudentNumber"].ToString()),
						CommandType = CommandType.Text
					})
					{
						sqlCommand8.ExecuteNonQuery();
					}
					transaction.Commit();
					sqlConnection.Close();
					k_maxCandidate++;
					Thread.Sleep(25);
					bgTransferCandidate.ReportProgress(k_maxCandidate);
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message + " Please restart the application", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void PromoteStudentsUnConditionally()
	{
		try
		{
			string[] array = new string[10] { "P.7", "P.6", "P.5", "P.4", "P.3", "P.2", "P.1", "Top", "Middle", "Baby" };
			for (int i = 0; i < array.Length - 1; i++)
			{
				currentTask_Promote = "Promoting " + array[i + 1] + " students...";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT s.*, g.* FROM tbl_Stud s LEFT JOIN  tbl_Guardian g ON s.Oid = g.studentOid WHERE s.ClassId='{array[i + 1]}'", DataConnection.ConnectToDatabase());
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "SourceTable");
				k = 0;
				maximum = dataSet.Tables[0].Rows.Count;
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection.Open();
					transaction = sqlConnection.BeginTransaction();
					using (SqlCommand sqlCommand = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = "UPDATE tbl_Stud SET ClassId=@ClassId WHERE StudentNumber=@StudentNumber",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter.Value = row["StudentNumber"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
						sqlParameter.Value = array[i].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand2 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = string.Format("DELETE FROM tbl_Scores_Primary WHERE StudentNumber='{0}'", row["StudentNumber"].ToString()),
						CommandType = CommandType.Text
					})
					{
						sqlCommand2.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand3 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = string.Format("DELETE FROM tbl_GeneralReports_Grading_Primary WHERE StudentNumber='{0}'", row["StudentNumber"].ToString()),
						CommandType = CommandType.Text
					})
					{
						sqlCommand3.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand4 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = string.Format("DELETE FROM tbl_GeneralReportCards_Primary WHERE StudentNumber='{0}'", row["StudentNumber"].ToString()),
						CommandType = CommandType.Text
					})
					{
						sqlCommand4.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand5 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = string.Format("DELETE FROM tbl_Scores_PrePrimary WHERE StudentNumber='{0}'", row["StudentNumber"].ToString()),
						CommandType = CommandType.Text
					})
					{
						sqlCommand5.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand6 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = string.Format("DELETE FROM tbl_GeneralReports_Grading_PrePrimary WHERE StudentNumber='{0}'", row["StudentNumber"].ToString()),
						CommandType = CommandType.Text
					})
					{
						sqlCommand6.ExecuteNonQuery();
					}
					transaction.Commit();
					sqlConnection.Close();
					k++;
					Thread.Sleep(25);
					bgPromoteStudents.ReportProgress(k);
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static void PerformBulkCopyDifferentSchema()
	{
		DataTable dataTable = new DataTable();
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		SqlCommand sqlCommand = new SqlCommand("SELECT TOP 5 * FROM Products_Archive", sqlConnection);
		sqlConnection.Open();
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
		{
			sqlConnection2.Open();
			using SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlConnection2.ConnectionString);
			sqlBulkCopy.ColumnMappings.Add("ProductID", "ProductID");
			sqlBulkCopy.ColumnMappings.Add("ProductName", "Name");
			sqlBulkCopy.ColumnMappings.Add("QuantityPerUnit", "Quantity");
			sqlBulkCopy.DestinationTableName = "Products_TopSelling";
			sqlBulkCopy.WriteToServer(sqlDataReader);
		}
		sqlDataReader.Close();
	}

	private static void bulkCopy_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
	{
		MessageBox.Show("-- Copied {0} rows.", e.RowsCopied.ToString());
	}

	private void PromoteStudents_Load(object sender, EventArgs e)
	{
		lblTaskCandidates.Text = string.Empty;
		lblTaskPromote.Text = string.Empty;
	}

	private void wizardControl1_NextClick(object sender, WizardCommandButtonClickEventArgs e)
	{
		if (wizardControl1.SelectedPage == wizardPage1)
		{
			if (!YearPromoted)
			{
				wizardPage2.AllowNext = false;
				wizardPage2.AllowBack = false;
				bgTransferCandidate.RunWorkerAsync();
			}
			else
			{
				XtraMessageBox.Show("Sorry we cannot do that! You have already promoted students for " + txtExitYear.Text, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				e.Handled = true;
			}
		}
	}

	private void bgTransferCandidate_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressTransferCandidates.Properties.Maximum = k_maxCandidate + 1;
		progressTransferCandidates.Position = e.ProgressPercentage;
		lblTaskCandidates.Text = currentTask;
	}

	private void bgTransferCandidate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		lblTaskCandidates.Text = "Backing up candidate classes completed.";
		progressTransferCandidates.Position = 0;
		bgPromoteStudents.RunWorkerAsync();
	}

	private void bgPromoteStudents_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		LogopromotedYear();
		wizardPage2.AllowNext = true;
		wizardPage2.AllowBack = true;
		wizardControl1.SelectedPage = completionWizardPage1;
		completionWizardPage1.AllowBack = false;
	}

	private void bgPromoteStudents_DoWork(object sender, DoWorkEventArgs e)
	{
		PromoteStudentsUnConditionally();
	}

	private void bgTransferCandidate_DoWork(object sender, DoWorkEventArgs e)
	{
		TransferCandidates();
	}

	private void bgPromoteStudents_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressPromoteStudents.Properties.Maximum = maximum + 1;
		progressPromoteStudents.Position = e.ProgressPercentage;
		lblTaskPromote.Text = currentTask_Promote;
	}

	private void LogopromotedYear()
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_PromoStamps (SemesterId) VALUES (@SemesterId)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
				sqlParameter.Value = txtExitYear.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (wizardControl1.SelectedPage == wizardPage1 && txtExitYear.Text != string.Empty && txtExitYear.Text.Length == 4)
		{
			wizardPage1.AllowNext = true;
		}
		else
		{
			wizardPage1.AllowNext = false;
		}
	}

	private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (radioGroup1.SelectedIndex == 0)
		{
			lblDescription.Visible = false;
		}
		else
		{
			lblDescription.Visible = true;
		}
	}

	private void PromoteStudents_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (bgPromoteStudents.IsBusy || bgTransferCandidate.IsBusy)
		{
			DialogResult dialogResult = XtraMessageBox.Show("Some processes are still pending. Are you sure you want to close the wizard?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				bgPromoteStudents.CancelAsync();
				bgTransferCandidate.CancelAsync();
				e.Cancel = false;
			}
			else
			{
				e.Cancel = true;
			}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I_Xtreme.DialogForms.PromotePupils));
		this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
		this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.txtExitYear = new DevExpress.XtraEditors.TextEdit();
		this.lblDescription = new DevExpress.XtraEditors.LabelControl();
		this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
		this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
		this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
		this.lblTaskPromote = new DevExpress.XtraEditors.LabelControl();
		this.progressTransferCandidates = new DevExpress.XtraEditors.ProgressBarControl();
		this.lblTaskCandidates = new DevExpress.XtraEditors.LabelControl();
		this.progressPromoteStudents = new DevExpress.XtraEditors.ProgressBarControl();
		this.bgPromoteStudents = new System.ComponentModel.BackgroundWorker();
		this.bgTransferCandidate = new System.ComponentModel.BackgroundWorker();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.bandedGridColClass = new DevExpress.XtraGrid.Columns.GridColumn();
		this.bandedGridColPromote = new DevExpress.XtraGrid.Columns.GridColumn();
		this.bandedGridColPOB = new DevExpress.XtraGrid.Columns.GridColumn();
		this.bandedGridColRepeat = new DevExpress.XtraGrid.Columns.GridColumn();
		((System.ComponentModel.ISupportInitialize)this.wizardControl1).BeginInit();
		this.wizardControl1.SuspendLayout();
		this.welcomeWizardPage1.SuspendLayout();
		this.wizardPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtExitYear.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.radioGroup1.Properties).BeginInit();
		this.wizardPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.progressTransferCandidates.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.progressPromoteStudents.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		base.SuspendLayout();
		this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
		this.wizardControl1.Controls.Add(this.wizardPage1);
		this.wizardControl1.Controls.Add(this.completionWizardPage1);
		this.wizardControl1.Controls.Add(this.wizardPage2);
		this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.wizardControl1.HeaderImage = I_Xtreme.Properties.Resources.promote2;
		this.wizardControl1.Image = I_Xtreme.Properties.Resources.promote1;
		this.wizardControl1.Location = new System.Drawing.Point(0, 0);
		this.wizardControl1.Name = "wizardControl1";
		this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[4] { this.welcomeWizardPage1, this.wizardPage1, this.wizardPage2, this.completionWizardPage1 });
		this.wizardControl1.Size = new System.Drawing.Size(622, 457);
		this.wizardControl1.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(wizardControl1_NextClick);
		this.welcomeWizardPage1.Controls.Add(this.labelControl3);
		this.welcomeWizardPage1.Controls.Add(this.labelControl1);
		this.welcomeWizardPage1.IntroductionText = resources.GetString("welcomeWizardPage1.IntroductionText");
		this.welcomeWizardPage1.Name = "welcomeWizardPage1";
		this.welcomeWizardPage1.Size = new System.Drawing.Size(405, 324);
		this.welcomeWizardPage1.Text = "Welcome to the promote wizard";
		this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
		this.labelControl3.Location = new System.Drawing.Point(4, 23);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(70, 13);
		this.labelControl3.TabIndex = 1;
		this.labelControl3.Text = "IMPORTANT!";
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Green;
		this.labelControl1.Location = new System.Drawing.Point(6, 270);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(392, 23);
		this.labelControl1.TabIndex = 0;
		this.labelControl1.Text = "Please note that you cannot undo this process.";
		this.wizardPage1.Controls.Add(this.gridControl1);
		this.wizardPage1.Controls.Add(this.labelControl5);
		this.wizardPage1.Controls.Add(this.labelControl4);
		this.wizardPage1.Controls.Add(this.txtExitYear);
		this.wizardPage1.Controls.Add(this.lblDescription);
		this.wizardPage1.Controls.Add(this.radioGroup1);
		this.wizardPage1.DescriptionText = "Choose conditions on how you want to promote students.";
		this.wizardPage1.Name = "wizardPage1";
		this.wizardPage1.Size = new System.Drawing.Size(590, 312);
		this.wizardPage1.Text = "Promotion Mode";
		this.gridControl1.Location = new System.Drawing.Point(18, 67);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(551, 168);
		this.gridControl1.TabIndex = 6;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.labelControl5.Location = new System.Drawing.Point(177, 259);
		this.labelControl5.Name = "labelControl5";
		this.labelControl5.Size = new System.Drawing.Size(337, 13);
		this.labelControl5.TabIndex = 5;
		this.labelControl5.Text = "(Enter exit year for candidate classes in the format [yyyy] . e.g 2012)";
		this.labelControl4.Location = new System.Drawing.Point(18, 259);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(47, 13);
		this.labelControl4.TabIndex = 4;
		this.labelControl4.Text = "Exit Year:";
		this.txtExitYear.Location = new System.Drawing.Point(71, 254);
		this.txtExitYear.Name = "txtExitYear";
		this.txtExitYear.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtExitYear.Properties.Mask.EditMask = "\\d{0,4}";
		this.txtExitYear.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
		this.txtExitYear.Properties.Mask.ShowPlaceHolders = false;
		this.txtExitYear.Properties.MaxLength = 4;
		this.txtExitYear.Size = new System.Drawing.Size(100, 22);
		this.txtExitYear.TabIndex = 3;
		this.lblDescription.Location = new System.Drawing.Point(18, 284);
		this.lblDescription.Name = "lblDescription";
		this.lblDescription.Size = new System.Drawing.Size(231, 13);
		this.lblDescription.TabIndex = 2;
		this.lblDescription.Text = "Pupils will be promoted basing on Average Score";
		this.lblDescription.Visible = false;
		this.radioGroup1.Location = new System.Drawing.Point(16, 14);
		this.radioGroup1.Name = "radioGroup1";
		this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Promote all pupils unconditionally"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Promote pupils basing on the following conditions")
		});
		this.radioGroup1.Size = new System.Drawing.Size(287, 55);
		this.radioGroup1.TabIndex = 0;
		this.radioGroup1.SelectedIndexChanged += new System.EventHandler(radioGroup1_SelectedIndexChanged);
		this.completionWizardPage1.FinishText = "You have successfully promoted the pupils";
		this.completionWizardPage1.Name = "completionWizardPage1";
		this.completionWizardPage1.Size = new System.Drawing.Size(405, 324);
		this.wizardPage2.Controls.Add(this.lblTaskPromote);
		this.wizardPage2.Controls.Add(this.progressTransferCandidates);
		this.wizardPage2.Controls.Add(this.lblTaskCandidates);
		this.wizardPage2.Controls.Add(this.progressPromoteStudents);
		this.wizardPage2.DescriptionText = "Sit back and relax while the wizards works for you. This may take a few minutes.";
		this.wizardPage2.Name = "wizardPage2";
		this.wizardPage2.Size = new System.Drawing.Size(590, 312);
		this.wizardPage2.Text = "Promote Progress";
		this.lblTaskPromote.Location = new System.Drawing.Point(264, 272);
		this.lblTaskPromote.Name = "lblTaskPromote";
		this.lblTaskPromote.Size = new System.Drawing.Size(63, 13);
		this.lblTaskPromote.TabIndex = 3;
		this.lblTaskPromote.Text = "labelControl6";
		this.progressTransferCandidates.Location = new System.Drawing.Point(22, 171);
		this.progressTransferCandidates.Name = "progressTransferCandidates";
		this.progressTransferCandidates.Properties.ShowTitle = true;
		this.progressTransferCandidates.Size = new System.Drawing.Size(546, 30);
		this.progressTransferCandidates.TabIndex = 2;
		this.lblTaskCandidates.Location = new System.Drawing.Point(264, 207);
		this.lblTaskCandidates.Name = "lblTaskCandidates";
		this.lblTaskCandidates.Size = new System.Drawing.Size(63, 13);
		this.lblTaskCandidates.TabIndex = 1;
		this.lblTaskCandidates.Text = "labelControl5";
		this.progressPromoteStudents.Location = new System.Drawing.Point(22, 236);
		this.progressPromoteStudents.Name = "progressPromoteStudents";
		this.progressPromoteStudents.Properties.ShowTitle = true;
		this.progressPromoteStudents.Size = new System.Drawing.Size(546, 30);
		this.progressPromoteStudents.TabIndex = 0;
		this.bgPromoteStudents.WorkerReportsProgress = true;
		this.bgPromoteStudents.WorkerSupportsCancellation = true;
		this.bgPromoteStudents.DoWork += new System.ComponentModel.DoWorkEventHandler(bgPromoteStudents_DoWork);
		this.bgPromoteStudents.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(bgPromoteStudents_ProgressChanged);
		this.bgPromoteStudents.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgPromoteStudents_RunWorkerCompleted);
		this.bgTransferCandidate.WorkerReportsProgress = true;
		this.bgTransferCandidate.WorkerSupportsCancellation = true;
		this.bgTransferCandidate.DoWork += new System.ComponentModel.DoWorkEventHandler(bgTransferCandidate_DoWork);
		this.bgTransferCandidate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(bgTransferCandidate_ProgressChanged);
		this.bgTransferCandidate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgTransferCandidate_RunWorkerCompleted);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[4] { this.bandedGridColClass, this.bandedGridColPromote, this.bandedGridColPOB, this.bandedGridColRepeat });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.bandedGridColClass.Caption = "Class";
		this.bandedGridColClass.Name = "bandedGridColClass";
		this.bandedGridColClass.Visible = true;
		this.bandedGridColClass.VisibleIndex = 0;
		this.bandedGridColClass.Width = 143;
		this.bandedGridColPromote.Caption = "Promote";
		this.bandedGridColPromote.Name = "bandedGridColPromote";
		this.bandedGridColPromote.Visible = true;
		this.bandedGridColPromote.VisibleIndex = 1;
		this.bandedGridColPromote.Width = 129;
		this.bandedGridColPOB.Caption = "POB";
		this.bandedGridColPOB.Name = "bandedGridColPOB";
		this.bandedGridColPOB.Visible = true;
		this.bandedGridColPOB.VisibleIndex = 2;
		this.bandedGridColPOB.Width = 167;
		this.bandedGridColRepeat.Caption = "Repeat";
		this.bandedGridColRepeat.Name = "bandedGridColRepeat";
		this.bandedGridColRepeat.Visible = true;
		this.bandedGridColRepeat.VisibleIndex = 3;
		this.bandedGridColRepeat.Width = 177;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(622, 457);
		base.Controls.Add(this.wizardControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "PromotePupils";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Promote Pupils";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(PromoteStudents_FormClosing);
		base.Load += new System.EventHandler(PromoteStudents_Load);
		((System.ComponentModel.ISupportInitialize)this.wizardControl1).EndInit();
		this.wizardControl1.ResumeLayout(false);
		this.welcomeWizardPage1.ResumeLayout(false);
		this.welcomeWizardPage1.PerformLayout();
		this.wizardPage1.ResumeLayout(false);
		this.wizardPage1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtExitYear.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.radioGroup1.Properties).EndInit();
		this.wizardPage2.ResumeLayout(false);
		this.wizardPage2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.progressTransferCandidates.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.progressPromoteStudents.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		base.ResumeLayout(false);
	}
}
