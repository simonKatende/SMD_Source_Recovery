using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.dSetStaffTableAdapters;

namespace I_Xtreme;

public class AddSupplier : XtraForm
{
	public StartOrStopTimer StartTimer;

	private IContainer components = null;

	private LabelControl labelControl62;

	private LabelControl labelControl61;

	private LabelControl labelControl60;

	private TextEdit txtSupplierPhone;

	private LabelControl labelControl59;

	private TextEdit txtSupplierCity;

	private LabelControl labelControl58;

	private TextEdit txtSupplierOthername;

	private LabelControl labelControl57;

	private TextEdit txtSupplierEmail;

	private LabelControl labelControl56;

	private TextEdit txtSupplierMobile;

	private TextEdit txtSupplierStreet1;

	private LabelControl labelControl54;

	private TextEdit txtSupplierStreet;

	private LabelControl labelControl53;

	private TextEdit txtSupplierCompany;

	private LabelControl labelControl52;

	private TextEdit txtSupplierJobTitle;

	private LabelControl labelControl51;

	private LabelControl labelControl50;

	private TextEdit txtSupplierBoxNo;

	private TextEdit txtSupplierSurname;

	private MemoEdit txtSupplierNotes;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private StaffTableAdapter staffTableAdapter;

	private LabelControl labelControl1;

	public AddSupplier()
	{
		InitializeComponent();
	}

