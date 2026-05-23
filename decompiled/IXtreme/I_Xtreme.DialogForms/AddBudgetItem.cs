using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class AddBudgetItem : XtraForm
{
	private DataTable dt;

	private DataTable _dt;

	private string _BudgetType = string.Empty;

	private string _BudgetPeriod = string.Empty;

	public BudgetParameters BudgetRefresh;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private EmptySpaceItem emptySpaceItem1;

	public TextEdit txtRate;

	private Timer timer1;

	private GridLookUpEdit comboBoxEdit1;

	private GridView gridLookUpEdit1View;

	private LayoutControlItem layoutControlItem1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private TextEdit txtCategory;

	private TextEdit txtItem;

	private TextEdit txtAccNo;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlItem layoutControlItem4;

	public AddBudgetItem(string BudgetType, string BudgetPeriod)
	{
		InitializeComponent();
		_BudgetType = BudgetType;
		_BudgetPeriod = BudgetPeriod;
		LoadExpenseItems();
	}

	private void AddBudgetItems()
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			string commandText = string.Empty;
			if (_BudgetType == "Annual")
			{
				commandText = $"SELECT * FROM tbl_budget WHERE accNo='{txtAccNo.Text}' AND Year='{_BudgetPeriod}'";
			}
			else if (_BudgetType == "Termly")
			{
				commandText = $"SELECT * FROM tbl_budget WHERE accNo='{txtAccNo.Text}' AND semester='{_BudgetPeriod}'";
			}
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = commandText,
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				XtraMessageBox.Show($"The item ({txtItem.Text}) already exists in the bugdet for {_BudgetPeriod}", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			sqlConnection.Close();
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection2,
				CommandText = "INSERT INTO tbl_budget(AccNo,semester,[year],qty,units,rate)VALUES(@AccNo,@semester,@year,@qty,@units,@rate)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@AccNo", SqlDbType.VarChar, 9);
			sqlParameter.Value = txtAccNo.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			if (_BudgetType == "Annual")
			{
				sqlParameter = sqlCommand2.Parameters.Add("@semester", SqlDbType.VarChar, 30);
				sqlParameter.Value = DBNull.Value;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@year", SqlDbType.VarChar, 4);
				sqlParameter.Value = _BudgetPeriod;
				sqlParameter.Direction = ParameterDirection.Input;
			}
			else if (_BudgetType == "Termly")
			{
				sqlParameter = sqlCommand2.Parameters.Add("@semester", SqlDbType.VarChar, 30);
				sqlParameter.Value = _BudgetPeriod;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@year", SqlDbType.VarChar, 4);
				sqlParameter.Value = DBNull.Value;
				sqlParameter.Direction = ParameterDirection.Input;
			}
			sqlParameter = sqlCommand2.Parameters.Add("@qty", SqlDbType.Int);
			sqlParameter.Value = 1;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand2.Parameters.Add("@units", SqlDbType.VarChar, 20);
			sqlParameter.Value = DBNull.Value;
			sqlParameter.Direction = ParameterDirection.Input;
			double result = (double.TryParse(txtRate.Text, out result) ? result : 0.0);
			sqlParameter = sqlCommand2.Parameters.Add("@rate", SqlDbType.Money);
			sqlParameter.Value = result;
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand2.ExecuteNonQuery() > 0)
			{
				sqlConnection2.Close();
				comboBoxEdit1.EditValue = null;
				txtAccNo.Text = string.Empty;
				txtCategory.Text = string.Empty;
				txtItem.Text = string.Empty;
				txtRate.Text = string.Empty;
				LoadSemesterBudget(_BudgetType, _BudgetPeriod);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		AddBudgetItems();
	}

	private void LoadSemesterBudget(string __BudgetType, string __BudgetPeriod)
	{
		try
		{
			dt = new DataTable();
			string selectCommandText = string.Empty;
			if (__BudgetType == "Termly")
			{
				selectCommandText = $"SELECT gas.subAccountNo, gas.SubAccoutName AS SubVote, b.semester, b.year, b.qty, b.units, b.rate, (b.rate * b.qty) AS Amount, ga.accName AS Vote FROM tbl_generalAccounts_Sub gas INNER JOIN tbl_budget b ON gas.subAccountNo = b.accNo INNER JOIN tbl_generalAccounts ga ON gas.accNo = ga.accNo WHERE b.semester='{__BudgetPeriod}'";
			}
			else if (__BudgetType == "Annual")
			{
				selectCommandText = $"SELECT gas.subAccountNo, gas.SubAccoutName AS SubVote, b.semester, b.year, b.qty, b.units, b.rate, (b.rate * b.qty) AS Amount, ga.accName AS Vote FROM tbl_generalAccounts_Sub gas INNER JOIN tbl_budget b ON gas.subAccountNo = b.accNo INNER JOIN tbl_generalAccounts ga ON gas.accNo = ga.accNo WHERE b.year='{__BudgetPeriod}'";
			}
			using (SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "Budget");
				dt = dataSet.Tables[0];
			}
			BudgetRefresh("pageBudgetCreate", __BudgetType, __BudgetPeriod, dt);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadExpenseItems()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT ga.categoryId, ga.accName, gas.subAccountNo, gas.SubAccoutName FROM tbl_generalAccounts ga INNER JOIN tbl_generalAccounts_Sub gas ON ga.accNo = gas.accNo WHERE(ga.categoryId = 2000)", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Budget");
			_dt = new DataTable();
			_dt = dataSet.Tables[0];
			comboBoxEdit1.Properties.DataSource = _dt.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
	{
		if (gridLookUpEdit1View.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = _dt.Rows[gridLookUpEdit1View.GetFocusedDataSourceRowIndex()];
			txtAccNo.Text = dataRow["subAccountNo"].ToString();
			txtCategory.Text = dataRow["accName"].ToString();
			txtItem.Text = dataRow["SubAccoutName"].ToString();
		}
		else
		{
			txtAccNo.Text = string.Empty;
			txtCategory.Text = string.Empty;
			txtItem.Text = string.Empty;
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(txtItem.Text) && !string.IsNullOrEmpty(txtRate.Text))
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
		this.components = new System.ComponentModel.Container();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.txtCategory = new DevExpress.XtraEditors.TextEdit();
		this.txtItem = new DevExpress.XtraEditors.TextEdit();
		this.txtAccNo = new DevExpress.XtraEditors.TextEdit();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtRate = new DevExpress.XtraEditors.TextEdit();
		this.comboBoxEdit1 = new DevExpress.XtraEditors.GridLookUpEdit();
		this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtCategory.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAccNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtRate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridLookUpEdit1View).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.txtCategory);
		this.layoutControl1.Controls.Add(this.txtItem);
		this.layoutControl1.Controls.Add(this.txtAccNo);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.txtRate);
		this.layoutControl1.Controls.Add(this.comboBoxEdit1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(395, 186);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.txtCategory.Location = new System.Drawing.Point(80, 30);
		this.txtCategory.Name = "txtCategory";
		this.txtCategory.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.txtCategory.Properties.Appearance.Options.UseFont = true;
		this.txtCategory.Properties.ReadOnly = true;
		this.txtCategory.Size = new System.Drawing.Size(313, 24);
		this.txtCategory.StyleController = this.layoutControl1;
		this.txtCategory.TabIndex = 18;
		this.txtItem.Location = new System.Drawing.Point(80, 58);
		this.txtItem.Name = "txtItem";
		this.txtItem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.txtItem.Properties.Appearance.Options.UseFont = true;
		this.txtItem.Properties.ReadOnly = true;
		this.txtItem.Size = new System.Drawing.Size(313, 24);
		this.txtItem.StyleController = this.layoutControl1;
		this.txtItem.TabIndex = 17;
		this.txtAccNo.Location = new System.Drawing.Point(80, 86);
		this.txtAccNo.Name = "txtAccNo";
		this.txtAccNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.txtAccNo.Properties.Appearance.Options.UseFont = true;
		this.txtAccNo.Properties.ReadOnly = true;
		this.txtAccNo.Size = new System.Drawing.Size(313, 24);
		this.txtAccNo.StyleController = this.layoutControl1;
		this.txtAccNo.TabIndex = 16;
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(201, 159);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(192, 25);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 9;
		this.simpleButton2.Text = "Close";
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(2, 159);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(195, 25);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 4;
		this.simpleButton1.Text = "Add";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.txtRate.EnterMoveNextControl = true;
		this.txtRate.Location = new System.Drawing.Point(80, 114);
		this.txtRate.Name = "txtRate";
		this.txtRate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtRate.Properties.Appearance.Options.UseFont = true;
		this.txtRate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtRate.Properties.DisplayFormat.FormatString = "{0:#,#.0}";
		this.txtRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.txtRate.Properties.EditFormat.FormatString = "{0:#,#.0}";
		this.txtRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.txtRate.Properties.Mask.EditMask = "n0";
		this.txtRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtRate.Size = new System.Drawing.Size(313, 26);
		this.txtRate.StyleController = this.layoutControl1;
		this.txtRate.TabIndex = 3;
		this.comboBoxEdit1.Location = new System.Drawing.Point(80, 2);
		this.comboBoxEdit1.Name = "comboBoxEdit1";
		this.comboBoxEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.comboBoxEdit1.Properties.Appearance.Options.UseFont = true;
		this.comboBoxEdit1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.comboBoxEdit1.Properties.AppearanceDropDown.Options.UseFont = true;
		this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.comboBoxEdit1.Properties.DisplayMember = "SubAccoutName";
		this.comboBoxEdit1.Properties.NullText = "";
		this.comboBoxEdit1.Properties.PopupSizeable = false;
		this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
		this.comboBoxEdit1.Properties.View = this.gridLookUpEdit1View;
		this.comboBoxEdit1.Size = new System.Drawing.Size(313, 24);
		this.comboBoxEdit1.StyleController = this.layoutControl1;
		this.comboBoxEdit1.TabIndex = 15;
		this.comboBoxEdit1.EditValueChanged += new System.EventHandler(comboBoxEdit1_EditValueChanged);
		this.gridLookUpEdit1View.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.DetailTip.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.Empty.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.EvenRow.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.FilterPanel.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.FixedLine.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.FocusedCell.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.FocusedRow.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.FooterPanel.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.GroupButton.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.GroupFooter.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.GroupPanel.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.GroupRow.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.HorzLine.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.OddRow.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.Preview.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.Row.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.RowSeparator.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.SelectedRow.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.TopNewRow.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.VertLine.Options.UseFont = true;
		this.gridLookUpEdit1View.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridLookUpEdit1View.Appearance.ViewCaption.Options.UseFont = true;
		this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridColumn1, this.gridColumn2, this.gridColumn3 });
		this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
		this.gridLookUpEdit1View.GroupCount = 1;
		this.gridLookUpEdit1View.GroupFormat = "{1} {2}";
		this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
		this.gridLookUpEdit1View.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridLookUpEdit1View.OptionsBehavior.Editable = false;
		this.gridLookUpEdit1View.OptionsFind.AlwaysVisible = true;
		this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
		this.gridLookUpEdit1View.OptionsView.ShowIndicator = false;
		this.gridLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[8] { this.layoutControlItem2, this.layoutControlItem5, this.layoutControlItem6, this.emptySpaceItem1, this.layoutControlItem1, this.layoutControlItem3, this.layoutControlItem7, this.layoutControlItem4 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(395, 186);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.txtRate;
		this.layoutControlItem2.CustomizationFormText = "Amount";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 112);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(395, 30);
		this.layoutControlItem2.Text = "Amount";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(75, 18);
		this.layoutControlItem5.Control = this.simpleButton1;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 157);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(199, 29);
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem6.Control = this.simpleButton2;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(199, 157);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(196, 29);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 142);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(395, 15);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.comboBoxEdit1;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(395, 28);
		this.layoutControlItem1.Text = "Item";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(75, 18);
		this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem3.Control = this.txtAccNo;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 84);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(395, 28);
		this.layoutControlItem3.Text = "Account No";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(75, 18);
		this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem7.Control = this.txtCategory;
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(395, 28);
		this.layoutControlItem7.Text = "Vote";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(75, 18);
		this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem4.Control = this.txtItem;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 56);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(395, 28);
		this.layoutControlItem4.Text = "Sub Vote";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(75, 18);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.gridColumn1.Caption = "Category";
		this.gridColumn1.FieldName = "accName";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn2.Caption = "Account No";
		this.gridColumn2.FieldName = "subAccountNo";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 0;
		this.gridColumn3.Caption = "Item";
		this.gridColumn3.FieldName = "SubAccoutName";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 1;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(395, 186);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "AddBudgetItem";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Add Budget Item";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtCategory.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAccNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtRate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridLookUpEdit1View).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		base.ResumeLayout(false);
	}
}
