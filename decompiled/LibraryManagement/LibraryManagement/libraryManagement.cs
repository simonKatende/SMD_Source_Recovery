using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraTab;

namespace LibraryManagement;

public class libraryManagement : XtraForm
{
	private IContainer components = null;

	private XtraTabControl xtraTabControl1;

	private XtraTabPage xtraTabPage1;

	private XtraTabPage xtraTabPage2;

	private XtraTabPage xtraTabPage3;

	private LabelControl labelControl2;

	private LabelControl labelControl1;

	private TextEdit txtCategory;

	private LabelControl labelControl8;

	private LabelControl labelControl7;

	private LabelControl labelControl6;

	private LabelControl labelControl5;

	private LabelControl labelControl4;

	private LabelControl labelControl3;

	private TextEdit txtPublisherTel;

	private TextEdit txtPublisherMobile;

	private TextEdit txtPublisherState;

	private TextEdit txtPublisherCity;

	private TextEdit txtPublisherName;

	private MemoEdit txtPublisherAddress;

	private TextEdit txtAuthorName;

	private MemoEdit txtAuthorDetails;

	private LabelControl labelControl10;

	private LabelControl labelControl9;

	private XtraTabPage xtraTabPage4;

	private XtraTabPage xtraTabPage5;

	private PanelControl panelControl1;

	private SimpleButton btnSave;

	private SimpleButton btnClose;

	private LabelControl labelControl11;

	private LabelControl labelControl12;

	private LabelControl labelControl13;

	private LabelControl labelControl14;

	private LabelControl labelControl15;

	private LabelControl labelControl16;

	private TextEdit txtVendorTel;

	private TextEdit txtVendorMobile;

	private TextEdit txtVendorState;

	private TextEdit txtVendorCity;

	private TextEdit txtVendorName;

	private MemoEdit txtVendorAddress;

	private TextEdit txtLocationName;

	private MemoEdit txtLocationDetails;

	private LabelControl labelControl17;

	private LabelControl labelControl18;

	private MemoEdit txtCategoryDescription;

	private XtraTabPage xtraTabPage6;

	private TextEdit txtBookDuration;

	private TextEdit txtBookLimit;

	private LabelControl labelControl20;

	private LabelControl labelControl19;

	public libraryManagement()
	{
		InitializeComponent();
	}