	private void AddNewSupplier()
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_Suppliers(Surname,OtherNames,Phone,Mobile,Street,Street1,BoxNo,City,Email,JobTitle,Company,Notes)VALUES(@Surname,@OtherNames,@Phone,@Mobile,@Street,@Street1,@BoxNo,@City,@Email,@JobTitle,@Company,@Notes)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Surname", SqlDbType.VarChar, 50);
			sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSupplierSurname.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@OtherNames", SqlDbType.VarChar, 50);
			sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSupplierOthername.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Phone", SqlDbType.VarChar, 12);
			sqlParameter.Value = txtSupplierPhone.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Mobile", SqlDbType.VarChar, 10);
			sqlParameter.Value = txtSupplierMobile.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Street", SqlDbType.VarChar, 50);
			sqlParameter.Value = txtSupplierStreet.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Street1", SqlDbType.VarChar, 50);
			sqlParameter.Value = txtSupplierStreet1.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@BoxNo", SqlDbType.VarChar, 30);
			sqlParameter.Value = txtSupplierBoxNo.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@City", SqlDbType.VarChar, 30);
			sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSupplierCity.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar, 50);
			sqlParameter.Value = txtSupplierEmail.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@JobTitle", SqlDbType.VarChar, 30);
			sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSupplierJobTitle.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Company", SqlDbType.VarChar, 50);
			sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSupplierCompany.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Notes", SqlDbType.VarChar, 200);
			sqlParameter.Value = txtSupplierNotes.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				sqlConnection.Close();
				StartTimer(timerStatus: true);
				txtSupplierBoxNo.Text = string.Empty;
				txtSupplierCity.Text = string.Empty;
				txtSupplierCompany.Text = string.Empty;
				txtSupplierEmail.Text = string.Empty;
				txtSupplierJobTitle.Text = string.Empty;
				txtSupplierMobile.Text = string.Empty;
				txtSupplierNotes.Text = string.Empty;
				txtSupplierOthername.Text = string.Empty;
				txtSupplierPhone.Text = string.Empty;
				txtSupplierStreet.Text = string.Empty;
				txtSupplierStreet1.Text = string.Empty;
				txtSupplierSurname.Text = string.Empty;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void UpdateSuppliers()
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "UPDATE tbl_Suppliers SET Surname=@Surname,OtherNames=@OtherNames,Phone=@Phone,Mobile=@Mobile,Street=@Street,Street1=@Street1,BoxNo=@BoxNo,City=@City,Email=@Email,JobTitle=@JobTitle,Company=@Company,Notes=@Notes WHERE SupplierCode=@SupplierCode",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@SupplierCode", SqlDbType.BigInt);
			sqlParameter.Value = SupplierOptions.ActiveSupplierID;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Surname", SqlDbType.VarChar, 50);
			sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSupplierSurname.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@OtherNames", SqlDbType.VarChar, 50);
			sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSupplierOthername.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Phone", SqlDbType.VarChar, 12);
			sqlParameter.Value = txtSupplierPhone.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Mobile", SqlDbType.VarChar, 10);
			sqlParameter.Value = txtSupplierMobile.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Street", SqlDbType.VarChar, 50);
			sqlParameter.Value = txtSupplierStreet.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Street1", SqlDbType.VarChar, 50);
			sqlParameter.Value = txtSupplierStreet1.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@BoxNo", SqlDbType.VarChar, 30);
			sqlParameter.Value = txtSupplierBoxNo.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@City", SqlDbType.VarChar, 30);
			sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSupplierCity.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar, 50);
			sqlParameter.Value = txtSupplierEmail.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@JobTitle", SqlDbType.VarChar, 30);
			sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSupplierJobTitle.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Company", SqlDbType.VarChar, 50);
			sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSupplierCompany.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Notes", SqlDbType.VarChar, 200);
			sqlParameter.Value = txtSupplierNotes.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				sqlConnection.Close();
				Dispose();
				StartTimer(timerStatus: true);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (Text == "Add New Supplier")
		{
			AddNewSupplier();
		}
		else if (Text == "Edit Supplier")
		{
			UpdateSuppliers();
		}
	}

	private void AddSupplier_Load(object sender, EventArgs e)
	{
		if (!(Text == "Edit Supplier"))
		{
			return;
		}
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_Suppliers WHERE SupplierCode=" + SupplierOptions.ActiveSupplierID, selectConnection);
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "suppliers");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		foreach (DataRow row in dataTable.Rows)
		{
			txtSupplierSurname.Text = row["Surname"].ToString();
			txtSupplierBoxNo.Text = row["BoxNo"].ToString();
			txtSupplierCity.Text = row["City"].ToString();
			txtSupplierCompany.Text = row["Company"].ToString();
			txtSupplierEmail.Text = row["Email"].ToString();
			txtSupplierJobTitle.Text = row["JobTitle"].ToString();
			txtSupplierMobile.Text = row["Mobile"].ToString();
			txtSupplierNotes.Text = row["Notes"].ToString();
			txtSupplierOthername.Text = row["Othernames"].ToString();
			txtSupplierPhone.Text = row["Phone"].ToString();
			txtSupplierStreet.Text = row["Street"].ToString();
			txtSupplierStreet1.Text = row["Street1"].ToString();
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
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
		this.labelControl62 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl61 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl60 = new DevExpress.XtraEditors.LabelControl();
		this.txtSupplierPhone = new DevExpress.XtraEditors.TextEdit();
		this.labelControl59 = new DevExpress.XtraEditors.LabelControl();
		this.txtSupplierCity = new DevExpress.XtraEditors.TextEdit();
		this.labelControl58 = new DevExpress.XtraEditors.LabelControl();
		this.txtSupplierOthername = new DevExpress.XtraEditors.TextEdit();
		this.labelControl57 = new DevExpress.XtraEditors.LabelControl();
		this.txtSupplierEmail = new DevExpress.XtraEditors.TextEdit();
		this.labelControl56 = new DevExpress.XtraEditors.LabelControl();
		this.txtSupplierMobile = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplierStreet1 = new DevExpress.XtraEditors.TextEdit();
		this.labelControl54 = new DevExpress.XtraEditors.LabelControl();
		this.txtSupplierStreet = new DevExpress.XtraEditors.TextEdit();
		this.labelControl53 = new DevExpress.XtraEditors.LabelControl();
		this.txtSupplierCompany = new DevExpress.XtraEditors.TextEdit();
		this.labelControl52 = new DevExpress.XtraEditors.LabelControl();
		this.txtSupplierJobTitle = new DevExpress.XtraEditors.TextEdit();
		this.labelControl51 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl50 = new DevExpress.XtraEditors.LabelControl();
		this.txtSupplierBoxNo = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplierSurname = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplierNotes = new DevExpress.XtraEditors.MemoEdit();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.staffTableAdapter = new I_Xtreme.dSetStaffTableAdapters.StaffTableAdapter();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierPhone.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierCity.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierOthername.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierEmail.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierMobile.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierStreet1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierStreet.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierCompany.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierJobTitle.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierBoxNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierSurname.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierNotes.Properties).BeginInit();
		base.SuspendLayout();
		this.labelControl62.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl62.Location = new System.Drawing.Point(7, 269);
		this.labelControl62.Name = "labelControl62";
		this.labelControl62.Size = new System.Drawing.Size(32, 13);
		this.labelControl62.TabIndex = 59;
		this.labelControl62.Text = "Notes:";
		this.labelControl61.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl61.Location = new System.Drawing.Point(26, 19);
		this.labelControl61.Name = "labelControl61";
		this.labelControl61.Size = new System.Drawing.Size(49, 13);
		this.labelControl61.TabIndex = 58;
		this.labelControl61.Text = "Company:";
		this.labelControl60.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl60.Location = new System.Drawing.Point(281, 235);
		this.labelControl60.Name = "labelControl60";
		this.labelControl60.Size = new System.Drawing.Size(28, 13);
		this.labelControl60.TabIndex = 57;
		this.labelControl60.Text = "Email:";
		this.txtSupplierPhone.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierPhone.EnterMoveNextControl = true;
		this.txtSupplierPhone.Location = new System.Drawing.Point(81, 124);
		this.txtSupplierPhone.Name = "txtSupplierPhone";
		this.txtSupplierPhone.Properties.MaxLength = 12;
		this.txtSupplierPhone.Size = new System.Drawing.Size(198, 20);
		this.txtSupplierPhone.TabIndex = 3;
		this.labelControl59.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl59.Location = new System.Drawing.Point(286, 209);
		this.labelControl59.Name = "labelControl59";
		this.labelControl59.Size = new System.Drawing.Size(23, 13);
		this.labelControl59.TabIndex = 56;
		this.labelControl59.Text = "City:";
		this.txtSupplierCity.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierCity.EnterMoveNextControl = true;
		this.txtSupplierCity.Location = new System.Drawing.Point(315, 202);
		this.txtSupplierCity.Name = "txtSupplierCity";
		this.txtSupplierCity.Properties.MaxLength = 30;
		this.txtSupplierCity.Size = new System.Drawing.Size(184, 20);
		this.txtSupplierCity.TabIndex = 8;
		this.labelControl58.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl58.Location = new System.Drawing.Point(285, 131);
		this.labelControl58.Name = "labelControl58";
		this.labelControl58.Size = new System.Drawing.Size(24, 13);
		this.labelControl58.TabIndex = 55;
		this.labelControl58.Text = "Mob:";
		this.txtSupplierOthername.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierOthername.EnterMoveNextControl = true;
		this.txtSupplierOthername.Location = new System.Drawing.Point(81, 98);
		this.txtSupplierOthername.Name = "txtSupplierOthername";
		this.txtSupplierOthername.Properties.MaxLength = 50;
		this.txtSupplierOthername.Size = new System.Drawing.Size(418, 20);
		this.txtSupplierOthername.TabIndex = 2;
		this.labelControl57.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl57.Location = new System.Drawing.Point(14, 105);
		this.labelControl57.Name = "labelControl57";
		this.labelControl57.Size = new System.Drawing.Size(61, 13);
		this.labelControl57.TabIndex = 54;
		this.labelControl57.Text = "Other name:";
		this.txtSupplierEmail.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierEmail.EnterMoveNextControl = true;
		this.txtSupplierEmail.Location = new System.Drawing.Point(315, 228);
		this.txtSupplierEmail.Name = "txtSupplierEmail";
		this.txtSupplierEmail.Properties.MaxLength = 50;
		this.txtSupplierEmail.Size = new System.Drawing.Size(184, 20);
		this.txtSupplierEmail.TabIndex = 10;
		this.labelControl56.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl56.Location = new System.Drawing.Point(31, 235);
		this.labelControl56.Name = "labelControl56";
		this.labelControl56.Size = new System.Drawing.Size(44, 13);
		this.labelControl56.TabIndex = 53;
		this.labelControl56.Text = "Job Title:";
		this.txtSupplierMobile.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierMobile.EnterMoveNextControl = true;
		this.txtSupplierMobile.Location = new System.Drawing.Point(315, 124);
		this.txtSupplierMobile.Name = "txtSupplierMobile";
		this.txtSupplierMobile.Properties.MaxLength = 10;
		this.txtSupplierMobile.Size = new System.Drawing.Size(184, 20);
		this.txtSupplierMobile.TabIndex = 4;
		this.txtSupplierStreet1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierStreet1.EnterMoveNextControl = true;
		this.txtSupplierStreet1.Location = new System.Drawing.Point(81, 176);
		this.txtSupplierStreet1.Name = "txtSupplierStreet1";
		this.txtSupplierStreet1.Properties.MaxLength = 50;
		this.txtSupplierStreet1.Size = new System.Drawing.Size(418, 20);
		this.txtSupplierStreet1.TabIndex = 6;
		this.labelControl54.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl54.Location = new System.Drawing.Point(37, 209);
		this.labelControl54.Name = "labelControl54";
		this.labelControl54.Size = new System.Drawing.Size(38, 13);
		this.labelControl54.TabIndex = 51;
		this.labelControl54.Text = "Box No.";
		this.txtSupplierStreet.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierStreet.EnterMoveNextControl = true;
		this.txtSupplierStreet.Location = new System.Drawing.Point(81, 150);
		this.txtSupplierStreet.Name = "txtSupplierStreet";
		this.txtSupplierStreet.Properties.MaxLength = 50;
		this.txtSupplierStreet.Size = new System.Drawing.Size(418, 20);
		this.txtSupplierStreet.TabIndex = 5;
		this.labelControl53.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl53.Location = new System.Drawing.Point(32, 183);
		this.labelControl53.Name = "labelControl53";
		this.labelControl53.Size = new System.Drawing.Size(43, 13);
		this.labelControl53.TabIndex = 50;
		this.labelControl53.Text = "Street 1:";
		this.txtSupplierCompany.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierCompany.EnterMoveNextControl = true;
		this.txtSupplierCompany.Location = new System.Drawing.Point(81, 12);
		this.txtSupplierCompany.Name = "txtSupplierCompany";
		this.txtSupplierCompany.Properties.MaxLength = 50;
		this.txtSupplierCompany.Size = new System.Drawing.Size(418, 20);
		this.txtSupplierCompany.TabIndex = 0;
		this.labelControl52.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl52.Location = new System.Drawing.Point(41, 157);
		this.labelControl52.Name = "labelControl52";
		this.labelControl52.Size = new System.Drawing.Size(34, 13);
		this.labelControl52.TabIndex = 49;
		this.labelControl52.Text = "Street:";
		this.txtSupplierJobTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierJobTitle.EnterMoveNextControl = true;
		this.txtSupplierJobTitle.Location = new System.Drawing.Point(81, 228);
		this.txtSupplierJobTitle.Name = "txtSupplierJobTitle";
		this.txtSupplierJobTitle.Properties.MaxLength = 30;
		this.txtSupplierJobTitle.Size = new System.Drawing.Size(198, 20);
		this.txtSupplierJobTitle.TabIndex = 9;
		this.labelControl51.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl51.Location = new System.Drawing.Point(41, 131);
		this.labelControl51.Name = "labelControl51";
		this.labelControl51.Size = new System.Drawing.Size(34, 13);
		this.labelControl51.TabIndex = 48;
		this.labelControl51.Text = "Phone:";
		this.labelControl50.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl50.Location = new System.Drawing.Point(29, 77);
		this.labelControl50.Name = "labelControl50";
		this.labelControl50.Size = new System.Drawing.Size(46, 13);
		this.labelControl50.TabIndex = 47;
		this.labelControl50.Text = "Surname:";
		this.txtSupplierBoxNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierBoxNo.EnterMoveNextControl = true;
		this.txtSupplierBoxNo.Location = new System.Drawing.Point(81, 202);
		this.txtSupplierBoxNo.Name = "txtSupplierBoxNo";
		this.txtSupplierBoxNo.Properties.Mask.EditMask = "\\d+";
		this.txtSupplierBoxNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
		this.txtSupplierBoxNo.Properties.MaxLength = 30;
		this.txtSupplierBoxNo.Size = new System.Drawing.Size(198, 20);
		this.txtSupplierBoxNo.TabIndex = 7;
		this.txtSupplierSurname.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierSurname.EnterMoveNextControl = true;
		this.txtSupplierSurname.Location = new System.Drawing.Point(81, 70);
		this.txtSupplierSurname.Name = "txtSupplierSurname";
		this.txtSupplierSurname.Properties.MaxLength = 50;
		this.txtSupplierSurname.Size = new System.Drawing.Size(418, 20);
		this.txtSupplierSurname.TabIndex = 1;
		this.txtSupplierNotes.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtSupplierNotes.Location = new System.Drawing.Point(7, 288);
		this.txtSupplierNotes.Name = "txtSupplierNotes";
		this.txtSupplierNotes.Properties.MaxLength = 200;
		this.txtSupplierNotes.Size = new System.Drawing.Size(492, 75);
		this.txtSupplierNotes.TabIndex = 11;
		this.simpleButton1.Location = new System.Drawing.Point(7, 375);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(235, 23);
		this.simpleButton1.TabIndex = 12;
		this.simpleButton1.Text = "Save";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.Location = new System.Drawing.Point(262, 375);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(235, 23);
		this.simpleButton2.TabIndex = 62;
		this.simpleButton2.Text = "Cancel";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.staffTableAdapter.ClearBeforeFill = true;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Visible = true;
		this.labelControl1.Location = new System.Drawing.Point(14, 40);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(485, 24);
		this.labelControl1.TabIndex = 63;
		this.labelControl1.Text = "Contact Person";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(506, 405);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.labelControl62);
		base.Controls.Add(this.labelControl61);
		base.Controls.Add(this.labelControl60);
		base.Controls.Add(this.txtSupplierPhone);
		base.Controls.Add(this.labelControl59);
		base.Controls.Add(this.txtSupplierCity);
		base.Controls.Add(this.labelControl58);
		base.Controls.Add(this.txtSupplierOthername);
		base.Controls.Add(this.labelControl57);
		base.Controls.Add(this.txtSupplierEmail);
		base.Controls.Add(this.labelControl56);
		base.Controls.Add(this.txtSupplierMobile);
		base.Controls.Add(this.txtSupplierStreet1);
		base.Controls.Add(this.labelControl54);
		base.Controls.Add(this.txtSupplierStreet);
		base.Controls.Add(this.labelControl53);
		base.Controls.Add(this.txtSupplierCompany);
		base.Controls.Add(this.labelControl52);
		base.Controls.Add(this.txtSupplierJobTitle);
		base.Controls.Add(this.labelControl51);
		base.Controls.Add(this.labelControl50);
		base.Controls.Add(this.txtSupplierBoxNo);
		base.Controls.Add(this.txtSupplierSurname);
		base.Controls.Add(this.txtSupplierNotes);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "AddSupplier";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Add Supplier";
		base.Load += new System.EventHandler(AddSupplier_Load);
		((System.ComponentModel.ISupportInitialize)this.txtSupplierPhone.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierCity.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierOthername.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierEmail.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierMobile.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierStreet1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierStreet.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierCompany.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierJobTitle.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierBoxNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierSurname.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierNotes.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
