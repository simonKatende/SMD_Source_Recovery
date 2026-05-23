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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace I_Xtreme.DialogForms;

public class LedgerUpdateProgress : XtraForm
{
	private string StudentNo = string.Empty;

	private DataTable dt_FeesLedger;

	private int i = 0;

	private SqlTransaction trans;

	private IContainer components = null;

	private ProgressBarControl progressBarControl1;

	private MyGridControl gridStudentPayment;

	private MyGridView gridViewStudentPayment;

	private GridColumn gridColDate;

	private GridColumn gridColRef;

	private GridColumn gridColSemester;

	private GridColumn gridColParticulars;

	private GridColumn gridColBills;

	private GridColumn gridColPayment;

	private GridColumn gridColBalance;

	private GridColumn gridColAmount;

	private GridColumn gridColumn3;

	private Timer timer1;

	public LedgerUpdateProgress(string _StudentNo)
	{
		InitializeComponent();
		StudentNo = _StudentNo;
		LoadStudentLegder();
	}

	private void UpdateFeesBalance()
	{
		try
		{
			if (gridViewStudentPayment.RowCount == 0)
			{
				double num = 0.0;
				SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandText = $"UPDATE tbl_Stud SET cashOnAccount={num} WHERE StudentNumber='{StudentNo}'",
					CommandType = CommandType.Text
				};
				if (sqlCommand.ExecuteNonQuery() > 0)
				{
					sqlConnection.Close();
					base.DialogResult = DialogResult.OK;
					Close();
				}
				return;
			}
			for (int i = 0; i < gridViewStudentPayment.RowCount; i++)
			{
				progressBarControl1.Properties.Maximum = gridViewStudentPayment.RowCount;
				double result = (double.TryParse(gridViewStudentPayment.GetRowCellValue(i, "Bal").ToString(), out result) ? result : 0.0);
				long num2 = Convert.ToInt64(gridViewStudentPayment.GetRowCellValue(i, "Ref").ToString());
				SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection2.Open();
				trans = sqlConnection2.BeginTransaction();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					Transaction = trans,
					CommandText = "UPDATE FeesPayment SET Balance=@Balance WHERE PaymentId=@PaymentId AND StudentNumber=@StudentNumber",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@PaymentId", SqlDbType.BigInt);
					sqlParameter.Value = num2;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
					sqlParameter.Value = StudentNo;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@Balance", SqlDbType.Money);
					sqlParameter.Value = result;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection2,
					Transaction = trans,
					CommandText = $"UPDATE tbl_Stud SET cashOnAccount={result} WHERE StudentNumber='{StudentNo}'",
					CommandType = CommandType.Text
				})
				{
					sqlCommand3.ExecuteNonQuery();
				}
				trans.Commit();
				sqlConnection2.Close();
				Application.DoEvents();
				progressBarControl1.Position = i;
				if (i == gridViewStudentPayment.RowCount - 1)
				{
					base.DialogResult = DialogResult.OK;
					Close();
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Dispose();
		}
	}

	private void LoadStudentLegder()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT PaymentId AS Ref, StudentNumber,DateOfPayment AS Date,BankId,accNo,BankSlipNo AS TRef,SemesterId AS Term,Particulars, Debit AS Dr, Credit AS Cr,(Debit-Credit) AS Amount FROM FeesPayment WHERE StudentNumber='{StudentNo}' ORDER BY PaymentId", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentLedger");
			dt_FeesLedger = new DataTable();
			dt_FeesLedger = dataSet.Tables[0];
			gridStudentPayment.DataSource = dt_FeesLedger.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Dispose();
		}
	}

	private void LedgerUpdateProgress_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void gridViewStudentPayment_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
	{
		GridView gridView = (GridView)sender;
		if (e.Column.FieldName == "Bal" && e.IsGetData)
		{
			decimal num = default(decimal);
			int rowHandle = gridView.GetRowHandle(e.ListSourceRowIndex);
			for (int i = -1; i <= rowHandle - 1; i++)
			{
				num += Convert.ToDecimal(gridView.GetRowCellValue(i + 1, "Amount"));
			}
			e.Value = num;
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		i++;
		if (i == 3)
		{
			timer1.Enabled = false;
			UpdateFeesBalance();
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
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		this.gridStudentPayment = new AlienAge.CustomGrid.MyGridControl();
		this.gridViewStudentPayment = new AlienAge.CustomGrid.MyGridView();
		this.gridColDate = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColRef = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColSemester = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColParticulars = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColBills = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColPayment = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColBalance = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColAmount = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridStudentPayment).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewStudentPayment).BeginInit();
		base.SuspendLayout();
		this.progressBarControl1.Location = new System.Drawing.Point(13, 13);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Size = new System.Drawing.Size(343, 18);
		this.progressBarControl1.TabIndex = 0;
		this.gridStudentPayment.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.gridStudentPayment.Location = new System.Drawing.Point(92, -197);
		this.gridStudentPayment.MainView = this.gridViewStudentPayment;
		this.gridStudentPayment.Name = "gridStudentPayment";
		this.gridStudentPayment.Size = new System.Drawing.Size(103, 17);
		this.gridStudentPayment.TabIndex = 14;
		this.gridStudentPayment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewStudentPayment });
		this.gridViewStudentPayment.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewStudentPayment.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridViewStudentPayment.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewStudentPayment.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridViewStudentPayment.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewStudentPayment.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridViewStudentPayment.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewStudentPayment.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridViewStudentPayment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[9] { this.gridColDate, this.gridColRef, this.gridColSemester, this.gridColParticulars, this.gridColBills, this.gridColPayment, this.gridColBalance, this.gridColAmount, this.gridColumn3 });
		this.gridViewStudentPayment.GridControl = this.gridStudentPayment;
		this.gridViewStudentPayment.Name = "gridViewStudentPayment";
		this.gridViewStudentPayment.OptionsBehavior.Editable = false;
		this.gridViewStudentPayment.OptionsCustomization.AllowGroup = false;
		this.gridViewStudentPayment.OptionsCustomization.AllowSort = false;
		this.gridViewStudentPayment.OptionsPrint.PrintFooter = false;
		this.gridViewStudentPayment.OptionsPrint.PrintGroupFooter = false;
		this.gridViewStudentPayment.OptionsPrint.PrintHorzLines = false;
		this.gridViewStudentPayment.OptionsView.ShowFooter = true;
		this.gridViewStudentPayment.OptionsView.ShowGroupPanel = false;
		this.gridViewStudentPayment.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridViewStudentPayment.OptionsView.ShowIndicator = false;
		this.gridViewStudentPayment.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(gridViewStudentPayment_CustomUnboundColumnData);
		this.gridColDate.Caption = "Date";
		this.gridColDate.DisplayFormat.FormatString = "dd-MMM-yy";
		this.gridColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.gridColDate.FieldName = "Date";
		this.gridColDate.Name = "gridColDate";
		this.gridColDate.Visible = true;
		this.gridColDate.VisibleIndex = 0;
		this.gridColDate.Width = 56;
		this.gridColRef.Caption = "T_REF";
		this.gridColRef.FieldName = "TRef";
		this.gridColRef.Name = "gridColRef";
		this.gridColRef.Visible = true;
		this.gridColRef.VisibleIndex = 2;
		this.gridColRef.Width = 46;
		this.gridColSemester.Caption = "Semester";
		this.gridColSemester.FieldName = "Term";
		this.gridColSemester.Name = "gridColSemester";
		this.gridColSemester.Visible = true;
		this.gridColSemester.VisibleIndex = 1;
		this.gridColSemester.Width = 80;
		this.gridColParticulars.Caption = "Particulars";
		this.gridColParticulars.FieldName = "Particulars";
		this.gridColParticulars.Name = "gridColParticulars";
		this.gridColParticulars.Visible = true;
		this.gridColParticulars.VisibleIndex = 3;
		this.gridColParticulars.Width = 100;
		this.gridColBills.Caption = "Bills";
		this.gridColBills.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColBills.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColBills.FieldName = "Dr";
		this.gridColBills.Name = "gridColBills";
		this.gridColBills.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Dr", "{0:#,#.0}")
		});
		this.gridColBills.Visible = true;
		this.gridColBills.VisibleIndex = 4;
		this.gridColBills.Width = 84;
		this.gridColPayment.Caption = "Payment";
		this.gridColPayment.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColPayment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColPayment.FieldName = "Cr";
		this.gridColPayment.Name = "gridColPayment";
		this.gridColPayment.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cr", "{0:#,#.0}")
		});
		this.gridColPayment.Visible = true;
		this.gridColPayment.VisibleIndex = 5;
		this.gridColPayment.Width = 84;
		this.gridColBalance.Caption = "Balance";
		this.gridColBalance.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColBalance.FieldName = "Bal";
		this.gridColBalance.Name = "gridColBalance";
		this.gridColBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Bal", "{0:#,#.0}")
		});
		this.gridColBalance.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
		this.gridColBalance.Visible = true;
		this.gridColBalance.VisibleIndex = 6;
		this.gridColBalance.Width = 89;
		this.gridColAmount.Caption = "Amount";
		this.gridColAmount.FieldName = "Amount";
		this.gridColAmount.Name = "gridColAmount";
		this.gridColumn3.Caption = "PaymentID";
		this.gridColumn3.FieldName = "Ref";
		this.gridColumn3.Name = "gridColumn3";
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(367, 41);
		base.ControlBox = false;
		base.Controls.Add(this.progressBarControl1);
		base.Controls.Add(this.gridStudentPayment);
		base.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Default;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "LedgerUpdateProgress";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Updating Ledger. Please wait...";
		base.Load += new System.EventHandler(LedgerUpdateProgress_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridStudentPayment).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewStudentPayment).EndInit();
		base.ResumeLayout(false);
	}
}
