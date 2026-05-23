using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class SubjectTermUnits : XtraForm
{
	private int prevValue = 0;

	private int newValue = 0;

	private SqlTransaction trans;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private ComboBoxEdit cboClass;

	private GridControl gridUnits;

	private GridView gridView1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private ComboBoxEdit cboTerm;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	public SubjectTermUnits()
	{
		InitializeComponent();
		WorkingSemesters.GetSemesters(new ComboBoxEdit[1] { cboTerm });
		cboTerm.SelectedItem = WorkingSemesters.GetWorkingSemester();
	}

	private void LoadTermSubjects()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettingsNC   WHERE SemesterId='{cboTerm.Text}' AND ClassId='{cboClass.Text}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		gridUnits.DataSource = dataTable.DefaultView;
	}

	private void cboTerm_EditValueChanged(object sender, EventArgs e)
	{
		if (cboTerm.EditValue != null && cboClass.EditValue != null)
		{
			LoadTermSubjects();
		}
	}

	private void cboClass_EditValueChanged(object sender, EventArgs e)
	{
		if (cboTerm.EditValue != null && cboClass.EditValue != null)
		{
			LoadTermSubjects();
		}
	}

	private string UpdateCommand(int UnitsUsed)
	{
		string result = string.Empty;
		switch (UnitsUsed)
		{
		case 0:
			result = "UPDATE tbl_Scores_OL_Report SET U1='x',U2='x',U3='x',U4='x',U5='x',U6='x',U7='x',U8='x',U9='x',U10='x', Score1='x',Score2='x',Score3='x',Score4='x',Score5='x',Score6='x',Score7='x',Score8='x',Score9='x',Score10='x', Hund1='x',Hund2='x',Hund3='x',Hund4='x',Hund5='x',Hund6='x',Hund7='x',Hund8='x',Hund9='x',Hund10='x', TUnits=0 WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND SemesterId=@SemesterId";
			break;
		case 1:
			result = "UPDATE tbl_Scores_OL_Report SET U2='x',U3='x',U4='x',U5='x',U6='x',U7='x',U8='x',U9='x',U10='x', Score2='x',Score3='x',Score4='x',Score5='x',Score6='x',Score7='x',Score8='x',Score9='x',Score10='x', Hund2='x',Hund3='x',Hund4='x',Hund5='x',Hund6='x',Hund7='x',Hund8='x',Hund9='x',Hund10='x', TUnits=1 WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND SemesterId=@SemesterId";
			break;
		case 2:
			result = "UPDATE tbl_Scores_OL_Report SET U3='x',U4='x',U5='x',U6='x',U7='x',U8='x',U9='x',U10='x', Score3='x',Score4='x',Score5='x',Score6='x',Score7='x',Score8='x',Score9='x',Score10='x', Hund3='x',Hund4='x',Hund5='x',Hund6='x',Hund7='x',Hund8='x',Hund9='x',Hund10='x', TUnits=2 WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND SemesterId=@SemesterId";
			break;
		case 3:
			result = "UPDATE tbl_Scores_OL_Report SET U4='x',U5='x',U6='x',U7='x',U8='x',U9='x',U10='x', Score4='x',Score5='x',Score6='x',Score7='x',Score8='x',Score9='x',Score10='x', Hund4='x',Hund5='x',Hund6='x',Hund7='x',Hund8='x',Hund9='x',Hund10='x', TUnits=3 WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND SemesterId=@SemesterId";
			break;
		case 4:
			result = "UPDATE tbl_Scores_OL_Report SET U5='x',U6='x',U7='x',U8='x',U9='x',U10='x', Score5='x',Score6='x',Score7='x',Score8='x',Score9='x',Score10='x', Hund5='x',Hund6='x',Hund7='x',Hund8='x',Hund9='x',Hund10='x', TUnits=4 WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND SemesterId=@SemesterId";
			break;
		case 5:
			result = "UPDATE tbl_Scores_OL_Report SET U6='x',U7='x',U8='x',U9='x',U10='x', Score6='x',Score7='x',Score8='x',Score9='x',Score10='x', Hund6='x',Hund7='x',Hund8='x',Hund9='x',Hund10='x', TUnits=5 WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND SemesterId=@SemesterId";
			break;
		case 6:
			result = "UPDATE tbl_Scores_OL_Report SET U7='x',U8='x',U9='x',U10='x', Score7='x',Score8='x',Score9='x',Score10='x', Hund7='x',Hund8='x',Hund9='x',Hund10='x', TUnits=6 WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND SemesterId=@SemesterId";
			break;
		case 7:
			result = "UPDATE tbl_Scores_OL_Report SET U8='x',U9='x',U10='x', Score8='x',Score9='x',Score10='x', Hund8='x',Hund9='x',Hund10='x', TUnits=7 WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND SemesterId=@SemesterId";
			break;
		case 8:
			result = "UPDATE tbl_Scores_OL_Report SET U9='x',U10='x', Score9='x',Score10='x', Hund9='x',Hund10='x', TUnits=8 WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND SemesterId=@SemesterId";
			break;
		case 9:
			result = "UPDATE tbl_Scores_OL_Report SET U10='x', Score10='x', Hund10='x', TUnits=9 WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND SemesterId=@SemesterId";
			break;
		case 10:
			result = "UPDATE tbl_Scores_OL_Report SET TUnits=10 WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND SemesterId=@SemesterId";
			break;
		}
		return result;
	}

	private void UpdateUnitsDown(CellValueChangedEventArgs e)
	{
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		trans = sqlConnection.BeginTransaction();
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			Transaction = trans,
			CommandText = "UPDATE tbl_TermSettingsNC SET TUnits=@TUnits WHERE SubjectId=@SubjectId AND SemesterId=@SemesterId AND ClassId=@ClassId",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", gridView1.GetRowCellValue(e.RowHandle, "SubjectId"));
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", cboTerm.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", cboClass.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@TUnits", newValue);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
		}
		string commandText = UpdateCommand(newValue);
		using (SqlCommand sqlCommand2 = new SqlCommand
		{
			Connection = sqlConnection,
			Transaction = trans,
			CommandText = commandText,
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@SubjectId", gridView1.GetRowCellValue(e.RowHandle, "SubjectId"));
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@SemesterId", cboTerm.Text);
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@ClassId", cboClass.Text);
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlCommand2.ExecuteNonQuery();
		}
		trans.Commit();
		sqlConnection.Close();
	}

	private void UpdateUnitsUp(CellValueChangedEventArgs e)
	{
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "UPDATE tbl_TermSettingsNC SET TUnits=@TUnits WHERE SubjectId=@SubjectId AND SemesterId=@SemesterId AND ClassId=@ClassId",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", gridView1.GetRowCellValue(e.RowHandle, "SubjectId"));
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", cboTerm.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", cboClass.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@TUnits", newValue);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
		}
		for (int i = prevValue + 1; i < newValue + 1; i++)
		{
			string commandText = string.Format("UPDATE tbl_Scores_OL_Report SET U{0}='',Score{0}='',Hund{0}='', TUnits={1} WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND SemesterId=@SemesterId", i, newValue);
			using SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = commandText,
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@SubjectId", gridView1.GetRowCellValue(e.RowHandle, "SubjectId"));
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@SemesterId", cboTerm.Text);
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@ClassId", cboClass.Text);
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlCommand2.ExecuteNonQuery();
		}
		sqlConnection.Close();
	}

	private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
	{
		if (gridView1.FocusedRowHandle <= -1)
		{
			return;
		}
		newValue = Convert.ToInt32(e.Value);
		if (e.Column.FieldName == "TUnits")
		{
			if (newValue > prevValue)
			{
				UpdateUnitsUp(e);
			}
			else if (newValue < prevValue)
			{
				DialogResult dialogResult = XtraMessageBox.Show("Changing highest unit to lower unit will delete all marks in upper units.\nNote that this process is not reversible. Do you want to do this?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Yes)
				{
					UpdateUnitsDown(e);
				}
				else
				{
					gridView1.HideEditor();
				}
			}
		}
		else if (e.Column.FieldName == "IsAssessed")
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "UPDATE tbl_Scores_OL_Report SET IsAssessed=@IsAssessed WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND SemesterId=@SemesterId",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("IsAssessed", Convert.ToBoolean(e.Value));
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("SubjectId", gridView1.GetRowCellValue(e.RowHandle, "SubjectId"));
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("SemesterId", cboTerm.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("ClassId", cboClass.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		else if (e.Column.FieldName == "ProjectAvailable")
		{
			SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection2,
				CommandText = "UPDATE tbl_TermSettingsNC SET ProjectAvailable=@ProjectAvailable WHERE ClassId=@ClassId AND SubjectId=@SubjectId AND SemesterId=@SemesterId",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter2 = sqlCommand2.Parameters.AddWithValue("ProjectAvailable", Convert.ToBoolean(e.Value));
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.AddWithValue("SubjectId", gridView1.GetRowCellValue(e.RowHandle, "SubjectId"));
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.AddWithValue("SemesterId", cboTerm.Text);
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.AddWithValue("ClassId", cboClass.Text);
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlCommand2.ExecuteNonQuery();
			sqlConnection2.Close();
		}
	}

	private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
	{
		if (gridView1.FocusedRowHandle > -1 && gridView1.FocusedColumn == gridView1.Columns["TUnits"])
		{
			if (!int.TryParse(e.Value.ToString(), out var result) || result > 10 || result < 1)
			{
				e.Valid = false;
			}
			else if (!int.TryParse(e.Value.ToString(), out result))
			{
				e.Valid = true;
			}
		}
	}

	private void gridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
	{
		e.ExceptionMode = ExceptionMode.DisplayError;
		e.WindowCaption = "Input Error";
		e.ErrorText = "You have to enter digits ranging from 1 to 10 only.";
		gridView1.HideEditor();
	}

	private void gridView1_ShownEditor(object sender, EventArgs e)
	{
		prevValue = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TUnits"));
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
		this.cboClass = new DevExpress.XtraEditors.ComboBoxEdit();
		this.gridUnits = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.cboTerm = new DevExpress.XtraEditors.ComboBoxEdit();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridUnits).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboTerm.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.cboClass);
		this.layoutControl1.Controls.Add(this.gridUnits);
		this.layoutControl1.Controls.Add(this.cboTerm);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Margin = new System.Windows.Forms.Padding(2);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(527, 390);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.cboClass.Location = new System.Drawing.Point(40, 27);
		this.cboClass.Margin = new System.Windows.Forms.Padding(2);
		this.cboClass.Name = "cboClass";
		this.cboClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClass.Properties.Items.AddRange(new object[4] { "S.1", "S.2", "S.3", "S.4" });
		this.cboClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboClass.Size = new System.Drawing.Size(484, 20);
		this.cboClass.StyleController = this.layoutControl1;
		this.cboClass.TabIndex = 6;
		this.cboClass.EditValueChanged += new System.EventHandler(cboClass_EditValueChanged);
		this.gridUnits.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
		this.gridUnits.Location = new System.Drawing.Point(3, 51);
		this.gridUnits.MainView = this.gridView1;
		this.gridUnits.Margin = new System.Windows.Forms.Padding(2);
		this.gridUnits.Name = "gridUnits";
		this.gridUnits.Size = new System.Drawing.Size(521, 336);
		this.gridUnits.TabIndex = 5;
		this.gridUnits.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[4] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4 });
		this.gridView1.DetailHeight = 239;
		this.gridView1.GridControl = this.gridUnits;
		this.gridView1.GroupFormat = "{1} {2}";
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.ShownEditor += new System.EventHandler(gridView1_ShownEditor);
		this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView1_CellValueChanged);
		this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(gridView1_ValidatingEditor);
		this.gridView1.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(gridView1_InvalidValueException);
		this.gridColumn1.Caption = "Subject";
		this.gridColumn1.FieldName = "SubjectId";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.OptionsColumn.AllowEdit = false;
		this.gridColumn1.OptionsColumn.ReadOnly = true;
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 465;
		this.gridColumn2.Caption = "Total Chapters";
		this.gridColumn2.FieldName = "TUnits";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn2.Width = 207;
		this.gridColumn3.Caption = "Is Assessed";
		this.gridColumn3.FieldName = "IsAssessed";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn4.Caption = "Project Inclusive";
		this.gridColumn4.FieldName = "ProjectAvailable";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 2;
		this.gridColumn4.Width = 412;
		this.cboTerm.Location = new System.Drawing.Point(40, 3);
		this.cboTerm.Margin = new System.Windows.Forms.Padding(2);
		this.cboTerm.Name = "cboTerm";
		this.cboTerm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboTerm.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboTerm.Size = new System.Drawing.Size(484, 20);
		this.cboTerm.StyleController = this.layoutControl1;
		this.cboTerm.TabIndex = 4;
		this.cboTerm.EditValueChanged += new System.EventHandler(cboTerm_EditValueChanged);
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.Root.Size = new System.Drawing.Size(527, 390);
		this.Root.TextVisible = false;
		this.layoutControlItem1.Control = this.cboTerm;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(525, 24);
		this.layoutControlItem1.Text = "Term";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(25, 13);
		this.layoutControlItem2.Control = this.gridUnits;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(525, 340);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.cboClass;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(525, 24);
		this.layoutControlItem3.Text = "Class";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(25, 13);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(527, 390);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.Margin = new System.Windows.Forms.Padding(2);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SubjectTermUnits";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "SubjectTermUnits";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridUnits).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboTerm.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
