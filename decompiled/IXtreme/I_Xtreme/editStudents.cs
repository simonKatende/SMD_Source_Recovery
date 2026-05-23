using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Utils.Behaviors;
using DevExpress.Utils.VisualEffects;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Mask;
using I_Xtreme.DialogForms;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Properties;

namespace I_Xtreme;

public class editStudents : XtraForm
{
	private string fName = string.Empty;

	private string fContact = string.Empty;

	private string fAddress = string.Empty;

	private string fEmail = string.Empty;

	private string mNin = string.Empty;

	private string fNin = string.Empty;

	private string mName = string.Empty;

	private string mContact = string.Empty;

	private string mAddress = string.Empty;

	private string mEmail = string.Empty;

	private string oldStudentId = string.Empty;

	private static SqlTransaction _trans;

	private SqlTransaction transaction;

	private DataTable _dt;

	private DataSet dataSet;

	private DataTable dataTable;

	private SqlTransaction trans;

	private string bursaryProvider;

	private string _class = string.Empty;

	private bool EditMode = false;

	private string __cmdText = "INSERT INTO tbl_Stud (StudentNumber,StudentID,HouseId,ClassId,StreamId,Oid,FormerSchool,StudyStatus,BursaryStatus,RequiredFees,BursaryProvider,AdmissionDate,Sex,Picture,Religion,HomeCountry,fullName,Status,Notes,cashOnAccount,Comb,FeesDiscount,SubjectString,fName,fContact,fAddress,fEmail,mName,mContact,mAddress,mEmail,DOB,IsTheologyStud,PrimaryScores1,Guardian,PriorityContact,OtherContact,GuardianAddress,mNIN,fNIN,LIN,ReportCentre,Cocurricular,HealthStatus,sNIN,GuardianRelation,GuardianPic,Term) VALUES (@StudentNumber,@StudentID,@HouseId,@ClassId,@StreamId,@Oid,@FormerSchool,@StudyStatus,@BursaryStatus,@RequiredFees,@BursaryProvider,@AdmissionDate,@Sex,@Picture,@Religion,@HomeCountry,@fullName,@Status,@Notes,@cashOnAccount,@Comb,@FeesDiscount,@SubjectString,@fName,@fContact,@fAddress,@fEmail,@mName,@mContact,@mAddress,@mEmail,@DOB,@IsTheologyStud,@PrimaryScores1,@Guardian,@PriorityContact,@OtherContact,@GuardianAddress,@mNIN,@fNIN,@LIN,@ReportCentre,@Cocurricular,@HealthStatus,@sNIN,@GuardianRelation,@GuardianPic,@Term)";

	public string admissionYear = string.Empty;

	private static string connectionString = DataConnection.ConnectToDatabase();

	private string combShort = string.Empty;

	private string combFull = string.Empty;

	public ClassChanged ClassChanged;

	public StartOrStopTimer StartTimer;

	private IContainer components = null;

	private TextEdit txtGuardianContact;

	private ComboBoxEdit cboReligion;

	private ComboBoxEdit cboHall;

	private TextEdit txtFormerSchool;

	private ComboBoxEdit cboSex;

	private TextEdit txtGurdianAddress;

	private TextEdit txtFullName;

	private LabelControl lblStudyStatus;

	private TextEdit txtRequiredFees;

	private MemoEdit txtNotes;

	private ComboBoxEdit cboBursaryProvider;

	private RadioGroup radioGroupStudyStatus;

	private ComboBoxEdit cboStream;

	private ComboBoxEdit cboClass;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	public TextEdit txtStudentNumber;

	public TextEdit txtUniqueGuid;

	public ComboBoxEdit cboNationality;

	private DXValidationProvider dxValidateInsert;

	private DXValidationProvider dxValidateUpdate;

	private TextEdit txtGuardian;

	public ComboBoxEdit cboStatus;

	private LabelControl lblCurrentClass;

	private LabelControl labelControl4;

	private LabelControl labelControl3;

	private LabelControl lblSelectedIndex;

	private LabelControl lblGuardianId;

	private TextEdit txtFeesDiscount;

	private CheckEdit chkBursaryStatus;

	private SimpleButton simpleButton5;

	private DateEdit dtDOB;

	private PictureEdit picStudent;

	private LabelControl labelControl5;

	private LabelControl labelControl6;

	private LabelControl labelControl7;

	private LabelControl labelControl8;

	private LabelControl labelControl9;

	private LabelControl labelControl10;

	private LabelControl labelControl11;

	private LabelControl labelControl12;

	private LabelControl labelControl13;

	private LabelControl labelControl14;

	private LabelControl labelControl15;

	private LabelControl labelControl16;

	private LabelControl labelControl17;

	private LabelControl labelControl18;

	private LabelControl labelControl19;

	private LabelControl labelControl20;

	private LabelControl labelControl21;

	private LabelControl labelControl23;

	private LabelControl labelControl22;

	private TextEdit txtResults;

	private LabelControl lblResultsLabel;

	private CheckEdit chkTheologyStudent;

	public TextEdit txtIDNumber;

	private LabelControl labelControl1;

	private TextEdit txtOtherContact;

	private LabelControl labelControl24;

	private LookUpEdit cboCombination;

	public TextEdit txtNIN;

	public TextEdit txtLIN;

	private LabelControl labelControl2;

	private LabelControl labelControl25;

	private TextEdit txtHealthStatus;

	private LabelControl labelControl26;

	private LabelControl labelControl27;

	private ComboBoxEdit cboNOKRelation;

	private LabelControl labelControl28;

	private ComboBoxEdit txtGames;

	private ComboBoxEdit txtReportCentre;

	private BehaviorManager behaviorManager1;

	private PictureEdit picGuardianPhoto;

	private AdornerUIManager adornerUIManager1;

	private Badge badge1;

	private Badge badge2;

	private SimpleButton simpleButton3;

	public editStudents(bool EditMode)
	{
		InitializeComponent();
		GetReportCentres();
		this.EditMode = EditMode;
		txtFullName.Focus();
		_class = StudentOptions.ActiveClass();
		lblCurrentClass.Text = _class;
		if (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Primary.ToString())
		{
			lblResultsLabel.Visible = false;
			txtResults.Visible = false;
		}
	}

	private void GetReportCentres()
	{
		DataTable dataTable = new DataTable();
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM ReportCentre", DataConnection.ConnectToDatabase());
		sqlDataAdapter.Fill(dataTable);
		txtReportCentre.Properties.Items.Clear();
		txtReportCentre.Properties.Items.Add("-Add New-");
		foreach (DataRow row in dataTable.Rows)
		{
			txtReportCentre.Properties.Items.Add(row["CentreName"]);
		}
	}

	private void ClearStudentFields()
	{
		txtFullName.Text = string.Empty;
		txtStudentNumber.Text = string.Empty;
		txtNotes.Text = string.Empty;
		txtGuardian.Text = string.Empty;
		txtGuardianContact.Text = string.Empty;
		txtGurdianAddress.Text = string.Empty;
		txtFormerSchool.Text = string.Empty;
		cboReligion.SelectedIndex = 0;
		cboSex.SelectedIndex = 0;
		picStudent.Image = Resources.Default;
		picGuardianPhoto.Image = Resources.Default;
		cboNOKRelation.Text = string.Empty;
		txtFeesDiscount.Text = string.Empty;
		chkBursaryStatus.Checked = false;
		txtResults.Text = string.Empty;
		txtIDNumber.Text = string.Empty;
	}

