using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.NavigationForms;

public class usrALevelGrading : XtraUserControl
{
	private DataTable dataTableALevelGrades;

	private int focusedRow = 0;

	private IContainer components = null;

	private MyGridControl dgALevelGrades2;

	private MyGridView gridViewALGrades2;

	private SimpleButton btnUpdateA;

	private TextEdit txtPointsAA;

	private TextEdit txtEndAA;

	private TextEdit txtCategoryAA;

	private TextEdit txtDebutAA;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem7;

	private LabelControl lblGradeIdAAA;

	private LayoutControlItem layoutControlItem1;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem8;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	public usrALevelGrading()
	{
		InitializeComponent();
	}

	private void gridViewALGrades2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		try
		{
			int focusedDataSourceRowIndex = gridViewALGrades2.GetFocusedDataSourceRowIndex();
			DataRow dataRow = dataTableALevelGrades.Rows[focusedDataSourceRowIndex];
			txtCategoryAA.Text = dataRow["Category"].ToString();
			txtDebutAA.Text = dataRow["Debut"].ToString();
			txtPointsAA.Text = dataRow["Points"].ToString();
			lblGradeIdAAA.Text = dataRow["ScaleId"].ToString();
			txtEndAA.Text = dataRow["End"].ToString();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void LoadALevelGradingScale_2()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from ALevelGradingScale_2", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "myScale");
			dataTableALevelGrades = new DataTable();
			dataTableALevelGrades = dataSet.Tables[0];
			dgALevelGrades2.DataSource = dataTableALevelGrades.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void btnUpdateA_Click(object sender, EventArgs e)
	{
		if (lblGradeIdAAA.Text != string.Empty)
		{
			WaitDialogForm waitDialogForm = new WaitDialogForm();
			waitDialogForm.Caption = "Updating...";
			try
			{
				waitDialogForm.Show();
				focusedRow = gridViewALGrades2.FocusedRowHandle;
				using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = $"UPDATE ALevelGradingScale_2 SET Category=@Category,Debut=@Debut,[End]=@End,points=@Points WHERE ScaleId='{lblGradeIdAAA.Text}'",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar, 2);
						sqlParameter.Value = txtCategoryAA.Text;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Debut", SqlDbType.Float);
						sqlParameter.Value = txtDebutAA.Text;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@End", SqlDbType.Float);
						sqlParameter.Value = txtEndAA.Text;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Points", SqlDbType.Int);
						sqlParameter.Value = txtPointsAA.Text;
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
						CommandText = "UPDATE gradingFooter_A SET D1=@D1,D2=@D2,C3=@C3,C4=@C4,C5=@C5,C6=@C6,P7=@P7,P8=@P8,F9=@F9",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@D1", SqlDbType.VarChar, 10);
						sqlParameter2.Value = string.Format("{0}-{1}", gridViewALGrades2.GetRowCellValue(0, "Debut"), gridViewALGrades2.GetRowCellValue(0, "End"));
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@D2", SqlDbType.VarChar, 10);
						sqlParameter2.Value = string.Format("{0}-{1}", gridViewALGrades2.GetRowCellValue(1, "Debut"), gridViewALGrades2.GetRowCellValue(1, "End"));
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@C3", SqlDbType.VarChar, 10);
						sqlParameter2.Value = string.Format("{0}-{1}", gridViewALGrades2.GetRowCellValue(2, "Debut"), gridViewALGrades2.GetRowCellValue(2, "End"));
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@C4", SqlDbType.VarChar, 10);
						sqlParameter2.Value = string.Format("{0}-{1}", gridViewALGrades2.GetRowCellValue(3, "Debut"), gridViewALGrades2.GetRowCellValue(3, "End"));
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@C5", SqlDbType.VarChar, 10);
						sqlParameter2.Value = string.Format("{0}-{1}", gridViewALGrades2.GetRowCellValue(4, "Debut"), gridViewALGrades2.GetRowCellValue(4, "End"));
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@C6", SqlDbType.VarChar, 10);
						sqlParameter2.Value = string.Format("{0}-{1}", gridViewALGrades2.GetRowCellValue(5, "Debut"), gridViewALGrades2.GetRowCellValue(5, "End"));
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@P7", SqlDbType.VarChar, 10);
						sqlParameter2.Value = string.Format("{0}-{1}", gridViewALGrades2.GetRowCellValue(6, "Debut"), gridViewALGrades2.GetRowCellValue(6, "End"));
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@P8", SqlDbType.VarChar, 10);
						sqlParameter2.Value = string.Format("{0}-{1}", gridViewALGrades2.GetRowCellValue(7, "Debut"), gridViewALGrades2.GetRowCellValue(7, "End"));
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@F9", SqlDbType.VarChar, 10);
						sqlParameter2.Value = string.Format("{0}-{1}", gridViewALGrades2.GetRowCellValue(8, "Debut"), gridViewALGrades2.GetRowCellValue(8, "End"));
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
					}
					sqlConnection2.Close();
				}
				LoadALevelGradingScale_2();
				gridViewALGrades2.FocusedRowHandle = focusedRow;
				waitDialogForm.Close();
				return;
			}
			catch (Exception ex)
			{
				waitDialogForm.Close();
				XtraMessageBox.Show(ex.Message, "School Management Dynamics");
				return;
			}
		}
		XtraMessageBox.Show("Please select a grade you want to update from the list", "School Management Dynamics");
	}

	private void usrALevelGrading_Load(object sender, EventArgs e)
	{
		LoadALevelGradingScale_2();
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
		this.dgALevelGrades2 = new AlienAge.CustomGrid.MyGridControl();
		this.gridViewALGrades2 = new AlienAge.CustomGrid.MyGridView();
		this.btnUpdateA = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.lblGradeIdAAA = new DevExpress.XtraEditors.LabelControl();
		this.txtEndAA = new DevExpress.XtraEditors.TextEdit();
		this.txtPointsAA = new DevExpress.XtraEditors.TextEdit();
		this.txtDebutAA = new DevExpress.XtraEditors.TextEdit();
		this.txtCategoryAA = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		((System.ComponentModel.ISupportInitialize)this.dgALevelGrades2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewALGrades2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtEndAA.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPointsAA.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDebutAA.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtCategoryAA.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		base.SuspendLayout();
		this.dgALevelGrades2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.dgALevelGrades2.Location = new System.Drawing.Point(4, 27);
		this.dgALevelGrades2.MainView = this.gridViewALGrades2;
		this.dgALevelGrades2.Name = "dgALevelGrades2";
		this.dgALevelGrades2.Size = new System.Drawing.Size(780, 507);
		this.dgALevelGrades2.TabIndex = 0;
		this.dgALevelGrades2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewALGrades2 });
		this.gridViewALGrades2.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades2.Appearance.Empty.Options.UseFont = true;
		this.gridViewALGrades2.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades2.Appearance.FilterPanel.Options.UseFont = true;
		this.gridViewALGrades2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewALGrades2.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridViewALGrades2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewALGrades2.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades2.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridViewALGrades2.Appearance.FocusedRow.Options.UseFont = true;
		this.gridViewALGrades2.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades2.Appearance.FooterPanel.Options.UseFont = true;
		this.gridViewALGrades2.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades2.Appearance.GroupFooter.Options.UseFont = true;
		this.gridViewALGrades2.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades2.Appearance.GroupRow.Options.UseFont = true;
		this.gridViewALGrades2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewALGrades2.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridViewALGrades2.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewALGrades2.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridViewALGrades2.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades2.Appearance.Preview.Options.UseFont = true;
		this.gridViewALGrades2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades2.Appearance.Row.Options.UseFont = true;
		this.gridViewALGrades2.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewALGrades2.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridViewALGrades2.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades2.Appearance.TopNewRow.Options.UseFont = true;
		this.gridViewALGrades2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridColumn1, this.gridColumn2, this.gridColumn3 });
		this.gridViewALGrades2.GridControl = this.dgALevelGrades2;
		this.gridViewALGrades2.Name = "gridViewALGrades2";
		this.gridViewALGrades2.OptionsBehavior.Editable = false;
		this.gridViewALGrades2.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridViewALGrades2.OptionsCustomization.AllowGroup = false;
		this.gridViewALGrades2.OptionsView.ShowGroupPanel = false;
		this.gridViewALGrades2.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridViewALGrades2.OptionsView.ShowIndicator = false;
		this.gridViewALGrades2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewALGrades2_FocusedRowChanged);
		this.btnUpdateA.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnUpdateA.Appearance.Options.UseFont = true;
		this.btnUpdateA.Location = new System.Drawing.Point(788, 83);
		this.btnUpdateA.Name = "btnUpdateA";
		this.btnUpdateA.Size = new System.Drawing.Size(212, 23);
		this.btnUpdateA.StyleController = this.layoutControl1;
		this.btnUpdateA.TabIndex = 3;
		this.btnUpdateA.Text = "Set Grade";
		this.btnUpdateA.Click += new System.EventHandler(btnUpdateA_Click);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.lblGradeIdAAA);
		this.layoutControl1.Controls.Add(this.btnUpdateA);
		this.layoutControl1.Controls.Add(this.txtEndAA);
		this.layoutControl1.Controls.Add(this.txtPointsAA);
		this.layoutControl1.Controls.Add(this.dgALevelGrades2);
		this.layoutControl1.Controls.Add(this.txtDebutAA);
		this.layoutControl1.Controls.Add(this.txtCategoryAA);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(776, 9, 553, 562);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(1004, 538);
		this.layoutControl1.TabIndex = 21;
		this.layoutControl1.Text = "layoutControl1";
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.labelControl1.Location = new System.Drawing.Point(4, 4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(177, 19);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 20;
		this.labelControl1.Text = "A Level Grading Scale";
		this.lblGradeIdAAA.Location = new System.Drawing.Point(788, 110);
		this.lblGradeIdAAA.Name = "lblGradeIdAAA";
		this.lblGradeIdAAA.Size = new System.Drawing.Size(63, 13);
		this.lblGradeIdAAA.StyleController = this.layoutControl1;
		this.lblGradeIdAAA.TabIndex = 19;
		this.lblGradeIdAAA.Text = "labelControl1";
		this.lblGradeIdAAA.Visible = false;
		this.txtEndAA.Location = new System.Drawing.Point(950, 55);
		this.txtEndAA.Name = "txtEndAA";
		this.txtEndAA.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtEndAA.Properties.Appearance.Options.UseFont = true;
		this.txtEndAA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtEndAA.Size = new System.Drawing.Size(50, 24);
		this.txtEndAA.StyleController = this.layoutControl1;
		this.txtEndAA.TabIndex = 2;
		this.txtEndAA.TabStop = false;
		this.txtPointsAA.Location = new System.Drawing.Point(950, 27);
		this.txtPointsAA.Name = "txtPointsAA";
		this.txtPointsAA.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtPointsAA.Properties.Appearance.Options.UseFont = true;
		this.txtPointsAA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtPointsAA.Properties.ReadOnly = true;
		this.txtPointsAA.Size = new System.Drawing.Size(50, 24);
		this.txtPointsAA.StyleController = this.layoutControl1;
		this.txtPointsAA.TabIndex = 18;
		this.txtDebutAA.Location = new System.Drawing.Point(842, 55);
		this.txtDebutAA.Name = "txtDebutAA";
		this.txtDebutAA.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtDebutAA.Properties.Appearance.Options.UseFont = true;
		this.txtDebutAA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtDebutAA.Size = new System.Drawing.Size(50, 24);
		this.txtDebutAA.StyleController = this.layoutControl1;
		this.txtDebutAA.TabIndex = 1;
		this.txtCategoryAA.Location = new System.Drawing.Point(842, 27);
		this.txtCategoryAA.Name = "txtCategoryAA";
		this.txtCategoryAA.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtCategoryAA.Properties.Appearance.Options.UseFont = true;
		this.txtCategoryAA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtCategoryAA.Properties.ReadOnly = true;
		this.txtCategoryAA.Size = new System.Drawing.Size(50, 24);
		this.txtCategoryAA.StyleController = this.layoutControl1;
		this.txtCategoryAA.TabIndex = 9;
		this.txtCategoryAA.TabStop = false;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[8] { this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7, this.layoutControlItem2, this.layoutControlItem1, this.layoutControlItem8 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(1004, 538);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem3.Control = this.txtCategoryAA;
		this.layoutControlItem3.CustomizationFormText = "Category";
		this.layoutControlItem3.Location = new System.Drawing.Point(784, 23);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(108, 28);
		this.layoutControlItem3.Text = "Category";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(51, 16);
		this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem4.Control = this.txtPointsAA;
		this.layoutControlItem4.CustomizationFormText = "Points";
		this.layoutControlItem4.Location = new System.Drawing.Point(892, 23);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(108, 28);
		this.layoutControlItem4.Text = "Points";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(51, 16);
		this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem5.Control = this.txtDebutAA;
		this.layoutControlItem5.CustomizationFormText = "Debut";
		this.layoutControlItem5.Location = new System.Drawing.Point(784, 51);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(108, 28);
		this.layoutControlItem5.Text = "Debut";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(51, 16);
		this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem6.Control = this.txtEndAA;
		this.layoutControlItem6.CustomizationFormText = "End";
		this.layoutControlItem6.Location = new System.Drawing.Point(892, 51);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(108, 28);
		this.layoutControlItem6.Text = "End";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(51, 16);
		this.layoutControlItem7.Control = this.btnUpdateA;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(784, 79);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(216, 27);
		this.layoutControlItem7.Text = "layoutControlItem7";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextToControlDistance = 0;
		this.layoutControlItem7.TextVisible = false;
		this.layoutControlItem2.Control = this.dgALevelGrades2;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 23);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(784, 511);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem1.Control = this.lblGradeIdAAA;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(784, 106);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(216, 428);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutControlItem8.Control = this.labelControl1;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(1000, 23);
		this.layoutControlItem8.Text = "layoutControlItem8";
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextToControlDistance = 0;
		this.layoutControlItem8.TextVisible = false;
		this.gridColumn1.Caption = "Grade";
		this.gridColumn1.FieldName = "Category";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn2.Caption = "Start";
		this.gridColumn2.FieldName = "Debut";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn3.Caption = "End";
		this.gridColumn3.FieldName = "End";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 2;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrALevelGrading";
		base.Size = new System.Drawing.Size(1004, 538);
		base.Load += new System.EventHandler(usrALevelGrading_Load);
		((System.ComponentModel.ISupportInitialize)this.dgALevelGrades2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewALGrades2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtEndAA.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPointsAA.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDebutAA.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtCategoryAA.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		base.ResumeLayout(false);
	}
}
