using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using AlienAge.Semesters;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.DialogForms;

public class StudentSubjectFilter : XtraForm
{
	public string StudentNumber = string.Empty;

	private static string connectionString = DataConnection.ConnectToDatabase();

	private string semester = string.Empty;

	private string PrimaryLevel = string.Empty;

	private string _Class = string.Empty;

	private string schoolCurriculum = SchoolSettings.SchoolGeneralCurriculum.ToString();

	private IContainer components = null;

	private SimpleButton simpleButton1;

	private MyGridControl gridSubjectList;

	private MyGridView gridView1;

	public LookUpEdit lookUpClasses;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem11;

	private PanelControl panelControl1;

	private LayoutControlItem layoutControlItem1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	public StudentSubjectFilter(string _PrimaryLevel)
	{
		InitializeComponent();
		PrimaryLevel = _PrimaryLevel;
		semester = WorkingSemesters.GetWorkingSemester();
	}

	private void LoadOLevelSubjects(string StudentClass)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(connectionString);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT ISNULL(IsAssessed,0) IsAssessible,SubjectId AS Subject FROM tbl_GeneralReportCards_Primary WHERE ClassId='{StudentClass}' AND SemesterId='{semester}' GROUP BY IsAssessed,SubjectId ORDER BY SubjectId", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "PrimarySubjectsFilter");
			DataTable dataTable = dataSet.Tables[0];
			gridSubjectList.DataSource = dataTable.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton27_Click(object sender, EventArgs e)
	{
		SubjectDropingMode.DropFromMainForm(DropMode: true);
		using dropSubjects dropSubjects = new dropSubjects(string.Empty);
		dropSubjects.ShowDialog();
	}

	private void StudentSubjectRegistration_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			Close();
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void StudentSubjectRegistration_Load(object sender, EventArgs e)
	{
		if (schoolCurriculum == SchoolSettings.SchoolType.Primary.ToString())
		{
			if (PrimaryLevel == "Nursery")
			{
				Classes.LoadLookUpWithClasses(lookUpClasses, "Nursery");
			}
			else if (PrimaryLevel == "Primary")
			{
				Classes.LoadLookUpWithClasses(lookUpClasses, "Primary");
			}
		}
		else
		{
			Classes.LoadLookUpWithClasses(lookUpClasses);
		}
	}

	private void lookUpClasses_EditValueChanged(object sender, EventArgs e)
	{
		if (lookUpClasses.EditValue != null)
		{
			_Class = lookUpClasses.Properties.GetDataSourceValue("ClassId", lookUpClasses.ItemIndex).ToString();
			LoadOLevelSubjects(_Class);
		}
	}

	private void gridView1_CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e)
	{
		EmptyForeGroundCustomDraw.DrawEmptyForeGround(e, "No subjects registed or Select a class");
	}

	private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
	{
		if (e.Column.FieldName == "IsAssessible")
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "UPDATE tbl_GeneralReportCards_Primary SET IsAssessed=@IsAssessed WHERE SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
			sqlParameter.Value = gridView1.GetRowCellValue(e.RowHandle, "Subject");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
			sqlParameter.Value = _Class;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
			sqlParameter.Value = semester;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@IsAssessed", SqlDbType.Bit);
			sqlParameter.Value = Convert.ToBoolean(e.Value.ToString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
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
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.gridSubjectList = new AlienAge.CustomGrid.MyGridControl();
		this.gridView1 = new AlienAge.CustomGrid.MyGridView();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.lookUpClasses = new DevExpress.XtraEditors.LookUpEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridSubjectList).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpClasses.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.panelControl1);
		this.layoutControl1.Controls.Add(this.gridSubjectList);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.lookUpClasses);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(741, 644);
		this.layoutControl1.TabIndex = 13;
		this.layoutControl1.Text = "layoutControl1";
		this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl1.Location = new System.Drawing.Point(5, 607);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(562, 32);
		this.panelControl1.TabIndex = 13;
		this.gridSubjectList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.gridSubjectList.Location = new System.Drawing.Point(5, 41);
		this.gridSubjectList.MainView = this.gridView1;
		this.gridSubjectList.Margin = new System.Windows.Forms.Padding(2);
		this.gridSubjectList.Name = "gridSubjectList";
		this.gridSubjectList.Size = new System.Drawing.Size(731, 560);
		this.gridSubjectList.TabIndex = 0;
		this.gridSubjectList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.DetailTip.Options.UseFont = true;
		this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.Empty.Options.UseFont = true;
		this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.EvenRow.Options.UseFont = true;
		this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FixedLine.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedCell.BackColor2 = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.GroupButton.Options.UseFont = true;
		this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.HideSelectionRow.BackColor2 = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.HorzLine.Options.UseFont = true;
		this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.OddRow.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.SelectedRow.BackColor2 = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.VertLine.Options.UseFont = true;
		this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[2] { this.gridColumn1, this.gridColumn2 });
		this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
		this.gridView1.GridControl = this.gridSubjectList;
		this.gridView1.GroupFormat = "{1}{2}";
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView1.OptionsCustomization.AllowFilter = false;
		this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
		this.gridView1.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(gridView1_CustomDrawEmptyForeground);
		this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView1_CellValueChanged);
		this.simpleButton1.Location = new System.Drawing.Point(573, 607);
		this.simpleButton1.Margin = new System.Windows.Forms.Padding(2);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(163, 32);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 9;
		this.simpleButton1.Text = "Close";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.lookUpClasses.Location = new System.Drawing.Point(56, 5);
		this.lookUpClasses.Margin = new System.Windows.Forms.Padding(2);
		this.lookUpClasses.Name = "lookUpClasses";
		this.lookUpClasses.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.lookUpClasses.Properties.Appearance.Options.UseFont = true;
		this.lookUpClasses.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpClasses.Properties.NullText = "[Select Class]";
		this.lookUpClasses.Size = new System.Drawing.Size(680, 30);
		this.lookUpClasses.StyleController = this.layoutControl1;
		this.lookUpClasses.TabIndex = 12;
		this.lookUpClasses.EditValueChanged += new System.EventHandler(lookUpClasses_EditValueChanged);
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[4] { this.layoutControlItem2, this.layoutControlItem11, this.layoutControlItem4, this.layoutControlItem1 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(741, 644);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem2.Control = this.gridSubjectList;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 36);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(737, 566);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem11.Control = this.simpleButton1;
		this.layoutControlItem11.Location = new System.Drawing.Point(568, 602);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(169, 38);
		this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem11.TextVisible = false;
		this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem4.Control = this.lookUpClasses;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(737, 36);
		this.layoutControlItem4.Text = "Class";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(46, 24);
		this.layoutControlItem1.Control = this.panelControl1;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 602);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(568, 38);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.gridColumn1.Caption = "Is Assessible";
		this.gridColumn1.FieldName = "IsAssessible";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 145;
		this.gridColumn2.Caption = "Subject";
		this.gridColumn2.FieldName = "Subject";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.OptionsColumn.AllowEdit = false;
		this.gridColumn2.OptionsColumn.ReadOnly = true;
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn2.Width = 584;
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(741, 644);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Margin = new System.Windows.Forms.Padding(4);
		base.MaximizeBox = false;
		base.Name = "StudentSubjectFilter";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Subjects filter";
		base.Load += new System.EventHandler(StudentSubjectRegistration_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(StudentSubjectRegistration_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridSubjectList).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpClasses.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		base.ResumeLayout(false);
	}
}
