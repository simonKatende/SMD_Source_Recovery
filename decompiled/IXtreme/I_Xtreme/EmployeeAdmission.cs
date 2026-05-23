using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.DialogForms;
using I_Xtreme.Properties;

namespace I_Xtreme;

public class EmployeeAdmission : XtraForm
{
	private int itemId = 0;

	private const int maxWidth = 400;

	private const int maxHeight = 480;

	private static DataSet dataSet;

	private static DataTable dataTable;

	private SqlTransaction trans;

	private string workingStatus = "Teaching staff";

	private string LedgerAccount = string.Empty;

	private string OriginalAccountName = string.Empty;

	private string invokingParentForm = string.Empty;

	private string defaultAccountName = string.Empty;

	public StartOrStopTimer StartTimer;

	private IContainer components = null;

	private LayoutControl layoutEmployeeData;

	private ComboBoxEdit cboEmplHouse;

	private TextEdit txtEmplFormerEmployee;

	private TextEdit textEdit22;

	private TextEdit txtEmplAddress;

	private TextEdit txtEmplContactNumber;

	private TextEdit txtStaffName;

	private DateEdit dtEmplHireDate;

	private TextEdit txtResponsibility;

	private ComboBoxEdit cboEmplSex;

	private LayoutControlGroup layoutControlGroup5;

	private LayoutControlItem layoutControlItem23;

	private LayoutControlItem layoutControlItem24;

	private LayoutControlItem layoutControlItem26;

	private LayoutControlItem layoutControlItem27;

	private LayoutControlItem layoutControlItem28;

	private LayoutControlItem layoutControlItem29;

	private LayoutControlItem layoutControlItem30;

	private LayoutControlItem layoutControlItem31;

	private LayoutControlItem layoutControlItem32;

	private LayoutControlItem layoutControlItem33;

	private LayoutControlItem layoutControlItem93;

	private PictureEdit picStaff;

	private MemoEdit txtEmplNotes;

	private RadioGroup radioGroup6;

	private SimpleButton simpleButton1;

	public TextEdit txtStaffNumber;

	private LayoutControlItem layoutControlItem5;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton3;

	private SimpleButton simpleButton4;

	private MemoEdit txtQualification;

	private LabelControl labelControl2;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem9;

	private EmptySpaceItem emptySpaceItem1;

	private DXValidationProvider dxValidationProvider1;

	private NavigationFrame navigationFrame1;

	private NavigationPage navigationPage1;

	private NavigationPage navigationPage2;

	private GridControl grdPayments;

	private GridView grvPayments;

	private NavigationPage navigationPage3;

	private GridControl grdDeductions;

	private GridView grvDeductions;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private GridColumn gridColumn7;

	private GridColumn gridColumn8;

	private GridColumn gridColumn9;

	private SplitContainerControl splitContainerControl1;

	private SimpleButton btnBack;

	private SimpleButton simpleButton6;

	private SimpleButton simpleButton5;

	private LayoutControl layoutControl1;

	private LabelControl labelControl3;

	private LayoutControlGroup Root;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem4;

	private LayoutControl layoutControl2;

	private LabelControl labelControl4;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem10;

	private LayoutControlItem layoutControlItem12;

	private LayoutControlItem layoutControlItem11;

	private LayoutControlItem layoutControlItem13;

	public EmployeeAdmission(string InvokingParentForm, string DefaultAccoutName)
	{
		InitializeComponent();
		invokingParentForm = InvokingParentForm;
		defaultAccountName = DefaultAccoutName;
	}

