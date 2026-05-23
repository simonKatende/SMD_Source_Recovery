using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace I_Xtreme;

public class LessonCounter : XtraForm
{
	private DataTable dt;

	public string firstName;

	public string lastName;

	public string emplNo;

	private IContainer components = null;

	private TextEdit txtMonth;

	private TextEdit txtYear;

	private TextEdit txtTotalLessons;

	private TextEdit txtCostPerLesson;

	private TextEdit txtLessonCost;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private LabelControl labelControl3;

	private PanelControl panelControl1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private LabelControl labelControl7;

	private LabelControl labelControl8;

	private LabelControl labelControl9;

	private LabelControl labelControl10;

	private LabelControl labelControl11;

	private LabelControl labelControl12;

	private LabelControl labelControl13;

	private LabelControl labelControl14;

	private LabelControl labelControl15;

	private LabelControl labelControl17;

	private DateEdit dtDate;

	private ComboBoxEdit cboClass;

	private ComboBoxEdit cboStream;

	private ComboBoxEdit cboSubject;

	public PictureEdit pictureEdit1;

	private DXValidationProvider dxValidationProvider1;

	private GridControl gridControl1;

	private GridView gridView1;

	private LabelControl labelControl18;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private SimpleButton simpleButton3;

	private Timer timer1;

	public LessonCounter()
	{
		InitializeComponent();
	}

	private void dtDate_EditValueChanged(object sender, EventArgs e)
	{
		txtMonth.Text = dtDate.DateTime.ToString("MMMM");
		txtYear.Text = dtDate.DateTime.ToString("yyyy");
		dxValidationProvider1.RemoveControlError(dtDate);
		GetMeAllLessons();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (dtDate.EditValue != null)
		{
			if (cboClass.SelectedIndex != 0)
			{
				if (cboStream.SelectedItem.ToString() != "N/A")
				{
					if (txtTotalLessons.Text != string.Empty)
					{
						if (txtCostPerLesson.Text != string.Empty)
						{
							AddEmployeeLessons();
							CustomDialog.ShowCustomDialog("Valuation added successfully");
						}
						else
						{
							dxValidationProvider1.Validate();
						}
					}
					else
					{
						dxValidationProvider1.Validate();
					}
				}
				else
				{
					dxValidationProvider1.Validate();
				}
			}
			else
			{
				dxValidationProvider1.Validate();
			}
		}
		else
		{
			dxValidationProvider1.Validate();
		}
	}

