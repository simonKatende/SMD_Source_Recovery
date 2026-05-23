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

public class MultipleItems : XtraForm
{
	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private GridControl gridControl1;

	private LayoutControlItem layoutControlItem1;

	private SimpleButton simpleButton1;

	public LabelControl lblSemester;

	public LabelControl lblStudNo;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private PanelControl panelControl1;

	private SimpleButton simpleButton2;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private Timer timer1;

	private GridColumn gridColumn3;

	public GridView gridView1;

	public MultipleItems()
	{
		InitializeComponent();
	}

	public void SaveCurrentlySelectedItems()
	{
		using DataTable dataTable = new DataTable();
		dataTable.Columns.Add(new DataColumn("prCode", Type.GetType("System.Int32")));
		dataTable.Columns.Add(new DataColumn("prName", Type.GetType("System.String")));
		dataTable.Columns.Add(new DataColumn("prPrice", Type.GetType("System.String")));
		for (int i = 0; i < gridView1.RowCount; i++)
		{
			int result = (int.TryParse(gridView1.GetRowCellValue(i, "accNo").ToString(), out result) ? result : 0);
			double result2 = (double.TryParse(gridView1.GetRowCellValue(i, "Amount").ToString(), out result2) ? result2 : 0.0);
			string value = gridView1.GetRowCellValue(i, "RequirementName").ToString();
			if (result2 > 0.0)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["prCode"] = result;
				dataRow["prName"] = value;
				dataRow["prPrice"] = result2.ToString();
				dataTable.Rows.Add(dataRow);
			}
		}
		MultipleFeesPayment.SavePayableItems(dataTable);
	}

	private void LoadStudentPaymentDetails()
	{
		try
		{
			using (new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				string selectCommandText = $"SELECT StudentNumber,accNo,Particulars AS RequirementName,SemesterId,SUM(Balance-Balance) AS Amount from FeesPayment WHERE StudentNumber='{lblStudNo.Text}' AND SemesterId='{lblSemester.Text}' AND Credit=0 GROUP BY StudentNumber,accNo,Particulars,SemesterId";
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "Classes");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				gridControl1.DataSource = dataTable.DefaultView;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void MultipleItems_Load(object sender, EventArgs e)
	{
		LoadStudentPaymentDetails();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		GridColumnSummaryItem gridColumnSummaryItem = new GridColumnSummaryItem();
		gridColumnSummaryItem.SetSummary(SummaryItemType.Sum, "{0:#,#.0}");
		gridColumnSummaryItem.FieldName = "Amount";
		gridView1.Columns["Amount"].SummaryItem.Assign(gridColumnSummaryItem);
	}

	private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
	{
		if (gridView1.FocusedRowHandle > -1 && gridView1.Columns.ColumnByFieldName("Amount").FieldName == "Amount" && !double.TryParse(e.Value.ToString(), out var _))
		{
			e.Valid = false;
		}
	}

	private void gridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
	{
		e.ExceptionMode = ExceptionMode.DisplayError;
		e.WindowCaption = "Input Error";
		e.ErrorText = "You have to enter digits only";
		gridView1.HideEditor();
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		SaveCurrentlySelectedItems();
		MultipleFeesPayment.UseMultiplePayMode(payMode: true);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void MultipleItems_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			SaveCurrentlySelectedItems();
			MultipleFeesPayment.UseMultiplePayMode(payMode: true);
			base.DialogResult = DialogResult.OK;
			Close();
		}
		else if (e.KeyCode == Keys.Escape)
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.lblSemester = new DevExpress.XtraEditors.LabelControl();
		this.lblStudNo = new DevExpress.XtraEditors.LabelControl();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.panelControl1);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.lblSemester);
		this.layoutControl1.Controls.Add(this.lblStudNo);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(566, 466);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl1.Location = new System.Drawing.Point(128, 442);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(322, 22);
		this.panelControl1.TabIndex = 11;
		this.simpleButton2.Location = new System.Drawing.Point(2, 442);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(122, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 10;
		this.simpleButton2.Text = "Cancel";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.simpleButton1.Location = new System.Drawing.Point(454, 442);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(110, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 7;
		this.simpleButton1.Text = "Continue";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.lblSemester.Location = new System.Drawing.Point(69, 2);
		this.lblSemester.Name = "lblSemester";
		this.lblSemester.Size = new System.Drawing.Size(63, 13);
		this.lblSemester.StyleController = this.layoutControl1;
		this.lblSemester.TabIndex = 6;
		this.lblSemester.Text = "labelControl2";
		this.lblStudNo.Location = new System.Drawing.Point(2, 2);
		this.lblStudNo.Name = "lblStudNo";
		this.lblStudNo.Size = new System.Drawing.Size(63, 13);
		this.lblStudNo.StyleController = this.layoutControl1;
		this.lblStudNo.TabIndex = 5;
		this.lblStudNo.Text = "labelControl1";
		this.gridControl1.Location = new System.Drawing.Point(2, 19);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(562, 419);
		this.gridControl1.TabIndex = 4;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridColumn3, this.gridColumn1, this.gridColumn2 });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridView1.OptionsView.ShowFooter = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(gridView1_ValidatingEditor);
		this.gridView1.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(gridView1_InvalidValueException);
		this.gridColumn3.Caption = "AccNo";
		this.gridColumn3.FieldName = "accNo";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 0;
		this.gridColumn1.Caption = "Particulars";
		this.gridColumn1.FieldName = "RequirementName";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 1;
		this.gridColumn2.Caption = "Amount";
		this.gridColumn2.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn2.FieldName = "Amount";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 2;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[6] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(566, 466);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 17);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(566, 423);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.lblStudNo;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(67, 17);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutControlItem3.Control = this.lblSemester;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(67, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(499, 17);
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutControlItem4.Control = this.simpleButton1;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(452, 440);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(114, 26);
		this.layoutControlItem4.Text = "layoutControlItem4";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextToControlDistance = 0;
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlItem5.Control = this.simpleButton2;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 440);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(126, 26);
		this.layoutControlItem5.Text = "layoutControlItem5";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextToControlDistance = 0;
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem6.Control = this.panelControl1;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(126, 440);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(326, 26);
		this.layoutControlItem6.Text = "layoutControlItem6";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextToControlDistance = 0;
		this.layoutControlItem6.TextVisible = false;
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(566, 466);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.Name = "MultipleItems";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Multiple Items";
		base.Load += new System.EventHandler(MultipleItems_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(MultipleItems_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		base.ResumeLayout(false);
	}
}
