using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class AddSubjects : XtraForm
{
	private string schoolType = SchoolSettings.SchoolGeneralCurriculum.ToString();

	private GridHitInfo downHitInfo = null;

	public StartOrStopTimer StartTimer;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private RadioGroup radioGroupLevel;

	private LayoutControlItem layoutControlItem8;

	private ComboBoxEdit cboSubGroup;

	private GridControl gridControlAdded;

	private GridView gridViewAdded;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutSubjectGrouping;

	private GridControl gridControlSubjects;

	private GridView gridViewSubjects;

	private LayoutControlItem layoutControlItem1;

	public AddSubjects()
	{
		InitializeComponent();
	}

	private void AppendSubjects()
	{
		if (schoolType == SchoolSettings.SchoolType.Primary.ToString())
		{
			if (cboSubGroup.SelectedIndex > -1)
			{
				using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					sqlConnection.Open();
					SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = "SELECT * FROM OLevelSubjects WHERE SubjectId=@SubjectId",
						CommandType = CommandType.Text
					};
					sqlCommand.Parameters.AddWithValue("subjectId", gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "Subject"));
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					if (!sqlDataReader.HasRows)
					{
						sqlConnection.Close();
						using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection2.Open();
						using SqlCommand sqlCommand2 = new SqlCommand
						{
							Connection = sqlConnection2,
							CommandText = "INSERT INTO OLevelSubjects (SubGroup,SubjectId,SubjectName,ShortCode)VALUES(@SubGroup,@SubjectId,@SubjectName,@ShortCode)",
							CommandType = CommandType.Text
						};
						SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@SubGroup", SqlDbType.VarChar, 50);
						sqlParameter.Value = cboSubGroup.SelectedItem.ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
						sqlParameter.Value = gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "Subject");
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@SubjectName", SqlDbType.VarChar, 50);
						sqlParameter.Value = gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "Subject");
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@ShortCode", SqlDbType.VarChar, 2);
						sqlParameter.Value = gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "ShortCode");
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
						sqlConnection2.Close();
					}
				}
				StartTimer(timerStatus: true);
				LoadAddedSubjects(radioGroupLevel.SelectedIndex);
			}
			else
			{
				XtraMessageBox.Show("Please select a Subject Group", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		else
		{
			if (!(schoolType == SchoolSettings.SchoolType.Secondary.ToString()))
			{
				return;
			}
			if (radioGroupLevel.SelectedIndex == 0)
			{
				using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					sqlConnection3.Open();
					SqlCommand sqlCommand3 = new SqlCommand
					{
						Connection = sqlConnection3,
						CommandText = "SELECT * FROM OLevelSubjects WHERE SubjectId=@SubjectId",
						CommandType = CommandType.Text
					};
					sqlCommand3.Parameters.AddWithValue("subjectId", gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "Subject").ToString());
					SqlDataReader sqlDataReader2 = sqlCommand3.ExecuteReader();
					if (!sqlDataReader2.HasRows)
					{
						sqlConnection3.Close();
						using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection4.Open();
						using (SqlCommand sqlCommand4 = new SqlCommand
						{
							Connection = sqlConnection4,
							CommandText = "INSERT INTO OLevelSubjects (SubGroup,SubjectId,SubjectName,ShortCode)VALUES(@SubGroup,@SubjectId,@SubjectName,@ShortCode)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter2 = sqlCommand4.Parameters.Add("@SubGroup", SqlDbType.VarChar, 50);
							sqlParameter2.Value = cboSubGroup.SelectedItem.ToString();
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand4.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
							sqlParameter2.Value = gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "Subject").ToString();
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand4.Parameters.Add("@SubjectName", SqlDbType.VarChar, 50);
							sqlParameter2.Value = gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "Subject").ToString();
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand4.Parameters.Add("@ShortCode", SqlDbType.VarChar, 2);
							sqlParameter2.Value = gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "ShortCode");
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlCommand4.ExecuteNonQuery();
						}
						sqlConnection4.Close();
					}
				}
				StartTimer(timerStatus: true);
				LoadAddedSubjects(radioGroupLevel.SelectedIndex);
			}
			else
			{
				if (radioGroupLevel.SelectedIndex != 1)
				{
					return;
				}
				using SqlConnection sqlConnection5 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection5.Open();
				using SqlCommand sqlCommand5 = new SqlCommand
				{
					Connection = sqlConnection5,
					CommandText = "SELECT * FROM ALevelSubjects WHERE SubjectId=@SubjectId",
					CommandType = CommandType.Text
				};
				sqlCommand5.Parameters.AddWithValue("subjectId", gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "Subject").ToString());
				SqlDataReader sqlDataReader3 = sqlCommand5.ExecuteReader();
				if (sqlDataReader3.HasRows)
				{
					return;
				}
				sqlConnection5.Close();
				using SqlConnection sqlConnection6 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection6.Open();
				using SqlCommand sqlCommand6 = new SqlCommand
				{
					Connection = sqlConnection6,
					CommandText = "INSERT INTO ALevelSubjects (SubjectId,SubjectName,Category,ShortCode)VALUES(@SubjectId,@SubjectName,@Category,@ShortCode)",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter3 = sqlCommand6.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
				sqlParameter3.Value = gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "Subject");
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand6.Parameters.Add("@SubjectName", SqlDbType.VarChar, 50);
				sqlParameter3.Value = gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "Subject");
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand6.Parameters.Add("@Category", SqlDbType.VarChar, 12);
				sqlParameter3.Value = gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "Category");
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand6.Parameters.Add("@ShortCode", SqlDbType.VarChar, 2);
				sqlParameter3.Value = gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "ShortCode");
				sqlParameter3.Direction = ParameterDirection.Input;
				if (sqlCommand6.ExecuteNonQuery() <= 0)
				{
					return;
				}
				sqlConnection6.Close();
				string[] array = new string[0];
				array = Subjects.ALevelPapers(gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "Subject").ToString()).ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					using SqlConnection sqlConnection7 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection7.Open();
					using SqlCommand sqlCommand7 = new SqlCommand
					{
						Connection = sqlConnection7,
						CommandText = "SELECT PaperId FROM ALevelSubjects_Categorised WHERE PaperId=@PaperId",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter4 = sqlCommand7.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
					sqlParameter4.Value = string.Format("{0} {1}", gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "Subject").ToString(), array[i].ToString());
					sqlParameter4.Direction = ParameterDirection.Input;
					SqlDataReader sqlDataReader4 = sqlCommand7.ExecuteReader();
					if (sqlDataReader4.HasRows)
					{
						continue;
					}
					sqlConnection7.Close();
					using SqlConnection sqlConnection8 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection8.Open();
					using SqlCommand sqlCommand8 = new SqlCommand
					{
						Connection = sqlConnection8,
						CommandText = "INSERT INTO ALevelSubjects_Categorised (PaperId,SubjectId,Paper,Category,ShortCode)VALUES(@PaperId,@SubjectId,@Paper,@Category,@ShortCode)",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter5 = sqlCommand8.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
					sqlParameter5.Value = string.Format("{0} {1}", gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "Subject").ToString(), array[i].ToString());
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlParameter5 = sqlCommand8.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
					sqlParameter5.Value = gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "Subject").ToString();
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlParameter5 = sqlCommand8.Parameters.Add("@Paper", SqlDbType.VarChar, 10);
					sqlParameter5.Value = array[i].ToString();
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlParameter5 = sqlCommand8.Parameters.Add("@Category", SqlDbType.VarChar, 7);
					sqlParameter5.Value = gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "Category");
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlParameter5 = sqlCommand8.Parameters.Add("@ShortCode", SqlDbType.VarChar, 2);
					sqlParameter5.Value = string.Format("{0}{1}", gridViewSubjects.GetRowCellValue(gridViewSubjects.GetFocusedDataSourceRowIndex(), "ShortCode").ToString().Substring(0, 1), array[i].ToString().Substring(array[i].ToString().Length - 1, 1));
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlCommand8.ExecuteNonQuery();
					sqlConnection8.Close();
				}
				StartTimer(timerStatus: true);
				LoadAddedSubjects(radioGroupLevel.SelectedIndex);
			}
		}
	}

	private void simpleButton31_Click(object sender, EventArgs e)
	{
		AppendSubjects();
	}

	private void AddSubjects_Load(object sender, EventArgs e)
	{
		if (schoolType == SchoolSettings.SchoolType.Primary.ToString())
		{
			layoutControlItem8.Visibility = LayoutVisibility.Never;
			gridControlSubjects.DataSource = Subjects.PrimarySubjectsData;
		}
		else if (schoolType == SchoolSettings.SchoolType.Secondary.ToString())
		{
			gridControlSubjects.DataSource = Subjects.OLevelSubjectsData;
		}
	}

	private void simpleButton4_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void radioGroupLevel_SelectedIndexChanged_1(object sender, EventArgs e)
	{
		LoadAddedSubjects(radioGroupLevel.SelectedIndex);
		if (radioGroupLevel.SelectedIndex == 0)
		{
			layoutSubjectGrouping.Visibility = LayoutVisibility.Always;
			gridControlSubjects.DataSource = Subjects.OLevelSubjectsData.DefaultView;
		}
		else
		{
			layoutSubjectGrouping.Visibility = LayoutVisibility.Never;
			gridControlSubjects.DataSource = Subjects.ALevelSubjectsData;
		}
	}

	private void LoadAddedSubjects(int Level)
	{
		try
		{
			string empty = string.Empty;
			empty = ((Level != 0) ? "SELECT * FROM ALevelSubjects" : "SELECT * FROM OLevelSubjects");
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(empty, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Subjects");
			gridControlAdded.DataSource = dataSet.Tables[0].DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void gridViewSubjects_MouseDown(object sender, MouseEventArgs e)
	{
		GridView gridView = sender as GridView;
		downHitInfo = null;
		GridHitInfo gridHitInfo = gridView.CalcHitInfo(new Point(e.X, e.Y));
		if (Control.ModifierKeys == Keys.None && e.Button == MouseButtons.Left && gridHitInfo.RowHandle >= 0)
		{
			downHitInfo = gridHitInfo;
		}
	}

	private void gridViewSubjects_MouseMove(object sender, MouseEventArgs e)
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

	private void gridControlAdded_DragOver(object sender, DragEventArgs e)
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

	private void gridControlAdded_DragDrop(object sender, DragEventArgs e)
	{
		AppendSubjects();
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.gridControlSubjects = new DevExpress.XtraGrid.GridControl();
		this.gridViewSubjects = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.cboSubGroup = new DevExpress.XtraEditors.ComboBoxEdit();
		this.gridControlAdded = new DevExpress.XtraGrid.GridControl();
		this.gridViewAdded = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.radioGroupLevel = new DevExpress.XtraEditors.RadioGroup();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutSubjectGrouping = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControlSubjects).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSubjects).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSubGroup.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControlAdded).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewAdded).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.radioGroupLevel.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutSubjectGrouping).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.gridControlSubjects);
		this.layoutControl1.Controls.Add(this.cboSubGroup);
		this.layoutControl1.Controls.Add(this.gridControlAdded);
		this.layoutControl1.Controls.Add(this.radioGroupLevel);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(842, 357, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(713, 499);
		this.layoutControl1.TabIndex = 19;
		this.layoutControl1.Text = "layoutControl1";
		this.gridControlSubjects.Location = new System.Drawing.Point(12, 115);
		this.gridControlSubjects.MainView = this.gridViewSubjects;
		this.gridControlSubjects.Name = "gridControlSubjects";
		this.gridControlSubjects.Size = new System.Drawing.Size(339, 372);
		this.gridControlSubjects.TabIndex = 24;
		this.gridControlSubjects.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewSubjects });
		this.gridViewSubjects.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridViewSubjects.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridViewSubjects.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridViewSubjects.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.DetailTip.Options.UseFont = true;
		this.gridViewSubjects.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.Empty.Options.UseFont = true;
		this.gridViewSubjects.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.EvenRow.Options.UseFont = true;
		this.gridViewSubjects.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridViewSubjects.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.FilterPanel.Options.UseFont = true;
		this.gridViewSubjects.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.FixedLine.Options.UseFont = true;
		this.gridViewSubjects.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.FocusedCell.Options.UseFont = true;
		this.gridViewSubjects.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.FocusedRow.Options.UseFont = true;
		this.gridViewSubjects.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.FooterPanel.Options.UseFont = true;
		this.gridViewSubjects.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.GroupButton.Options.UseFont = true;
		this.gridViewSubjects.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.GroupFooter.Options.UseFont = true;
		this.gridViewSubjects.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.GroupPanel.Options.UseFont = true;
		this.gridViewSubjects.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.GroupRow.Options.UseFont = true;
		this.gridViewSubjects.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridViewSubjects.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridViewSubjects.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.HorzLine.Options.UseFont = true;
		this.gridViewSubjects.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.OddRow.Options.UseFont = true;
		this.gridViewSubjects.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.Preview.Options.UseFont = true;
		this.gridViewSubjects.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.Row.Options.UseFont = true;
		this.gridViewSubjects.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.RowSeparator.Options.UseFont = true;
		this.gridViewSubjects.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.SelectedRow.Options.UseFont = true;
		this.gridViewSubjects.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.TopNewRow.Options.UseFont = true;
		this.gridViewSubjects.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.VertLine.Options.UseFont = true;
		this.gridViewSubjects.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewSubjects.Appearance.ViewCaption.Options.UseFont = true;
		this.gridViewSubjects.GridControl = this.gridControlSubjects;
		this.gridViewSubjects.Name = "gridViewSubjects";
		this.gridViewSubjects.OptionsBehavior.Editable = false;
		this.gridViewSubjects.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridViewSubjects.OptionsView.ShowGroupPanel = false;
		this.gridViewSubjects.OptionsView.ShowIndicator = false;
		this.gridViewSubjects.MouseDown += new System.Windows.Forms.MouseEventHandler(gridViewSubjects_MouseDown);
		this.gridViewSubjects.MouseMove += new System.Windows.Forms.MouseEventHandler(gridViewSubjects_MouseMove);
		this.cboSubGroup.Location = new System.Drawing.Point(114, 89);
		this.cboSubGroup.Name = "cboSubGroup";
		this.cboSubGroup.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboSubGroup.Properties.Appearance.Options.UseFont = true;
		this.cboSubGroup.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboSubGroup.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboSubGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSubGroup.Properties.Items.AddRange(new object[2] { "Core Subjects", "Other subjects" });
		this.cboSubGroup.Size = new System.Drawing.Size(587, 22);
		this.cboSubGroup.StyleController = this.layoutControl1;
		this.cboSubGroup.TabIndex = 23;
		this.gridControlAdded.AllowDrop = true;
		this.gridControlAdded.Location = new System.Drawing.Point(355, 115);
		this.gridControlAdded.MainView = this.gridViewAdded;
		this.gridControlAdded.Name = "gridControlAdded";
		this.gridControlAdded.Size = new System.Drawing.Size(346, 372);
		this.gridControlAdded.TabIndex = 22;
		this.gridControlAdded.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewAdded });
		this.gridControlAdded.DragDrop += new System.Windows.Forms.DragEventHandler(gridControlAdded_DragDrop);
		this.gridControlAdded.DragOver += new System.Windows.Forms.DragEventHandler(gridControlAdded_DragOver);
		this.gridViewAdded.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridViewAdded.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridViewAdded.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridViewAdded.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.DetailTip.Options.UseFont = true;
		this.gridViewAdded.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.Empty.Options.UseFont = true;
		this.gridViewAdded.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.EvenRow.Options.UseFont = true;
		this.gridViewAdded.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridViewAdded.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.FilterPanel.Options.UseFont = true;
		this.gridViewAdded.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.FixedLine.Options.UseFont = true;
		this.gridViewAdded.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.FocusedCell.Options.UseFont = true;
		this.gridViewAdded.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.FocusedRow.Options.UseFont = true;
		this.gridViewAdded.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.FooterPanel.Options.UseFont = true;
		this.gridViewAdded.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.GroupButton.Options.UseFont = true;
		this.gridViewAdded.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.GroupFooter.Options.UseFont = true;
		this.gridViewAdded.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.GroupPanel.Options.UseFont = true;
		this.gridViewAdded.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.GroupRow.Options.UseFont = true;
		this.gridViewAdded.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridViewAdded.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridViewAdded.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.HorzLine.Options.UseFont = true;
		this.gridViewAdded.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.OddRow.Options.UseFont = true;
		this.gridViewAdded.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.Preview.Options.UseFont = true;
		this.gridViewAdded.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.Row.Options.UseFont = true;
		this.gridViewAdded.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.RowSeparator.Options.UseFont = true;
		this.gridViewAdded.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.SelectedRow.Options.UseFont = true;
		this.gridViewAdded.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.TopNewRow.Options.UseFont = true;
		this.gridViewAdded.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.VertLine.Options.UseFont = true;
		this.gridViewAdded.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridViewAdded.Appearance.ViewCaption.Options.UseFont = true;
		this.gridViewAdded.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[2] { this.gridColumn1, this.gridColumn2 });
		this.gridViewAdded.GridControl = this.gridControlAdded;
		this.gridViewAdded.GroupCount = 1;
		this.gridViewAdded.GroupFormat = " {1}{2}";
		this.gridViewAdded.Name = "gridViewAdded";
		this.gridViewAdded.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridViewAdded.OptionsBehavior.Editable = false;
		this.gridViewAdded.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridViewAdded.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.gridViewAdded.OptionsView.ShowGroupPanel = false;
		this.gridViewAdded.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridViewAdded.OptionsView.ShowIndicator = false;
		this.gridViewAdded.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
		this.gridViewAdded.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridColumn1.Caption = "SubGroup";
		this.gridColumn1.FieldName = "SubGroup";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn2.Caption = "Subject";
		this.gridColumn2.FieldName = "SubjectId";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 0;
		this.radioGroupLevel.Location = new System.Drawing.Point(12, 31);
		this.radioGroupLevel.Name = "radioGroupLevel";
		this.radioGroupLevel.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.radioGroupLevel.Properties.Appearance.Options.UseFont = true;
		this.radioGroupLevel.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "O Level"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "A Level")
		});
		this.radioGroupLevel.Size = new System.Drawing.Size(689, 54);
		this.radioGroupLevel.StyleController = this.layoutControl1;
		this.radioGroupLevel.TabIndex = 21;
		this.radioGroupLevel.SelectedIndexChanged += new System.EventHandler(radioGroupLevel_SelectedIndexChanged_1);
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[4] { this.layoutControlItem1, this.layoutControlItem3, this.layoutControlItem8, this.layoutSubjectGrouping });
		this.layoutControlGroup1.Name = "Root";
		this.layoutControlGroup1.Size = new System.Drawing.Size(713, 499);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControlSubjects;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 103);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(343, 376);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem3.Control = this.gridControlAdded;
		this.layoutControlItem3.Location = new System.Drawing.Point(343, 103);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(350, 376);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem8.Control = this.radioGroupLevel;
		this.layoutControlItem8.CustomizationFormText = "Class Level";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(693, 77);
		this.layoutControlItem8.Text = "Class Level";
		this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem8.TextSize = new System.Drawing.Size(98, 16);
		this.layoutSubjectGrouping.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutSubjectGrouping.AppearanceItemCaption.Options.UseFont = true;
		this.layoutSubjectGrouping.Control = this.cboSubGroup;
		this.layoutSubjectGrouping.Location = new System.Drawing.Point(0, 77);
		this.layoutSubjectGrouping.Name = "layoutSubjectGrouping";
		this.layoutSubjectGrouping.Size = new System.Drawing.Size(693, 26);
		this.layoutSubjectGrouping.Text = "Subject Grouping";
		this.layoutSubjectGrouping.TextSize = new System.Drawing.Size(98, 16);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(713, 499);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.Name = "AddSubjects";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Select Subjects";
		base.Load += new System.EventHandler(AddSubjects_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControlSubjects).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSubjects).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSubGroup.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControlAdded).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewAdded).EndInit();
		((System.ComponentModel.ISupportInitialize)this.radioGroupLevel.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutSubjectGrouping).EndInit();
		base.ResumeLayout(false);
	}
}
