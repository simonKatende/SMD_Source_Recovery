using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.Security;
using DevExpress.XtraEditors;

namespace I_Xtreme.DialogForms;

public class NormalizeNumbers : XtraForm
{
	private int i = 0;

	private IContainer components = null;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private Label label1;

	public NormalizeNumbers()
	{
		InitializeComponent();
	}

	private string StudentCode(string num)
	{
		string text = "";
		return num.Length switch
		{
			1 => "0000" + num, 
			2 => "000" + num, 
			3 => "00" + num, 
			4 => "0" + num, 
			_ => "0000", 
		};
	}

	private void NormalizeNumbersAsync()
	{
		try
		{
			simpleButton1.Enabled = false;
			label1.Text = "Working. Please wait...";
			Application.DoEvents();
			string text = DataConnection.ConnectToDatabase();
			string schoolCode = SerialNumber.GetSchoolCode(text);
			int num = SchoolSettings.CurriculumInUse(text);
			string selectCommandText = "SELECT auto,StudentNumber,ClassId,fullName FROM tbl_Stud ORDER BY ClassId,fullName";
			string text2 = "";
			string empty = string.Empty;
			string text3 = DateTime.Now.ToString("yy");
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, text);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			foreach (DataRow row in dataTable.Rows)
			{
				string value = row["StudentNumber"].ToString();
				i++;
				string text4 = StudentCode(i.ToString());
				text2 = schoolCode + text4;
				using SqlConnection sqlConnection = new SqlConnection(text);
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = sqlTransaction,
					CommandType = CommandType.Text,
					CommandText = "UPDATE tbl_Stud SET StudentNumber=@StudentNumber WHERE StudentNumber=@OldNumber"
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.NVarChar, 12);
					sqlParameter.Value = text2;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@OldNumber", SqlDbType.NVarChar, 12);
					sqlParameter.Value = value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = sqlTransaction,
					CommandType = CommandType.Text,
					CommandText = "UPDATE FeesPayment SET StudentNumber=@StudentNumber WHERE StudentNumber=@OldNumber"
				})
				{
					SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.NVarChar, 12);
					sqlParameter2.Value = text2;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@OldNumber", SqlDbType.NVarChar, 12);
					sqlParameter2.Value = value;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = sqlTransaction,
					CommandType = CommandType.Text,
					CommandText = "UPDATE tbl_Scores_OL_Report SET StudentNumber=@StudentNumber WHERE StudentNumber=@OldNumber"
				})
				{
					SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.NVarChar, 12);
					sqlParameter3.Value = text2;
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand3.Parameters.Add("@OldNumber", SqlDbType.NVarChar, 12);
					sqlParameter3.Value = value;
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlCommand3.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand4 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = sqlTransaction,
					CommandType = CommandType.Text,
					CommandText = "UPDATE tbl_Scores_AL SET StudentNumber=@StudentNumber WHERE StudentNumber=@OldNumber"
				})
				{
					SqlParameter sqlParameter4 = sqlCommand4.Parameters.Add("@StudentNumber", SqlDbType.NVarChar, 12);
					sqlParameter4.Value = text2;
					sqlParameter4.Direction = ParameterDirection.Input;
					sqlParameter4 = sqlCommand4.Parameters.Add("@OldNumber", SqlDbType.NVarChar, 12);
					sqlParameter4.Value = value;
					sqlParameter4.Direction = ParameterDirection.Input;
					sqlCommand4.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand5 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = sqlTransaction,
					CommandType = CommandType.Text,
					CommandText = "UPDATE tbl_GeneralReport_Grading_AL SET StudentNumber=@StudentNumber WHERE StudentNumber=@OldNumber"
				})
				{
					SqlParameter sqlParameter5 = sqlCommand5.Parameters.Add("@StudentNumber", SqlDbType.NVarChar, 12);
					sqlParameter5.Value = text2;
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlParameter5 = sqlCommand5.Parameters.Add("@OldNumber", SqlDbType.NVarChar, 12);
					sqlParameter5.Value = value;
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlCommand5.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand6 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = sqlTransaction,
					CommandType = CommandType.Text,
					CommandText = "UPDATE tbl_GeneralReport_AL SET StudentNumber=@StudentNumber WHERE StudentNumber=@OldNumber"
				})
				{
					SqlParameter sqlParameter6 = sqlCommand6.Parameters.Add("@StudentNumber", SqlDbType.NVarChar, 12);
					sqlParameter6.Value = text2;
					sqlParameter6.Direction = ParameterDirection.Input;
					sqlParameter6 = sqlCommand6.Parameters.Add("@OldNumber", SqlDbType.NVarChar, 12);
					sqlParameter6.Value = value;
					sqlParameter6.Direction = ParameterDirection.Input;
					sqlCommand6.ExecuteNonQuery();
				}
				sqlTransaction.Commit();
				sqlConnection.Close();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			simpleButton1.Enabled = true;
			Application.DoEvents();
		}
		finally
		{
			XtraMessageBox.Show("Normalizing completed successfully", "Succees", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			label1.Text = "Normalize Completed";
			simpleButton1.Enabled = true;
			Application.DoEvents();
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		NormalizeNumbersAsync();
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
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.label1 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.simpleButton1.Location = new System.Drawing.Point(12, 54);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(190, 22);
		this.simpleButton1.TabIndex = 5;
		this.simpleButton1.Text = "Start Normalize";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(246, 54);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(190, 22);
		this.simpleButton2.TabIndex = 6;
		this.simpleButton2.Text = "Close";
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Tahoma", 18f);
		this.label1.Location = new System.Drawing.Point(12, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(0, 29);
		this.label1.TabIndex = 7;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(448, 81);
		base.ControlBox = false;
		base.Controls.Add(this.label1);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "NormalizeNumbers";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Normalize Numbers";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
