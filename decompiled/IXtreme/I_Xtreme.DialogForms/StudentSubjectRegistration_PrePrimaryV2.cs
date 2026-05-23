using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.DialogForms;

public class StudentSubjectRegistration_PrePrimaryV2 : XtraForm
{
	private static string connectionString = DataConnection.ConnectToDatabase();

	private string semester = string.Empty;

	public string studentClass = string.Empty;

	private string schoolCurriculum = SchoolSettings.SchoolGeneralCurriculum.ToString();

	private string classLevel = string.Empty;

	private string levelRanking = string.Empty;

	private string PrimaryLevel = string.Empty;

	private IContainer components = null;

	private SimpleButton btnRegisterStudents;

	private SimpleButton simpleButton1;

	private LabelControl labelControl2;

	public LookUpEdit lookUpClasses;

	private SimpleButton simpleButton2;

	public StudentSubjectRegistration_PrePrimaryV2(string _PrimaryLevel)
	{
		InitializeComponent();
		PrimaryLevel = _PrimaryLevel;
		semester = WorkingSemesters.GetWorkingSemester();
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
			if (lookUpClasses.Enabled)
			{
				using (RegisterStudentsPre registerStudentsPre = new RegisterStudentsPre(studentClass))
				{
					if (registerStudentsPre.ShowDialog() != DialogResult.OK)
					{
					}
					return;
				}
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

	private void lookUpClasses_Closed(object sender, ClosedEventArgs e)
	{
		if (lookUpClasses.EditValue != null)
		{
			studentClass = lookUpClasses.Properties.GetDataSourceValue("ClassId", lookUpClasses.ItemIndex).ToString();
			classLevel = lookUpClasses.Properties.GetDataSourceValue("ClassGroup", lookUpClasses.ItemIndex).ToString();
			levelRanking = lookUpClasses.Properties.GetDataSourceValue("SubGroup", lookUpClasses.ItemIndex).ToString();
		}
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
		this.btnRegisterStudents = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.lookUpClasses = new DevExpress.XtraEditors.LookUpEdit();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		((System.ComponentModel.ISupportInitialize)this.lookUpClasses.Properties).BeginInit();
		base.SuspendLayout();
		this.btnRegisterStudents.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnRegisterStudents.Appearance.Options.UseFont = true;
		this.btnRegisterStudents.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.btnRegisterStudents.Location = new System.Drawing.Point(12, 75);
		this.btnRegisterStudents.Name = "btnRegisterStudents";
		this.btnRegisterStudents.Size = new System.Drawing.Size(143, 25);
		this.btnRegisterStudents.TabIndex = 8;
		this.btnRegisterStudents.Text = "Register students";
		this.btnRegisterStudents.Click += new System.EventHandler(btnRegisterStudents_Click);
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
		this.labelControl2.Location = new System.Drawing.Point(7, 580);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(763, 10);
		this.labelControl2.TabIndex = 11;
		this.lookUpClasses.Location = new System.Drawing.Point(12, 12);
		this.lookUpClasses.Name = "lookUpClasses";
		this.lookUpClasses.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lookUpClasses.Properties.Appearance.Options.UseFont = true;
		this.lookUpClasses.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpClasses.Properties.NullText = "[Select Class]";
		this.lookUpClasses.Size = new System.Drawing.Size(295, 24);
		this.lookUpClasses.TabIndex = 12;
		this.lookUpClasses.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(lookUpClasses_Closed);
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(164, 75);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(143, 25);
		this.simpleButton2.TabIndex = 13;
		this.simpleButton2.Text = "Close";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(319, 112);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.lookUpClasses);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.btnRegisterStudents);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.Name = "StudentSubjectRegistration_PrePrimaryV2";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Student Registration";
		base.Load += new System.EventHandler(StudentSubjectRegistration_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(StudentSubjectRegistration_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.lookUpClasses.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
