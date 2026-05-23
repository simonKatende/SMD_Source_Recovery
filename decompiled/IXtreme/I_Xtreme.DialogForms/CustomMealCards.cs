using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using I_Xtreme.MealCards;
using I_Xtreme.StudentIDs;

namespace I_Xtreme.DialogForms;

public class CustomMealCards : RibbonForm
{
	private DataTable dt;

	private DataTable _dt;

	private string __Class = string.Empty;

	private string __Stream = string.Empty;

	private string StudentNumber = string.Empty;

	private string _StudentNumber = string.Empty;

	private GridHitInfo downHitInfo = null;

	private IContainer components = null;

	private SplitContainerControl splitContainerControl1;

	private GridControl gridControl1;

	private GridView gridView1;

	private GridControl gridControl2;

	private GridView gridView2;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private GridColumn gridColumn7;

	private GridColumn gridColumn8;

	private GridColumn gridColumn9;

	private GridColumn colNo1;

	private GridColumn colNo2;

	private RibbonControl ribbonControl1;

	private RibbonPage ribbonPage1;

	private RibbonPageGroup ribbonPageGroup1;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private BarButtonItem barButtonItem4;

	private BarButtonItem barButtonItem5;

	public CustomMealCards(string _Class, string _Stream)
	{
		InitializeComponent();
		LoadMealCardArchive(_Class, _Stream);
		LoadStudentsForMealCards(_Class, _Stream);
		__Class = _Class;
		__Stream = _Stream;
	}

	private void LoadStudentsForMealCards(string _Class, string _Stream)
	{
		try
		{
			string selectCommandText = $"SELECT StudentNumber,fullName, StudyStatus, StreamId,Sex, BursaryStatus AS Bursary,cashOnAccount FROM tbl_Stud WHERE ClassId='{_Class}' AND StreamId='{_Stream}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Students");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			gridControl1.DataSource = dt.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadMealCardArchive(string _Class, string _Stream)
	{
		try
		{
			string selectCommandText = $"SELECT mc.StudentNumber, mc.mealCardId, s.fullName, s.ClassId, s.StreamId FROM  tbl_Stud s INNER JOIN tbl_MealCards mc ON s.StudentNumber = mc.StudentNumber WHERE ClassId='{_Class}' AND StreamId='{_Stream}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Students");
			_dt = new DataTable();
			_dt = dataSet.Tables[0];
			gridControl2.DataSource = _dt.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void DeleteSelectedEntry(string StudentNumber)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "DELETE FROM tbl_MealCards WHERE  StudentNumber=@StudentNumber",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
		sqlParameter.Value = StudentNumber;
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			LoadMealCardArchive(__Class, __Stream);
			sqlConnection.Close();
		}
	}

