using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class ResetSubjectLogin : XtraForm
{
	private DataSet ds_PWD;

	private DataTable dt_PWD;

	public StartOrStopTimer StartTimer;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private SimpleButton simpleButton3;

	private GridControl gridControl1;

	private GridView gridView1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private EmptySpaceItem emptySpaceItem1;

	public SimpleButton btnDeleteAccount;

	public SimpleButton btnResetAccount;

	public ResetSubjectLogin()
	{
		InitializeComponent();
	}

	private void LoadSubjectLogins()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT l.id,s.StaffName AS Name,l.staffId,l.ClassId AS Class,l.SubjectId AS Subject from tbl_subjectLogin l INNER JOIN Staff s ON l.staffId = s.StaffId", selectConnection);
			ds_PWD = new DataSet();
			sqlDataAdapter.Fill(ds_PWD, "SubjectLogins");
			dt_PWD = new DataTable();
			dt_PWD = ds_PWD.Tables[0];
			gridControl1.DataSource = dt_PWD.DefaultView;
			gridView1.Columns["id"].Visible = false;
			gridView1.Columns["staffId"].Visible = false;
			gridView1.Columns["Name"].GroupIndex = 0;
			gridView1.Columns["Class"].GroupIndex = 1;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void DeleteSubjectLogin()
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "DELETE FROM tbl_subjectLogin WHERE id=@id",
				CommandType = CommandType.Text
			};
			DataRow dataRow = dt_PWD.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@id", SqlDbType.Int);
			sqlParameter.Value = dataRow["id"];
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				sqlConnection.Close();
				StartTimer(timerStatus: true);
				LoadSubjectLogins();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void DeleteEntireUserLogin()
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "DELETE FROM tbl_subjectLogin WHERE StaffId=@StaffId",
				CommandType = CommandType.Text
			};
			DataRow dataRow = dt_PWD.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StaffId", SqlDbType.VarChar, 50);
			sqlParameter.Value = dataRow["StaffId"];
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				sqlConnection.Close();
				StartTimer(timerStatus: true);
				LoadSubjectLogins();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void ResetUserLogin()
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "UPDATE tbl_subjectLogin SET Login=@Login, Password=@Password,Password2=@Password2 WHERE StaffId=@StaffId",
				CommandType = CommandType.Text
			};
			DataRow dataRow = dt_PWD.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Login", SqlDbType.VarChar, 50);
			sqlParameter.Value = DBNull.Value;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Password", SqlDbType.VarChar, 50);
			sqlParameter.Value = DBNull.Value;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Password2", SqlDbType.VarChar, 50);
			sqlParameter.Value = DBNull.Value;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@StaffId", SqlDbType.VarChar, 50);
			sqlParameter.Value = dataRow["StaffId"];
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				sqlConnection.Close();
				StartTimer(timerStatus: true);
				LoadSubjectLogins();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void ResetSubjectLogin_Load(object sender, EventArgs e)
	{
		LoadSubjectLogins();
	}

	private void btnDeleteAccount_Click(object sender, EventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() <= -1)
		{
			return;
		}
		DataRow dataRow = dt_PWD.Rows[gridView1.GetFocusedDataSourceRowIndex()];
		using ConfirmSubjectLoginDelete confirmSubjectLoginDelete = new ConfirmSubjectLoginDelete();
		confirmSubjectLoginDelete.lblDeleteAction.Text = string.Format("How do you wish to delete the login for {0}?", dataRow["Name"].ToString().ToUpper());
		switch (confirmSubjectLoginDelete.ShowDialog())
		{
		case DialogResult.OK:
			DeleteSubjectLogin();
			break;
		case DialogResult.Yes:
			DeleteEntireUserLogin();
			break;
		}
	}

	private void btnResetAccount_Click(object sender, EventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = dt_PWD.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			DialogResult dialogResult = XtraMessageBox.Show(string.Format("Are you sure you want to reset {0}", dataRow["Name"].ToString().ToUpper()), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				ResetUserLogin();
			}
		}
		else
		{
			XtraMessageBox.Show("Please select a user login from the list.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
		this.btnDeleteAccount = new DevExpress.XtraEditors.SimpleButton();
		this.btnResetAccount = new DevExpress.XtraEditors.SimpleButton();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.simpleButton3);
		this.layoutControl1.Controls.Add(this.btnDeleteAccount);
		this.layoutControl1.Controls.Add(this.btnResetAccount);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(568, 488);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.simpleButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton3.Location = new System.Drawing.Point(480, 462);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(84, 22);
		this.simpleButton3.StyleController = this.layoutControl1;
		this.simpleButton3.TabIndex = 7;
		this.simpleButton3.Text = "Close";
		this.btnDeleteAccount.Location = new System.Drawing.Point(480, 4);
		this.btnDeleteAccount.Name = "btnDeleteAccount";
		this.btnDeleteAccount.Size = new System.Drawing.Size(84, 22);
		this.btnDeleteAccount.StyleController = this.layoutControl1;
		this.btnDeleteAccount.TabIndex = 6;
		this.btnDeleteAccount.Text = "Delete Account";
		this.btnDeleteAccount.Click += new System.EventHandler(btnDeleteAccount_Click);
		this.btnResetAccount.Location = new System.Drawing.Point(480, 30);
		this.btnResetAccount.Name = "btnResetAccount";
		this.btnResetAccount.Size = new System.Drawing.Size(84, 22);
		this.btnResetAccount.StyleController = this.layoutControl1;
		this.btnResetAccount.TabIndex = 5;
		this.btnResetAccount.Text = "Reset Account";
		this.btnResetAccount.Click += new System.EventHandler(btnResetAccount_Click);
		this.gridControl1.Location = new System.Drawing.Point(4, 4);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(472, 480);
		this.gridControl1.TabIndex = 4;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsFind.AlwaysVisible = true;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[5] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.emptySpaceItem1 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(568, 488);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(476, 484);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.btnResetAccount;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(476, 26);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(88, 26);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.btnDeleteAccount;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(476, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(88, 26);
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.Control = this.simpleButton3;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(476, 458);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(88, 26);
		this.layoutControlItem4.Text = "layoutControlItem4";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextToControlDistance = 0;
		this.layoutControlItem4.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(476, 52);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(88, 406);
		this.emptySpaceItem1.Text = "emptySpaceItem1";
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(568, 488);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "ResetSubjectLogin";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "ResetSubjectLogin";
		base.Load += new System.EventHandler(ResetSubjectLogin_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		base.ResumeLayout(false);
	}
}
