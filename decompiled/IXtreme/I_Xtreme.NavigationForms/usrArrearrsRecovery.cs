using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Data;
using DevExpress.Data.Mask;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.NavigationForms;

public class usrArrearrsRecovery : XtraUserControl
{
	private DataTable dt;

	private string _term = string.Empty;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private MyGridControl gridControl1;

	private MyGridView dragOver;

	private LayoutControlItem layoutControlItem1;

	private Timer timer1;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn8;

	private RepositoryItemTextEdit repositoryItemTextEdit2;

	private RepositoryItemTextEdit repositoryItemTextEdit1;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem13;

	private GridColumn gridColumn3;

	private GridColumn gridColumn2;

	private GridColumn gridColumn6;

	private GridColumn gridColumn1;

	public usrArrearrsRecovery(string term)
	{
		InitializeComponent();
		_term = term;
		LoadTempCheque();
	}

	private void LoadTempCheque()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT s.StudentNumber, s.fullName, s.ClassId, s.StreamId, s.Sex, s.StudyStatus,f.SemesterId, f.accNo,f.Particulars,f.Credit,f.DateOfPayment,f.BankSlipNo\r\nFROM    tbl_oldStudents s INNER JOIN  dbo.FeesPayment f ON s.StudentNumber =f.StudentNumber WHERE   (f.Credit > 0) AND (f.SemesterId = '{_term}')", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "feesarrears");
		dt = new DataTable();
		dt = dataSet.Tables[0];
		gridControl1.DataSource = dt.DefaultView;
		PrintableControl.SavePrintableControl(gridControl1);
		ActiveFormSelected.SetActiveForm("Fees Arrears Recovery");
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
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.gridControl1 = new AlienAge.CustomGrid.MyGridControl();
		this.dragOver = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dragOver).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(870, 488);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseTextOptions = true;
		this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Location = new System.Drawing.Point(4, 4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(862, 24);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 16;
		this.labelControl1.Text = "Fees Arrears Recovery";
		this.gridControl1.AllowDrop = true;
		this.gridControl1.Location = new System.Drawing.Point(4, 32);
		this.gridControl1.MainView = this.dragOver;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[2] { this.repositoryItemTextEdit1, this.repositoryItemTextEdit2 });
		this.gridControl1.Size = new System.Drawing.Size(862, 452);
		this.gridControl1.TabIndex = 4;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.dragOver });
		this.dragOver.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.FilterPanel.Options.UseFont = true;
		this.dragOver.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.dragOver.Appearance.FocusedCell.Options.UseBackColor = true;
		this.dragOver.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.dragOver.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.FocusedRow.Options.UseBackColor = true;
		this.dragOver.Appearance.FocusedRow.Options.UseFont = true;
		this.dragOver.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.FooterPanel.Options.UseFont = true;
		this.dragOver.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.GroupFooter.Options.UseFont = true;
		this.dragOver.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.GroupRow.Options.UseFont = true;
		this.dragOver.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.HeaderPanel.Options.UseFont = true;
		this.dragOver.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.dragOver.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.dragOver.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.Preview.Options.UseFont = true;
		this.dragOver.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.Row.Options.UseFont = true;
		this.dragOver.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.dragOver.Appearance.SelectedRow.Options.UseBackColor = true;
		this.dragOver.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.TopNewRow.Options.UseFont = true;
		this.dragOver.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[7] { this.gridColumn3, this.gridColumn2, this.gridColumn5, this.gridColumn4, this.gridColumn6, this.gridColumn1, this.gridColumn8 });
		this.dragOver.FixedLineWidth = 3;
		this.dragOver.GridControl = this.gridControl1;
		this.dragOver.GroupFormat = "{1}";
		this.dragOver.Name = "dragOver";
		this.dragOver.OptionsBehavior.AutoExpandAllGroups = true;
		this.dragOver.OptionsCustomization.AllowGroup = false;
		this.dragOver.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.dragOver.OptionsView.ShowFooter = true;
		this.dragOver.OptionsView.ShowGroupPanel = false;
		this.dragOver.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.dragOver.OptionsView.ShowIndicator = false;
		this.dragOver.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
		this.gridColumn5.Caption = "Particulars";
		this.gridColumn5.FieldName = "ExpenseType";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.OptionsColumn.AllowEdit = false;
		this.gridColumn5.OptionsColumn.ReadOnly = true;
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 2;
		this.gridColumn5.Width = 304;
		this.gridColumn4.Caption = "Term";
		this.gridColumn4.FieldName = "SemesterId";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.OptionsColumn.AllowEdit = false;
		this.gridColumn4.OptionsColumn.ReadOnly = true;
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 3;
		this.gridColumn4.Width = 201;
		this.repositoryItemTextEdit2.AutoHeight = false;
		this.repositoryItemTextEdit2.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
		this.repositoryItemTextEdit2.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
		this.repositoryItemTextEdit2.MaskSettings.Set("mask", "##,###,###,###");
		this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
		this.repositoryItemTextEdit2.UseMaskAsDisplayFormat = true;
		this.repositoryItemTextEdit1.AutoHeight = false;
		this.repositoryItemTextEdit1.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
		this.repositoryItemTextEdit1.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
		this.repositoryItemTextEdit1.MaskSettings.Set("mask", "##,###,###,###");
		this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
		this.repositoryItemTextEdit1.UseMaskAsDisplayFormat = true;
		this.gridColumn8.Caption = "Payment";
		this.gridColumn8.DisplayFormat.FormatString = "{0:#,#}";
		this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn8.FieldName = "Credit";
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.OptionsColumn.AllowEdit = false;
		this.gridColumn8.OptionsColumn.ReadOnly = true;
		this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", "{0:#,#}")
		});
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 6;
		this.gridColumn8.Width = 340;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlItem1, this.layoutControlItem13 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(870, 488);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(866, 456);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem13.Control = this.labelControl1;
		this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem13.Name = "layoutControlItem13";
		this.layoutControlItem13.Size = new System.Drawing.Size(866, 28);
		this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem13.TextVisible = false;
		this.gridColumn2.Caption = "Student No.";
		this.gridColumn2.FieldName = "StudentNumber";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn2.Width = 195;
		this.gridColumn3.Caption = "Name";
		this.gridColumn3.FieldName = "fullName";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 0;
		this.gridColumn3.Width = 197;
		this.gridColumn1.Caption = "Trx. Ref.";
		this.gridColumn1.FieldName = "BankSlipNo";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 5;
		this.gridColumn1.Width = 154;
		this.gridColumn6.Caption = "Date";
		this.gridColumn6.DisplayFormat.FormatString = "dd.MMM.yy";
		this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.gridColumn6.FieldName = "DateOfPayment";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 4;
		this.gridColumn6.Width = 147;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrArrearrsRecovery";
		base.Size = new System.Drawing.Size(870, 488);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dragOver).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).EndInit();
		base.ResumeLayout(false);
	}
}