	private void LoadHouses()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Houses", selectConnection);
			dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Hall");
			dataTable = dataSet.Tables[0];
			cboHall.Properties.Items.Clear();
			ComboBoxItemCollection items = cboHall.Properties.Items;
			object[] items2 = new string[2] { "-", "-Add New-" };
			items.AddRange(items2);
			foreach (DataRow row in dataTable.Rows)
			{
				cboHall.Properties.Items.Add(row["HouseName"]);
			}
			cboHall.SelectedIndex = 0;
		}
		catch
		{
		}
	}

	private void AdmitStudent()
	{
		try
		{
			string text = StudentNumber.GetNextStudentNumber()[0];
			if (StudentNumber.StudentNumberExists(text))
			{
				XtraMessageBox.Show("The Student Number is already used.\nManually change the Student Number or\nCorrect your computer's calender, close and re-open this form", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (cboBursaryProvider.Enabled)
			{
				bursaryProvider = cboBursaryProvider.SelectedItem.ToString();
			}
			else
			{
				bursaryProvider = string.Empty;
			}
			double result = (double.TryParse(txtRequiredFees.Text, out result) ? result : 0.0);
			Image image = null;
			image = ((picGuardianPhoto.Image != null) ? picGuardianPhoto.Image : Resources.Default);
			int num = image.Height;
			int num2 = image.Width;
			num = num * 409 / num2;
			num2 = 409;
			if (num > 376)
			{
				num2 = num2 * 376 / num;
				num = 376;
			}
			Bitmap bitmap = new Bitmap(image, num2, num);
			byte[] array = new byte[0];
			using (MemoryStream memoryStream = new MemoryStream())
			{
				bitmap.Save(memoryStream, ImageFormat.Bmp);
				memoryStream.Position = 0L;
				array = new byte[memoryStream.Length + 1];
				memoryStream.Read(array, 0, array.Length);
			}
			Image image2 = null;
			image2 = ((picStudent.Image != null) ? picStudent.Image : Resources.Default);
			int num3 = image2.Height;
			int num4 = image2.Width;
			num3 = num3 * 409 / num4;
			num4 = 409;
			if (num3 > 376)
			{
				num4 = num4 * 376 / num3;
				num3 = 376;
			}
			Bitmap bitmap2 = new Bitmap(image2, num4, num3);
			byte[] array2 = new byte[0];
			using (MemoryStream memoryStream2 = new MemoryStream())
			{
				bitmap2.Save(memoryStream2, ImageFormat.Bmp);
				memoryStream2.Position = 0L;
				array2 = new byte[memoryStream2.Length + 1];
				memoryStream2.Read(array2, 0, array2.Length);
			}
			using SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			transaction = sqlConnection.BeginTransaction();
			string g = txtUniqueGuid.Text;
			Guid guid = new Guid(g);
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Transaction = transaction,
				Connection = sqlConnection,
				CommandText = __cmdText,
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
				sqlParameter.Value = text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@StudentID", SqlDbType.VarChar, 12);
				sqlParameter.Value = txtIDNumber.Text.ToUpper();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@HouseId", SqlDbType.VarChar, 25);
				sqlParameter.Value = cboHall.SelectedItem.ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
				sqlParameter.Value = cboClass.SelectedItem.ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@StreamId", SqlDbType.VarChar, 10);
				sqlParameter.Value = cboStream.SelectedItem;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Oid", SqlDbType.UniqueIdentifier);
				sqlParameter.Value = guid;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@FormerSchool", SqlDbType.VarChar, 50);
				sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtFormerSchool.Text.Trim());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@StudyStatus", SqlDbType.VarChar, 1);
				sqlParameter.Value = lblStudyStatus.Text.Trim();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@BursaryStatus", SqlDbType.Bit);
				sqlParameter.Value = Convert.ToBoolean(chkBursaryStatus.EditValue);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@RequiredFees", SqlDbType.Money);
				sqlParameter.Value = result.ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@BursaryProvider", SqlDbType.VarChar, 50);
				sqlParameter.Value = bursaryProvider;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@AdmissionDate", SqlDbType.VarChar, 4);
				sqlParameter.Value = admissionYear.ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Sex", SqlDbType.VarChar, 1);
				sqlParameter.Value = cboSex.SelectedItem;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Picture", SqlDbType.Image);
				sqlParameter.Value = array2;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Religion", SqlDbType.VarChar, 15);
				sqlParameter.Value = cboReligion.SelectedItem;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@HomeCountry", SqlDbType.VarChar, 15);
				sqlParameter.Value = cboNationality.SelectedItem;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fullName", SqlDbType.VarChar, 50);
				sqlParameter.Value = txtFullName.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Notes", SqlDbType.VarChar);
				sqlParameter.Value = txtNotes.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar, 15);
				sqlParameter.Value = cboStatus.SelectedItem.ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@cashOnAccount", SqlDbType.Money);
				sqlParameter.Value = 0;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Comb", SqlDbType.VarChar, 12);
				sqlParameter.Value = combShort;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@SubjectString", SqlDbType.VarChar, 50);
				sqlParameter.Value = combFull;
				sqlParameter.Direction = ParameterDirection.Input;
				double result2 = (double.TryParse(txtFeesDiscount.Text, out result2) ? result2 : 0.0);
				sqlParameter = sqlCommand.Parameters.Add("@FeesDiscount", SqlDbType.Money);
				sqlParameter.Value = result2;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fName", SqlDbType.VarChar, 50);
				sqlParameter.Value = fName;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fAddress", SqlDbType.VarChar, 50);
				sqlParameter.Value = fAddress;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fContact", SqlDbType.VarChar, 10);
				sqlParameter.Value = fContact;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fEmail", SqlDbType.VarChar, 50);
				sqlParameter.Value = fEmail;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mName", SqlDbType.VarChar, 50);
				sqlParameter.Value = mName;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mAddress", SqlDbType.VarChar, 50);
				sqlParameter.Value = mAddress;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mContact", SqlDbType.VarChar, 10);
				sqlParameter.Value = mContact;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mEmail", SqlDbType.VarChar, 50);
				sqlParameter.Value = mEmail;
				sqlParameter.Direction = ParameterDirection.Input;
				DateTime result3 = (DateTime.TryParse(dtDOB.Text.ToString(), out result3) ? result3 : DateTime.Now);
				sqlParameter = sqlCommand.Parameters.Add("@DOB", SqlDbType.DateTime);
				sqlParameter.Value = result3;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@IsTheologyStud", SqlDbType.Bit);
				sqlParameter.Value = Convert.ToBoolean(chkTheologyStudent.EditValue);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@PrimaryScores1", SqlDbType.VarChar, 50);
				sqlParameter.Value = txtResults.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Guardian", SqlDbType.VarChar, 50);
				sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtGuardian.Text.Trim());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@PriorityContact", SqlDbType.VarChar, 11);
				sqlParameter.Value = txtGuardianContact.Text.Trim();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@OtherContact", SqlDbType.VarChar, 11);
				sqlParameter.Value = txtOtherContact.Text.Trim();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@GuardianAddress", SqlDbType.VarChar, 50);
				sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtGurdianAddress.Text.Trim());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fNIN", SqlDbType.NVarChar, 100);
				sqlParameter.Value = fNin;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mNIN", SqlDbType.NVarChar, 100);
				sqlParameter.Value = mNin;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@sNIN", SqlDbType.NVarChar, 100);
				sqlParameter.Value = txtNIN.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@LIN", SqlDbType.NVarChar, 100);
				sqlParameter.Value = txtLIN.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@ReportCentre", SqlDbType.NVarChar, 100);
				sqlParameter.Value = txtReportCentre.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Cocurricular", SqlDbType.NVarChar, 100);
				sqlParameter.Value = txtGames.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@HealthStatus", SqlDbType.NVarChar, 100);
				sqlParameter.Value = txtHealthStatus.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@GuardianPic", SqlDbType.Image);
				sqlParameter.Value = array;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@GuardianRelation", SqlDbType.NVarChar, 100);
				sqlParameter.Value = cboNOKRelation.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Term", SqlDbType.NVarChar, 30);
				sqlParameter.Value = WorkingSemesters.GetWorkingSemester();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			transaction.Commit();
			CustomDialog.ShowCustomDialog("Student Registered");
			ClearStudentFields();
			sqlConnection.Close();
			txtUniqueGuid.Text = Guid.NewGuid().ToString();
			txtIDNumber.Text = StudentNumber.GetNextStudentNumber()[1];
			if (!SchoolInfoTemp.UseDashboard)
			{
				StartTimer(timerStatus: true);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadBursaryProviders()
	{
		try
		{
			using (SqlConnection selectConnection = new SqlConnection(connectionString))
			{
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_AllowedDiscounts", selectConnection);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "provider");
				_dt = new DataTable();
				_dt = dataSet.Tables[0];
				cboBursaryProvider.Properties.Items.Clear();
				cboBursaryProvider.Properties.Items.AddRange(new object[2] { "------", "Add New" });
				foreach (DataRow row in _dt.Rows)
				{
					cboBursaryProvider.Properties.Items.Add(row["ShortDescription"].ToString());
				}
			}
			cboBursaryProvider.SelectedIndex = 0;
		}
		catch
		{
		}
	}

	private void FindStudent(string studentNumber)
	{
		try
		{
			string selectCommandText = $"SELECT * FROM tbl_Stud  WHERE StudentNumber='{studentNumber}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, connectionString);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Students");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				fName = row["fName"].ToString();
				fAddress = row["fAddress"].ToString();
				fContact = row["fContact"].ToString();
				fEmail = row["fEmail"].ToString();
				fNin = row["fNIN"].ToString();
				mName = row["mName"].ToString();
				mAddress = row["mAddress"].ToString();
				mContact = row["mContact"].ToString();
				mEmail = row["mEmail"].ToString();
				mNin = row["mNIN"].ToString();
				DateTime result = (DateTime.TryParse(row["DOB"].ToString(), out result) ? result : DateTime.Now);
				dtDOB.DateTime = result;
				txtStudentNumber.Text = row["StudentNumber"].ToString();
				txtUniqueGuid.Text = row["Oid"].ToString();
				txtFullName.Text = row["fullName"].ToString();
				admissionYear = row["AdmissionDate"].ToString();
				txtGuardianContact.Text = row["PriorityContact"].ToString();
				txtOtherContact.Text = row["OtherContact"].ToString();
				txtGurdianAddress.Text = row["GuardianAddress"].ToString();
				txtGuardian.Text = row["Guardian"].ToString();
				txtFormerSchool.Text = row["FormerSchool"].ToString();
				txtNIN.Text = row["sNIN"].ToString();
				txtLIN.Text = row["LIN"].ToString();
				txtReportCentre.Text = row["ReportCentre"].ToString();
				txtGames.Text = row["Cocurricular"].ToString();
				txtHealthStatus.Text = row["HealthStatus"].ToString();
				cboNOKRelation.Text = row["GuardianRelation"].ToString();
				double result2 = (double.TryParse(row["RequiredFees"].ToString(), out result2) ? result2 : 0.0);
				double result3 = (double.TryParse(row["FeesDiscount"].ToString(), out result3) ? result3 : 0.0);
				txtRequiredFees.Text = result2.ToString("#,#.0");
				txtFeesDiscount.Text = result3.ToString("#,#.0");
				cboSex.Text = row["Sex"].ToString();
				cboReligion.Text = row["Religion"].ToString();
				cboNationality.Text = row["HomeCountry"].ToString();
				cboClass.Text = row["ClassId"].ToString();
				_class = row["ClassId"].ToString();
				cboStream.Text = row["StreamId"].ToString();
				cboHall.Text = row["HouseId"].ToString();
				cboStatus.Text = row["Status"].ToString();
				txtIDNumber.Text = row["StudentID"].ToString();
				oldStudentId = row["StudentID"].ToString();
				cboCombination.Text = row["SubjectString"].ToString();
				txtResults.Text = row["PrimaryScores1"].ToString();
				bool result4 = bool.TryParse(row["IsTheologyStud"].ToString(), out result4) && result4;
				chkTheologyStudent.Checked = result4;
				byte[] array = new byte[0];
				array = (byte[])row["Picture"];
				using (MemoryStream stream = new MemoryStream(array))
				{
					picStudent.Image = Image.FromStream(stream);
				}
				if (!string.IsNullOrEmpty(row["GuardianPic"].ToString()))
				{
					byte[] array2 = new byte[0];
					array2 = (byte[])row["GuardianPic"];
					using MemoryStream stream2 = new MemoryStream(array2);
					picGuardianPhoto.Image = Image.FromStream(stream2);
				}
				if (row["StudyStatus"].ToString() == "B")
				{
					radioGroupStudyStatus.SelectedIndex = 0;
				}
				else
				{
					radioGroupStudyStatus.SelectedIndex = 1;
				}
				bool result5 = bool.TryParse(row["BursaryStatus"].ToString(), out result5) && result5;
				if (result5)
				{
					cboBursaryProvider.SelectedItem = row["BursaryProvider"].ToString();
					chkBursaryStatus.Checked = true;
				}
				else
				{
					chkBursaryStatus.Checked = false;
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void radioGroupStudyStatus_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (radioGroupStudyStatus.SelectedIndex == 0)
		{
			lblStudyStatus.Text = "B";
		}
		else
		{
			lblStudyStatus.Text = "D";
		}
		txtRequiredFees.Text = FeesStructure(lblStudyStatus.Text).ToString();
	}

	private void LoadImage()
	{
		try
		{
			string text = null;
			using OpenFileDialog openFileDialog = new OpenFileDialog
			{
				RestoreDirectory = true,
				Title = "Open Student's photo",
				Filter = "jpg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|png files (*.png)|*.png|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				text = openFileDialog.FileName;
				picStudent.Image = Image.FromFile(text);
				picStudent.Image = Image.FromFile(text);
			}
		}
		catch (ArgumentException ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
		catch (Exception ex2)
		{
			XtraMessageBox.Show(ex2.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private double FeesStructure(string studyStatus)
	{
		double result = 0.0;
		if (cboClass.SelectedIndex > 0 && Text != "Edit Student Details")
		{
			using SqlConnection selectConnection = new SqlConnection(connectionString);
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM Classes WHERE ClassName='{cboClass.SelectedItem}'", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "feesStructure");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				if (studyStatus == "D")
				{
					result = (double.TryParse(row["TuitionNonResidents"].ToString(), out result) ? result : 0.0);
				}
				else if (studyStatus == "B")
				{
					result = (double.TryParse(row["TuitionResidents"].ToString(), out result) ? result : 0.0);
				}
			}
		}
		return result;
	}

	private void picStudent_DoubleClick(object sender, EventArgs e)
	{
		LoadImage();
	}

	private void UpdateStudent()
	{
		try
		{
			if (oldStudentId != txtIDNumber.Text && StudentNumber.StudentIDExists(txtIDNumber.Text))
			{
				XtraMessageBox.Show("The Student ID. No. you provided already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string commandText = "UPDATE tbl_Stud SET HouseId = @HouseId,StudentID=@StudentID,ClassId=@ClassId,StreamId = @StreamId,FormerSchool = @FormerSchool,StudyStatus = @StudyStatus,BursaryStatus = @BursaryStatus,RequiredFees = @RequiredFees,BursaryProvider = @BursaryProvider,AdmissionDate = @AdmissionDate,Sex = @Sex,picture = @picture,Religion = @Religion,HomeCountry = @HomeCountry,fullName = @fullName,Notes = @Notes,Status = @Status,Comb=@Comb,FeesDiscount=@FeesDiscount,SubjectString=@SubjectString,fName=@fName,fAddress=@fAddress,fContact=@fContact,fEmail=@fEmail,mName=@mName,mAddress=@mAddress,mContact=@mContact,mEmail=@mEmail,DOB=@DOB,IsTheologyStud=@IsTheologyStud,PrimaryScores1=@PrimaryScores1,Guardian=@Guardian,PriorityContact=@PriorityContact,OtherContact=@OtherContact,GuardianAddress=@GuardianAddress,mNIN=@mNIN,fNIN=@fNIN,LIN=@LIN,ReportCentre=@ReportCentre,Cocurricular=@Cocurricular,HealthStatus=@HealthStatus,sNIN=@sNIN,GuardianRelation=@GuardianRelation,GuardianPic=@GuardianPic WHERE StudentNumber=@StudentNumber";
			if (cboBursaryProvider.Enabled)
			{
				bursaryProvider = cboBursaryProvider.SelectedItem.ToString();
			}
			else
			{
				bursaryProvider = string.Empty;
			}
			double result = (double.TryParse(txtRequiredFees.Text, out result) ? result : 0.0);
			Image image = null;
			image = ((picGuardianPhoto.Image != null) ? picGuardianPhoto.Image : Resources.Default);
			int num = image.Height;
			int num2 = image.Width;
			num = num * 409 / num2;
			num2 = 409;
			if (num > 376)
			{
				num2 = num2 * 376 / num;
				num = 376;
			}
			Bitmap bitmap = new Bitmap(image, num2, num);
			byte[] array = new byte[0];
			using (MemoryStream memoryStream = new MemoryStream())
			{
				bitmap.Save(memoryStream, ImageFormat.Bmp);
				memoryStream.Position = 0L;
				array = new byte[memoryStream.Length + 1];
				memoryStream.Read(array, 0, array.Length);
			}
			Image image2 = null;
			image2 = ((picStudent.Image != null) ? picStudent.Image : Resources.Default);
			int num3 = image2.Height;
			int num4 = image2.Width;
			num3 = num3 * 409 / num4;
			num4 = 409;
			if (num3 > 376)
			{
				num4 = num4 * 376 / num3;
				num3 = 376;
			}
			Bitmap bitmap2 = new Bitmap(image2, num4, num3);
			byte[] array2 = new byte[0];
			using (MemoryStream memoryStream2 = new MemoryStream())
			{
				bitmap2.Save(memoryStream2, ImageFormat.Bmp);
				memoryStream2.Position = 0L;
				array2 = new byte[memoryStream2.Length + 1];
				memoryStream2.Read(array2, 0, array2.Length);
			}
			using SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = commandText,
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
				sqlParameter.Value = txtStudentNumber.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@StudentID", SqlDbType.VarChar, 12);
				sqlParameter.Value = txtIDNumber.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@HouseId", SqlDbType.VarChar, 25);
				sqlParameter.Value = cboHall.SelectedItem;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
				sqlParameter.Value = cboClass.SelectedItem.ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@StreamId", SqlDbType.VarChar, 10);
				sqlParameter.Value = cboStream.SelectedItem;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@FormerSchool", SqlDbType.VarChar, 50);
				sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtFormerSchool.Text.Trim());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@StudyStatus", SqlDbType.VarChar, 1);
				sqlParameter.Value = lblStudyStatus.Text.Trim();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@BursaryStatus", SqlDbType.Bit);
				sqlParameter.Value = Convert.ToBoolean(chkBursaryStatus.EditValue);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@RequiredFees", SqlDbType.Money);
				sqlParameter.Value = result.ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@BursaryProvider", SqlDbType.VarChar, 50);
				sqlParameter.Value = bursaryProvider;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@AdmissionDate", SqlDbType.VarChar, 4);
				sqlParameter.Value = admissionYear.ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Sex", SqlDbType.VarChar, 1);
				sqlParameter.Value = cboSex.SelectedItem;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Picture", SqlDbType.Image);
				sqlParameter.Value = array2;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Religion", SqlDbType.VarChar, 15);
				sqlParameter.Value = cboReligion.SelectedItem;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@HomeCountry", SqlDbType.VarChar, 15);
				sqlParameter.Value = cboNationality.SelectedItem;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Notes", SqlDbType.VarChar);
				sqlParameter.Value = txtNotes.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar, 20);
				sqlParameter.Value = cboStatus.SelectedItem.ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fullName", SqlDbType.VarChar, 50);
				sqlParameter.Value = txtFullName.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Comb", SqlDbType.VarChar, 12);
				sqlParameter.Value = combShort;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@SubjectString", SqlDbType.VarChar, 50);
				sqlParameter.Value = combFull;
				sqlParameter.Direction = ParameterDirection.Input;
				double result2 = (double.TryParse(txtFeesDiscount.Text, out result2) ? result2 : 0.0);
				sqlParameter = sqlCommand.Parameters.Add("@FeesDiscount", SqlDbType.Money);
				sqlParameter.Value = result2;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fName", SqlDbType.VarChar, 50);
				sqlParameter.Value = fName;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fAddress", SqlDbType.VarChar, 50);
				sqlParameter.Value = fAddress;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fContact", SqlDbType.VarChar, 10);
				sqlParameter.Value = fContact;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fEmail", SqlDbType.VarChar, 50);
				sqlParameter.Value = fEmail;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mName", SqlDbType.VarChar, 50);
				sqlParameter.Value = mName;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mAddress", SqlDbType.VarChar, 50);
				sqlParameter.Value = mAddress;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mContact", SqlDbType.VarChar, 10);
				sqlParameter.Value = mContact;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mEmail", SqlDbType.VarChar, 50);
				sqlParameter.Value = mEmail;
				sqlParameter.Direction = ParameterDirection.Input;
				DateTime result3 = (DateTime.TryParse(dtDOB.Text.ToString(), out result3) ? result3 : DateTime.Now);
				sqlParameter = sqlCommand.Parameters.Add("@DOB", SqlDbType.DateTime);
				sqlParameter.Value = result3;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@IsTheologyStud", SqlDbType.Bit);
				sqlParameter.Value = Convert.ToBoolean(chkTheologyStudent.EditValue);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@PrimaryScores1", SqlDbType.VarChar, 50);
				sqlParameter.Value = txtResults.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Guardian", SqlDbType.VarChar, 50);
				sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtGuardian.Text.Trim());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@PriorityContact", SqlDbType.VarChar, 11);
				sqlParameter.Value = txtGuardianContact.Text.Trim();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@OtherContact", SqlDbType.VarChar, 11);
				sqlParameter.Value = txtOtherContact.Text.Trim();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@GuardianAddress", SqlDbType.VarChar, 50);
				sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtGurdianAddress.Text.Trim());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fNIN", SqlDbType.NVarChar, 100);
				sqlParameter.Value = fNin;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mNIN", SqlDbType.VarChar, 100);
				sqlParameter.Value = mNin;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@sNIN", SqlDbType.NVarChar, 100);
				sqlParameter.Value = txtNIN.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@LIN", SqlDbType.NVarChar, 100);
				sqlParameter.Value = txtLIN.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@ReportCentre", SqlDbType.NVarChar, 100);
				sqlParameter.Value = txtReportCentre.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Cocurricular", SqlDbType.NVarChar, 100);
				sqlParameter.Value = txtGames.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@HealthStatus", SqlDbType.NVarChar, 100);
				sqlParameter.Value = txtHealthStatus.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@GuardianPic", SqlDbType.Image);
				sqlParameter.Value = array;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@GuardianRelation", SqlDbType.NVarChar, 100);
				sqlParameter.Value = cboNOKRelation.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			sqlConnection.Close();
			base.DialogResult = DialogResult.OK;
			Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void UpdateStudentByClass()
	{
		try
		{
			if (cboClass.SelectedItem.ToString() != "-N/A-")
			{
				UpdateStudent();
				if (SchoolInfoTemp.UseDashboard)
				{
					ClassChanged(cboClass.SelectedItem.ToString());
				}
			}
			else
			{
				if (!(cboClass.SelectedItem.ToString() == "-N/A-"))
				{
					return;
				}
				if (cboBursaryProvider.Enabled)
				{
					bursaryProvider = cboBursaryProvider.SelectedItem.ToString();
				}
				else
				{
					bursaryProvider = string.Empty;
				}
				double result = (double.TryParse(txtRequiredFees.Text, out result) ? result : 0.0);
				Image image = null;
				image = ((picStudent.Image != null) ? picStudent.Image : Resources.Default);
				int num = image.Height;
				int num2 = image.Width;
				num = num * 409 / num2;
				num2 = 409;
				if (num > 376)
				{
					num2 = num2 * 376 / num;
					num = 376;
				}
				Bitmap bitmap = new Bitmap(image, num2, num);
				MemoryStream memoryStream = new MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Png);
				memoryStream.Position = 0L;
				byte[] array = new byte[memoryStream.Length + 1];
				memoryStream.Read(array, 0, array.Length);
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				transaction = sqlConnection.BeginTransaction();
				string g = txtUniqueGuid.Text;
				Guid guid = new Guid(g);
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Transaction = transaction,
					Connection = sqlConnection,
					CommandText = "INSERT INTO tbl_suspendedStudents (ClassId,StudentNumber,HouseId,StreamId,Oid,FormerSchool,StudyStatus,BursaryStatus,RequiredFees,BursaryProvider,AdmissionDate,Sex,Picture,Religion,HomeCountry,fullName,Status,Notes,cashOnAccount,FeesDiscount,fName,fContact,fAddress,fEmail,mName,mContact,mAddress,mEmail,DOB,IsTheologyStud,PrimaryScores1,SubjectString,StudentID,mNIN,fNIN,LIN,ReportCentre,Cocurricular,HealthStatus,sNIN,GuardianRelation,GuardianPic) VALUES (@ClassId,@StudentNumber,@HouseId,@StreamId,@Oid,@FormerSchool,@StudyStatus,@BursaryStatus,@RequiredFees,@BursaryProvider,@AdmissionDate,@Sex,@Picture,@Religion,@HomeCountry,@fullName,@Status,@Notes,@cashOnAccount,@FeesDiscount,@fName,@fContact,@fAddress,@fEmail,@mName,@mContact,@mAddress,@mEmail,@DOB,@IsTheologyStud,@PrimaryScores1,@SubjectString,@StudentID,@mNIN,@fNIN,@LIN,@ReportCentre,@Cocurricular,@HealthStatus,@sNIN,@GuardianRelation,@GuardianPic)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
					sqlParameter.Value = txtStudentNumber.Text.Trim().ToUpper();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@StudentID", SqlDbType.VarChar, 12);
					sqlParameter.Value = txtIDNumber.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@HouseId", SqlDbType.VarChar, 25);
					sqlParameter.Value = cboHall.SelectedItem.ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 25);
					sqlParameter.Value = _class;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@StreamId", SqlDbType.VarChar, 10);
					sqlParameter.Value = cboStream.SelectedItem;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Oid", SqlDbType.UniqueIdentifier);
					sqlParameter.Value = guid;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@FormerSchool", SqlDbType.VarChar, 50);
					sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtFormerSchool.Text.Trim());
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@StudyStatus", SqlDbType.VarChar, 1);
					sqlParameter.Value = lblStudyStatus.Text.Trim();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@BursaryStatus", SqlDbType.Bit);
					sqlParameter.Value = Convert.ToBoolean(chkBursaryStatus.EditValue);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@RequiredFees", SqlDbType.Money);
					sqlParameter.Value = result.ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@BursaryProvider", SqlDbType.VarChar, 50);
					sqlParameter.Value = bursaryProvider;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@AdmissionDate", SqlDbType.VarChar, 4);
					sqlParameter.Value = admissionYear.ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Sex", SqlDbType.VarChar, 1);
					sqlParameter.Value = cboSex.SelectedItem;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Picture", SqlDbType.Image);
					sqlParameter.Value = array;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Religion", SqlDbType.VarChar, 15);
					sqlParameter.Value = cboReligion.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@HomeCountry", SqlDbType.VarChar, 15);
					sqlParameter.Value = cboNationality.SelectedItem;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@fullName", SqlDbType.VarChar, 50);
					sqlParameter.Value = txtFullName.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Notes", SqlDbType.VarChar);
					sqlParameter.Value = txtNotes.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar, 15);
					sqlParameter.Value = cboStatus.SelectedItem.ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@cashOnAccount", SqlDbType.Money);
					sqlParameter.Value = 0;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Comb", SqlDbType.VarChar, 12);
					sqlParameter.Value = combShort;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@SubjectString", SqlDbType.VarChar, 50);
					sqlParameter.Value = combFull;
					sqlParameter.Direction = ParameterDirection.Input;
					double result2 = (double.TryParse(txtFeesDiscount.Text, out result2) ? result2 : 0.0);
					sqlParameter = sqlCommand.Parameters.Add("@FeesDiscount", SqlDbType.Money);
					sqlParameter.Value = result2;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@fName", SqlDbType.VarChar, 50);
					sqlParameter.Value = fName;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@fAddress", SqlDbType.VarChar, 50);
					sqlParameter.Value = fAddress;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@fContact", SqlDbType.VarChar, 10);
					sqlParameter.Value = fContact;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@fEmail", SqlDbType.VarChar, 50);
					sqlParameter.Value = fEmail;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@mName", SqlDbType.VarChar, 50);
					sqlParameter.Value = mName;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@mAddress", SqlDbType.VarChar, 50);
					sqlParameter.Value = mAddress;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@mContact", SqlDbType.VarChar, 10);
					sqlParameter.Value = mContact;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@mEmail", SqlDbType.VarChar, 50);
					sqlParameter.Value = mEmail;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@mNIN", SqlDbType.VarChar, 50);
					sqlParameter.Value = mNin;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@fNIN", SqlDbType.VarChar, 50);
					sqlParameter.Value = fNin;
					sqlParameter.Direction = ParameterDirection.Input;
					DateTime result3 = (DateTime.TryParse(dtDOB.Text.ToString(), out result3) ? result3 : DateTime.Now);
					sqlParameter = sqlCommand.Parameters.Add("@DOB", SqlDbType.DateTime);
					sqlParameter.Value = result3;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@IsTheologyStud", SqlDbType.Bit);
					sqlParameter.Value = Convert.ToBoolean(chkTheologyStudent.EditValue);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@PrimaryScores1", SqlDbType.VarChar, 50);
					sqlParameter.Value = txtResults.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@sNIN", SqlDbType.NVarChar, 100);
					sqlParameter.Value = txtNIN.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@LIN", SqlDbType.NVarChar, 100);
					sqlParameter.Value = txtLIN.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@ReportCentre", SqlDbType.NVarChar, 100);
					sqlParameter.Value = txtReportCentre.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Cocurricular", SqlDbType.NVarChar, 100);
					sqlParameter.Value = txtGames.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@HealthStatus", SqlDbType.NVarChar, 100);
					sqlParameter.Value = txtHealthStatus.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@GuardianPic", SqlDbType.Image);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@GuardianRelation", SqlDbType.NVarChar, 100);
					sqlParameter.Value = cboNOKRelation.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Transaction = transaction,
					Connection = sqlConnection,
					CommandText = "DELETE FROM tbl_Scores_OL_Report WHERE StudentNumber=@StudentNumber",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
					sqlParameter2.Value = txtStudentNumber.Text.Trim().ToUpper();
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand3 = new SqlCommand
				{
					Transaction = transaction,
					Connection = sqlConnection,
					CommandText = "DELETE FROM tbl_Stud WHERE StudentNumber=@StudentNumber",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
					sqlParameter3.Value = txtStudentNumber.Text.Trim().ToUpper();
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlCommand3.ExecuteNonQuery();
				}
				if (_class != "S.1" && _class != "S.2" && _class != "S.3" && _class != "S.4")
				{
					using (SqlCommand sqlCommand4 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = $"DELETE FROM {SchoolSettings.ScoresTableSource(_class)} WHERE StudentNumber=@StudentNumber",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter4 = sqlCommand4.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter4.Value = txtStudentNumber.Text.Trim().ToUpper();
						sqlParameter4.Direction = ParameterDirection.Input;
						sqlCommand4.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand5 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = $"DELETE FROM {SchoolSettings.GeneralReportTableSource(_class)} WHERE StudentNumber=@StudentNumber",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter5 = sqlCommand5.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter5.Value = txtStudentNumber.Text.Trim().ToUpper();
						sqlParameter5.Direction = ParameterDirection.Input;
						sqlCommand5.ExecuteNonQuery();
					}
					using SqlCommand sqlCommand6 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection,
						CommandText = $"DELETE FROM {SchoolSettings.GeneralReportGradingTableSource(_class)} WHERE StudentNumber=@StudentNumber",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter6 = sqlCommand6.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
					sqlParameter6.Value = txtStudentNumber.Text.Trim().ToUpper();
					sqlParameter6.Direction = ParameterDirection.Input;
					sqlCommand6.ExecuteNonQuery();
				}
				transaction.Commit();
				sqlConnection.Close();
				if (SchoolInfoTemp.UseDashboard)
				{
					ClassChanged(cboClass.SelectedItem.ToString());
				}
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
			transaction.Rollback();
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		if (Text == "Add New Student")
		{
			while (dxValidateInsert.Validate())
			{
				if (dxValidateInsert.GetInvalidControls().Count == 0)
				{
					if (chkBursaryStatus.Checked && cboBursaryProvider.SelectedIndex <= 1)
					{
						XtraMessageBox.Show("Please select a Bursary Provide for this student.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else if (StudentNumber.StudentIDExists(txtIDNumber.Text))
					{
						XtraMessageBox.Show("The Id Number you provided already exists", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						txtIDNumber.Focus();
					}
					else
					{
						AdmitStudent();
					}
					break;
				}
			}
		}
		else
		{
			if (!(Text == "Edit Student details"))
			{
				return;
			}
			while (dxValidateUpdate.Validate())
			{
				if (dxValidateUpdate.GetInvalidControls().Count != 0)
				{
					continue;
				}
				if (chkBursaryStatus.Checked && cboBursaryProvider.SelectedIndex <= 1)
				{
					XtraMessageBox.Show("Please select a Bursary Provider for this student.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					break;
				}
				if (cboClass.Text == _class)
				{
					UpdateStudent();
					break;
				}
				DialogResult dialogResult = XtraMessageBox.Show("Changing the student's class will automatically detete all registered subjects for this student.\nAre you sure you want to continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Yes)
				{
					UpdateStudentByClass();
				}
				break;
			}
		}
	}

	private void editStudents_Load(object sender, EventArgs e)
	{
		LoadHouses();
		Classes.LoadComboWithClasses(new ComboBoxEdit[1] { cboClass });
		LoadBursaryProviders();
		if (EditMode)
		{
			FindStudent(StudentOptions.ActiveStudent());
			lblSelectedIndex.Text = cboClass.SelectedIndex.ToString();
			simpleButton3.Visible = true;
			txtGuardianContact.ReadOnly = !CurrentUser.CanEditContact;
			txtOtherContact.ReadOnly = !CurrentUser.CanEditContact;
		}
		else if (!EditMode)
		{
			txtIDNumber.Text = StudentNumber.GetNextStudentNumber()[1];
		}
	}

	private void txtStudentNumber_TextChanged(object sender, EventArgs e)
	{
		if (Text == "Add New Student")
		{
			dxValidateInsert.RemoveControlError(txtStudentNumber);
		}
	}

	private void cboSex_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!EditMode)
		{
			dxValidateInsert.RemoveControlError(cboSex);
		}
		else if (EditMode)
		{
			dxValidateUpdate.RemoveControlError(cboSex);
		}
	}

	private void cboReligion_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!EditMode)
		{
			dxValidateInsert.RemoveControlError(cboReligion);
		}
		else if (EditMode)
		{
			dxValidateUpdate.RemoveControlError(cboReligion);
		}
	}

	private void cboBursaryProvider_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cboBursaryProvider.SelectedIndex != 1)
		{
			return;
		}
		using DiscountsAllowed discountsAllowed = new DiscountsAllowed("SubCreation");
		if (discountsAllowed.ShowDialog() == DialogResult.OK)
		{
			LoadBursaryProviders();
			cboBursaryProvider.SelectedIndex = 0;
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void editStudents_FormClosed(object sender, FormClosedEventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void cboClass_Closed(object sender, ClosedEventArgs e)
	{
		if (Text == "Add New Student")
		{
			dxValidateInsert.RemoveControlError(cboClass);
		}
		txtRequiredFees.Text = FeesStructure(lblStudyStatus.Text).ToString();
		Stream.LoadStreams(cboClass.SelectedItem.ToString(), cboStream);
	}

	private void editStudents_KeyDown(object sender, KeyEventArgs e)
	{
		try
		{
			if (e.Alt && e.KeyCode == Keys.L)
			{
				LoadImage();
			}
			else
			{
				if (!e.Alt || e.KeyCode != Keys.C)
				{
					return;
				}
				picStudent.Image = null;
				picStudent.Image = Resources.Default;
				using CameraCapture cameraCapture = new CameraCapture();
				if (cameraCapture.ShowDialog() == DialogResult.OK)
				{
					picStudent.Image = cameraCapture.GetCroppedImage();
				}
				return;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void cboStream_QueryPopUp(object sender, CancelEventArgs e)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(connectionString);
			string selectCommandText = $"SELECT * from Streams WHERE ClassId='{cboClass.SelectedItem}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Streams");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count == 0)
			{
				cboStream.Properties.Items.Clear();
				cboStream.Properties.Items.Add("-");
				cboStream.SelectedIndex = 0;
				return;
			}
			cboStream.Properties.Items.Clear();
			foreach (DataRow row in dataTable.Rows)
			{
				cboStream.Properties.Items.Add(row["StreamId"]);
			}
			cboStream.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void LoadCombinations()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_SubjectCombinations", connectionString);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Combs");
			cboCombination.Properties.DataSource = dataSet.Tables[0].DefaultView;
			cboCombination.Properties.DisplayMember = "combFull";
			cboCombination.Properties.ValueMember = "combID";
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void txtFullName_TextChanged(object sender, EventArgs e)
	{
		if (!EditMode)
		{
			dxValidateInsert.RemoveControlError(txtFullName);
		}
		else if (EditMode)
		{
			dxValidateUpdate.RemoveControlError(txtFullName);
		}
	}

	private void chkBursaryStatus_CheckedChanged(object sender, EventArgs e)
	{
		if (chkBursaryStatus.Checked)
		{
			cboBursaryProvider.Properties.ReadOnly = false;
			txtFeesDiscount.Properties.ReadOnly = false;
			txtFeesDiscount.Enabled = true;
		}
		else
		{
			cboBursaryProvider.Properties.ReadOnly = true;
			txtFeesDiscount.Properties.ReadOnly = true;
			txtFeesDiscount.Text = string.Empty;
			txtFeesDiscount.Enabled = false;
		}
	}

	private void simpleButton5_Click(object sender, EventArgs e)
	{
		using ParentInfo parentInfo = new ParentInfo(fName, fContact, fAddress, fEmail, mName, mContact, mAddress, mEmail, fNin, mNin);
		if (parentInfo.ShowDialog() == DialogResult.OK)
		{
			fName = parentInfo.FName;
			fAddress = parentInfo.FAddress;
			fEmail = parentInfo.FEmail;
			fContact = parentInfo.FContact;
			mName = parentInfo.MName;
			mAddress = parentInfo.MAddress;
			mEmail = parentInfo.MEmail;
			mContact = parentInfo.MContact;
			fNin = parentInfo.F_NIN;
			mNin = parentInfo.M_NIN;
		}
	}

	private void cboHall_Closed(object sender, ClosedEventArgs e)
	{
		if (cboHall.SelectedIndex != 1)
		{
			return;
		}
		using AddHouse addHouse = new AddHouse();
		if (addHouse.ShowDialog() == DialogResult.OK)
		{
			LoadHouses();
		}
	}

	private void cboBursaryProvider_Closed(object sender, ClosedEventArgs e)
	{
		if (Text == "Add New Student" && cboBursaryProvider.SelectedIndex > 1)
		{
			DataRow dataRow = _dt.Rows[cboBursaryProvider.SelectedIndex - 2];
			double result = (double.TryParse(dataRow["DiscountValue"].ToString(), out result) ? result : 0.0);
			txtFeesDiscount.Text = result.ToString("#,#.0");
		}
	}

	private void cboClass_EditValueChanged(object sender, EventArgs e)
	{
		if (cboClass.EditValue == null)
		{
			return;
		}
		string text = cboClass.EditValue.ToString();
		switch (text)
		{
		default:
			if (!(text == "S.4"))
			{
				if (text == "S.5" || text == "S.6")
				{
					lblResultsLabel.Visible = true;
					txtResults.Visible = true;
					lblResultsLabel.Text = "UCE Results";
					LoadCombinations();
				}
				else
				{
					lblResultsLabel.Visible = false;
					txtResults.Visible = false;
					cboCombination.Properties.DataSource = null;
				}
				break;
			}
			goto case "S.1";
		case "S.1":
		case "S.2":
		case "S.3":
			lblResultsLabel.Visible = true;
			txtResults.Visible = true;
			lblResultsLabel.Text = "PLE Results";
			cboCombination.Properties.DataSource = null;
			break;
		}
	}

	private void cboCombination_EditValueChanged(object sender, EventArgs e)
	{
		if (cboCombination.EditValue != null)
		{
			combFull = cboCombination.Properties.GetDataSourceValue("combFull", cboCombination.ItemIndex).ToString();
			combShort = cboCombination.Properties.GetDataSourceValue("combShort", cboCombination.ItemIndex).ToString();
		}
	}

	private void txtReportCentre_EditValueChanged(object sender, EventArgs e)
	{
		if (txtReportCentre.EditValue.ToString() == "-Add New-")
		{
			NewReportCentre newReportCentre = new NewReportCentre();
			if (newReportCentre.ShowDialog() == DialogResult.OK)
			{
				GetReportCentres();
			}
		}
	}

	private void picStudent_MouseClick(object sender, MouseEventArgs e)
	{
		if (e.Button != MouseButtons.Right)
		{
			return;
		}
		try
		{
			picStudent.Image = null;
			picStudent.Image = Resources.Default;
			using CameraCapture cameraCapture = new CameraCapture();
			if (cameraCapture.ShowDialog() == DialogResult.OK)
			{
				picStudent.Image = cameraCapture.GetCroppedImage();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void picStudent_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		LoadImage();
	}

	private void picGuardianPhoto_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		try
		{
			string text = null;
			using OpenFileDialog openFileDialog = new OpenFileDialog
			{
				RestoreDirectory = true,
				Title = "Open Guardian's photo",
				Filter = "jpg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|png files (*.png)|*.png|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				text = openFileDialog.FileName;
				picGuardianPhoto.Image = Image.FromFile(text);
				picGuardianPhoto.Image = Image.FromFile(text);
			}
		}
		catch (ArgumentException ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
		catch (Exception ex2)
		{
			XtraMessageBox.Show(ex2.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton3_Click(object sender, EventArgs e)
	{
		FingerPrintTasks fingerPrintTasks = new FingerPrintTasks(txtStudentNumber.Text);
		fingerPrintTasks.ShowDialog();
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
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule5 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule6 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule7 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule8 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.Utils.SuperToolTip superToolTip = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
		this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
		this.txtFeesDiscount = new DevExpress.XtraEditors.TextEdit();
		this.chkBursaryStatus = new DevExpress.XtraEditors.CheckEdit();
		this.radioGroupStudyStatus = new DevExpress.XtraEditors.RadioGroup();
		this.cboStream = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtRequiredFees = new DevExpress.XtraEditors.TextEdit();
		this.txtNotes = new DevExpress.XtraEditors.MemoEdit();
		this.cboBursaryProvider = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboClass = new DevExpress.XtraEditors.ComboBoxEdit();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.txtGuardianContact = new DevExpress.XtraEditors.TextEdit();
		this.cboReligion = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboHall = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboNationality = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtFormerSchool = new DevExpress.XtraEditors.TextEdit();
		this.cboSex = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtGurdianAddress = new DevExpress.XtraEditors.TextEdit();
		this.txtGuardian = new DevExpress.XtraEditors.TextEdit();
		this.txtFullName = new DevExpress.XtraEditors.TextEdit();
		this.txtStudentNumber = new DevExpress.XtraEditors.TextEdit();
		this.dtDOB = new DevExpress.XtraEditors.DateEdit();
		this.lblStudyStatus = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.lblCurrentClass = new DevExpress.XtraEditors.LabelControl();
		this.txtUniqueGuid = new DevExpress.XtraEditors.TextEdit();
		this.dxValidateInsert = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		this.txtIDNumber = new DevExpress.XtraEditors.TextEdit();
		this.txtNIN = new DevExpress.XtraEditors.TextEdit();
		this.txtLIN = new DevExpress.XtraEditors.TextEdit();
		this.dxValidateUpdate = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		this.lblSelectedIndex = new DevExpress.XtraEditors.LabelControl();
		this.lblGuardianId = new DevExpress.XtraEditors.LabelControl();
		this.picStudent = new DevExpress.XtraEditors.PictureEdit();
		this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
		this.txtResults = new DevExpress.XtraEditors.TextEdit();
		this.lblResultsLabel = new DevExpress.XtraEditors.LabelControl();
		this.chkTheologyStudent = new DevExpress.XtraEditors.CheckEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.txtOtherContact = new DevExpress.XtraEditors.TextEdit();
		this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
		this.cboCombination = new DevExpress.XtraEditors.LookUpEdit();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
		this.txtHealthStatus = new DevExpress.XtraEditors.TextEdit();
		this.labelControl26 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
		this.cboNOKRelation = new DevExpress.XtraEditors.ComboBoxEdit();
		this.labelControl28 = new DevExpress.XtraEditors.LabelControl();
		this.txtGames = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtReportCentre = new DevExpress.XtraEditors.ComboBoxEdit();
		this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
		this.picGuardianPhoto = new DevExpress.XtraEditors.PictureEdit();
		this.adornerUIManager1 = new DevExpress.Utils.VisualEffects.AdornerUIManager(this.components);
		this.badge1 = new DevExpress.Utils.VisualEffects.Badge();
		this.badge2 = new DevExpress.Utils.VisualEffects.Badge();
		this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
		((System.ComponentModel.ISupportInitialize)this.txtFeesDiscount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkBursaryStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.radioGroupStudyStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtRequiredFees.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtNotes.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboBursaryProvider.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtGuardianContact.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboReligion.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboHall.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboNationality.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtFormerSchool.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSex.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtGurdianAddress.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtGuardian.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtFullName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNumber.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtDOB.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtDOB.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtUniqueGuid.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidateInsert).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtIDNumber.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtNIN.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtLIN.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidateUpdate).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picStudent.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtResults.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkTheologyStudent.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtOtherContact.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboCombination.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtHealthStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboNOKRelation.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtGames.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReportCentre.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.behaviorManager1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picGuardianPhoto.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.adornerUIManager1).BeginInit();
		base.SuspendLayout();
		this.simpleButton5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.simpleButton5.Appearance.Options.UseFont = true;
		this.simpleButton5.Location = new System.Drawing.Point(511, 397);
		this.simpleButton5.Margin = new System.Windows.Forms.Padding(2);
		this.simpleButton5.Name = "simpleButton5";
		this.simpleButton5.Size = new System.Drawing.Size(153, 22);
		this.simpleButton5.TabIndex = 31;
		this.simpleButton5.Text = "Parent Information...";
		this.simpleButton5.Click += new System.EventHandler(simpleButton5_Click);
		this.txtFeesDiscount.Location = new System.Drawing.Point(357, 453);
		this.txtFeesDiscount.Margin = new System.Windows.Forms.Padding(2);
		this.txtFeesDiscount.Name = "txtFeesDiscount";
		this.txtFeesDiscount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtFeesDiscount.Properties.Mask.EditMask = "n0";
		this.txtFeesDiscount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtFeesDiscount.Properties.ReadOnly = true;
		this.txtFeesDiscount.Size = new System.Drawing.Size(145, 22);
		this.txtFeesDiscount.TabIndex = 28;
		this.chkBursaryStatus.Location = new System.Drawing.Point(134, 400);
		this.chkBursaryStatus.Margin = new System.Windows.Forms.Padding(2);
		this.chkBursaryStatus.Name = "chkBursaryStatus";
		this.chkBursaryStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.chkBursaryStatus.Properties.Appearance.Options.UseFont = true;
		this.chkBursaryStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.chkBursaryStatus.Properties.Caption = "This student is on bursary scheme";
		this.chkBursaryStatus.Size = new System.Drawing.Size(367, 23);
		this.chkBursaryStatus.TabIndex = 26;
		this.chkBursaryStatus.CheckedChanged += new System.EventHandler(chkBursaryStatus_CheckedChanged);
		this.radioGroupStudyStatus.EnterMoveNextControl = true;
		this.radioGroupStudyStatus.Location = new System.Drawing.Point(134, 332);
		this.radioGroupStudyStatus.Margin = new System.Windows.Forms.Padding(2);
		this.radioGroupStudyStatus.Name = "radioGroupStudyStatus";
		this.radioGroupStudyStatus.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroupStudyStatus.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroupStudyStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.radioGroupStudyStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Border"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Day")
		});
		this.radioGroupStudyStatus.Size = new System.Drawing.Size(367, 34);
		this.radioGroupStudyStatus.TabIndex = 23;
		this.radioGroupStudyStatus.SelectedIndexChanged += new System.EventHandler(radioGroupStudyStatus_SelectedIndexChanged);
		this.cboStream.EnterMoveNextControl = true;
		this.cboStream.Location = new System.Drawing.Point(134, 308);
		this.cboStream.Margin = new System.Windows.Forms.Padding(2);
		this.cboStream.Name = "cboStream";
		this.cboStream.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboStream.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboStream.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboStream.Size = new System.Drawing.Size(145, 22);
		this.cboStream.TabIndex = 21;
		this.cboStream.QueryPopUp += new System.ComponentModel.CancelEventHandler(cboStream_QueryPopUp);
		this.cboStatus.EditValue = "Active";
		this.cboStatus.EnterMoveNextControl = true;
		this.cboStatus.Location = new System.Drawing.Point(357, 308);
		this.cboStatus.Margin = new System.Windows.Forms.Padding(2);
		this.cboStatus.Name = "cboStatus";
		this.cboStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboStatus.Properties.Items.AddRange(new object[4] { "Active", "Suspended", "Discontinued", "Dropped Out" });
		this.cboStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboStatus.Size = new System.Drawing.Size(145, 22);
		this.cboStatus.TabIndex = 22;
		this.txtRequiredFees.Enabled = false;
		this.txtRequiredFees.EnterMoveNextControl = true;
		this.txtRequiredFees.Location = new System.Drawing.Point(134, 453);
		this.txtRequiredFees.Margin = new System.Windows.Forms.Padding(2);
		this.txtRequiredFees.Name = "txtRequiredFees";
		this.txtRequiredFees.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtRequiredFees.Properties.Mask.EditMask = "n0";
		this.txtRequiredFees.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtRequiredFees.Properties.ReadOnly = true;
		this.txtRequiredFees.Size = new System.Drawing.Size(145, 22);
		this.txtRequiredFees.TabIndex = 17;
		this.txtRequiredFees.TabStop = false;
		this.txtNotes.Location = new System.Drawing.Point(513, 373);
		this.txtNotes.Name = "txtNotes";
		this.txtNotes.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtNotes.Properties.MaxLength = 300;
		this.txtNotes.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtNotes.Size = new System.Drawing.Size(151, 16);
		this.txtNotes.TabIndex = 19;
		this.txtNotes.Visible = false;
		this.cboBursaryProvider.EnterMoveNextControl = true;
		this.cboBursaryProvider.Location = new System.Drawing.Point(134, 428);
		this.cboBursaryProvider.Margin = new System.Windows.Forms.Padding(2);
		this.cboBursaryProvider.Name = "cboBursaryProvider";
		this.cboBursaryProvider.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboBursaryProvider.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboBursaryProvider.Properties.ReadOnly = true;
		this.cboBursaryProvider.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboBursaryProvider.Size = new System.Drawing.Size(367, 22);
		this.cboBursaryProvider.TabIndex = 27;
		this.cboBursaryProvider.SelectedIndexChanged += new System.EventHandler(cboBursaryProvider_SelectedIndexChanged);
		this.cboBursaryProvider.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboBursaryProvider_Closed);
		this.cboClass.EnterMoveNextControl = true;
		this.dxValidateUpdate.SetIconAlignment(this.cboClass, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.dxValidateInsert.SetIconAlignment(this.cboClass, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.cboClass.Location = new System.Drawing.Point(134, 285);
		this.cboClass.Margin = new System.Windows.Forms.Padding(2);
		this.cboClass.Name = "cboClass";
		this.cboClass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboClass.Size = new System.Drawing.Size(145, 22);
		this.cboClass.TabIndex = 19;
		conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
		conditionValidationRule.ErrorText = "This value is not valid";
		conditionValidationRule.Value1 = "N/A";
		this.dxValidateInsert.SetValidationRule(this.cboClass, conditionValidationRule);
		this.cboClass.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboClass_Closed);
		this.cboClass.EditValueChanged += new System.EventHandler(cboClass_EditValueChanged);
		this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl4.Appearance.Options.UseFont = true;
		this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.labelControl4.Location = new System.Drawing.Point(7, 267);
		this.labelControl4.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(449, 14);
		this.labelControl4.TabIndex = 14;
		this.labelControl4.Text = "Fees and Study Information";
		this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl3.Appearance.Options.UseFont = true;
		this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.labelControl3.Location = new System.Drawing.Point(7, 176);
		this.labelControl3.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(123, 14);
		this.labelControl3.TabIndex = 13;
		this.labelControl3.Text = "Guardian Information";
		this.txtGuardianContact.EnterMoveNextControl = true;
		this.txtGuardianContact.Location = new System.Drawing.Point(356, 194);
		this.txtGuardianContact.Margin = new System.Windows.Forms.Padding(2);
		this.txtGuardianContact.Name = "txtGuardianContact";
		this.txtGuardianContact.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtGuardianContact.Properties.MaxLength = 10;
		this.txtGuardianContact.Size = new System.Drawing.Size(145, 22);
		this.txtGuardianContact.TabIndex = 14;
		this.cboReligion.EditValue = "-Religion-";
		this.cboReligion.EnterMoveNextControl = true;
		this.dxValidateUpdate.SetIconAlignment(this.cboReligion, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.dxValidateInsert.SetIconAlignment(this.cboReligion, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.cboReligion.Location = new System.Drawing.Point(399, 80);
		this.cboReligion.Margin = new System.Windows.Forms.Padding(2);
		this.cboReligion.Name = "cboReligion";
		this.cboReligion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboReligion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboReligion.Properties.Items.AddRange(new object[7] { "-Religion-", "Catholic", "Moslem", "Anglican", "SDA", "Born-Again", "Others" });
		this.cboReligion.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboReligion.Size = new System.Drawing.Size(102, 22);
		this.cboReligion.TabIndex = 7;
		conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
		conditionValidationRule2.ErrorText = "This value is not valid";
		conditionValidationRule2.Value1 = "Religion";
		this.dxValidateUpdate.SetValidationRule(this.cboReligion, conditionValidationRule2);
		conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
		conditionValidationRule3.ErrorText = "This value is not valid";
		conditionValidationRule3.Value1 = "Religion";
		this.dxValidateInsert.SetValidationRule(this.cboReligion, conditionValidationRule3);
		this.cboReligion.SelectedIndexChanged += new System.EventHandler(cboReligion_SelectedIndexChanged);
		this.cboHall.EnterMoveNextControl = true;
		this.cboHall.Location = new System.Drawing.Point(334, 104);
		this.cboHall.Margin = new System.Windows.Forms.Padding(2);
		this.cboHall.Name = "cboHall";
		this.cboHall.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboHall.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboHall.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboHall.Size = new System.Drawing.Size(167, 22);
		this.cboHall.TabIndex = 9;
		this.cboHall.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboHall_Closed);
		this.cboNationality.EnterMoveNextControl = true;
		this.cboNationality.Location = new System.Drawing.Point(134, 104);
		this.cboNationality.Margin = new System.Windows.Forms.Padding(2);
		this.cboNationality.Name = "cboNationality";
		this.cboNationality.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboNationality.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboNationality.Properties.Items.AddRange(new object[53]
		{
			"Algeria", "Angola", "Benin", "Botswana", "Burkina Faso", "Burundi", "Cameroon", "Cape Verde", "Central African Republic", "Chad",
			"Comoros", "Cote d’lvoire", "Dem. Rep. of the Congo", "Djibouti", "Egypt", "Equatorial Guinea", "Eritrea", "Ethiopia", "Gabon", "Ghana",
			"Guinea", "Guinea-Bissau", "Kenya", "Lesotho", "Liberia", "Libya", "Madagascar", "Malawi", "Mali", "Mauritania",
			"Mauritius", "Morocco", "Mozambique", "Namibia", "Niger", "Nigeria", "Republic of Congo", "Rwanda", "Sao Tome and Principe", "Senegal",
			"Seychelles", "Sierra Leone", "Somalia", "South Africa", "Sudan", "Swaziland", "Tanzania", "The Gambia", "Togo", "Tunisia",
			"Uganda", "Zambia", "Zimbabwe"
		});
		this.cboNationality.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboNationality.Size = new System.Drawing.Size(161, 22);
		this.cboNationality.TabIndex = 8;
		this.txtFormerSchool.EnterMoveNextControl = true;
		this.txtFormerSchool.Location = new System.Drawing.Point(134, 128);
		this.txtFormerSchool.Margin = new System.Windows.Forms.Padding(2);
		this.txtFormerSchool.Name = "txtFormerSchool";
		this.txtFormerSchool.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtFormerSchool.Properties.MaxLength = 100;
		this.txtFormerSchool.Size = new System.Drawing.Size(367, 22);
		this.txtFormerSchool.TabIndex = 10;
		this.cboSex.EditValue = "-Sex-";
		this.cboSex.EnterMoveNextControl = true;
		this.dxValidateUpdate.SetIconAlignment(this.cboSex, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.dxValidateInsert.SetIconAlignment(this.cboSex, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.cboSex.Location = new System.Drawing.Point(282, 80);
		this.cboSex.Margin = new System.Windows.Forms.Padding(2);
		this.cboSex.Name = "cboSex";
		this.cboSex.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboSex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSex.Properties.Items.AddRange(new object[3] { "-Sex-", "Female", "Male" });
		this.cboSex.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboSex.Size = new System.Drawing.Size(71, 22);
		this.cboSex.TabIndex = 6;
		conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
		conditionValidationRule4.ErrorText = "This value is not valid";
		conditionValidationRule4.Value1 = "-Sex-";
		this.dxValidateUpdate.SetValidationRule(this.cboSex, conditionValidationRule4);
		conditionValidationRule5.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
		conditionValidationRule5.ErrorText = "This value is not valid";
		conditionValidationRule5.Value1 = "-Sex-";
		this.dxValidateInsert.SetValidationRule(this.cboSex, conditionValidationRule5);
		this.cboSex.SelectedIndexChanged += new System.EventHandler(cboSex_SelectedIndexChanged);
		this.txtGurdianAddress.EnterMoveNextControl = true;
		this.txtGurdianAddress.Location = new System.Drawing.Point(134, 217);
		this.txtGurdianAddress.Margin = new System.Windows.Forms.Padding(2);
		this.txtGurdianAddress.Name = "txtGurdianAddress";
		this.txtGurdianAddress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtGurdianAddress.Properties.MaxLength = 50;
		this.txtGurdianAddress.Size = new System.Drawing.Size(145, 22);
		this.txtGurdianAddress.TabIndex = 15;
		this.txtGuardian.EnterMoveNextControl = true;
		this.txtGuardian.Location = new System.Drawing.Point(134, 194);
		this.txtGuardian.Margin = new System.Windows.Forms.Padding(2);
		this.txtGuardian.Name = "txtGuardian";
		this.txtGuardian.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtGuardian.Properties.MaxLength = 50;
		this.txtGuardian.Size = new System.Drawing.Size(145, 22);
		this.txtGuardian.TabIndex = 13;
		this.txtFullName.EnterMoveNextControl = true;
		this.dxValidateInsert.SetIconAlignment(this.txtFullName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.dxValidateUpdate.SetIconAlignment(this.txtFullName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtFullName.Location = new System.Drawing.Point(134, 56);
		this.txtFullName.Margin = new System.Windows.Forms.Padding(2);
		this.txtFullName.Name = "txtFullName";
		this.txtFullName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtFullName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtFullName.Properties.MaxLength = 50;
		this.txtFullName.Size = new System.Drawing.Size(367, 22);
		this.txtFullName.TabIndex = 4;
		conditionValidationRule6.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule6.ErrorText = "This value is not valid";
		this.dxValidateUpdate.SetValidationRule(this.txtFullName, conditionValidationRule6);
		conditionValidationRule7.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule7.ErrorText = "This value is not valid";
		this.dxValidateInsert.SetValidationRule(this.txtFullName, conditionValidationRule7);
		this.txtFullName.TextChanged += new System.EventHandler(txtFullName_TextChanged);
		this.txtStudentNumber.EnterMoveNextControl = true;
		this.dxValidateInsert.SetIconAlignment(this.txtStudentNumber, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.dxValidateUpdate.SetIconAlignment(this.txtStudentNumber, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtStudentNumber.Location = new System.Drawing.Point(7, 77);
		this.txtStudentNumber.Margin = new System.Windows.Forms.Padding(2);
		this.txtStudentNumber.Name = "txtStudentNumber";
		this.txtStudentNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtStudentNumber.Properties.MaxLength = 12;
		this.txtStudentNumber.Properties.ReadOnly = true;
		this.txtStudentNumber.Size = new System.Drawing.Size(60, 22);
		this.txtStudentNumber.TabIndex = 0;
		this.txtStudentNumber.TabStop = false;
		this.txtStudentNumber.Visible = false;
		this.txtStudentNumber.TextChanged += new System.EventHandler(txtStudentNumber_TextChanged);
		this.dtDOB.EditValue = null;
		this.dtDOB.Location = new System.Drawing.Point(134, 80);
		this.dtDOB.Margin = new System.Windows.Forms.Padding(2);
		this.dtDOB.Name = "dtDOB";
		this.dtDOB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.dtDOB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtDOB.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtDOB.Properties.MaskSettings.Set("mask", "");
		this.dtDOB.Size = new System.Drawing.Size(102, 22);
		this.dtDOB.TabIndex = 5;
		this.lblStudyStatus.Location = new System.Drawing.Point(529, 240);
		this.lblStudyStatus.Name = "lblStudyStatus";
		this.lblStudyStatus.Size = new System.Drawing.Size(6, 13);
		this.lblStudyStatus.TabIndex = 10;
		this.lblStudyStatus.Text = "B";
		this.lblStudyStatus.Visible = false;
		this.simpleButton2.Location = new System.Drawing.Point(511, 423);
		this.simpleButton2.Margin = new System.Windows.Forms.Padding(2);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(153, 23);
		this.simpleButton2.TabIndex = 32;
		this.simpleButton2.Text = "Save";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.simpleButton1.Location = new System.Drawing.Point(511, 449);
		this.simpleButton1.Margin = new System.Windows.Forms.Padding(2);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(153, 23);
		this.simpleButton1.TabIndex = 33;
		this.simpleButton1.Text = "Close";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.lblCurrentClass.Location = new System.Drawing.Point(549, 235);
		this.lblCurrentClass.Name = "lblCurrentClass";
		this.lblCurrentClass.Size = new System.Drawing.Size(25, 13);
		this.lblCurrentClass.TabIndex = 17;
		this.lblCurrentClass.Text = "Class";
		this.lblCurrentClass.Visible = false;
		this.txtUniqueGuid.Location = new System.Drawing.Point(613, 258);
		this.txtUniqueGuid.Name = "txtUniqueGuid";
		this.txtUniqueGuid.Properties.ReadOnly = true;
		this.txtUniqueGuid.Size = new System.Drawing.Size(45, 20);
		this.txtUniqueGuid.TabIndex = 17;
		this.txtUniqueGuid.TabStop = false;
		this.txtUniqueGuid.Visible = false;
		this.txtIDNumber.EnterMoveNextControl = true;
		this.dxValidateInsert.SetIconAlignment(this.txtIDNumber, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.dxValidateUpdate.SetIconAlignment(this.txtIDNumber, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtIDNumber.Location = new System.Drawing.Point(134, 8);
		this.txtIDNumber.Margin = new System.Windows.Forms.Padding(2);
		this.txtIDNumber.Name = "txtIDNumber";
		this.txtIDNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtIDNumber.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtIDNumber.Properties.MaxLength = 12;
		this.txtIDNumber.Size = new System.Drawing.Size(165, 22);
		this.txtIDNumber.TabIndex = 0;
		conditionValidationRule8.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule8.ErrorText = "This value is not valid";
		this.dxValidateInsert.SetValidationRule(this.txtIDNumber, conditionValidationRule8);
		this.txtNIN.EnterMoveNextControl = true;
		this.dxValidateInsert.SetIconAlignment(this.txtNIN, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.dxValidateUpdate.SetIconAlignment(this.txtNIN, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtNIN.Location = new System.Drawing.Point(134, 32);
		this.txtNIN.Margin = new System.Windows.Forms.Padding(2);
		this.txtNIN.Name = "txtNIN";
		this.txtNIN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtNIN.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtNIN.Properties.MaxLength = 14;
		this.txtNIN.Size = new System.Drawing.Size(165, 22);
		this.txtNIN.TabIndex = 2;
		this.txtLIN.EnterMoveNextControl = true;
		this.dxValidateInsert.SetIconAlignment(this.txtLIN, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.dxValidateUpdate.SetIconAlignment(this.txtLIN, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtLIN.Location = new System.Drawing.Point(336, 8);
		this.txtLIN.Margin = new System.Windows.Forms.Padding(2);
		this.txtLIN.Name = "txtLIN";
		this.txtLIN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtLIN.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtLIN.Properties.MaxLength = 14;
		this.txtLIN.Size = new System.Drawing.Size(165, 22);
		this.txtLIN.TabIndex = 1;
		this.lblSelectedIndex.Location = new System.Drawing.Point(529, 263);
		this.lblSelectedIndex.Name = "lblSelectedIndex";
		this.lblSelectedIndex.Size = new System.Drawing.Size(63, 13);
		this.lblSelectedIndex.TabIndex = 23;
		this.lblSelectedIndex.Text = "labelControl1";
		this.lblSelectedIndex.Visible = false;
		this.lblGuardianId.Location = new System.Drawing.Point(529, 293);
		this.lblGuardianId.Name = "lblGuardianId";
		this.lblGuardianId.Size = new System.Drawing.Size(63, 13);
		this.lblGuardianId.TabIndex = 24;
		this.lblGuardianId.Text = "labelControl1";
		this.lblGuardianId.Visible = false;
		this.picStudent.Cursor = System.Windows.Forms.Cursors.Default;
		this.picStudent.Location = new System.Drawing.Point(510, 8);
		this.picStudent.Margin = new System.Windows.Forms.Padding(2);
		this.picStudent.Name = "picStudent";
		this.picStudent.Properties.ShowMenu = false;
		this.picStudent.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.picStudent.Size = new System.Drawing.Size(153, 157);
		toolTipTitleItem.Text = "Student's Photo";
		toolTipItem.Text = "Double-Click here to upload a photo or Right-Click to capture with camera";
		superToolTip.Items.Add(toolTipTitleItem);
		superToolTip.Items.Add(toolTipItem);
		this.picStudent.SuperTip = superToolTip;
		this.picStudent.TabIndex = 25;
		this.picStudent.MouseClick += new System.Windows.Forms.MouseEventHandler(picStudent_MouseClick);
		this.picStudent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(picStudent_MouseDoubleClick);
		this.labelControl5.Location = new System.Drawing.Point(100, 65);
		this.labelControl5.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl5.Name = "labelControl5";
		this.labelControl5.Size = new System.Drawing.Size(27, 13);
		this.labelControl5.TabIndex = 27;
		this.labelControl5.Text = "Name";
		this.labelControl6.Location = new System.Drawing.Point(241, 89);
		this.labelControl6.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl6.Name = "labelControl6";
		this.labelControl6.Size = new System.Drawing.Size(35, 13);
		this.labelControl6.TabIndex = 28;
		this.labelControl6.Text = "Gender";
		this.labelControl7.Location = new System.Drawing.Point(357, 89);
		this.labelControl7.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl7.Name = "labelControl7";
		this.labelControl7.Size = new System.Drawing.Size(37, 13);
		this.labelControl7.TabIndex = 29;
		this.labelControl7.Text = "Religion";
		this.labelControl8.Location = new System.Drawing.Point(299, 113);
		this.labelControl8.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl8.Name = "labelControl8";
		this.labelControl8.Size = new System.Drawing.Size(30, 13);
		this.labelControl8.TabIndex = 30;
		this.labelControl8.Text = "House";
		this.labelControl9.Location = new System.Drawing.Point(92, 116);
		this.labelControl9.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl9.Name = "labelControl9";
		this.labelControl9.Size = new System.Drawing.Size(39, 13);
		this.labelControl9.TabIndex = 31;
		this.labelControl9.Text = "Country";
		this.labelControl10.Location = new System.Drawing.Point(62, 137);
		this.labelControl10.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl10.Name = "labelControl10";
		this.labelControl10.Size = new System.Drawing.Size(67, 13);
		this.labelControl10.TabIndex = 32;
		this.labelControl10.Text = "Former school";
		this.labelControl11.Location = new System.Drawing.Point(105, 89);
		this.labelControl11.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl11.Name = "labelControl11";
		this.labelControl11.Size = new System.Drawing.Size(21, 13);
		this.labelControl11.TabIndex = 33;
		this.labelControl11.Text = "DOB";
		this.labelControl12.Location = new System.Drawing.Point(102, 203);
		this.labelControl12.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl12.Name = "labelControl12";
		this.labelControl12.Size = new System.Drawing.Size(27, 13);
		this.labelControl12.TabIndex = 34;
		this.labelControl12.Text = "Name";
		this.labelControl13.Location = new System.Drawing.Point(317, 203);
		this.labelControl13.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl13.Name = "labelControl13";
		this.labelControl13.Size = new System.Drawing.Size(38, 13);
		this.labelControl13.TabIndex = 35;
		this.labelControl13.Text = "Contact";
		this.labelControl14.Location = new System.Drawing.Point(91, 226);
		this.labelControl14.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl14.Name = "labelControl14";
		this.labelControl14.Size = new System.Drawing.Size(39, 13);
		this.labelControl14.TabIndex = 36;
		this.labelControl14.Text = "Address";
		this.labelControl15.Location = new System.Drawing.Point(71, 249);
		this.labelControl15.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl15.Name = "labelControl15";
		this.labelControl15.Size = new System.Drawing.Size(58, 13);
		this.labelControl15.TabIndex = 37;
		this.labelControl15.Text = "Relationship";
		this.labelControl16.Location = new System.Drawing.Point(105, 291);
		this.labelControl16.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl16.Name = "labelControl16";
		this.labelControl16.Size = new System.Drawing.Size(25, 13);
		this.labelControl16.TabIndex = 38;
		this.labelControl16.Text = "Class";
		this.labelControl17.Location = new System.Drawing.Point(96, 314);
		this.labelControl17.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl17.Name = "labelControl17";
		this.labelControl17.Size = new System.Drawing.Size(34, 13);
		this.labelControl17.TabIndex = 39;
		this.labelControl17.Text = "Stream";
		this.labelControl18.Location = new System.Drawing.Point(292, 291);
		this.labelControl18.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl18.Name = "labelControl18";
		this.labelControl18.Size = new System.Drawing.Size(59, 13);
		this.labelControl18.TabIndex = 40;
		this.labelControl18.Text = "Combination";
		this.labelControl19.Location = new System.Drawing.Point(105, 459);
		this.labelControl19.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl19.Name = "labelControl19";
		this.labelControl19.Size = new System.Drawing.Size(23, 13);
		this.labelControl19.TabIndex = 41;
		this.labelControl19.Text = "Fees";
		this.labelControl20.Location = new System.Drawing.Point(52, 434);
		this.labelControl20.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl20.Name = "labelControl20";
		this.labelControl20.Size = new System.Drawing.Size(80, 13);
		this.labelControl20.TabIndex = 42;
		this.labelControl20.Text = "Bursary provider";
		this.labelControl21.Location = new System.Drawing.Point(311, 459);
		this.labelControl21.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl21.Name = "labelControl21";
		this.labelControl21.Size = new System.Drawing.Size(41, 13);
		this.labelControl21.TabIndex = 43;
		this.labelControl21.Text = "Discount";
		this.labelControl23.Location = new System.Drawing.Point(72, 342);
		this.labelControl23.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl23.Name = "labelControl23";
		this.labelControl23.Size = new System.Drawing.Size(61, 13);
		this.labelControl23.TabIndex = 45;
		this.labelControl23.Text = "Study status";
		this.labelControl22.Location = new System.Drawing.Point(323, 314);
		this.labelControl22.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl22.Name = "labelControl22";
		this.labelControl22.Size = new System.Drawing.Size(31, 13);
		this.labelControl22.TabIndex = 46;
		this.labelControl22.Text = "Status";
		this.txtResults.EnterMoveNextControl = true;
		this.txtResults.Location = new System.Drawing.Point(134, 369);
		this.txtResults.Margin = new System.Windows.Forms.Padding(2);
		this.txtResults.Name = "txtResults";
		this.txtResults.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtResults.Size = new System.Drawing.Size(103, 22);
		this.txtResults.TabIndex = 24;
		this.lblResultsLabel.Appearance.Options.UseTextOptions = true;
		this.lblResultsLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.lblResultsLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblResultsLabel.Location = new System.Drawing.Point(8, 376);
		this.lblResultsLabel.Margin = new System.Windows.Forms.Padding(2);
		this.lblResultsLabel.Name = "lblResultsLabel";
		this.lblResultsLabel.Size = new System.Drawing.Size(121, 13);
		this.lblResultsLabel.TabIndex = 48;
		this.lblResultsLabel.Text = "PLE Resutls";
		this.chkTheologyStudent.Location = new System.Drawing.Point(249, 371);
		this.chkTheologyStudent.Margin = new System.Windows.Forms.Padding(2);
		this.chkTheologyStudent.Name = "chkTheologyStudent";
		this.chkTheologyStudent.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.chkTheologyStudent.Properties.Appearance.ForeColor = System.Drawing.Color.Green;
		this.chkTheologyStudent.Properties.Appearance.Options.UseFont = true;
		this.chkTheologyStudent.Properties.Appearance.Options.UseForeColor = true;
		this.chkTheologyStudent.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.chkTheologyStudent.Properties.Caption = "This is an Islamic Theology Student";
		this.chkTheologyStudent.Size = new System.Drawing.Size(253, 23);
		this.chkTheologyStudent.TabIndex = 25;
		this.labelControl1.Location = new System.Drawing.Point(79, 17);
		this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(50, 13);
		this.labelControl1.TabIndex = 51;
		this.labelControl1.Text = "Id Number";
		this.txtOtherContact.EnterMoveNextControl = true;
		this.txtOtherContact.Location = new System.Drawing.Point(356, 217);
		this.txtOtherContact.Margin = new System.Windows.Forms.Padding(2);
		this.txtOtherContact.Name = "txtOtherContact";
		this.txtOtherContact.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtOtherContact.Properties.MaxLength = 10;
		this.txtOtherContact.Size = new System.Drawing.Size(145, 22);
		this.txtOtherContact.TabIndex = 17;
		this.labelControl24.Location = new System.Drawing.Point(288, 226);
		this.labelControl24.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl24.Name = "labelControl24";
		this.labelControl24.Size = new System.Drawing.Size(69, 13);
		this.labelControl24.TabIndex = 53;
		this.labelControl24.Text = "Other Contact";
		this.cboCombination.Location = new System.Drawing.Point(357, 285);
		this.cboCombination.Margin = new System.Windows.Forms.Padding(2);
		this.cboCombination.Name = "cboCombination";
		this.cboCombination.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboCombination.Properties.Appearance.Options.UseFont = true;
		this.cboCombination.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboCombination.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboCombination.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[3]
		{
			new DevExpress.XtraEditors.Controls.LookUpColumnInfo("combID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
			new DevExpress.XtraEditors.Controls.LookUpColumnInfo("combFull", "F_Comb"),
			new DevExpress.XtraEditors.Controls.LookUpColumnInfo("combShort", "S_Comb")
		});
		this.cboCombination.Properties.NullText = "";
		this.cboCombination.Properties.PopupSizeable = false;
		this.cboCombination.Size = new System.Drawing.Size(145, 22);
		this.cboCombination.TabIndex = 20;
		this.cboCombination.EditValueChanged += new System.EventHandler(cboCombination_EditValueChanged);
		this.labelControl2.Location = new System.Drawing.Point(109, 41);
		this.labelControl2.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(18, 13);
		this.labelControl2.TabIndex = 56;
		this.labelControl2.Text = "NIN";
		this.labelControl25.Location = new System.Drawing.Point(313, 16);
		this.labelControl25.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl25.Name = "labelControl25";
		this.labelControl25.Size = new System.Drawing.Size(16, 13);
		this.labelControl25.TabIndex = 57;
		this.labelControl25.Text = "LIN";
		this.txtHealthStatus.EnterMoveNextControl = true;
		this.txtHealthStatus.Location = new System.Drawing.Point(336, 32);
		this.txtHealthStatus.Margin = new System.Windows.Forms.Padding(2);
		this.txtHealthStatus.Name = "txtHealthStatus";
		this.txtHealthStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtHealthStatus.Properties.MaxLength = 50;
		this.txtHealthStatus.Properties.NullText = "Health Status";
		this.txtHealthStatus.Properties.NullValuePrompt = "Health Status";
		this.txtHealthStatus.Size = new System.Drawing.Size(165, 22);
		this.txtHealthStatus.TabIndex = 3;
		this.labelControl26.Location = new System.Drawing.Point(315, 41);
		this.labelControl26.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl26.Name = "labelControl26";
		this.labelControl26.Size = new System.Drawing.Size(13, 13);
		this.labelControl26.TabIndex = 59;
		this.labelControl26.Text = "HS";
		this.labelControl27.Location = new System.Drawing.Point(31, 161);
		this.labelControl27.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl27.Name = "labelControl27";
		this.labelControl27.Size = new System.Drawing.Size(97, 13);
		this.labelControl27.TabIndex = 61;
		this.labelControl27.Text = "Co-curricular/Games";
		this.cboNOKRelation.Location = new System.Drawing.Point(134, 240);
		this.cboNOKRelation.Margin = new System.Windows.Forms.Padding(2);
		this.cboNOKRelation.Name = "cboNOKRelation";
		this.cboNOKRelation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboNOKRelation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboNOKRelation.Properties.Items.AddRange(new object[11]
		{
			"Aunt", "Brother", "Cousin", "Father", "Grand Parent", "In-Law", "Mother", "Nephew", "Niece", "Sister",
			"Uncle"
		});
		this.cboNOKRelation.Properties.MaxLength = 80;
		this.cboNOKRelation.Properties.Sorted = true;
		this.cboNOKRelation.Size = new System.Drawing.Size(367, 22);
		this.cboNOKRelation.TabIndex = 18;
		this.labelControl28.Location = new System.Drawing.Point(315, 156);
		this.labelControl28.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl28.Name = "labelControl28";
		this.labelControl28.Size = new System.Drawing.Size(13, 13);
		this.labelControl28.TabIndex = 63;
		this.labelControl28.Text = "RS";
		this.txtGames.Location = new System.Drawing.Point(134, 152);
		this.txtGames.Margin = new System.Windows.Forms.Padding(2);
		this.txtGames.Name = "txtGames";
		this.txtGames.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtGames.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.txtGames.Properties.Items.AddRange(new object[10] { "Athletics", "Basketball", "Chess", "Cricket", "Football", "MDD", "Netball", "Table Tenis", "Volleyball", "Woodball" });
		this.txtGames.Properties.MaxLength = 100;
		this.txtGames.Properties.Sorted = true;
		this.txtGames.Size = new System.Drawing.Size(161, 22);
		this.txtGames.TabIndex = 11;
		this.txtReportCentre.Location = new System.Drawing.Point(334, 152);
		this.txtReportCentre.Margin = new System.Windows.Forms.Padding(2);
		this.txtReportCentre.Name = "txtReportCentre";
		this.txtReportCentre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtReportCentre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.txtReportCentre.Properties.MaxLength = 100;
		this.txtReportCentre.Properties.NullText = "Report Centre";
		this.txtReportCentre.Properties.NullValuePrompt = "Report Centre";
		this.txtReportCentre.Size = new System.Drawing.Size(167, 22);
		this.txtReportCentre.TabIndex = 12;
		this.txtReportCentre.EditValueChanged += new System.EventHandler(txtReportCentre_EditValueChanged);
		this.picGuardianPhoto.Cursor = System.Windows.Forms.Cursors.Default;
		this.picGuardianPhoto.Location = new System.Drawing.Point(511, 198);
		this.picGuardianPhoto.Margin = new System.Windows.Forms.Padding(2);
		this.picGuardianPhoto.Name = "picGuardianPhoto";
		this.picGuardianPhoto.Properties.ShowMenu = false;
		this.picGuardianPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.picGuardianPhoto.Size = new System.Drawing.Size(153, 157);
		toolTipTitleItem2.Text = "Guardian's Photo";
		toolTipItem2.Text = "Double-Click here to upload a  photo";
		superToolTip2.Items.Add(toolTipTitleItem2);
		superToolTip2.Items.Add(toolTipItem2);
		this.picGuardianPhoto.SuperTip = superToolTip2;
		this.picGuardianPhoto.TabIndex = 64;
		this.picGuardianPhoto.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(picGuardianPhoto_MouseDoubleClick);
		this.adornerUIManager1.Elements.Add(this.badge1);
		this.adornerUIManager1.Elements.Add(this.badge2);
		this.adornerUIManager1.Owner = this;
		this.badge1.Properties.Location = System.Drawing.ContentAlignment.BottomCenter;
		this.badge1.Properties.Text = "Student Photo";
		this.badge1.TargetElement = this.picStudent;
		this.badge2.Appearance.BackColor = System.Drawing.Color.Green;
		this.badge2.Appearance.Options.UseBackColor = true;
		this.badge2.Properties.Location = System.Drawing.ContentAlignment.BottomCenter;
		this.badge2.Properties.Text = "Guardian Photo";
		this.badge2.TargetElement = this.picGuardianPhoto;
		this.simpleButton3.Location = new System.Drawing.Point(510, 170);
		this.simpleButton3.Margin = new System.Windows.Forms.Padding(2);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(153, 23);
		this.simpleButton3.TabIndex = 65;
		this.simpleButton3.Text = "Capture Fingerprint";
		this.simpleButton3.Visible = false;
		this.simpleButton3.Click += new System.EventHandler(simpleButton3_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(675, 491);
		base.Controls.Add(this.simpleButton3);
		base.Controls.Add(this.picGuardianPhoto);
		base.Controls.Add(this.labelControl28);
		base.Controls.Add(this.labelControl27);
		base.Controls.Add(this.labelControl26);
		base.Controls.Add(this.txtHealthStatus);
		base.Controls.Add(this.labelControl25);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.txtLIN);
		base.Controls.Add(this.txtNIN);
		base.Controls.Add(this.labelControl24);
		base.Controls.Add(this.txtOtherContact);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.txtIDNumber);
		base.Controls.Add(this.chkTheologyStudent);
		base.Controls.Add(this.lblResultsLabel);
		base.Controls.Add(this.txtResults);
		base.Controls.Add(this.labelControl22);
		base.Controls.Add(this.labelControl23);
		base.Controls.Add(this.labelControl21);
		base.Controls.Add(this.labelControl20);
		base.Controls.Add(this.labelControl19);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.labelControl18);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.labelControl17);
		base.Controls.Add(this.labelControl16);
		base.Controls.Add(this.cboStatus);
		base.Controls.Add(this.chkBursaryStatus);
		base.Controls.Add(this.txtNotes);
		base.Controls.Add(this.labelControl15);
		base.Controls.Add(this.txtFeesDiscount);
		base.Controls.Add(this.labelControl14);
		base.Controls.Add(this.labelControl13);
		base.Controls.Add(this.labelControl12);
		base.Controls.Add(this.labelControl11);
		base.Controls.Add(this.cboBursaryProvider);
		base.Controls.Add(this.txtRequiredFees);
		base.Controls.Add(this.labelControl10);
		base.Controls.Add(this.labelControl9);
		base.Controls.Add(this.simpleButton5);
		base.Controls.Add(this.radioGroupStudyStatus);
		base.Controls.Add(this.labelControl8);
		base.Controls.Add(this.labelControl7);
		base.Controls.Add(this.cboStream);
		base.Controls.Add(this.labelControl6);
		base.Controls.Add(this.labelControl5);
		base.Controls.Add(this.lblGuardianId);
		base.Controls.Add(this.txtUniqueGuid);
		base.Controls.Add(this.lblStudyStatus);
		base.Controls.Add(this.cboClass);
		base.Controls.Add(this.labelControl4);
		base.Controls.Add(this.picStudent);
		base.Controls.Add(this.lblSelectedIndex);
		base.Controls.Add(this.lblCurrentClass);
		base.Controls.Add(this.txtStudentNumber);
		base.Controls.Add(this.txtGurdianAddress);
		base.Controls.Add(this.txtFullName);
		base.Controls.Add(this.txtGuardianContact);
		base.Controls.Add(this.labelControl3);
		base.Controls.Add(this.cboSex);
		base.Controls.Add(this.cboReligion);
		base.Controls.Add(this.txtGuardian);
		base.Controls.Add(this.cboHall);
		base.Controls.Add(this.cboNationality);
		base.Controls.Add(this.txtFormerSchool);
		base.Controls.Add(this.dtDOB);
		base.Controls.Add(this.cboCombination);
		base.Controls.Add(this.cboNOKRelation);
		base.Controls.Add(this.txtGames);
		base.Controls.Add(this.txtReportCentre);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.Name = "editStudents";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Edit student";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(editStudents_FormClosed);
		base.Load += new System.EventHandler(editStudents_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(editStudents_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.txtFeesDiscount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkBursaryStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.radioGroupStudyStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtRequiredFees.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtNotes.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboBursaryProvider.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtGuardianContact.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboReligion.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboHall.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboNationality.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtFormerSchool.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSex.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtGurdianAddress.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtGuardian.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtFullName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNumber.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtDOB.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtDOB.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtUniqueGuid.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidateInsert).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtIDNumber.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtNIN.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtLIN.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidateUpdate).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picStudent.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtResults.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkTheologyStudent.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtOtherContact.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboCombination.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtHealthStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboNOKRelation.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtGames.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReportCentre.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.behaviorManager1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picGuardianPhoto.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.adornerUIManager1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