	private static void AddEntries(string cmd, string message, string name, string details, string requiredName, string customMessage)
	{
		try
		{
			if (requiredName != "")
			{
				using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					sqlConnection.Open();
					using SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = cmd,
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50);
					sqlParameter.Value = name.ToUpper();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Details", SqlDbType.VarChar, 100);
					sqlParameter.Value = details;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
					XtraMessageBox.Show(message + " added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
			}
			XtraMessageBox.Show(customMessage + " name is required", "Intelligent Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static void AddV_P(string table, string message, string name, string address, string city, string state, string mobileNo, string telephoneNo, string requiredItem, string customMessage)
	{
		try
		{
			if (requiredItem != "")
			{
				using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					sqlConnection.Open();
					using SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = $"INSERT INTO {table} (Name,Address,City,State,MobileNumber,TelephoneNumber) VALUES (@Name,@Address,@City,@State,@MobileNumber,@TelephoneNumber)",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50);
					sqlParameter.Value = name.ToUpper();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Address", SqlDbType.VarChar, 100);
					sqlParameter.Value = address;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@City", SqlDbType.VarChar, 30);
					sqlParameter.Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(city);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@State", SqlDbType.VarChar, 30);
					sqlParameter.Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@MobileNumber", SqlDbType.VarChar, 30);
					sqlParameter.Value = mobileNo;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@TelephoneNumber", SqlDbType.VarChar, 30);
					sqlParameter.Value = telephoneNo;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
					XtraMessageBox.Show(message + " added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
			}
			XtraMessageBox.Show(customMessage + " name is required", "Intelligent Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (xtraTabControl1.SelectedTabPageIndex == 0)
		{
			AddEntries("Insert Into tbl_BookCategories (Name,Details) VALUES (@Name,@Details)", txtCategory.Text, txtCategory.Text, txtCategoryDescription.Text, txtCategory.Text, "Category");
			return;
		}
		if (xtraTabControl1.SelectedTabPageIndex == 1)
		{
			AddV_P("tbl_BookPublishers", txtPublisherName.Text, txtPublisherName.Text, txtPublisherAddress.Text, txtPublisherCity.Text, txtPublisherState.Text, txtPublisherMobile.Text, txtPublisherTel.Text, txtPublisherName.Text, "Publisher");
			return;
		}
		if (xtraTabControl1.SelectedTabPageIndex == 2)
		{
			AddEntries("Insert Into tbl_BookAuthors (Name,Details) VALUES (@Name,@Details)", txtAuthorName.Text, txtAuthorName.Text, txtAuthorDetails.Text, txtAuthorName.Text, "Author");
			return;
		}
		if (xtraTabControl1.SelectedTabPageIndex == 3)
		{
			AddV_P("tbl_BookVendors", txtVendorName.Text, txtVendorName.Text, txtVendorAddress.Text, txtVendorCity.Text, txtVendorState.Text, txtVendorState.Text, txtVendorTel.Text, txtVendorName.Text, "Vendor");
			return;
		}
		if (xtraTabControl1.SelectedTabPageIndex == 4)
		{
			AddEntries("Insert Into tbl_BookLocations (Name,Details) VALUES (@Name,@Details)", txtLocationName.Text, txtLocationName.Text, txtLocationDetails.Text, txtLocationName.Text, "Location");
			return;
		}
		try
		{
			if (Convert.ToInt32(txtBookDuration.Text) > 0 && Convert.ToInt32(txtBookLimit.Text) > 0)
			{
				int result = ((!int.TryParse(txtBookLimit.Text, out result)) ? 1 : result);
				int result2 = ((!int.TryParse(txtBookDuration.Text, out result2)) ? 1 : result2);
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "SELECT * FROM tbl_BookLimit",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					sqlConnection.Close();
					using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection2.Open();
					using SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						CommandText = "UPDATE tbl_BookLimit SET BookLimit=@BookLimit,BookDuration=@BookDuration",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@BookLimit", SqlDbType.Int);
					sqlParameter.Value = result;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@BookDuration", SqlDbType.Int);
					sqlParameter.Value = result2;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
					XtraMessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				sqlConnection.Close();
				using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection3.Open();
				using SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection3,
					CommandText = "INSERT INTO tbl_BookLimit (BookLimit,BookDuration) VALUES (@BookLimit,@BookDuration)",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@BookLimit", SqlDbType.Int);
				sqlParameter2.Value = result;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand3.Parameters.Add("@BookDuration", SqlDbType.Int);
				sqlParameter2.Value = result2;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand3.ExecuteNonQuery();
				XtraMessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			XtraMessageBox.Show("Book Limit and Duration cannot be Zero or less than zero", "Intelligent Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void libraryManagement_Load(object sender, EventArgs e)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_BookLimit", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "BookLimiting");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				txtBookDuration.Text = row["BookDuration"].ToString();
				txtBookLimit.Text = row["BookLimit"].ToString();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
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
		this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
		this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.txtCategory = new DevExpress.XtraEditors.TextEdit();
		this.txtCategoryDescription = new DevExpress.XtraEditors.MemoEdit();
		this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
		this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.txtPublisherTel = new DevExpress.XtraEditors.TextEdit();
		this.txtPublisherMobile = new DevExpress.XtraEditors.TextEdit();
		this.txtPublisherState = new DevExpress.XtraEditors.TextEdit();
		this.txtPublisherCity = new DevExpress.XtraEditors.TextEdit();
		this.txtPublisherName = new DevExpress.XtraEditors.TextEdit();
		this.txtPublisherAddress = new DevExpress.XtraEditors.MemoEdit();
		this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
		this.txtAuthorName = new DevExpress.XtraEditors.TextEdit();
		this.txtAuthorDetails = new DevExpress.XtraEditors.MemoEdit();
		this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
		this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
		this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
		this.txtVendorTel = new DevExpress.XtraEditors.TextEdit();
		this.txtVendorMobile = new DevExpress.XtraEditors.TextEdit();
		this.txtVendorState = new DevExpress.XtraEditors.TextEdit();
		this.txtVendorCity = new DevExpress.XtraEditors.TextEdit();
		this.txtVendorName = new DevExpress.XtraEditors.TextEdit();
		this.txtVendorAddress = new DevExpress.XtraEditors.MemoEdit();
		this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
		this.txtLocationName = new DevExpress.XtraEditors.TextEdit();
		this.txtLocationDetails = new DevExpress.XtraEditors.MemoEdit();
		this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
		this.xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
		this.txtBookDuration = new DevExpress.XtraEditors.TextEdit();
		this.txtBookLimit = new DevExpress.XtraEditors.TextEdit();
		this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.btnSave = new DevExpress.XtraEditors.SimpleButton();
		this.btnClose = new DevExpress.XtraEditors.SimpleButton();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl1).BeginInit();
		this.xtraTabControl1.SuspendLayout();
		this.xtraTabPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtCategory.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtCategoryDescription.Properties).BeginInit();
		this.xtraTabPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtPublisherTel.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPublisherMobile.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPublisherState.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPublisherCity.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPublisherName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPublisherAddress.Properties).BeginInit();
		this.xtraTabPage3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtAuthorName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAuthorDetails.Properties).BeginInit();
		this.xtraTabPage4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtVendorTel.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtVendorMobile.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtVendorState.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtVendorCity.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtVendorName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtVendorAddress.Properties).BeginInit();
		this.xtraTabPage5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtLocationName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtLocationDetails.Properties).BeginInit();
		this.xtraTabPage6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtBookDuration.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtBookLimit.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		this.panelControl1.SuspendLayout();
		base.SuspendLayout();
		this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
		this.xtraTabControl1.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
		this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
		this.xtraTabControl1.Name = "xtraTabControl1";
		this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
		this.xtraTabControl1.Size = new System.Drawing.Size(329, 212);
		this.xtraTabControl1.TabIndex = 0;
		this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[6] { this.xtraTabPage1, this.xtraTabPage2, this.xtraTabPage3, this.xtraTabPage4, this.xtraTabPage5, this.xtraTabPage6 });
		this.xtraTabPage1.Controls.Add(this.labelControl2);
		this.xtraTabPage1.Controls.Add(this.labelControl1);
		this.xtraTabPage1.Controls.Add(this.txtCategory);
		this.xtraTabPage1.Controls.Add(this.txtCategoryDescription);
		this.xtraTabPage1.Name = "xtraTabPage1";
		this.xtraTabPage1.Size = new System.Drawing.Size(231, 206);
		this.xtraTabPage1.Text = "Book Categories";
		this.labelControl2.Location = new System.Drawing.Point(3, 47);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(32, 13);
		this.labelControl2.TabIndex = 3;
		this.labelControl2.Text = "Details";
		this.labelControl1.Location = new System.Drawing.Point(3, 19);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(27, 13);
		this.labelControl1.TabIndex = 2;
		this.labelControl1.Text = "Name";
		this.txtCategory.Location = new System.Drawing.Point(42, 12);
		this.txtCategory.Name = "txtCategory";
		this.txtCategory.Size = new System.Drawing.Size(183, 20);
		this.txtCategory.TabIndex = 0;
		this.txtCategoryDescription.Location = new System.Drawing.Point(42, 39);
		this.txtCategoryDescription.Name = "txtCategoryDescription";
		this.txtCategoryDescription.Size = new System.Drawing.Size(183, 160);
		this.txtCategoryDescription.TabIndex = 1;
		this.xtraTabPage2.Controls.Add(this.labelControl8);
		this.xtraTabPage2.Controls.Add(this.labelControl7);
		this.xtraTabPage2.Controls.Add(this.labelControl6);
		this.xtraTabPage2.Controls.Add(this.labelControl5);
		this.xtraTabPage2.Controls.Add(this.labelControl4);
		this.xtraTabPage2.Controls.Add(this.labelControl3);
		this.xtraTabPage2.Controls.Add(this.txtPublisherTel);
		this.xtraTabPage2.Controls.Add(this.txtPublisherMobile);
		this.xtraTabPage2.Controls.Add(this.txtPublisherState);
		this.xtraTabPage2.Controls.Add(this.txtPublisherCity);
		this.xtraTabPage2.Controls.Add(this.txtPublisherName);
		this.xtraTabPage2.Controls.Add(this.txtPublisherAddress);
		this.xtraTabPage2.Name = "xtraTabPage2";
		this.xtraTabPage2.Size = new System.Drawing.Size(231, 206);
		this.xtraTabPage2.Text = "Book Publishers";
		this.labelControl8.Location = new System.Drawing.Point(4, 190);
		this.labelControl8.Name = "labelControl8";
		this.labelControl8.Size = new System.Drawing.Size(34, 13);
		this.labelControl8.TabIndex = 11;
		this.labelControl8.Text = "Tel No.";
		this.labelControl7.Location = new System.Drawing.Point(4, 166);
		this.labelControl7.Name = "labelControl7";
		this.labelControl7.Size = new System.Drawing.Size(50, 13);
		this.labelControl7.TabIndex = 10;
		this.labelControl7.Text = "Mobile No.";
		this.labelControl6.Location = new System.Drawing.Point(4, 138);
		this.labelControl6.Name = "labelControl6";
		this.labelControl6.Size = new System.Drawing.Size(30, 13);
		this.labelControl6.TabIndex = 9;
		this.labelControl6.Text = "State:";
		this.labelControl5.Location = new System.Drawing.Point(4, 112);
		this.labelControl5.Name = "labelControl5";
		this.labelControl5.Size = new System.Drawing.Size(19, 13);
		this.labelControl5.TabIndex = 8;
		this.labelControl5.Text = "City";
		this.labelControl4.Location = new System.Drawing.Point(4, 31);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(39, 13);
		this.labelControl4.TabIndex = 7;
		this.labelControl4.Text = "Address";
		this.labelControl3.Location = new System.Drawing.Point(4, 10);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(27, 13);
		this.labelControl3.TabIndex = 6;
		this.labelControl3.Text = "Name";
		this.txtPublisherTel.Location = new System.Drawing.Point(66, 183);
		this.txtPublisherTel.Name = "txtPublisherTel";
		this.txtPublisherTel.Size = new System.Drawing.Size(156, 20);
		this.txtPublisherTel.TabIndex = 5;
		this.txtPublisherMobile.Location = new System.Drawing.Point(66, 159);
		this.txtPublisherMobile.Name = "txtPublisherMobile";
		this.txtPublisherMobile.Size = new System.Drawing.Size(156, 20);
		this.txtPublisherMobile.TabIndex = 4;
		this.txtPublisherState.Location = new System.Drawing.Point(66, 131);
		this.txtPublisherState.Name = "txtPublisherState";
		this.txtPublisherState.Size = new System.Drawing.Size(156, 20);
		this.txtPublisherState.TabIndex = 3;
		this.txtPublisherCity.Location = new System.Drawing.Point(66, 105);
		this.txtPublisherCity.Name = "txtPublisherCity";
		this.txtPublisherCity.Size = new System.Drawing.Size(156, 20);
		this.txtPublisherCity.TabIndex = 2;
		this.txtPublisherName.Location = new System.Drawing.Point(66, 3);
		this.txtPublisherName.Name = "txtPublisherName";
		this.txtPublisherName.Size = new System.Drawing.Size(156, 20);
		this.txtPublisherName.TabIndex = 0;
		this.txtPublisherAddress.Location = new System.Drawing.Point(66, 29);
		this.txtPublisherAddress.Name = "txtPublisherAddress";
		this.txtPublisherAddress.Size = new System.Drawing.Size(156, 70);
		this.txtPublisherAddress.TabIndex = 1;
		this.xtraTabPage3.Controls.Add(this.txtAuthorName);
		this.xtraTabPage3.Controls.Add(this.txtAuthorDetails);
		this.xtraTabPage3.Controls.Add(this.labelControl10);
		this.xtraTabPage3.Controls.Add(this.labelControl9);
		this.xtraTabPage3.Name = "xtraTabPage3";
		this.xtraTabPage3.Size = new System.Drawing.Size(231, 206);
		this.xtraTabPage3.Text = "Book Authors";
		this.txtAuthorName.Location = new System.Drawing.Point(42, 12);
		this.txtAuthorName.Name = "txtAuthorName";
		this.txtAuthorName.Size = new System.Drawing.Size(183, 20);
		this.txtAuthorName.TabIndex = 3;
		this.txtAuthorDetails.Location = new System.Drawing.Point(42, 39);
		this.txtAuthorDetails.Name = "txtAuthorDetails";
		this.txtAuthorDetails.Size = new System.Drawing.Size(183, 160);
		this.txtAuthorDetails.TabIndex = 2;
		this.labelControl10.Location = new System.Drawing.Point(4, 43);
		this.labelControl10.Name = "labelControl10";
		this.labelControl10.Size = new System.Drawing.Size(32, 13);
		this.labelControl10.TabIndex = 1;
		this.labelControl10.Text = "Details";
		this.labelControl9.Location = new System.Drawing.Point(4, 19);
		this.labelControl9.Name = "labelControl9";
		this.labelControl9.Size = new System.Drawing.Size(27, 13);
		this.labelControl9.TabIndex = 0;
		this.labelControl9.Text = "Name";
		this.xtraTabPage4.Controls.Add(this.labelControl11);
		this.xtraTabPage4.Controls.Add(this.labelControl12);
		this.xtraTabPage4.Controls.Add(this.labelControl13);
		this.xtraTabPage4.Controls.Add(this.labelControl14);
		this.xtraTabPage4.Controls.Add(this.labelControl15);
		this.xtraTabPage4.Controls.Add(this.labelControl16);
		this.xtraTabPage4.Controls.Add(this.txtVendorTel);
		this.xtraTabPage4.Controls.Add(this.txtVendorMobile);
		this.xtraTabPage4.Controls.Add(this.txtVendorState);
		this.xtraTabPage4.Controls.Add(this.txtVendorCity);
		this.xtraTabPage4.Controls.Add(this.txtVendorName);
		this.xtraTabPage4.Controls.Add(this.txtVendorAddress);
		this.xtraTabPage4.Name = "xtraTabPage4";
		this.xtraTabPage4.Size = new System.Drawing.Size(231, 206);
		this.xtraTabPage4.Text = "Book Vendors";
		this.labelControl11.Location = new System.Drawing.Point(4, 190);
		this.labelControl11.Name = "labelControl11";
		this.labelControl11.Size = new System.Drawing.Size(34, 13);
		this.labelControl11.TabIndex = 23;
		this.labelControl11.Text = "Tel No.";
		this.labelControl12.Location = new System.Drawing.Point(4, 166);
		this.labelControl12.Name = "labelControl12";
		this.labelControl12.Size = new System.Drawing.Size(50, 13);
		this.labelControl12.TabIndex = 22;
		this.labelControl12.Text = "Mobile No.";
		this.labelControl13.Location = new System.Drawing.Point(4, 138);
		this.labelControl13.Name = "labelControl13";
		this.labelControl13.Size = new System.Drawing.Size(30, 13);
		this.labelControl13.TabIndex = 21;
		this.labelControl13.Text = "State:";
		this.labelControl14.Location = new System.Drawing.Point(4, 112);
		this.labelControl14.Name = "labelControl14";
		this.labelControl14.Size = new System.Drawing.Size(19, 13);
		this.labelControl14.TabIndex = 20;
		this.labelControl14.Text = "City";
		this.labelControl15.Location = new System.Drawing.Point(4, 31);
		this.labelControl15.Name = "labelControl15";
		this.labelControl15.Size = new System.Drawing.Size(39, 13);
		this.labelControl15.TabIndex = 19;
		this.labelControl15.Text = "Address";
		this.labelControl16.Location = new System.Drawing.Point(4, 10);
		this.labelControl16.Name = "labelControl16";
		this.labelControl16.Size = new System.Drawing.Size(27, 13);
		this.labelControl16.TabIndex = 18;
		this.labelControl16.Text = "Name";
		this.txtVendorTel.Location = new System.Drawing.Point(62, 183);
		this.txtVendorTel.Name = "txtVendorTel";
		this.txtVendorTel.Size = new System.Drawing.Size(163, 20);
		this.txtVendorTel.TabIndex = 17;
		this.txtVendorMobile.Location = new System.Drawing.Point(62, 159);
		this.txtVendorMobile.Name = "txtVendorMobile";
		this.txtVendorMobile.Size = new System.Drawing.Size(163, 20);
		this.txtVendorMobile.TabIndex = 16;
		this.txtVendorState.Location = new System.Drawing.Point(62, 131);
		this.txtVendorState.Name = "txtVendorState";
		this.txtVendorState.Size = new System.Drawing.Size(163, 20);
		this.txtVendorState.TabIndex = 15;
		this.txtVendorCity.Location = new System.Drawing.Point(62, 105);
		this.txtVendorCity.Name = "txtVendorCity";
		this.txtVendorCity.Size = new System.Drawing.Size(163, 20);
		this.txtVendorCity.TabIndex = 14;
		this.txtVendorName.Location = new System.Drawing.Point(62, 3);
		this.txtVendorName.Name = "txtVendorName";
		this.txtVendorName.Size = new System.Drawing.Size(163, 20);
		this.txtVendorName.TabIndex = 12;
		this.txtVendorAddress.Location = new System.Drawing.Point(62, 29);
		this.txtVendorAddress.Name = "txtVendorAddress";
		this.txtVendorAddress.Size = new System.Drawing.Size(163, 70);
		this.txtVendorAddress.TabIndex = 13;
		this.xtraTabPage5.Controls.Add(this.txtLocationName);
		this.xtraTabPage5.Controls.Add(this.txtLocationDetails);
		this.xtraTabPage5.Controls.Add(this.labelControl17);
		this.xtraTabPage5.Controls.Add(this.labelControl18);
		this.xtraTabPage5.Name = "xtraTabPage5";
		this.xtraTabPage5.Size = new System.Drawing.Size(231, 206);
		this.xtraTabPage5.Text = "Book Locations";
		this.txtLocationName.Location = new System.Drawing.Point(42, 12);
		this.txtLocationName.Name = "txtLocationName";
		this.txtLocationName.Size = new System.Drawing.Size(183, 20);
		this.txtLocationName.TabIndex = 7;
		this.txtLocationDetails.Location = new System.Drawing.Point(42, 39);
		this.txtLocationDetails.Name = "txtLocationDetails";
		this.txtLocationDetails.Size = new System.Drawing.Size(183, 160);
		this.txtLocationDetails.TabIndex = 6;
		this.labelControl17.Location = new System.Drawing.Point(4, 39);
		this.labelControl17.Name = "labelControl17";
		this.labelControl17.Size = new System.Drawing.Size(32, 13);
		this.labelControl17.TabIndex = 5;
		this.labelControl17.Text = "Details";
		this.labelControl18.Location = new System.Drawing.Point(4, 19);
		this.labelControl18.Name = "labelControl18";
		this.labelControl18.Size = new System.Drawing.Size(27, 13);
		this.labelControl18.TabIndex = 4;
		this.labelControl18.Text = "Name";
		this.xtraTabPage6.Controls.Add(this.txtBookDuration);
		this.xtraTabPage6.Controls.Add(this.txtBookLimit);
		this.xtraTabPage6.Controls.Add(this.labelControl20);
		this.xtraTabPage6.Controls.Add(this.labelControl19);
		this.xtraTabPage6.Name = "xtraTabPage6";
		this.xtraTabPage6.Size = new System.Drawing.Size(231, 206);
		this.xtraTabPage6.Text = "Book Limit";
		this.txtBookDuration.Location = new System.Drawing.Point(16, 92);
		this.txtBookDuration.Name = "txtBookDuration";
		this.txtBookDuration.Properties.Mask.EditMask = "f0";
		this.txtBookDuration.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtBookDuration.Size = new System.Drawing.Size(210, 20);
		this.txtBookDuration.TabIndex = 3;
		this.txtBookLimit.Location = new System.Drawing.Point(16, 32);
		this.txtBookLimit.Name = "txtBookLimit";
		this.txtBookLimit.Properties.Mask.EditMask = "f0";
		this.txtBookLimit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtBookLimit.Size = new System.Drawing.Size(210, 20);
		this.txtBookLimit.TabIndex = 2;
		this.labelControl20.Location = new System.Drawing.Point(16, 73);
		this.labelControl20.Name = "labelControl20";
		this.labelControl20.Size = new System.Drawing.Size(67, 13);
		this.labelControl20.TabIndex = 1;
		this.labelControl20.Text = "Book Duration";
		this.labelControl19.Location = new System.Drawing.Point(16, 12);
		this.labelControl19.Name = "labelControl19";
		this.labelControl19.Size = new System.Drawing.Size(47, 13);
		this.labelControl19.TabIndex = 0;
		this.labelControl19.Text = "Book Limit";
		this.panelControl1.Controls.Add(this.btnSave);
		this.panelControl1.Controls.Add(this.btnClose);
		this.panelControl1.Location = new System.Drawing.Point(2, 218);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(322, 38);
		this.panelControl1.TabIndex = 1;
		this.btnSave.Location = new System.Drawing.Point(242, 7);
		this.btnSave.Name = "btnSave";
		this.btnSave.Size = new System.Drawing.Size(75, 23);
		this.btnSave.TabIndex = 1;
		this.btnSave.Text = "Save";
		this.btnSave.Click += new System.EventHandler(btnSave_Click);
		this.btnClose.Location = new System.Drawing.Point(5, 7);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(75, 23);
		this.btnClose.TabIndex = 0;
		this.btnClose.Text = "Close";
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(329, 260);
		base.Controls.Add(this.panelControl1);
		base.Controls.Add(this.xtraTabControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "libraryManagement";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Library Management";
		base.Load += new System.EventHandler(libraryManagement_Load);
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl1).EndInit();
		this.xtraTabControl1.ResumeLayout(false);
		this.xtraTabPage1.ResumeLayout(false);
		this.xtraTabPage1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtCategory.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtCategoryDescription.Properties).EndInit();
		this.xtraTabPage2.ResumeLayout(false);
		this.xtraTabPage2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtPublisherTel.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPublisherMobile.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPublisherState.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPublisherCity.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPublisherName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPublisherAddress.Properties).EndInit();
		this.xtraTabPage3.ResumeLayout(false);
		this.xtraTabPage3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtAuthorName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAuthorDetails.Properties).EndInit();
		this.xtraTabPage4.ResumeLayout(false);
		this.xtraTabPage4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtVendorTel.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtVendorMobile.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtVendorState.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtVendorCity.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtVendorName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtVendorAddress.Properties).EndInit();
		this.xtraTabPage5.ResumeLayout(false);
		this.xtraTabPage5.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtLocationName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtLocationDetails.Properties).EndInit();
		this.xtraTabPage6.ResumeLayout(false);
		this.xtraTabPage6.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtBookDuration.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtBookLimit.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		this.panelControl1.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
