using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

public class StudentSubjectRegistration : XtraForm
{
	public string StudentNumber = string.Empty;

	private static string connectionString = DataConnection.ConnectToDatabase();

	private string semester = string.Empty;

	public string studentClass = string.Empty;

	private string schoolCurriculum = SchoolSettings.SchoolGeneralCurriculum.ToString();

	private string classLevel = string.Empty;

	private string levelRanking = string.Empty;

	private string PrimaryLevel = string.Empty;

	private IContainer components = null;

	private SimpleButton simpleButton27;

	private SimpleButton btnRegisterStudents;

	private GroupControl groupControl16;

	public TextEdit txtStream;

	public TextEdit txtClass;

	public TextEdit txtName;

	public RadioGroup radioGroupMode;

	public PictureEdit pictureEdit14;

	private SimpleButton simpleButton1;

	private MyGridControl gridSubjectList;

	private MyGridView gridView1;

	private GridView searchLookUpEdit1View;

	public SearchLookUpEdit searchLookUpEdit1;

	private GridColumn gridPic;

	private GridColumn gridName;

	private GridColumn gridStudentNo;

	private GridColumn gridStream;

	public LookUpEdit lookUpClasses;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem9;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem10;

	private LayoutControlItem layoutControlItem11;

	private LayoutControlGroup groupSearch;

	private EmptySpaceItem emptySpaceItem1;

	public StudentSubjectRegistration(string _PrimaryLevel)
	{
		InitializeComponent();
		PrimaryLevel = _PrimaryLevel;
		groupSearch.Visibility = LayoutVisibility.Never;
		semester = WorkingSemesters.GetWorkingSemester();
	}

