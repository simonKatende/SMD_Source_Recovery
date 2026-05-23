using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using AlienAge.Semesters;
using DevExpress.Data;
using DevExpress.Data.Mask;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class PersonalRequirements : XtraForm
{
	private DataTable f_dTable;

	private IContainer components = null;

	private DateEdit dtOfAppend;

	private SimpleButton simpleButton41;

	private TextEdit txtAN;

	private DXValidationProvider dxValidationProvider1;

	public ComboBoxEdit cboClassAppend;

	private SimpleButton simpleButton1;

	public TextEdit txtAppendAmount;

	public ComboBoxEdit cboAppItem;

	private LabelControl labelControl1;

	private LabelControl lblSemester;

	private MyGridControl gridControl1;

	private MyGridView gridView1;

	private GridColumn gridName;

	private GridColumn gridStudentNumber;

	private GridColumn gridDB;

	private GridColumn gridSex;

	private GridColumn gridBursary;

	private GridColumn gridColumn1;

	private GridColumn gridFeesBalance;

	private LabelControl labelControl6;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private Timer timer1;

	private CheckEdit checkEdit2;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private LayoutControlItem layoutControlItem1;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem7;

	private SeparatorControl separatorControl1;

	private LayoutControlItem layoutControlItem9;

	public PersonalRequirements()
	{
		InitializeComponent();
		Classes.LoadComboWithClasses(new ComboBoxEdit[1] { cboClassAppend });
		cboClassAppend.SelectedIndex = -1;
	}

	private void LoadPayableItems()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			string selectCommandText = "SELECT * FROM tbl_generalAccounts_Sub WHERE accNo=1001";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentRequirements");
			f_dTable = new DataTable();
			f_dTable = dataSet.Tables[0];
			cboAppItem.Properties.Items.Clear();
			foreach (DataRow row in f_dTable.Rows)
			{
				cboAppItem.Properties.Items.Add(row["SubAccoutName"].ToString());
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void cboAppItem_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			DataRow dataRow = f_dTable.Rows[cboAppItem.SelectedIndex];
			txtAN.Text = dataRow["subAccountNo"].ToString();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton41_Click(object sender, EventArgs e)
	{
		if (lblSemester.Text != "Semester No Set!")
		{
			if (cboAppItem.SelectedIndex != -1)
			{
				double result = (double.TryParse(txtAppendAmount.Text, out result) ? result : 0.0);
				int num = 0;
				StudentRequirements.AppendToCustomInit(appendingCategory: (!(cboAppItem.SelectedItem.ToString() == "Fees")) ? 1 : 0, View: gridView1, appedingTo: 2, feesAmount: result, itemRequired: cboAppItem.SelectedItem.ToString(), currentSemester: lblSemester.Text, currentClass: cboClassAppend.SelectedItem.ToString(), appendDate: dtOfAppend.DateTime, acc_No: txtAN.Text);
				bool isPIK = Convert.ToBoolean(checkEdit2.EditValue);
				using appendRequirements appendRequirements = new appendRequirements(isPIK, cboAppItem.SelectedItem.ToString());
				if (appendRequirements.ShowDialog() == DialogResult.OK)
				{
					LoadSelectedClass();
				}
				return;
			}
			XtraMessageBox.Show("Please select an Item", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		else
		{
			XtraMessageBox.Show("Sorry we cannot do that. You have to set an Active Semester First.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		Close();
	}

	public void StudentFeesCallBackFN(bool timerStatus)
	{
		timer1.Enabled = timerStatus;
	}

	private void gridView1_DoubleClick(object sender, EventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			StudentOptions.SetActiveStudent(gridView1.GetRowCellValue(gridView1.GetFocusedDataSourceRowIndex(), "StudentNumber").ToString());
			StudentOptions.SetPaymentMode("SingleStudent");
			StudentOptions.SetActiveClass(cboClassAppend.SelectedItem.ToString());
			using StudentFeesPayment studentFeesPayment = new StudentFeesPayment("AppendForm");
			studentFeesPayment.RefreshList = StudentFeesCallBackFN;
			studentFeesPayment.ShowDialog();
		}
	}

	private void LoadDefaultClass()
	{
		try
		{
			string[] array = Classes.ListOfClasses().Split();
			foreach (string text in array)
			{
				using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				string selectCommandText = $"SELECT StudentNumber,fullName AS Name, StudyStatus AS DB, StreamId,Sex, BursaryStatus AS Bursary,cashOnAccount,ClassId,RequiredFees,FeesDiscount FROM tbl_Stud WHERE ClassId='{text}'";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "Students");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					gridControl1.DataSource = dataTable.DefaultView;
					cboClassAppend.SelectedItem = text;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadSelectedClass()
	{
		try
		{
			if (cboClassAppend.SelectedIndex <= 0)
			{
				return;
			}
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			string selectCommandText = $"SELECT StudentNumber,fullName AS Name, StudyStatus AS DB, StreamId,Sex,Religion, BursaryStatus AS Bursary,cashOnAccount,RequiredFees,FeesDiscount FROM tbl_Stud WHERE ClassId='{cboClassAppend.SelectedItem.ToString()}' AND Status='Active'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Students");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			gridControl1.DataSource = dataTable.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void cboClassAppend_Closed(object sender, ClosedEventArgs e)
	{
		LoadSelectedClass();
	}

	private void PersonalRequirements_Load(object sender, EventArgs e)
	{
		LoadDefaultClass();
		lblSemester.Text = WorkingSemesters.GetWorkingSemester();
		LoadPayableItems();
		dtOfAppend.DateTime = DateTime.Now;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		timer1.Enabled = false;
	}

	private void checkEdit2_CheckedChanged(object sender, EventArgs e)
	{
		if (checkEdit2.Checked)
		{
			layoutControlItem4.Visibility = LayoutVisibility.Never;
			txtAppendAmount.Text = "0";
			txtAppendAmount.ReadOnly = true;
		}
		else
		{
			layoutControlItem4.Visibility = LayoutVisibility.Always;
			txtAppendAmount.Text = string.Empty;
			txtAppendAmount.ReadOnly = false;
		}
	}

	private void cboAppItem_EditValueChanged(object sender, EventArgs e)
	{
		if (cboAppItem.EditValue != null)
		{
			layoutControlItem3.Visibility = LayoutVisibility.Always;
			checkEdit2.Text = cboAppItem.EditValue.ToString() + "-Payable In Kind";
		}
		else
		{
			layoutControlItem3.Visibility = LayoutVisibility.Never;
			checkEdit2.Text = "Payable In Kind";
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
		DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
		DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
		this.txtAN = new DevExpress.XtraEditors.TextEdit();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.lblSemester = new DevExpress.XtraEditors.LabelControl();
		this.cboClassAppend = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboAppItem = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtAppendAmount = new DevExpress.XtraEditors.TextEdit();
		this.dtOfAppend = new DevExpress.XtraEditors.DateEdit();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.gridControl1 = new AlienAge.CustomGrid.MyGridControl();
		this.gridView1 = new AlienAge.CustomGrid.MyGridView();
		this.gridName = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridStudentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridDB = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridSex = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridBursary = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridFeesBalance = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton41 = new DevExpress.XtraEditors.SimpleButton();
		this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.txtAN.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.checkEdit2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClassAppend.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboAppItem.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAppendAmount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtOfAppend.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtOfAppend.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.separatorControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		base.SuspendLayout();
		this.txtAN.Location = new System.Drawing.Point(4, 279);
		this.txtAN.Name = "txtAN";
		this.txtAN.Size = new System.Drawing.Size(197, 20);
		this.txtAN.StyleController = this.layoutControl1;
		this.txtAN.TabIndex = 31;
		this.txtAN.Visible = false;
		this.layoutControl1.Controls.Add(this.separatorControl1);
		this.layoutControl1.Controls.Add(this.checkEdit2);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.lblSemester);
		this.layoutControl1.Controls.Add(this.cboClassAppend);
		this.layoutControl1.Controls.Add(this.cboAppItem);
		this.layoutControl1.Controls.Add(this.txtAppendAmount);
		this.layoutControl1.Controls.Add(this.dtOfAppend);
		this.layoutControl1.Controls.Add(this.txtAN);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Left;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(570, 168, 650, 400);
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(205, 517);
		this.layoutControl1.TabIndex = 45;
		this.layoutControl1.Text = "layoutControl1";
		this.checkEdit2.Location = new System.Drawing.Point(4, 161);
		this.checkEdit2.Name = "checkEdit2";
		this.checkEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.checkEdit2.Properties.Appearance.Options.UseFont = true;
		this.checkEdit2.Properties.Caption = "Item payable in kind";
		this.checkEdit2.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
		this.checkEdit2.Size = new System.Drawing.Size(197, 20);
		this.checkEdit2.StyleController = this.layoutControl1;
		this.checkEdit2.TabIndex = 44;
		this.checkEdit2.CheckedChanged += new System.EventHandler(checkEdit2_CheckedChanged);
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseForeColor = true;
		this.labelControl1.Appearance.Options.UseTextOptions = true;
		this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Location = new System.Drawing.Point(4, 4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(197, 16);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 34;
		this.labelControl1.Text = "Term";
		this.lblSemester.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblSemester.Appearance.ForeColor = System.Drawing.Color.Red;
		this.lblSemester.Appearance.Options.UseFont = true;
		this.lblSemester.Appearance.Options.UseForeColor = true;
		this.lblSemester.Appearance.Options.UseTextOptions = true;
		this.lblSemester.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblSemester.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblSemester.Location = new System.Drawing.Point(3, 23);
		this.lblSemester.Name = "lblSemester";
		this.lblSemester.Size = new System.Drawing.Size(199, 19);
		this.lblSemester.StyleController = this.layoutControl1;
		this.lblSemester.TabIndex = 35;
		this.cboClassAppend.Location = new System.Drawing.Point(4, 86);
		this.cboClassAppend.Name = "cboClassAppend";
		this.cboClassAppend.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboClassAppend.Properties.Appearance.Options.UseFont = true;
		this.cboClassAppend.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboClassAppend.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClassAppend.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboClassAppend.Size = new System.Drawing.Size(197, 24);
		this.cboClassAppend.StyleController = this.layoutControl1;
		this.cboClassAppend.TabIndex = 21;
		this.cboClassAppend.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboClassAppend_Closed);
		this.cboAppItem.Location = new System.Drawing.Point(4, 133);
		this.cboAppItem.Name = "cboAppItem";
		this.cboAppItem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboAppItem.Properties.Appearance.Options.UseFont = true;
		this.cboAppItem.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboAppItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboAppItem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboAppItem.Size = new System.Drawing.Size(197, 24);
		this.cboAppItem.StyleController = this.layoutControl1;
		this.cboAppItem.TabIndex = 22;
		this.cboAppItem.SelectedIndexChanged += new System.EventHandler(cboAppItem_SelectedIndexChanged);
		this.cboAppItem.EditValueChanged += new System.EventHandler(cboAppItem_EditValueChanged);
		this.txtAppendAmount.EditValue = "0";
		this.txtAppendAmount.Location = new System.Drawing.Point(4, 204);
		this.txtAppendAmount.Name = "txtAppendAmount";
		this.txtAppendAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtAppendAmount.Properties.Appearance.Options.UseFont = true;
		this.txtAppendAmount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtAppendAmount.Properties.DisplayFormat.FormatString = "{0:#,#.0}";
		this.txtAppendAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.txtAppendAmount.Properties.EditFormat.FormatString = "{0:#,#.0}";
		this.txtAppendAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.txtAppendAmount.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
		this.txtAppendAmount.Properties.MaskSettings.Set("mask", "n0");
		this.txtAppendAmount.Size = new System.Drawing.Size(197, 24);
		this.txtAppendAmount.StyleController = this.layoutControl1;
		this.txtAppendAmount.TabIndex = 25;
		this.dtOfAppend.EditValue = null;
		this.dtOfAppend.Location = new System.Drawing.Point(4, 251);
		this.dtOfAppend.Name = "dtOfAppend";
		this.dtOfAppend.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.dtOfAppend.Properties.Appearance.Options.UseFont = true;
		this.dtOfAppend.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.dtOfAppend.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtOfAppend.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtOfAppend.Properties.DisplayFormat.FormatString = "{0:dd-MMM-yy}";
		this.dtOfAppend.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtOfAppend.Properties.EditFormat.FormatString = "{0:dd-MMM-yy}";
		this.dtOfAppend.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtOfAppend.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.dtOfAppend.Size = new System.Drawing.Size(197, 24);
		this.dtOfAppend.StyleController = this.layoutControl1;
		this.dtOfAppend.TabIndex = 28;
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[10] { this.layoutControlItem1, this.emptySpaceItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem8, this.layoutControlItem7, this.layoutControlItem9 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.Root.Size = new System.Drawing.Size(205, 517);
		this.Root.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.cboClassAppend;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 63);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(201, 47);
		this.layoutControlItem1.Text = "Class";
		this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(68, 16);
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 303);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(201, 210);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.cboAppItem;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 110);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(201, 47);
		this.layoutControlItem2.Text = "Item";
		this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 16);
		this.layoutControlItem3.Control = this.checkEdit2;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 157);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(201, 24);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem4.Control = this.txtAppendAmount;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 181);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(201, 47);
		this.layoutControlItem4.Text = "Amount";
		this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 16);
		this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem5.Control = this.dtOfAppend;
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 228);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(201, 47);
		this.layoutControlItem5.Text = "Billing Date";
		this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem5.TextSize = new System.Drawing.Size(68, 16);
		this.layoutControlItem6.Control = this.txtAN;
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 275);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(201, 24);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutControlItem8.AppearanceItemCaption.Options.UseTextOptions = true;
		this.layoutControlItem8.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.layoutControlItem8.Control = this.labelControl1;
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(201, 20);
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem7.Control = this.lblSemester;
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 20);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.layoutControlItem7.Size = new System.Drawing.Size(201, 21);
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextVisible = false;
		this.gridControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridControl1.Location = new System.Drawing.Point(211, 4);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(544, 468);
		this.gridControl1.TabIndex = 37;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[10] { this.gridName, this.gridStudentNumber, this.gridDB, this.gridSex, this.gridColumn1, this.gridBursary, this.gridFeesBalance, this.gridColumn2, this.gridColumn3, this.gridColumn4 });
		this.gridView1.FixedLineWidth = 3;
		styleFormatCondition.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		styleFormatCondition.Appearance.BackColor2 = System.Drawing.Color.FromArgb(0, 0, 192);
		styleFormatCondition.Appearance.ForeColor = System.Drawing.Color.White;
		styleFormatCondition.Appearance.Options.UseBackColor = true;
		styleFormatCondition.Appearance.Options.UseForeColor = true;
		styleFormatCondition.ApplyToRow = true;
		styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
		styleFormatCondition.Value1 = "1";
		styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
		styleFormatCondition2.Value1 = "0";
		this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[2] { styleFormatCondition, styleFormatCondition2 });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsFind.AlwaysVisible = true;
		this.gridView1.OptionsSelection.MultiSelect = true;
		this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
		this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.ShowFooter = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.DoubleClick += new System.EventHandler(gridView1_DoubleClick);
		this.gridName.Caption = "Name";
		this.gridName.FieldName = "Name";
		this.gridName.Name = "gridName";
		this.gridName.OptionsColumn.AllowEdit = false;
		this.gridName.Visible = true;
		this.gridName.VisibleIndex = 1;
		this.gridName.Width = 247;
		this.gridStudentNumber.Caption = "StudentNo";
		this.gridStudentNumber.FieldName = "StudentNumber";
		this.gridStudentNumber.Name = "gridStudentNumber";
		this.gridStudentNumber.OptionsColumn.AllowEdit = false;
		this.gridStudentNumber.Visible = true;
		this.gridStudentNumber.VisibleIndex = 2;
		this.gridStudentNumber.Width = 116;
		this.gridDB.Caption = "DB";
		this.gridDB.FieldName = "DB";
		this.gridDB.Name = "gridDB";
		this.gridDB.OptionsColumn.AllowEdit = false;
		this.gridDB.Visible = true;
		this.gridDB.VisibleIndex = 3;
		this.gridDB.Width = 43;
		this.gridSex.Caption = "Sex";
		this.gridSex.FieldName = "Sex";
		this.gridSex.Name = "gridSex";
		this.gridSex.OptionsColumn.AllowEdit = false;
		this.gridSex.Visible = true;
		this.gridSex.VisibleIndex = 4;
		this.gridSex.Width = 43;
		this.gridColumn1.Caption = "Stream";
		this.gridColumn1.FieldName = "StreamId";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.OptionsColumn.AllowEdit = false;
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 6;
		this.gridColumn1.Width = 58;
		this.gridBursary.Caption = "Bursary";
		this.gridBursary.FieldName = "Bursary";
		this.gridBursary.Name = "gridBursary";
		this.gridBursary.OptionsColumn.AllowEdit = false;
		this.gridBursary.Visible = true;
		this.gridBursary.VisibleIndex = 5;
		this.gridFeesBalance.Caption = "Fees Balance";
		this.gridFeesBalance.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridFeesBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridFeesBalance.FieldName = "cashOnAccount";
		this.gridFeesBalance.Name = "gridFeesBalance";
		this.gridFeesBalance.OptionsColumn.AllowEdit = false;
		this.gridFeesBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cashOnAccount", "{0:#,#.0}")
		});
		this.gridFeesBalance.Visible = true;
		this.gridFeesBalance.VisibleIndex = 7;
		this.gridFeesBalance.Width = 151;
		this.gridColumn2.Caption = "Religion";
		this.gridColumn2.FieldName = "Religion";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn3.Caption = "Fees";
		this.gridColumn3.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn3.FieldName = "RequiredFees";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.OptionsColumn.AllowEdit = false;
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 8;
		this.gridColumn3.Width = 162;
		this.gridColumn4.Caption = "Fees Discount";
		this.gridColumn4.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn4.FieldName = "FeesDiscount";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.OptionsColumn.AllowEdit = false;
		this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FeesDiscount", "{0:#,#.0}")
		});
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 9;
		this.gridColumn4.Width = 150;
		this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(509, 478);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(244, 29);
		this.simpleButton1.TabIndex = 32;
		this.simpleButton1.Text = "Close";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton41.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.simpleButton41.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton41.Appearance.Options.UseFont = true;
		this.simpleButton41.Location = new System.Drawing.Point(260, 478);
		this.simpleButton41.Name = "simpleButton41";
		this.simpleButton41.Size = new System.Drawing.Size(244, 29);
		this.simpleButton41.TabIndex = 27;
		this.simpleButton41.Text = "Append";
		this.simpleButton41.Click += new System.EventHandler(simpleButton41_Click);
		this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl6.Location = new System.Drawing.Point(10, 53);
		this.labelControl6.Name = "labelControl6";
		this.labelControl6.Size = new System.Drawing.Size(197, 13);
		this.labelControl6.TabIndex = 43;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.separatorControl1.Location = new System.Drawing.Point(3, 44);
		this.separatorControl1.Name = "separatorControl1";
		this.separatorControl1.Size = new System.Drawing.Size(199, 20);
		this.separatorControl1.TabIndex = 45;
		this.layoutControlItem9.Control = this.separatorControl1;
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 41);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.layoutControlItem9.Size = new System.Drawing.Size(201, 22);
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(760, 517);
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.labelControl6);
		base.Controls.Add(this.gridControl1);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.simpleButton41);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.IconOptions.ShowIcon = false;
		base.Name = "PersonalRequirements";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Student Requirements";
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		base.Load += new System.EventHandler(PersonalRequirements_Load);
		((System.ComponentModel.ISupportInitialize)this.txtAN.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.checkEdit2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClassAppend.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboAppItem.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAppendAmount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtOfAppend.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtOfAppend.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.separatorControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		base.ResumeLayout(false);
	}
}
