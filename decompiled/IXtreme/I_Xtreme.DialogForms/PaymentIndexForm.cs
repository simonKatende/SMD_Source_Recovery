using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace I_Xtreme.DialogForms;

public class PaymentIndexForm : XtraForm
{
	private IContainer components = null;

	private MyGridControl gridControl9;

	private MyGridView gridView2;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	public PaymentIndexForm()
	{
		InitializeComponent();
		LoadPaymentIndex();
	}

	private void LoadPaymentIndex()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from tbl_generalAccounts_Sub WHERE accNo LIKE '1%'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		gridControl9.DataSource = dataTable;
	}

	private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
	{
		int result = (int.TryParse(gridView2.GetRowCellValue(e.RowHandle, "PaymentIndex").ToString(), out result) ? result : 0);
		string value = gridView2.GetRowCellValue(e.RowHandle, "subAccountNo").ToString();
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			CommandText = "UPDATE tbl_generalAccounts_Sub SET PaymentIndex=@PaymentIndex WHERE subAccountNo=@subAccountNo",
			CommandType = CommandType.Text,
			Connection = sqlConnection
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@PaymentIndex", result);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@subAccountNo", value);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
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
		this.gridControl9 = new AlienAge.CustomGrid.MyGridControl();
		this.gridView2 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		((System.ComponentModel.ISupportInitialize)this.gridControl9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		base.SuspendLayout();
		this.gridControl9.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl9.Location = new System.Drawing.Point(0, 0);
		this.gridControl9.MainView = this.gridView2;
		this.gridControl9.Name = "gridControl9";
		this.gridControl9.Size = new System.Drawing.Size(573, 601);
		this.gridControl9.TabIndex = 2;
		this.gridControl9.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridView2.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.EvenRow.Options.UseFont = true;
		this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView2.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView2.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.White;
		this.gridView2.Appearance.GroupRow.BackColor2 = System.Drawing.Color.White;
		this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
		this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
		this.gridView2.Appearance.GroupRow.Options.UseFont = true;
		this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
		this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.OddRow.Options.UseFont = true;
		this.gridView2.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.Preview.Options.UseFont = true;
		this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.Row.Options.UseFont = true;
		this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView2.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridView2.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridView2.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridView2.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.Transparent;
		this.gridView2.AppearancePrint.GroupRow.BackColor2 = System.Drawing.Color.Transparent;
		this.gridView2.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black;
		this.gridView2.AppearancePrint.GroupRow.Options.UseBackColor = true;
		this.gridView2.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.GroupRow.Options.UseForeColor = true;
		this.gridView2.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridView2.AppearancePrint.Lines.BackColor = System.Drawing.Color.Transparent;
		this.gridView2.AppearancePrint.Lines.BackColor2 = System.Drawing.Color.Transparent;
		this.gridView2.AppearancePrint.Lines.Options.UseBackColor = true;
		this.gridView2.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.Preview.Options.UseFont = true;
		this.gridView2.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.AppearancePrint.Row.Options.UseFont = true;
		this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridColumn1, this.gridColumn2, this.gridColumn3 });
		this.gridView2.DetailHeight = 239;
		this.gridView2.GridControl = this.gridControl9;
		this.gridView2.GroupFormat = "{1}";
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView2.OptionsCustomization.AllowFilter = false;
		this.gridView2.OptionsCustomization.AllowQuickHideColumns = false;
		this.gridView2.OptionsEditForm.PopupEditFormWidth = 533;
		this.gridView2.OptionsMenu.EnableFooterMenu = false;
		this.gridView2.OptionsPrint.PrintGroupFooter = false;
		this.gridView2.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.gridView2.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.gridView2.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView2.OptionsView.ShowIndicator = false;
		this.gridView2.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView2_CellValueChanged);
		this.gridColumn1.Caption = "Acc No";
		this.gridColumn1.FieldName = "subAccountNo";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.OptionsColumn.AllowEdit = false;
		this.gridColumn1.OptionsColumn.ReadOnly = true;
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn2.Caption = "Name";
		this.gridColumn2.FieldName = "SubAccoutName";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.OptionsColumn.AllowEdit = false;
		this.gridColumn2.OptionsColumn.ReadOnly = true;
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn3.Caption = "Payment Index";
		this.gridColumn3.FieldName = "PaymentIndex";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 2;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(573, 601);
		base.Controls.Add(this.gridControl9);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "PaymentIndexForm";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Payment Index";
		((System.ComponentModel.ISupportInitialize)this.gridControl9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		base.ResumeLayout(false);
	}
}
