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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme;

public class MonthlyDeductions : XtraForm
{
	private DataTable _dt;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private SimpleButton simpleButton1;

	private LayoutControlItem layoutControlItem2;

	private Timer timer1;

	private SimpleButton simpleButton2;

	private PanelControl panelControl1;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private ComboBoxEdit cboDeductions;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private GridColumn gridColumn1;

	private GridColumn gridColumn4;

	private CheckEdit checkEdit2;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlGroup layoutControlGroup4;

	private LayoutControlGroup layoutControlGroup2;

	public GridControl gridControl2;

	public GridView gridView2;

	public MonthlyDeductions()
	{
		InitializeComponent();
	}

	private void EmployeeItems_Load(object sender, EventArgs e)
	{
		GetDeductionsList();
		GetDeductableItems();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		GridColumnSummaryItem gridColumnSummaryItem = new GridColumnSummaryItem();
		gridColumnSummaryItem.SetSummary(SummaryItemType.Sum, "{0:#,#.0}");
		gridColumnSummaryItem.FieldName = "Amount";
		gridColumn4.SummaryItem.Assign(gridColumnSummaryItem);
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		gridView2.CloseEditor();
		if (XtraMessageBox.Show("Are you sure you want to continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			base.DialogResult = DialogResult.OK;
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void GetDeductionsList()
	{
		try
		{
			string empty = string.Empty;
			empty = ((!checkEdit2.Checked) ? "SELECT id,Item,SUM(Amount)-SUM(Amount) AS Amount FROM tbl_EmployeeDeductions GROUP BY id,item " : "SELECT * FROM tbl_EmployeeDeductions");
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(empty, DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "deductions");
			_dt = new DataTable();
			_dt = dataSet.Tables[0];
			gridControl2.DataSource = _dt.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void GetDeductableItems()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_EmployeeDeductions", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "deductions");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			cboDeductions.Properties.Items.Clear();
			cboDeductions.Properties.Items.Add("Add New");
			foreach (DataRow row in dataTable.Rows)
			{
				cboDeductions.Properties.Items.Add(row["Item"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void cboDeductions_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cboDeductions.SelectedIndex != 0)
		{
			return;
		}
		using EmpDeductions empDeductions = new EmpDeductions();
		if (empDeductions.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = $"SELECT * FROM tbl_EmployeeDeductions WHERE Item='{empDeductions.txtItem.Text}'",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				XtraMessageBox.Show("This item already exists", "Duplicate entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				sqlConnection.Close();
				cboDeductions.SelectedIndex = -1;
				return;
			}
			sqlConnection.Close();
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection2,
				CommandText = "INSERT INTO tbl_EmployeeDeductions (Item,Amount)VALUES(@Item,@Amount)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@Item", SqlDbType.VarChar, 50);
			sqlParameter.Value = empDeductions.txtItem.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand2.Parameters.Add("@Amount", SqlDbType.Money);
			sqlParameter.Value = Convert.ToDouble(empDeductions.txtAmount.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand2.ExecuteNonQuery();
			sqlConnection2.Close();
			GetDeductionsList();
			GetDeductableItems();
			cboDeductions.SelectedIndex = -1;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void checkEdit2_CheckedChanged(object sender, EventArgs e)
	{
		if (checkEdit2.Enabled)
		{
			GetDeductionsList();
		}
	}

	private void gridView2_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
	{
		if (gridView2.FocusedRowHandle > -1 && gridView2.Columns.ColumnByFieldName("Amount").FieldName == "Amount" && !double.TryParse(e.Value.ToString(), out var _))
		{
			e.Valid = false;
		}
	}

	private void gridView2_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
	{
		e.ExceptionMode = ExceptionMode.DisplayError;
		e.WindowCaption = "Input Error";
		e.ErrorText = "You have to enter digits only.";
		gridView2.HideEditor();
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
		this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
		this.gridControl2 = new DevExpress.XtraGrid.GridControl();
		this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.cboDeductions = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.checkEdit2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboDeductions.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.checkEdit2);
		this.layoutControl1.Controls.Add(this.gridControl2);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.panelControl1);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.cboDeductions);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(441, 185, 409, 446);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(575, 525);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.checkEdit2.Location = new System.Drawing.Point(5, 49);
		this.checkEdit2.Name = "checkEdit2";
		this.checkEdit2.Properties.Caption = "Use default values";
		this.checkEdit2.Size = new System.Drawing.Size(565, 19);
		this.checkEdit2.StyleController = this.layoutControl1;
		this.checkEdit2.TabIndex = 12;
		this.checkEdit2.CheckedChanged += new System.EventHandler(checkEdit2_CheckedChanged);
		this.gridControl2.Location = new System.Drawing.Point(5, 72);
		this.gridControl2.MainView = this.gridView2;
		this.gridControl2.Name = "gridControl2";
		this.gridControl2.Size = new System.Drawing.Size(565, 422);
		this.gridControl2.TabIndex = 8;
		this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[2] { this.gridColumn1, this.gridColumn4 });
		this.gridView2.GridControl = this.gridControl2;
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsView.ShowFooter = true;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.gridView2.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(gridView2_ValidatingEditor);
		this.gridView2.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(gridView2_InvalidValueException);
		this.gridColumn1.Caption = "Item";
		this.gridColumn1.FieldName = "Item";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 686;
		this.gridColumn4.Caption = "Amount";
		this.gridColumn4.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn4.FieldName = "Amount";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 1;
		this.gridColumn4.Width = 494;
		this.simpleButton2.Location = new System.Drawing.Point(429, 501);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(69, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 7;
		this.simpleButton2.Text = "Cancel";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl1.Location = new System.Drawing.Point(2, 501);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(423, 22);
		this.panelControl1.TabIndex = 6;
		this.simpleButton1.Location = new System.Drawing.Point(502, 501);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(71, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 5;
		this.simpleButton1.Text = "Continue";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.cboDeductions.Location = new System.Drawing.Point(5, 25);
		this.cboDeductions.Name = "cboDeductions";
		this.cboDeductions.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboDeductions.Properties.NullText = "Add new item";
		this.cboDeductions.Size = new System.Drawing.Size(565, 20);
		this.cboDeductions.StyleController = this.layoutControl1;
		this.cboDeductions.TabIndex = 9;
		this.cboDeductions.SelectedIndexChanged += new System.EventHandler(cboDeductions_SelectedIndexChanged);
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlGroup4, this.layoutControlGroup2 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(575, 525);
		this.layoutControlGroup1.Text = "ParentGroup";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlGroup4.CustomizationFormText = "layoutControlGroup4";
		this.layoutControlGroup4.GroupBordersVisible = false;
		this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem3, this.layoutControlItem2, this.layoutControlItem4 });
		this.layoutControlGroup4.Location = new System.Drawing.Point(0, 499);
		this.layoutControlGroup4.Name = "layoutControlGroup4";
		this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup4.Size = new System.Drawing.Size(575, 26);
		this.layoutControlGroup4.Text = "layoutControlGroup4";
		this.layoutControlGroup4.TextVisible = false;
		this.layoutControlItem3.Control = this.panelControl1;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(427, 26);
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem2.Control = this.simpleButton1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(500, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(75, 26);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem4.Control = this.simpleButton2;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(427, 0);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(73, 26);
		this.layoutControlItem4.Text = "layoutControlItem4";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextToControlDistance = 0;
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlGroup2.CustomizationFormText = "Deductions";
		this.layoutControlGroup2.ExpandButtonVisible = true;
		this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem6, this.layoutControlItem5, this.layoutControlItem8 });
		this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup2.Name = "layoutControlGroup2";
		this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup2.ShowTabPageCloseButton = true;
		this.layoutControlGroup2.Size = new System.Drawing.Size(575, 499);
		this.layoutControlGroup2.Text = "Deductions";
		this.layoutControlItem6.Control = this.cboDeductions;
		this.layoutControlItem6.CustomizationFormText = "Deductions";
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(569, 24);
		this.layoutControlItem6.Text = "Deductions";
		this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextToControlDistance = 0;
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem5.Control = this.gridControl2;
		this.layoutControlItem5.CustomizationFormText = "Deductions";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 47);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(569, 426);
		this.layoutControlItem5.Text = "Deductions";
		this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextToControlDistance = 0;
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem8.Control = this.checkEdit2;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(569, 23);
		this.layoutControlItem8.Text = "layoutControlItem8";
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextToControlDistance = 0;
		this.layoutControlItem8.TextVisible = false;
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		base.ClientSize = new System.Drawing.Size(575, 525);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "MonthlyDeductions";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Monthly deductions";
		base.Load += new System.EventHandler(EmployeeItems_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.checkEdit2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboDeductions.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		base.ResumeLayout(false);
	}
}
