using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme;

public class editFeesPayChangeValues : XtraForm
{
	private SqlTransaction trans;

	private DataTable __dt;

	private string paymentMode = string.Empty;

	public string editMode = string.Empty;

	private readonly int paymentId = 0;

	public string bankId = string.Empty;

	public string accNo = string.Empty;

	private readonly string StudentNumber = string.Empty;

	private bool flag = false;

	private double NewValue = 0.0;

	private double OldBalance = 0.0;

	private double OldCreditValue = 0.0;

	private double OldDebitValue = 0.0;

	private IContainer components = null;

	private SimpleButton btnClose;

	private SimpleButton btnUpdate;

	private GroupControl groupControl3;

	private TextEdit txtReceipt;

	private TextEdit txtCredit;

	private TextEdit txtItem;

	private TextEdit txtDate;

	private TextEdit txtCaptureDate;

	private TextEdit txtBalance;

	private LabelControl labelControl7;

	private LabelControl labelControl6;

	private LabelControl labelControl4;

	private LabelControl labelControl3;

	private LabelControl labelControl2;

	private LabelControl labelControl8;

	private LabelControl labelControl9;

	public TextEdit txtNumber;

	public PictureEdit pictureEdit1;

	public TextEdit txtCLass;

	public TextEdit txtFullName;

	private TextEdit txtSemester;

	private LabelControl labelControl10;

	private LabelControl labelControl5;

	private TextEdit txtDebit;

	private TextEdit txtChangeValueTo;

	private LabelControl labelControl1;

	private TextEdit txtAdjustedBalance;

	private LabelControl labelControl11;

	private LabelControl labelControl12;

	private Timer timer1;

	public editFeesPayChangeValues(string _StudentNumber, int PaymentId, double Balance)
	{
		InitializeComponent();
		StudentNumber = _StudentNumber;
		paymentId = PaymentId;
		OldBalance = Balance;
	}

	public editFeesPayChangeValues()
	{
	}

	private void editFeesPay_Load(object sender, EventArgs e)
	{
		LoadSelectedEntry(paymentId);
	}

