using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrOLevelGradingScale1 : XtraUserControl
{
	private string schoolType = SchoolSettings.SchoolGeneralCurriculum.ToString();

	private DataTable dataTableOLevelGrades;

	private int focusedRow = 0;

	private IContainer components = null;

	private MyGridControl gridOLevelGrading;

	private MyGridView gridViewOLevelGrading;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LabelControl labelControl51;

	private LabelControl labelControl50;

	private TextEdit txtOLevelComment5;

	private TextEdit txtOLevelComment4;

	private LabelControl lblOLevelGSId;

	private LabelControl labelControl123;

	private LabelControl labelControl122;

	private TextEdit txtOLevelComment3;

	private TextEdit txtOLevelComment2;

	private TextEdit txtOLevelComment;

	private LabelControl labelControl71;

	private LabelControl labelControl69;

	private TextEdit txtGradeCategory;

	private PanelControl panelControl1;

	private LayoutControlItem layoutControlItem2;

	private SimpleButton btnUpdateGradingScale;

	private TextEdit txtGradeEnd;

	private TextEdit txtGradeDebut;

	private LabelControl labelControl2;

	private LabelControl labelControl1;

	private GridColumn gridColumn8;

	private GridColumn gridColumn7;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private LabelControl labelControl3;

	private LayoutControlItem layoutControlItem3;

	public usrOLevelGradingScale1()
	{
		InitializeComponent();
	}

	private void LoadGradingScaleOL()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelGradingScale", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "myScales");
			dataTableOLevelGrades = new DataTable();
			dataTableOLevelGrades = dataSet.Tables[0];
			gridOLevelGrading.DataSource = dataTableOLevelGrades.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void btnUpdateGradingScale_Click(object sender, EventArgs e)
	{
		if (lblOLevelGSId.Text != string.Empty)
		{
			if (txtOLevelComment.Text != string.Empty && txtOLevelComment2.Text != string.Empty && txtOLevelComment3.Text != string.Empty)
			{
				WaitDialogForm waitDialogForm = new WaitDialogForm();
				waitDialogForm.Caption = "Updating...";
				try
				{
					waitDialogForm.Show();
					focusedRow = gridViewOLevelGrading.FocusedRowHandle;
					using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
					{
						sqlConnection.Open();
						using (SqlCommand sqlCommand = new SqlCommand
						{
							Connection = sqlConnection,
							CommandText = $"UPDATE OLevelGradingScale SET Category=@Category,Debut=@Debut,[End]=@End,Comment=@Comment,Comment2=@Comment2,Comment3=@Comment3,Comment4=@Comment4,Comment5=@Comment5 WHERE ScaleId='{lblOLevelGSId.Text}'",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar, 2);
							sqlParameter.Value = txtGradeCategory.Text.Trim();
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Debut", SqlDbType.Float);
							sqlParameter.Value = txtGradeDebut.Text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@End", SqlDbType.Float);
							sqlParameter.Value = txtGradeEnd.Text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Comment", SqlDbType.VarChar, 80);
							sqlParameter.Value = txtOLevelComment.Text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Comment2", SqlDbType.VarChar, 80);
							sqlParameter.Value = txtOLevelComment2.Text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Comment3", SqlDbType.VarChar, 80);
							sqlParameter.Value = txtOLevelComment3.Text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Comment4", SqlDbType.VarChar, 80);
							sqlParameter.Value = txtOLevelComment4.Text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Comment5", SqlDbType.VarChar, 80);
							sqlParameter.Value = txtOLevelComment5.Text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlCommand.ExecuteNonQuery();
						}
						sqlConnection.Close();
					}
					using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
					{
						sqlConnection2.Open();
						using (SqlCommand sqlCommand2 = new SqlCommand
						{
							Connection = sqlConnection2,
							CommandText = "UPDATE gradingFooter SET D1=@D1,D2=@D2,C3=@C3,C4=@C4,C5=@C5,C6=@C6,P7=@P7,P8=@P8,F9=@F9",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@D1", SqlDbType.VarChar, 6);
							sqlParameter2.Value = string.Format("{0}-{1}", gridViewOLevelGrading.GetRowCellValue(0, "Debut"), gridViewOLevelGrading.GetRowCellValue(0, "End"));
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand2.Parameters.Add("@D2", SqlDbType.VarChar, 6);
							sqlParameter2.Value = string.Format("{0}-{1}", gridViewOLevelGrading.GetRowCellValue(1, "Debut"), gridViewOLevelGrading.GetRowCellValue(1, "End"));
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand2.Parameters.Add("@C3", SqlDbType.VarChar, 6);
							sqlParameter2.Value = string.Format("{0}-{1}", gridViewOLevelGrading.GetRowCellValue(2, "Debut"), gridViewOLevelGrading.GetRowCellValue(2, "End"));
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand2.Parameters.Add("@C4", SqlDbType.VarChar, 6);
							sqlParameter2.Value = string.Format("{0}-{1}", gridViewOLevelGrading.GetRowCellValue(3, "Debut"), gridViewOLevelGrading.GetRowCellValue(3, "End"));
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand2.Parameters.Add("@C5", SqlDbType.VarChar, 6);
							sqlParameter2.Value = string.Format("{0}-{1}", gridViewOLevelGrading.GetRowCellValue(4, "Debut"), gridViewOLevelGrading.GetRowCellValue(4, "End"));
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand2.Parameters.Add("@C6", SqlDbType.VarChar, 6);
							sqlParameter2.Value = string.Format("{0}-{1}", gridViewOLevelGrading.GetRowCellValue(5, "Debut"), gridViewOLevelGrading.GetRowCellValue(5, "End"));
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand2.Parameters.Add("@P7", SqlDbType.VarChar, 6);
							sqlParameter2.Value = string.Format("{0}-{1}", gridViewOLevelGrading.GetRowCellValue(6, "Debut"), gridViewOLevelGrading.GetRowCellValue(6, "End"));
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand2.Parameters.Add("@P8", SqlDbType.VarChar, 6);
							sqlParameter2.Value = string.Format("{0}-{1}", gridViewOLevelGrading.GetRowCellValue(7, "Debut"), gridViewOLevelGrading.GetRowCellValue(7, "End"));
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand2.Parameters.Add("@F9", SqlDbType.VarChar, 6);
							sqlParameter2.Value = string.Format("{0}-{1}", gridViewOLevelGrading.GetRowCellValue(8, "Debut"), gridViewOLevelGrading.GetRowCellValue(8, "End"));
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlCommand2.ExecuteNonQuery();
						}
						sqlConnection2.Close();
					}
					LoadGradingScaleOL();
					waitDialogForm.Close();
					gridViewOLevelGrading.FocusedRowHandle = focusedRow;
					return;
				}
				catch (Exception ex)
				{
					waitDialogForm.Close();
					XtraMessageBox.Show(ex.Message, "School Management Dynamics");
					return;
				}
			}
			XtraMessageBox.Show("Please note that all the comments are required", "School Management Dynamics");
		}
		else
		{
			XtraMessageBox.Show("Please select a grade you want to update from the list", "School Management Dynamics");
		}
	}

	private void gridViewOLevelGrading_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		try
		{
			if (gridViewOLevelGrading.FocusedRowHandle > -1)
			{
				int focusedDataSourceRowIndex = gridViewOLevelGrading.GetFocusedDataSourceRowIndex();
				DataRow dataRow = dataTableOLevelGrades.Rows[focusedDataSourceRowIndex];
				txtGradeCategory.Text = dataRow["Category"].ToString();
				txtOLevelComment.Text = dataRow["Comment"].ToString();
				txtOLevelComment2.Text = dataRow["Comment2"].ToString();
				txtOLevelComment3.Text = dataRow["Comment3"].ToString();
				txtOLevelComment4.Text = dataRow["Comment4"].ToString();
				txtOLevelComment5.Text = dataRow["Comment5"].ToString();
				txtGradeDebut.Text = dataRow["Debut"].ToString();
				txtGradeEnd.Text = dataRow["End"].ToString();
				lblOLevelGSId.Text = dataRow["ScaleId"].ToString();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void usrOLevelGradingScale1_Load(object sender, EventArgs e)
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Initializing Grading Scale...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.InitializeOLevelGradingScale, 0);
		Thread.Sleep(25);
		if (schoolType == SchoolSettings.SchoolType.Primary.ToString())
		{
			labelControl3.Text = "Subjects Grading Scale";
		}
		LoadGradingScaleOL();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
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
		this.gridOLevelGrading = new AlienAge.CustomGrid.MyGridControl();
		this.gridViewOLevelGrading = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.txtGradeEnd = new DevExpress.XtraEditors.TextEdit();
		this.txtGradeDebut = new DevExpress.XtraEditors.TextEdit();
		this.btnUpdateGradingScale = new DevExpress.XtraEditors.SimpleButton();
		this.txtOLevelComment = new DevExpress.XtraEditors.TextEdit();
		this.labelControl51 = new DevExpress.XtraEditors.LabelControl();
		this.txtGradeCategory = new DevExpress.XtraEditors.TextEdit();
		this.labelControl50 = new DevExpress.XtraEditors.LabelControl();
		this.txtOLevelComment5 = new DevExpress.XtraEditors.TextEdit();
		this.txtOLevelComment4 = new DevExpress.XtraEditors.TextEdit();
		this.labelControl69 = new DevExpress.XtraEditors.LabelControl();
		this.lblOLevelGSId = new DevExpress.XtraEditors.LabelControl();
		this.labelControl123 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl122 = new DevExpress.XtraEditors.LabelControl();
		this.txtOLevelComment3 = new DevExpress.XtraEditors.TextEdit();
		this.txtOLevelComment2 = new DevExpress.XtraEditors.TextEdit();
		this.labelControl71 = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.gridOLevelGrading).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewOLevelGrading).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		this.panelControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtGradeEnd.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtGradeDebut.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtGradeCategory.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment5.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment4.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment3.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.gridOLevelGrading.Location = new System.Drawing.Point(4, 27);
		this.gridOLevelGrading.MainView = this.gridViewOLevelGrading;
		this.gridOLevelGrading.Name = "gridOLevelGrading";
		this.gridOLevelGrading.Size = new System.Drawing.Size(802, 271);
		this.gridOLevelGrading.TabIndex = 0;
		this.gridOLevelGrading.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewOLevelGrading });
		this.gridViewOLevelGrading.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrading.Appearance.FilterPanel.Options.UseFont = true;
		this.gridViewOLevelGrading.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewOLevelGrading.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrading.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridViewOLevelGrading.Appearance.FocusedCell.Options.UseFont = true;
		this.gridViewOLevelGrading.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewOLevelGrading.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrading.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridViewOLevelGrading.Appearance.FocusedRow.Options.UseFont = true;
		this.gridViewOLevelGrading.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrading.Appearance.FooterPanel.Options.UseFont = true;
		this.gridViewOLevelGrading.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrading.Appearance.GroupFooter.Options.UseFont = true;
		this.gridViewOLevelGrading.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrading.Appearance.GroupRow.Options.UseFont = true;
		this.gridViewOLevelGrading.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrading.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridViewOLevelGrading.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewOLevelGrading.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrading.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridViewOLevelGrading.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridViewOLevelGrading.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrading.Appearance.Preview.Options.UseFont = true;
		this.gridViewOLevelGrading.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrading.Appearance.Row.Options.UseFont = true;
		this.gridViewOLevelGrading.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewOLevelGrading.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrading.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridViewOLevelGrading.Appearance.SelectedRow.Options.UseFont = true;
		this.gridViewOLevelGrading.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrading.Appearance.TopNewRow.Options.UseFont = true;
		this.gridViewOLevelGrading.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[8] { this.gridColumn8, this.gridColumn7, this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6 });
		this.gridViewOLevelGrading.GridControl = this.gridOLevelGrading;
		this.gridViewOLevelGrading.Name = "gridViewOLevelGrading";
		this.gridViewOLevelGrading.OptionsBehavior.Editable = false;
		this.gridViewOLevelGrading.OptionsCustomization.AllowGroup = false;
		this.gridViewOLevelGrading.OptionsView.ShowGroupPanel = false;
		this.gridViewOLevelGrading.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridViewOLevelGrading.OptionsView.ShowIndicator = false;
		this.gridViewOLevelGrading.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewOLevelGrading_FocusedRowChanged);
		this.gridColumn8.Caption = "Grade";
		this.gridColumn8.FieldName = "Category";
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 0;
		this.gridColumn8.Width = 44;
		this.gridColumn7.Caption = "Start";
		this.gridColumn7.FieldName = "Debut";
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.Visible = true;
		this.gridColumn7.VisibleIndex = 1;
		this.gridColumn7.Width = 44;
		this.gridColumn1.Caption = "End";
		this.gridColumn1.FieldName = "End";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 2;
		this.gridColumn1.Width = 45;
		this.gridColumn2.Caption = "1st Remark";
		this.gridColumn2.FieldName = "Comment";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 3;
		this.gridColumn2.Width = 187;
		this.gridColumn3.Caption = "2nd Remark";
		this.gridColumn3.FieldName = "Comment2";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 4;
		this.gridColumn3.Width = 187;
		this.gridColumn4.Caption = "3rd Remark";
		this.gridColumn4.FieldName = "Comment3";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 5;
		this.gridColumn4.Width = 187;
		this.gridColumn5.Caption = "4th Remark";
		this.gridColumn5.FieldName = "Comment4";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 6;
		this.gridColumn5.Width = 187;
		this.gridColumn6.Caption = "5th Remark";
		this.gridColumn6.FieldName = "Comment5";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 7;
		this.gridColumn6.Width = 213;
		this.layoutControl1.Controls.Add(this.labelControl3);
		this.layoutControl1.Controls.Add(this.panelControl1);
		this.layoutControl1.Controls.Add(this.gridOLevelGrading);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(810, 525);
		this.layoutControl1.TabIndex = 2;
		this.layoutControl1.Text = "layoutControl1";
		this.panelControl1.Controls.Add(this.labelControl2);
		this.panelControl1.Controls.Add(this.labelControl1);
		this.panelControl1.Controls.Add(this.txtGradeEnd);
		this.panelControl1.Controls.Add(this.txtGradeDebut);
		this.panelControl1.Controls.Add(this.btnUpdateGradingScale);
		this.panelControl1.Controls.Add(this.txtOLevelComment);
		this.panelControl1.Controls.Add(this.labelControl51);
		this.panelControl1.Controls.Add(this.txtGradeCategory);
		this.panelControl1.Controls.Add(this.labelControl50);
		this.panelControl1.Controls.Add(this.txtOLevelComment5);
		this.panelControl1.Controls.Add(this.txtOLevelComment4);
		this.panelControl1.Controls.Add(this.labelControl69);
		this.panelControl1.Controls.Add(this.lblOLevelGSId);
		this.panelControl1.Controls.Add(this.labelControl123);
		this.panelControl1.Controls.Add(this.labelControl122);
		this.panelControl1.Controls.Add(this.txtOLevelComment3);
		this.panelControl1.Controls.Add(this.txtOLevelComment2);
		this.panelControl1.Controls.Add(this.labelControl71);
		this.panelControl1.Location = new System.Drawing.Point(4, 302);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(802, 219);
		this.panelControl1.TabIndex = 49;
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl2.Location = new System.Drawing.Point(277, 16);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(21, 16);
		this.labelControl2.TabIndex = 53;
		this.labelControl2.Text = "End";
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl1.Location = new System.Drawing.Point(169, 16);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(28, 16);
		this.labelControl1.TabIndex = 52;
		this.labelControl1.Text = "Start";
		this.txtGradeEnd.Location = new System.Drawing.Point(304, 8);
		this.txtGradeEnd.Name = "txtGradeEnd";
		this.txtGradeEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtGradeEnd.Properties.Appearance.Options.UseFont = true;
		this.txtGradeEnd.Properties.Appearance.Options.UseTextOptions = true;
		this.txtGradeEnd.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.txtGradeEnd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtGradeEnd.Properties.Mask.EditMask = "f0";
		this.txtGradeEnd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtGradeEnd.Size = new System.Drawing.Size(63, 24);
		this.txtGradeEnd.TabIndex = 50;
		this.txtGradeDebut.Location = new System.Drawing.Point(208, 8);
		this.txtGradeDebut.Name = "txtGradeDebut";
		this.txtGradeDebut.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtGradeDebut.Properties.Appearance.Options.UseFont = true;
		this.txtGradeDebut.Properties.Appearance.Options.UseTextOptions = true;
		this.txtGradeDebut.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.txtGradeDebut.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtGradeDebut.Properties.Mask.EditMask = "f0";
		this.txtGradeDebut.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtGradeDebut.Size = new System.Drawing.Size(63, 24);
		this.txtGradeDebut.TabIndex = 49;
		this.btnUpdateGradingScale.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnUpdateGradingScale.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnUpdateGradingScale.Appearance.Options.UseFont = true;
		this.btnUpdateGradingScale.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.btnUpdateGradingScale.Location = new System.Drawing.Point(619, 186);
		this.btnUpdateGradingScale.Name = "btnUpdateGradingScale";
		this.btnUpdateGradingScale.Size = new System.Drawing.Size(177, 28);
		this.btnUpdateGradingScale.TabIndex = 8;
		this.btnUpdateGradingScale.Text = "Update Grading Scale";
		this.btnUpdateGradingScale.Click += new System.EventHandler(btnUpdateGradingScale_Click);
		this.txtOLevelComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtOLevelComment.Location = new System.Drawing.Point(98, 38);
		this.txtOLevelComment.Name = "txtOLevelComment";
		this.txtOLevelComment.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtOLevelComment.Properties.Appearance.Options.UseFont = true;
		this.txtOLevelComment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtOLevelComment.Properties.MaxLength = 45;
		this.txtOLevelComment.Size = new System.Drawing.Size(698, 26);
		this.txtOLevelComment.TabIndex = 3;
		this.labelControl51.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl51.Location = new System.Drawing.Point(8, 164);
		this.labelControl51.Name = "labelControl51";
		this.labelControl51.Size = new System.Drawing.Size(71, 16);
		this.labelControl51.TabIndex = 48;
		this.labelControl51.Text = "5th Remark:";
		this.txtGradeCategory.Location = new System.Drawing.Point(98, 8);
		this.txtGradeCategory.Name = "txtGradeCategory";
		this.txtGradeCategory.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtGradeCategory.Properties.Appearance.Options.UseFont = true;
		this.txtGradeCategory.Properties.Appearance.Options.UseTextOptions = true;
		this.txtGradeCategory.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.txtGradeCategory.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtGradeCategory.Properties.ReadOnly = true;
		this.txtGradeCategory.Size = new System.Drawing.Size(63, 24);
		this.txtGradeCategory.TabIndex = 30;
		this.txtGradeCategory.TabStop = false;
		this.labelControl50.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl50.Location = new System.Drawing.Point(8, 135);
		this.labelControl50.Name = "labelControl50";
		this.labelControl50.Size = new System.Drawing.Size(71, 16);
		this.labelControl50.TabIndex = 47;
		this.labelControl50.Text = "4th Remark:";
		this.txtOLevelComment5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtOLevelComment5.Location = new System.Drawing.Point(98, 154);
		this.txtOLevelComment5.Name = "txtOLevelComment5";
		this.txtOLevelComment5.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtOLevelComment5.Properties.Appearance.Options.UseFont = true;
		this.txtOLevelComment5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtOLevelComment5.Properties.MaxLength = 45;
		this.txtOLevelComment5.Size = new System.Drawing.Size(698, 26);
		this.txtOLevelComment5.TabIndex = 7;
		this.txtOLevelComment4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtOLevelComment4.Location = new System.Drawing.Point(98, 125);
		this.txtOLevelComment4.Name = "txtOLevelComment4";
		this.txtOLevelComment4.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtOLevelComment4.Properties.Appearance.Options.UseFont = true;
		this.txtOLevelComment4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtOLevelComment4.Properties.MaxLength = 45;
		this.txtOLevelComment4.Size = new System.Drawing.Size(698, 26);
		this.txtOLevelComment4.TabIndex = 6;
		this.labelControl69.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl69.Location = new System.Drawing.Point(8, 16);
		this.labelControl69.Name = "labelControl69";
		this.labelControl69.Size = new System.Drawing.Size(39, 16);
		this.labelControl69.TabIndex = 33;
		this.labelControl69.Text = "Grade:";
		this.lblOLevelGSId.Location = new System.Drawing.Point(72, 151);
		this.lblOLevelGSId.Name = "lblOLevelGSId";
		this.lblOLevelGSId.Size = new System.Drawing.Size(0, 13);
		this.lblOLevelGSId.TabIndex = 44;
		this.lblOLevelGSId.Visible = false;
		this.labelControl123.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl123.Location = new System.Drawing.Point(8, 106);
		this.labelControl123.Name = "labelControl123";
		this.labelControl123.Size = new System.Drawing.Size(72, 16);
		this.labelControl123.TabIndex = 43;
		this.labelControl123.Text = "3rd Remark:";
		this.labelControl122.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl122.Location = new System.Drawing.Point(8, 77);
		this.labelControl122.Name = "labelControl122";
		this.labelControl122.Size = new System.Drawing.Size(74, 16);
		this.labelControl122.TabIndex = 42;
		this.labelControl122.Text = "2nd Remark:";
		this.txtOLevelComment3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtOLevelComment3.Location = new System.Drawing.Point(98, 96);
		this.txtOLevelComment3.Name = "txtOLevelComment3";
		this.txtOLevelComment3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtOLevelComment3.Properties.Appearance.Options.UseFont = true;
		this.txtOLevelComment3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtOLevelComment3.Properties.MaxLength = 45;
		this.txtOLevelComment3.Size = new System.Drawing.Size(698, 26);
		this.txtOLevelComment3.TabIndex = 5;
		this.txtOLevelComment2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtOLevelComment2.Location = new System.Drawing.Point(98, 67);
		this.txtOLevelComment2.Name = "txtOLevelComment2";
		this.txtOLevelComment2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtOLevelComment2.Properties.Appearance.Options.UseFont = true;
		this.txtOLevelComment2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtOLevelComment2.Properties.MaxLength = 45;
		this.txtOLevelComment2.Size = new System.Drawing.Size(698, 26);
		this.txtOLevelComment2.TabIndex = 4;
		this.labelControl71.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl71.Location = new System.Drawing.Point(8, 48);
		this.labelControl71.Name = "labelControl71";
		this.labelControl71.Size = new System.Drawing.Size(70, 16);
		this.labelControl71.TabIndex = 38;
		this.labelControl71.Text = "1st Remark:";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(810, 525);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridOLevelGrading;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 23);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(806, 275);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.panelControl1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 298);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(806, 223);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.labelControl3.Location = new System.Drawing.Point(4, 4);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(177, 19);
		this.labelControl3.StyleController = this.layoutControl1;
		this.labelControl3.TabIndex = 50;
		this.labelControl3.Text = "O Level Grading Scale";
		this.layoutControlItem3.Control = this.labelControl3;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(806, 23);
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrOLevelGradingScale1";
		base.Size = new System.Drawing.Size(810, 525);
		base.Load += new System.EventHandler(usrOLevelGradingScale1_Load);
		((System.ComponentModel.ISupportInitialize)this.gridOLevelGrading).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewOLevelGrading).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		this.panelControl1.ResumeLayout(false);
		this.panelControl1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtGradeEnd.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtGradeDebut.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtGradeCategory.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment5.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment4.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment3.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