	private void AddSelectedEntry(string StudentNumber)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "SELECT StudentNumber FROM tbl_MealCards WHERE StudentNumber=@StudentNumber",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
		sqlParameter.Value = StudentNumber;
		sqlParameter.Direction = ParameterDirection.Input;
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		if (!sqlDataReader.HasRows)
		{
			sqlDataReader.Close();
			SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_MealCards (StudentNumber) VALUES (@StudentNumber)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter2.Value = StudentNumber;
			sqlParameter2.Direction = ParameterDirection.Input;
			if (sqlCommand2.ExecuteNonQuery() > 0)
			{
				LoadMealCardArchive(__Class, __Stream);
				sqlConnection.Close();
			}
		}
		else
		{
			sqlDataReader.Close();
		}
	}

	private void gridView1_MouseDown(object sender, MouseEventArgs e)
	{
		GridView gridView = sender as GridView;
		downHitInfo = null;
		GridHitInfo gridHitInfo = gridView.CalcHitInfo(new Point(e.X, e.Y));
		if (Control.ModifierKeys == Keys.None && e.Button == MouseButtons.Left && gridHitInfo.RowHandle >= 0)
		{
			downHitInfo = gridHitInfo;
		}
	}

	private void gridView1_MouseMove(object sender, MouseEventArgs e)
	{
		GridView gridView = sender as GridView;
		if (e.Button == MouseButtons.Left && downHitInfo != null)
		{
			Size dragSize = SystemInformation.DragSize;
			Rectangle rectangle = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);
			if (!rectangle.Contains(new Point(e.X, e.Y)))
			{
				DataRow dataRow = gridView.GetDataRow(downHitInfo.RowHandle);
				gridView.GridControl.DoDragDrop(dataRow, DragDropEffects.Move);
				downHitInfo = null;
				DXMouseEventArgs.GetMouseArgs(e).Handled = true;
			}
		}
	}

	private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = dt.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			StudentNumber = dataRow["StudentNumber"].ToString();
		}
	}

	private void gridControl2_DragDrop(object sender, DragEventArgs e)
	{
		AddSelectedEntry(StudentNumber);
	}

	private void gridControl2_DragOver(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(typeof(DataRow)))
		{
			e.Effect = DragDropEffects.Move;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}

	private void gridView1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			AddSelectedEntry(StudentNumber);
		}
	}

	private void gridView2_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Delete)
		{
			DeleteSelectedEntry(_StudentNumber);
		}
	}

	private void gridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (gridView2.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = _dt.Rows[gridView2.GetFocusedDataSourceRowIndex()];
			_StudentNumber = dataRow["StudentNumber"].ToString();
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			AddSelectedEntry(StudentNumber);
		}
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (gridView2.GetFocusedDataSourceRowIndex() > -1)
		{
			DeleteSelectedEntry(_StudentNumber);
		}
	}

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
		IDSelectionParameters.SetIDParameters(__Stream, __Class);
		MealCard_FrontSide report = new MealCard_FrontSide();
		ReportPrintTool reportPrintTool = new ReportPrintTool(report);
		reportPrintTool.PreviewRibbonForm.Ribbon.RibbonStyle = RibbonControlStyle.OfficeUniversal;
		reportPrintTool.PreviewRibbonForm.Ribbon.ShowApplicationButton = DefaultBoolean.False;
		reportPrintTool.PreviewRibbonForm.Ribbon.ShowCategoryInCaption = false;
		reportPrintTool.PreviewRibbonForm.Ribbon.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
		reportPrintTool.PreviewRibbonForm.Ribbon.ShowToolbarCustomizeItem = false;
		reportPrintTool.PreviewRibbonForm.Text = $"School Management Dynamics - ({__Class} Meal Cards) ";
		reportPrintTool.ShowRibbonPreviewDialog();
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			DialogResult dialogResult = XtraMessageBox.Show("Do you really want to clear the current collection?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
			if (dialogResult != DialogResult.Yes)
			{
				return;
			}
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "DELETE FROM tbl_MealCards",
					CommandType = CommandType.Text
				};
				if (sqlCommand.ExecuteNonQuery() > 0)
				{
					sqlConnection.Close();
				}
			}
			LoadMealCardArchive(__Class, __Stream);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.Name == "colNo1" && e.ListSourceRowIndex > -1)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void gridView2_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.Name == "colNo2" && e.ListSourceRowIndex > -1)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
	{
		for (int i = 0; i < gridView1.RowCount; i++)
		{
			AddSelectedEntry(gridView1.GetRowCellValue(i, "StudentNumber").ToString());
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I_Xtreme.DialogForms.CustomMealCards));
		this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.colNo1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridControl2 = new DevExpress.XtraGrid.GridControl();
		this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.colNo2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).BeginInit();
		this.splitContainerControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).BeginInit();
		base.SuspendLayout();
		this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
		this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
		this.splitContainerControl1.Location = new System.Drawing.Point(0, 109);
		this.splitContainerControl1.Name = "splitContainerControl1";
		this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
		this.splitContainerControl1.Panel1.Text = "Panel1";
		this.splitContainerControl1.Panel2.Controls.Add(this.gridControl2);
		this.splitContainerControl1.Panel2.MinSize = 300;
		this.splitContainerControl1.Panel2.Text = "Panel2";
		this.splitContainerControl1.Size = new System.Drawing.Size(712, 394);
		this.splitContainerControl1.SplitterPosition = 300;
		this.splitContainerControl1.TabIndex = 1;
		this.splitContainerControl1.Text = "Customization Options";
		this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl1.Location = new System.Drawing.Point(0, 0);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(403, 390);
		this.gridControl1.TabIndex = 0;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.DetailTip.Options.UseFont = true;
		this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.Empty.Options.UseFont = true;
		this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.GhostWhite;
		this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
		this.gridView1.Appearance.EvenRow.Options.UseFont = true;
		this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.FixedLine.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.GroupButton.Options.UseFont = true;
		this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.HorzLine.Options.UseFont = true;
		this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.OddRow.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.VertLine.Options.UseFont = true;
		this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[8] { this.colNo1, this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6, this.gridColumn7 });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsCustomization.AllowColumnMoving = false;
		this.gridView1.OptionsCustomization.AllowGroup = false;
		this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
		this.gridView1.OptionsFind.AlwaysVisible = true;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
		this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
		this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(gridView1_KeyDown);
		this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(gridView1_MouseDown);
		this.gridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(gridView1_MouseMove);
		this.colNo1.Caption = "#";
		this.colNo1.Name = "colNo1";
		this.colNo1.Visible = true;
		this.colNo1.VisibleIndex = 0;
		this.colNo1.Width = 69;
		this.gridColumn1.Caption = "Name";
		this.gridColumn1.FieldName = "fullName";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 1;
		this.gridColumn1.Width = 305;
		this.gridColumn2.Caption = "Student#";
		this.gridColumn2.FieldName = "StudentNumber";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 2;
		this.gridColumn2.Width = 263;
		this.gridColumn3.Caption = "D/B";
		this.gridColumn3.FieldName = "StudyStatus";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 3;
		this.gridColumn3.Width = 44;
		this.gridColumn4.Caption = "Stream";
		this.gridColumn4.FieldName = "StreamId";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 4;
		this.gridColumn4.Width = 108;
		this.gridColumn5.Caption = "Sex";
		this.gridColumn5.FieldName = "Sex";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 5;
		this.gridColumn5.Width = 53;
		this.gridColumn6.Caption = "Is on Bursary";
		this.gridColumn6.FieldName = "Bursary";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 6;
		this.gridColumn6.Width = 134;
		this.gridColumn7.Caption = "Fees Balance";
		this.gridColumn7.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn7.FieldName = "cashOnAccount";
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.Visible = true;
		this.gridColumn7.VisibleIndex = 7;
		this.gridColumn7.Width = 158;
		this.gridControl2.AllowDrop = true;
		this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl2.Location = new System.Drawing.Point(0, 0);
		this.gridControl2.MainView = this.gridView2;
		this.gridControl2.Name = "gridControl2";
		this.gridControl2.Size = new System.Drawing.Size(300, 390);
		this.gridControl2.TabIndex = 0;
		this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridControl2.DragDrop += new System.Windows.Forms.DragEventHandler(gridControl2_DragDrop);
		this.gridControl2.DragOver += new System.Windows.Forms.DragEventHandler(gridControl2_DragOver);
		this.gridView2.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView2.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView2.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView2.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.DetailTip.Options.UseFont = true;
		this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.Empty.Options.UseFont = true;
		this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
		this.gridView2.Appearance.EvenRow.Options.UseFont = true;
		this.gridView2.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView2.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView2.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.FixedLine.Options.UseFont = true;
		this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView2.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.GroupButton.Options.UseFont = true;
		this.gridView2.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView2.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.GroupRow.Options.UseFont = true;
		this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView2.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.HorzLine.Options.UseFont = true;
		this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.OddRow.Options.UseFont = true;
		this.gridView2.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.Preview.Options.UseFont = true;
		this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.Row.Options.UseFont = true;
		this.gridView2.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView2.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView2.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.VertLine.Options.UseFont = true;
		this.gridView2.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 11f);
		this.gridView2.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.colNo2, this.gridColumn8, this.gridColumn9 });
		this.gridView2.GridControl = this.gridControl2;
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsBehavior.Editable = false;
		this.gridView2.OptionsCustomization.AllowColumnMoving = false;
		this.gridView2.OptionsCustomization.AllowFilter = false;
		this.gridView2.OptionsCustomization.AllowGroup = false;
		this.gridView2.OptionsCustomization.AllowQuickHideColumns = false;
		this.gridView2.OptionsFind.AlwaysVisible = true;
		this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.gridView2.OptionsView.ShowIndicator = false;
		this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView2_FocusedRowChanged);
		this.gridView2.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView2_CustomColumnDisplayText);
		this.gridView2.KeyDown += new System.Windows.Forms.KeyEventHandler(gridView2_KeyDown);
		this.colNo2.Caption = "#";
		this.colNo2.Name = "colNo2";
		this.colNo2.Visible = true;
		this.colNo2.VisibleIndex = 0;
		this.colNo2.Width = 95;
		this.gridColumn8.Caption = "Name";
		this.gridColumn8.FieldName = "fullName";
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 1;
		this.gridColumn8.Width = 519;
		this.gridColumn9.Caption = "Student#";
		this.gridColumn9.FieldName = "StudentNumber";
		this.gridColumn9.Name = "gridColumn9";
		this.gridColumn9.Visible = true;
		this.gridColumn9.VisibleIndex = 2;
		this.gridColumn9.Width = 520;
		this.ribbonControl1.AllowMinimizeRibbon = false;
		this.ribbonControl1.AllowTrimPageText = false;
		this.ribbonControl1.ExpandCollapseItem.Id = 0;
		this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[6]
		{
			this.ribbonControl1.ExpandCollapseItem,
			this.barButtonItem1,
			this.barButtonItem2,
			this.barButtonItem3,
			this.barButtonItem4,
			this.barButtonItem5
		});
		this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
		this.ribbonControl1.MaxItemId = 6;
		this.ribbonControl1.Name = "ribbonControl1";
		this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[1] { this.ribbonPage1 });
		this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice;
		this.ribbonControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowCategoryInCaption = false;
		this.ribbonControl1.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
		this.ribbonControl1.ShowQatLocationSelector = false;
		this.ribbonControl1.ShowToolbarCustomizeItem = false;
		this.ribbonControl1.Size = new System.Drawing.Size(712, 109);
		this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
		this.barButtonItem1.Caption = "Clear List";
		this.barButtonItem1.Id = 1;
		this.barButtonItem1.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem1.ImageOptions.Image");
		this.barButtonItem1.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem1.ImageOptions.LargeImage");
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem2.Caption = "Add to list";
		this.barButtonItem2.Id = 2;
		this.barButtonItem2.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem2.ImageOptions.Image");
		this.barButtonItem2.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem2.ImageOptions.LargeImage");
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem3.Caption = "Remove from list";
		this.barButtonItem3.Id = 3;
		this.barButtonItem3.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem3.ImageOptions.Image");
		this.barButtonItem3.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem3.ImageOptions.LargeImage");
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
		this.barButtonItem4.Caption = "Preview";
		this.barButtonItem4.Id = 4;
		this.barButtonItem4.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem4.ImageOptions.Image");
		this.barButtonItem4.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem4.ImageOptions.LargeImage");
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[1] { this.ribbonPageGroup1 });
		this.ribbonPage1.Name = "ribbonPage1";
		this.ribbonPage1.Text = "ribbonPage1";
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1, true);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem5);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem3);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem4);
		this.ribbonPageGroup1.Name = "ribbonPageGroup1";
		this.ribbonPageGroup1.ShowCaptionButton = false;
		this.ribbonPageGroup1.Text = "Customization Options";
		this.barButtonItem5.Caption = "Add All";
		this.barButtonItem5.Id = 5;
		this.barButtonItem5.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem5.ImageOptions.Image");
		this.barButtonItem5.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem5.ImageOptions.LargeImage");
		this.barButtonItem5.Name = "barButtonItem5";
		this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem5_ItemClick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(712, 503);
		base.Controls.Add(this.splitContainerControl1);
		base.Controls.Add(this.ribbonControl1);
		base.Name = "CustomMealCards";
		this.Ribbon = this.ribbonControl1;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Custom Meal Cards";
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).EndInit();
		this.splitContainerControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
