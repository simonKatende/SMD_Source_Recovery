using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using AlienAge.TermlySettings.Thematic;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace MarksEntry;

public class Login : XtraForm
{
	private string SelectedClass = string.Empty;

	public string SelectedClassGroup = string.Empty;

	private string ThematicCurriculum = string.Empty;

	private IContainer components = null;

	private SimpleButton btnCancel;

	private SimpleButton btnLogin;

	private TextEdit txtUserId;

	private TextEdit txtPassword;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private ComboBoxEdit cboSubject;

	private LabelControl labelControl3;

	private LabelControl labelControl4;

	private Timer timer1;

	private LookUpEdit lookupClasses;

	private RadioGroup radioGroup1;

	private GroupControl groupControl1;

	public Login()
	{
		InitializeComponent();
		Text = "Login";
		Classes.LoadLookUpWithClasses(lookupClasses);
	}

	private void LoadALevelSubjects()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * from ALevelSubjects", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "subject");
			DataTable dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				cboSubject.Properties.Items.Clear();
				foreach (DataRow row in dataTable.Rows)
				{
					cboSubject.Properties.Items.Add(string.Format("{0}", row["SubjectId"]));
				}
				cboSubject.SelectedIndex = 0;
				cboSubject.ForeColor = Color.Black;
			}
			else
			{
				cboSubject.Properties.Items.Clear();
				cboSubject.Properties.Items.Add("No Subjects");
				cboSubject.SelectedIndex = 0;
				cboSubject.ForeColor = Color.Red;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void LoadOLevelSubjects()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * from OLevelSubjects", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "subject");
			DataTable dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				cboSubject.Properties.Items.Clear();
				foreach (DataRow row in dataTable.Rows)
				{
					cboSubject.Properties.Items.Add(row["SubjectId"].ToString());
				}
				cboSubject.SelectedIndex = 0;
				cboSubject.ForeColor = Color.Black;
			}
			else
			{
				cboSubject.Properties.Items.Clear();
				cboSubject.Properties.Items.Add("No Subjects");
				cboSubject.SelectedIndex = 0;
				cboSubject.ForeColor = Color.Red;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private string LoadDefaultALevelPaperForTeacher(string SubjectId)
	{
		string result = string.Empty;
		using (SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
		{
			string selectCommandText = $"SELECT * FROM tbl_subjectLogin WHERE SubjectId LIKE '%{SubjectId}%' AND staffId='{txtUserId.Text.ToUpper()}' AND ClassId='{SelectedClass}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ALevelSubjects");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			IEnumerator enumerator = dataTable.Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					result = dataRow["SubjectId"].ToString();
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
		return result;
	}

	private void LoginToSubjects()
	{
		try
		{
			string text = CryptorEngine.Encrypt(txtPassword.Text + txtUserId.Text.ToLower() + SelectedClass);
			string arg = CryptorEngine.Encrypt($"DOS{txtUserId.Text.ToLower()}{txtPassword.Text}");
			if (radioGroup1.SelectedIndex == 0)
			{
				if ((!SelectedClass.Contains("S.5") && !SelectedClass.Contains("S.6") && !SelectedClass.Contains("P.")) || SemesterSettings.IsSemesterSet(SelectedClass, WorkingSemesters.GetWorkingSemester()))
				{
					SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection.Open();
					using SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = $"SELECT * FROM tbl_userLogin WHERE GroupName='DOS' AND userName='{txtUserId.Text.ToUpper()}' AND Password='{arg}'",
						CommandType = CommandType.Text
					};
					using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					if (sqlDataReader.HasRows)
					{
						using (SubjectInitials subjectInitials = new SubjectInitials())
						{
							if (subjectInitials.ShowDialog() == DialogResult.OK)
							{
								TeacherLogin.InitializeLogin(SelectedClass, WorkingSemesters.GetWorkingSemester(), cboSubject.SelectedItem.ToString(), TeacherInitials.GetTeacherInitials(), txtUserId.Text.ToUpper(), "DOS");
								LoginStatus.SaveLoginStatus(loggedIn: true);
								MarksGateway.SetLoginParameters(TeacherInitials.GetTeacherInitials(), cboSubject.SelectedItem.ToString(), SelectedClass, WorkingSemesters.GetWorkingSemester(), ThematicCurriculum);
								base.DialogResult = DialogResult.OK;
								Close();
							}
							else
							{
								LoginStatus.SaveLoginStatus(loggedIn: false);
							}
							return;
						}
					}
					SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection2.Open();
					SqlCommand sqlCommand2 = new SqlCommand();
					sqlCommand2.Connection = sqlConnection2;
					string commandText = $"SELECT * FROM tbl_subjectLogin WHERE staffId='{txtUserId.Text.ToUpper()}' AND SubjectId = '{LoadDefaultALevelPaperForTeacher(cboSubject.SelectedItem.ToString())}' AND ClassId='{SelectedClass}'";
					sqlCommand2.CommandText = commandText;
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					if (sqlDataReader2.HasRows)
					{
						sqlConnection2.Close();
						string commandText2 = "SELECT * FROM tbl_subjectLogin WHERE staffId=@staffId AND SubjectId=@SubjectId AND ClassId=@ClassId AND Password=@Password";
						SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection3.Open();
						SqlCommand sqlCommand3 = new SqlCommand();
						sqlCommand3.Connection = sqlConnection3;
						sqlCommand3.CommandText = commandText2;
						sqlCommand3.CommandType = CommandType.Text;
						SqlParameter sqlParameter = sqlCommand3.Parameters.Add("@staffId", SqlDbType.VarChar, 50);
						sqlParameter.Value = txtUserId.Text;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand3.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
						sqlParameter.Value = LoadDefaultALevelPaperForTeacher(cboSubject.SelectedItem.ToString());
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand3.Parameters.Add("@ClassId", SqlDbType.VarChar, 50);
						sqlParameter.Value = SelectedClass;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand3.Parameters.Add("@Password", SqlDbType.VarChar, 80);
						sqlParameter.Value = string.Empty;
						sqlParameter.Direction = ParameterDirection.Input;
						SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
						if (sqlDataReader3.HasRows)
						{
							using (CreateTeacherLogin createTeacherLogin = new CreateTeacherLogin())
							{
								createTeacherLogin.userId = txtUserId.Text;
								createTeacherLogin.subjectId = cboSubject.SelectedItem.ToString();
								createTeacherLogin.classId = SelectedClass;
								createTeacherLogin.txtNewUserId.Text = txtUserId.Text.ToUpper();
								createTeacherLogin.lblReason.Text = $"You must create a secret password that will enable you login to {cboSubject.SelectedItem.ToString()} for {SelectedClass} and enter marks";
								if (createTeacherLogin.ShowDialog() == DialogResult.OK)
								{
									using (SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase()))
									{
										sqlConnection4.Open();
										using SqlCommand sqlCommand4 = new SqlCommand
										{
											Connection = sqlConnection4,
											CommandText = "UPDATE tbl_subjectLogin SET Password=@Password,Password2=@Password2,Login=@Login WHERE staffId=@staffId AND SubjectId LIKE '%" + createTeacherLogin.subjectId + "%' AND ClassId=@ClassId",
											CommandType = CommandType.Text
										};
										SqlParameter sqlParameter2 = sqlCommand4.Parameters.Add("@Password", SqlDbType.VarChar, 80);
										sqlParameter2.Value = createTeacherLogin.newPassWord;
										sqlParameter2.Direction = ParameterDirection.Input;
										sqlParameter2 = sqlCommand4.Parameters.Add("@Password2", SqlDbType.VarChar, 50);
										sqlParameter2.Value = createTeacherLogin.newPassWord2;
										sqlParameter2.Direction = ParameterDirection.Input;
										sqlParameter2 = sqlCommand4.Parameters.Add("@Login", SqlDbType.VarChar, 50);
										sqlParameter2.Value = createTeacherLogin.userId;
										sqlParameter2.Direction = ParameterDirection.Input;
										sqlParameter2 = sqlCommand4.Parameters.Add("@staffId", SqlDbType.VarChar, 50);
										sqlParameter2.Value = createTeacherLogin.userId;
										sqlParameter2.Direction = ParameterDirection.Input;
										sqlParameter2 = sqlCommand4.Parameters.Add("@ClassId", SqlDbType.VarChar, 50);
										sqlParameter2.Value = createTeacherLogin.classId;
										sqlParameter2.Direction = ParameterDirection.Input;
										sqlCommand4.ExecuteNonQuery();
										sqlConnection4.Close();
										return;
									}
								}
								return;
							}
						}
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_subjectLogin WHERE staffId='{txtUserId.Text.ToUpper()}' AND SubjectId='{LoadDefaultALevelPaperForTeacher(cboSubject.SelectedItem.ToString())}' AND ClassId='{SelectedClass}' AND Password='{text}'", DataConnection.ConnectToDatabase());
						DataSet dataSet = new DataSet();
						sqlDataAdapter.Fill(dataSet, "ValidateLogin");
						if (dataSet.Tables[0].Rows.Count > 0)
						{
							foreach (DataRow row in dataSet.Tables[0].Rows)
							{
								TeacherLogin.InitializeLogin(SelectedClass, WorkingSemesters.GetWorkingSemester(), cboSubject.SelectedItem.ToString(), row["StaffName"].ToString(), txtUserId.Text, "Teacher");
								TeacherInitials.SetInitials(row["StaffName"].ToString());
								MarksGateway.SetLoginParameters(TeacherInitials.GetTeacherInitials(), cboSubject.SelectedItem.ToString(), SelectedClass, WorkingSemesters.GetWorkingSemester(), ThematicCurriculum);
								base.DialogResult = DialogResult.OK;
								Close();
							}
							return;
						}
						XtraMessageBox.Show("Invalid Login!\nEither the Password or Username is incorrect", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						sqlConnection2.Close();
						XtraMessageBox.Show($"The Staff ID [{txtUserId.Text.ToUpper()}] you provided is not mapped for login in {cboSubject.SelectedItem.ToString()} in {SelectedClass}.\nPlease contact your system administrator.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					return;
				}
				XtraMessageBox.Show("Sorry, you cannot enter students' marks now because...\nThere are no examinations ratios set for " + SelectedClass + ", " + WorkingSemesters.GetWorkingSemester(), "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				if (radioGroup1.SelectedIndex != 1)
				{
					return;
				}
				using SqlConnection sqlConnection5 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection5.Open();
				using SqlCommand sqlCommand5 = new SqlCommand
				{
					Connection = sqlConnection5,
					CommandText = $"SELECT * FROM tbl_userLogin WHERE GroupName='DOS' AND userName='{txtUserId.Text.ToUpper()}' AND Password='{arg}'",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader4 = sqlCommand5.ExecuteReader();
				if (sqlDataReader4.HasRows)
				{
					using (SubjectInitials subjectInitials2 = new SubjectInitials())
					{
						if (subjectInitials2.ShowDialog() == DialogResult.OK)
						{
							TeacherLogin.InitializeLogin(SelectedClass, WorkingSemesters.GetWorkingSemester(), cboSubject.SelectedItem.ToString(), TeacherInitials.GetTeacherInitials(), txtUserId.Text.ToUpper(), "DOS");
							LoginStatus.SaveLoginStatus(loggedIn: true);
							MarksGateway.SetLoginParameters(TeacherInitials.GetTeacherInitials(), cboSubject.SelectedItem.ToString(), SelectedClass, WorkingSemesters.GetWorkingSemester(), ThematicCurriculum);
							base.DialogResult = DialogResult.OK;
							Close();
						}
						else
						{
							LoginStatus.SaveLoginStatus(loggedIn: false);
						}
						return;
					}
				}
				SqlConnection sqlConnection6 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection6.Open();
				SqlCommand sqlCommand6 = new SqlCommand();
				sqlCommand6.Connection = sqlConnection6;
				string commandText3 = $"SELECT * FROM tbl_subjectLogin WHERE staffId='{txtUserId.Text.ToUpper()}' AND SubjectId = '{LoadDefaultALevelPaperForTeacher(cboSubject.SelectedItem.ToString())}' AND ClassId='{SelectedClass}'";
				sqlCommand6.CommandText = commandText3;
				SqlDataReader sqlDataReader5 = sqlCommand6.ExecuteReader();
				if (sqlDataReader5.HasRows)
				{
					sqlConnection6.Close();
					string commandText4 = "SELECT * FROM tbl_subjectLogin WHERE staffId=@staffId AND SubjectId=@SubjectId AND ClassId=@ClassId AND Password=@Password";
					SqlConnection sqlConnection7 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection7.Open();
					SqlCommand sqlCommand7 = new SqlCommand();
					sqlCommand7.Connection = sqlConnection7;
					sqlCommand7.CommandText = commandText4;
					sqlCommand7.CommandType = CommandType.Text;
					SqlParameter sqlParameter3 = sqlCommand7.Parameters.Add("@staffId", SqlDbType.VarChar, 50);
					sqlParameter3.Value = txtUserId.Text;
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand7.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
					sqlParameter3.Value = LoadDefaultALevelPaperForTeacher(cboSubject.SelectedItem.ToString());
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand7.Parameters.Add("@ClassId", SqlDbType.VarChar, 50);
					sqlParameter3.Value = SelectedClass;
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand7.Parameters.Add("@Password", SqlDbType.VarChar, 80);
					sqlParameter3.Value = string.Empty;
					sqlParameter3.Direction = ParameterDirection.Input;
					SqlDataReader sqlDataReader6 = sqlCommand7.ExecuteReader();
					if (sqlDataReader6.HasRows)
					{
						using (CreateTeacherLogin createTeacherLogin2 = new CreateTeacherLogin())
						{
							createTeacherLogin2.userId = txtUserId.Text;
							createTeacherLogin2.subjectId = cboSubject.SelectedItem.ToString();
							createTeacherLogin2.classId = SelectedClass;
							createTeacherLogin2.txtNewUserId.Text = txtUserId.Text.ToUpper();
							createTeacherLogin2.lblReason.Text = $"You must create a secret password that will enable you login to {cboSubject.SelectedItem.ToString()} for {SelectedClass} and enter marks";
							if (createTeacherLogin2.ShowDialog() == DialogResult.OK)
							{
								using (SqlConnection sqlConnection8 = new SqlConnection(DataConnection.ConnectToDatabase()))
								{
									sqlConnection8.Open();
									using SqlCommand sqlCommand8 = new SqlCommand
									{
										Connection = sqlConnection8,
										CommandText = "UPDATE tbl_subjectLogin SET Password=@Password,Password2=@Password2,Login=@Login WHERE staffId=@staffId AND SubjectId LIKE '%" + createTeacherLogin2.subjectId + "%' AND ClassId=@ClassId",
										CommandType = CommandType.Text
									};
									SqlParameter sqlParameter4 = sqlCommand8.Parameters.Add("@Password", SqlDbType.VarChar, 80);
									sqlParameter4.Value = createTeacherLogin2.newPassWord;
									sqlParameter4.Direction = ParameterDirection.Input;
									sqlParameter4 = sqlCommand8.Parameters.Add("@Password2", SqlDbType.VarChar, 50);
									sqlParameter4.Value = createTeacherLogin2.newPassWord2;
									sqlParameter4.Direction = ParameterDirection.Input;
									sqlParameter4 = sqlCommand8.Parameters.Add("@Login", SqlDbType.VarChar, 50);
									sqlParameter4.Value = createTeacherLogin2.userId;
									sqlParameter4.Direction = ParameterDirection.Input;
									sqlParameter4 = sqlCommand8.Parameters.Add("@staffId", SqlDbType.VarChar, 50);
									sqlParameter4.Value = createTeacherLogin2.userId;
									sqlParameter4.Direction = ParameterDirection.Input;
									sqlParameter4 = sqlCommand8.Parameters.Add("@ClassId", SqlDbType.VarChar, 50);
									sqlParameter4.Value = createTeacherLogin2.classId;
									sqlParameter4.Direction = ParameterDirection.Input;
									sqlCommand8.ExecuteNonQuery();
									sqlConnection8.Close();
									return;
								}
							}
							return;
						}
					}
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter($"SELECT * FROM tbl_subjectLogin WHERE staffId='{txtUserId.Text.ToUpper()}' AND SubjectId='{LoadDefaultALevelPaperForTeacher(cboSubject.SelectedItem.ToString())}' AND ClassId='{SelectedClass}' AND Password='{text}'", DataConnection.ConnectToDatabase());
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "ValidateLogin");
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						foreach (DataRow row2 in dataSet2.Tables[0].Rows)
						{
							TeacherLogin.InitializeLogin(SelectedClass, WorkingSemesters.GetWorkingSemester(), cboSubject.SelectedItem.ToString(), row2["StaffName"].ToString(), txtUserId.Text, "Teacher");
							TeacherInitials.SetInitials(row2["StaffName"].ToString());
							MarksGateway.SetLoginParameters(TeacherInitials.GetTeacherInitials(), cboSubject.SelectedItem.ToString(), SelectedClass, WorkingSemesters.GetWorkingSemester(), ThematicCurriculum);
							base.DialogResult = DialogResult.OK;
							Close();
						}
						return;
					}
					XtraMessageBox.Show("Invalid Login!\nEither the Password or Username is incorrect", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					sqlConnection6.Close();
					XtraMessageBox.Show($"The Staff ID [{txtUserId.Text.ToUpper()}] you provided is not mapped for login in {cboSubject.SelectedItem.ToString()} in {SelectedClass}.\nPlease contact your system administrator.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				return;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message + "\nCANNOT CONNECT TO THE SERVER.\nPlease enter the correct server/database parameters or check your Network Integrity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			using ConnectToDatabase connectToDatabase = new ConnectToDatabase();
			connectToDatabase.ShowDialog();
		}
	}

	private void btnLogin_Click(object sender, EventArgs e)
	{
		LoginToSubjects();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Application.ExitThread();
	}

	private void Login_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			LoginToSubjects();
		}
		else if (e.KeyCode == Keys.Escape)
		{
			Application.ExitThread();
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (SelectedClass != string.Empty && txtPassword.Text != string.Empty && txtUserId.Text != string.Empty)
		{
			btnLogin.Enabled = true;
		}
		else
		{
			btnLogin.Enabled = false;
		}
	}

	private void lookupClasses_Closed(object sender, ClosedEventArgs e)
	{
		if (lookupClasses.EditValue == null)
		{
			return;
		}
		try
		{
			if (string.IsNullOrEmpty(lookupClasses.Text) || lookupClasses.Text == "N/A")
			{
				cboSubject.Enabled = false;
				return;
			}
			cboSubject.Enabled = true;
			SelectedClass = lookupClasses.Properties.GetDataSourceValue("ClassId", lookupClasses.ItemIndex).ToString();
			SelectedClassGroup = lookupClasses.Properties.GetDataSourceValue("ClassGroup", lookupClasses.ItemIndex).ToString();
			if (SelectedClass.Equals("S.1") || SelectedClass.Equals("S.2") || SelectedClass.Equals("S.3") || SelectedClass.Equals("S.4"))
			{
				LoadOLevelSubjects();
				ThematicCurriculum = "New";
			}
			else if (SelectedClass.Equals("S.5") || SelectedClass.Equals("S.6"))
			{
				LoadALevelSubjects();
				ThematicCurriculum = "Old";
			}
			else if (SelectedClass.Equals("P.1") || SelectedClass.Equals("P.2") || SelectedClass.Equals("P.3") || SelectedClass.Equals("P.4") || SelectedClass.Equals("P.5") || SelectedClass.Equals("P.6") || SelectedClass.Equals("P.7"))
			{
				LoadOLevelSubjects();
				ThematicCurriculum = "Old";
			}
			else
			{
				SelectedClass = lookupClasses.Properties.GetDataSourceValue("ClassId", lookupClasses.ItemIndex).ToString();
				SelectedClassGroup = "Islamic Theology";
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void lookupClasses_QueryPopUp(object sender, CancelEventArgs e)
	{
		SelectedClass = string.Empty;
		SelectedClassGroup = string.Empty;
		ThematicCurriculum = string.Empty;
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
		this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
		this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
		this.txtUserId = new DevExpress.XtraEditors.TextEdit();
		this.txtPassword = new DevExpress.XtraEditors.TextEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.cboSubject = new DevExpress.XtraEditors.ComboBoxEdit();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.lookupClasses = new DevExpress.XtraEditors.LookUpEdit();
		this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
		this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
		((System.ComponentModel.ISupportInitialize)this.txtUserId.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSubject.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookupClasses.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.radioGroup1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).BeginInit();
		this.groupControl1.SuspendLayout();
		base.SuspendLayout();
		this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5f);
		this.btnCancel.Appearance.Options.UseFont = true;
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.Location = new System.Drawing.Point(255, 253);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(163, 34);
		this.btnCancel.TabIndex = 5;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
		this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5f);
		this.btnLogin.Appearance.Options.UseFont = true;
		this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.No;
		this.btnLogin.Location = new System.Drawing.Point(79, 253);
		this.btnLogin.Name = "btnLogin";
		this.btnLogin.Size = new System.Drawing.Size(163, 34);
		this.btnLogin.TabIndex = 4;
		this.btnLogin.Text = "Login";
		this.btnLogin.Click += new System.EventHandler(btnLogin_Click);
		this.txtUserId.EnterMoveNextControl = true;
		this.txtUserId.Location = new System.Drawing.Point(79, 193);
		this.txtUserId.Margin = new System.Windows.Forms.Padding(2);
		this.txtUserId.Name = "txtUserId";
		this.txtUserId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.txtUserId.Properties.Appearance.Options.UseFont = true;
		this.txtUserId.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtUserId.Size = new System.Drawing.Size(339, 26);
		this.txtUserId.TabIndex = 2;
		this.txtPassword.Location = new System.Drawing.Point(79, 223);
		this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.txtPassword.Properties.Appearance.Options.UseFont = true;
		this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtPassword.Properties.UseSystemPasswordChar = true;
		this.txtPassword.Size = new System.Drawing.Size(339, 26);
		this.txtPassword.TabIndex = 3;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Location = new System.Drawing.Point(11, 201);
		this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(57, 18);
		this.labelControl1.TabIndex = 6;
		this.labelControl1.Text = "Staff ID:";
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.labelControl2.Appearance.Options.UseFont = true;
		this.labelControl2.Location = new System.Drawing.Point(11, 231);
		this.labelControl2.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(66, 18);
		this.labelControl2.TabIndex = 7;
		this.labelControl2.Text = "Password:";
		this.cboSubject.EnterMoveNextControl = true;
		this.cboSubject.Location = new System.Drawing.Point(79, 163);
		this.cboSubject.Margin = new System.Windows.Forms.Padding(2);
		this.cboSubject.Name = "cboSubject";
		this.cboSubject.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.cboSubject.Properties.Appearance.Options.UseFont = true;
		this.cboSubject.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.5f);
		this.cboSubject.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboSubject.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboSubject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSubject.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboSubject.Size = new System.Drawing.Size(339, 26);
		this.cboSubject.TabIndex = 1;
		this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.labelControl3.Appearance.Options.UseFont = true;
		this.labelControl3.Location = new System.Drawing.Point(11, 141);
		this.labelControl3.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(38, 18);
		this.labelControl3.TabIndex = 8;
		this.labelControl3.Text = "Class:";
		this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.labelControl4.Appearance.Options.UseFont = true;
		this.labelControl4.Location = new System.Drawing.Point(11, 171);
		this.labelControl4.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(53, 18);
		this.labelControl4.TabIndex = 9;
		this.labelControl4.Text = "Subject:";
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.lookupClasses.Location = new System.Drawing.Point(79, 135);
		this.lookupClasses.Margin = new System.Windows.Forms.Padding(2);
		this.lookupClasses.Name = "lookupClasses";
		this.lookupClasses.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.lookupClasses.Properties.Appearance.Options.UseFont = true;
		this.lookupClasses.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.5f);
		this.lookupClasses.Properties.AppearanceDropDown.Options.UseFont = true;
		this.lookupClasses.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookupClasses.Properties.NullText = "[Select Class]";
		this.lookupClasses.Size = new System.Drawing.Size(339, 24);
		this.lookupClasses.TabIndex = 13;
		this.lookupClasses.QueryPopUp += new System.ComponentModel.CancelEventHandler(lookupClasses_QueryPopUp);
		this.lookupClasses.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(lookupClasses_Closed);
		this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.radioGroup1.Location = new System.Drawing.Point(2, 23);
		this.radioGroup1.Margin = new System.Windows.Forms.Padding(2);
		this.radioGroup1.Name = "radioGroup1";
		this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroup1.Properties.Appearance.Options.UseFont = true;
		this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Thematic", true, "Thematic"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Islamic Theology", true, "Theology")
		});
		this.radioGroup1.Size = new System.Drawing.Size(405, 75);
		this.radioGroup1.TabIndex = 14;
		this.groupControl1.Controls.Add(this.radioGroup1);
		this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card;
		this.groupControl1.Location = new System.Drawing.Point(11, 11);
		this.groupControl1.Margin = new System.Windows.Forms.Padding(2);
		this.groupControl1.Name = "groupControl1";
		this.groupControl1.Size = new System.Drawing.Size(409, 100);
		this.groupControl1.TabIndex = 15;
		this.groupControl1.Text = "Curriculum";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(429, 309);
		base.ControlBox = false;
		base.Controls.Add(this.groupControl1);
		base.Controls.Add(this.lookupClasses);
		base.Controls.Add(this.btnCancel);
		base.Controls.Add(this.labelControl4);
		base.Controls.Add(this.btnLogin);
		base.Controls.Add(this.labelControl3);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.txtPassword);
		base.Controls.Add(this.txtUserId);
		base.Controls.Add(this.cboSubject);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.Name = "Login";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Login";
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(Login_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.txtUserId.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSubject.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookupClasses.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.radioGroup1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).EndInit();
		this.groupControl1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