	private void GetEmployeePayments(string StaffId)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("StaffId", typeof(string));
		dataTable.Columns.Add("IsActive", typeof(bool));
		dataTable.Columns.Add("subAccountNo", typeof(string));
		dataTable.Columns.Add("SubAccoutName", typeof(string));
		dataTable.Columns.Add("Rate", typeof(double));
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT ga.categoryId, ga.accNo, ga.accName, a.subAccountNo, a.SubAccoutName FROM  .tbl_generalAccounts_Sub AS a RIGHT OUTER JOIN tbl_generalAccounts AS ga ON a.accNo = ga.accNo WHERE(ga.categoryId = 2000) AND(ga.accNo = 2001)", DataConnection.ConnectToDatabase());
		DataTable dataTable2 = new DataTable();
		sqlDataAdapter.Fill(dataTable2);
		foreach (DataRow row in dataTable2.Rows)
		{
			dataTable.Rows.Add(StaffId, false, row["subAccountNo"], row["SubAccoutName"], 0);
		}
		grdPayments.DataSource = dataTable.DefaultView;
		SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter($"SELECT * FROM tbl_PayrollMonthlyAllowances WHERE StaffID='{StaffId}'", DataConnection.ConnectToDatabase());
		DataTable dataTable3 = new DataTable();
		sqlDataAdapter2.Fill(dataTable3);
		foreach (DataRow row2 in dataTable3.Rows)
		{
			for (int i = 0; i < grvPayments.RowCount; i++)
			{
				if (grvPayments.GetRowCellValue(i, "subAccountNo").ToString() == row2["accNo"].ToString())
				{
					bool flag = Convert.ToBoolean(row2["IsActive"]);
					if (flag)
					{
						grvPayments.SetRowCellValue(i, "Rate", Convert.ToDouble(row2["Rate"]));
					}
					else
					{
						grvPayments.SetRowCellValue(i, "Rate", 0);
					}
					grvPayments.SetRowCellValue(i, "IsActive", flag);
					break;
				}
			}
		}
	}

	private void GetEmployeeDeductions(string StaffId)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT id,StaffId,Item AS Particulars,Rate FROM tbl_PayrollDeductions WHERE StaffId='{StaffId}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		grdDeductions.DataSource = dataTable.DefaultView;
	}

	private void AdmitStaff()
	{
		while (dxValidationProvider1.Validate())
		{
			if (dxValidationProvider1.GetInvalidControls().Count != 0)
			{
				continue;
			}
			if (StaffNumber.StaffNumberExists(txtStaffNumber.Text))
			{
				break;
			}
			try
			{
				string text = $"{Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtStaffName.Text.Trim())}";
				string nextSubAccountNumber = FinalAccounts.GetNextSubAccountNumber(5000, 5001);
				SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "SELECT * FROM Staff WHERE StaffName=@StaffName",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StaffName", SqlDbType.VarChar, 50);
					sqlParameter.Value = text;
					sqlParameter.Direction = ParameterDirection.Input;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					if (!sqlDataReader.HasRows)
					{
						sqlDataReader.Close();
						sqlConnection.Close();
					}
					else
					{
						sqlDataReader.Close();
						sqlConnection.Close();
						text = $"{text}{nextSubAccountNumber}";
					}
				}
				Image image = null;
				image = ((picStaff.Image != null) ? picStaff.Image : Resources.Default);
				int num = image.Height;
				int num2 = image.Width;
				num = num * 400 / num2;
				num2 = 400;
				if (num > 480)
				{
					num2 = num2 * 480 / num;
					num = 480;
				}
				Bitmap bitmap = new Bitmap(image, num2, num);
				MemoryStream memoryStream = new MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Png);
				memoryStream.Position = 0L;
				byte[] array = new byte[memoryStream.Length + 1];
				memoryStream.Read(array, 0, array.Length);
				using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection2.Open();
				trans = sqlConnection2.BeginTransaction();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					Transaction = trans,
					CommandText = "INSERT INTO Staff (StaffId,ContactNumber,Address,Sex,Responsibility,HouseID,Qualification,DateOfHire,WorkingStatus,Pic,FormerEmployee,StaffName,Notes,SalaryAmount,LedgerNo,StaffIdNumber)VALUES(@StaffId,@ContactNumber,@Address,@Sex,@Responsibility,@HouseID,@Qualification,@DateOfHire,@WorkingStatus,@Pic,@FormerEmployee,@StaffName,@Notes,@SalaryAmount,@LedgerNo,@StaffIdNumber)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@StaffId", SqlDbType.VarChar, 50);
					sqlParameter2.Value = txtStaffNumber.Text.Trim();
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@ContactNumber", SqlDbType.VarChar, 50);
					sqlParameter2.Value = txtEmplContactNumber.Text.Trim();
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@Address", SqlDbType.VarChar, 50);
					sqlParameter2.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtEmplAddress.Text);
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@Sex", SqlDbType.VarChar, 1);
					sqlParameter2.Value = cboEmplSex.Text.Substring(0, 1);
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@Responsibility", SqlDbType.VarChar, 50);
					sqlParameter2.Value = txtResponsibility.Text.Trim();
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@HouseID", SqlDbType.VarChar, 50);
					sqlParameter2.Value = cboEmplHouse.SelectedItem;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@DateOfHire", SqlDbType.DateTime);
					sqlParameter2.Value = dtEmplHireDate.DateTime.ToShortDateString();
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@Qualification", SqlDbType.VarChar, 50);
					sqlParameter2.Value = txtQualification.Text;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@Pic", SqlDbType.Image);
					sqlParameter2.Value = array;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@FormerEmployee", SqlDbType.VarChar, 50);
					sqlParameter2.Value = txtEmplFormerEmployee.Text;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@WorkingStatus", SqlDbType.VarChar, 50);
					sqlParameter2.Value = workingStatus;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@StaffName", SqlDbType.VarChar, 80);
					sqlParameter2.Value = text;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@Notes", SqlDbType.VarChar);
					sqlParameter2.Value = txtEmplNotes.Text;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@SalaryAmount", SqlDbType.Money);
					sqlParameter2.Value = 0;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@LedgerNo", SqlDbType.VarChar, 9);
					sqlParameter2.Value = nextSubAccountNumber;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@StaffIdNumber", SqlDbType.VarChar, 12);
					sqlParameter2.Value = StaffNumber.GetNextStaffNumber()[0];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection2,
					Transaction = trans,
					CommandText = "INSERT INTO tbl_generalAccounts_Sub (accNo,subAccountNo,SubAccoutName)VALUES(@accNo,@subAccountNo,@SubAccoutName)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@accNo", SqlDbType.Int);
					sqlParameter3.Value = 5001;
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand3.Parameters.Add("@subAccountNo", SqlDbType.VarChar, 9);
					sqlParameter3.Value = nextSubAccountNumber;
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand3.Parameters.Add("@SubAccoutName", SqlDbType.VarChar, 25);
					sqlParameter3.Value = text;
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlCommand3.ExecuteNonQuery();
				}
				trans.Commit();
				sqlConnection2.Close();
				if (invokingParentForm == "MainForm")
				{
					txtStaffName.Text = string.Empty;
					txtEmplContactNumber.Text = string.Empty;
					txtEmplAddress.Text = string.Empty;
					txtQualification.Text = string.Empty;
					txtEmplFormerEmployee.Text = string.Empty;
					txtStaffNumber.Text = StaffNumber.GetNextStaffNumber()[1];
					StartTimer(timerStatus: true);
				}
				else if (invokingParentForm == "SubAccount")
				{
					base.DialogResult = DialogResult.OK;
					Close();
				}
				break;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message, "School Management Dynamics");
				break;
			}
		}
	}

	private void UpdateStaff()
	{
		try
		{
			Image image = null;
			image = ((picStaff.Image != null) ? picStaff.Image : Resources.Default);
			int num = image.Height;
			int num2 = image.Width;
			num = num * 400 / num2;
			num2 = 400;
			if (num > 480)
			{
				num2 = num2 * 480 / num;
				num = 480;
			}
			Bitmap bitmap = new Bitmap(image, num2, num);
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Png);
			memoryStream.Position = 0L;
			byte[] array = new byte[memoryStream.Length + 1];
			memoryStream.Read(array, 0, array.Length);
			string text = $"{Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtStaffName.Text.Trim())}";
			if (OriginalAccountName != text)
			{
				SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "SELECT * FROM Staff WHERE StaffName=@StaffName",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StaffName", SqlDbType.VarChar, 50);
				sqlParameter.Value = text;
				sqlParameter.Direction = ParameterDirection.Input;
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (!sqlDataReader.HasRows)
				{
					sqlDataReader.Close();
					sqlConnection.Close();
				}
				else
				{
					sqlDataReader.Close();
					sqlConnection.Close();
					text = text + string.Empty + LedgerAccount;
				}
			}
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			trans = sqlConnection2.BeginTransaction();
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection2,
				Transaction = trans,
				CommandText = "UPDATE Staff SET ContactNumber=@ContactNumber,Address=@Address,Sex=@Sex,Responsibility=@Responsibility,HouseId=@HouseId,Qualification=@Qualification,DateOfHire=@DateOfHire,WorkingStatus=@WorkingStatus,Pic=@Pic,FormerEmployee=@FormerEmployee,StaffName=@StaffName,Notes=@Notes, SalaryAmount=@SalaryAmount WHERE StaffId=@StaffId",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@StaffId", SqlDbType.VarChar, 50);
				sqlParameter2.Value = txtStaffNumber.Text.Trim();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@ContactNumber", SqlDbType.VarChar, 50);
				sqlParameter2.Value = txtEmplContactNumber.Text.Trim();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Address", SqlDbType.VarChar, 50);
				sqlParameter2.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtEmplAddress.Text);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Sex", SqlDbType.VarChar, 1);
				sqlParameter2.Value = cboEmplSex.Text.Substring(0, 1);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Responsibility", SqlDbType.VarChar, 50);
				sqlParameter2.Value = txtResponsibility.Text.Trim();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@HouseID", SqlDbType.VarChar, 50);
				sqlParameter2.Value = cboEmplHouse.SelectedItem;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@DateOfHire", SqlDbType.DateTime);
				sqlParameter2.Value = dtEmplHireDate.DateTime.ToShortDateString();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Qualification", SqlDbType.VarChar, 50);
				sqlParameter2.Value = txtQualification.Text;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Pic", SqlDbType.Image);
				sqlParameter2.Value = array;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@FormerEmployee", SqlDbType.VarChar, 50);
				sqlParameter2.Value = txtEmplFormerEmployee.Text;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@WorkingStatus", SqlDbType.VarChar, 50);
				sqlParameter2.Value = workingStatus;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@StaffName", SqlDbType.VarChar, 80);
				sqlParameter2.Value = $"{Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtStaffName.Text.Trim())}";
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Notes", SqlDbType.VarChar);
				sqlParameter2.Value = txtEmplNotes.Text;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@SalaryAmount", SqlDbType.Money);
				sqlParameter2.Value = 0;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand3 = new SqlCommand
			{
				Connection = sqlConnection2,
				Transaction = trans,
				CommandText = "UPDATE tbl_generalAccounts_Sub SET SubAccoutName=@SubAccoutName WHERE subAccountNo=@subAccountNo",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@subAccountNo", SqlDbType.VarChar, 9);
				sqlParameter3.Value = LedgerAccount;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@SubAccoutName", SqlDbType.VarChar, 25);
				sqlParameter3.Value = text;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlCommand3.ExecuteNonQuery();
			}
			trans.Commit();
			sqlConnection2.Close();
			if (!(invokingParentForm == "MainForm") && !(invokingParentForm == "SubAccount"))
			{
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (navigationFrame1.SelectedPageIndex == 0)
		{
			while (dxValidationProvider1.Validate())
			{
				if (dxValidationProvider1.GetInvalidControls().Count == 0)
				{
					if (Text == "Add New Employee")
					{
						AdmitStaff();
					}
					else if (Text == "Edit Employee details")
					{
						UpdateStaff();
					}
					navigationFrame1.SelectedPageIndex = 1;
					GetEmployeePayments(txtStaffNumber.Text);
					btnBack.Enabled = true;
					break;
				}
			}
		}
		else if (navigationFrame1.SelectedPageIndex == 1)
		{
			GetEmployeeDeductions(txtStaffNumber.Text);
			navigationFrame1.SelectedPageIndex = 2;
			simpleButton1.Text = "Finish";
		}
		else if (navigationFrame1.SelectedPageIndex == 2)
		{
			Close();
		}
	}

	private void picStaff_DoubleClick(object sender, EventArgs e)
	{
		try
		{
			string text = null;
			using OpenFileDialog openFileDialog = new OpenFileDialog
			{
				RestoreDirectory = true,
				Title = "Open Employee's photo",
				Filter = "jpg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|png files (*.png)|*.png|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				text = openFileDialog.FileName;
				picStaff.Image = Image.FromFile(text);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private static void LoadHouses(ComboBoxEdit myCombo)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Houses", selectConnection);
			dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Hall");
			dataTable = dataSet.Tables[0];
			myCombo.Properties.Items.Clear();
			if (dataTable.Rows.Count == 0)
			{
				myCombo.Properties.Items.Clear();
				myCombo.Properties.Items.Add("-");
				myCombo.SelectedIndex = 0;
				return;
			}
			myCombo.Properties.Items.Clear();
			foreach (DataRow row in dataTable.Rows)
			{
				myCombo.Properties.Items.Add(row["HouseName"]);
			}
			myCombo.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void SearchEmployee(string employeeNo)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			string selectCommandText = $"SELECT * FROM Staff WHERE StaffId='{employeeNo}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "employee");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				txtStaffName.Text = row["StaffName"].ToString();
				txtEmplContactNumber.Text = row["ContactNumber"].ToString();
				txtEmplAddress.Text = row["Address"].ToString();
				cboEmplSex.Text = row["Sex"].ToString();
				txtResponsibility.Text = row["Responsibility"].ToString();
				txtQualification.Text = row["Qualification"].ToString();
				cboEmplHouse.SelectedItem = row["HouseId"].ToString();
				dtEmplHireDate.Text = Convert.ToDateTime(row["DateOfHire"]).ToString("dd-MMM-yyyy");
				OriginalAccountName = row["StaffName"].ToString();
				LedgerAccount = row["LedgerNo"].ToString();
				txtEmplNotes.Text = row["Notes"].ToString();
				txtStaffNumber.Text = row["StaffId"].ToString();
				byte[] array = new byte[0];
				array = (byte[])row["Pic"];
				using (MemoryStream stream = new MemoryStream(array))
				{
					picStaff.Image = Image.FromStream(stream);
				}
				if (row["WorkingStatus"].ToString() == "Teaching Staff")
				{
					radioGroup6.SelectedIndex = 0;
				}
				else
				{
					radioGroup6.SelectedIndex = 1;
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void radioGroup6_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (radioGroup6.SelectedIndex == 0)
		{
			workingStatus = "Teaching staff";
		}
		else
		{
			workingStatus = "None Teaching Staff";
		}
	}

	private void EmployeeAdmission_Load(object sender, EventArgs e)
	{
		LoadHouses(cboEmplHouse);
		if (Text == "Edit Employee details")
		{
			SearchEmployee(txtStaffNumber.Text);
			return;
		}
		txtStaffNumber.Text = StaffNumber.GetNextStaffNumber()[1];
		dtEmplHireDate.DateTime = DateTime.Now;
		txtStaffName.Text = defaultAccountName;
	}

	private void EmployeeAdmission_FormClosed(object sender, FormClosedEventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void simpleButton3_Click(object sender, EventArgs e)
	{
		try
		{
			string text = null;
			using OpenFileDialog openFileDialog = new OpenFileDialog
			{
				RestoreDirectory = true,
				Title = "Open Employee's photo",
				Filter = "jpg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|png files (*.png)|*.png|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				text = openFileDialog.FileName;
				picStaff.Image = Image.FromFile(text);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void txtStaffNumber_TextChanged(object sender, EventArgs e)
	{
		dxValidationProvider1.RemoveControlError(txtStaffNumber);
	}

	private void txtStaffName_TextChanged(object sender, EventArgs e)
	{
		dxValidationProvider1.RemoveControlError(txtStaffName);
	}

	private void cboEmplSex_QueryPopUp(object sender, CancelEventArgs e)
	{
		dxValidationProvider1.RemoveControlError(cboEmplSex);
	}

	private void txtEmplContactNumber_TextChanged(object sender, EventArgs e)
	{
		dxValidationProvider1.RemoveControlError(txtEmplContactNumber);
	}

	private void txtEmplAddress_TextChanged(object sender, EventArgs e)
	{
		dxValidationProvider1.RemoveControlError(txtEmplAddress);
	}

	private void dtEmplHireDate_QueryPopUp(object sender, CancelEventArgs e)
	{
		dxValidationProvider1.RemoveControlError(dtEmplHireDate);
	}

	private void btnBack_Click(object sender, EventArgs e)
	{
		if (navigationFrame1.SelectedPageIndex == 2)
		{
			simpleButton1.Text = "Next";
			navigationFrame1.SelectedPageIndex = 1;
		}
		else if (navigationFrame1.SelectedPageIndex == 1)
		{
			navigationFrame1.SelectedPageIndex = 0;
			btnBack.Enabled = false;
		}
	}

	private void simpleButton5_Click(object sender, EventArgs e)
	{
		StaffDeductions staffDeductions = new StaffDeductions(txtStaffNumber.Text);
		if (staffDeductions.ShowDialog() == DialogResult.OK)
		{
			GetEmployeeDeductions(txtStaffNumber.Text);
		}
	}

	private void grvPayments_CellValueChanged(object sender, CellValueChangedEventArgs e)
	{
		if (e.Column.FieldName == "Rate")
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			string text = grvPayments.GetRowCellValue(grvPayments.FocusedRowHandle, "subAccountNo").ToString();
			string text2 = grvPayments.GetRowCellValue(grvPayments.FocusedRowHandle, "SubAccoutName").ToString();
			double result = (double.TryParse(e.Value.ToString(), out result) ? result : 0.0);
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT * FROM tbl_PayrollMonthlyAllowances WHERE accNo=@accNo AND StaffID=@StaffID",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
			sqlParameter.Value = text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@StaffID", SqlDbType.VarChar, 50);
			sqlParameter.Value = txtStaffNumber.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "UPDATE tbl_PayrollMonthlyAllowances SET Rate=@Rate WHERE accNo=@accNo",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
				sqlParameter2.Value = text;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Rate", SqlDbType.Money);
				sqlParameter2.Value = result;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
				sqlConnection.Close();
			}
			else
			{
				sqlDataReader.Close();
				sqlConnection.Close();
				DataModel.SaveData("tbl_PayrollMonthlyAllowances", new string[5] { "accNo", "StaffID", "Particulars", "Rate", "IsActive" }, new object[5] { text, txtStaffNumber.Text, text2, result, 1 });
			}
		}
	}

	private void simpleButton6_Click(object sender, EventArgs e)
	{
		if (XtraMessageBox.Show("Do you really want to delete the selected item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "DELETE FROM tbl_PayrollDeductions WHERE id=@id AND StaffId=@StaffId",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@id", SqlDbType.Int);
			sqlParameter.Value = itemId;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@StaffId", SqlDbType.VarChar, 12);
			sqlParameter.Value = txtStaffNumber.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				XtraMessageBox.Show("Item deleted successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				simpleButton6.Enabled = false;
				GetEmployeeDeductions(txtStaffNumber.Text);
			}
		}
	}

	private void grvDeductions_RowClick(object sender, RowClickEventArgs e)
	{
		if (grvDeductions.FocusedRowHandle > -1)
		{
			simpleButton6.Enabled = true;
			itemId = Convert.ToInt32(grvDeductions.GetRowCellValue(e.RowHandle, "id").ToString());
		}
		else
		{
			simpleButton6.Enabled = false;
		}
	}

	private void grvDeductions_CellValueChanged(object sender, CellValueChangedEventArgs e)
	{
		if (e.Column.FieldName == "Rate")
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			string text = grvDeductions.GetRowCellValue(grvDeductions.FocusedRowHandle, "id").ToString();
			double result = (double.TryParse(e.Value.ToString(), out result) ? result : 0.0);
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "UPDATE tbl_PayrollDeductions SET Rate=@Rate WHERE id=@id",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@id", SqlDbType.Int);
			sqlParameter.Value = itemId;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Rate", SqlDbType.Money);
			sqlParameter.Value = result;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
	}

	private void grvDeductions_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (grvDeductions.FocusedRowHandle > -1)
		{
			simpleButton6.Enabled = true;
			itemId = Convert.ToInt32(grvDeductions.GetRowCellValue(e.FocusedRowHandle, "id").ToString());
		}
		else
		{
			simpleButton6.Enabled = false;
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
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule5 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule6 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		this.layoutEmployeeData = new DevExpress.XtraLayout.LayoutControl();
		this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.txtEmplNotes = new DevExpress.XtraEditors.MemoEdit();
		this.picStaff = new DevExpress.XtraEditors.PictureEdit();
		this.radioGroup6 = new DevExpress.XtraEditors.RadioGroup();
		this.cboEmplHouse = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtEmplFormerEmployee = new DevExpress.XtraEditors.TextEdit();
		this.textEdit22 = new DevExpress.XtraEditors.TextEdit();
		this.txtEmplAddress = new DevExpress.XtraEditors.TextEdit();
		this.txtEmplContactNumber = new DevExpress.XtraEditors.TextEdit();
		this.txtStaffName = new DevExpress.XtraEditors.TextEdit();
		this.txtStaffNumber = new DevExpress.XtraEditors.TextEdit();
		this.dtEmplHireDate = new DevExpress.XtraEditors.DateEdit();
		this.txtResponsibility = new DevExpress.XtraEditors.TextEdit();
		this.cboEmplSex = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtQualification = new DevExpress.XtraEditors.MemoEdit();
		this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem93 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
		this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.grdPayments = new DevExpress.XtraGrid.GridControl();
		this.grvPayments = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.navigationPage3 = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
		this.grdDeductions = new DevExpress.XtraGrid.GridControl();
		this.grvDeductions = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
		this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
		this.btnBack = new DevExpress.XtraEditors.SimpleButton();
		((System.ComponentModel.ISupportInitialize)this.layoutEmployeeData).BeginInit();
		this.layoutEmployeeData.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtEmplNotes.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picStaff.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.radioGroup6.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboEmplHouse.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplFormerEmployee.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit22.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplAddress.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplContactNumber.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStaffName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStaffNumber.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtEmplHireDate.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtEmplHireDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtResponsibility.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboEmplSex.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtQualification.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem23).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem32).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem93).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem29).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem27).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem28).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem30).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem31).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem24).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem33).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem26).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.navigationFrame1).BeginInit();
		this.navigationFrame1.SuspendLayout();
		this.navigationPage1.SuspendLayout();
		this.navigationPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.grdPayments).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.grvPayments).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		this.navigationPage3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl2).BeginInit();
		this.layoutControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.grdDeductions).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.grvDeductions).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).BeginInit();
		this.splitContainerControl1.SuspendLayout();
		base.SuspendLayout();
		this.layoutEmployeeData.Controls.Add(this.simpleButton3);
		this.layoutEmployeeData.Controls.Add(this.simpleButton4);
		this.layoutEmployeeData.Controls.Add(this.labelControl2);
		this.layoutEmployeeData.Controls.Add(this.labelControl1);
		this.layoutEmployeeData.Controls.Add(this.txtEmplNotes);
		this.layoutEmployeeData.Controls.Add(this.picStaff);
		this.layoutEmployeeData.Controls.Add(this.radioGroup6);
		this.layoutEmployeeData.Controls.Add(this.cboEmplHouse);
		this.layoutEmployeeData.Controls.Add(this.txtEmplFormerEmployee);
		this.layoutEmployeeData.Controls.Add(this.textEdit22);
		this.layoutEmployeeData.Controls.Add(this.txtEmplAddress);
		this.layoutEmployeeData.Controls.Add(this.txtEmplContactNumber);
		this.layoutEmployeeData.Controls.Add(this.txtStaffName);
		this.layoutEmployeeData.Controls.Add(this.txtStaffNumber);
		this.layoutEmployeeData.Controls.Add(this.dtEmplHireDate);
		this.layoutEmployeeData.Controls.Add(this.txtResponsibility);
		this.layoutEmployeeData.Controls.Add(this.cboEmplSex);
		this.layoutEmployeeData.Controls.Add(this.txtQualification);
		this.layoutEmployeeData.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutEmployeeData.Location = new System.Drawing.Point(0, 0);
		this.layoutEmployeeData.Margin = new System.Windows.Forms.Padding(4);
		this.layoutEmployeeData.Name = "layoutEmployeeData";
		this.layoutEmployeeData.Root = this.layoutControlGroup5;
		this.layoutEmployeeData.Size = new System.Drawing.Size(962, 734);
		this.layoutEmployeeData.TabIndex = 13;
		this.layoutEmployeeData.Text = "layoutControl1";
		this.simpleButton3.Location = new System.Drawing.Point(5, 288);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(135, 32);
		this.simpleButton3.StyleController = this.layoutEmployeeData;
		this.simpleButton3.TabIndex = 1;
		this.simpleButton3.TabStop = false;
		this.simpleButton3.Text = "Load Photo";
		this.simpleButton3.Click += new System.EventHandler(simpleButton3_Click);
		this.simpleButton4.Location = new System.Drawing.Point(144, 288);
		this.simpleButton4.Name = "simpleButton4";
		this.simpleButton4.Size = new System.Drawing.Size(132, 32);
		this.simpleButton4.StyleController = this.layoutEmployeeData;
		this.simpleButton4.TabIndex = 1;
		this.simpleButton4.TabStop = false;
		this.simpleButton4.Text = "PC Camera";
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.labelControl2.Appearance.Options.UseFont = true;
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl2.LineVisible = true;
		this.labelControl2.Location = new System.Drawing.Point(280, 246);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(677, 21);
		this.labelControl2.StyleController = this.layoutEmployeeData;
		this.labelControl2.TabIndex = 1;
		this.labelControl2.Text = "Employment Records";
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.LineVisible = true;
		this.labelControl1.Location = new System.Drawing.Point(280, 113);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(677, 21);
		this.labelControl1.StyleController = this.layoutEmployeeData;
		this.labelControl1.TabIndex = 1;
		this.labelControl1.Text = "Contact Information";
		this.txtEmplNotes.Location = new System.Drawing.Point(420, 591);
		this.txtEmplNotes.Name = "txtEmplNotes";
		this.txtEmplNotes.Properties.NullText = "Notes";
		this.txtEmplNotes.Properties.NullValuePrompt = "Notes";
		this.txtEmplNotes.Size = new System.Drawing.Size(537, 138);
		this.txtEmplNotes.StyleController = this.layoutEmployeeData;
		this.txtEmplNotes.TabIndex = 13;
		this.txtEmplNotes.ToolTip = "Notes";
		this.txtEmplNotes.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
		this.picStaff.Cursor = System.Windows.Forms.Cursors.Default;
		this.picStaff.Location = new System.Drawing.Point(5, 5);
		this.picStaff.Name = "picStaff";
		this.picStaff.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.picStaff.Size = new System.Drawing.Size(271, 279);
		this.picStaff.StyleController = this.layoutEmployeeData;
		this.picStaff.TabIndex = 1;
		this.picStaff.DoubleClick += new System.EventHandler(picStaff_DoubleClick);
		this.radioGroup6.Location = new System.Drawing.Point(420, 343);
		this.radioGroup6.Name = "radioGroup6";
		this.radioGroup6.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroup6.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.radioGroup6.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroup6.Properties.Appearance.Options.UseFont = true;
		this.radioGroup6.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Teaching staff"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "None teaching staff")
		});
		this.radioGroup6.Size = new System.Drawing.Size(537, 70);
		this.radioGroup6.StyleController = this.layoutEmployeeData;
		this.radioGroup6.TabIndex = 10;
		this.radioGroup6.ToolTip = "Employee Type";
		this.radioGroup6.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
		this.radioGroup6.SelectedIndexChanged += new System.EventHandler(radioGroup6_SelectedIndexChanged);
		this.cboEmplHouse.EditValue = "";
		this.cboEmplHouse.Location = new System.Drawing.Point(760, 77);
		this.cboEmplHouse.Name = "cboEmplHouse";
		this.cboEmplHouse.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9f);
		this.cboEmplHouse.Properties.Appearance.Options.UseFont = true;
		this.cboEmplHouse.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11f);
		this.cboEmplHouse.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboEmplHouse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboEmplHouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboEmplHouse.Properties.NullText = "House";
		this.cboEmplHouse.Properties.NullValuePrompt = "House";
		this.cboEmplHouse.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboEmplHouse.Size = new System.Drawing.Size(197, 32);
		this.cboEmplHouse.StyleController = this.layoutEmployeeData;
		this.cboEmplHouse.TabIndex = 4;
		this.cboEmplHouse.ToolTip = "House";
		this.cboEmplHouse.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
		this.txtEmplFormerEmployee.EditValue = "";
		this.txtEmplFormerEmployee.Location = new System.Drawing.Point(420, 307);
		this.txtEmplFormerEmployee.Name = "txtEmplFormerEmployee";
		this.txtEmplFormerEmployee.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9f);
		this.txtEmplFormerEmployee.Properties.Appearance.Options.UseFont = true;
		this.txtEmplFormerEmployee.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtEmplFormerEmployee.Properties.NullText = "Former employee";
		this.txtEmplFormerEmployee.Properties.NullValuePrompt = "Former employee";
		this.txtEmplFormerEmployee.Size = new System.Drawing.Size(537, 32);
		this.txtEmplFormerEmployee.StyleController = this.layoutEmployeeData;
		this.txtEmplFormerEmployee.TabIndex = 9;
		this.txtEmplFormerEmployee.ToolTip = "Former employee";
		this.txtEmplFormerEmployee.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
		this.textEdit22.EditValue = "";
		this.textEdit22.Location = new System.Drawing.Point(420, 210);
		this.textEdit22.Name = "textEdit22";
		this.textEdit22.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9f);
		this.textEdit22.Properties.Appearance.Options.UseFont = true;
		this.textEdit22.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.textEdit22.Properties.NullText = "Email";
		this.textEdit22.Properties.NullValuePrompt = "Email";
		this.textEdit22.Size = new System.Drawing.Size(537, 32);
		this.textEdit22.StyleController = this.layoutEmployeeData;
		this.textEdit22.TabIndex = 7;
		this.textEdit22.ToolTip = "Email";
		this.textEdit22.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
		this.txtEmplAddress.EditValue = "";
		this.dxValidationProvider1.SetIconAlignment(this.txtEmplAddress, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtEmplAddress.Location = new System.Drawing.Point(420, 174);
		this.txtEmplAddress.Name = "txtEmplAddress";
		this.txtEmplAddress.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9f);
		this.txtEmplAddress.Properties.Appearance.Options.UseFont = true;
		this.txtEmplAddress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtEmplAddress.Properties.NullText = "Address";
		this.txtEmplAddress.Properties.NullValuePrompt = "Address";
		this.txtEmplAddress.Size = new System.Drawing.Size(537, 32);
		this.txtEmplAddress.StyleController = this.layoutEmployeeData;
		this.txtEmplAddress.TabIndex = 6;
		this.txtEmplAddress.ToolTip = "Address";
		this.txtEmplAddress.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
		conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.txtEmplAddress, conditionValidationRule);
		this.txtEmplAddress.TextChanged += new System.EventHandler(txtEmplAddress_TextChanged);
		this.txtEmplContactNumber.EditValue = "";
		this.dxValidationProvider1.SetIconAlignment(this.txtEmplContactNumber, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtEmplContactNumber.Location = new System.Drawing.Point(420, 138);
		this.txtEmplContactNumber.Name = "txtEmplContactNumber";
		this.txtEmplContactNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9f);
		this.txtEmplContactNumber.Properties.Appearance.Options.UseFont = true;
		this.txtEmplContactNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtEmplContactNumber.Properties.NullText = "Telephone";
		this.txtEmplContactNumber.Properties.NullValuePrompt = "Telephone";
		this.txtEmplContactNumber.Size = new System.Drawing.Size(537, 32);
		this.txtEmplContactNumber.StyleController = this.layoutEmployeeData;
		this.txtEmplContactNumber.TabIndex = 5;
		this.txtEmplContactNumber.ToolTip = "Telephone";
		this.txtEmplContactNumber.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
		conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule2.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.txtEmplContactNumber, conditionValidationRule2);
		this.txtEmplContactNumber.TextChanged += new System.EventHandler(txtEmplContactNumber_TextChanged);
		this.txtStaffName.EditValue = "";
		this.dxValidationProvider1.SetIconAlignment(this.txtStaffName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtStaffName.Location = new System.Drawing.Point(420, 41);
		this.txtStaffName.Name = "txtStaffName";
		this.txtStaffName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9f);
		this.txtStaffName.Properties.Appearance.Options.UseFont = true;
		this.txtStaffName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtStaffName.Properties.NullText = "Surname";
		this.txtStaffName.Properties.NullValuePrompt = "Surname";
		this.txtStaffName.Size = new System.Drawing.Size(537, 32);
		this.txtStaffName.StyleController = this.layoutEmployeeData;
		this.txtStaffName.TabIndex = 2;
		this.txtStaffName.ToolTip = "Surname";
		this.txtStaffName.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
		conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule3.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.txtStaffName, conditionValidationRule3);
		this.txtStaffName.TextChanged += new System.EventHandler(txtStaffName_TextChanged);
		this.txtStaffNumber.EditValue = "";
		this.dxValidationProvider1.SetIconAlignment(this.txtStaffNumber, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtStaffNumber.Location = new System.Drawing.Point(420, 5);
		this.txtStaffNumber.Name = "txtStaffNumber";
		this.txtStaffNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9f);
		this.txtStaffNumber.Properties.Appearance.Options.UseFont = true;
		this.txtStaffNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtStaffNumber.Properties.NullText = "Employee No";
		this.txtStaffNumber.Properties.NullValuePrompt = "Employee No";
		this.txtStaffNumber.Size = new System.Drawing.Size(537, 32);
		this.txtStaffNumber.StyleController = this.layoutEmployeeData;
		this.txtStaffNumber.TabIndex = 0;
		this.txtStaffNumber.ToolTip = "Employee No";
		this.txtStaffNumber.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
		conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule4.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.txtStaffNumber, conditionValidationRule4);
		this.txtStaffNumber.TextChanged += new System.EventHandler(txtStaffNumber_TextChanged);
		this.dtEmplHireDate.EditValue = null;
		this.dxValidationProvider1.SetIconAlignment(this.dtEmplHireDate, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.dtEmplHireDate.Location = new System.Drawing.Point(420, 271);
		this.dtEmplHireDate.Name = "dtEmplHireDate";
		this.dtEmplHireDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9f);
		this.dtEmplHireDate.Properties.Appearance.Options.UseFont = true;
		this.dtEmplHireDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11f);
		this.dtEmplHireDate.Properties.AppearanceDropDown.Options.UseFont = true;
		this.dtEmplHireDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.dtEmplHireDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtEmplHireDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtEmplHireDate.Properties.Mask.EditMask = "";
		this.dtEmplHireDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
		this.dtEmplHireDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.dtEmplHireDate.Size = new System.Drawing.Size(537, 32);
		this.dtEmplHireDate.StyleController = this.layoutEmployeeData;
		this.dtEmplHireDate.TabIndex = 8;
		this.dtEmplHireDate.ToolTip = "Date of Hire";
		this.dtEmplHireDate.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
		conditionValidationRule5.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule5.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.dtEmplHireDate, conditionValidationRule5);
		this.dtEmplHireDate.QueryPopUp += new System.ComponentModel.CancelEventHandler(dtEmplHireDate_QueryPopUp);
		this.txtResponsibility.EditValue = "";
		this.txtResponsibility.Location = new System.Drawing.Point(420, 417);
		this.txtResponsibility.Name = "txtResponsibility";
		this.txtResponsibility.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9f);
		this.txtResponsibility.Properties.Appearance.Options.UseFont = true;
		this.txtResponsibility.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtResponsibility.Properties.NullText = "Responsibility";
		this.txtResponsibility.Properties.NullValuePrompt = "Responsibility";
		this.txtResponsibility.Size = new System.Drawing.Size(537, 32);
		this.txtResponsibility.StyleController = this.layoutEmployeeData;
		this.txtResponsibility.TabIndex = 11;
		this.txtResponsibility.ToolTip = "Responsibility";
		this.txtResponsibility.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
		this.cboEmplSex.EditValue = "";
		this.dxValidationProvider1.SetIconAlignment(this.cboEmplSex, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.cboEmplSex.Location = new System.Drawing.Point(420, 77);
		this.cboEmplSex.Name = "cboEmplSex";
		this.cboEmplSex.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9f);
		this.cboEmplSex.Properties.Appearance.Options.UseFont = true;
		this.cboEmplSex.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11f);
		this.cboEmplSex.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboEmplSex.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboEmplSex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboEmplSex.Properties.Items.AddRange(new object[2] { "Female", "Male" });
		this.cboEmplSex.Properties.NullText = "Sex";
		this.cboEmplSex.Properties.NullValuePrompt = "Sex";
		this.cboEmplSex.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboEmplSex.Size = new System.Drawing.Size(196, 32);
		this.cboEmplSex.StyleController = this.layoutEmployeeData;
		this.cboEmplSex.TabIndex = 3;
		this.cboEmplSex.ToolTip = "Sex";
		this.cboEmplSex.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
		conditionValidationRule6.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule6.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.cboEmplSex, conditionValidationRule6);
		this.cboEmplSex.QueryPopUp += new System.ComponentModel.CancelEventHandler(cboEmplSex_QueryPopUp);
		this.txtQualification.EditValue = "";
		this.txtQualification.Location = new System.Drawing.Point(420, 453);
		this.txtQualification.Name = "txtQualification";
		this.txtQualification.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9f);
		this.txtQualification.Properties.Appearance.Options.UseFont = true;
		this.txtQualification.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtQualification.Properties.NullText = "Qualification";
		this.txtQualification.Properties.NullValuePrompt = "Qualification";
		this.txtQualification.Size = new System.Drawing.Size(537, 134);
		this.txtQualification.StyleController = this.layoutEmployeeData;
		this.txtQualification.TabIndex = 12;
		this.txtQualification.ToolTip = "Qualification";
		this.txtQualification.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
		this.layoutControlGroup5.CustomizationFormText = "layout";
		this.layoutControlGroup5.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup5.GroupBordersVisible = false;
		this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[19]
		{
			this.layoutControlItem23, this.layoutControlItem32, this.layoutControlItem5, this.layoutControlItem93, this.layoutControlItem29, this.layoutControlItem27, this.layoutControlItem28, this.layoutControlItem30, this.layoutControlItem31, this.layoutControlItem24,
			this.layoutControlItem33, this.layoutControlItem2, this.layoutControlItem26, this.layoutControlItem3, this.layoutControlItem6, this.layoutControlItem7, this.layoutControlItem8, this.layoutControlItem9, this.emptySpaceItem1
		});
		this.layoutControlGroup5.Name = "layout";
		this.layoutControlGroup5.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
		this.layoutControlGroup5.Size = new System.Drawing.Size(962, 734);
		this.layoutControlGroup5.TextVisible = false;
		this.layoutControlItem23.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem23.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem23.Control = this.txtStaffNumber;
		this.layoutControlItem23.CustomizationFormText = "Student No.";
		this.layoutControlItem23.Location = new System.Drawing.Point(275, 0);
		this.layoutControlItem23.Name = "layoutControlItem4";
		this.layoutControlItem23.Size = new System.Drawing.Size(681, 36);
		this.layoutControlItem23.Text = "Employee#.";
		this.layoutControlItem23.TextSize = new System.Drawing.Size(137, 22);
		this.layoutControlItem32.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem32.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem32.Control = this.txtEmplContactNumber;
		this.layoutControlItem32.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem32.Location = new System.Drawing.Point(275, 133);
		this.layoutControlItem32.Name = "layoutControlItem11";
		this.layoutControlItem32.Size = new System.Drawing.Size(681, 36);
		this.layoutControlItem32.Text = "Tel#";
		this.layoutControlItem32.TextSize = new System.Drawing.Size(137, 22);
		this.layoutControlItem5.Control = this.radioGroup6;
		this.layoutControlItem5.CustomizationFormText = "Employee Type";
		this.layoutControlItem5.Location = new System.Drawing.Point(275, 338);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(681, 74);
		this.layoutControlItem5.Text = "Employee Type";
		this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
		this.layoutControlItem5.TextSize = new System.Drawing.Size(137, 19);
		this.layoutControlItem93.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem93.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem93.Control = this.cboEmplHouse;
		this.layoutControlItem93.CustomizationFormText = "House:";
		this.layoutControlItem93.Location = new System.Drawing.Point(615, 72);
		this.layoutControlItem93.Name = "layoutControlItem93";
		this.layoutControlItem93.Size = new System.Drawing.Size(341, 36);
		this.layoutControlItem93.Text = "House";
		this.layoutControlItem93.TextSize = new System.Drawing.Size(137, 22);
		this.layoutControlItem29.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem29.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem29.AppearanceItemCaption.Options.UseTextOptions = true;
		this.layoutControlItem29.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.layoutControlItem29.Control = this.txtEmplFormerEmployee;
		this.layoutControlItem29.CustomizationFormText = "Former school";
		this.layoutControlItem29.Location = new System.Drawing.Point(275, 302);
		this.layoutControlItem29.Name = "layoutControlItem14";
		this.layoutControlItem29.Size = new System.Drawing.Size(681, 36);
		this.layoutControlItem29.Text = "Former Employee";
		this.layoutControlItem29.TextSize = new System.Drawing.Size(137, 22);
		this.layoutControlItem27.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem27.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem27.Control = this.txtResponsibility;
		this.layoutControlItem27.CustomizationFormText = "Religion";
		this.layoutControlItem27.Location = new System.Drawing.Point(275, 412);
		this.layoutControlItem27.Name = "layoutControlItem9";
		this.layoutControlItem27.Size = new System.Drawing.Size(681, 36);
		this.layoutControlItem27.Text = "Responsibility";
		this.layoutControlItem27.TextSize = new System.Drawing.Size(137, 22);
		this.layoutControlItem28.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem28.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem28.Control = this.txtQualification;
		this.layoutControlItem28.CustomizationFormText = "Home Country";
		this.layoutControlItem28.Location = new System.Drawing.Point(275, 448);
		this.layoutControlItem28.Name = "layoutControlItem10";
		this.layoutControlItem28.Size = new System.Drawing.Size(681, 138);
		this.layoutControlItem28.Text = "Qualifications";
		this.layoutControlItem28.TextSize = new System.Drawing.Size(137, 22);
		this.layoutControlItem30.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem30.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem30.Control = this.textEdit22;
		this.layoutControlItem30.CustomizationFormText = "Kin address";
		this.layoutControlItem30.Location = new System.Drawing.Point(275, 205);
		this.layoutControlItem30.Name = "layoutControlItem13";
		this.layoutControlItem30.Size = new System.Drawing.Size(681, 36);
		this.layoutControlItem30.Text = "Email";
		this.layoutControlItem30.TextSize = new System.Drawing.Size(137, 22);
		this.layoutControlItem31.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem31.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem31.Control = this.txtEmplAddress;
		this.layoutControlItem31.CustomizationFormText = "layoutControlItem12";
		this.layoutControlItem31.Location = new System.Drawing.Point(275, 169);
		this.layoutControlItem31.Name = "layoutControlItem12";
		this.layoutControlItem31.Size = new System.Drawing.Size(681, 36);
		this.layoutControlItem31.Text = "Address";
		this.layoutControlItem31.TextSize = new System.Drawing.Size(137, 22);
		this.layoutControlItem24.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem24.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem24.Control = this.txtStaffName;
		this.layoutControlItem24.CustomizationFormText = "Surname";
		this.layoutControlItem24.Location = new System.Drawing.Point(275, 36);
		this.layoutControlItem24.Name = "layoutControlItem5";
		this.layoutControlItem24.Size = new System.Drawing.Size(681, 36);
		this.layoutControlItem24.Text = "Name";
		this.layoutControlItem24.TextSize = new System.Drawing.Size(137, 22);
		this.layoutControlItem33.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem33.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem33.Control = this.cboEmplSex;
		this.layoutControlItem33.CustomizationFormText = "Other names";
		this.layoutControlItem33.Location = new System.Drawing.Point(275, 72);
		this.layoutControlItem33.Name = "layoutControlItem6";
		this.layoutControlItem33.Size = new System.Drawing.Size(340, 36);
		this.layoutControlItem33.Text = "Sex";
		this.layoutControlItem33.TextSize = new System.Drawing.Size(137, 22);
		this.layoutControlItem2.Control = this.labelControl1;
		this.layoutControlItem2.Location = new System.Drawing.Point(275, 108);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(681, 25);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem26.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem26.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem26.Control = this.dtEmplHireDate;
		this.layoutControlItem26.CustomizationFormText = "Date of birth";
		this.layoutControlItem26.Location = new System.Drawing.Point(275, 266);
		this.layoutControlItem26.Name = "layoutControlItem8";
		this.layoutControlItem26.Size = new System.Drawing.Size(681, 36);
		this.layoutControlItem26.Text = "Hire Date";
		this.layoutControlItem26.TextSize = new System.Drawing.Size(137, 22);
		this.layoutControlItem3.Control = this.labelControl2;
		this.layoutControlItem3.Location = new System.Drawing.Point(275, 241);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(681, 25);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem6.Control = this.txtEmplNotes;
		this.layoutControlItem6.Location = new System.Drawing.Point(275, 586);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(681, 142);
		this.layoutControlItem6.Text = "Notes";
		this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
		this.layoutControlItem6.TextSize = new System.Drawing.Size(137, 19);
		this.layoutControlItem7.Control = this.picStaff;
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(275, 283);
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextVisible = false;
		this.layoutControlItem8.Control = this.simpleButton4;
		this.layoutControlItem8.Location = new System.Drawing.Point(139, 283);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(136, 36);
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem9.Control = this.simpleButton3;
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 283);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(139, 36);
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 319);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(275, 409);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(13, 6);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(120, 33);
		this.simpleButton2.TabIndex = 19;
		this.simpleButton2.Text = "Close";
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(819, 6);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(130, 33);
		this.simpleButton1.TabIndex = 13;
		this.simpleButton1.Text = "Next";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.navigationFrame1.Controls.Add(this.navigationPage1);
		this.navigationFrame1.Controls.Add(this.navigationPage2);
		this.navigationFrame1.Controls.Add(this.navigationPage3);
		this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.navigationFrame1.Location = new System.Drawing.Point(0, 0);
		this.navigationFrame1.Name = "navigationFrame1";
		this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[3] { this.navigationPage1, this.navigationPage2, this.navigationPage3 });
		this.navigationFrame1.SelectedPage = this.navigationPage1;
		this.navigationFrame1.Size = new System.Drawing.Size(962, 734);
		this.navigationFrame1.TabIndex = 14;
		this.navigationFrame1.Text = "navigationFrame1";
		this.navigationPage1.Caption = "navigationPage1";
		this.navigationPage1.Controls.Add(this.layoutEmployeeData);
		this.navigationPage1.Name = "navigationPage1";
		this.navigationPage1.Size = new System.Drawing.Size(962, 734);
		this.navigationPage2.Caption = "navigationPage2";
		this.navigationPage2.Controls.Add(this.layoutControl1);
		this.navigationPage2.Name = "navigationPage2";
		this.navigationPage2.Size = new System.Drawing.Size(962, 734);
		this.layoutControl1.Controls.Add(this.labelControl3);
		this.layoutControl1.Controls.Add(this.grdPayments);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(962, 734);
		this.layoutControl1.TabIndex = 1;
		this.layoutControl1.Text = "layoutControl1";
		this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.labelControl3.Appearance.Options.UseFont = true;
		this.labelControl3.Location = new System.Drawing.Point(4, 4);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(236, 29);
		this.labelControl3.StyleController = this.layoutControl1;
		this.labelControl3.TabIndex = 4;
		this.labelControl3.Text = ">> Monthly Payments";
		this.grdPayments.Location = new System.Drawing.Point(4, 37);
		this.grdPayments.MainView = this.grvPayments;
		this.grdPayments.Name = "grdPayments";
		this.grdPayments.Size = new System.Drawing.Size(954, 693);
		this.grdPayments.TabIndex = 0;
		this.grdPayments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.grvPayments });
		this.grvPayments.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.grvPayments.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.grvPayments.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.grvPayments.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.DetailTip.Options.UseFont = true;
		this.grvPayments.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.Empty.Options.UseFont = true;
		this.grvPayments.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.EvenRow.Options.UseFont = true;
		this.grvPayments.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.FilterCloseButton.Options.UseFont = true;
		this.grvPayments.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.FilterPanel.Options.UseFont = true;
		this.grvPayments.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.FixedLine.Options.UseFont = true;
		this.grvPayments.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.FocusedCell.Options.UseFont = true;
		this.grvPayments.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.FocusedRow.Options.UseFont = true;
		this.grvPayments.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.FooterPanel.Options.UseFont = true;
		this.grvPayments.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.GroupButton.Options.UseFont = true;
		this.grvPayments.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.GroupFooter.Options.UseFont = true;
		this.grvPayments.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.GroupPanel.Options.UseFont = true;
		this.grvPayments.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.GroupRow.Options.UseFont = true;
		this.grvPayments.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.HeaderPanel.Options.UseFont = true;
		this.grvPayments.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.HideSelectionRow.Options.UseFont = true;
		this.grvPayments.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.HorzLine.Options.UseFont = true;
		this.grvPayments.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.OddRow.Options.UseFont = true;
		this.grvPayments.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.Preview.Options.UseFont = true;
		this.grvPayments.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.Row.Options.UseFont = true;
		this.grvPayments.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.RowSeparator.Options.UseFont = true;
		this.grvPayments.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.SelectedRow.Options.UseFont = true;
		this.grvPayments.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.TopNewRow.Options.UseFont = true;
		this.grvPayments.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.VertLine.Options.UseFont = true;
		this.grvPayments.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvPayments.Appearance.ViewCaption.Options.UseFont = true;
		this.grvPayments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[5] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5 });
		this.grvPayments.GridControl = this.grdPayments;
		this.grvPayments.Name = "grvPayments";
		this.grvPayments.OptionsView.EnableAppearanceEvenRow = true;
		this.grvPayments.OptionsView.ShowGroupPanel = false;
		this.grvPayments.OptionsView.ShowIndicator = false;
		this.grvPayments.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(grvPayments_CellValueChanged);
		this.gridColumn1.Caption = "StaffId";
		this.gridColumn1.FieldName = "StaffId";
		this.gridColumn1.MinWidth = 30;
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Width = 112;
		this.gridColumn2.Caption = "Payable";
		this.gridColumn2.FieldName = "IsActive";
		this.gridColumn2.MinWidth = 30;
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 0;
		this.gridColumn2.Width = 179;
		this.gridColumn3.Caption = "Item ID No.";
		this.gridColumn3.FieldName = "subAccountNo";
		this.gridColumn3.MinWidth = 30;
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.OptionsColumn.ReadOnly = true;
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 1;
		this.gridColumn3.Width = 275;
		this.gridColumn4.Caption = "Item";
		this.gridColumn4.FieldName = "SubAccoutName";
		this.gridColumn4.MinWidth = 30;
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.OptionsColumn.AllowEdit = false;
		this.gridColumn4.OptionsColumn.ReadOnly = true;
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 2;
		this.gridColumn4.Width = 522;
		this.gridColumn5.Caption = "Amount";
		this.gridColumn5.DisplayFormat.FormatString = "#,#.0";
		this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn5.FieldName = "Rate";
		this.gridColumn5.MinWidth = 30;
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 3;
		this.gridColumn5.Width = 538;
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlItem1, this.layoutControlItem4 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.Root.Size = new System.Drawing.Size(962, 734);
		this.layoutControlItem1.Control = this.grdPayments;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 33);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(958, 697);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem4.Control = this.labelControl3;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(958, 33);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.navigationPage3.Caption = "navigationPage3";
		this.navigationPage3.Controls.Add(this.layoutControl2);
		this.navigationPage3.Name = "navigationPage3";
		this.navigationPage3.Size = new System.Drawing.Size(962, 734);
		this.layoutControl2.Controls.Add(this.labelControl4);
		this.layoutControl2.Controls.Add(this.simpleButton6);
		this.layoutControl2.Controls.Add(this.simpleButton5);
		this.layoutControl2.Controls.Add(this.grdDeductions);
		this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl2.Location = new System.Drawing.Point(0, 0);
		this.layoutControl2.Name = "layoutControl2";
		this.layoutControl2.Root = this.layoutControlGroup1;
		this.layoutControl2.Size = new System.Drawing.Size(962, 734);
		this.layoutControl2.TabIndex = 3;
		this.layoutControl2.Text = "layoutControl2";
		this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.labelControl4.Appearance.Options.UseFont = true;
		this.labelControl4.Location = new System.Drawing.Point(4, 4);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(249, 29);
		this.labelControl4.StyleController = this.layoutControl2;
		this.labelControl4.TabIndex = 4;
		this.labelControl4.Text = ">> Monthly Deductions";
		this.simpleButton6.Enabled = false;
		this.simpleButton6.Location = new System.Drawing.Point(843, 73);
		this.simpleButton6.Name = "simpleButton6";
		this.simpleButton6.Size = new System.Drawing.Size(115, 32);
		this.simpleButton6.StyleController = this.layoutControl2;
		this.simpleButton6.TabIndex = 2;
		this.simpleButton6.Text = "Delete";
		this.simpleButton6.Click += new System.EventHandler(simpleButton6_Click);
		this.simpleButton5.Location = new System.Drawing.Point(843, 37);
		this.simpleButton5.Name = "simpleButton5";
		this.simpleButton5.Size = new System.Drawing.Size(115, 32);
		this.simpleButton5.StyleController = this.layoutControl2;
		this.simpleButton5.TabIndex = 1;
		this.simpleButton5.Text = "Add New";
		this.simpleButton5.Click += new System.EventHandler(simpleButton5_Click);
		this.grdDeductions.Location = new System.Drawing.Point(4, 37);
		this.grdDeductions.MainView = this.grvDeductions;
		this.grdDeductions.Name = "grdDeductions";
		this.grdDeductions.Size = new System.Drawing.Size(835, 693);
		this.grdDeductions.TabIndex = 0;
		this.grdDeductions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.grvDeductions });
		this.grvDeductions.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.grvDeductions.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.grvDeductions.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.grvDeductions.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.DetailTip.Options.UseFont = true;
		this.grvDeductions.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.Empty.Options.UseFont = true;
		this.grvDeductions.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.EvenRow.Options.UseFont = true;
		this.grvDeductions.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.FilterCloseButton.Options.UseFont = true;
		this.grvDeductions.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.FilterPanel.Options.UseFont = true;
		this.grvDeductions.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.FixedLine.Options.UseFont = true;
		this.grvDeductions.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.FocusedCell.Options.UseFont = true;
		this.grvDeductions.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.FocusedRow.Options.UseFont = true;
		this.grvDeductions.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.FooterPanel.Options.UseFont = true;
		this.grvDeductions.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.GroupButton.Options.UseFont = true;
		this.grvDeductions.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.GroupFooter.Options.UseFont = true;
		this.grvDeductions.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.GroupPanel.Options.UseFont = true;
		this.grvDeductions.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.GroupRow.Options.UseFont = true;
		this.grvDeductions.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.HeaderPanel.Options.UseFont = true;
		this.grvDeductions.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.HideSelectionRow.Options.UseFont = true;
		this.grvDeductions.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.HorzLine.Options.UseFont = true;
		this.grvDeductions.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.OddRow.Options.UseFont = true;
		this.grvDeductions.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.Preview.Options.UseFont = true;
		this.grvDeductions.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.Row.Options.UseFont = true;
		this.grvDeductions.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.RowSeparator.Options.UseFont = true;
		this.grvDeductions.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.SelectedRow.Options.UseFont = true;
		this.grvDeductions.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.TopNewRow.Options.UseFont = true;
		this.grvDeductions.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.VertLine.Options.UseFont = true;
		this.grvDeductions.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.grvDeductions.Appearance.ViewCaption.Options.UseFont = true;
		this.grvDeductions.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[4] { this.gridColumn6, this.gridColumn7, this.gridColumn8, this.gridColumn9 });
		this.grvDeductions.GridControl = this.grdDeductions;
		this.grvDeductions.Name = "grvDeductions";
		this.grvDeductions.OptionsView.EnableAppearanceEvenRow = true;
		this.grvDeductions.OptionsView.ShowGroupPanel = false;
		this.grvDeductions.OptionsView.ShowIndicator = false;
		this.grvDeductions.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(grvDeductions_RowClick);
		this.grvDeductions.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(grvDeductions_FocusedRowChanged);
		this.grvDeductions.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(grvDeductions_CellValueChanged);
		this.gridColumn6.Caption = "Item Id. No.";
		this.gridColumn6.FieldName = "id";
		this.gridColumn6.MinWidth = 30;
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.OptionsColumn.AllowEdit = false;
		this.gridColumn6.OptionsColumn.ReadOnly = true;
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 0;
		this.gridColumn6.Width = 112;
		this.gridColumn7.Caption = "StaffId";
		this.gridColumn7.FieldName = "StaffId";
		this.gridColumn7.MinWidth = 30;
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.Width = 112;
		this.gridColumn8.Caption = "Item";
		this.gridColumn8.FieldName = "Particulars";
		this.gridColumn8.MinWidth = 30;
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.OptionsColumn.AllowEdit = false;
		this.gridColumn8.OptionsColumn.ReadOnly = true;
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 1;
		this.gridColumn8.Width = 112;
		this.gridColumn9.Caption = "Amount";
		this.gridColumn9.DisplayFormat.FormatString = "#,#";
		this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn9.FieldName = "Rate";
		this.gridColumn9.MinWidth = 30;
		this.gridColumn9.Name = "gridColumn9";
		this.gridColumn9.Visible = true;
		this.gridColumn9.VisibleIndex = 2;
		this.gridColumn9.Width = 112;
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[4] { this.layoutControlItem10, this.layoutControlItem12, this.layoutControlItem11, this.layoutControlItem13 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(962, 734);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem10.Control = this.grdDeductions;
		this.layoutControlItem10.Location = new System.Drawing.Point(0, 33);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(839, 697);
		this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem10.TextVisible = false;
		this.layoutControlItem12.Control = this.simpleButton6;
		this.layoutControlItem12.Location = new System.Drawing.Point(839, 69);
		this.layoutControlItem12.Name = "layoutControlItem12";
		this.layoutControlItem12.Size = new System.Drawing.Size(119, 661);
		this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem12.TextVisible = false;
		this.layoutControlItem11.Control = this.simpleButton5;
		this.layoutControlItem11.Location = new System.Drawing.Point(839, 33);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(119, 36);
		this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem11.TextVisible = false;
		this.layoutControlItem13.Control = this.labelControl4;
		this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem13.Name = "layoutControlItem13";
		this.layoutControlItem13.Size = new System.Drawing.Size(958, 33);
		this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem13.TextVisible = false;
		this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
		this.splitContainerControl1.Horizontal = false;
		this.splitContainerControl1.IsSplitterFixed = true;
		this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
		this.splitContainerControl1.Name = "splitContainerControl1";
		this.splitContainerControl1.Panel1.Controls.Add(this.navigationFrame1);
		this.splitContainerControl1.Panel1.Text = "Panel1";
		this.splitContainerControl1.Panel2.Controls.Add(this.btnBack);
		this.splitContainerControl1.Panel2.Controls.Add(this.simpleButton1);
		this.splitContainerControl1.Panel2.Controls.Add(this.simpleButton2);
		this.splitContainerControl1.Panel2.Text = "Panel2";
		this.splitContainerControl1.Size = new System.Drawing.Size(962, 791);
		this.splitContainerControl1.SplitterPosition = 50;
		this.splitContainerControl1.TabIndex = 23;
		this.btnBack.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.btnBack.Appearance.Options.UseFont = true;
		this.btnBack.Enabled = false;
		this.btnBack.Location = new System.Drawing.Point(683, 6);
		this.btnBack.Name = "btnBack";
		this.btnBack.Size = new System.Drawing.Size(130, 33);
		this.btnBack.TabIndex = 20;
		this.btnBack.Text = "Back";
		this.btnBack.Click += new System.EventHandler(btnBack_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(144f, 144f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		base.ClientSize = new System.Drawing.Size(962, 791);
		base.Controls.Add(this.splitContainerControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Margin = new System.Windows.Forms.Padding(4);
		base.MaximizeBox = false;
		base.Name = "EmployeeAdmission";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Employee Admission";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(EmployeeAdmission_FormClosed);
		base.Load += new System.EventHandler(EmployeeAdmission_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutEmployeeData).EndInit();
		this.layoutEmployeeData.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtEmplNotes.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picStaff.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.radioGroup6.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboEmplHouse.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplFormerEmployee.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit22.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplAddress.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplContactNumber.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStaffName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStaffNumber.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtEmplHireDate.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtEmplHireDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtResponsibility.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboEmplSex.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtQualification.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem23).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem32).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem93).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem29).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem27).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem28).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem30).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem31).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem24).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem33).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem26).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.navigationFrame1).EndInit();
		this.navigationFrame1.ResumeLayout(false);
		this.navigationPage1.ResumeLayout(false);
		this.navigationPage2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.grdPayments).EndInit();
		((System.ComponentModel.ISupportInitialize)this.grvPayments).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		this.navigationPage3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControl2).EndInit();
		this.layoutControl2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.grdDeductions).EndInit();
		((System.ComponentModel.ISupportInitialize)this.grvDeductions).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).EndInit();
		this.splitContainerControl1.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
