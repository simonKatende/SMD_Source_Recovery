using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrRankingOLNC : XtraUserControl
{
	private string ClassEn = string.Empty;

	private string Term = string.Empty;

	private int scopeIndex = 0;

	private string subHeader = string.Empty;

	private IOverlaySplashScreenHandle handle = null;

	private IContainer components = null;

	private GridControl gridControl1;

	private GridView gridView1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private LayoutControl layoutControl1;

	private LabelControl lblSubHeader;

	private LabelControl lblHeader;

	private LayoutControlGroup Root;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private IOverlaySplashScreenHandle ShowProgressPanel()
	{
		return SplashScreenManager.ShowOverlayForm(this);
	}

	private void CloseProgressPanel(IOverlaySplashScreenHandle handle)
	{
		if (handle != null)
		{
			SplashScreenManager.CloseOverlayForm(handle);
		}
	}

	public usrRankingOLNC(string ClassEn, string Term, int scopeIndex)
	{
		InitializeComponent();
		Dock = DockStyle.Fill;
		this.ClassEn = ClassEn;
		this.Term = Term;
		this.scopeIndex = scopeIndex;
	}

	private void LoadMarks()
	{
		try
		{
			string selectCommandText = string.Empty;
			if (scopeIndex == 0)
			{
				selectCommandText = $"SELECT s.fullName, s.StudentNumber,  s.ClassId, s.StreamId,  sc.SemesterId,  AVG(sc.OutOfHund) AS OutOfHund,  RANK() OVER (PARTITION BY s.ClassId ORDER BY AVG(sc.OutOfHund) DESC) AS RankByClassId,  RANK() OVER (PARTITION BY s.StreamId ORDER BY AVG(sc.OutOfHund) DESC) AS RankByStreamId FROM tbl_Scores_OL_Report sc INNER JOIN dbo.tbl_Stud s ON sc.StudentNumber = s.StudentNumber AND sc.ClassId = s.ClassId GROUP BY s.fullName, s.StudentNumber,  s.ClassId,  s.StreamId, sc.SemesterId HAVING(s.ClassId = '{ClassEn}') AND(sc.SemesterId = '{Term}')";
				subHeader = "Analysis based on Assessment of Integration only";
			}
			else if (scopeIndex == 1)
			{
				selectCommandText = $"SELECT s.fullName, s.StudentNumber,  s.ClassId, s.StreamId,  sc.SemesterId,  AVG(sc.ETAv) AS OutOfHund,  RANK() OVER (PARTITION BY s.ClassId ORDER BY AVG(sc.ETAv) DESC) AS RankByClassId,  RANK() OVER (PARTITION BY s.StreamId ORDER BY AVG(sc.ETAv) DESC) AS RankByStreamId FROM tbl_Scores_OL_Report sc INNER JOIN dbo.tbl_Stud s ON sc.StudentNumber = s.StudentNumber AND sc.ClassId = s.ClassId GROUP BY s.fullName, s.StudentNumber,  s.ClassId,  s.StreamId, sc.SemesterId HAVING(s.ClassId = '{ClassEn}') AND(sc.SemesterId = '{Term}')";
				subHeader = "Analysis based on Assessment of Integration and EOT Examination";
			}
			else if (scopeIndex == 2)
			{
				selectCommandText = $"SELECT s.fullName, s.StudentNumber, s.ClassId, s.StreamId,  sc.SemesterId, AVG(ISNULL(TRY_CAST(sc.ETA AS FLOAT), 0)) AS OutOfHund, RANK() OVER (PARTITION BY s.ClassId ORDER BY AVG(ISNULL(TRY_CAST(sc.ETA AS FLOAT), 0)) DESC) AS RankByClassId,\r\nRANK() OVER (PARTITION BY s.StreamId ORDER BY AVG(ISNULL(TRY_CAST(sc.ETA AS FLOAT), 0)) DESC) AS RankByStreamId FROM tbl_Scores_OL_Report sc INNER JOIN  tbl_Stud s ON sc.StudentNumber = s.StudentNumber AND sc.ClassId = s.ClassId GROUP BY s.fullName, s.StudentNumber,  s.ClassId, s.StreamId, sc.SemesterId HAVING  (s.ClassId = '{ClassEn}') AND (sc.SemesterId = '{Term}')";
				subHeader = "Analysis based on EOT Examination only";
			}
			lblHeader.Text = "Students' Class Ranking. " + ClassEn + "-" + Term;
			lblSubHeader.Text = subHeader;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			gridControl1.DataSource = dataTable.DefaultView;
			PrintableControl.SavePrintableControl(gridControl1);
			MarkSheet.SetGridViewType("Ranking");
			MarkSheet.SetMarkSheetViewType("GridControl");
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
		}
	}

	private void usrMarkSheetOLAdvance_Load(object sender, EventArgs e)
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Generating Ranking...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.GenerateMarkSheet, 0);
		Thread.Sleep(25);
		LoadMarks();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	private void pivotGridControl1_FieldValueDisplayText(object sender, PivotFieldDisplayTextEventArgs e)
	{
		if (e.ValueType == PivotGridValueType.GrandTotal)
		{
			if (e.IsColumn)
			{
				e.DisplayText = "Total Students";
			}
			else
			{
				e.DisplayText = "Custom Row Grand Total";
			}
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
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.lblSubHeader = new DevExpress.XtraEditors.LabelControl();
		this.lblHeader = new DevExpress.XtraEditors.LabelControl();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.gridControl1.Location = new System.Drawing.Point(12, 64);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(991, 637);
		this.gridControl1.TabIndex = 0;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.DetailTip.Options.UseFont = true;
		this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.Empty.Options.UseFont = true;
		this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.EvenRow.Options.UseFont = true;
		this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.FixedLine.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.GroupButton.Options.UseFont = true;
		this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.HorzLine.Options.UseFont = true;
		this.gridView1.Appearance.HotTrackedRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.HotTrackedRow.Options.UseFont = true;
		this.gridView1.Appearance.NoSearchResults.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.NoSearchResults.Options.UseFont = true;
		this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.OddRow.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.VertLine.Options.UseFont = true;
		this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView1.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.gridView1.AppearancePrint.EvenRow.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.gridView1.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.EvenRow.ForeColor = System.Drawing.Color.Black;
		this.gridView1.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.gridView1.AppearancePrint.EvenRow.Options.UseBorderColor = true;
		this.gridView1.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.EvenRow.Options.UseForeColor = true;
		this.gridView1.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.Lines.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.Lines.Options.UseFont = true;
		this.gridView1.AppearancePrint.OddRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.Preview.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.Preview.Options.UseFont = true;
		this.gridView1.AppearancePrint.Row.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.Row.Options.UseFont = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[6] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn6, this.gridColumn4, this.gridColumn5 });
		this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
		this.gridView1.OptionsFind.AlwaysVisible = true;
		this.gridView1.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridColumn1.Caption = "Name";
		this.gridColumn1.FieldName = "fullName";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 314;
		this.gridColumn2.Caption = "Student No.";
		this.gridColumn2.FieldName = "StudentNumber";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn2.Width = 314;
		this.gridColumn3.Caption = "Stream";
		this.gridColumn3.FieldName = "StreamId";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 2;
		this.gridColumn3.Width = 78;
		this.gridColumn6.Caption = "Avg.";
		this.gridColumn6.DisplayFormat.FormatString = "n3";
		this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn6.FieldName = "OutOfHund";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 3;
		this.gridColumn6.Width = 78;
		this.gridColumn4.Caption = "Stm Pos.";
		this.gridColumn4.FieldName = "RankByStreamId";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.ToolTip = "Position in stream";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 4;
		this.gridColumn4.Width = 78;
		this.gridColumn5.Caption = "Cls Pos.";
		this.gridColumn5.FieldName = "RankByClassId";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.ToolTip = "Position in class";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 5;
		this.gridColumn5.Width = 78;
		this.layoutControl1.Controls.Add(this.lblSubHeader);
		this.layoutControl1.Controls.Add(this.lblHeader);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(1015, 713);
		this.layoutControl1.TabIndex = 1;
		this.layoutControl1.Text = "layoutControl1";
		this.lblSubHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.lblSubHeader.Appearance.Options.UseFont = true;
		this.lblSubHeader.Appearance.Options.UseTextOptions = true;
		this.lblSubHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblSubHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblSubHeader.Location = new System.Drawing.Point(12, 41);
		this.lblSubHeader.Name = "lblSubHeader";
		this.lblSubHeader.Size = new System.Drawing.Size(991, 19);
		this.lblSubHeader.StyleController = this.layoutControl1;
		this.lblSubHeader.TabIndex = 5;
		this.lblHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 16f);
		this.lblHeader.Appearance.Options.UseFont = true;
		this.lblHeader.Appearance.Options.UseTextOptions = true;
		this.lblHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblHeader.Location = new System.Drawing.Point(12, 12);
		this.lblHeader.Name = "lblHeader";
		this.lblHeader.Size = new System.Drawing.Size(991, 25);
		this.lblHeader.StyleController = this.layoutControl1;
		this.lblHeader.TabIndex = 4;
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3 });
		this.Root.Name = "Root";
		this.Root.Size = new System.Drawing.Size(1015, 713);
		this.Root.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 52);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(995, 641);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.lblHeader;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(995, 29);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.lblSubHeader;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 29);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(995, 23);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrRankingOLNC";
		base.Size = new System.Drawing.Size(1015, 713);
		base.Load += new System.EventHandler(usrMarkSheetOLAdvance_Load);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