	private void LoadOLevelSubjects()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(connectionString);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT id,SubjectId,SubjectName AS Subject from OLevelSubjects", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "OLevelSubjectsSubejcts");
			DataTable dataTable = dataSet.Tables[0];
			dataTable.Columns.Add(new DataColumn("Add", typeof(bool)));
			gridView1.Columns.Clear();
			gridSubjectList.DataSource = dataTable.DefaultView;
			gridView1.Columns["SubjectId"].Visible = false;
			gridView1.Columns["id"].Visible = false;
			gridView1.Columns["Subject"].OptionsColumn.ReadOnly = true;
			gridView1.Columns["Add"].VisibleIndex = 0;
			gridView1.Columns["Add"].Width = 30;
			for (int i = 0; i < gridView1.RowCount; i++)
			{
				gridView1.SetRowCellValue(i, gridView1.Columns["Add"].FieldName, false);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static void LoadStudentsLookUp(SearchLookUpEdit lookUpEdit, string _class)
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT fullName AS Name, StudentNumber AS StudentNo,StreamId AS Stream,Picture,RequiredFees FROM tbl_Stud WHERE ClassId='{_class}'", connectionString);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentList");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			lookUpEdit.Properties.DataSource = dataTable;
			lookUpEdit.Properties.DisplayMember = "Name";
			lookUpEdit.Properties.ValueMember = "StudentNo";
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void btnRegisterStudents_Click(object sender, EventArgs e)
	{
		if (semester != "Semester No Set!")
		{
			string s = semester.Substring(semester.IndexOf('-') + 1, 4);
			int result = (int.TryParse(s, out result) ? result : 1984);
			int levelToRegister = 0;
			if (lookUpClasses.Enabled)
			{
				if (schoolCurriculum == SchoolSettings.SchoolType.Primary.ToString())
				{
					levelToRegister = 0;
				}
				else if (schoolCurriculum == SchoolSettings.SchoolType.Secondary.ToString())
				{
					if (classLevel == SchoolSettings.SecondaryClassLevels.OLevel.ToString())
					{
						levelToRegister = 0;
					}
					else if (classLevel == SchoolSettings.SecondaryClassLevels.ALevel.ToString())
					{
						levelToRegister = 1;
						gridView1.Columns["SubjectId"].GroupIndex = -1;
					}
				}
				gridView1.ActiveFilterString = $"[Add] = '{true}'";
				StudentRegistration.SetRegistrationParameters(gridView1, studentClass, StudentNumber, result, radioGroupMode.SelectedIndex, levelToRegister);
				using RegisterStudents registerStudents = new RegisterStudents(classLevel);
				if (registerStudents.ShowDialog() == DialogResult.OK)
				{
					gridView1.ClearColumnsFilter();
					if (classLevel == SchoolSettings.SecondaryClassLevels.ALevel.ToString())
					{
						gridView1.Columns["SubjectId"].GroupIndex = 0;
					}
					for (int i = 0; i < gridView1.RowCount; i++)
					{
						gridView1.SetRowCellValue(i, "Add", 0);
					}
				}
				return;
			}
			XtraMessageBox.Show("Please select a class you wish to register.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		else
		{
			XtraMessageBox.Show("Please set a Term first!", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void simpleButton27_Click(object sender, EventArgs e)
	{
		SubjectDropingMode.DropFromMainForm(DropMode: true);
		using dropSubjects dropSubjects = new dropSubjects(string.Empty);
		dropSubjects.ShowDialog();
	}

	private void radioGroupMode_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (radioGroupMode.SelectedIndex == 1)
			{
				groupSearch.Visibility = LayoutVisibility.Always;
				LoadStudentsLookUp(searchLookUpEdit1, studentClass);
			}
			else if (radioGroupMode.SelectedIndex == 0)
			{
				groupSearch.Visibility = LayoutVisibility.Never;
				lookUpClasses.Enabled = true;
				txtClass.Text = string.Empty;
				txtName.Text = string.Empty;
				txtStream.Text = string.Empty;
				pictureEdit14.Image = null;
				searchLookUpEdit1.Properties.DataSource = null;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
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

	private void searchLookUpEdit1_Closed(object sender, ClosedEventArgs e)
	{
		if (searchLookUpEdit1View.GetFocusedDataSourceRowIndex() > -1)
		{
			txtName.Text = searchLookUpEdit1View.GetRowCellValue(searchLookUpEdit1View.GetFocusedDataSourceRowIndex(), "Name").ToString();
			txtStream.Text = searchLookUpEdit1View.GetRowCellValue(searchLookUpEdit1View.GetFocusedDataSourceRowIndex(), "Stream").ToString();
			StudentNumber = searchLookUpEdit1View.GetRowCellValue(searchLookUpEdit1View.GetFocusedDataSourceRowIndex(), "StudentNo").ToString();
			txtClass.Text = studentClass;
			byte[] array = new byte[0];
			array = (byte[])searchLookUpEdit1View.GetRowCellValue(searchLookUpEdit1View.GetFocusedDataSourceRowIndex(), "Picture");
			using MemoryStream stream = new MemoryStream(array);
			pictureEdit14.Image = Image.FromStream(stream);
		}
	}

	private void searchLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
	{
		searchLookUpEdit1.Properties.PopupFormSize = new Size(base.Width, base.Height);
		txtClass.Text = string.Empty;
		txtName.Text = string.Empty;
		txtStream.Text = string.Empty;
	}

	private void lookUpClasses_Closed(object sender, ClosedEventArgs e)
	{
		if (lookUpClasses.EditValue == null)
		{
			return;
		}
		studentClass = lookUpClasses.Properties.GetDataSourceValue("ClassId", lookUpClasses.ItemIndex).ToString();
		classLevel = lookUpClasses.Properties.GetDataSourceValue("ClassGroup", lookUpClasses.ItemIndex).ToString();
		levelRanking = lookUpClasses.Properties.GetDataSourceValue("SubGroup", lookUpClasses.ItemIndex).ToString();
		LoadStudentsLookUp(searchLookUpEdit1, studentClass);
		if (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Primary.ToString() || (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Secondary.ToString() && classLevel == SchoolSettings.SecondaryClassLevels.OLevel.ToString()))
		{
			LoadOLevelSubjects();
			return;
		}
		if (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Secondary.ToString() && classLevel == SchoolSettings.SecondaryClassLevels.ALevel.ToString())
		{
			using (SqlConnection selectConnection = new SqlConnection(connectionString))
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT SubjectId,PaperId,Paper FROM ALevelSubjects_Categorised", selectConnection);
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "ALevelSubejcts");
				DataTable dataTable = dataSet.Tables[0];
				dataTable.Columns.Add(new DataColumn("Add", typeof(bool)));
				gridView1.Columns.Clear();
				gridSubjectList.DataSource = dataTable.DefaultView;
				gridView1.Columns["PaperId"].Visible = false;
				gridView1.Columns["Paper"].OptionsColumn.ReadOnly = true;
				gridView1.Columns["SubjectId"].GroupIndex = 0;
				gridView1.Columns["Add"].VisibleIndex = 0;
				gridView1.Columns["Add"].Width = 30;
				for (int i = 0; i < gridView1.RowCount; i++)
				{
					gridView1.SetRowCellValue(i, gridView1.Columns["Add"].FieldName, 0);
				}
				return;
			}
		}
		gridSubjectList.DataSource = null;
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
		this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
		this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridPic = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridName = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridStudentNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridStream = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.gridSubjectList = new AlienAge.CustomGrid.MyGridControl();
		this.gridView1 = new AlienAge.CustomGrid.MyGridView();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.lookUpClasses = new DevExpress.XtraEditors.LookUpEdit();
		this.simpleButton27 = new DevExpress.XtraEditors.SimpleButton();
		this.btnRegisterStudents = new DevExpress.XtraEditors.SimpleButton();
		this.txtStream = new DevExpress.XtraEditors.TextEdit();
		this.pictureEdit14 = new DevExpress.XtraEditors.PictureEdit();
		this.txtClass = new DevExpress.XtraEditors.TextEdit();
		this.txtName = new DevExpress.XtraEditors.TextEdit();
		this.groupControl16 = new DevExpress.XtraEditors.GroupControl();
		this.radioGroupMode = new DevExpress.XtraEditors.RadioGroup();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.groupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.searchLookUpEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.searchLookUpEdit1View).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridSubjectList).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpClasses.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStream.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit14.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl16).BeginInit();
		this.groupControl16.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.radioGroupMode.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupSearch).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		base.SuspendLayout();
		this.searchLookUpEdit1.EditValue = "";
		this.searchLookUpEdit1.Location = new System.Drawing.Point(71, 188);
		this.searchLookUpEdit1.Margin = new System.Windows.Forms.Padding(2);
		this.searchLookUpEdit1.Name = "searchLookUpEdit1";
		this.searchLookUpEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.searchLookUpEdit1.Properties.NullText = "";
		this.searchLookUpEdit1.Properties.PopupView = this.searchLookUpEdit1View;
		this.searchLookUpEdit1.Properties.ShowClearButton = false;
		this.searchLookUpEdit1.Properties.ShowFooter = false;
		this.searchLookUpEdit1.Size = new System.Drawing.Size(193, 28);
		this.searchLookUpEdit1.StyleController = this.layoutControl1;
		this.searchLookUpEdit1.TabIndex = 27;
		this.searchLookUpEdit1.QueryPopUp += new System.ComponentModel.CancelEventHandler(searchLookUpEdit1_QueryPopUp);
		this.searchLookUpEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(searchLookUpEdit1_Closed);
		this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[4] { this.gridPic, this.gridName, this.gridStudentNo, this.gridStream });
		this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
		this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
		this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
		this.searchLookUpEdit1View.OptionsView.ShowIndicator = false;
		this.gridPic.Caption = "Image";
		this.gridPic.FieldName = "Picture";
		this.gridPic.Name = "gridPic";
		this.gridPic.Visible = true;
		this.gridPic.VisibleIndex = 0;
		this.gridPic.Width = 61;
		this.gridName.Caption = "Name";
		this.gridName.FieldName = "Name";
		this.gridName.Name = "gridName";
		this.gridName.Visible = true;
		this.gridName.VisibleIndex = 1;
		this.gridName.Width = 343;
		this.gridStudentNo.Caption = "Student#";
		this.gridStudentNo.FieldName = "StudentNo";
		this.gridStudentNo.Name = "gridStudentNo";
		this.gridStudentNo.Visible = true;
		this.gridStudentNo.VisibleIndex = 2;
		this.gridStudentNo.Width = 477;
		this.gridStream.Caption = "Stream";
		this.gridStream.FieldName = "Stream";
		this.gridStream.Name = "gridStream";
		this.gridStream.Visible = true;
		this.gridStream.VisibleIndex = 3;
		this.gridStream.Width = 213;
		this.layoutControl1.Controls.Add(this.gridSubjectList);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.lookUpClasses);
		this.layoutControl1.Controls.Add(this.simpleButton27);
		this.layoutControl1.Controls.Add(this.btnRegisterStudents);
		this.layoutControl1.Controls.Add(this.searchLookUpEdit1);
		this.layoutControl1.Controls.Add(this.txtStream);
		this.layoutControl1.Controls.Add(this.pictureEdit14);
		this.layoutControl1.Controls.Add(this.txtClass);
		this.layoutControl1.Controls.Add(this.txtName);
		this.layoutControl1.Controls.Add(this.groupControl16);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(868, 644);
		this.layoutControl1.TabIndex = 13;
		this.layoutControl1.Text = "layoutControl1";
		this.gridSubjectList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.gridSubjectList.Location = new System.Drawing.Point(277, 5);
		this.gridSubjectList.MainView = this.gridView1;
		this.gridSubjectList.Margin = new System.Windows.Forms.Padding(2);
		this.gridSubjectList.Name = "gridSubjectList";
		this.gridSubjectList.Size = new System.Drawing.Size(586, 596);
		this.gridSubjectList.TabIndex = 0;
		this.gridSubjectList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.GridControl = this.gridSubjectList;
		this.gridView1.GroupFormat = "{1}{2}";
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView1.OptionsCustomization.AllowFilter = false;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
		this.simpleButton1.Location = new System.Drawing.Point(578, 607);
		this.simpleButton1.Margin = new System.Windows.Forms.Padding(2);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(285, 32);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 9;
		this.simpleButton1.Text = "Close";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.lookUpClasses.Location = new System.Drawing.Point(64, 110);
		this.lookUpClasses.Margin = new System.Windows.Forms.Padding(2);
		this.lookUpClasses.Name = "lookUpClasses";
		this.lookUpClasses.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpClasses.Properties.NullText = "[Select Class]";
		this.lookUpClasses.Size = new System.Drawing.Size(207, 26);
		this.lookUpClasses.StyleController = this.layoutControl1;
		this.lookUpClasses.TabIndex = 12;
		this.lookUpClasses.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(lookUpClasses_Closed);
		this.simpleButton27.Location = new System.Drawing.Point(291, 607);
		this.simpleButton27.Margin = new System.Windows.Forms.Padding(2);
		this.simpleButton27.Name = "simpleButton27";
		this.simpleButton27.Size = new System.Drawing.Size(281, 32);
		this.simpleButton27.StyleController = this.layoutControl1;
		this.simpleButton27.TabIndex = 5;
		this.simpleButton27.Text = "Drop subjects";
		this.simpleButton27.Click += new System.EventHandler(simpleButton27_Click);
		this.btnRegisterStudents.Location = new System.Drawing.Point(5, 607);
		this.btnRegisterStudents.Margin = new System.Windows.Forms.Padding(2);
		this.btnRegisterStudents.Name = "btnRegisterStudents";
		this.btnRegisterStudents.Size = new System.Drawing.Size(280, 32);
		this.btnRegisterStudents.StyleController = this.layoutControl1;
		this.btnRegisterStudents.TabIndex = 8;
		this.btnRegisterStudents.Text = "Register students";
		this.btnRegisterStudents.Click += new System.EventHandler(btnRegisterStudents_Click);
		this.txtStream.Location = new System.Drawing.Point(71, 566);
		this.txtStream.Margin = new System.Windows.Forms.Padding(2);
		this.txtStream.Name = "txtStream";
		this.txtStream.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtStream.Properties.Appearance.Options.UseFont = true;
		this.txtStream.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtStream.Properties.ReadOnly = true;
		this.txtStream.Size = new System.Drawing.Size(193, 28);
		this.txtStream.StyleController = this.layoutControl1;
		this.txtStream.TabIndex = 5;
		this.pictureEdit14.Location = new System.Drawing.Point(12, 222);
		this.pictureEdit14.Margin = new System.Windows.Forms.Padding(2);
		this.pictureEdit14.Name = "pictureEdit14";
		this.pictureEdit14.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.pictureEdit14.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit14.Size = new System.Drawing.Size(252, 270);
		this.pictureEdit14.StyleController = this.layoutControl1;
		this.pictureEdit14.TabIndex = 6;
		this.txtClass.Location = new System.Drawing.Point(71, 532);
		this.txtClass.Margin = new System.Windows.Forms.Padding(2);
		this.txtClass.Name = "txtClass";
		this.txtClass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtClass.Properties.Appearance.Options.UseFont = true;
		this.txtClass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtClass.Properties.ReadOnly = true;
		this.txtClass.Size = new System.Drawing.Size(193, 28);
		this.txtClass.StyleController = this.layoutControl1;
		this.txtClass.TabIndex = 4;
		this.txtName.Location = new System.Drawing.Point(71, 498);
		this.txtName.Margin = new System.Windows.Forms.Padding(2);
		this.txtName.Name = "txtName";
		this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtName.Properties.Appearance.Options.UseFont = true;
		this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtName.Properties.ReadOnly = true;
		this.txtName.Size = new System.Drawing.Size(193, 28);
		this.txtName.StyleController = this.layoutControl1;
		this.txtName.TabIndex = 3;
		this.groupControl16.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.groupControl16.Controls.Add(this.radioGroupMode);
		this.groupControl16.Location = new System.Drawing.Point(5, 5);
		this.groupControl16.Margin = new System.Windows.Forms.Padding(2);
		this.groupControl16.Name = "groupControl16";
		this.groupControl16.Size = new System.Drawing.Size(266, 99);
		this.groupControl16.TabIndex = 5;
		this.groupControl16.Text = "Registration mode";
		this.radioGroupMode.Dock = System.Windows.Forms.DockStyle.Fill;
		this.radioGroupMode.Location = new System.Drawing.Point(3, 30);
		this.radioGroupMode.Margin = new System.Windows.Forms.Padding(2);
		this.radioGroupMode.Name = "radioGroupMode";
		this.radioGroupMode.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroupMode.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroupMode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.radioGroupMode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Entire class"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Single student")
		});
		this.radioGroupMode.Size = new System.Drawing.Size(260, 66);
		this.radioGroupMode.TabIndex = 0;
		this.radioGroupMode.SelectedIndexChanged += new System.EventHandler(radioGroupMode_SelectedIndexChanged);
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[8] { this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem1, this.layoutControlItem10, this.layoutControlItem11, this.groupSearch, this.emptySpaceItem1, this.layoutControlItem4 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(868, 644);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem2.Control = this.gridSubjectList;
		this.layoutControlItem2.Location = new System.Drawing.Point(272, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(592, 602);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.groupControl16;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(272, 105);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem1.Control = this.btnRegisterStudents;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 602);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(286, 38);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem10.Control = this.simpleButton27;
		this.layoutControlItem10.Location = new System.Drawing.Point(286, 602);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(287, 38);
		this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem10.TextVisible = false;
		this.layoutControlItem11.Control = this.simpleButton1;
		this.layoutControlItem11.Location = new System.Drawing.Point(573, 602);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(291, 38);
		this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem11.TextVisible = false;
		this.groupSearch.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
		this.groupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[5] { this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7, this.layoutControlItem8, this.layoutControlItem9 });
		this.groupSearch.Location = new System.Drawing.Point(0, 149);
		this.groupSearch.Name = "groupSearch";
		this.groupSearch.OptionsItemText.TextToControlDistance = 5;
		this.groupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.groupSearch.Size = new System.Drawing.Size(272, 453);
		this.groupSearch.Text = "Find Student";
		this.layoutControlItem5.Control = this.searchLookUpEdit1;
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(258, 34);
		this.layoutControlItem5.Text = "Student";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(54, 19);
		this.layoutControlItem6.Control = this.pictureEdit14;
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 34);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(258, 276);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem7.Control = this.txtName;
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 310);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(258, 34);
		this.layoutControlItem7.Text = "Name";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(54, 19);
		this.layoutControlItem8.Control = this.txtClass;
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 344);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(258, 34);
		this.layoutControlItem8.Text = "Class";
		this.layoutControlItem8.TextSize = new System.Drawing.Size(54, 19);
		this.layoutControlItem9.Control = this.txtStream;
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 378);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(258, 34);
		this.layoutControlItem9.Text = "Stream";
		this.layoutControlItem9.TextSize = new System.Drawing.Size(54, 19);
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 137);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(272, 12);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.Control = this.lookUpClasses;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 105);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(272, 32);
		this.layoutControlItem4.Text = "Class";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(54, 19);
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(868, 644);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Margin = new System.Windows.Forms.Padding(4);
		base.MaximizeBox = false;
		base.Name = "StudentSubjectRegistration";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Student Registration";
		base.Load += new System.EventHandler(StudentSubjectRegistration_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(StudentSubjectRegistration_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.searchLookUpEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.searchLookUpEdit1View).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridSubjectList).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpClasses.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStream.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit14.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl16).EndInit();
		this.groupControl16.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.radioGroupMode.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupSearch).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		base.ResumeLayout(false);
	}
}
