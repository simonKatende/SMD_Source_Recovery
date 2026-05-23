using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.DialogForms;

public class ConfirmDelete : XtraForm
{
	public StartOrStopTimer StartTimer;

	private IContainer components = null;

	private LabelControl labelControl1;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	public LabelControl lblDeleteWhat;

	public ConfirmDelete()
	{
		InitializeComponent();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (lblDeleteWhat.Text == "StockItem")
		{
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "SELECT * FROM tbl_OrderdDetails WHERE itemId=@itemId",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@itemId", SqlDbType.BigInt);
				sqlParameter.Value = InventoryItem.StockCategoryID;
				sqlParameter.Direction = ParameterDirection.Input;
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (!sqlDataReader.HasRows)
				{
					sqlConnection.Close();
					using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection2.Open();
					using SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						CommandText = "DELETE FROM tbl_StockItems WHERE id=@id",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@id", SqlDbType.BigInt);
					sqlParameter2.Value = InventoryItem.StockCategoryID;
					sqlParameter2.Direction = ParameterDirection.Input;
					if (sqlCommand2.ExecuteNonQuery() > 0)
					{
						StartTimer(timerStatus: true);
						sqlConnection2.Close();
						Dispose();
					}
					return;
				}
				sqlConnection.Close();
				XtraMessageBox.Show("The selected item cannot be deleted because it holds reference to a supplier invoice.", "School Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
		}
		if (lblDeleteWhat.Text == "supplier")
		{
			using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection3.Open();
				using SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection3,
					CommandText = $"SELECT * FROM tbl_Orders WHERE SupplierID={SupplierOptions.ActiveSupplierID}",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader2 = sqlCommand3.ExecuteReader();
				if (sqlDataReader2.HasRows)
				{
					sqlConnection3.Close();
					XtraMessageBox.Show("This supplier cannnot be deleted because there are invoices referenced to this company.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				sqlConnection3.Close();
				using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection4.Open();
				using SqlCommand sqlCommand4 = new SqlCommand
				{
					Connection = sqlConnection4,
					CommandText = $"DELETE FROM tbl_Suppliers WHERE Company='{SupplierOptions.ActiveCompanyName()}'",
					CommandType = CommandType.Text
				};
				if (sqlCommand4.ExecuteNonQuery() > 0)
				{
					StartTimer(timerStatus: true);
					sqlConnection4.Close();
					Dispose();
				}
				return;
			}
		}
		if (lblDeleteWhat.Text == "employee")
		{
			using (SqlConnection sqlConnection5 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection5.Open();
				using SqlCommand sqlCommand5 = new SqlCommand
				{
					Connection = sqlConnection5,
					CommandText = $"SELECT * FROM tbl_emplDebts WHERE EmployeeNumber='{StaffOptions.ActiveStaffID()}'",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader3 = sqlCommand5.ExecuteReader();
				if (sqlDataReader3.HasRows)
				{
					sqlConnection5.Close();
					XtraMessageBox.Show("This employee cannot be deleted because he/she has salary payment records attached to him/her.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				sqlConnection5.Close();
				using SqlConnection sqlConnection6 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection6.Open();
				using SqlCommand sqlCommand6 = new SqlCommand
				{
					Connection = sqlConnection6,
					CommandText = $"DELETE FROM Staff WHERE StaffId='{StaffOptions.ActiveStaffID()}'",
					CommandType = CommandType.Text
				};
				if (sqlCommand6.ExecuteNonQuery() > 0)
				{
					StartTimer(timerStatus: true);
					sqlConnection6.Close();
					Dispose();
				}
				return;
			}
		}
		if (lblDeleteWhat.Text == "student")
		{
			StudentOptions.DeleteStudentConditionally(StudentOptions.ActiveStudent(), StudentOptions.ActiveGuid, StudentOptions.ActiveClass());
			StartTimer(timerStatus: true);
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
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.lblDeleteWhat = new DevExpress.XtraEditors.LabelControl();
		base.SuspendLayout();
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl1.Location = new System.Drawing.Point(9, 23);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(272, 16);
		this.labelControl1.TabIndex = 0;
		this.labelControl1.Text = "Do you really want to delete the selected entry?";
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Yes;
		this.simpleButton1.Location = new System.Drawing.Point(7, 62);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(142, 23);
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "&Yes";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.No;
		this.simpleButton2.Location = new System.Drawing.Point(157, 62);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(142, 23);
		this.simpleButton2.TabIndex = 1;
		this.simpleButton2.Text = "&No";
		this.lblDeleteWhat.Location = new System.Drawing.Point(11, 10);
		this.lblDeleteWhat.Name = "lblDeleteWhat";
		this.lblDeleteWhat.Size = new System.Drawing.Size(63, 13);
		this.lblDeleteWhat.TabIndex = 2;
		this.lblDeleteWhat.Text = "labelControl2";
		this.lblDeleteWhat.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(303, 98);
		base.Controls.Add(this.lblDeleteWhat);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.labelControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.Name = "ConfirmDelete";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Confirm";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