	private void AddEmployeeLessons()
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand();
			sqlCommand.Connection = sqlConnection;
			sqlCommand.CommandText = $"SELECT * FROM tbl_LessonsCounter WHERE EmployeeNo='{emplNo}' AND ClassId='{cboClass.SelectedItem}' AND StreamId='{cboStream.SelectedItem}' AND SubjectId='{cboSubject.SelectedItem}' AND month='{txtMonth.Text}' AND year={Convert.ToInt32(txtYear.Text)}";
			sqlCommand.CommandType = CommandType.Text;
			using SqlCommand sqlCommand2 = sqlCommand;
			using SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				sqlConnection.Close();
				XtraMessageBox.Show("Employee already valuated for this Period, Class, Stream and Subject.", string.Format("Duplicate entry for {0} {}", firstName, lastName), MessageBoxButtons.OK);
				return;
			}
			sqlConnection.Close();
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using SqlCommand sqlCommand3 = new SqlCommand
			{
				Connection = sqlConnection2,
				CommandText = "INSERT INTO tbl_LessonsCounter (EmployeeNo,ClassId,StreamId,SemesterId,SubjectId,dateCaptured,month,year,totalLessons,costPerLesson,TotalCost)VALUES(@EmployeeNo,@ClassId,@StreamId,@SemesterId,@SubjectId,@dateCaptured,@month,@year,@totalLessons,@costPerLesson,@TotalCost)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand3.Parameters.Add("@EmployeeNo", SqlDbType.VarChar, 50);
			sqlParameter.Value = emplNo;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand3.Parameters.Add("@ClassId", SqlDbType.VarChar, 50);
			sqlParameter.Value = cboClass.SelectedItem;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand3.Parameters.Add("@StreamId", SqlDbType.VarChar, 50);
			sqlParameter.Value = cboStream.SelectedItem;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
			sqlParameter.Value = WorkingSemesters.GetWorkingSemester();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand3.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
			sqlParameter.Value = cboSubject.SelectedItem;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand3.Parameters.Add("@dateCaptured", SqlDbType.DateTime);
			sqlParameter.Value = dtDate.DateTime.ToShortDateString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand3.Parameters.Add("@month", SqlDbType.VarChar, 11);
			sqlParameter.Value = txtMonth.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand3.Parameters.Add("@year", SqlDbType.Int);
			sqlParameter.Value = Convert.ToInt32(txtYear.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand3.Parameters.Add("@totalLessons", SqlDbType.Int);
			sqlParameter.Value = Convert.ToInt32(txtTotalLessons.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand3.Parameters.Add("@costPerLesson", SqlDbType.Money);
			sqlParameter.Value = Convert.ToDouble(txtCostPerLesson.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand3.Parameters.Add("@TotalCost", SqlDbType.Money);
			sqlParameter.Value = Convert.ToDouble(txtLessonCost.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand3.ExecuteNonQuery();
			sqlConnection2.Close();
			GetMeAllLessons();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
	{
		dxValidationProvider1.RemoveControlError(cboClass);
		if (cboClass.SelectedItem.ToString() == "S.1" || cboClass.SelectedItem.ToString() == "S.2" || cboClass.SelectedItem.ToString() == "S.3" || cboClass.SelectedItem.ToString() == "S.4")
		{
			try
			{
				using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * from OLevelSubjects", selectConnection);
				using (DataSet dataSet = new DataSet())
				{
					sqlDataAdapter.Fill(dataSet, "OLevelSubjectsSubejcts");
					DataTable dataTable = dataSet.Tables[0];
					cboSubject.Properties.Items.Clear();
					foreach (DataRow row in dataTable.Rows)
					{
						cboSubject.Properties.Items.Add(row["SubjectId"].ToString());
					}
				}
				cboSubject.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		else if (cboClass.SelectedItem.ToString() == "S.5" || cboClass.SelectedItem.ToString() == "S.6")
		{
			try
			{
				using SqlConnection selectConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("SELECT * from ALevelSubjects_Categorised", selectConnection2);
				using (DataSet dataSet2 = new DataSet())
				{
					sqlDataAdapter2.Fill(dataSet2, "ALevelSubejcts");
					DataTable dataTable2 = dataSet2.Tables[0];
					cboSubject.Properties.Items.Clear();
					foreach (DataRow row2 in dataTable2.Rows)
					{
						cboSubject.Properties.Items.Add(string.Format("{0} {1}", row2["SubjectId"], row2["paper"]));
					}
				}
				cboSubject.SelectedIndex = 0;
			}
			catch (Exception ex2)
			{
				XtraMessageBox.Show(ex2.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		else
		{
			cboSubject.Properties.Items.Clear();
			cboSubject.Properties.Items.Add("No Subjects found");
			cboSubject.SelectedIndex = 0;
		}
		Stream.LoadStreams(cboClass.SelectedItem.ToString(), cboStream);
	}

	private void CalculateTotalLessonCost()
	{
		int result = (int.TryParse(txtTotalLessons.Text, out result) ? result : 0);
		double result2 = (double.TryParse(txtCostPerLesson.Text, out result2) ? result2 : 0.0);
		txtLessonCost.Text = ((double)result * result2).ToString();
	}

	private void txtTotalLessons_TextChanged(object sender, EventArgs e)
	{
		dxValidationProvider1.RemoveControlError(txtTotalLessons);
		CalculateTotalLessonCost();
	}

	private void txtCostPerLesson_TextChanged(object sender, EventArgs e)
	{
		dxValidationProvider1.RemoveControlError(txtCostPerLesson);
		CalculateTotalLessonCost();
	}

	private void cboStream_SelectedIndexChanged(object sender, EventArgs e)
	{
		dxValidationProvider1.RemoveControlError(cboStream);
	}

	private void GetMeAllLessons()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_LessonsCounter WHERE EmployeeNo='{emplNo}'AND SemesterId='{WorkingSemesters.GetWorkingSemester()}' AND month='{txtMonth.Text}' AND year={Convert.ToInt32(txtYear.Text)}", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Lessons");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			gridControl1.DataSource = dt.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
		}
	}

	private void LessonCounter_Load(object sender, EventArgs e)
	{
		Text = $"Lesson Counter: {firstName.ToUpper()} {lastName.ToUpper()} [{emplNo}]";
		Classes.LoadComboWithClasses(new ComboBoxEdit[1] { cboClass });
	}

	private void LessonCounter_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			if (dtDate.EditValue != null)
			{
				if (cboClass.SelectedIndex != 0)
				{
					if (cboStream.SelectedItem.ToString() != "N/A")
					{
						if (txtTotalLessons.Text != string.Empty)
						{
							if (txtCostPerLesson.Text != string.Empty)
							{
								AddEmployeeLessons();
								CustomDialog.ShowCustomDialog("Valuation added successfully");
							}
							else
							{
								dxValidationProvider1.Validate();
							}
						}
						else
						{
							dxValidationProvider1.Validate();
						}
					}
					else
					{
						dxValidationProvider1.Validate();
					}
				}
				else
				{
					dxValidationProvider1.Validate();
				}
			}
			else
			{
				dxValidationProvider1.Validate();
			}
		}
		else if (e.KeyCode == Keys.Escape)
		{
			Close();
		}
	}

	private void DeleteLessonValuation()
	{
		if (XtraMessageBox.Show("Are sure you want to delete this entry?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
		{
			return;
		}
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			DataRow dataRow = dt.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = string.Format("SELECT * FROM tbl_EmployeePaySlip WHERE EmployeeNo='{0}' AND Month='{1}' AND Year={2} AND Particulars='Lessons'", emplNo, dataRow["month"], dataRow["year"]),
				CommandType = CommandType.Text
			};
			using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				sqlConnection.Close();
				XtraMessageBox.Show("This Employee Account is already credited. Editing is not possible", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			sqlConnection.Close();
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			DataRow dataRow2 = dt.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection2,
				CommandText = string.Format("DELETE FROM tbl_LessonsCounter WHERE id='{0}'", dataRow2["id"]),
				CommandType = CommandType.Text
			})
			{
				sqlCommand2.ExecuteNonQuery();
			}
			sqlConnection2.Close();
			CustomDialog.ShowCustomDialog("Success");
			GetMeAllLessons();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() < 0)
		{
			simpleButton3.Enabled = false;
		}
		else
		{
			simpleButton3.Enabled = true;
		}
	}

	private void simpleButton3_Click(object sender, EventArgs e)
	{
		DeleteLessonValuation();
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
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule5 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		this.txtMonth = new DevExpress.XtraEditors.TextEdit();
		this.txtYear = new DevExpress.XtraEditors.TextEdit();
		this.txtTotalLessons = new DevExpress.XtraEditors.TextEdit();
		this.txtCostPerLesson = new DevExpress.XtraEditors.TextEdit();
		this.txtLessonCost = new DevExpress.XtraEditors.TextEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
		this.dtDate = new DevExpress.XtraEditors.DateEdit();
		this.cboClass = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboStream = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboSubject = new DevExpress.XtraEditors.ComboBoxEdit();
		this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.txtMonth.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtYear.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtTotalLessons.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtCostPerLesson.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtLessonCost.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		this.panelControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dtDate.Properties.VistaTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSubject.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		base.SuspendLayout();
		this.txtMonth.Location = new System.Drawing.Point(53, 212);
		this.txtMonth.Name = "txtMonth";
		this.txtMonth.Properties.ReadOnly = true;
		this.txtMonth.Size = new System.Drawing.Size(127, 20);
		this.txtMonth.TabIndex = 2;
		this.txtYear.Location = new System.Drawing.Point(53, 238);
		this.txtYear.Name = "txtYear";
		this.txtYear.Properties.ReadOnly = true;
		this.txtYear.Size = new System.Drawing.Size(127, 20);
		this.txtYear.TabIndex = 3;
		this.dxValidationProvider1.SetIconAlignment(this.txtTotalLessons, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtTotalLessons.Location = new System.Drawing.Point(72, 420);
		this.txtTotalLessons.Name = "txtTotalLessons";
		this.txtTotalLessons.Properties.Mask.EditMask = "f0";
		this.txtTotalLessons.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtTotalLessons.Size = new System.Drawing.Size(108, 20);
		this.txtTotalLessons.TabIndex = 4;
		conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.txtTotalLessons, conditionValidationRule);
		this.txtTotalLessons.TextChanged += new System.EventHandler(txtTotalLessons_TextChanged);
		this.dxValidationProvider1.SetIconAlignment(this.txtCostPerLesson, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtCostPerLesson.Location = new System.Drawing.Point(72, 446);
		this.txtCostPerLesson.Name = "txtCostPerLesson";
		this.txtCostPerLesson.Properties.Mask.EditMask = "n";
		this.txtCostPerLesson.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtCostPerLesson.Size = new System.Drawing.Size(108, 20);
		this.txtCostPerLesson.TabIndex = 5;
		conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule2.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.txtCostPerLesson, conditionValidationRule2);
		this.txtCostPerLesson.TextChanged += new System.EventHandler(txtCostPerLesson_TextChanged);
		this.txtLessonCost.Location = new System.Drawing.Point(72, 472);
		this.txtLessonCost.Name = "txtLessonCost";
		this.txtLessonCost.Properties.ReadOnly = true;
		this.txtLessonCost.Size = new System.Drawing.Size(108, 20);
		this.txtLessonCost.TabIndex = 6;
		this.labelControl1.Location = new System.Drawing.Point(6, 427);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(42, 13);
		this.labelControl1.TabIndex = 11;
		this.labelControl1.Text = "Lessons:";
		this.labelControl2.Location = new System.Drawing.Point(6, 453);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(48, 13);
		this.labelControl2.TabIndex = 12;
		this.labelControl2.Text = "Unit Cost:";
		this.labelControl3.Location = new System.Drawing.Point(6, 479);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(53, 13);
		this.labelControl3.TabIndex = 13;
		this.labelControl3.Text = "Total Cost:";
		this.pictureEdit1.Location = new System.Drawing.Point(6, 2);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(175, 178);
		this.pictureEdit1.TabIndex = 14;
		this.panelControl1.Controls.Add(this.simpleButton3);
		this.panelControl1.Controls.Add(this.simpleButton2);
		this.panelControl1.Controls.Add(this.simpleButton1);
		this.panelControl1.Location = new System.Drawing.Point(2, 500);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(721, 34);
		this.panelControl1.TabIndex = 19;
		this.simpleButton3.Location = new System.Drawing.Point(5, 6);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(75, 23);
		this.simpleButton3.TabIndex = 2;
		this.simpleButton3.Text = "Delete Entry";
		this.simpleButton3.ToolTip = "Delete selected entry";
		this.simpleButton3.Click += new System.EventHandler(simpleButton3_Click);
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(560, 6);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(75, 23);
		this.simpleButton2.TabIndex = 1;
		this.simpleButton2.Text = "Close";
		this.simpleButton1.Location = new System.Drawing.Point(641, 5);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(75, 23);
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "OK";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.labelControl7.Location = new System.Drawing.Point(6, 302);
		this.labelControl7.Name = "labelControl7";
		this.labelControl7.Size = new System.Drawing.Size(29, 13);
		this.labelControl7.TabIndex = 20;
		this.labelControl7.Text = "Class:";
		this.labelControl8.Location = new System.Drawing.Point(6, 328);
		this.labelControl8.Name = "labelControl8";
		this.labelControl8.Size = new System.Drawing.Size(38, 13);
		this.labelControl8.TabIndex = 21;
		this.labelControl8.Text = "Stream:";
		this.labelControl9.Location = new System.Drawing.Point(6, 354);
		this.labelControl9.Name = "labelControl9";
		this.labelControl9.Size = new System.Drawing.Size(40, 13);
		this.labelControl9.TabIndex = 22;
		this.labelControl9.Text = "Subject:";
		this.labelControl10.Location = new System.Drawing.Point(6, 211);
		this.labelControl10.Name = "labelControl10";
		this.labelControl10.Size = new System.Drawing.Size(34, 13);
		this.labelControl10.TabIndex = 23;
		this.labelControl10.Text = "Month:";
		this.labelControl11.Location = new System.Drawing.Point(6, 237);
		this.labelControl11.Name = "labelControl11";
		this.labelControl11.Size = new System.Drawing.Size(26, 13);
		this.labelControl11.TabIndex = 24;
		this.labelControl11.Text = "Year:";
		this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl12.Visible = true;
		this.labelControl12.Location = new System.Drawing.Point(65, 275);
		this.labelControl12.Name = "labelControl12";
		this.labelControl12.Size = new System.Drawing.Size(115, 13);
		this.labelControl12.TabIndex = 25;
		this.labelControl13.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl13.Visible = true;
		this.labelControl13.Location = new System.Drawing.Point(82, 385);
		this.labelControl13.Name = "labelControl13";
		this.labelControl13.Size = new System.Drawing.Size(98, 18);
		this.labelControl13.TabIndex = 26;
		this.labelControl14.Location = new System.Drawing.Point(6, 275);
		this.labelControl14.Name = "labelControl14";
		this.labelControl14.Size = new System.Drawing.Size(46, 13);
		this.labelControl14.TabIndex = 27;
		this.labelControl14.Text = "Class info";
		this.labelControl15.Location = new System.Drawing.Point(6, 385);
		this.labelControl15.Name = "labelControl15";
		this.labelControl15.Size = new System.Drawing.Size(63, 13);
		this.labelControl15.TabIndex = 28;
		this.labelControl15.Text = "Lesson count";
		this.labelControl17.Location = new System.Drawing.Point(6, 185);
		this.labelControl17.Name = "labelControl17";
		this.labelControl17.Size = new System.Drawing.Size(27, 13);
		this.labelControl17.TabIndex = 30;
		this.labelControl17.Text = "Date:";
		this.dtDate.EditValue = null;
		this.dxValidationProvider1.SetIconAlignment(this.dtDate, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.dtDate.Location = new System.Drawing.Point(53, 186);
		this.dtDate.Name = "dtDate";
		this.dtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtDate.Properties.Mask.EditMask = "";
		this.dtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
		this.dtDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtDate.Size = new System.Drawing.Size(127, 20);
		this.dtDate.TabIndex = 8;
		conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule3.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.dtDate, conditionValidationRule3);
		this.dtDate.EditValueChanged += new System.EventHandler(dtDate_EditValueChanged);
		this.dxValidationProvider1.SetIconAlignment(this.cboClass, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.cboClass.Location = new System.Drawing.Point(53, 299);
		this.cboClass.Name = "cboClass";
		this.cboClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClass.Size = new System.Drawing.Size(127, 20);
		this.cboClass.TabIndex = 7;
		conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
		conditionValidationRule4.ErrorText = "This value is not valid";
		conditionValidationRule4.Value1 = "N/A";
		this.dxValidationProvider1.SetValidationRule(this.cboClass, conditionValidationRule4);
		this.cboClass.SelectedIndexChanged += new System.EventHandler(cboClass_SelectedIndexChanged);
		this.dxValidationProvider1.SetIconAlignment(this.cboStream, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.cboStream.Location = new System.Drawing.Point(53, 325);
		this.cboStream.Name = "cboStream";
		this.cboStream.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboStream.Size = new System.Drawing.Size(127, 20);
		this.cboStream.TabIndex = 9;
		conditionValidationRule5.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
		conditionValidationRule5.ErrorText = "This value is not valid";
		conditionValidationRule5.Value1 = "N/A";
		this.dxValidationProvider1.SetValidationRule(this.cboStream, conditionValidationRule5);
		this.cboStream.SelectedIndexChanged += new System.EventHandler(cboStream_SelectedIndexChanged);
		this.cboSubject.Location = new System.Drawing.Point(53, 351);
		this.cboSubject.Name = "cboSubject";
		this.cboSubject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSubject.Size = new System.Drawing.Size(127, 20);
		this.cboSubject.TabIndex = 10;
		this.gridControl1.Location = new System.Drawing.Point(206, 5);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(517, 489);
		this.gridControl1.TabIndex = 32;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[6] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6 });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.GroupCount = 1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridView1.OptionsCustomization.AllowGroup = false;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridColumn1.Caption = "Class";
		this.gridColumn1.FieldName = "ClassId";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn2.Caption = "Stream";
		this.gridColumn2.FieldName = "StreamId";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 0;
		this.gridColumn3.Caption = "Subject";
		this.gridColumn3.FieldName = "SubjectId";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 1;
		this.gridColumn4.Caption = "Lessons";
		this.gridColumn4.FieldName = "totalLessons";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 2;
		this.gridColumn5.Caption = "Unit cost";
		this.gridColumn5.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn5.FieldName = "costPerLesson";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 3;
		this.gridColumn5.Width = 82;
		this.gridColumn6.Caption = "Total";
		this.gridColumn6.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn6.FieldName = "TotalCost";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 4;
		this.gridColumn6.Width = 101;
		this.labelControl18.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl18.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Vertical;
		this.labelControl18.Visible = true;
		this.labelControl18.Location = new System.Drawing.Point(186, 2);
		this.labelControl18.Name = "labelControl18";
		this.labelControl18.Size = new System.Drawing.Size(14, 487);
		this.labelControl18.TabIndex = 33;
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(726, 536);
		base.Controls.Add(this.labelControl18);
		base.Controls.Add(this.gridControl1);
		base.Controls.Add(this.labelControl17);
		base.Controls.Add(this.labelControl15);
		base.Controls.Add(this.labelControl14);
		base.Controls.Add(this.labelControl13);
		base.Controls.Add(this.labelControl12);
		base.Controls.Add(this.labelControl11);
		base.Controls.Add(this.labelControl10);
		base.Controls.Add(this.labelControl9);
		base.Controls.Add(this.labelControl8);
		base.Controls.Add(this.labelControl7);
		base.Controls.Add(this.panelControl1);
		base.Controls.Add(this.pictureEdit1);
		base.Controls.Add(this.labelControl3);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.txtLessonCost);
		base.Controls.Add(this.txtCostPerLesson);
		base.Controls.Add(this.txtTotalLessons);
		base.Controls.Add(this.txtYear);
		base.Controls.Add(this.txtMonth);
		base.Controls.Add(this.dtDate);
		base.Controls.Add(this.cboClass);
		base.Controls.Add(this.cboStream);
		base.Controls.Add(this.cboSubject);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.Name = "LessonCounter";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Lesson Counter";
		base.Load += new System.EventHandler(LessonCounter_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(LessonCounter_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.txtMonth.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtYear.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtTotalLessons.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtCostPerLesson.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtLessonCost.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		this.panelControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dtDate.Properties.VistaTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSubject.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
