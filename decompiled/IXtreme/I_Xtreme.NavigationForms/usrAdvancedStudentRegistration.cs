using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrAdvancedStudentRegistration : XtraUserControl
{
	private DataTable _dt;

	private string schoolType = SchoolSettings.SchoolGeneralCurriculum.ToString();

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private SimpleButton simpleButton19;

	private CheckedComboBoxEdit cboCheckedSubjects;

	private ComboBoxEdit cboStreamAdvanced;

	private ComboBoxEdit cboClassAdvanced;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlItem layoutControlItem8;

	private DXValidationProvider dxRegistration;

	private GridControl gridControl1;

	private GridView gridView1;

	private LayoutControlItem layoutControlItem9;

	private CheckedComboBoxEdit cboSubjectList;

	private LayoutControlItem layoutControlItem1;

	private TextEdit txtSemester;

	private LayoutControlItem layoutControlItem2;

	public usrAdvancedStudentRegistration()
	{
		InitializeComponent();
		txtSemester.Text = WorkingSemesters.GetWorkingSemester();
		PrintableControl.SavePrintableControl(gridControl1);
		ActiveFormSelected.SetActiveForm("-");
	}

	private void GetAllStudents(string classId, string streamId)
	{
		WaitDialogForm waitDialogForm = new WaitDialogForm();
		waitDialogForm.Caption = "Generating list. Please wait...";
		try
		{
			gridView1.Columns.Clear();
			string empty = string.Empty;
			empty = ((!(streamId == "-Select Stream-")) ? $"SELECT fullName AS Name,StudentNumber AS StudentNo FROM tbl_Stud WHERE ClassId='{classId}' AND StreamId='{streamId}'" : $"SELECT fullName AS Name,StudentNumber AS StudentNo FROM tbl_Stud WHERE ClassId='{classId}'");
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(empty, DataConnection.ConnectToDatabase()))
			{
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "StudentList");
				_dt = new DataTable();
				_dt = dataSet.Tables[0];
				_dt.Columns.Add(new DataColumn("No", typeof(string)));
				foreach (string checkedValue in cboCheckedSubjects.Properties.GetItems().GetCheckedValues())
				{
					_dt.Columns.Add(new DataColumn(checkedValue, typeof(bool)));
				}
				gridControl1.DataSource = _dt.DefaultView;
				gridView1.Columns["No"].VisibleIndex = 0;
				gridView1.Columns["Name"].VisibleIndex = 1;
				gridView1.Columns["StudentNo"].VisibleIndex = 2;
				gridView1.Columns["No"].BestFit();
				gridView1.Columns["StudentNo"].BestFit();
			}
			foreach (string checkedValue2 in cboCheckedSubjects.Properties.GetItems().GetCheckedValues())
			{
				for (int i = 0; i < gridView1.RowCount; i++)
				{
					for (int j = 3; j < gridView1.Columns.Count; j++)
					{
						gridView1.SetRowCellValue(i, gridView1.Columns[j].FieldName, 0);
					}
				}
			}
			gridView1.OptionsView.EnableAppearanceEvenRow = true;
			PrintableControl.SavePrintableControl(gridControl1);
			string empty2 = string.Empty;
			empty2 = ((cboStreamAdvanced.SelectedIndex != 0) ? $"Subject Options for : {cboClassAdvanced.SelectedItem.ToString()} {cboStreamAdvanced.SelectedItem.ToString()}" : $"Subject Options for : {cboClassAdvanced.SelectedItem.ToString()}");
			ActiveFormSelected.SetActiveForm(empty2);
			waitDialogForm.Close();
			StudentRegistrationAdvanced.SaveDataTable(_dt);
		}
		catch (Exception ex)
		{
			waitDialogForm.Close();
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadSubjectList()
	{
		foreach (string checkedValue in cboCheckedSubjects.Properties.GetItems().GetCheckedValues())
		{
			cboSubjectList.Properties.Items.Add(checkedValue);
		}
	}

	private void GetOLevelSubjects()
	{
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from OLevelSubjects", selectConnection);
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "OLevelSubjects");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		cboCheckedSubjects.Properties.Items.Clear();
		foreach (DataRow row in dataTable.Rows)
		{
			cboCheckedSubjects.Properties.Items.Add(row["SubjectName"]);
		}
	}

	private static void LoadClassStreams(ComboBoxEdit _cboClass, ComboBoxEdit _cboStream)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			string selectCommandText = $"SELECT * FROM Streams WHERE ClassId='{_cboClass.SelectedItem}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Streams");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count == 0)
			{
				_cboStream.Properties.Items.Clear();
				_cboStream.Properties.Items.Add("-");
				_cboStream.SelectedIndex = 0;
				return;
			}
			_cboStream.Properties.Items.Clear();
			foreach (DataRow row in dataTable.Rows)
			{
				_cboStream.Properties.Items.Add(row["StreamName"]);
			}
			_cboStream.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void GetALevelSubjects()
	{
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from ALevelSubjects_Categorised", selectConnection);
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "ALevelSubjects");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		cboCheckedSubjects.Properties.Items.Clear();
		foreach (DataRow row in dataTable.Rows)
		{
			cboCheckedSubjects.Properties.Items.Add(row["PaperId"]);
		}
	}

	private void cboCheckedSubjects_CloseUp(object sender, CloseUpEventArgs e)
	{
		if (cboCheckedSubjects.EditValue != null && cboClassAdvanced.SelectedIndex > 0)
		{
			LoadSubjectList();
			GetAllStudents(cboClassAdvanced.SelectedItem.ToString(), cboStreamAdvanced.SelectedItem.ToString());
		}
	}

	private void cboCheckedSubjects_EditValueChanged(object sender, EventArgs e)
	{
		dxRegistration.RemoveControlError(cboCheckedSubjects);
	}

	private void cboClassAdvanced_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (schoolType == SchoolSettings.SchoolType.Secondary.ToString())
		{
			if (cboClassAdvanced.SelectedItem.ToString() == "S.1" || cboClassAdvanced.SelectedItem.ToString() == "S.2" || cboClassAdvanced.SelectedItem.ToString() == "S.3" || cboClassAdvanced.SelectedItem.ToString() == "S.4")
			{
				GetOLevelSubjects();
				dxRegistration.RemoveControlError(cboClassAdvanced);
			}
			else if (cboClassAdvanced.SelectedItem.ToString() == "S.5" || cboClassAdvanced.SelectedItem.ToString() == "S.6")
			{
				GetALevelSubjects();
				dxRegistration.RemoveControlError(cboClassAdvanced);
			}
		}
		else if (schoolType == SchoolSettings.SchoolType.Primary.ToString())
		{
			GetOLevelSubjects();
			dxRegistration.RemoveControlError(cboClassAdvanced);
		}
		LoadClassStreams(cboClassAdvanced, cboStreamAdvanced);
		cboStreamAdvanced.Properties.Items.Add("-Select Stream-");
		cboStreamAdvanced.SelectedItem = "-Select Stream-";
	}

	private void simpleButton19_Click(object sender, EventArgs e)
	{
		if (cboClassAdvanced.SelectedIndex > 0)
		{
			if (cboCheckedSubjects.Properties.GetCheckedItems().ToString() != string.Empty)
			{
				if (txtSemester.Text.Contains("Term"))
				{
					using (RegisterAdvanced registerAdvanced = new RegisterAdvanced())
					{
						string text = txtSemester.Text.TrimStart().TrimEnd();
						StudentRegistrationAdvanced.SerializeDataGrid(gridView1);
						registerAdvanced.lblClass.Text = cboClassAdvanced.SelectedItem.ToString();
						registerAdvanced.lblAcademicYear.Text = txtSemester.Text.Substring(text.IndexOf('-') + 1, 4);
						registerAdvanced.ShowDialog();
						return;
					}
				}
				dxRegistration.Validate(txtSemester);
			}
			else
			{
				dxRegistration.Validate(cboCheckedSubjects);
			}
		}
		else
		{
			dxRegistration.Validate(cboClassAdvanced);
		}
	}

	private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == "No")
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void cboSubjectList_CloseUp(object sender, CloseUpEventArgs e)
	{
		for (int i = 3; i < gridView1.Columns.Count; i++)
		{
			for (int j = 0; j < gridView1.RowCount; j++)
			{
				gridView1.SetRowCellValue(j, gridView1.Columns[i].FieldName, 0);
			}
		}
		foreach (string checkedValue in cboSubjectList.Properties.GetItems().GetCheckedValues())
		{
			for (int k = 0; k < gridView1.RowCount; k++)
			{
				gridView1.SetRowCellValue(k, checkedValue, 1);
			}
		}
	}

	private void usrAdvancedStudentRegistration_Load(object sender, EventArgs e)
	{
		if (schoolType == SchoolSettings.SchoolType.Primary.ToString())
		{
			Classes.LoadComboWithClasses(cboClassAdvanced, "Primary");
		}
		else if (schoolType == SchoolSettings.SchoolType.Secondary.ToString())
		{
			Classes.LoadComboWithClasses(new ComboBoxEdit[1] { cboClassAdvanced });
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
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.txtSemester = new DevExpress.XtraEditors.TextEdit();
		this.cboSubjectList = new DevExpress.XtraEditors.CheckedComboBoxEdit();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.simpleButton19 = new DevExpress.XtraEditors.SimpleButton();
		this.cboCheckedSubjects = new DevExpress.XtraEditors.CheckedComboBoxEdit();
		this.cboStreamAdvanced = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboClassAdvanced = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.dxRegistration = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtSemester.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSubjectList.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboCheckedSubjects.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboStreamAdvanced.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClassAdvanced.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxRegistration).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.txtSemester);
		this.layoutControl1.Controls.Add(this.cboSubjectList);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Controls.Add(this.simpleButton19);
		this.layoutControl1.Controls.Add(this.cboCheckedSubjects);
		this.layoutControl1.Controls.Add(this.cboStreamAdvanced);
		this.layoutControl1.Controls.Add(this.cboClassAdvanced);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(340, 207, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(844, 543);
		this.layoutControl1.TabIndex = 40;
		this.layoutControl1.Text = "layoutControl1";
		this.txtSemester.Location = new System.Drawing.Point(766, 4);
		this.txtSemester.Name = "txtSemester";
		this.txtSemester.Properties.Appearance.Options.UseTextOptions = true;
		this.txtSemester.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.txtSemester.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtSemester.Properties.ReadOnly = true;
		this.txtSemester.Size = new System.Drawing.Size(74, 22);
		this.txtSemester.StyleController = this.layoutControl1;
		this.txtSemester.TabIndex = 50;
		conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
		conditionValidationRule.ErrorText = "No semester is set. Contact your system administrator";
		conditionValidationRule.Value1 = "Semester No Set!";
		this.dxRegistration.SetValidationRule(this.txtSemester, conditionValidationRule);
		this.cboSubjectList.EditValue = "Subjects Quick Selection";
		this.cboSubjectList.Location = new System.Drawing.Point(173, 30);
		this.cboSubjectList.Name = "cboSubjectList";
		this.cboSubjectList.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboSubjectList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSubjectList.Properties.NullText = "Subjects Quick Selection";
		this.cboSubjectList.Properties.NullValuePrompt = "Subjects Quick Selection";
		this.cboSubjectList.Size = new System.Drawing.Size(589, 22);
		this.cboSubjectList.StyleController = this.layoutControl1;
		this.cboSubjectList.TabIndex = 49;
		this.cboSubjectList.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(cboSubjectList_CloseUp);
		this.gridControl1.Location = new System.Drawing.Point(4, 56);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(836, 483);
		this.gridControl1.TabIndex = 48;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.DetailTip.Options.UseFont = true;
		this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.Empty.Options.UseFont = true;
		this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
		this.gridView1.Appearance.EvenRow.Options.UseFont = true;
		this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FixedLine.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupButton.Options.UseFont = true;
		this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.HorzLine.Options.UseFont = true;
		this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.OddRow.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.VertLine.Options.UseFont = true;
		this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView1.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView1.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsCustomization.AllowGroup = false;
		this.gridView1.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
		this.simpleButton19.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton19.Location = new System.Drawing.Point(766, 30);
		this.simpleButton19.Name = "simpleButton19";
		this.simpleButton19.Size = new System.Drawing.Size(74, 22);
		this.simpleButton19.StyleController = this.layoutControl1;
		this.simpleButton19.TabIndex = 47;
		this.simpleButton19.Text = "Register";
		this.simpleButton19.Click += new System.EventHandler(simpleButton19_Click);
		this.cboCheckedSubjects.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.cboCheckedSubjects.Location = new System.Drawing.Point(173, 4);
		this.cboCheckedSubjects.Name = "cboCheckedSubjects";
		this.cboCheckedSubjects.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboCheckedSubjects.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboCheckedSubjects.Properties.NullText = "Optional Subjects";
		this.cboCheckedSubjects.Properties.NullValuePrompt = "Optional Subjects";
		this.cboCheckedSubjects.Size = new System.Drawing.Size(589, 22);
		this.cboCheckedSubjects.StyleController = this.layoutControl1;
		this.cboCheckedSubjects.TabIndex = 43;
		conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
		conditionValidationRule2.ErrorText = "This value is not valid";
		conditionValidationRule2.Value1 = "<Null>";
		this.dxRegistration.SetValidationRule(this.cboCheckedSubjects, conditionValidationRule2);
		this.cboCheckedSubjects.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(cboCheckedSubjects_CloseUp);
		this.cboCheckedSubjects.EditValueChanged += new System.EventHandler(cboCheckedSubjects_EditValueChanged);
		this.cboStreamAdvanced.Location = new System.Drawing.Point(45, 30);
		this.cboStreamAdvanced.Name = "cboStreamAdvanced";
		this.cboStreamAdvanced.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboStreamAdvanced.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboStreamAdvanced.Properties.NullText = "Stream";
		this.cboStreamAdvanced.Properties.NullValuePrompt = "Stream";
		this.cboStreamAdvanced.Size = new System.Drawing.Size(124, 22);
		this.cboStreamAdvanced.StyleController = this.layoutControl1;
		this.cboStreamAdvanced.TabIndex = 46;
		this.cboClassAdvanced.Location = new System.Drawing.Point(45, 4);
		this.cboClassAdvanced.Name = "cboClassAdvanced";
		this.cboClassAdvanced.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboClassAdvanced.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClassAdvanced.Properties.NullText = "Class";
		this.cboClassAdvanced.Properties.NullValuePrompt = "Class";
		this.cboClassAdvanced.Size = new System.Drawing.Size(124, 22);
		this.cboClassAdvanced.StyleController = this.layoutControl1;
		this.cboClassAdvanced.TabIndex = 41;
		conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
		conditionValidationRule3.ErrorText = "This value is not valid";
		conditionValidationRule3.Value1 = "N/A";
		this.dxRegistration.SetValidationRule(this.cboClassAdvanced, conditionValidationRule3);
		this.cboClassAdvanced.SelectedIndexChanged += new System.EventHandler(cboClassAdvanced_SelectedIndexChanged);
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[7] { this.layoutControlItem3, this.layoutControlItem7, this.layoutControlItem9, this.layoutControlItem5, this.layoutControlItem1, this.layoutControlItem8, this.layoutControlItem2 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(844, 543);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem3.Control = this.cboClassAdvanced;
		this.layoutControlItem3.CustomizationFormText = "Class:";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(169, 26);
		this.layoutControlItem3.Text = "Class:";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(38, 13);
		this.layoutControlItem7.Control = this.cboCheckedSubjects;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(169, 0);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(593, 26);
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextVisible = false;
		this.layoutControlItem9.Control = this.gridControl1;
		this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 52);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(840, 487);
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextVisible = false;
		this.layoutControlItem5.Control = this.cboStreamAdvanced;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 26);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(169, 26);
		this.layoutControlItem5.Text = "Stream:";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(38, 13);
		this.layoutControlItem1.Control = this.cboSubjectList;
		this.layoutControlItem1.CustomizationFormText = "Select All";
		this.layoutControlItem1.Location = new System.Drawing.Point(169, 26);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(593, 26);
		this.layoutControlItem1.Text = "Select All";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem8.Control = this.simpleButton19;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(762, 26);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(78, 26);
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem2.Control = this.txtSemester;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(762, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(78, 26);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrAdvancedStudentRegistration";
		base.Size = new System.Drawing.Size(844, 543);
		base.Load += new System.EventHandler(usrAdvancedStudentRegistration_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtSemester.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSubjectList.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboCheckedSubjects.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboStreamAdvanced.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClassAdvanced.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxRegistration).EndInit();
		base.ResumeLayout(false);
	}
}
