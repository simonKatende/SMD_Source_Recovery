using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;

namespace LibraryManagement;

public class ReturnBooks : XtraForm
{
	private SqlTransaction trans;

	private IContainer components = null;

	private LabelControl labelControl11;

	private SimpleButton btnClose;

	private SimpleButton simpleButton1;

	private DateEdit dateEdit1;

	private LabelControl labelControl10;

	private LabelControl labelControl6;

	private TextEdit txtFineAmount;

	private ComboBoxEdit cboFineReason;

	private CheckEdit chkFine;

	private GroupControl groupControl2;

	private LabelControl labelControl9;

	private TextEdit txtReturnDueDate;

	private LabelControl labelControl8;

	private LabelControl labelControl7;

	private TextEdit txtReturnBorrowDate;

	private TextEdit txtReturnReference;

	private TextEdit txtReturnTitle;

	private LookUpEdit lookUpReturnBook;

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

	public ReturnBooks()
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

	private void lookUpReturnBook_EditValueChanged(object sender, EventArgs e)
	{
		txtReturnTitle.Text = lookUpReturnBook.Text;
		txtReturnDueDate.Text = lookUpReturnBook.Properties.GetDataSourceValue("DueDate", lookUpReturnBook.ItemIndex).ToString();
		txtReturnBorrowDate.Text = lookUpReturnBook.Properties.GetDataSourceValue("Date", lookUpReturnBook.ItemIndex).ToString();
		txtReturnReference.Text = lookUpReturnBook.Properties.GetDataSourceValue("RefNo", lookUpReturnBook.ItemIndex).ToString();
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

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (dateEdit1.Text != "")
		{
			if (!chkFine.Checked)
			{
				try
				{
					using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection.Open();
					trans = sqlConnection.BeginTransaction();
					using (SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						Transaction = trans,
						CommandText = "UPDATE tbl_Books SET Status='Available' WHERE Ref=@Ref",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Ref", SqlDbType.VarChar, 50);
						sqlParameter.Value = txtReturnReference.Text;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection,
						Transaction = trans,
						CommandText = "UPDATE tbl_BookIssue SET Status='Returned',ReturnDate=@ReturnDate WHERE BookRef=@BookRef AND StudentNumber=@StudentNumber AND Status='Not Returned'",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@BookRef", SqlDbType.VarChar, 50);
						sqlParameter2.Value = txtReturnReference.Text;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@ReturnDate", SqlDbType.DateTime);
						sqlParameter2.Value = dateEdit1.DateTime.ToShortDateString();
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter2.Value = txtReturnStudentnumber.Text;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
					}
					trans.Commit();
					XtraMessageBox.Show($"The Book: {txtReturnTitle.Text} ({txtReturnReference.Text}) has been returned successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				catch (Exception ex)
				{
					XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			if (cboFineReason.SelectedIndex != 0)
			{
				if (txtFineAmount.Text != "" || Convert.ToDouble(txtFineAmount.Text) > 0.0)
				{
					try
					{
						using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection2.Open();
						trans = sqlConnection2.BeginTransaction();
						using (SqlCommand sqlCommand3 = new SqlCommand
						{
							Connection = sqlConnection2,
							Transaction = trans,
							CommandText = "INSERT INTO tbl_Fines (StudentNumber,Reason,BookRef,Date,FineAmount,AmountPaid,Balance,Status)VALUES(@StudentNumber,@Reason,@BookRef,@Date,@FineAmount,@AmountPaid,@Balance,@Status)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter3.Value = txtReturnStudentnumber.Text;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@Reason", SqlDbType.VarChar, 50);
							sqlParameter3.Value = cboFineReason.SelectedItem;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@BookRef", SqlDbType.VarChar, 50);
							sqlParameter3.Value = txtReturnReference.Text;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@Date", SqlDbType.DateTime);
							sqlParameter3.Value = dateEdit1.DateTime.ToShortDateString();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@FineAmount", SqlDbType.VarChar, 50);
							sqlParameter3.Value = Convert.ToDouble(txtFineAmount.Text);
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@AmountPaid", SqlDbType.Money);
							sqlParameter3.Value = 0;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@Balance", SqlDbType.Money);
							sqlParameter3.Value = Convert.ToDouble(txtFineAmount.Text);
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@Status", SqlDbType.VarChar, 10);
							sqlParameter3.Value = "Not Cleared";
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlCommand3.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand4 = new SqlCommand
						{
							Connection = sqlConnection2,
							Transaction = trans,
							CommandText = "UPDATE tbl_Books SET Status='Available' WHERE Ref=@Ref",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter4 = sqlCommand4.Parameters.Add("@Ref", SqlDbType.VarChar, 50);
							sqlParameter4.Value = txtReturnReference.Text;
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlCommand4.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand5 = new SqlCommand
						{
							Connection = sqlConnection2,
							Transaction = trans,
							CommandText = "UPDATE tbl_BookIssue SET Status='Returned',ReturnDate=@ReturnDate WHERE BookRef=@BookRef AND StudentNumber=@StudentNumber AND Status='Not Returned'",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter5 = sqlCommand5.Parameters.Add("@BookRef", SqlDbType.VarChar, 50);
							sqlParameter5.Value = txtReturnReference.Text;
							sqlParameter5.Direction = ParameterDirection.Input;
							sqlParameter5 = sqlCommand5.Parameters.Add("@ReturnDate", SqlDbType.DateTime);
							sqlParameter5.Value = dateEdit1.DateTime.ToShortDateString();
							sqlParameter5.Direction = ParameterDirection.Input;
							sqlParameter5 = sqlCommand5.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter5.Value = txtReturnStudentnumber.Text;
							sqlParameter5.Direction = ParameterDirection.Input;
							sqlCommand5.ExecuteNonQuery();
						}
						trans.Commit();
						XtraMessageBox.Show($"The Book: {txtReturnTitle.Text} ({txtReturnReference.Text}) has been returned successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					catch (Exception ex2)
					{
						XtraMessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
				}
				XtraMessageBox.Show("Fine amount cannot be Blank or Zero (0)", "Intelligent Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				XtraMessageBox.Show("Please select a reason for Fining the student", "Intelligent Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		else
		{
			XtraMessageBox.Show("Please select return date", "Intelligent Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void chkFine_CheckedChanged(object sender, EventArgs e)
	{
		if (chkFine.Checked)
		{
			cboFineReason.Enabled = true;
			txtFineAmount.Properties.ReadOnly = false;
		}
		else
		{
			cboFineReason.Enabled = false;
			txtFineAmount.Properties.ReadOnly = true;
		}
	}

	private void txtReturnStudentnumber_TextChanged(object sender, EventArgs e)
	{
		try
		{
			lookUpReturnBook.Properties.Columns.Clear();
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT bi.StudentNumber,bi.BookRef AS RefNo,bi.Date AS Date,bi.DueDate AS DueDate,bi.Status,b.Ref,b.Title AS Title FROM tbl_BookIssue bi FULL OUTER JOIN tbl_Books b ON b.Ref=bi.BookRef WHERE bi.StudentNumber='{txtReturnStudentnumber.Text}' AND bi.Status='Not Returned'", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentReturns");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			lookUpReturnBook.Properties.DataSource = dataTable;
			lookUpReturnBook.Properties.DisplayMember = "Title";
			lookUpReturnBook.Properties.ValueMember = "RefNo";
			LookUpColumnInfoCollection columns = lookUpReturnBook.Properties.Columns;
			columns.Add(new LookUpColumnInfo("Title", 0));
			columns.Add(new LookUpColumnInfo("RefNo", 0));
			lookUpReturnBook.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
			lookUpReturnBook.Properties.SearchMode = SearchMode.AutoComplete;
			lookUpReturnBook.Properties.AutoSearchColumnIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void ReturnBooks_Load(object sender, EventArgs e)
	{
		LoadLookUp();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (txtReturnStudentnumber.Text != "" || txtReturnReference.Text != "")
		{
			simpleButton1.Enabled = true;
		}
		else
		{
			simpleButton1.Enabled = false;
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
		this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
		this.btnClose = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
		this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
		this.txtFineAmount = new DevExpress.XtraEditors.TextEdit();
		this.cboFineReason = new DevExpress.XtraEditors.ComboBoxEdit();
		this.chkFine = new DevExpress.XtraEditors.CheckEdit();
		this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
		this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
		this.txtReturnDueDate = new DevExpress.XtraEditors.TextEdit();
		this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
		this.txtReturnBorrowDate = new DevExpress.XtraEditors.TextEdit();
		this.txtReturnReference = new DevExpress.XtraEditors.TextEdit();
		this.txtReturnTitle = new DevExpress.XtraEditors.TextEdit();
		this.lookUpReturnBook = new DevExpress.XtraEditors.LookUpEdit();
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
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtFineAmount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboFineReason.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkFine.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl2).BeginInit();
		this.groupControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtReturnDueDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnBorrowDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnReference.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnTitle.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpReturnBook.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).BeginInit();
		this.groupControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtReturnStudentClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnStudentName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnStudentnumber.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureStudentReturn.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpReturnStudent.Properties).BeginInit();
		base.SuspendLayout();
		this.labelControl11.Location = new System.Drawing.Point(211, 251);
		this.labelControl11.Name = "labelControl11";
		this.labelControl11.Size = new System.Drawing.Size(58, 13);
		this.labelControl11.TabIndex = 23;
		this.labelControl11.Text = "Return date";
		this.btnClose.Location = new System.Drawing.Point(3, 341);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(75, 23);
		this.btnClose.TabIndex = 22;
		this.btnClose.Text = "Close";
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		this.simpleButton1.Location = new System.Drawing.Point(283, 341);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(156, 23);
		this.simpleButton1.TabIndex = 21;
		this.simpleButton1.Text = "Return book";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.dateEdit1.EditValue = null;
		this.dateEdit1.Location = new System.Drawing.Point(283, 246);
		this.dateEdit1.Name = "dateEdit1";
		this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dateEdit1.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dateEdit1.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dateEdit1.Size = new System.Drawing.Size(156, 20);
		this.dateEdit1.TabIndex = 20;
		this.labelControl10.Location = new System.Drawing.Point(211, 227);
		this.labelControl10.Name = "labelControl10";
		this.labelControl10.Size = new System.Drawing.Size(59, 13);
		this.labelControl10.TabIndex = 19;
		this.labelControl10.Text = "Fine amount";
		this.labelControl6.Location = new System.Drawing.Point(211, 201);
		this.labelControl6.Name = "labelControl6";
		this.labelControl6.Size = new System.Drawing.Size(56, 13);
		this.labelControl6.TabIndex = 18;
		this.labelControl6.Text = "Fine reason";
		this.txtFineAmount.Location = new System.Drawing.Point(283, 220);
		this.txtFineAmount.Name = "txtFineAmount";
		this.txtFineAmount.Properties.Mask.EditMask = "n";
		this.txtFineAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtFineAmount.Properties.ReadOnly = true;
		this.txtFineAmount.Size = new System.Drawing.Size(156, 20);
		this.txtFineAmount.TabIndex = 17;
		this.cboFineReason.EditValue = "-Select reason-";
		this.cboFineReason.Enabled = false;
		this.cboFineReason.Location = new System.Drawing.Point(283, 194);
		this.cboFineReason.Name = "cboFineReason";
		this.cboFineReason.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboFineReason.Properties.Items.AddRange(new object[4] { "-Select reason-", "Past due date", "Book damage", "Book loss" });
		this.cboFineReason.Size = new System.Drawing.Size(156, 20);
		this.cboFineReason.TabIndex = 16;
		this.chkFine.Location = new System.Drawing.Point(281, 154);
		this.chkFine.Name = "chkFine";
		this.chkFine.Properties.Caption = "Fine this student";
		this.chkFine.Size = new System.Drawing.Size(129, 19);
		this.chkFine.TabIndex = 15;
		this.chkFine.CheckedChanged += new System.EventHandler(chkFine_CheckedChanged);
		this.groupControl2.Controls.Add(this.labelControl9);
		this.groupControl2.Controls.Add(this.txtReturnDueDate);
		this.groupControl2.Controls.Add(this.labelControl8);
		this.groupControl2.Controls.Add(this.labelControl7);
		this.groupControl2.Controls.Add(this.txtReturnBorrowDate);
		this.groupControl2.Controls.Add(this.txtReturnReference);
		this.groupControl2.Controls.Add(this.txtReturnTitle);
		this.groupControl2.Controls.Add(this.lookUpReturnBook);
		this.groupControl2.Controls.Add(this.labelControl5);
		this.groupControl2.Location = new System.Drawing.Point(3, 156);
		this.groupControl2.Name = "groupControl2";
		this.groupControl2.Size = new System.Drawing.Size(201, 176);
		this.groupControl2.TabIndex = 14;
		this.groupControl2.Text = "Borrow details";
		this.labelControl9.Location = new System.Drawing.Point(6, 153);
		this.labelControl9.Name = "labelControl9";
		this.labelControl9.Size = new System.Drawing.Size(44, 13);
		this.labelControl9.TabIndex = 9;
		this.labelControl9.Text = "Due date";
		this.txtReturnDueDate.Location = new System.Drawing.Point(76, 146);
		this.txtReturnDueDate.Name = "txtReturnDueDate";
		this.txtReturnDueDate.Properties.ReadOnly = true;
		this.txtReturnDueDate.Size = new System.Drawing.Size(120, 20);
		this.txtReturnDueDate.TabIndex = 8;
		this.labelControl8.Location = new System.Drawing.Point(6, 128);
		this.labelControl8.Name = "labelControl8";
		this.labelControl8.Size = new System.Drawing.Size(59, 13);
		this.labelControl8.TabIndex = 7;
		this.labelControl8.Text = "Borrow date";
		this.labelControl7.Location = new System.Drawing.Point(6, 103);
		this.labelControl7.Name = "labelControl7";
		this.labelControl7.Size = new System.Drawing.Size(33, 13);
		this.labelControl7.TabIndex = 6;
		this.labelControl7.Text = "Ref No";
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
		this.lookUpReturnBook.Location = new System.Drawing.Point(76, 26);
		this.lookUpReturnBook.Name = "lookUpReturnBook";
		this.lookUpReturnBook.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpReturnBook.Properties.NullText = "-Select Book-";
		this.lookUpReturnBook.Size = new System.Drawing.Size(120, 20);
		this.lookUpReturnBook.TabIndex = 1;
		this.lookUpReturnBook.EditValueChanged += new System.EventHandler(lookUpReturnBook_EditValueChanged);
		this.labelControl5.Location = new System.Drawing.Point(6, 26);
		this.labelControl5.Name = "labelControl5";
		this.labelControl5.Size = new System.Drawing.Size(46, 13);
		this.labelControl5.TabIndex = 0;
		this.labelControl5.Text = "Find book";
		this.groupControl1.Controls.Add(this.labelControl4);
		this.groupControl1.Controls.Add(this.labelControl3);
		this.groupControl1.Controls.Add(this.labelControl2);
		this.groupControl1.Controls.Add(this.txtReturnStudentClass);
		this.groupControl1.Controls.Add(this.labelControl1);
		this.groupControl1.Controls.Add(this.txtReturnStudentName);
		this.groupControl1.Controls.Add(this.txtReturnStudentnumber);
		this.groupControl1.Controls.Add(this.pictureStudentReturn);
		this.groupControl1.Controls.Add(this.lookUpReturnStudent);
		this.groupControl1.Location = new System.Drawing.Point(3, 5);
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
		base.ClientSize = new System.Drawing.Size(445, 372);
		base.Controls.Add(this.labelControl11);
		base.Controls.Add(this.btnClose);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.dateEdit1);
		base.Controls.Add(this.labelControl10);
		base.Controls.Add(this.labelControl6);
		base.Controls.Add(this.txtFineAmount);
		base.Controls.Add(this.cboFineReason);
		base.Controls.Add(this.chkFine);
		base.Controls.Add(this.groupControl2);
		base.Controls.Add(this.groupControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "ReturnBooks";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Return Books";
		base.Load += new System.EventHandler(ReturnBooks_Load);
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtFineAmount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboFineReason.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkFine.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl2).EndInit();
		this.groupControl2.ResumeLayout(false);
		this.groupControl2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtReturnDueDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnBorrowDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnReference.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReturnTitle.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpReturnBook.Properties).EndInit();
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
