using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using AlienAge.Semesters;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class CreditorList : XtraForm
{
	public string bankAccountNo = string.Empty;

	public string cheaqueNo = string.Empty;

	public DateTime dtDate;

	private DataTable _dt_TA;

	private DataTable _dt_GP;

	private string itemAccNo = string.Empty;

	private string _creditorName = string.Empty;

	private string creditorAccountNo = string.Empty;

	private SqlTransaction trans;

	private IContainer components = null;

	private MyGridControl gridControl1;

	private MyGridView gridView1;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn3;

	private ComboBoxEdit cboGeneralParticulars;

	private TextEdit txtNarration;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private Timer timer1;

	private TextEdit txtVoucherNo;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem7;

	public TextEdit txtCheaqueTotal;

	private LabelControl labelControl2;

	public CreditorList()
	{
		InitializeComponent();
		LoadExpenseAccounts();
	}

	private void LoadTransactingAccount()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT gas.subAccountNo,gas.SubAccoutName,ga.accName,ga.accNo FROM tbl_generalAccounts ga RIGHT OUTER JOIN tbl_generalAccounts_Sub gas ON gas.accNo = ga.accNo GROUP BY gas.subAccountNo,gas.SubAccoutName,ga.accName,ga.categoryId,ga.accNo HAVING  (ga.categoryId >= 5000)", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccountStandingBalance");
			_dt_TA = new DataTable();
			_dt_TA = dataSet.Tables[0];
			gridControl1.DataSource = _dt_TA.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void WithdrawMMoneyAndPayCreditor()
	{
		try
		{
			string captureDate = CaptureDate.GetCaptureDate();
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			trans = sqlConnection.BeginTransaction();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Transaction = trans,
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Credit,captureDate,Narration,TrRef) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Credit,@captureDate,@Narration,@TrRef)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
				sqlParameter.Value = bankAccountNo;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
				sqlParameter.Value = _creditorName + "_" + cboGeneralParticulars.SelectedItem.ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
				sqlParameter.Value = WorkingSemesters.GetWorkingSemester();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@_date", SqlDbType.DateTime);
				sqlParameter.Value = dtDate.ToShortDateString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@month", SqlDbType.VarChar, 9);
				sqlParameter.Value = dtDate.ToString("MMMM");
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@year", SqlDbType.Int);
				sqlParameter.Value = dtDate.Year;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Credit", SqlDbType.Money);
				sqlParameter.Value = Convert.ToDouble(txtCheaqueTotal.Text);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
				sqlParameter.Value = captureDate;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Narration", SqlDbType.VarChar);
				sqlParameter.Value = txtNarration.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@TrRef", SqlDbType.VarChar, 30);
				sqlParameter.Value = txtVoucherNo.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Transaction = trans,
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,captureDate,Narration,TrRef) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@captureDate,@Narration,@TrRef)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
				sqlParameter2.Value = creditorAccountNo;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
				sqlParameter2.Value = cboGeneralParticulars.SelectedItem.ToString();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
				sqlParameter2.Value = WorkingSemesters.GetWorkingSemester();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@_date", SqlDbType.DateTime);
				sqlParameter2.Value = dtDate.ToShortDateString();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@month", SqlDbType.VarChar, 9);
				sqlParameter2.Value = dtDate.ToString("MMMM");
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@year", SqlDbType.Int);
				sqlParameter2.Value = dtDate.Year;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Debit", SqlDbType.Money);
				sqlParameter2.Value = Convert.ToDouble(txtCheaqueTotal.Text);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
				sqlParameter2.Value = captureDate;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Narration", SqlDbType.VarChar);
				sqlParameter2.Value = txtNarration.Text;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@TrRef", SqlDbType.VarChar, 30);
				sqlParameter2.Value = txtVoucherNo.Text;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand3 = new SqlCommand
			{
				Transaction = trans,
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,captureDate,Narration,TrRef) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@captureDate,@Narration,@TrRef)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
				sqlParameter3.Value = itemAccNo;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
				sqlParameter3.Value = cboGeneralParticulars.SelectedItem.ToString();
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
				sqlParameter3.Value = WorkingSemesters.GetWorkingSemester();
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@_date", SqlDbType.DateTime);
				sqlParameter3.Value = dtDate.ToShortDateString();
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@month", SqlDbType.VarChar, 9);
				sqlParameter3.Value = dtDate.ToString("MMMM");
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@year", SqlDbType.Int);
				sqlParameter3.Value = dtDate.Year;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@Debit", SqlDbType.Money);
				sqlParameter3.Value = Convert.ToDouble(txtCheaqueTotal.Text);
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
				sqlParameter3.Value = captureDate;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@Narration", SqlDbType.VarChar);
				sqlParameter3.Value = txtNarration.Text;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@TrRef", SqlDbType.VarChar, 30);
				sqlParameter3.Value = txtVoucherNo.Text;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlCommand3.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Transaction = trans,
				Connection = sqlConnection,
				CommandText = "INSERT INTO Expenses (ExpenseName,expenseSource,qty,units,ChequeNo,VoucherNo,ExpenseValue,DateOfExpense,SemesterId,Narration,CaptureDate)VALUES(@ExpenseName,@expenseSource,@qty,@units,@ChequeNo,@VoucherNo,@ExpenseValue,@DateOfExpense,@SemesterId,@Narration,@CaptureDate)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter4 = sqlCommand4.Parameters.Add("@ExpenseName", SqlDbType.VarChar, 50);
				sqlParameter4.Value = cboGeneralParticulars.SelectedItem.ToString();
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@expenseSource", SqlDbType.VarChar, 50);
				sqlParameter4.Value = "Creditor Payment";
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@qty", SqlDbType.Int);
				sqlParameter4.Value = 1;
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@units", SqlDbType.VarChar, 35);
				sqlParameter4.Value = string.Empty;
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@ChequeNo", SqlDbType.VarChar, 30);
				sqlParameter4.Value = cheaqueNo;
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@VoucherNo", SqlDbType.VarChar, 30);
				sqlParameter4.Value = txtVoucherNo.Text;
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@ExpenseValue", SqlDbType.Money);
				sqlParameter4.Value = Convert.ToDouble(txtCheaqueTotal.Text);
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@DateOfExpense", SqlDbType.DateTime);
				sqlParameter4.Value = dtDate.ToShortDateString();
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
				sqlParameter4.Value = WorkingSemesters.GetWorkingSemester();
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@Narration", SqlDbType.VarChar, 50);
				sqlParameter4.Value = txtNarration.Text;
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@CaptureDate", SqlDbType.VarChar, 100);
				sqlParameter4.Value = captureDate;
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlCommand4.ExecuteNonQuery();
			}
			trans.Commit();
			sqlConnection.Close();
			base.DialogResult = DialogResult.OK;
			Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void CreditorList_Load(object sender, EventArgs e)
	{
		LoadTransactingAccount();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		WithdrawMMoneyAndPayCreditor();
	}

	private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = _dt_TA.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			creditorAccountNo = dataRow["subAccountNo"].ToString();
			_creditorName = dataRow["SubAccoutName"].ToString();
		}
	}

	private void LoadExpenseAccounts()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT gas.subAccountNo AS AccNo, _ga.accName AS Vote, gas.SubAccoutName AS Item FROM tbl_generalAccounts AS ga INNER JOIN tbl_generalAccounts_Sub AS gas ON ga.accNo = gas.accNo INNER JOIN tbl_generalAccounts AS _ga ON ga.accNo = _ga.accNo WHERE (ga.categoryId = 2000)", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "ExpenseAccounts");
		_dt_GP = new DataTable();
		_dt_GP = dataSet.Tables[0];
		cboGeneralParticulars.Properties.Items.Add("-Add New Expense Account-");
		foreach (DataRow row in _dt_GP.Rows)
		{
			cboGeneralParticulars.Properties.Items.Add(row["Item"].ToString());
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1 && cboGeneralParticulars.SelectedIndex > 0 && !string.IsNullOrEmpty(txtNarration.Text) && !string.IsNullOrEmpty(txtVoucherNo.Text))
		{
			simpleButton1.Enabled = true;
		}
		else
		{
			simpleButton1.Enabled = false;
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void cboGeneralParticulars_Closed(object sender, ClosedEventArgs e)
	{
		if (cboGeneralParticulars.SelectedIndex > -1)
		{
			DataRow dataRow = _dt_GP.Rows[cboGeneralParticulars.SelectedIndex - 1];
			itemAccNo = dataRow["AccNo"].ToString();
		}
	}

	private void CreditorList_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
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
		this.gridControl1 = new AlienAge.CustomGrid.MyGridControl();
		this.gridView1 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.txtCheaqueTotal = new DevExpress.XtraEditors.TextEdit();
		this.txtVoucherNo = new DevExpress.XtraEditors.TextEdit();
		this.cboGeneralParticulars = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtNarration = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtCheaqueTotal.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtVoucherNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboGeneralParticulars.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtNarration.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		base.SuspendLayout();
		this.gridControl1.Location = new System.Drawing.Point(2, 2);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(603, 386);
		this.gridControl1.TabIndex = 0;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView1.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView1.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView1.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView1.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView1.AppearancePrint.Preview.Options.UseFont = true;
		this.gridView1.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView1.AppearancePrint.Row.Options.UseFont = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[2] { this.gridColumn1, this.gridColumn3 });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsPrint.PrintHorzLines = false;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
		this.gridColumn1.Caption = "Account #";
		this.gridColumn1.FieldName = "subAccountNo";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 115;
		this.gridColumn3.Caption = "Creditor";
		this.gridColumn3.FieldName = "SubAccoutName";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 1;
		this.gridColumn3.Width = 250;
		this.layoutControl1.Controls.Add(this.txtCheaqueTotal);
		this.layoutControl1.Controls.Add(this.txtVoucherNo);
		this.layoutControl1.Controls.Add(this.cboGeneralParticulars);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Controls.Add(this.txtNarration);
		this.layoutControl1.Location = new System.Drawing.Point(3, 3);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(607, 498);
		this.layoutControl1.TabIndex = 1;
		this.layoutControl1.Text = "layoutControl1";
		this.txtCheaqueTotal.Location = new System.Drawing.Point(2, 414);
		this.txtCheaqueTotal.Name = "txtCheaqueTotal";
		this.txtCheaqueTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.txtCheaqueTotal.Properties.Appearance.Options.UseFont = true;
		this.txtCheaqueTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtCheaqueTotal.Properties.ReadOnly = true;
		this.txtCheaqueTotal.Size = new System.Drawing.Size(299, 28);
		this.txtCheaqueTotal.StyleController = this.layoutControl1;
		this.txtCheaqueTotal.TabIndex = 0;
		this.txtVoucherNo.Location = new System.Drawing.Point(305, 414);
		this.txtVoucherNo.Name = "txtVoucherNo";
		this.txtVoucherNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.txtVoucherNo.Properties.Appearance.Options.UseFont = true;
		this.txtVoucherNo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtVoucherNo.Size = new System.Drawing.Size(300, 26);
		this.txtVoucherNo.StyleController = this.layoutControl1;
		this.txtVoucherNo.TabIndex = 1;
		this.cboGeneralParticulars.Location = new System.Drawing.Point(2, 468);
		this.cboGeneralParticulars.Name = "cboGeneralParticulars";
		this.cboGeneralParticulars.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboGeneralParticulars.Properties.Appearance.Options.UseFont = true;
		this.cboGeneralParticulars.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboGeneralParticulars.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboGeneralParticulars.Properties.MaxLength = 35;
		this.cboGeneralParticulars.Size = new System.Drawing.Size(299, 28);
		this.cboGeneralParticulars.StyleController = this.layoutControl1;
		this.cboGeneralParticulars.TabIndex = 2;
		this.cboGeneralParticulars.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboGeneralParticulars_Closed);
		this.txtNarration.Location = new System.Drawing.Point(305, 468);
		this.txtNarration.Name = "txtNarration";
		this.txtNarration.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtNarration.Properties.Appearance.Options.UseFont = true;
		this.txtNarration.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtNarration.Properties.MaxLength = 50;
		this.txtNarration.Size = new System.Drawing.Size(300, 28);
		this.txtNarration.StyleController = this.layoutControl1;
		this.txtNarration.TabIndex = 3;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[5] { this.layoutControlItem1, this.layoutControlItem6, this.layoutControlItem4, this.layoutControlItem7, this.layoutControlItem5 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(607, 498);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(607, 390);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f);
		this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem6.Control = this.txtVoucherNo;
		this.layoutControlItem6.CustomizationFormText = "Voucher#";
		this.layoutControlItem6.Location = new System.Drawing.Point(303, 390);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(304, 54);
		this.layoutControlItem6.Text = "Voucher#";
		this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem6.TextSize = new System.Drawing.Size(182, 19);
		this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem4.Control = this.cboGeneralParticulars;
		this.layoutControlItem4.CustomizationFormText = "Payment General Purpose";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 444);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(303, 54);
		this.layoutControlItem4.Text = "Payment General Purpose";
		this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem4.TextSize = new System.Drawing.Size(182, 19);
		this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f);
		this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem7.Control = this.txtCheaqueTotal;
		this.layoutControlItem7.CustomizationFormText = "Cheaque Total:";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 390);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(303, 54);
		this.layoutControlItem7.Text = "Cheaque Total";
		this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem7.TextSize = new System.Drawing.Size(182, 19);
		this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem5.Control = this.txtNarration;
		this.layoutControlItem5.CustomizationFormText = "Narration";
		this.layoutControlItem5.Location = new System.Drawing.Point(303, 444);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(304, 54);
		this.layoutControlItem5.Text = "Narration";
		this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem5.TextSize = new System.Drawing.Size(182, 19);
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(314, 530);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(296, 24);
		this.simpleButton2.TabIndex = 5;
		this.simpleButton2.Text = "Cancel";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(3, 530);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(296, 24);
		this.simpleButton1.TabIndex = 4;
		this.simpleButton1.Text = "Continue";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl2.Visible = true;
		this.labelControl2.Location = new System.Drawing.Point(3, 510);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(607, 14);
		this.labelControl2.TabIndex = 6;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(613, 561);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.simpleButton2);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.Name = "CreditorList";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Select Creditor";
		base.Load += new System.EventHandler(CreditorList_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(CreditorList_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtCheaqueTotal.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtVoucherNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboGeneralParticulars.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtNarration.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		base.ResumeLayout(false);
	}
}
