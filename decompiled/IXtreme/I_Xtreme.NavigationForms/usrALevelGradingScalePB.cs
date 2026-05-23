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

public class usrALevelGradingScalePB : XtraUserControl
{
	private DataTable dataTableALevelPaperBalancing;

	private int focusedRow = 0;

	private IContainer components = null;

	private PanelControl panelControl14;

	private LabelControl labelControl53;

	private LabelControl labelControl52;

	private TextEdit txtALevelComment5;

	private TextEdit txtALevelComment4;

	private SimpleButton btnUpdateALevelGradingScale;

	private LabelControl lblGradeIdAA;

	private LabelControl labelControl72;

	private TextEdit txtALevelComment;

	private TextEdit txtACategory;

	private LabelControl labelControl120;

	private TextEdit txtALevelComment2;

	private LabelControl labelControl80;

	private LabelControl labelControl119;

	private TextEdit txtALevelComment3;

	private MyGridControl dgALevelGrades;

	private MyGridView gridViewALGrades;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem3;

	public usrALevelGradingScalePB()
	{
		InitializeComponent();
	}

	private void gridViewALGrades_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		try
		{
			if (gridViewALGrades.FocusedRowHandle > -1)
			{
				int focusedDataSourceRowIndex = gridViewALGrades.GetFocusedDataSourceRowIndex();
				DataRow dataRow = dataTableALevelPaperBalancing.Rows[focusedDataSourceRowIndex];
				txtACategory.Text = dataRow["Category"].ToString();
				txtALevelComment.Text = dataRow["Comment"].ToString();
				txtALevelComment2.Text = dataRow["Comment2"].ToString();
				txtALevelComment3.Text = dataRow["Comment3"].ToString();
				txtALevelComment4.Text = dataRow["Comment4"].ToString();
				txtALevelComment5.Text = dataRow["Comment5"].ToString();
				lblGradeIdAA.Text = dataRow["GradeId"].ToString();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void LoadALevelGradingScale()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from ALevelGradingScale", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "myScale");
			dataTableALevelPaperBalancing = new DataTable();
			dataTableALevelPaperBalancing = dataSet.Tables[0];
			dgALevelGrades.DataSource = dataTableALevelPaperBalancing.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void btnUpdateALevelGradingScale_Click(object sender, EventArgs e)
	{
		if (lblGradeIdAA.Text != string.Empty)
		{
			if (txtALevelComment.Text != string.Empty && txtALevelComment2.Text != string.Empty && txtALevelComment3.Text != string.Empty)
			{
				WaitDialogForm waitDialogForm = new WaitDialogForm();
				waitDialogForm.Caption = "Updating...";
				try
				{
					waitDialogForm.Show();
					focusedRow = gridViewALGrades.FocusedRowHandle;
					using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
					{
						sqlConnection.Open();
						using (SqlCommand sqlCommand = new SqlCommand
						{
							Connection = sqlConnection,
							CommandText = $"UPDATE ALevelGradingScale SET Category=@Category,Comment=@Comment,Comment2=@Comment2,Comment3=@Comment3,Comment4=@Comment4,Comment5=@Comment5 WHERE GradeId='{lblGradeIdAA.Text}'",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar, 2);
							sqlParameter.Value = txtACategory.Text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Comment", SqlDbType.VarChar, 80);
							sqlParameter.Value = txtALevelComment.Text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Comment2", SqlDbType.VarChar, 80);
							sqlParameter.Value = txtALevelComment2.Text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Comment3", SqlDbType.VarChar, 80);
							sqlParameter.Value = txtALevelComment3.Text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Comment4", SqlDbType.VarChar, 80);
							sqlParameter.Value = txtALevelComment4.Text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Comment5", SqlDbType.VarChar, 80);
							sqlParameter.Value = txtALevelComment5.Text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlCommand.ExecuteNonQuery();
						}
						sqlConnection.Close();
					}
					LoadALevelGradingScale();
					gridViewALGrades.FocusedRowHandle = focusedRow;
					waitDialogForm.Close();
					return;
				}
				catch (Exception ex)
				{
					waitDialogForm.Close();
					XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

	private void usrALevelGradingScalePB_Load(object sender, EventArgs e)
	{
		LoadALevelGradingScale();
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
		this.panelControl14 = new DevExpress.XtraEditors.PanelControl();
		this.labelControl53 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl52 = new DevExpress.XtraEditors.LabelControl();
		this.txtALevelComment5 = new DevExpress.XtraEditors.TextEdit();
		this.txtALevelComment4 = new DevExpress.XtraEditors.TextEdit();
		this.btnUpdateALevelGradingScale = new DevExpress.XtraEditors.SimpleButton();
		this.lblGradeIdAA = new DevExpress.XtraEditors.LabelControl();
		this.labelControl72 = new DevExpress.XtraEditors.LabelControl();
		this.txtALevelComment = new DevExpress.XtraEditors.TextEdit();
		this.txtACategory = new DevExpress.XtraEditors.TextEdit();
		this.labelControl120 = new DevExpress.XtraEditors.LabelControl();
		this.txtALevelComment2 = new DevExpress.XtraEditors.TextEdit();
		this.labelControl80 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl119 = new DevExpress.XtraEditors.LabelControl();
		this.txtALevelComment3 = new DevExpress.XtraEditors.TextEdit();
		this.dgALevelGrades = new AlienAge.CustomGrid.MyGridControl();
		this.gridViewALGrades = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.panelControl14).BeginInit();
		this.panelControl14.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment5.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment4.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtACategory.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment3.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgALevelGrades).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewALGrades).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.panelControl14.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panelControl14.Controls.Add(this.labelControl53);
		this.panelControl14.Controls.Add(this.labelControl52);
		this.panelControl14.Controls.Add(this.txtALevelComment5);
		this.panelControl14.Controls.Add(this.txtALevelComment4);
		this.panelControl14.Controls.Add(this.btnUpdateALevelGradingScale);
		this.panelControl14.Controls.Add(this.lblGradeIdAA);
		this.panelControl14.Controls.Add(this.labelControl72);
		this.panelControl14.Controls.Add(this.txtALevelComment);
		this.panelControl14.Controls.Add(this.txtACategory);
		this.panelControl14.Controls.Add(this.labelControl120);
		this.panelControl14.Controls.Add(this.txtALevelComment2);
		this.panelControl14.Controls.Add(this.labelControl80);
		this.panelControl14.Controls.Add(this.labelControl119);
		this.panelControl14.Controls.Add(this.txtALevelComment3);
		this.panelControl14.Location = new System.Drawing.Point(4, 325);
		this.panelControl14.Name = "panelControl14";
		this.panelControl14.Size = new System.Drawing.Size(975, 219);
		this.panelControl14.TabIndex = 38;
		this.labelControl53.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.labelControl53.Location = new System.Drawing.Point(11, 165);
		this.labelControl53.Name = "labelControl53";
		this.labelControl53.Size = new System.Drawing.Size(71, 16);
		this.labelControl53.TabIndex = 39;
		this.labelControl53.Text = "5th Remark:";
		this.labelControl52.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.labelControl52.Location = new System.Drawing.Point(11, 136);
		this.labelControl52.Name = "labelControl52";
		this.labelControl52.Size = new System.Drawing.Size(71, 16);
		this.labelControl52.TabIndex = 38;
		this.labelControl52.Text = "4th Remark:";
		this.txtALevelComment5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtALevelComment5.Location = new System.Drawing.Point(99, 157);
		this.txtALevelComment5.Name = "txtALevelComment5";
		this.txtALevelComment5.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.txtALevelComment5.Properties.Appearance.Options.UseFont = true;
		this.txtALevelComment5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtALevelComment5.Properties.MaxLength = 45;
		this.txtALevelComment5.Size = new System.Drawing.Size(870, 24);
		this.txtALevelComment5.TabIndex = 7;
		this.txtALevelComment4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtALevelComment4.Location = new System.Drawing.Point(99, 128);
		this.txtALevelComment4.Name = "txtALevelComment4";
		this.txtALevelComment4.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.txtALevelComment4.Properties.Appearance.Options.UseFont = true;
		this.txtALevelComment4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtALevelComment4.Properties.MaxLength = 45;
		this.txtALevelComment4.Size = new System.Drawing.Size(870, 24);
		this.txtALevelComment4.TabIndex = 6;
		this.btnUpdateALevelGradingScale.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnUpdateALevelGradingScale.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.btnUpdateALevelGradingScale.Appearance.Options.UseFont = true;
		this.btnUpdateALevelGradingScale.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.btnUpdateALevelGradingScale.Location = new System.Drawing.Point(792, 186);
		this.btnUpdateALevelGradingScale.Name = "btnUpdateALevelGradingScale";
		this.btnUpdateALevelGradingScale.Size = new System.Drawing.Size(177, 28);
		this.btnUpdateALevelGradingScale.TabIndex = 8;
		this.btnUpdateALevelGradingScale.Text = "Update Grading Scale";
		this.btnUpdateALevelGradingScale.Click += new System.EventHandler(btnUpdateALevelGradingScale_Click);
		this.lblGradeIdAA.Location = new System.Drawing.Point(68, 109);
		this.lblGradeIdAA.Name = "lblGradeIdAA";
		this.lblGradeIdAA.Size = new System.Drawing.Size(0, 13);
		this.lblGradeIdAA.TabIndex = 35;
		this.lblGradeIdAA.Visible = false;
		this.labelControl72.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.labelControl72.Location = new System.Drawing.Point(11, 49);
		this.labelControl72.Name = "labelControl72";
		this.labelControl72.Size = new System.Drawing.Size(70, 16);
		this.labelControl72.TabIndex = 28;
		this.labelControl72.Text = "1st Remark:";
		this.txtALevelComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtALevelComment.Location = new System.Drawing.Point(99, 41);
		this.txtALevelComment.Name = "txtALevelComment";
		this.txtALevelComment.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtALevelComment.Properties.Appearance.Options.UseFont = true;
		this.txtALevelComment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtALevelComment.Properties.MaxLength = 45;
		this.txtALevelComment.Size = new System.Drawing.Size(871, 24);
		this.txtALevelComment.TabIndex = 3;
		this.txtACategory.Location = new System.Drawing.Point(99, 12);
		this.txtACategory.Name = "txtACategory";
		this.txtACategory.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtACategory.Properties.Appearance.Options.UseFont = true;
		this.txtACategory.Properties.Appearance.Options.UseTextOptions = true;
		this.txtACategory.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.txtACategory.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtACategory.Properties.ReadOnly = true;
		this.txtACategory.Size = new System.Drawing.Size(63, 24);
		this.txtACategory.TabIndex = 21;
		this.txtACategory.TabStop = false;
		this.labelControl120.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.labelControl120.Location = new System.Drawing.Point(11, 107);
		this.labelControl120.Name = "labelControl120";
		this.labelControl120.Size = new System.Drawing.Size(72, 16);
		this.labelControl120.TabIndex = 33;
		this.labelControl120.Text = "3rd Remark:";
		this.txtALevelComment2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtALevelComment2.Location = new System.Drawing.Point(99, 70);
		this.txtALevelComment2.Name = "txtALevelComment2";
		this.txtALevelComment2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.txtALevelComment2.Properties.Appearance.Options.UseFont = true;
		this.txtALevelComment2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtALevelComment2.Properties.MaxLength = 45;
		this.txtALevelComment2.Size = new System.Drawing.Size(871, 24);
		this.txtALevelComment2.TabIndex = 4;
		this.labelControl80.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.labelControl80.Location = new System.Drawing.Point(11, 20);
		this.labelControl80.Name = "labelControl80";
		this.labelControl80.Size = new System.Drawing.Size(39, 16);
		this.labelControl80.TabIndex = 24;
		this.labelControl80.Text = "Grade:";
		this.labelControl119.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.labelControl119.Location = new System.Drawing.Point(11, 78);
		this.labelControl119.Name = "labelControl119";
		this.labelControl119.Size = new System.Drawing.Size(74, 16);
		this.labelControl119.TabIndex = 32;
		this.labelControl119.Text = "2nd Remark:";
		this.txtALevelComment3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtALevelComment3.Location = new System.Drawing.Point(99, 99);
		this.txtALevelComment3.Name = "txtALevelComment3";
		this.txtALevelComment3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.txtALevelComment3.Properties.Appearance.Options.UseFont = true;
		this.txtALevelComment3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtALevelComment3.Properties.MaxLength = 45;
		this.txtALevelComment3.Size = new System.Drawing.Size(871, 24);
		this.txtALevelComment3.TabIndex = 5;
		this.dgALevelGrades.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.dgALevelGrades.Location = new System.Drawing.Point(4, 27);
		this.dgALevelGrades.MainView = this.gridViewALGrades;
		this.dgALevelGrades.Name = "dgALevelGrades";
		this.dgALevelGrades.Size = new System.Drawing.Size(975, 294);
		this.dgALevelGrades.TabIndex = 0;
		this.dgALevelGrades.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewALGrades });
		this.gridViewALGrades.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridViewALGrades.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades.Appearance.EvenRow.Options.UseFont = true;
		this.gridViewALGrades.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewALGrades.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewALGrades.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridViewALGrades.Appearance.FocusedCell.Options.UseFont = true;
		this.gridViewALGrades.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewALGrades.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewALGrades.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridViewALGrades.Appearance.FocusedRow.Options.UseFont = true;
		this.gridViewALGrades.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades.Appearance.GroupFooter.Options.UseFont = true;
		this.gridViewALGrades.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades.Appearance.GroupRow.Options.UseFont = true;
		this.gridViewALGrades.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridViewALGrades.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewALGrades.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewALGrades.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridViewALGrades.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridViewALGrades.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades.Appearance.Preview.Options.UseFont = true;
		this.gridViewALGrades.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewALGrades.Appearance.Row.Options.UseFont = true;
		this.gridViewALGrades.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewALGrades.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewALGrades.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridViewALGrades.Appearance.SelectedRow.Options.UseFont = true;
		this.gridViewALGrades.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewALGrades.Appearance.TopNewRow.Options.UseFont = true;
		this.gridViewALGrades.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[6] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6 });
		this.gridViewALGrades.GridControl = this.dgALevelGrades;
		this.gridViewALGrades.Name = "gridViewALGrades";
		this.gridViewALGrades.OptionsBehavior.Editable = false;
		this.gridViewALGrades.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridViewALGrades.OptionsCustomization.AllowGroup = false;
		this.gridViewALGrades.OptionsView.ShowGroupPanel = false;
		this.gridViewALGrades.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridViewALGrades.OptionsView.ShowIndicator = false;
		this.gridViewALGrades.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewALGrades_FocusedRowChanged);
		this.gridColumn1.Caption = "Grade";
		this.gridColumn1.FieldName = "Category";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 46;
		this.gridColumn2.Caption = "1st Remark";
		this.gridColumn2.FieldName = "Comment";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn2.Width = 184;
		this.gridColumn3.Caption = "2nd Remark";
		this.gridColumn3.FieldName = "Comment2";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 2;
		this.gridColumn3.Width = 184;
		this.gridColumn4.Caption = "3rd Remark";
		this.gridColumn4.FieldName = "Comment3";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 3;
		this.gridColumn4.Width = 184;
		this.gridColumn5.Caption = "4th Remark";
		this.gridColumn5.FieldName = "Comment4";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 4;
		this.gridColumn5.Width = 184;
		this.gridColumn6.Caption = "5th Remark";
		this.gridColumn6.FieldName = "Comment5";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 5;
		this.gridColumn6.Width = 191;
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.dgALevelGrades);
		this.layoutControl1.Controls.Add(this.panelControl14);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(571, 173, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(983, 548);
		this.layoutControl1.TabIndex = 39;
		this.layoutControl1.Text = "layoutControl1";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(983, 548);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.dgALevelGrades;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 23);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(979, 298);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.panelControl14;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 321);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(979, 223);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.labelControl1.Location = new System.Drawing.Point(4, 4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(312, 19);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 39;
		this.labelControl1.Text = "A Level Subject Performance Remarks";
		this.layoutControlItem3.Control = this.labelControl1;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(979, 23);
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrALevelGradingScalePB";
		base.Size = new System.Drawing.Size(983, 548);
		base.Load += new System.EventHandler(usrALevelGradingScalePB_Load);
		((System.ComponentModel.ISupportInitialize)this.panelControl14).EndInit();
		this.panelControl14.ResumeLayout(false);
		this.panelControl14.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment5.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment4.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtACategory.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment3.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgALevelGrades).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewALGrades).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
