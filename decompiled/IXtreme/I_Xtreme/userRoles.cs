using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace I_Xtreme;

public class userRoles : XtraForm
{
	private DataTable dt;

	private DataSet ds;

	private IContainer components = null;

	private GridControl gridControl1;

	private GridView gridView1;

	private PanelControl panelControl1;

	private SimpleButton simpleButton1;

	private ListBoxControl listBoxControl1;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	public userRoles()
	{
		InitializeComponent();
	}

	private void LoadUserGroups(int groupId)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_UserGroups WHERE GroupId={groupId}", selectConnection);
			ds = new DataSet();
			sqlDataAdapter.Fill(ds, "UserGroups");
			dt = new DataTable();
			dt = ds.Tables[0];
			gridControl1.DataSource = dt.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void userRoles_Load(object sender, EventArgs e)
	{
		LoadUserGroups(1);
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
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		this.panelControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.listBoxControl1).BeginInit();
		base.SuspendLayout();
		this.gridControl1.Location = new System.Drawing.Point(1, 193);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(517, 180);
		this.gridControl1.TabIndex = 0;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsCustomization.AllowGroup = false;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.panelControl1.Controls.Add(this.simpleButton1);
		this.panelControl1.Location = new System.Drawing.Point(1, 377);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(517, 36);
		this.panelControl1.TabIndex = 1;
		this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton1.Location = new System.Drawing.Point(5, 8);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(75, 23);
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "Close";
		this.listBoxControl1.Location = new System.Drawing.Point(1, 30);
		this.listBoxControl1.Name = "listBoxControl1";
		this.listBoxControl1.Size = new System.Drawing.Size(517, 140);
		this.listBoxControl1.TabIndex = 2;
		this.labelControl1.Location = new System.Drawing.Point(6, 10);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(58, 13);
		this.labelControl1.TabIndex = 3;
		this.labelControl1.Text = "Group name";
		this.labelControl2.Location = new System.Drawing.Point(6, 174);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(167, 13);
		this.labelControl2.TabIndex = 4;
		this.labelControl2.Text = "Permissions for the Selected Group";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(521, 415);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.listBoxControl1);
		base.Controls.Add(this.panelControl1);
		base.Controls.Add(this.gridControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "userRoles";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "User roles";
		base.Load += new System.EventHandler(userRoles_Load);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		this.panelControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.listBoxControl1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
