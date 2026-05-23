using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using AlienAge.Semesters;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class DepositSourceDetails : XtraForm
{
	private SqlTransaction trans;

	private string connectionString = DataConnection.ConnectToDatabase();

	public DateTime dtDate;

	public string _AccountNo = string.Empty;

	public double voucherTotal = 0.0;

	private IContainer components = null;

	private MyGridControl myGridControl1;

	private MyGridView myGridView1;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private LabelControl labelControl2;

	private GridColumn gridColAccNo;

	private GridColumn gridColItem;

	private GridColumn gridColNarration;

	private GridColumn gridColAmount;

	private Timer timer1;

	public TextEdit txtAmount;

	private TextEdit txtTransactionRef;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private DataTable RequisitionDataTable
	{
		get
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Vote", typeof(string));
			dataTable.Columns.Add("Item", typeof(string));
			dataTable.Columns.Add("AccNo", typeof(string));
			dataTable.Columns.Add("Amount", typeof(double));
			dataTable.Columns.Add("Narration", typeof(string));
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT gas.subAccountNo AS AccNo, _ga.accName AS Vote, gas.SubAccoutName AS Item FROM tbl_generalAccounts AS ga INNER JOIN tbl_generalAccounts_Sub AS gas ON ga.accNo = gas.accNo INNER JOIN tbl_generalAccounts AS _ga ON ga.accNo = _ga.accNo WHERE (ga.categoryId = 1000)", connectionString);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "expenseItems");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				dataTable.Rows.Add(row["Vote"], row["Item"], row["AccNo"], 0, string.Empty);
			}
			return dataTable;
		}
	}

	public DepositSourceDetails()
	{
		InitializeComponent();
		LoadExpensesItems();
	}

	private void MakeCashDeposit()
	{
		try
		{
			string captureDate = CaptureDate.GetCaptureDate();
			myGridView1.ActiveFilterString = $"[Amount] > '{0}'";
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			for (int i = 0; i < myGridView1.RowCount; i++)
			{
				sqlConnection.Open();
				trans = sqlConnection.BeginTransaction();
				double num = Convert.ToDouble(myGridView1.GetRowCellValue(i, "Amount"));
				string text = myGridView1.GetRowCellValue(i, "Narration").ToString();
				string text2 = myGridView1.GetRowCellValue(i, "Vote").ToString();
				string text3 = myGridView1.GetRowCellValue(i, "Item").ToString();
				string value = myGridView1.GetRowCellValue(i, "AccNo").ToString();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Transaction = trans,
					Connection = sqlConnection,
					CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Credit,captureDate,Narration,TrRef) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Credit,@captureDate,@Narration,@TrRef)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
					sqlParameter.Value = value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
					sqlParameter.Value = text3 + "-" + text;
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
					sqlParameter.Value = num;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
					sqlParameter.Value = captureDate;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Narration", SqlDbType.VarChar);
					sqlParameter.Value = txtTransactionRef.Text + "/" + text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@TrRef", SqlDbType.VarChar, 30);
					sqlParameter.Value = txtTransactionRef.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				trans.Commit();
				sqlConnection.Close();
				if (i != myGridView1.RowCount - 1)
				{
					continue;
				}
				SqlConnection sqlConnection2 = new SqlConnection(connectionString);
				sqlConnection2.Open();
				using SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,captureDate,Narration,TrRef) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@captureDate,@Narration,@TrRef)",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
				sqlParameter2.Value = _AccountNo;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
				sqlParameter2.Value = text3 + "-" + text;
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
				sqlParameter2.Value = Convert.ToDouble(txtAmount.Text);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
				sqlParameter2.Value = captureDate;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Narration", SqlDbType.VarChar);
				sqlParameter2.Value = "CASH DEPOSIT/" + txtTransactionRef.Text;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@TrRef", SqlDbType.VarChar, 30);
				sqlParameter2.Value = txtTransactionRef.Text;
				sqlParameter2.Direction = ParameterDirection.Input;
				if (sqlCommand2.ExecuteNonQuery() > 0)
				{
					sqlConnection2.Close();
					base.DialogResult = DialogResult.OK;
					Close();
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadExpensesItems()
	{
		try
		{
			myGridControl1.DataSource = RequisitionDataTable.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		if (Convert.ToDouble(txtAmount.Text) == voucherTotal)
		{
			MakeCashDeposit();
		}
		else
		{
			XtraMessageBox.Show("Sorry! We cannot do that. The deposit total does not match with the slip total.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		GridSummaryItem gridSummaryItem = new GridSummaryItem();
		gridSummaryItem.SetSummary(SummaryItemType.Sum, "{0:#,#.0}");
		gridSummaryItem.FieldName = "Amount";
		myGridView1.Columns["Amount"].SummaryItem.Assign(gridSummaryItem);
		voucherTotal = Convert.ToDouble(myGridView1.Columns["Amount"].SummaryItem.SummaryValue);
		if (myGridView1.GetFocusedDataSourceRowIndex() > -1 && !string.IsNullOrEmpty(txtTransactionRef.Text))
		{
			simpleButton2.Enabled = true;
		}
		else
		{
			simpleButton2.Enabled = false;
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void RequisitionDetails_KeyDown(object sender, KeyEventArgs e)
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
		this.myGridControl1 = new AlienAge.CustomGrid.MyGridControl();
		this.myGridView1 = new AlienAge.CustomGrid.MyGridView();
		this.gridColAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColItem = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColAmount = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColNarration = new DevExpress.XtraGrid.Columns.GridColumn();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.txtAmount = new DevExpress.XtraEditors.TextEdit();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.txtTransactionRef = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.myGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.myGridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAmount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtTransactionRef.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.myGridControl1.Location = new System.Drawing.Point(4, 4);
		this.myGridControl1.MainView = this.myGridView1;
		this.myGridControl1.Name = "myGridControl1";
		this.myGridControl1.Size = new System.Drawing.Size(599, 438);
		this.myGridControl1.TabIndex = 0;
		this.myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.myGridView1 });
		this.myGridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.myGridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.myGridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.myGridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.DetailTip.Options.UseFont = true;
		this.myGridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.Empty.Options.UseFont = true;
		this.myGridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.EvenRow.Options.UseFont = true;
		this.myGridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.myGridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.myGridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.FixedLine.Options.UseFont = true;
		this.myGridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.myGridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.myGridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.myGridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.myGridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.myGridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.myGridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.myGridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.GroupButton.Options.UseFont = true;
		this.myGridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.myGridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.myGridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.GroupRow.Options.UseFont = true;
		this.myGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.myGridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.myGridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.myGridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.myGridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.HorzLine.Options.UseFont = true;
		this.myGridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.OddRow.Options.UseFont = true;
		this.myGridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.Preview.Options.UseFont = true;
		this.myGridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.Row.Options.UseFont = true;
		this.myGridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.myGridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.myGridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.myGridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.myGridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.myGridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.VertLine.Options.UseFont = true;
		this.myGridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.myGridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[4] { this.gridColAccNo, this.gridColItem, this.gridColAmount, this.gridColNarration });
		this.myGridView1.GridControl = this.myGridControl1;
		this.myGridView1.GroupFormat = "{1} {2}";
		this.myGridView1.Name = "myGridView1";
		this.myGridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.myGridView1.OptionsCustomization.AllowGroup = false;
		this.myGridView1.OptionsView.ShowFooter = true;
		this.myGridView1.OptionsView.ShowGroupPanel = false;
		this.myGridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.myGridView1.OptionsView.ShowIndicator = false;
		this.gridColAccNo.Caption = "Acc#";
		this.gridColAccNo.FieldName = "AccNo";
		this.gridColAccNo.Name = "gridColAccNo";
		this.gridColAccNo.Visible = true;
		this.gridColAccNo.VisibleIndex = 0;
		this.gridColAccNo.Width = 195;
		this.gridColItem.Caption = "Item";
		this.gridColItem.FieldName = "Item";
		this.gridColItem.Name = "gridColItem";
		this.gridColItem.Visible = true;
		this.gridColItem.VisibleIndex = 1;
		this.gridColItem.Width = 371;
		this.gridColAmount.Caption = "Amount";
		this.gridColAmount.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColAmount.FieldName = "Amount";
		this.gridColAmount.Name = "gridColAmount";
		this.gridColAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:#,#.0}")
		});
		this.gridColAmount.Visible = true;
		this.gridColAmount.VisibleIndex = 2;
		this.gridColAmount.Width = 262;
		this.gridColNarration.Caption = "Narration";
		this.gridColNarration.FieldName = "Narration";
		this.gridColNarration.Name = "gridColNarration";
		this.gridColNarration.Visible = true;
		this.gridColNarration.VisibleIndex = 3;
		this.gridColNarration.Width = 266;
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(314, 530);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(296, 24);
		this.simpleButton1.TabIndex = 1;
		this.simpleButton1.Text = "Cancel";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.Location = new System.Drawing.Point(3, 530);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(296, 24);
		this.simpleButton2.TabIndex = 2;
		this.simpleButton2.Text = "Continue";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.txtAmount.Location = new System.Drawing.Point(4, 468);
		this.txtAmount.Name = "txtAmount";
		this.txtAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtAmount.Properties.Appearance.Options.UseFont = true;
		this.txtAmount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtAmount.Properties.ReadOnly = true;
		this.txtAmount.Size = new System.Drawing.Size(297, 26);
		this.txtAmount.StyleController = this.layoutControl1;
		this.txtAmount.TabIndex = 3;
		this.layoutControl1.Controls.Add(this.txtTransactionRef);
		this.layoutControl1.Controls.Add(this.txtAmount);
		this.layoutControl1.Controls.Add(this.myGridControl1);
		this.layoutControl1.Location = new System.Drawing.Point(3, 3);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(607, 498);
		this.layoutControl1.TabIndex = 7;
		this.layoutControl1.Text = "layoutControl1";
		this.txtTransactionRef.EditValue = "";
		this.txtTransactionRef.Location = new System.Drawing.Point(305, 468);
		this.txtTransactionRef.Name = "txtTransactionRef";
		this.txtTransactionRef.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtTransactionRef.Properties.Appearance.Options.UseFont = true;
		this.txtTransactionRef.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtTransactionRef.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtTransactionRef.Size = new System.Drawing.Size(298, 26);
		this.txtTransactionRef.StyleController = this.layoutControl1;
		this.txtTransactionRef.TabIndex = 6;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(607, 498);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.myGridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(603, 442);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.txtAmount;
		this.layoutControlItem2.CustomizationFormText = "Cheaque Total";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 442);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(301, 52);
		this.layoutControlItem2.Text = "Deposit Total";
		this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem2.TextSize = new System.Drawing.Size(122, 19);
		this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f);
		this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem3.Control = this.txtTransactionRef;
		this.layoutControlItem3.CustomizationFormText = "Voucher#";
		this.layoutControlItem3.Location = new System.Drawing.Point(301, 442);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(302, 52);
		this.layoutControlItem3.Text = "Transaction Ref#";
		this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem3.TextSize = new System.Drawing.Size(122, 19);
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl2.Visible = true;
		this.labelControl2.Location = new System.Drawing.Point(3, 510);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(607, 14);
		this.labelControl2.TabIndex = 5;
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(613, 561);
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.Name = "DepositSourceDetails";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Cash Deposit Source Details";
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(RequisitionDetails_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.myGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.myGridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAmount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtTransactionRef.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
