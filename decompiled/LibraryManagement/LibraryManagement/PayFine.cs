using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;

namespace LibraryManagement;

public class PayFine : XtraForm
{
	private SqlTransaction trans;

	private IContainer components = null;

	private SimpleButton simpleButton2;

	private LabelControl labelControl11;

	private LabelControl labelControl10;

	private LabelControl labelControl6;

	private TextEdit txtAmountFine;

	private DateEdit dtFine;

	private ComboBoxEdit cboSemesterFine;

	private SimpleButton simpleButton1;

	private GroupControl groupControl2;

	private LabelControl labelControl9;

	private TextEdit txtReturnDueDate;

	private LabelControl labelControl8;

	private LabelControl labelControl7;

	private TextEdit txtReturnBorrowDate;

	private TextEdit txtReturnReference;

	private TextEdit txtReturnTitle;

	private LookUpEdit lookUpFines;

	private LabelControl labelControl5;

	private GroupControl groupControl1;

	private LabelControl labelControl4;

	private LabelControl labelControl3;

	private LabelControl labelControl2;

	private TextEdit txtReturnStudentClass;

	private LabelControl labelControl1;

	private TextEdit txtReturnStudentName;

	private TextEdit txtReturnStudentnumber;

	private PictureEdit pictureStudentReturn;

	private LookUpEdit lookUpReturnStudent;

	private Timer timer1;

	public PayFine()
	{
		InitializeComponent();
	}

