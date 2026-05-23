using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.DialogForms;

public class StudentSubjectRegistration_PrePrimary : XtraForm
{
	private static string connectionString = DataConnection.ConnectToDatabase();

	private string semester = string.Empty;

	public string studentClass = string.Empty;

	private string schoolCurriculum = SchoolSettings.SchoolGeneralCurriculum.ToString();

	private string classLevel = string.Empty;

	private string levelRanking = string.Empty;

	private string PrimaryLevel = string.Empty;

	private IContainer components = null;

	private PanelControl panelControl9;

	private LayoutControl layoutControl9;

	private SimpleButton simpleButton27;

	private SimpleButton btnRegisterStudents;

	private LayoutControlGroup layoutControlGroup13;

	private LayoutControlGroup groupSearch;

	private LayoutControlItem layoutControlItem95;

	private LayoutControlItem layoutControlItem111;

	private LayoutControlItem layoutControlItem176;

	private LayoutControlItem layoutControlItem178;

	private GroupControl groupControl17;

	private GroupControl groupControl16;

	public TextEdit txtStream;

	public TextEdit txtClass;

	public TextEdit txtName;

	public RadioGroup radioGroupMode;

	public PictureEdit pictureEdit14;

	private LayoutControlItem layoutControlItem1;

	public LabelControl lblStudentNo;

	private SimpleButton simpleButton1;

	private GridControl gridSubjectList;

	private GridView gridView1;

	private GridView searchLookUpEdit1View;

	private LayoutControlItem layoutSearch;

	public SearchLookUpEdit searchLookUpEdit1;

	private GridColumn gridPic;

	private GridColumn gridName;

	private GridColumn gridStudentNo;

	private GridColumn gridStream;

	private LabelControl labelControl2;

	public LookUpEdit lookUpClasses;

	private GridColumn gridColSubGroup;

	private GridColumn gridColSubjectID;

	private GridColumn gridColumn1;

	private GridColumn gridColumnSubGroup;

	private CheckBox checkBox1;

