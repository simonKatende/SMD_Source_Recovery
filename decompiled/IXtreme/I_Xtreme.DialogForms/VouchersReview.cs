using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.PaymentVoucher;

namespace I_Xtreme.DialogForms;

public class VouchersReview : XtraForm
{
	private DataTable dt;

	private string voucherNo = string.Empty;

	private string captureDate = string.Empty;

	private SqlTransaction trans;

	private IContainer components = null;

	private MyGridControl myGridControl1;

	private MyGridView myGridView1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn5;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn6;

	private LayoutControl layoutControl1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private SimpleButton simpleButton3;

	private LayoutControlItem layoutControlItem5;

	private EmptySpaceItem emptySpaceItem1;

	public VouchersReview(string voucherType)
	{
		InitializeComponent();
		LoadPreviousVouchers();
	}

	private void LoadPreviousVouchers()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT PaymentMode, ChequeNo, VoucherNo, ExpenseValue, DateOfExpense,CaptureDate FROM Expenses", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Vouchers");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			myGridControl1.DataSource = dt.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void myGridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (myGridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = dt.Rows[myGridView1.GetFocusedDataSourceRowIndex()];
			captureDate = dataRow["CaptureDate"].ToString();
			voucherNo = dataRow["VoucherNo"].ToString();
			VoucherParameters.VoucherNoSelected = voucherNo;
			double result = 0.0;
			string selectCommandText = $"SELECT SUM(ExpenseValue) AS ExpenseValue  FROM Expenses WHERE (VoucherNo = '{I_Xtreme.ExtremeClasses.PaymentVoucher.VoucherNo}')";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					result = (double.TryParse(row["ExpenseValue"].ToString(), out result) ? result : 0.0);
					I_Xtreme.ExtremeClasses.PaymentVoucher.SetVoucherInformation(voucherNo, (long)result);
				}
			}
			simpleButton3.Enabled = true;
		}
		else
		{
			simpleButton3.Enabled = false;
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		DialogResult dialogResult = XtraMessageBox.Show($"Do you really want to delete the voucher [{voucherNo}]?\nNote that you will not be able to undo the action.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult == DialogResult.Yes)
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			trans = sqlConnection.BeginTransaction();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = "DELETE FROM Expenses WHERE CaptureDate=@CaptureDate",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@CaptureDate", SqlDbType.VarChar, 50);
				sqlParameter.Value = captureDate;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = "DELETE FROM tbl_StatementOfAffairs WHERE CaptureDate=@CaptureDate",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@CaptureDate", SqlDbType.VarChar, 50);
				sqlParameter2.Value = captureDate;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			trans.Commit();
			sqlConnection.Close();
			XtraMessageBox.Show("Transactions deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			LoadPreviousVouchers();
		}
	}

	private void simpleButton3_Click(object sender, EventArgs e)
	{
		PaymentVoucherRpt report = new PaymentVoucherRpt();
		ReportPrintTool reportPrintTool = new ReportPrintTool(report);
		reportPrintTool.ShowRibbonPreview();
	}

	private void myGridView1_RowClick(object sender, RowClickEventArgs e)
	{
		if (myGridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = dt.Rows[myGridView1.GetFocusedDataSourceRowIndex()];
			captureDate = dataRow["CaptureDate"].ToString();
			voucherNo = dataRow["VoucherNo"].ToString();
			double result = 0.0;
			string selectCommandText = $"SELECT SUM(ExpenseValue) AS ExpenseValue FROM Expenses WHERE VoucherNo='{I_Xtreme.ExtremeClasses.PaymentVoucher.VoucherNo}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					result = (double.TryParse(row["ExpenseValue"].ToString(), out result) ? result : 0.0);
					I_Xtreme.ExtremeClasses.PaymentVoucher.SetVoucherInformation(voucherNo, (long)result);
				}
			}
			simpleButton3.Enabled = true;
		}
		else
		{
			simpleButton3.Enabled = false;
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
		this.myGridControl1 = new AlienAge.CustomGrid.MyGridControl();
		this.myGridView1 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		((System.ComponentModel.ISupportInitialize)this.myGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.myGridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		base.SuspendLayout();
		this.myGridControl1.Location = new System.Drawing.Point(4, 4);
		this.myGridControl1.MainView = this.myGridView1;
		this.myGridControl1.Name = "myGridControl1";
		this.myGridControl1.Size = new System.Drawing.Size(776, 525);
		this.myGridControl1.TabIndex = 0;
		this.myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.myGridView1 });
		this.myGridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.myGridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.myGridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.myGridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.DetailTip.Options.UseFont = true;
		this.myGridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.Empty.Options.UseFont = true;
		this.myGridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.myGridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.GhostWhite;
		this.myGridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.EvenRow.Options.UseBackColor = true;
		this.myGridView1.Appearance.EvenRow.Options.UseFont = true;
		this.myGridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.myGridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.myGridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.FixedLine.Options.UseFont = true;
		this.myGridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.myGridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.myGridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.myGridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.myGridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.myGridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.myGridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.myGridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.GroupButton.Options.UseFont = true;
		this.myGridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.myGridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.myGridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.GroupRow.Options.UseFont = true;
		this.myGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.myGridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.myGridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.myGridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.myGridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.HorzLine.Options.UseFont = true;
		this.myGridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.OddRow.Options.UseFont = true;
		this.myGridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.Preview.Options.UseFont = true;
		this.myGridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.Row.Options.UseFont = true;
		this.myGridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.myGridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.myGridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.myGridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.myGridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.myGridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.VertLine.Options.UseFont = true;
		this.myGridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[6] { this.gridColumn1, this.gridColumn5, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn6 });
		this.myGridView1.GridControl = this.myGridControl1;
		this.myGridView1.GroupCount = 1;
		this.myGridView1.GroupFormat = "{1} {2}";
		this.myGridView1.Name = "myGridView1";
		this.myGridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.myGridView1.OptionsBehavior.Editable = false;
		this.myGridView1.OptionsFind.AlwaysVisible = true;
		this.myGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.myGridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.myGridView1.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.myGridView1.OptionsView.ShowGroupPanel = false;
		this.myGridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.myGridView1.OptionsView.ShowIndicator = false;
		this.myGridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.myGridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(myGridView1_RowClick);
		this.myGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(myGridView1_FocusedRowChanged);
		this.gridColumn1.Caption = "PaymentMode";
		this.gridColumn1.FieldName = "PaymentMode";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 1;
		this.gridColumn5.Caption = "Date";
		this.gridColumn5.FieldName = "DateOfExpense";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 0;
		this.gridColumn2.Caption = "ChequeNo";
		this.gridColumn2.FieldName = "ChequeNo";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn3.Caption = "VoucherNo";
		this.gridColumn3.FieldName = "VoucherNo";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 2;
		this.gridColumn4.Caption = "Amount";
		this.gridColumn4.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn4.FieldName = "ExpenseValue";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 3;
		this.gridColumn6.Caption = "Trx.ID";
		this.gridColumn6.FieldName = "CaptureDate";
		this.gridColumn6.Name = "gridColumn6";
		this.layoutControl1.Controls.Add(this.simpleButton3);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.myGridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(784, 561);
		this.layoutControl1.TabIndex = 1;
		this.layoutControl1.Text = "layoutControl1";
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(663, 533);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(117, 24);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 5;
		this.simpleButton2.Text = "Cancel";
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(4, 533);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(128, 24);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 4;
		this.simpleButton1.Text = "Delete Voucher";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[5] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem5, this.emptySpaceItem1 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(784, 561);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.myGridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(780, 529);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.simpleButton1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 529);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(132, 28);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.simpleButton2;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(659, 529);
		this.layoutControlItem3.MaxSize = new System.Drawing.Size(121, 0);
		this.layoutControlItem3.MinSize = new System.Drawing.Size(121, 28);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(121, 28);
		this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.simpleButton3.Appearance.Options.UseFont = true;
		this.simpleButton3.Enabled = false;
		this.simpleButton3.Location = new System.Drawing.Point(136, 533);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(128, 24);
		this.simpleButton3.StyleController = this.layoutControl1;
		this.simpleButton3.TabIndex = 7;
		this.simpleButton3.Text = "Print Voucher";
		this.simpleButton3.Click += new System.EventHandler(simpleButton3_Click);
		this.layoutControlItem5.Control = this.simpleButton3;
		this.layoutControlItem5.Location = new System.Drawing.Point(132, 529);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(132, 28);
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.Location = new System.Drawing.Point(264, 529);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(395, 28);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(784, 561);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "VouchersReview";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Vouchers Review";
		((System.ComponentModel.ISupportInitialize)this.myGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.myGridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		base.ResumeLayout(false);
	}
}