	private void LoadLookUp()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT fullName AS Name, StudentNumber AS StudentNo,ClassId AS Class,Picture FROM tbl_Stud", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentList");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			lookUpReturnStudent.Properties.DataSource = dataTable;
			lookUpReturnStudent.Properties.DisplayMember = "StudentNo";
			lookUpReturnStudent.Properties.ValueMember = "Name";
			LookUpColumnInfoCollection columns = lookUpReturnStudent.Properties.Columns;
			columns.Add(new LookUpColumnInfo("Name", 0));
			columns.Add(new LookUpColumnInfo("StudentNo", 0));
			columns.Add(new LookUpColumnInfo("Class", 0));
			lookUpReturnStudent.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
			lookUpReturnStudent.Properties.SearchMode = SearchMode.AutoComplete;
			lookUpReturnStudent.Properties.AutoSearchColumnIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void PayFine_Load(object sender, EventArgs e)
	{
		LoadLookUp();
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		try
		{
			double num = Convert.ToDouble(txtAmountFine.Text) + Convert.ToDouble(txtReturnBorrowDate.Text);
			double num2 = Convert.ToDouble(txtReturnReference.Text) - num;
			string text = "";
			text = ((!(num > Convert.ToDouble(txtReturnReference.Text)) && !(num2 <= 0.0)) ? "Not Cleared" : "Cleared");
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			trans = sqlConnection.BeginTransaction();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = "INSERT INTO Income (DateOfIncome,SourceOfIncome,Amount,SemesterId,Creditor,Narration,CaptureDate) VALUES (@DateOfIncome,@SourceOfIncome,@Amount,@SemesterId,@Creditor,@Narration,@CaptureDate)",
				CommandType = CommandType.Text
			})
			{
				DateTime now = DateTime.Now;
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@DateOfIncome", SqlDbType.DateTime);
				sqlParameter.Value = dtFine.DateTime.ToShortDateString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@SourceOfIncome", SqlDbType.VarChar, 50);
				sqlParameter.Value = "Library Fines";
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Amount", SqlDbType.Money);
				sqlParameter.Value = Convert.ToDouble(txtAmountFine.Text);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
				sqlParameter.Value = cboSemesterFine.SelectedItem;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Creditor", SqlDbType.VarChar, 50);
				sqlParameter.Value = txtReturnStudentnumber.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Narration", SqlDbType.VarChar, 50);
				sqlParameter.Value = txtReturnTitle.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@CaptureDate", SqlDbType.VarChar, 100);
				sqlParameter.Value = DateTime.Now.ToOADate();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = "UPDATE tbl_Fines SET AmountPaid=@AmountPaid,Balance=@Balance,Status=@Status WHERE FineReference=@FineReference",
				CommandType = CommandType.Text
			})
			{
				DateTime now2 = DateTime.Now;
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@AmountPaid", SqlDbType.Money);
				sqlParameter2.Value = num;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Balance", SqlDbType.Money);
				sqlParameter2.Value = num2;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Status", SqlDbType.VarChar, 15);
				sqlParameter2.Value = text;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@FineReference", SqlDbType.BigInt);
				sqlParameter2.Value = Convert.ToInt64(lookUpFines.Properties.GetDataSourceValue("Ref", lookUpFines.ItemIndex));
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			trans.Commit();
			XtraMessageBox.Show("Fine successfully paid", "Intelligent Records", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			lookUpFines.Text = "";
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void lookUpReturnStudent_EditValueChanged(object sender, EventArgs e)
	{
		try
		{
			byte[] array = new byte[0];
			array = (byte[])lookUpReturnStudent.Properties.GetDataSourceValue("Picture", lookUpReturnStudent.ItemIndex);
			using (MemoryStream stream = new MemoryStream(array))
			{
				pictureStudentReturn.Image = Image.FromStream(stream);
			}
			txtReturnStudentName.Text = lookUpReturnStudent.Properties.GetDataSourceValue("Name", lookUpReturnStudent.ItemIndex).ToString();
			txtReturnStudentClass.Text = lookUpReturnStudent.Properties.GetDataSourceValue("Class", lookUpReturnStudent.ItemIndex).ToString();
			txtReturnStudentnumber.Text = lookUpReturnStudent.Properties.GetDataSourceValue("StudentNo", lookUpReturnStudent.ItemIndex).ToString();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void txtReturnStudentnumber_TextChanged(object sender, EventArgs e)
	{
		try
		{
			lookUpFines.Properties.Columns.Clear();
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT FineReference AS Ref,StudentNumber,Reason,FineAmount,AmountPaid,Balance,Status FROM tbl_Fines WHERE StudentNumber='{txtReturnStudentnumber.Text}' AND Status='Not Cleared'", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentReturns");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			lookUpFines.Properties.DataSource = dataTable;
			lookUpFines.Properties.DisplayMember = "Ref";
			lookUpFines.Properties.ValueMember = "Reason";
			LookUpColumnInfoCollection columns = lookUpFines.Properties.Columns;
			columns.Add(new LookUpColumnInfo("Ref", 0));
			columns.Add(new LookUpColumnInfo("Reason", 0));
			lookUpFines.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
			lookUpFines.Properties.SearchMode = SearchMode.AutoComplete;
			lookUpFines.Properties.AutoSearchColumnIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void lookUpFines_EditValueChanged(object sender, EventArgs e)
	{
		txtReturnTitle.Text = lookUpFines.Text;
		txtReturnDueDate.Text = lookUpFines.Properties.GetDataSourceValue("Balance", lookUpFines.ItemIndex).ToString();
		txtReturnBorrowDate.Text = lookUpFines.Properties.GetDataSourceValue("AmountPaid", lookUpFines.ItemIndex).ToString();
		txtReturnReference.Text = lookUpFines.Properties.GetDataSourceValue("FineAmount", lookUpFines.ItemIndex).ToString();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (txtReturnTitle.Text == "" || cboSemesterFine.SelectedIndex == 0 || dtFine.Text == "" || txtAmountFine.Text == "")
		{
			simpleButton2.Enabled = false;
		}
		else
		{
			simpleButton2.Enabled = true;
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
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
		this.txtAmountFine = new DevExpress.XtraEditors.TextEdit();
		this.dtFine = new DevExpress.XtraEditors.DateEdit();
		this.cboSemesterFine = new DevExpress.XtraEditors.ComboBoxEdit();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
		this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
		this.txtReturnDueDate = new DevExpress.XtraEditors.TextEdit();
		this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
		this.txtReturnBorrowDate = new DevExpress.XtraEditors.TextEdit();
		this.txtReturnReference = new DevExpress.XtraEditors.TextEdit();
		this.txtReturnTitle = new DevExpress.XtraEditors.TextEdit();
		this.lookUpFines = new DevExpress.XtraEditors.LookUpEdit();
		this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
		this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.txtReturnStudentClass = new DevExpress.XtraEditors.TextEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.txtReturnStudentName = new DevExpress.XtraEditors.TextEdit();
		this.txtReturnStudentnumber = new DevExpress.XtraEditors.TextEdit();
		this.pictureStudentReturn = new DevExpress.XtraEditors.PictureEdit();
		this.lookUpReturnStudent = new DevExpress.XtraEditors.LookUpEdit();
		this.timer1 = new System.Windows.Forms.Timer();
		((System.ComponentModel.ISupportInitialize)this.txtAmountFine.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtFine.Properties.VistaTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtFine.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemesterFine.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl2).BeginInit();
		this.groupControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtReturnDueDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnBorrowDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnReference.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnTitle.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpFines.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).BeginInit();
		this.groupControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtReturnStudentClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnStudentName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnStudentnumber.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureStudentReturn.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpReturnStudent.Properties).BeginInit();
		base.SuspendLayout();
		this.simpleButton2.Location = new System.Drawing.Point(341, 342);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(100, 23);
		this.simpleButton2.TabIndex = 22;
		this.simpleButton2.Text = "Pay fine";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.labelControl11.Location = new System.Drawing.Point(224, 254);
		this.labelControl11.Name = "labelControl11";
		this.labelControl11.Size = new System.Drawing.Size(37, 13);
		this.labelControl11.TabIndex = 21;
		this.labelControl11.Text = "Amount";
		this.labelControl10.Location = new System.Drawing.Point(224, 227);
		this.labelControl10.Name = "labelControl10";
		this.labelControl10.Size = new System.Drawing.Size(23, 13);
		this.labelControl10.TabIndex = 20;
		this.labelControl10.Text = "Date";
		this.labelControl6.Location = new System.Drawing.Point(224, 201);
		this.labelControl6.Name = "labelControl6";
		this.labelControl6.Size = new System.Drawing.Size(45, 13);
		this.labelControl6.TabIndex = 19;
		this.labelControl6.Text = "Semester";
		this.txtAmountFine.Location = new System.Drawing.Point(280, 247);
		this.txtAmountFine.Name = "txtAmountFine";
		this.txtAmountFine.Properties.Mask.EditMask = "n";
		this.txtAmountFine.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtAmountFine.Size = new System.Drawing.Size(161, 20);
		this.txtAmountFine.TabIndex = 18;
		this.dtFine.EditValue = null;
		this.dtFine.Location = new System.Drawing.Point(280, 220);
		this.dtFine.Name = "dtFine";
		this.dtFine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtFine.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtFine.Size = new System.Drawing.Size(161, 20);
		this.dtFine.TabIndex = 17;
		this.cboSemesterFine.Location = new System.Drawing.Point(280, 194);
		this.cboSemesterFine.Name = "cboSemesterFine";
		this.cboSemesterFine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSemesterFine.Size = new System.Drawing.Size(161, 20);
		this.cboSemesterFine.TabIndex = 16;
		this.simpleButton1.Location = new System.Drawing.Point(5, 342);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(75, 23);
		this.simpleButton1.TabIndex = 15;
		this.simpleButton1.Text = "Close";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.groupControl2.Controls.Add(this.labelControl9);
		this.groupControl2.Controls.Add(this.txtReturnDueDate);
		this.groupControl2.Controls.Add(this.labelControl8);
		this.groupControl2.Controls.Add(this.labelControl7);
		this.groupControl2.Controls.Add(this.txtReturnBorrowDate);
		this.groupControl2.Controls.Add(this.txtReturnReference);
		this.groupControl2.Controls.Add(this.txtReturnTitle);
		this.groupControl2.Controls.Add(this.lookUpFines);
		this.groupControl2.Controls.Add(this.labelControl5);
		this.groupControl2.Location = new System.Drawing.Point(5, 157);
		this.groupControl2.Name = "groupControl2";
		this.groupControl2.Size = new System.Drawing.Size(201, 176);
		this.groupControl2.TabIndex = 14;
		this.groupControl2.Text = "Fine details";
		this.labelControl9.Location = new System.Drawing.Point(6, 153);
		this.labelControl9.Name = "labelControl9";
		this.labelControl9.Size = new System.Drawing.Size(37, 13);
		this.labelControl9.TabIndex = 9;
		this.labelControl9.Text = "Balance";
		this.txtReturnDueDate.Location = new System.Drawing.Point(76, 146);
		this.txtReturnDueDate.Name = "txtReturnDueDate";
		this.txtReturnDueDate.Properties.ReadOnly = true;
		this.txtReturnDueDate.Size = new System.Drawing.Size(120, 20);
		this.txtReturnDueDate.TabIndex = 8;
		this.labelControl8.Location = new System.Drawing.Point(6, 128);
		this.labelControl8.Name = "labelControl8";
		this.labelControl8.Size = new System.Drawing.Size(47, 13);
		this.labelControl8.TabIndex = 7;
		this.labelControl8.Text = "Prev. Pay";
		this.labelControl7.Location = new System.Drawing.Point(6, 103);
		this.labelControl7.Name = "labelControl7";
		this.labelControl7.Size = new System.Drawing.Size(37, 13);
		this.labelControl7.TabIndex = 6;
		this.labelControl7.Text = "Amount";
		this.txtReturnBorrowDate.Location = new System.Drawing.Point(76, 121);
		this.txtReturnBorrowDate.Name = "txtReturnBorrowDate";
		this.txtReturnBorrowDate.Properties.ReadOnly = true;
		this.txtReturnBorrowDate.Size = new System.Drawing.Size(120, 20);
		this.txtReturnBorrowDate.TabIndex = 4;
		this.txtReturnReference.Location = new System.Drawing.Point(76, 96);
		this.txtReturnReference.Name = "txtReturnReference";
		this.txtReturnReference.Properties.ReadOnly = true;
		this.txtReturnReference.Size = new System.Drawing.Size(120, 20);
		this.txtReturnReference.TabIndex = 3;
		this.txtReturnTitle.Location = new System.Drawing.Point(5, 71);
		this.txtReturnTitle.Name = "txtReturnTitle";
		this.txtReturnTitle.Properties.ReadOnly = true;
		this.txtReturnTitle.Size = new System.Drawing.Size(191, 20);
		this.txtReturnTitle.TabIndex = 2;
		this.lookUpFines.Location = new System.Drawing.Point(76, 26);
		this.lookUpFines.Name = "lookUpFines";
		this.lookUpFines.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpFines.Properties.NullText = "-Select fine-";
		this.lookUpFines.Size = new System.Drawing.Size(120, 20);
		this.lookUpFines.TabIndex = 1;
		this.lookUpFines.EditValueChanged += new System.EventHandler(lookUpFines_EditValueChanged);
		this.labelControl5.Location = new System.Drawing.Point(6, 26);
		this.labelControl5.Name = "labelControl5";
		this.labelControl5.Size = new System.Drawing.Size(25, 13);
		this.labelControl5.TabIndex = 0;
		this.labelControl5.Text = "Fines";
		this.groupControl1.Controls.Add(this.labelControl4);
		this.groupControl1.Controls.Add(this.labelControl3);
		this.groupControl1.Controls.Add(this.labelControl2);
		this.groupControl1.Controls.Add(this.txtReturnStudentClass);
		this.groupControl1.Controls.Add(this.labelControl1);
		this.groupControl1.Controls.Add(this.txtReturnStudentName);
		this.groupControl1.Controls.Add(this.txtReturnStudentnumber);
		this.groupControl1.Controls.Add(this.pictureStudentReturn);
		this.groupControl1.Controls.Add(this.lookUpReturnStudent);
		this.groupControl1.Location = new System.Drawing.Point(5, 6);
		this.groupControl1.Name = "groupControl1";
		this.groupControl1.Size = new System.Drawing.Size(436, 144);
		this.groupControl1.TabIndex = 13;
		this.groupControl1.Text = "Student details";
		this.labelControl4.Location = new System.Drawing.Point(140, 122);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(25, 13);
		this.labelControl4.TabIndex = 7;
		this.labelControl4.Text = "Class";
		this.labelControl3.Location = new System.Drawing.Point(140, 92);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(27, 13);
		this.labelControl3.TabIndex = 6;
		this.labelControl3.Text = "Name";
		this.labelControl2.Location = new System.Drawing.Point(140, 62);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(78, 13);
		this.labelControl2.TabIndex = 5;
		this.labelControl2.Text = "Student Number";
		this.txtReturnStudentClass.Location = new System.Drawing.Point(221, 115);
		this.txtReturnStudentClass.Name = "txtReturnStudentClass";
		this.txtReturnStudentClass.Properties.ReadOnly = true;
		this.txtReturnStudentClass.Size = new System.Drawing.Size(210, 20);
		this.txtReturnStudentClass.TabIndex = 4;
		this.labelControl1.Location = new System.Drawing.Point(140, 32);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(61, 13);
		this.labelControl1.TabIndex = 1;
		this.labelControl1.Text = "Find Student";
		this.txtReturnStudentName.Location = new System.Drawing.Point(221, 85);
		this.txtReturnStudentName.Name = "txtReturnStudentName";
		this.txtReturnStudentName.Properties.ReadOnly = true;
		this.txtReturnStudentName.Size = new System.Drawing.Size(210, 20);
		this.txtReturnStudentName.TabIndex = 3;
		this.txtReturnStudentnumber.Location = new System.Drawing.Point(221, 55);
		this.txtReturnStudentnumber.Name = "txtReturnStudentnumber";
		this.txtReturnStudentnumber.Properties.ReadOnly = true;
		this.txtReturnStudentnumber.Size = new System.Drawing.Size(210, 20);
		this.txtReturnStudentnumber.TabIndex = 2;
		this.txtReturnStudentnumber.TextChanged += new System.EventHandler(txtReturnStudentnumber_TextChanged);
		this.pictureStudentReturn.Location = new System.Drawing.Point(5, 25);
		this.pictureStudentReturn.Name = "pictureStudentReturn";
		this.pictureStudentReturn.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureStudentReturn.Size = new System.Drawing.Size(112, 112);
		this.pictureStudentReturn.TabIndex = 0;
		this.lookUpReturnStudent.Location = new System.Drawing.Point(221, 25);
		this.lookUpReturnStudent.Name = "lookUpReturnStudent";
		this.lookUpReturnStudent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpReturnStudent.Properties.NullText = "-Select student-";
		this.lookUpReturnStudent.Size = new System.Drawing.Size(210, 20);
		this.lookUpReturnStudent.TabIndex = 1;
		this.lookUpReturnStudent.EditValueChanged += new System.EventHandler(lookUpReturnStudent_EditValueChanged);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(447, 371);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.labelControl11);
		base.Controls.Add(this.labelControl10);
		base.Controls.Add(this.labelControl6);
		base.Controls.Add(this.txtAmountFine);
		base.Controls.Add(this.dtFine);
		base.Controls.Add(this.cboSemesterFine);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.groupControl2);
		base.Controls.Add(this.groupControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "PayFine";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Fine Payment";
		base.Load += new System.EventHandler(PayFine_Load);
		((System.ComponentModel.ISupportInitialize)this.txtAmountFine.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtFine.Properties.VistaTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtFine.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemesterFine.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl2).EndInit();
		this.groupControl2.ResumeLayout(false);
		this.groupControl2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtReturnDueDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnBorrowDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnReference.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnTitle.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpFines.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).EndInit();
		this.groupControl1.ResumeLayout(false);
		this.groupControl1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtReturnStudentClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnStudentName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnStudentnumber.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureStudentReturn.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpReturnStudent.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
