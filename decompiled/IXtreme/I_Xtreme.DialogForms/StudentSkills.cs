using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;

namespace I_Xtreme.DialogForms;

public class StudentSkills : XtraForm
{
	private string clubs = string.Empty;

	private string genericskills = string.Empty;

	private string gamesandsports = string.Empty;

	private string studentNo = string.Empty;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private XtraTabControl xtraTabControl1;

	private XtraTabPage xtraTabPage1;

	private XtraTabPage xtraTabPage2;

	private XtraTabPage xtraTabPage3;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControl layoutControl2;

	private MemoEdit txtGamesAndSports;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem4;

	private LayoutControl layoutControl3;

	private MemoEdit txtClubs;

	private LayoutControlGroup layoutControlGroup2;

	private LayoutControlItem layoutControlItem5;

	private LayoutControl layoutControl4;

	private MemoEdit txtGenericSkills;

	private LayoutControlGroup layoutControlGroup3;

	private LayoutControlItem layoutControlItem6;

	public StudentSkills()
	{
		InitializeComponent();
		LoadStudents();
		txtGamesAndSports.Text = gamesandsports;
		txtClubs.Text = clubs;
		txtGenericSkills.Text = genericskills;
	}

	private void LoadStudents()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT GenericSkills,Clubs,GamesAndSports,StudentNumber FROM tbl_Stud WHERE StudentNumber='{StudentOptions.ActiveStudent()}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		clubs = dataTable.Rows[0]["Clubs"].ToString();
		genericskills = dataTable.Rows[0]["GenericSkills"].ToString();
		gamesandsports = dataTable.Rows[0]["GamesAndSports"].ToString();
		studentNo = dataTable.Rows[0]["StudentNumber"].ToString();
	}

	private void UpdateStudent(string column, string value)
	{
		try
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = $"UPDATE tbl_Stud SET {column}='{value}' WHERE StudentNumber='{studentNo}'",
				CommandType = CommandType.Text
			};
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				sqlConnection.Close();
				XtraMessageBox.Show("Skills saved successfully", "Success");
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (xtraTabControl1.SelectedTabPageIndex == 0)
		{
			UpdateStudent("GamesAndSports", txtGamesAndSports.Text);
		}
		else if (xtraTabControl1.SelectedTabPageIndex == 1)
		{
			UpdateStudent("Clubs", txtClubs.Text);
		}
		else if (xtraTabControl1.SelectedTabPageIndex == 2)
		{
			UpdateStudent("GenericSkills", txtGenericSkills.Text);
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
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
		this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
		this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
		this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControl4 = new DevExpress.XtraLayout.LayoutControl();
		this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.txtGamesAndSports = new DevExpress.XtraEditors.MemoEdit();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.txtClubs = new DevExpress.XtraEditors.MemoEdit();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.txtGenericSkills = new DevExpress.XtraEditors.MemoEdit();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl1).BeginInit();
		this.xtraTabControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		this.xtraTabPage1.SuspendLayout();
		this.xtraTabPage2.SuspendLayout();
		this.xtraTabPage3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl2).BeginInit();
		this.layoutControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl3).BeginInit();
		this.layoutControl3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl4).BeginInit();
		this.layoutControl4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtGamesAndSports.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtClubs.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtGenericSkills.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.xtraTabControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(725, 472);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[4] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.emptySpaceItem1 });
		this.Root.Name = "Root";
		this.Root.Size = new System.Drawing.Size(725, 472);
		this.Root.TextVisible = false;
		this.xtraTabControl1.Location = new System.Drawing.Point(12, 12);
		this.xtraTabControl1.Name = "xtraTabControl1";
		this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
		this.xtraTabControl1.Size = new System.Drawing.Size(701, 422);
		this.xtraTabControl1.TabIndex = 4;
		this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[3] { this.xtraTabPage1, this.xtraTabPage2, this.xtraTabPage3 });
		this.layoutControlItem1.Control = this.xtraTabControl1;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(705, 426);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.xtraTabPage1.Controls.Add(this.layoutControl2);
		this.xtraTabPage1.Name = "xtraTabPage1";
		this.xtraTabPage1.Size = new System.Drawing.Size(699, 397);
		this.xtraTabPage1.Text = "Games and Sports";
		this.xtraTabPage2.Controls.Add(this.layoutControl3);
		this.xtraTabPage2.Name = "xtraTabPage2";
		this.xtraTabPage2.Size = new System.Drawing.Size(699, 397);
		this.xtraTabPage2.Text = "Clubs";
		this.xtraTabPage3.Controls.Add(this.layoutControl4);
		this.xtraTabPage3.Name = "xtraTabPage3";
		this.xtraTabPage3.Size = new System.Drawing.Size(699, 397);
		this.xtraTabPage3.Text = "Generic Skills";
		this.simpleButton1.Location = new System.Drawing.Point(404, 438);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(162, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 5;
		this.simpleButton1.Text = "Save";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.layoutControlItem2.Control = this.simpleButton1;
		this.layoutControlItem2.Location = new System.Drawing.Point(392, 426);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(166, 26);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(570, 438);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(143, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 6;
		this.simpleButton2.Text = "Cancel";
		this.layoutControlItem3.Control = this.simpleButton2;
		this.layoutControlItem3.Location = new System.Drawing.Point(558, 426);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(147, 26);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 426);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(392, 26);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControl2.Controls.Add(this.txtGamesAndSports);
		this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl2.Location = new System.Drawing.Point(0, 0);
		this.layoutControl2.Name = "layoutControl2";
		this.layoutControl2.Root = this.layoutControlGroup1;
		this.layoutControl2.Size = new System.Drawing.Size(699, 397);
		this.layoutControl2.TabIndex = 0;
		this.layoutControl2.Text = "layoutControl2";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem4 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Size = new System.Drawing.Size(699, 397);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControl3.Controls.Add(this.txtClubs);
		this.layoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl3.Location = new System.Drawing.Point(0, 0);
		this.layoutControl3.Name = "layoutControl3";
		this.layoutControl3.Root = this.layoutControlGroup2;
		this.layoutControl3.Size = new System.Drawing.Size(699, 397);
		this.layoutControl3.TabIndex = 0;
		this.layoutControl3.Text = "layoutControl3";
		this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup2.GroupBordersVisible = false;
		this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem5 });
		this.layoutControlGroup2.Name = "layoutControlGroup2";
		this.layoutControlGroup2.Size = new System.Drawing.Size(699, 397);
		this.layoutControlGroup2.TextVisible = false;
		this.layoutControl4.Controls.Add(this.txtGenericSkills);
		this.layoutControl4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl4.Location = new System.Drawing.Point(0, 0);
		this.layoutControl4.Name = "layoutControl4";
		this.layoutControl4.Root = this.layoutControlGroup3;
		this.layoutControl4.Size = new System.Drawing.Size(699, 397);
		this.layoutControl4.TabIndex = 0;
		this.layoutControl4.Text = "layoutControl4";
		this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup3.GroupBordersVisible = false;
		this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem6 });
		this.layoutControlGroup3.Name = "layoutControlGroup3";
		this.layoutControlGroup3.Size = new System.Drawing.Size(699, 397);
		this.layoutControlGroup3.TextVisible = false;
		this.txtGamesAndSports.Location = new System.Drawing.Point(12, 12);
		this.txtGamesAndSports.Name = "txtGamesAndSports";
		this.txtGamesAndSports.Size = new System.Drawing.Size(675, 373);
		this.txtGamesAndSports.StyleController = this.layoutControl2;
		this.txtGamesAndSports.TabIndex = 4;
		this.layoutControlItem4.Control = this.txtGamesAndSports;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(679, 377);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.txtClubs.Location = new System.Drawing.Point(12, 12);
		this.txtClubs.Name = "txtClubs";
		this.txtClubs.Size = new System.Drawing.Size(675, 373);
		this.txtClubs.StyleController = this.layoutControl3;
		this.txtClubs.TabIndex = 4;
		this.layoutControlItem5.Control = this.txtClubs;
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(679, 377);
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextVisible = false;
		this.txtGenericSkills.Location = new System.Drawing.Point(12, 12);
		this.txtGenericSkills.Name = "txtGenericSkills";
		this.txtGenericSkills.Size = new System.Drawing.Size(675, 373);
		this.txtGenericSkills.StyleController = this.layoutControl4;
		this.txtGenericSkills.TabIndex = 4;
		this.layoutControlItem6.Control = this.txtGenericSkills;
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(679, 377);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(725, 472);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "StudentSkills";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Student Skills";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl1).EndInit();
		this.xtraTabControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		this.xtraTabPage1.ResumeLayout(false);
		this.xtraTabPage2.ResumeLayout(false);
		this.xtraTabPage3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl2).EndInit();
		this.layoutControl2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl3).EndInit();
		this.layoutControl3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl4).EndInit();
		this.layoutControl4.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtGamesAndSports.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtClubs.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtGenericSkills.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		base.ResumeLayout(false);
	}
}
