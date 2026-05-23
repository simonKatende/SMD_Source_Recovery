using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using AlienAge.Semesters;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class StudentsResgistration : XtraForm
{
	private IContainer components = null;

	private LayoutControl layoutControl1;

	private ComboBoxEdit cboClass;

	private ComboBoxEdit cboTerm;

	private MyGridControl gridControl1;

	private MyGridView gridView1;

	private LayoutControlGroup Root;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem4;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private SplitContainerControl splitContainerControl1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private MyGridControl gridControl2;

	private MyGridView gridView2;

	private LayoutControlGroup layoutControlGroup2;

	private LayoutControlItem layoutControlItem2;

	private GridColumn gridColumn6;

	private DXValidationProvider dxValidationProvider1;

	private ComboBoxEdit cboStream;

	private LayoutControlItem layoutControlItem3;

	public StudentsResgistration()
	{
		InitializeComponent();
		LoadSubjects();
	}

	private void LoadSubjects()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelSubjects", DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			gridControl2.DataSource = dataTable.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void cboClass_EditValueChanged(object sender, EventArgs e)
	{
		try
		{
			if (cboClass.EditValue != null)
			{
				Stream.LoadStreams(cboClass.Text, cboStream);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		while (dxValidationProvider1.Validate())
		{
			if (dxValidationProvider1.GetInvalidControls().Count != 0)
			{
				continue;
			}
			if (gridView1.SelectedRowsCount > 0)
			{
				if (gridView2.SelectedRowsCount > 0)
				{
					RegisterStudentsNewCur registerStudentsNewCur = new RegisterStudentsNewCur(cboClass.EditValue.ToString(), cboTerm.EditValue.ToString(), gridView2, gridView1);
					if (registerStudentsNewCur.ShowDialog() != DialogResult.OK)
					{
					}
				}
				else
				{
					XtraMessageBox.Show("Please select the subjects you wish to register.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				XtraMessageBox.Show("Please select the students you wish to register.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			break;
		}
	}

	private void StudentsResgistration_Load(object sender, EventArgs e)
	{
		WorkingSemesters.GetSemesters(new ComboBoxEdit[1] { cboTerm });
	}

	private void cboStream_EditValueChanged(object sender, EventArgs e)
	{
		try
		{
			if (cboStream.EditValue != null)
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Stud WHERE ClassId='{cboClass.Text}' AND StreamId='{cboStream.Text}' AND Status='Active'", DataConnection.ConnectToDatabase());
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				gridControl1.DataSource = dataTable.DefaultView;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
		this.cboStream = new DevExpress.XtraEditors.ComboBoxEdit();
		this.gridControl2 = new AlienAge.CustomGrid.MyGridControl();
		this.gridView2 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.cboClass = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboTerm = new DevExpress.XtraEditors.ComboBoxEdit();
		this.gridControl1 = new AlienAge.CustomGrid.MyGridControl();
		this.gridView1 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboTerm.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1.Panel1).BeginInit();
		this.splitContainerControl1.Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1.Panel2).BeginInit();
		this.splitContainerControl1.Panel2.SuspendLayout();
		this.splitContainerControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.cboStream);
		this.layoutControl1.Controls.Add(this.gridControl2);
		this.layoutControl1.Controls.Add(this.cboClass);
		this.layoutControl1.Controls.Add(this.cboTerm);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Margin = new System.Windows.Forms.Padding(2);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(615, 180, 975, 600);
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(833, 361);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.dxValidationProvider1.SetIconAlignment(this.cboStream, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.cboStream.Location = new System.Drawing.Point(53, 52);
		this.cboStream.Margin = new System.Windows.Forms.Padding(2);
		this.cboStream.Name = "cboStream";
		this.cboStream.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboStream.Properties.Items.AddRange(new object[4] { "S.1", "S.2", "S.3", "S.4" });
		this.cboStream.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboStream.Size = new System.Drawing.Size(120, 20);
		this.cboStream.StyleController = this.layoutControl1;
		this.cboStream.TabIndex = 10;
		conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.cboStream, conditionValidationRule);
		this.cboStream.EditValueChanged += new System.EventHandler(cboStream_EditValueChanged);
		this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
		this.gridControl2.Location = new System.Drawing.Point(7, 129);
		this.gridControl2.MainView = this.gridView2;
		this.gridControl2.Margin = new System.Windows.Forms.Padding(2);
		this.gridControl2.Name = "gridControl2";
		this.gridControl2.Size = new System.Drawing.Size(166, 225);
		this.gridControl2.TabIndex = 9;
		this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[1] { this.gridColumn6 });
		this.gridView2.DetailHeight = 239;
		this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
		this.gridView2.GridControl = this.gridControl2;
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsBehavior.Editable = false;
		this.gridView2.OptionsSelection.CheckBoxSelectorColumnWidth = 33;
		this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView2.OptionsSelection.MultiSelect = true;
		this.gridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
		this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.gridView2.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView2.OptionsView.ShowIndicator = false;
		this.gridColumn6.Caption = "Subject";
		this.gridColumn6.FieldName = "SubjectId";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 1;
		this.dxValidationProvider1.SetIconAlignment(this.cboClass, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.cboClass.Location = new System.Drawing.Point(53, 28);
		this.cboClass.Margin = new System.Windows.Forms.Padding(2);
		this.cboClass.Name = "cboClass";
		this.cboClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClass.Properties.Items.AddRange(new object[4] { "S.1", "S.2", "S.3", "S.4" });
		this.cboClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboClass.Size = new System.Drawing.Size(120, 20);
		this.cboClass.StyleController = this.layoutControl1;
		this.cboClass.TabIndex = 8;
		conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule2.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.cboClass, conditionValidationRule2);
		this.cboClass.EditValueChanged += new System.EventHandler(cboClass_EditValueChanged);
		this.dxValidationProvider1.SetIconAlignment(this.cboTerm, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.cboTerm.Location = new System.Drawing.Point(53, 76);
		this.cboTerm.Margin = new System.Windows.Forms.Padding(2);
		this.cboTerm.Name = "cboTerm";
		this.cboTerm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboTerm.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboTerm.Size = new System.Drawing.Size(120, 20);
		this.cboTerm.StyleController = this.layoutControl1;
		this.cboTerm.TabIndex = 7;
		conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule3.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.cboTerm, conditionValidationRule3);
		this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
		this.gridControl1.Location = new System.Drawing.Point(181, 3);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(649, 355);
		this.gridControl1.TabIndex = 4;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[5] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5 });
		this.gridView1.DetailHeight = 239;
		this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsFind.AlwaysVisible = true;
		this.gridView1.OptionsFind.ShowFindButton = false;
		this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 33;
		this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView1.OptionsSelection.MultiSelect = true;
		this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
		this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridColumn1.Caption = "Student No.";
		this.gridColumn1.FieldName = "StudentNumber";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 1;
		this.gridColumn1.Width = 126;
		this.gridColumn2.Caption = "Name";
		this.gridColumn2.FieldName = "fullName";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 2;
		this.gridColumn2.Width = 452;
		this.gridColumn3.Caption = "Stream";
		this.gridColumn3.FieldName = "StreamId";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 3;
		this.gridColumn3.Width = 93;
		this.gridColumn4.Caption = "DB";
		this.gridColumn4.FieldName = "StudyStatus";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 4;
		this.gridColumn4.Width = 169;
		this.gridColumn5.Caption = "Sex";
		this.gridColumn5.FieldName = "Sex";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 5;
		this.gridColumn5.Width = 169;
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlGroup1, this.layoutControlGroup2 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.Root.Size = new System.Drawing.Size(833, 361);
		this.Root.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.Location = new System.Drawing.Point(178, 0);
		this.layoutControlItem1.MinSize = new System.Drawing.Size(69, 16);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(653, 359);
		this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlGroup1.GroupStyle = DevExpress.Utils.GroupStyle.Card;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem5, this.layoutControlItem4, this.layoutControlItem3 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.layoutControlGroup1.Size = new System.Drawing.Size(178, 101);
		this.layoutControlGroup1.Text = "REGISTRATION DETAILS";
		this.layoutControlItem5.Control = this.cboClass;
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(170, 24);
		this.layoutControlItem5.Text = "Class";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(34, 13);
		this.layoutControlItem4.Control = this.cboTerm;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(170, 24);
		this.layoutControlItem4.Text = "Term";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(34, 13);
		this.layoutControlItem3.Control = this.cboStream;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(170, 24);
		this.layoutControlItem3.Text = "Stream";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(34, 13);
		this.layoutControlGroup2.GroupStyle = DevExpress.Utils.GroupStyle.Card;
		this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem2 });
		this.layoutControlGroup2.Location = new System.Drawing.Point(0, 101);
		this.layoutControlGroup2.Name = "layoutControlGroup2";
		this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.layoutControlGroup2.Size = new System.Drawing.Size(178, 258);
		this.layoutControlGroup2.Text = "SUBJECTS";
		this.layoutControlItem2.Control = this.gridControl2;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(170, 229);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
		this.splitContainerControl1.Horizontal = false;
		this.splitContainerControl1.IsSplitterFixed = true;
		this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
		this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(2);
		this.splitContainerControl1.Name = "splitContainerControl1";
		this.splitContainerControl1.Panel1.Controls.Add(this.layoutControl1);
		this.splitContainerControl1.Panel1.Text = "Panel1";
		this.splitContainerControl1.Panel2.Controls.Add(this.simpleButton2);
		this.splitContainerControl1.Panel2.Controls.Add(this.simpleButton1);
		this.splitContainerControl1.Panel2.Text = "Panel2";
		this.splitContainerControl1.Size = new System.Drawing.Size(833, 414);
		this.splitContainerControl1.SplitterPosition = 43;
		this.splitContainerControl1.TabIndex = 1;
		this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton2.Location = new System.Drawing.Point(673, 7);
		this.simpleButton2.Margin = new System.Windows.Forms.Padding(2);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(75, 23);
		this.simpleButton2.TabIndex = 1;
		this.simpleButton2.Text = "Register";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton1.Location = new System.Drawing.Point(752, 7);
		this.simpleButton1.Margin = new System.Windows.Forms.Padding(2);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(75, 23);
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "Close";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(833, 414);
		base.Controls.Add(this.splitContainerControl1);
		base.IconOptions.ShowIcon = false;
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "StudentsResgistration";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Register Students";
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		base.Load += new System.EventHandler(StudentsResgistration_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboTerm.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1.Panel1).EndInit();
		this.splitContainerControl1.Panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1.Panel2).EndInit();
		this.splitContainerControl1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).EndInit();
		this.splitContainerControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).EndInit();
		base.ResumeLayout(false);
	}
}
