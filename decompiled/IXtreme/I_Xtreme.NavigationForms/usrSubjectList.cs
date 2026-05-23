using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.NavigationForms;

public class usrSubjectList : XtraUserControl
{
	private string schoolType = SchoolSettings.SchoolGeneralCurriculum.ToString();

	private DataTable dt_OLevel;

	private DataTable dt_ALevel;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private GridControl gridControlALevel;

	private GridView gridView2;

	private MyGridControl gridControlOLevel;

	private MyGridView gridView1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private GridColumn gridColName;

	private GridColumn gridColCode;

	private GridColumn gridColSubject;

	private GridColumn gridColPaper;

	private GridColumn gridColShortCode;

	private Timer timerOL;

	private Timer timerAL;

	public usrSubjectList()
	{
		InitializeComponent();
		LoadLevelSubjects();
	}

	public void SubjectsCallBackFN(bool timerStatus)
	{
		timerOL.Enabled = timerStatus;
	}

	private void LoadLevelSubjects()
	{
		try
		{
			string selectConnectionString = DataConnection.ConnectToDatabase();
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelSubjects", selectConnectionString))
			{
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "OLevelSubjects");
				dt_OLevel = new DataTable();
				dt_OLevel = dataSet.Tables[0];
				gridControlOLevel.DataSource = dt_OLevel.DefaultView;
			}
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("SELECT SubjectId,PaperId,Paper,ShortCode FROM ALevelSubjects_Categorised", selectConnectionString);
			using (DataSet dataSet2 = new DataSet())
			{
				sqlDataAdapter2.Fill(dataSet2, "ALevelSubejcts");
				dt_ALevel = new DataTable();
				dt_ALevel = dataSet2.Tables[0];
				gridControlALevel.DataSource = dt_ALevel.DefaultView;
			}
			timerOL.Enabled = false;
			PrintableControl.SavePrintableControl(gridControlOLevel, gridControlALevel);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void gridView1_CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e)
	{
		EmptyForeGroundCustomDraw.DrawEmptyForeGround(e, "No Subjects to display");
	}

	private void gridView2_CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e)
	{
		EmptyForeGroundCustomDraw.DrawEmptyForeGround(e, "No Subjects to display");
	}

	private void timerOL_Tick(object sender, EventArgs e)
	{
		LoadLevelSubjects();
	}

	private void usrSubjectList_Load(object sender, EventArgs e)
	{
		if (schoolType == SchoolSettings.SchoolType.Primary.ToString())
		{
			layoutControlItem1.Text = "Selected Subjects";
		}
		else if (schoolType == SchoolSettings.SchoolType.Secondary.ToString())
		{
			layoutControlItem2.Visibility = LayoutVisibility.Always;
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.gridControlALevel = new DevExpress.XtraGrid.GridControl();
		this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColSubject = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColShortCode = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColPaper = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridControlOLevel = new AlienAge.CustomGrid.MyGridControl();
		this.gridView1 = new AlienAge.CustomGrid.MyGridView();
		this.gridColCode = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColName = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timerOL = new System.Windows.Forms.Timer(this.components);
		this.timerAL = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControlALevel).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControlOLevel).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.gridControlALevel);
		this.layoutControl1.Controls.Add(this.gridControlOLevel);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(555, 494);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.gridControlALevel.Location = new System.Drawing.Point(279, 26);
		this.gridControlALevel.MainView = this.gridView2;
		this.gridControlALevel.Name = "gridControlALevel";
		this.gridControlALevel.Size = new System.Drawing.Size(272, 464);
		this.gridControlALevel.TabIndex = 5;
		this.gridControlALevel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView2.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
		this.gridView2.Appearance.GroupButton.BackColor2 = System.Drawing.Color.Transparent;
		this.gridView2.Appearance.GroupButton.Options.UseBackColor = true;
		this.gridView2.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.Transparent;
		this.gridView2.Appearance.GroupRow.BackColor2 = System.Drawing.Color.Transparent;
		this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
		this.gridView2.Appearance.GroupRow.Options.UseFont = true;
		this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView2.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.Preview.Options.UseFont = true;
		this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.Row.Options.UseFont = true;
		this.gridView2.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridColSubject, this.gridColShortCode, this.gridColPaper });
		this.gridView2.GridControl = this.gridControlALevel;
		this.gridView2.GroupCount = 1;
		this.gridView2.GroupFormat = "{1} {2}";
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView2.OptionsBehavior.Editable = false;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.gridView2.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView2.OptionsView.ShowIndicator = false;
		this.gridView2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColSubject, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridView2.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(gridView2_CustomDrawEmptyForeground);
		this.gridColSubject.Caption = "Subject";
		this.gridColSubject.FieldName = "SubjectId";
		this.gridColSubject.Name = "gridColSubject";
		this.gridColSubject.Visible = true;
		this.gridColSubject.VisibleIndex = 0;
		this.gridColShortCode.Caption = "Short Code";
		this.gridColShortCode.FieldName = "ShortCode";
		this.gridColShortCode.Name = "gridColShortCode";
		this.gridColShortCode.Visible = true;
		this.gridColShortCode.VisibleIndex = 0;
		this.gridColShortCode.Width = 266;
		this.gridColPaper.Caption = "Paper";
		this.gridColPaper.FieldName = "Paper";
		this.gridColPaper.Name = "gridColPaper";
		this.gridColPaper.Visible = true;
		this.gridColPaper.VisibleIndex = 1;
		this.gridColPaper.Width = 486;
		this.gridControlOLevel.Location = new System.Drawing.Point(4, 26);
		this.gridControlOLevel.MainView = this.gridView1;
		this.gridControlOLevel.Name = "gridControlOLevel";
		this.gridControlOLevel.Size = new System.Drawing.Size(271, 464);
		this.gridControlOLevel.TabIndex = 4;
		this.gridControlOLevel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[2] { this.gridColCode, this.gridColName });
		this.gridView1.GridControl = this.gridControlOLevel;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
		this.gridView1.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(gridView1_CustomDrawEmptyForeground);
		this.gridColCode.Caption = "Short Code";
		this.gridColCode.FieldName = "ShortCode";
		this.gridColCode.Name = "gridColCode";
		this.gridColCode.Visible = true;
		this.gridColCode.VisibleIndex = 0;
		this.gridColCode.Width = 112;
		this.gridColName.Caption = "Subject";
		this.gridColName.FieldName = "SubjectName";
		this.gridColName.Name = "gridColName";
		this.gridColName.Visible = true;
		this.gridColName.VisibleIndex = 1;
		this.gridColName.Width = 640;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlItem1, this.layoutControlItem2 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(555, 494);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.gridControlOLevel;
		this.layoutControlItem1.CustomizationFormText = "O Level Subjects";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(275, 490);
		this.layoutControlItem1.Text = "O Level Subjects";
		this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(117, 19);
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.gridControlALevel;
		this.layoutControlItem2.CustomizationFormText = "A Level Subjects";
		this.layoutControlItem2.Location = new System.Drawing.Point(275, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(276, 490);
		this.layoutControlItem2.Text = "A Level Subjects";
		this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem2.TextSize = new System.Drawing.Size(117, 19);
		this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.timerOL.Tick += new System.EventHandler(timerOL_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrSubjectList";
		base.Size = new System.Drawing.Size(555, 494);
		base.Load += new System.EventHandler(usrSubjectList_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControlALevel).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControlOLevel).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		base.ResumeLayout(false);
	}
}
