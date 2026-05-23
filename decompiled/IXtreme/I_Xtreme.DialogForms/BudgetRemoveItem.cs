using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Accounts;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace I_Xtreme.DialogForms;

public class BudgetRemoveItem : XtraForm
{
	private DataTable dt;

	private string _BudgetType = string.Empty;

	private string _BudgetPeriod = string.Empty;

	public BudgetParameters BudgetRefresh;

	private IContainer components = null;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private LabelControl labelControl1;

	private LabelControl lblEntryName;

	private LabelControl labelControl2;

	public BudgetRemoveItem(string BudgetType, string BudgetPeriod, string EntryName, string EntryID)
	{
		InitializeComponent();
		lblEntryName.Text = $"({EntryID}-{EntryName})";
		_BudgetType = BudgetType;
		_BudgetPeriod = BudgetPeriod;
		Text = $"Budget - {BudgetPeriod}";
	}

	private void LoadSemesterBudget(string __BudgetType, string __BudgetPeriod)
	{
		try
		{
			dt = new DataTable();
			string selectCommandText = string.Empty;
			if (__BudgetType == "Termly")
			{
				selectCommandText = $"SELECT gas.subAccountNo, gas.SubAccoutName AS SubVote, b.semester, b.year, b.qty, b.units, b.rate, (b.rate * b.qty) AS Amount, ga.accName AS Vote FROM tbl_generalAccounts_Sub gas INNER JOIN tbl_budget b ON gas.subAccountNo = b.accNo INNER JOIN tbl_generalAccounts ga ON gas.accNo = ga.accNo WHERE b.semester='{__BudgetPeriod}'";
			}
			else if (__BudgetType == "Annual")
			{
				selectCommandText = $"SELECT gas.subAccountNo, gas.SubAccoutName AS SubVote, b.semester, b.year, b.qty, b.units, b.rate, (b.rate * b.qty) AS Amount, ga.accName AS Vote FROM tbl_generalAccounts_Sub gas INNER JOIN tbl_budget b ON gas.subAccountNo = b.accNo INNER JOIN tbl_generalAccounts ga ON gas.accNo = ga.accNo WHERE b.year='{__BudgetPeriod}'";
			}
			using (SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "Budget");
				dt = dataSet.Tables[0];
			}
			BudgetRefresh("pageBudgetCreate", __BudgetType, __BudgetPeriod, dt);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void DeleteBudgetItem()
	{
		try
		{
			if (_BudgetType == "Termly")
			{
				using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					sqlConnection.Open();
					SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = "SELECT accNo,SemesterId FROM tbl_StatementOfAffairs WHERE accNo=@accNo AND SemesterId=@SemesterId",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("accNo", SqlDbType.VarChar, 9);
					sqlParameter.Value = BudgetItems.BudgetItemID;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
					sqlParameter.Value = _BudgetPeriod;
					sqlParameter.Direction = ParameterDirection.Input;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					if (!sqlDataReader.HasRows)
					{
						sqlDataReader.Close();
						SqlCommand sqlCommand2 = new SqlCommand
						{
							Connection = sqlConnection,
							CommandText = "DELETE FROM tbl_Budget WHERE accNo=@accNo AND semester=@semester",
							CommandType = CommandType.Text
						};
						SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("accNo", SqlDbType.VarChar, 9);
						sqlParameter2.Value = BudgetItems.BudgetItemID;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@semester", SqlDbType.VarChar, 13);
						sqlParameter2.Value = _BudgetPeriod;
						sqlParameter2.Direction = ParameterDirection.Input;
						if (sqlCommand2.ExecuteNonQuery() > 0)
						{
							sqlConnection.Close();
							LoadSemesterBudget(_BudgetType, _BudgetPeriod);
							BudgetItems.SetItemId("Nothing", "Nothing");
							Close();
						}
					}
					else
					{
						sqlDataReader.Close();
						XtraMessageBox.Show($"Item cannot be deleted because it holds reference in expenses for {_BudgetPeriod}", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					return;
				}
			}
			if (!(_BudgetType == "Annual"))
			{
				return;
			}
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			SqlCommand sqlCommand3 = new SqlCommand
			{
				Connection = sqlConnection2,
				CommandText = "SELECT accNo,SemesterId FROM tbl_StatementOfAffairs WHERE accNo=@accNo AND year=@year",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("accNo", SqlDbType.VarChar, 9);
			sqlParameter3.Value = BudgetItems.BudgetItemID;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@year", SqlDbType.Int);
			sqlParameter3.Value = _BudgetPeriod;
			sqlParameter3.Direction = ParameterDirection.Input;
			SqlDataReader sqlDataReader2 = sqlCommand3.ExecuteReader();
			if (!sqlDataReader2.HasRows)
			{
				sqlDataReader2.Close();
				SqlCommand sqlCommand4 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "DELETE FROM tbl_Budget WHERE accNo=@accNo AND year=@year",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter4 = sqlCommand4.Parameters.Add("accNo", SqlDbType.VarChar, 9);
				sqlParameter4.Value = BudgetItems.BudgetItemID;
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@year", SqlDbType.VarChar, 4);
				sqlParameter4.Value = _BudgetPeriod;
				sqlParameter4.Direction = ParameterDirection.Input;
				if (sqlCommand4.ExecuteNonQuery() > 0)
				{
					sqlConnection2.Close();
					LoadSemesterBudget(_BudgetType, _BudgetPeriod);
					BudgetItems.SetItemId("Nothing", "Nothing");
					Close();
				}
			}
			else
			{
				sqlDataReader2.Close();
				sqlDataReader2.Close();
				XtraMessageBox.Show($"Item cannot be deleted because it holds reference in expenses for {_BudgetPeriod}", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		DeleteBudgetItem();
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
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.lblEntryName = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		base.SuspendLayout();
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Yes;
		this.simpleButton1.Location = new System.Drawing.Point(18, 140);
		this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(249, 35);
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "Yes";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.No;
		this.simpleButton2.Location = new System.Drawing.Point(304, 140);
		this.simpleButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(249, 35);
		this.simpleButton2.TabIndex = 1;
		this.simpleButton2.Text = "No";
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseTextOptions = true;
		this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Location = new System.Drawing.Point(12, 29);
		this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(549, 28);
		this.labelControl1.TabIndex = 2;
		this.labelControl1.Text = "Do you really want to delete the selected entry?";
		this.lblEntryName.Appearance.Font = new System.Drawing.Font("Tahoma", 9f);
		this.lblEntryName.Appearance.Options.UseFont = true;
		this.lblEntryName.Appearance.Options.UseTextOptions = true;
		this.lblEntryName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblEntryName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblEntryName.Location = new System.Drawing.Point(12, 70);
		this.lblEntryName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.lblEntryName.Name = "lblEntryName";
		this.lblEntryName.Size = new System.Drawing.Size(549, 28);
		this.lblEntryName.TabIndex = 3;
		this.lblEntryName.Text = "labelControl2";
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl2.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
		this.labelControl2.LineVisible = true;
		this.labelControl2.Location = new System.Drawing.Point(12, 108);
		this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(549, 23);
		this.labelControl2.TabIndex = 4;
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(572, 193);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.lblEntryName);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		base.Name = "BudgetRemoveItem";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Confirm";
		base.ResumeLayout(false);
	}
}
