using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class CashTransferscs : XtraForm
{
	private SqlTransaction _trans;

	private DataTable _dt_TA;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private TextEdit txtTargetAccNo;

	private TextEdit txtSourceAccNo;

	private MemoEdit txtNarration;

	private DateEdit dateEdit1;

	private TextEdit txtTransferAmount;

	private TextEdit txtTargetAccBalance;

	private TextEdit txtSourceAccBalance;

	private ComboBoxEdit cboTarget;

	private ComboBoxEdit cboSource;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlGroup layoutControlGroup2;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlGroup layoutControlGroup3;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlItem layoutControlItem9;

	private SimpleButton simpleButton1;

	private LayoutControlItem layoutControlItem10;

	private Timer timer1;

	public CashTransferscs()
	{
		InitializeComponent();
		LoadTransactingAccount();
	}

	private double LoadTransactingAccountBalance(string accNo)
	{
		double result = 0.0;
		try
		{
			string selectCommandText = "SELECT SUM(ISNULL(Debit,0))-SUM(ISNULL(Credit,0)) AS Total FROM tbl_StatementOfAffairs WHERE _date <= '" + FinalAccounts.BooksClosinggDate.ToString("MM-dd-yyyy") + "' AND accNo='" + accNo + "'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccountStandingBalance");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			IEnumerator enumerator = dataTable.Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					result = (double.TryParse(dataRow["Total"].ToString(), out result) ? result : 0.0);
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
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return result;
	}

	private void LoadTransactingAccount()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT gas.subAccountNo,gas.SubAccoutName,ga.accName AS accType FROM tbl_generalAccounts ga RIGHT OUTER JOIN tbl_generalAccounts_Sub gas ON gas.accNo = ga.accNo GROUP BY gas.subAccountNo,gas.SubAccoutName,ga.accName HAVING  (ga.accName = 'Bank Accounts' OR ga.accName = 'Cash' OR ga.accName = 'Mobile Money')", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccountStandingBalance");
			_dt_TA = new DataTable();
			_dt_TA = dataSet.Tables[0];
			cboSource.Properties.Items.Clear();
			cboTarget.Properties.Items.Clear();
			foreach (DataRow row in _dt_TA.Rows)
			{
				cboSource.Properties.Items.Add(row["SubAccoutName"]);
				cboTarget.Properties.Items.Add(row["SubAccoutName"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void cboSource_Closed(object sender, ClosedEventArgs e)
	{
		if (cboSource.SelectedIndex > -1)
		{
			DataRow dataRow = _dt_TA.Rows[cboSource.SelectedIndex];
			txtSourceAccNo.Text = dataRow["subAccountNo"].ToString();
			txtSourceAccBalance.Text = LoadTransactingAccountBalance(dataRow["subAccountNo"].ToString()).ToString("#,#.0");
		}
	}

	private void cboTarget_Closed(object sender, ClosedEventArgs e)
	{
		if (cboTarget.SelectedIndex > -1)
		{
			DataRow dataRow = _dt_TA.Rows[cboTarget.SelectedIndex];
			txtTargetAccNo.Text = dataRow["subAccountNo"].ToString();
			txtTargetAccBalance.Text = LoadTransactingAccountBalance(dataRow["subAccountNo"].ToString()).ToString("#,#.0");
		}
	}

	private void MakeCashTransfer()
	{
		try
		{
			DateTime dateTime = dateEdit1.DateTime;
			double result = (double.TryParse(txtTransferAmount.Text, out result) ? result : 0.0);
			CaptureDate captureDate = new CaptureDate();
			string captureDate2 = CaptureDate.GetCaptureDate();
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			_trans = sqlConnection.BeginTransaction();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Transaction = _trans,
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Credit,captureDate,Narration) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Credit,@captureDate,@Narration)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
				sqlParameter.Value = txtSourceAccNo.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
				sqlParameter.Value = $"TRANSFER TO {cboTarget.SelectedItem.ToString()}-{txtNarration.Text}";
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
				sqlParameter.Value = WorkingSemesters.GetWorkingSemester();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@_date", SqlDbType.DateTime);
				sqlParameter.Value = dateTime.ToShortDateString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@month", SqlDbType.VarChar, 9);
				sqlParameter.Value = dateTime.ToString("MMMM");
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@year", SqlDbType.Int);
				sqlParameter.Value = dateTime.Year;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Credit", SqlDbType.Money);
				sqlParameter.Value = result;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
				sqlParameter.Value = captureDate2;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Narration", SqlDbType.VarChar);
				sqlParameter.Value = txtNarration.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Transaction = _trans,
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,captureDate,Narration) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@captureDate,@Narration)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
				sqlParameter2.Value = txtTargetAccNo.Text;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
				sqlParameter2.Value = $"TRANSFER FROM {cboSource.SelectedItem.ToString()}-{txtNarration.Text}";
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
				sqlParameter2.Value = WorkingSemesters.GetWorkingSemester();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@_date", SqlDbType.DateTime);
				sqlParameter2.Value = dateTime.ToShortDateString();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@month", SqlDbType.VarChar, 9);
				sqlParameter2.Value = dateTime.ToString("MMMM");
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@year", SqlDbType.Int);
				sqlParameter2.Value = dateTime.Year;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Debit", SqlDbType.Money);
				sqlParameter2.Value = result;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
				sqlParameter2.Value = captureDate2;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Narration", SqlDbType.VarChar);
				sqlParameter2.Value = txtNarration.Text;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			_trans.Commit();
			XtraMessageBox.Show("Transfer Succeful", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			sqlConnection.Close();
			Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (cboSource.SelectedItem.ToString() != cboTarget.SelectedItem.ToString())
		{
			if (cboSource.SelectedIndex > -1 && cboTarget.SelectedIndex > -1)
			{
				if (Convert.ToDouble(txtTransferAmount.Text) <= Convert.ToDouble(txtSourceAccBalance.Text))
				{
					MakeCashTransfer();
				}
				else
				{
					XtraMessageBox.Show("Sorry! You cannot transfer funds greater than the source account balance.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				XtraMessageBox.Show("You must choose a Source and Destination account for this transaction.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		else
		{
			XtraMessageBox.Show("Sorry! We cannot transfer funds between similary accounts.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(txtTransferAmount.Text) && !string.IsNullOrEmpty(dateEdit1.Text))
		{
			simpleButton1.Enabled = true;
		}
		else
		{
			simpleButton1.Enabled = false;
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtTargetAccNo = new DevExpress.XtraEditors.TextEdit();
		this.txtSourceAccNo = new DevExpress.XtraEditors.TextEdit();
		this.txtNarration = new DevExpress.XtraEditors.MemoEdit();
		this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
		this.txtTransferAmount = new DevExpress.XtraEditors.TextEdit();
		this.txtTargetAccBalance = new DevExpress.XtraEditors.TextEdit();
		this.txtSourceAccBalance = new DevExpress.XtraEditors.TextEdit();
		this.cboTarget = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboSource = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtTargetAccNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSourceAccNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtNarration.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtTransferAmount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtTargetAccBalance.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSourceAccBalance.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboTarget.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSource.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.txtTargetAccNo);
		this.layoutControl1.Controls.Add(this.txtSourceAccNo);
		this.layoutControl1.Controls.Add(this.txtNarration);
		this.layoutControl1.Controls.Add(this.dateEdit1);
		this.layoutControl1.Controls.Add(this.txtTransferAmount);
		this.layoutControl1.Controls.Add(this.txtTargetAccBalance);
		this.layoutControl1.Controls.Add(this.txtSourceAccBalance);
		this.layoutControl1.Controls.Add(this.cboTarget);
		this.layoutControl1.Controls.Add(this.cboSource);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(578, 503);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(303, 465);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(259, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 13;
		this.simpleButton1.Text = "Execute Transfer";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.txtTargetAccNo.Location = new System.Drawing.Point(303, 101);
		this.txtTargetAccNo.Name = "txtTargetAccNo";
		this.txtTargetAccNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtTargetAccNo.Properties.Appearance.Options.UseFont = true;
		this.txtTargetAccNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtTargetAccNo.Properties.ReadOnly = true;
		this.txtTargetAccNo.Size = new System.Drawing.Size(259, 24);
		this.txtTargetAccNo.StyleController = this.layoutControl1;
		this.txtTargetAccNo.TabIndex = 12;
		this.txtSourceAccNo.Location = new System.Drawing.Point(16, 101);
		this.txtSourceAccNo.Name = "txtSourceAccNo";
		this.txtSourceAccNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtSourceAccNo.Properties.Appearance.Options.UseFont = true;
		this.txtSourceAccNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtSourceAccNo.Properties.ReadOnly = true;
		this.txtSourceAccNo.Size = new System.Drawing.Size(259, 24);
		this.txtSourceAccNo.StyleController = this.layoutControl1;
		this.txtSourceAccNo.TabIndex = 11;
		this.txtNarration.Location = new System.Drawing.Point(303, 251);
		this.txtNarration.Name = "txtNarration";
		this.txtNarration.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtNarration.Properties.Appearance.Options.UseFont = true;
		this.txtNarration.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtNarration.Properties.MaxLength = 50;
		this.txtNarration.Size = new System.Drawing.Size(259, 210);
		this.txtNarration.StyleController = this.layoutControl1;
		this.txtNarration.TabIndex = 10;
		this.dateEdit1.EditValue = null;
		this.dateEdit1.Location = new System.Drawing.Point(404, 204);
		this.dateEdit1.Name = "dateEdit1";
		this.dateEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.dateEdit1.Properties.Appearance.Options.UseFont = true;
		this.dateEdit1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10f);
		this.dateEdit1.Properties.AppearanceDropDown.Options.UseFont = true;
		this.dateEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dateEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.dateEdit1.Size = new System.Drawing.Size(158, 24);
		this.dateEdit1.StyleController = this.layoutControl1;
		this.dateEdit1.TabIndex = 9;
		this.txtTransferAmount.Location = new System.Drawing.Point(404, 176);
		this.txtTransferAmount.Name = "txtTransferAmount";
		this.txtTransferAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtTransferAmount.Properties.Appearance.Options.UseFont = true;
		this.txtTransferAmount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtTransferAmount.Properties.Mask.EditMask = "n0";
		this.txtTransferAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtTransferAmount.Size = new System.Drawing.Size(158, 24);
		this.txtTransferAmount.StyleController = this.layoutControl1;
		this.txtTransferAmount.TabIndex = 8;
		this.txtTargetAccBalance.Location = new System.Drawing.Point(303, 148);
		this.txtTargetAccBalance.Name = "txtTargetAccBalance";
		this.txtTargetAccBalance.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtTargetAccBalance.Properties.Appearance.Options.UseFont = true;
		this.txtTargetAccBalance.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtTargetAccBalance.Properties.ReadOnly = true;
		this.txtTargetAccBalance.Size = new System.Drawing.Size(259, 24);
		this.txtTargetAccBalance.StyleController = this.layoutControl1;
		this.txtTargetAccBalance.TabIndex = 7;
		this.txtSourceAccBalance.Location = new System.Drawing.Point(16, 148);
		this.txtSourceAccBalance.Name = "txtSourceAccBalance";
		this.txtSourceAccBalance.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtSourceAccBalance.Properties.Appearance.Options.UseFont = true;
		this.txtSourceAccBalance.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtSourceAccBalance.Properties.ReadOnly = true;
		this.txtSourceAccBalance.Size = new System.Drawing.Size(259, 24);
		this.txtSourceAccBalance.StyleController = this.layoutControl1;
		this.txtSourceAccBalance.TabIndex = 6;
		this.cboTarget.Location = new System.Drawing.Point(303, 54);
		this.cboTarget.Name = "cboTarget";
		this.cboTarget.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboTarget.Properties.Appearance.Options.UseFont = true;
		this.cboTarget.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboTarget.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboTarget.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboTarget.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboTarget.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboTarget.Size = new System.Drawing.Size(259, 24);
		this.cboTarget.StyleController = this.layoutControl1;
		this.cboTarget.TabIndex = 5;
		this.cboTarget.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboTarget_Closed);
		this.cboSource.Location = new System.Drawing.Point(16, 54);
		this.cboSource.Name = "cboSource";
		this.cboSource.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboSource.Properties.Appearance.Options.UseFont = true;
		this.cboSource.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboSource.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboSource.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSource.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboSource.Size = new System.Drawing.Size(259, 24);
		this.cboSource.StyleController = this.layoutControl1;
		this.cboSource.TabIndex = 4;
		this.cboSource.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboSource_Closed);
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlGroup2, this.layoutControlGroup3 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(578, 503);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlGroup2.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlGroup2.AppearanceGroup.ForeColor = System.Drawing.Color.FromArgb(0, 64, 0);
		this.layoutControlGroup2.AppearanceGroup.Options.UseFont = true;
		this.layoutControlGroup2.AppearanceGroup.Options.UseForeColor = true;
		this.layoutControlGroup2.CustomizationFormText = "Source Account";
		this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem3, this.layoutControlItem8 });
		this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup2.Name = "layoutControlGroup2";
		this.layoutControlGroup2.Size = new System.Drawing.Size(287, 499);
		this.layoutControlGroup2.Text = "Source Account";
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.cboSource;
		this.layoutControlItem1.CustomizationFormText = "Source";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(263, 47);
		this.layoutControlItem1.Text = "Source";
		this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(97, 16);
		this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem3.Control = this.txtSourceAccBalance;
		this.layoutControlItem3.CustomizationFormText = "Account Balance";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 94);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(263, 362);
		this.layoutControlItem3.Text = "Account Balance";
		this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem3.TextSize = new System.Drawing.Size(97, 16);
		this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem8.Control = this.txtSourceAccNo;
		this.layoutControlItem8.CustomizationFormText = "Acc#";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 47);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(263, 47);
		this.layoutControlItem8.Text = "Acc#";
		this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem8.TextSize = new System.Drawing.Size(97, 16);
		this.layoutControlGroup3.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlGroup3.AppearanceGroup.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.layoutControlGroup3.AppearanceGroup.Options.UseFont = true;
		this.layoutControlGroup3.AppearanceGroup.Options.UseForeColor = true;
		this.layoutControlGroup3.CustomizationFormText = "Destination Account";
		this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[7] { this.layoutControlItem2, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7, this.layoutControlItem9, this.layoutControlItem10 });
		this.layoutControlGroup3.Location = new System.Drawing.Point(287, 0);
		this.layoutControlGroup3.Name = "layoutControlGroup3";
		this.layoutControlGroup3.Size = new System.Drawing.Size(287, 499);
		this.layoutControlGroup3.Text = "Destination Account";
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.cboTarget;
		this.layoutControlItem2.CustomizationFormText = "Destination";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(263, 47);
		this.layoutControlItem2.Text = "Destination";
		this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem2.TextSize = new System.Drawing.Size(97, 16);
		this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem4.Control = this.txtTargetAccBalance;
		this.layoutControlItem4.CustomizationFormText = "Account Balance";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 94);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(263, 47);
		this.layoutControlItem4.Text = "Account Balance";
		this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem4.TextSize = new System.Drawing.Size(97, 16);
		this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = true;
		this.layoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.layoutControlItem5.Control = this.txtTransferAmount;
		this.layoutControlItem5.CustomizationFormText = "Transfer Amount";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 141);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(263, 28);
		this.layoutControlItem5.Text = "Transfer Amount";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(97, 16);
		this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem6.AppearanceItemCaption.Options.UseTextOptions = true;
		this.layoutControlItem6.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.layoutControlItem6.Control = this.dateEdit1;
		this.layoutControlItem6.CustomizationFormText = "Date";
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 169);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(263, 28);
		this.layoutControlItem6.Text = "Date";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(97, 16);
		this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem7.Control = this.txtNarration;
		this.layoutControlItem7.CustomizationFormText = "Narration";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 197);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(263, 233);
		this.layoutControlItem7.Text = "Narration";
		this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem7.TextSize = new System.Drawing.Size(97, 16);
		this.layoutControlItem9.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem9.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem9.Control = this.txtTargetAccNo;
		this.layoutControlItem9.CustomizationFormText = "Acc#";
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 47);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(263, 47);
		this.layoutControlItem9.Text = "Acc#";
		this.layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem9.TextSize = new System.Drawing.Size(97, 16);
		this.layoutControlItem10.Control = this.simpleButton1;
		this.layoutControlItem10.CustomizationFormText = "Execute Transfer";
		this.layoutControlItem10.Location = new System.Drawing.Point(0, 430);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(263, 26);
		this.layoutControlItem10.Text = "Execute Transfer";
		this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem10.TextVisible = false;
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(578, 503);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.Name = "CashTransferscs";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Cash Transfer";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtTargetAccNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSourceAccNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtNarration.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtTransferAmount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtTargetAccBalance.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSourceAccBalance.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboTarget.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSource.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		base.ResumeLayout(false);
	}
}
