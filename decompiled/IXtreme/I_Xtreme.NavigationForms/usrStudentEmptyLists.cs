using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrStudentEmptyLists : XtraUserControl
{
	private DataSet student_DataSet;

	private DataTable student_dataTable;

	private IContainer components = null;

	private MyGridControl gridEmptyLists;

	private MyGridView gridViewEmptyLists;

	private GridColumn colBNo;

	private GridColumn gridColumn33;

	private GridColumn gridColumn31;

	private GridColumn gridColumn34;

	private GridColumn gridColumn35;

	private GridColumn gridColumn36;

	private GridColumn gridColumn37;

	private GridColumn gridColumn38;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private GridColumn gridColumnStream;

	public usrStudentEmptyLists()
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Loading Students' List...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.LoadStudentList, 0);
		Thread.Sleep(25);
		InitializeComponent();
		LoadCustomStudent();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	private void LoadCustomStudent()
	{
		WaitDialogForm waitDialogForm = new WaitDialogForm();
		try
		{
			string arg = StudentOptions.ActiveClass();
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT UPPER(fullName) AS fullName,UPPER(StudentNumber) AS StudentNumber,StreamId AS Stream FROM tbl_Stud WHERE ClassId='{arg}'", selectConnection);
			student_DataSet = new DataSet();
			waitDialogForm.SetCaption("Students' List is being populated");
			sqlDataAdapter.Fill(student_DataSet, "studentRecords");
			student_dataTable = new DataTable();
			student_dataTable = student_DataSet.Tables[0];
			gridEmptyLists.DataSource = student_dataTable.DefaultView;
			PrintableControl.SavePrintableControl(gridEmptyLists);
			PrintableControl.SavePrintableControl(gridViewEmptyLists);
			ActiveFormSelected.SetActiveForm("Students' Empty Lists");
			if (gridViewEmptyLists.RowCount > 1)
			{
				gridViewEmptyLists.FocusedRowHandle = 1;
			}
			waitDialogForm.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
			waitDialogForm.Close();
		}
	}

	private void gridViewEmptyLists_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column == colBNo && e.ListSourceRowIndex > -1)
		{
			e.DisplayText = (gridViewEmptyLists.GetRowHandle(e.ListSourceRowIndex) + 1).ToString();
		}
	}

	private void usrStudentEmptyLists_Load(object sender, EventArgs e)
	{
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
		this.gridEmptyLists = new AlienAge.CustomGrid.MyGridControl();
		this.gridViewEmptyLists = new AlienAge.CustomGrid.MyGridView();
		this.colBNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumnStream = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.gridEmptyLists).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewEmptyLists).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		base.SuspendLayout();
		this.gridEmptyLists.Location = new System.Drawing.Point(7, 7);
		this.gridEmptyLists.MainView = this.gridViewEmptyLists;
		this.gridEmptyLists.Name = "gridEmptyLists";
		this.gridEmptyLists.Size = new System.Drawing.Size(829, 516);
		this.gridEmptyLists.TabIndex = 1;
		this.gridEmptyLists.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewEmptyLists });
		this.gridViewEmptyLists.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gridViewEmptyLists.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gridViewEmptyLists.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.DetailTip.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.Empty.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridViewEmptyLists.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.EvenRow.Options.UseBackColor = true;
		this.gridViewEmptyLists.Appearance.EvenRow.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.FilterPanel.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.FixedLine.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewEmptyLists.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridViewEmptyLists.Appearance.FocusedCell.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewEmptyLists.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridViewEmptyLists.Appearance.FocusedRow.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.FooterPanel.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.GroupButton.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.GroupFooter.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.GroupPanel.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.GroupRow.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gridViewEmptyLists.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewEmptyLists.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridViewEmptyLists.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.HorzLine.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.OddRow.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.Preview.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.Row.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.RowSeparator.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewEmptyLists.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridViewEmptyLists.Appearance.SelectedRow.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.TopNewRow.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.VertLine.Options.UseFont = true;
		this.gridViewEmptyLists.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.Appearance.ViewCaption.Options.UseFont = true;
		this.gridViewEmptyLists.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridViewEmptyLists.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.gridViewEmptyLists.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridViewEmptyLists.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridViewEmptyLists.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridViewEmptyLists.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridViewEmptyLists.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridViewEmptyLists.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridViewEmptyLists.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.AppearancePrint.Lines.Options.UseFont = true;
		this.gridViewEmptyLists.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridViewEmptyLists.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.AppearancePrint.Preview.Options.UseFont = true;
		this.gridViewEmptyLists.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmptyLists.AppearancePrint.Row.Options.UseFont = true;
		this.gridViewEmptyLists.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[9] { this.colBNo, this.gridColumn33, this.gridColumn31, this.gridColumnStream, this.gridColumn34, this.gridColumn35, this.gridColumn36, this.gridColumn37, this.gridColumn38 });
		this.gridViewEmptyLists.GridControl = this.gridEmptyLists;
		this.gridViewEmptyLists.Name = "gridViewEmptyLists";
		this.gridViewEmptyLists.OptionsBehavior.Editable = false;
		this.gridViewEmptyLists.OptionsFind.AlwaysVisible = true;
		this.gridViewEmptyLists.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridViewEmptyLists.OptionsView.EnableAppearanceEvenRow = true;
		this.gridViewEmptyLists.OptionsView.ShowAutoFilterRow = true;
		this.gridViewEmptyLists.OptionsView.ShowFooter = true;
		this.gridViewEmptyLists.OptionsView.ShowGroupPanel = false;
		this.gridViewEmptyLists.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridViewEmptyLists.OptionsView.ShowIndicator = false;
		this.gridViewEmptyLists.RowHeight = 30;
		this.gridViewEmptyLists.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridViewEmptyLists_CustomColumnDisplayText);
		this.colBNo.Caption = "No";
		this.colBNo.Name = "colBNo";
		this.colBNo.Visible = true;
		this.colBNo.VisibleIndex = 0;
		this.colBNo.Width = 42;
		this.gridColumn33.Caption = "StudentNo";
		this.gridColumn33.FieldName = "StudentNumber";
		this.gridColumn33.Name = "gridColumn33";
		this.gridColumn33.Visible = true;
		this.gridColumn33.VisibleIndex = 1;
		this.gridColumn33.Width = 152;
		this.gridColumn31.Caption = "Name";
		this.gridColumn31.FieldName = "fullName";
		this.gridColumn31.Name = "gridColumn31";
		this.gridColumn31.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "fullName", "TOTAL STUDENTS: {0:#,#}")
		});
		this.gridColumn31.Visible = true;
		this.gridColumn31.VisibleIndex = 2;
		this.gridColumn31.Width = 200;
		this.gridColumnStream.Caption = "Stream";
		this.gridColumnStream.FieldName = "Stream";
		this.gridColumnStream.Name = "gridColumnStream";
		this.gridColumnStream.Visible = true;
		this.gridColumnStream.VisibleIndex = 3;
		this.gridColumn34.Name = "gridColumn34";
		this.gridColumn34.Visible = true;
		this.gridColumn34.VisibleIndex = 4;
		this.gridColumn34.Width = 154;
		this.gridColumn35.Name = "gridColumn35";
		this.gridColumn35.Visible = true;
		this.gridColumn35.VisibleIndex = 5;
		this.gridColumn35.Width = 154;
		this.gridColumn36.Name = "gridColumn36";
		this.gridColumn36.Visible = true;
		this.gridColumn36.VisibleIndex = 6;
		this.gridColumn36.Width = 154;
		this.gridColumn37.Name = "gridColumn37";
		this.gridColumn37.Visible = true;
		this.gridColumn37.VisibleIndex = 7;
		this.gridColumn37.Width = 154;
		this.gridColumn38.Name = "gridColumn38";
		this.gridColumn38.Visible = true;
		this.gridColumn38.VisibleIndex = 8;
		this.gridColumn38.Width = 170;
		this.layoutControl1.Controls.Add(this.gridEmptyLists);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(843, 530);
		this.layoutControl1.TabIndex = 2;
		this.layoutControl1.Text = "layoutControl1";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem1 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
		this.layoutControlGroup1.Size = new System.Drawing.Size(843, 530);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridEmptyLists;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(833, 520);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrStudentEmptyLists";
		base.Size = new System.Drawing.Size(843, 530);
		base.Load += new System.EventHandler(usrStudentEmptyLists_Load);
		((System.ComponentModel.ISupportInitialize)this.gridEmptyLists).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewEmptyLists).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		base.ResumeLayout(false);
	}
}
