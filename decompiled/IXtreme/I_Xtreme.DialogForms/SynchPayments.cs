using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.DataSync;
using AlienAge.Security;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using Newtonsoft.Json;

namespace I_Xtreme.DialogForms;

public class SynchPayments : XtraForm
{
	private int j = 0;

	private int k = 0;

	private int maximum = 0;

	private string connString = DataConnection.ConnectToDatabase();

	private IContainer components = null;

	private SimpleButton simpleButton1;

	private ProgressBarControl progressBarControl1;

	private SimpleButton simpleButton2;

	private BackgroundWorker backgroundWorker1;

	private DXValidationProvider dxValidationProvider1;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private EmptySpaceItem emptySpaceItem1;

	public SynchPayments()
	{
		InitializeComponent();
	}

	public static int GenerateFiveDigitNumber()
	{
		Random random = new Random();
		return random.Next(10000, 100000);
	}

	private void PostData()
	{
		try
		{
			string schoolCode = SerialNumber.GetSchoolCode(connString);
			string cmdText = "Select StudentNumber,Credit,PaymentId,BankSlipNo,SemesterId FROM FeesPayment WHERE IsSynched=0 AND Credit>0 AND ModeOfPayment<>'Surepay' ORDER BY PaymentId";
			string cmdText2 = "Select Count(PaymentId) AS PaymentId FROM FeesPayment WHERE IsSynched=0 AND Credit>0";
			using SqlConnection sqlConnection = new SqlConnection(connString);
			sqlConnection.Open();
			using (SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection))
			{
				int num = (int)sqlCommand.ExecuteScalar();
				maximum = num;
			}
			k = 1;
			string empty = string.Empty;
			double result = 0.0;
			long result2 = 0L;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			DateTime now = DateTime.Now;
			using SqlCommand sqlCommand2 = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
			while (sqlDataReader.Read())
			{
				empty = sqlDataReader[0].ToString();
				if (DataSyncHelper.StudentExists(empty) == "OK")
				{
					result = (double.TryParse(sqlDataReader[1].ToString(), out result) ? result : 0.0);
					result2 = (long.TryParse(sqlDataReader[2].ToString(), out result2) ? result2 : 0);
					empty2 = sqlDataReader[3].ToString();
					empty4 = sqlDataReader[4].ToString();
					empty3 = string.Empty;
					string requestUriString = DataSyncHelper.UrlString + "/api/feespayment/uploadpayment/" + schoolCode;
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
					httpWebRequest.Method = "POST";
					httpWebRequest.Headers["6CD14B34-E080-4AEC-995A-0BC03CCABE6B"] = DataSyncHelper.ApiKey;
					httpWebRequest.ContentType = "application/json";
					using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
					{
						empty3 = JsonConvert.SerializeObject(new
						{
							amountPaid = result,
							studentNo = empty,
							telcomCarrier = "Onsite Payment",
							transactionRef = empty2,
							localPaymentID = result2,
							term = empty4,
							trxDate = now
						});
						streamWriter.Write(empty3);
					}
					HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
					using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
					{
						string text = streamReader.ReadToEnd();
					}
					string text2 = httpWebResponse.StatusDescription.ToString();
					if (text2 == "OK")
					{
						using SqlCommand sqlCommand3 = new SqlCommand
						{
							Connection = sqlConnection,
							CommandText = "UPDATE FeesPayment SET IsSynched = 1 WHERE PaymentId=@PaymentId",
							CommandType = CommandType.Text
						};
						SqlParameter sqlParameter = sqlCommand3.Parameters.Add("@PaymentId", SqlDbType.BigInt);
						sqlParameter.Value = result2;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand3.ExecuteNonQuery();
					}
				}
				else
				{
					j++;
				}
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			j = 0;
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
		if (j > 0)
		{
			XtraMessageBox.Show($"{j.ToString()} records not synced because their corresponding student records are not yet uploaded", "Completed with warnings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		else
		{
			XtraMessageBox.Show("All processes completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		simpleButton1.Enabled = true;
		simpleButton2.Enabled = true;
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		PostData();
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
		this.components = new System.ComponentModel.Container();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).BeginInit();
		base.SuspendLayout();
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(190, 86);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(185, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "Close";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.progressBarControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(377, 110);
		this.layoutControl1.TabIndex = 7;
		this.layoutControl1.Text = "layoutControl1";
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.Location = new System.Drawing.Point(2, 86);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(184, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 1;
		this.simpleButton2.Text = "Sync Data";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.progressBarControl1.Location = new System.Drawing.Point(2, 2);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Size = new System.Drawing.Size(373, 44);
		this.progressBarControl1.StyleController = this.layoutControl1;
		this.progressBarControl1.TabIndex = 4;
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[4] { this.layoutControlItem1, this.layoutControlItem3, this.emptySpaceItem1, this.layoutControlItem4 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.Root.Size = new System.Drawing.Size(377, 110);
		this.Root.TextVisible = false;
		this.layoutControlItem1.Control = this.progressBarControl1;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 56);
		this.layoutControlItem1.MinSize = new System.Drawing.Size(54, 18);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(377, 48);
		this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem3.Control = this.simpleButton1;
		this.layoutControlItem3.Location = new System.Drawing.Point(188, 84);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(189, 26);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(377, 36);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.Control = this.simpleButton2;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 84);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(188, 26);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.backgroundWorker1.WorkerReportsProgress = true;
		this.backgroundWorker1.WorkerSupportsCancellation = true;
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
		this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(377, 110);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SynchPayments";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Sync Payments";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).EndInit();
		base.ResumeLayout(false);
	}
}
