using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.DataSync;
using AlienAge.Security;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using Newtonsoft.Json;

namespace I_Xtreme.DialogForms;

public class SynchStudents : XtraForm
{
	private static string conString = DataConnection.ConnectToDatabase();

	private IContainer components = null;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private Label label1;

	private LayoutControlItem layoutControlItem3;

	public SynchStudents()
	{
		InitializeComponent();
	}

	private static void UpdateSynchedStudents(string studentNo)
	{
		SqlConnection sqlConnection = new SqlConnection(conString);
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "UPDATE tbl_Stud SET IsSynched=1 WHERE StudentNumber=@StudentNumber",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
		sqlParameter.Value = studentNo;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
	}

	private void PostData()
	{
		try
		{
			simpleButton2.Enabled = false;
			label1.Text = "Working. Please wait...";
			Application.DoEvents();
			string schoolCodeMapping = SerialNumber.GetSchoolCodeMapping();
			string cmdText = "SELECT StudentNumber,StudentID,LIN,fullName,ClassId,StreamId,StudyStatus,Sex,HouseId FROM tbl_Stud WHERE IsSynched=0 ORDER BY ClassId";
			using SqlConnection sqlConnection = new SqlConnection(conString);
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				while (true)
				{
					string studentNo = sqlDataReader[0].ToString();
					string empty = string.Empty;
					try
					{
						string requestUriString = DataSyncHelper.UrlString + "/api/student/sync/" + schoolCodeMapping;
						HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
						httpWebRequest.Method = "POST";
						httpWebRequest.Headers["6CD14B34-E080-4AEC-995A-0BC03CCABE6B"] = DataSyncHelper.ApiKey;
						httpWebRequest.ContentType = "application/json";
						using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
						{
							empty = JsonConvert.SerializeObject(new
							{
								paymentCode = sqlDataReader[0],
								studentID = sqlDataReader[1],
								lin = sqlDataReader[2],
								name = sqlDataReader[3],
								studentClass = sqlDataReader[4],
								studentStream = sqlDataReader[5],
								studyStatus = sqlDataReader[6],
								gender = sqlDataReader[7],
								house = sqlDataReader[8]
							});
							streamWriter.Write(empty);
							streamWriter.Close();
						}
						HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
						using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
						{
							string text = streamReader.ReadToEnd();
						}
						int statusCode = (int)httpWebResponse.StatusCode;
						if (httpWebResponse.StatusCode == HttpStatusCode.OK)
						{
							UpdateSynchedStudents(studentNo);
						}
					}
					catch (Exception)
					{
						continue;
					}
					break;
				}
			}
		}
		catch (Exception ex2)
		{
			XtraMessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			simpleButton2.Enabled = true;
			Application.DoEvents();
		}
		finally
		{
			XtraMessageBox.Show("Normalizing completed successfully", "Succees", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			label1.Text = "Normalize Completed";
			simpleButton2.Enabled = true;
			Application.DoEvents();
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		PostData();
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
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.label1 = new System.Windows.Forms.Label();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(191, 67);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(186, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "Close";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.layoutControl1.Controls.Add(this.label1);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(427, 0, 650, 400);
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(379, 91);
		this.layoutControl1.TabIndex = 5;
		this.layoutControl1.Text = "layoutControl1";
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.Location = new System.Drawing.Point(2, 67);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(185, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 1;
		this.simpleButton2.Text = "Sync Data";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem2, this.layoutControlItem1, this.layoutControlItem3 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.Root.Size = new System.Drawing.Size(379, 91);
		this.Root.TextVisible = false;
		this.layoutControlItem2.Control = this.simpleButton2;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 65);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(189, 26);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem1.Control = this.simpleButton1;
		this.layoutControlItem1.Location = new System.Drawing.Point(189, 65);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(190, 26);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.label1.Font = new System.Drawing.Font("Tahoma", 16f);
		this.label1.Location = new System.Drawing.Point(2, 2);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(375, 61);
		this.label1.TabIndex = 4;
		this.layoutControlItem3.Control = this.label1;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(379, 65);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(379, 91);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SynchStudents";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Sync Students";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