	public StudentSubjectRegistration_PrePrimary(string _PrimaryLevel)
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
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT id,SubGroup,SubGroup AS SubGroup2,SubjectId,SubjectName AS Subject from OLevelSubjects", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "OLevelSubjectsSubejcts");
			DataTable dataTable = dataSet.Tables[0];
			dataTable.Columns.Add(new DataColumn("Add", typeof(bool)));
			gridSubjectList.DataSource = dataTable.DefaultView;
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
				StudentRegistration.SetRegistrationParameters(gridView1, studentClass, lblStudentNo.Text, result, radioGroupMode.SelectedIndex, levelToRegister);
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
			lblStudentNo.Text = searchLookUpEdit1View.GetRowCellValue(searchLookUpEdit1View.GetFocusedDataSourceRowIndex(), "StudentNo").ToString();
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

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox1.Checked)
		{
			for (int i = 0; i < gridView1.RowCount; i++)
			{
				gridView1.SetRowCellValue(i, gridView1.Columns["Add"].FieldName, true);
			}
		}
		else if (!checkBox1.Checked)
		{
			for (int j = 0; j < gridView1.RowCount; j++)
			{
				gridView1.SetRowCellValue(j, gridView1.Columns["Add"].FieldName, false);
			}
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
		this.panelControl9 = new DevExpress.XtraEditors.PanelControl();
		this.layoutControl9 = new DevExpress.XtraLayout.LayoutControl();
		this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
		this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridPic = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridName = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridStudentNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridStream = new DevExpress.XtraGrid.Columns.GridColumn();
		this.lblStudentNo = new DevExpress.XtraEditors.LabelControl();
		this.pictureEdit14 = new DevExpress.XtraEditors.PictureEdit();
		this.txtStream = new DevExpress.XtraEditors.TextEdit();
		this.txtClass = new DevExpress.XtraEditors.TextEdit();
		this.txtName = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup13 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.groupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem95 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem111 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem176 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem178 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutSearch = new DevExpress.XtraLayout.LayoutControlItem();
		this.simpleButton27 = new DevExpress.XtraEditors.SimpleButton();
		this.btnRegisterStudents = new DevExpress.XtraEditors.SimpleButton();
		this.groupControl17 = new DevExpress.XtraEditors.GroupControl();
		this.gridSubjectList = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColSubGroup = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColSubjectID = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumnSubGroup = new DevExpress.XtraGrid.Columns.GridColumn();
		this.groupControl16 = new DevExpress.XtraEditors.GroupControl();
		this.radioGroupMode = new DevExpress.XtraEditors.RadioGroup();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.lookUpClasses = new DevExpress.XtraEditors.LookUpEdit();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		((System.ComponentModel.ISupportInitialize)this.panelControl9).BeginInit();
		this.panelControl9.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl9).BeginInit();
		this.layoutControl9.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.searchLookUpEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.searchLookUpEdit1View).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit14.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStream.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupSearch).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem95).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem111).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem176).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem178).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutSearch).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl17).BeginInit();
		this.groupControl17.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridSubjectList).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl16).BeginInit();
		this.groupControl16.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.radioGroupMode.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpClasses.Properties).BeginInit();
		base.SuspendLayout();
		this.panelControl9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl9.Controls.Add(this.layoutControl9);
		this.panelControl9.Location = new System.Drawing.Point(4, 110);
		this.panelControl9.Name = "panelControl9";
		this.panelControl9.Size = new System.Drawing.Size(181, 399);
		this.panelControl9.TabIndex = 7;
		this.layoutControl9.Controls.Add(this.searchLookUpEdit1);
		this.layoutControl9.Controls.Add(this.lblStudentNo);
		this.layoutControl9.Controls.Add(this.pictureEdit14);
		this.layoutControl9.Controls.Add(this.txtStream);
		this.layoutControl9.Controls.Add(this.txtClass);
		this.layoutControl9.Controls.Add(this.txtName);
		this.layoutControl9.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl9.Location = new System.Drawing.Point(0, 0);
		this.layoutControl9.Name = "layoutControl9";
		this.layoutControl9.Root = this.layoutControlGroup13;
		this.layoutControl9.Size = new System.Drawing.Size(181, 399);
		this.layoutControl9.TabIndex = 0;
		this.layoutControl9.Text = "layoutControl9";
		this.searchLookUpEdit1.EditValue = "";
		this.searchLookUpEdit1.Location = new System.Drawing.Point(7, 47);
		this.searchLookUpEdit1.Name = "searchLookUpEdit1";
		this.searchLookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.searchLookUpEdit1.Properties.Appearance.Options.UseFont = true;
		this.searchLookUpEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.searchLookUpEdit1.Properties.NullText = "";
		this.searchLookUpEdit1.Properties.ShowClearButton = false;
		this.searchLookUpEdit1.Properties.ShowFooter = false;
		this.searchLookUpEdit1.Properties.View = this.searchLookUpEdit1View;
		this.searchLookUpEdit1.Size = new System.Drawing.Size(167, 26);
		this.searchLookUpEdit1.StyleController = this.layoutControl9;
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
		this.lblStudentNo.Location = new System.Drawing.Point(7, 379);
		this.lblStudentNo.Name = "lblStudentNo";
		this.lblStudentNo.Size = new System.Drawing.Size(167, 13);
		this.lblStudentNo.StyleController = this.layoutControl9;
		this.lblStudentNo.TabIndex = 25;
		this.pictureEdit14.Location = new System.Drawing.Point(7, 77);
		this.pictureEdit14.Name = "pictureEdit14";
		this.pictureEdit14.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.pictureEdit14.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit14.Size = new System.Drawing.Size(167, 168);
		this.pictureEdit14.StyleController = this.layoutControl9;
		this.pictureEdit14.TabIndex = 6;
		this.txtStream.Location = new System.Drawing.Point(7, 349);
		this.txtStream.Name = "txtStream";
		this.txtStream.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtStream.Properties.Appearance.Options.UseFont = true;
		this.txtStream.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtStream.Properties.ReadOnly = true;
		this.txtStream.Size = new System.Drawing.Size(167, 26);
		this.txtStream.StyleController = this.layoutControl9;
		this.txtStream.TabIndex = 5;
		this.txtClass.Location = new System.Drawing.Point(7, 298);
		this.txtClass.Name = "txtClass";
		this.txtClass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtClass.Properties.Appearance.Options.UseFont = true;
		this.txtClass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtClass.Properties.ReadOnly = true;
		this.txtClass.Size = new System.Drawing.Size(167, 26);
		this.txtClass.StyleController = this.layoutControl9;
		this.txtClass.TabIndex = 4;
		this.txtName.Location = new System.Drawing.Point(7, 249);
		this.txtName.Name = "txtName";
		this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtName.Properties.Appearance.Options.UseFont = true;
		this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtName.Properties.ReadOnly = true;
		this.txtName.Size = new System.Drawing.Size(167, 24);
		this.txtName.StyleController = this.layoutControl9;
		this.txtName.TabIndex = 3;
		this.layoutControlGroup13.CustomizationFormText = "layoutControlGroup13";
		this.layoutControlGroup13.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup13.GroupBordersVisible = false;
		this.layoutControlGroup13.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.groupSearch });
		this.layoutControlGroup13.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup13.Name = "layoutControlGroup13";
		this.layoutControlGroup13.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup13.Size = new System.Drawing.Size(181, 399);
		this.layoutControlGroup13.Text = "layoutControlGroup13";
		this.layoutControlGroup13.TextVisible = false;
		this.groupSearch.CustomizationFormText = "Student details";
		this.groupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[6] { this.layoutControlItem95, this.layoutControlItem111, this.layoutControlItem176, this.layoutControlItem178, this.layoutControlItem1, this.layoutSearch });
		this.groupSearch.Location = new System.Drawing.Point(0, 0);
		this.groupSearch.Name = "groupSearch";
		this.groupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.groupSearch.Size = new System.Drawing.Size(177, 395);
		this.groupSearch.Text = "Student details";
		this.layoutControlItem95.Control = this.txtName;
		this.layoutControlItem95.CustomizationFormText = "Name";
		this.layoutControlItem95.Location = new System.Drawing.Point(0, 223);
		this.layoutControlItem95.Name = "layoutControlItem95";
		this.layoutControlItem95.Size = new System.Drawing.Size(171, 28);
		this.layoutControlItem95.Text = "Name";
		this.layoutControlItem95.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem95.TextToControlDistance = 0;
		this.layoutControlItem95.TextVisible = false;
		this.layoutControlItem111.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem111.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem111.Control = this.txtClass;
		this.layoutControlItem111.CustomizationFormText = "Class";
		this.layoutControlItem111.Location = new System.Drawing.Point(0, 251);
		this.layoutControlItem111.Name = "layoutControlItem111";
		this.layoutControlItem111.Size = new System.Drawing.Size(171, 51);
		this.layoutControlItem111.Text = "Class";
		this.layoutControlItem111.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem111.TextSize = new System.Drawing.Size(81, 18);
		this.layoutControlItem176.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem176.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem176.Control = this.txtStream;
		this.layoutControlItem176.CustomizationFormText = "Stream";
		this.layoutControlItem176.Location = new System.Drawing.Point(0, 302);
		this.layoutControlItem176.Name = "layoutControlItem176";
		this.layoutControlItem176.Size = new System.Drawing.Size(171, 51);
		this.layoutControlItem176.Text = "Stream";
		this.layoutControlItem176.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem176.TextSize = new System.Drawing.Size(81, 18);
		this.layoutControlItem178.Control = this.pictureEdit14;
		this.layoutControlItem178.CustomizationFormText = "layoutControlItem178";
		this.layoutControlItem178.Location = new System.Drawing.Point(0, 51);
		this.layoutControlItem178.Name = "layoutControlItem178";
		this.layoutControlItem178.Size = new System.Drawing.Size(171, 172);
		this.layoutControlItem178.Text = "layoutControlItem178";
		this.layoutControlItem178.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem178.TextToControlDistance = 0;
		this.layoutControlItem178.TextVisible = false;
		this.layoutControlItem1.Control = this.lblStudentNo;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 353);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(171, 17);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutSearch.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutSearch.AppearanceItemCaption.Options.UseFont = true;
		this.layoutSearch.Control = this.searchLookUpEdit1;
		this.layoutSearch.CustomizationFormText = "Find Student";
		this.layoutSearch.Location = new System.Drawing.Point(0, 0);
		this.layoutSearch.Name = "layoutSearch";
		this.layoutSearch.Size = new System.Drawing.Size(171, 51);
		this.layoutSearch.Text = "Find Student";
		this.layoutSearch.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutSearch.TextSize = new System.Drawing.Size(81, 18);
		this.simpleButton27.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.simpleButton27.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton27.Appearance.Options.UseFont = true;
		this.simpleButton27.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton27.Location = new System.Drawing.Point(237, 596);
		this.simpleButton27.Name = "simpleButton27";
		this.simpleButton27.Size = new System.Drawing.Size(143, 25);
		this.simpleButton27.TabIndex = 5;
		this.simpleButton27.Text = "Drop subjects";
		this.simpleButton27.Click += new System.EventHandler(simpleButton27_Click);
		this.btnRegisterStudents.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnRegisterStudents.Appearance.Options.UseFont = true;
		this.btnRegisterStudents.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.btnRegisterStudents.Location = new System.Drawing.Point(4, 596);
		this.btnRegisterStudents.Name = "btnRegisterStudents";
		this.btnRegisterStudents.Size = new System.Drawing.Size(143, 25);
		this.btnRegisterStudents.TabIndex = 8;
		this.btnRegisterStudents.Text = "Register students";
		this.btnRegisterStudents.Click += new System.EventHandler(btnRegisterStudents_Click);
		this.groupControl17.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.groupControl17.Controls.Add(this.gridSubjectList);
		this.groupControl17.Location = new System.Drawing.Point(191, 27);
		this.groupControl17.Name = "groupControl17";
		this.groupControl17.Size = new System.Drawing.Size(581, 547);
		this.groupControl17.TabIndex = 6;
		this.groupControl17.Text = "Subject list";
		this.gridSubjectList.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridSubjectList.Location = new System.Drawing.Point(2, 21);
		this.gridSubjectList.MainView = this.gridView1;
		this.gridSubjectList.Name = "gridSubjectList";
		this.gridSubjectList.Size = new System.Drawing.Size(577, 524);
		this.gridSubjectList.TabIndex = 0;
		this.gridSubjectList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[4] { this.gridColSubGroup, this.gridColumn1, this.gridColSubjectID, this.gridColumnSubGroup });
		this.gridView1.GridControl = this.gridSubjectList;
		this.gridView1.GroupFormat = "{1}{2}";
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView1.OptionsCustomization.AllowFilter = false;
		this.gridView1.OptionsView.AllowCellMerge = true;
		this.gridView1.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridColSubGroup.Caption = "Assessable Area";
		this.gridColSubGroup.FieldName = "SubGroup2";
		this.gridColSubGroup.Name = "gridColSubGroup";
		this.gridColSubGroup.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
		this.gridColSubGroup.Visible = true;
		this.gridColSubGroup.VisibleIndex = 0;
		this.gridColSubGroup.Width = 511;
		this.gridColumn1.Caption = "Add";
		this.gridColumn1.FieldName = "Add";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 1;
		this.gridColumn1.Width = 96;
		this.gridColSubjectID.Caption = "Subject";
		this.gridColSubjectID.FieldName = "Subject";
		this.gridColSubjectID.Name = "gridColSubjectID";
		this.gridColSubjectID.Visible = true;
		this.gridColSubjectID.VisibleIndex = 2;
		this.gridColSubjectID.Width = 487;
		this.gridColumnSubGroup.Caption = "SubGroup";
		this.gridColumnSubGroup.FieldName = "SubGroup";
		this.gridColumnSubGroup.Name = "gridColumnSubGroup";
		this.groupControl16.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.groupControl16.Controls.Add(this.radioGroupMode);
		this.groupControl16.Location = new System.Drawing.Point(4, 6);
		this.groupControl16.Name = "groupControl16";
		this.groupControl16.Size = new System.Drawing.Size(181, 72);
		this.groupControl16.TabIndex = 5;
		this.groupControl16.Text = "Registration mode";
		this.radioGroupMode.Dock = System.Windows.Forms.DockStyle.Fill;
		this.radioGroupMode.Location = new System.Drawing.Point(2, 21);
		this.radioGroupMode.Name = "radioGroupMode";
		this.radioGroupMode.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroupMode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.radioGroupMode.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroupMode.Properties.Appearance.Options.UseFont = true;
		this.radioGroupMode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.radioGroupMode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Entire class"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Single student")
		});
		this.radioGroupMode.Size = new System.Drawing.Size(177, 49);
		this.radioGroupMode.TabIndex = 0;
		this.radioGroupMode.SelectedIndexChanged += new System.EventHandler(radioGroupMode_SelectedIndexChanged);
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(629, 596);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(143, 25);
		this.simpleButton1.TabIndex = 9;
		this.simpleButton1.Text = "Close";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl2.Visible = true;
		this.labelControl2.Location = new System.Drawing.Point(7, 580);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(763, 10);
		this.labelControl2.TabIndex = 11;
		this.lookUpClasses.Location = new System.Drawing.Point(6, 85);
		this.lookUpClasses.Name = "lookUpClasses";
		this.lookUpClasses.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lookUpClasses.Properties.Appearance.Options.UseFont = true;
		this.lookUpClasses.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpClasses.Properties.NullText = "[Select Class]";
		this.lookUpClasses.Size = new System.Drawing.Size(177, 24);
		this.lookUpClasses.TabIndex = 12;
		this.lookUpClasses.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(lookUpClasses_Closed);
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(193, 6);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(69, 17);
		this.checkBox1.TabIndex = 1;
		this.checkBox1.Text = "Select All";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(784, 626);
		base.Controls.Add(this.checkBox1);
		base.Controls.Add(this.lookUpClasses);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.panelControl9);
		base.Controls.Add(this.groupControl17);
		base.Controls.Add(this.groupControl16);
		base.Controls.Add(this.simpleButton27);
		base.Controls.Add(this.btnRegisterStudents);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "StudentSubjectRegistration_PrePrimary";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Student Registration";
		base.Load += new System.EventHandler(StudentSubjectRegistration_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(StudentSubjectRegistration_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.panelControl9).EndInit();
		this.panelControl9.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControl9).EndInit();
		this.layoutControl9.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.searchLookUpEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.searchLookUpEdit1View).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit14.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStream.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupSearch).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem95).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem111).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem176).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem178).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutSearch).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl17).EndInit();
		this.groupControl17.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridSubjectList).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl16).EndInit();
		this.groupControl16.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.radioGroupMode.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpClasses.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