	private void LoadSelectedEntry(int paymentId)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			string selectCommandText = $"SELECT PaymentId, StudentNumber,DateOfPayment,SemesterId,Particulars,CaptureDate, Debit, Credit,ModeOfPayment FROM FeesPayment WHERE (StudentNumber = '{StudentNumber}') AND (PaymentId={paymentId})";
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "FeesPayment");
			__dt = new DataTable();
			__dt = dataSet.Tables[0];
			if (__dt.Rows.Count == 0)
			{
				txtItem.Text = string.Empty;
				txtReceipt.Text = string.Empty;
				txtDate.Text = string.Empty;
				txtCaptureDate.Text = string.Empty;
				txtCredit.Text = string.Empty;
				txtBalance.Text = string.Empty;
				txtDebit.Text = string.Empty;
				paymentMode = string.Empty;
				return;
			}
			foreach (DataRow row in __dt.Rows)
			{
				txtItem.Text = row["Particulars"].ToString();
				txtReceipt.Text = row["PaymentId"].ToString();
				txtDate.Text = Convert.ToDateTime(row["DateOfPayment"].ToString()).ToString("dd-MMM-yy");
				txtSemester.Text = row["SemesterId"].ToString();
				txtCaptureDate.Text = row["CaptureDate"].ToString();
				txtCredit.Text = Convert.ToDouble(row["Credit"].ToString()).ToString("#,#.0");
				txtBalance.Text = OldBalance.ToString("#,#.0");
				txtDebit.Text = Convert.ToDouble(row["Debit"].ToString()).ToString("#,#.0");
				paymentMode = row["ModeOfPayment"].ToString();
				OldCreditValue = Convert.ToDouble(row["Credit"].ToString());
				OldDebitValue = Convert.ToDouble(row["Debit"].ToString());
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void btnUpdate_Click(object sender, EventArgs e)
	{
		try
		{
			double result = (double.TryParse(txtChangeValueTo.Text, out result) ? result : 0.0);
			if (result > 0.0)
			{
				if (Convert.ToDouble(txtCredit.Text) == 0.0)
				{
					using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
					{
						sqlConnection.Open();
						trans = sqlConnection.BeginTransaction();
						using (SqlCommand sqlCommand = new SqlCommand
						{
							Connection = sqlConnection,
							Transaction = trans,
							CommandText = "UPDATE FeesPayment SET Debit=@Debit WHERE CaptureDate=@CaptureDate",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter = sqlCommand.Parameters.Add("@CaptureDate", SqlDbType.VarChar, 50);
							sqlParameter.Value = txtCaptureDate.Text.TrimEnd();
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Debit", SqlDbType.Money);
							sqlParameter.Value = NewValue;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlCommand.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand2 = new SqlCommand
						{
							Connection = sqlConnection,
							Transaction = trans,
							CommandText = "UPDATE tbl_StatementOfAffairs SET Debit=@Debit WHERE captureDate=@captureDate",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@captureDate", SqlDbType.VarChar, 100);
							sqlParameter2.Value = txtCaptureDate.Text.TrimEnd();
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand2.Parameters.Add("@Debit", SqlDbType.Money);
							sqlParameter2.Value = NewValue;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlCommand2.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand3 = new SqlCommand
						{
							Connection = sqlConnection,
							Transaction = trans,
							CommandText = "UPDATE tbl_Stud SET cashOnAccount=@cashOnAccount WHERE StudentNumber=@StudentNumber",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter3.Value = StudentNumber;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@cashOnAccount", SqlDbType.Money);
							sqlParameter3.Value = Convert.ToDouble(txtAdjustedBalance.Text);
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlCommand3.ExecuteNonQuery();
						}
						trans.Commit();
						sqlConnection.Close();
						flag = true;
						if (flag)
						{
							AuditTrail.CaptureActions("Update", $"Changed billed amount from {txtDebit.Text} to {txtChangeValueTo.Text}, for student {txtFullName.Text}", AuditTrail.Departments.Fees, txtNumber.Text, txtCLass.Text, Convert.ToDecimal(txtDebit.Text), Convert.ToDecimal(txtChangeValueTo.Text));
							base.DialogResult = DialogResult.OK;
							Close();
						}
						return;
					}
				}
				using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection2.Open();
				trans = sqlConnection2.BeginTransaction();
				using (SqlCommand sqlCommand4 = new SqlCommand
				{
					Connection = sqlConnection2,
					Transaction = trans,
					CommandText = "UPDATE FeesPayment SET Credit=@Credit WHERE CaptureDate=@CaptureDate",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter4 = sqlCommand4.Parameters.Add("@CaptureDate", SqlDbType.VarChar, 50);
					sqlParameter4.Value = txtCaptureDate.Text.TrimEnd();
					sqlParameter4.Direction = ParameterDirection.Input;
					sqlParameter4 = sqlCommand4.Parameters.Add("@Credit", SqlDbType.Money);
					sqlParameter4.Value = NewValue;
					sqlParameter4.Direction = ParameterDirection.Input;
					sqlCommand4.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand5 = new SqlCommand
				{
					Connection = sqlConnection2,
					Transaction = trans,
					CommandText = "UPDATE tbl_StatementOfAffairs SET Credit=@Credit WHERE captureDate=@captureDate AND (Debit=0 OR Debit IS NULL)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter5 = sqlCommand5.Parameters.Add("@captureDate", SqlDbType.VarChar, 100);
					sqlParameter5.Value = txtCaptureDate.Text.TrimEnd();
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlParameter5 = sqlCommand5.Parameters.Add("@Credit", SqlDbType.Money);
					sqlParameter5.Value = NewValue;
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlCommand5.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand6 = new SqlCommand
				{
					Connection = sqlConnection2,
					Transaction = trans,
					CommandText = "UPDATE tbl_StatementOfAffairs SET Debit=@Debit WHERE captureDate=@captureDate AND (Credit=0 OR Credit IS NULL)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter6 = sqlCommand6.Parameters.Add("@captureDate", SqlDbType.VarChar, 100);
					sqlParameter6.Value = txtCaptureDate.Text.TrimEnd();
					sqlParameter6.Direction = ParameterDirection.Input;
					sqlParameter6 = sqlCommand6.Parameters.Add("@Debit", SqlDbType.Money);
					sqlParameter6.Value = NewValue;
					sqlParameter6.Direction = ParameterDirection.Input;
					sqlCommand6.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand7 = new SqlCommand
				{
					Connection = sqlConnection2,
					Transaction = trans,
					CommandText = "UPDATE tbl_Stud SET cashOnAccount=@cashOnAccount WHERE StudentNumber=@StudentNumber",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter7 = sqlCommand7.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
					sqlParameter7.Value = StudentNumber;
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlParameter7 = sqlCommand7.Parameters.Add("@cashOnAccount", SqlDbType.Money);
					sqlParameter7.Value = Convert.ToDouble(txtAdjustedBalance.Text);
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlCommand7.ExecuteNonQuery();
				}
				trans.Commit();
				sqlConnection2.Close();
				flag = true;
				if (flag)
				{
					AuditTrail.CaptureActions("Update", $"Changed paid amount from {txtCredit.Text} to {txtChangeValueTo.Text}, for student {txtFullName.Text}", AuditTrail.Departments.Fees, txtNumber.Text, txtCLass.Text, Convert.ToDecimal(txtCredit.Text), Convert.ToDecimal(txtChangeValueTo.Text));
					base.DialogResult = DialogResult.OK;
					Close();
				}
				return;
			}
			XtraMessageBox.Show("The Change To value cannot be NULL, Zero or Negative", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void txtChangeValueTo_TextChanged(object sender, EventArgs e)
	{
		double result = (double.TryParse(txtChangeValueTo.Text, out result) ? result : 0.0);
		if (result > 0.0)
		{
			NewValue = (double.TryParse(txtChangeValueTo.Text, out NewValue) ? NewValue : 0.0);
			if (OldCreditValue > 0.0)
			{
				if (NewValue > OldCreditValue)
				{
					txtAdjustedBalance.Text = (OldBalance - (NewValue - OldCreditValue)).ToString("#,#.0");
				}
				else if (NewValue < OldCreditValue)
				{
					txtAdjustedBalance.Text = (OldBalance + (OldCreditValue - NewValue)).ToString("#,#.0");
				}
			}
			else if (NewValue > OldDebitValue)
			{
				txtAdjustedBalance.Text = (NewValue - OldDebitValue + OldBalance).ToString("#,#.0");
			}
			else if (NewValue < OldDebitValue)
			{
				txtAdjustedBalance.Text = (OldBalance - (OldDebitValue - NewValue)).ToString("#,#.0");
			}
		}
		else if (result == 0.0 || string.IsNullOrEmpty(txtChangeValueTo.Text))
		{
			txtAdjustedBalance.Text = string.Empty;
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(txtCaptureDate.Text))
		{
			btnUpdate.Enabled = true;
		}
		else
		{
			btnUpdate.Enabled = false;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (components != null)
			{
				components.Dispose();
			}
			if (trans != null)
			{
				trans.Dispose();
				trans = null;
			}
			if (__dt != null)
			{
				__dt.Dispose();
				__dt = null;
			}
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.btnClose = new DevExpress.XtraEditors.SimpleButton();
		this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
		this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
		this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
		this.txtDebit = new DevExpress.XtraEditors.TextEdit();
		this.txtSemester = new DevExpress.XtraEditors.TextEdit();
		this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.txtBalance = new DevExpress.XtraEditors.TextEdit();
		this.txtReceipt = new DevExpress.XtraEditors.TextEdit();
		this.txtCredit = new DevExpress.XtraEditors.TextEdit();
		this.txtItem = new DevExpress.XtraEditors.TextEdit();
		this.txtDate = new DevExpress.XtraEditors.TextEdit();
		this.txtCaptureDate = new DevExpress.XtraEditors.TextEdit();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.txtNumber = new DevExpress.XtraEditors.TextEdit();
		this.txtCLass = new DevExpress.XtraEditors.TextEdit();
		this.txtFullName = new DevExpress.XtraEditors.TextEdit();
		this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
		this.txtChangeValueTo = new DevExpress.XtraEditors.TextEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.txtAdjustedBalance = new DevExpress.XtraEditors.TextEdit();
		this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.groupControl3).BeginInit();
		this.groupControl3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtDebit.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSemester.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtBalance.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReceipt.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtCredit.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtCaptureDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtNumber.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtCLass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtFullName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtChangeValueTo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAdjustedBalance.Properties).BeginInit();
		base.SuspendLayout();
		this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnClose.Appearance.Options.UseFont = true;
		this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnClose.Location = new System.Drawing.Point(226, 379);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(175, 29);
		this.btnClose.TabIndex = 1;
		this.btnClose.Text = "Cancel";
		this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnUpdate.Appearance.Options.UseFont = true;
		this.btnUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.btnUpdate.Location = new System.Drawing.Point(7, 379);
		this.btnUpdate.Name = "btnUpdate";
		this.btnUpdate.Size = new System.Drawing.Size(175, 29);
		this.btnUpdate.TabIndex = 0;
		this.btnUpdate.Text = "Change Value";
		this.btnUpdate.Click += new System.EventHandler(btnUpdate_Click);
		this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.groupControl3.Controls.Add(this.labelControl5);
		this.groupControl3.Controls.Add(this.txtDebit);
		this.groupControl3.Controls.Add(this.txtSemester);
		this.groupControl3.Controls.Add(this.labelControl10);
		this.groupControl3.Controls.Add(this.labelControl7);
		this.groupControl3.Controls.Add(this.labelControl6);
		this.groupControl3.Controls.Add(this.labelControl4);
		this.groupControl3.Controls.Add(this.labelControl3);
		this.groupControl3.Controls.Add(this.labelControl2);
		this.groupControl3.Controls.Add(this.txtBalance);
		this.groupControl3.Controls.Add(this.txtReceipt);
		this.groupControl3.Controls.Add(this.txtCredit);
		this.groupControl3.Controls.Add(this.txtItem);
		this.groupControl3.Controls.Add(this.txtDate);
		this.groupControl3.Controls.Add(this.txtCaptureDate);
		this.groupControl3.Location = new System.Drawing.Point(201, 39);
		this.groupControl3.Name = "groupControl3";
		this.groupControl3.Size = new System.Drawing.Size(200, 250);
		this.groupControl3.TabIndex = 2;
		this.groupControl3.Text = "Transaction Details";
		this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl5.Location = new System.Drawing.Point(32, 170);
		this.labelControl5.Name = "labelControl5";
		this.labelControl5.Size = new System.Drawing.Size(29, 16);
		this.labelControl5.TabIndex = 16;
		this.labelControl5.Text = "Debit";
		this.txtDebit.Location = new System.Drawing.Point(64, 162);
		this.txtDebit.Name = "txtDebit";
		this.txtDebit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtDebit.Properties.Appearance.Options.UseFont = true;
		this.txtDebit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtDebit.Properties.ReadOnly = true;
		this.txtDebit.Size = new System.Drawing.Size(130, 24);
		this.txtDebit.TabIndex = 15;
		this.txtSemester.Location = new System.Drawing.Point(64, 78);
		this.txtSemester.Name = "txtSemester";
		this.txtSemester.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtSemester.Properties.Appearance.Options.UseFont = true;
		this.txtSemester.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtSemester.Properties.ReadOnly = true;
		this.txtSemester.Size = new System.Drawing.Size(130, 24);
		this.txtSemester.TabIndex = 14;
		this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl10.Location = new System.Drawing.Point(30, 86);
		this.labelControl10.Name = "labelControl10";
		this.labelControl10.Size = new System.Drawing.Size(31, 16);
		this.labelControl10.TabIndex = 13;
		this.labelControl10.Text = "Term";
		this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl7.Location = new System.Drawing.Point(17, 226);
		this.labelControl7.Name = "labelControl7";
		this.labelControl7.Size = new System.Drawing.Size(44, 16);
		this.labelControl7.TabIndex = 12;
		this.labelControl7.Text = "Balance";
		this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl6.Location = new System.Drawing.Point(27, 198);
		this.labelControl6.Name = "labelControl6";
		this.labelControl6.Size = new System.Drawing.Size(34, 16);
		this.labelControl6.TabIndex = 11;
		this.labelControl6.Text = "Credit";
		this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl4.Location = new System.Drawing.Point(35, 142);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(26, 16);
		this.labelControl4.TabIndex = 9;
		this.labelControl4.Text = "Item";
		this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl3.Location = new System.Drawing.Point(41, 114);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(20, 16);
		this.labelControl3.TabIndex = 8;
		this.labelControl3.Text = "Ref";
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl2.Location = new System.Drawing.Point(35, 58);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(26, 16);
		this.labelControl2.TabIndex = 7;
		this.labelControl2.Text = "Date";
		this.txtBalance.Location = new System.Drawing.Point(64, 218);
		this.txtBalance.Name = "txtBalance";
		this.txtBalance.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtBalance.Properties.Appearance.Options.UseFont = true;
		this.txtBalance.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtBalance.Properties.ReadOnly = true;
		this.txtBalance.Size = new System.Drawing.Size(130, 24);
		this.txtBalance.TabIndex = 6;
		this.txtReceipt.Location = new System.Drawing.Point(64, 106);
		this.txtReceipt.Name = "txtReceipt";
		this.txtReceipt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtReceipt.Properties.Appearance.Options.UseFont = true;
		this.txtReceipt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtReceipt.Properties.ReadOnly = true;
		this.txtReceipt.Size = new System.Drawing.Size(130, 24);
		this.txtReceipt.TabIndex = 4;
		this.txtCredit.Location = new System.Drawing.Point(64, 190);
		this.txtCredit.Name = "txtCredit";
		this.txtCredit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtCredit.Properties.Appearance.Options.UseFont = true;
		this.txtCredit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtCredit.Properties.ReadOnly = true;
		this.txtCredit.Size = new System.Drawing.Size(130, 24);
		this.txtCredit.TabIndex = 3;
		this.txtItem.Location = new System.Drawing.Point(64, 134);
		this.txtItem.Name = "txtItem";
		this.txtItem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtItem.Properties.Appearance.Options.UseFont = true;
		this.txtItem.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtItem.Properties.ReadOnly = true;
		this.txtItem.Size = new System.Drawing.Size(130, 24);
		this.txtItem.TabIndex = 2;
		this.txtDate.Location = new System.Drawing.Point(64, 50);
		this.txtDate.Name = "txtDate";
		this.txtDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtDate.Properties.Appearance.Options.UseFont = true;
		this.txtDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtDate.Properties.ReadOnly = true;
		this.txtDate.Size = new System.Drawing.Size(130, 24);
		this.txtDate.TabIndex = 1;
		this.txtCaptureDate.Location = new System.Drawing.Point(5, 25);
		this.txtCaptureDate.Name = "txtCaptureDate";
		this.txtCaptureDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtCaptureDate.Properties.Appearance.Options.UseFont = true;
		this.txtCaptureDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtCaptureDate.Properties.ReadOnly = true;
		this.txtCaptureDate.Size = new System.Drawing.Size(189, 24);
		this.txtCaptureDate.TabIndex = 0;
		this.pictureEdit1.Location = new System.Drawing.Point(11, 44);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(175, 177);
		this.pictureEdit1.TabIndex = 3;
		this.txtNumber.Location = new System.Drawing.Point(55, 227);
		this.txtNumber.Name = "txtNumber";
		this.txtNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtNumber.Properties.Appearance.Options.UseFont = true;
		this.txtNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtNumber.Properties.ReadOnly = true;
		this.txtNumber.Size = new System.Drawing.Size(131, 24);
		this.txtNumber.TabIndex = 4;
		this.txtCLass.Location = new System.Drawing.Point(55, 257);
		this.txtCLass.Name = "txtCLass";
		this.txtCLass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtCLass.Properties.Appearance.Options.UseFont = true;
		this.txtCLass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtCLass.Properties.ReadOnly = true;
		this.txtCLass.Size = new System.Drawing.Size(131, 24);
		this.txtCLass.TabIndex = 5;
		this.txtFullName.Location = new System.Drawing.Point(7, 8);
		this.txtFullName.Name = "txtFullName";
		this.txtFullName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtFullName.Properties.Appearance.Options.UseFont = true;
		this.txtFullName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtFullName.Properties.ReadOnly = true;
		this.txtFullName.Size = new System.Drawing.Size(394, 24);
		this.txtFullName.TabIndex = 8;
		this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl8.Location = new System.Drawing.Point(6, 237);
		this.labelControl8.Name = "labelControl8";
		this.labelControl8.Size = new System.Drawing.Size(45, 16);
		this.labelControl8.TabIndex = 9;
		this.labelControl8.Text = "Stud No";
		this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl9.Location = new System.Drawing.Point(21, 265);
		this.labelControl9.Name = "labelControl9";
		this.labelControl9.Size = new System.Drawing.Size(30, 16);
		this.labelControl9.TabIndex = 10;
		this.labelControl9.Text = "Class";
		this.txtChangeValueTo.Location = new System.Drawing.Point(132, 319);
		this.txtChangeValueTo.Name = "txtChangeValueTo";
		this.txtChangeValueTo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtChangeValueTo.Properties.Appearance.Options.UseFont = true;
		this.txtChangeValueTo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtChangeValueTo.Properties.Mask.EditMask = "n0";
		this.txtChangeValueTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtChangeValueTo.Size = new System.Drawing.Size(269, 24);
		this.txtChangeValueTo.TabIndex = 11;
		this.txtChangeValueTo.TextChanged += new System.EventHandler(txtChangeValueTo_TextChanged);
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl1.Location = new System.Drawing.Point(7, 323);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(116, 16);
		this.labelControl1.TabIndex = 13;
		this.labelControl1.Text = "Change Value To>>";
		this.txtAdjustedBalance.Location = new System.Drawing.Point(132, 349);
		this.txtAdjustedBalance.Name = "txtAdjustedBalance";
		this.txtAdjustedBalance.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtAdjustedBalance.Properties.Appearance.Options.UseFont = true;
		this.txtAdjustedBalance.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtAdjustedBalance.Properties.Mask.EditMask = "n0";
		this.txtAdjustedBalance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtAdjustedBalance.Properties.ReadOnly = true;
		this.txtAdjustedBalance.Size = new System.Drawing.Size(269, 24);
		this.txtAdjustedBalance.TabIndex = 14;
		this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl11.Location = new System.Drawing.Point(6, 353);
		this.labelControl11.Name = "labelControl11";
		this.labelControl11.Size = new System.Drawing.Size(103, 16);
		this.labelControl11.TabIndex = 15;
		this.labelControl11.Text = "Adjusted Balance:";
		this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl12.Visible = true;
		this.labelControl12.Location = new System.Drawing.Point(7, 299);
		this.labelControl12.Name = "labelControl12";
		this.labelControl12.Size = new System.Drawing.Size(394, 16);
		this.labelControl12.TabIndex = 16;
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(407, 416);
		base.Controls.Add(this.labelControl12);
		base.Controls.Add(this.labelControl11);
		base.Controls.Add(this.txtAdjustedBalance);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.txtChangeValueTo);
		base.Controls.Add(this.btnClose);
		base.Controls.Add(this.btnUpdate);
		base.Controls.Add(this.labelControl9);
		base.Controls.Add(this.labelControl8);
		base.Controls.Add(this.txtFullName);
		base.Controls.Add(this.groupControl3);
		base.Controls.Add(this.pictureEdit1);
		base.Controls.Add(this.txtCLass);
		base.Controls.Add(this.txtNumber);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "editFeesPayChangeValues";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Edit student payments";
		base.Load += new System.EventHandler(editFeesPay_Load);
		((System.ComponentModel.ISupportInitialize)this.groupControl3).EndInit();
		this.groupControl3.ResumeLayout(false);
		this.groupControl3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtDebit.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSemester.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtBalance.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReceipt.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtCredit.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtCaptureDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtNumber.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtCLass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtFullName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtChangeValueTo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAdjustedBalance.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
