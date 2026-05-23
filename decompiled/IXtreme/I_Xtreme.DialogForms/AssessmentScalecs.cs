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
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.DialogForms;

public class AssessmentScalecs : XtraForm
{
	private DataTable dt;

	private IContainer components = null;

	private ComboBoxEdit comboBoxEdit1;

	private MyGridControl myGridControl1;

	private MyGridView myGridView1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private LabelControl labelControl1;

	private CheckEdit chkUseOrdinalScale;

	public AssessmentScalecs()
	{
		InitializeComponent();
		LoadAssessmentScales();
	}

	private void comboBoxEdit1_Closed(object sender, ClosedEventArgs e)
	{
		if (comboBoxEdit1.SelectedIndex <= -1)
		{
			return;
		}
		dt = new DataTable();
		dt.Columns.Add("Key", typeof(string));
		dt.Columns.Add("ShortCode", typeof(string));
		if (comboBoxEdit1.SelectedItem.ToString() == "Scale 1")
		{
			for (int i = 0; i < PreprimaryAssessmentScale.Scale1.Length; i++)
			{
				dt.Rows.Add(PreprimaryAssessmentScale.Scale1[i], PreprimaryAssessmentScale.Scale1_ShortCodes[i]);
			}
		}
		else if (comboBoxEdit1.SelectedItem.ToString() == "Scale 2")
		{
			for (int j = 0; j < PreprimaryAssessmentScale.Scale2.Length; j++)
			{
				dt.Rows.Add(PreprimaryAssessmentScale.Scale2[j], PreprimaryAssessmentScale.Scale2_ShortCodes[j]);
			}
		}
		else if (comboBoxEdit1.SelectedItem.ToString() == "Scale 3")
		{
			for (int k = 0; k < PreprimaryAssessmentScale.Scale3.Length; k++)
			{
				dt.Rows.Add(PreprimaryAssessmentScale.Scale3[k], PreprimaryAssessmentScale.Scale3_ShortCodes[k]);
			}
		}
		else if (comboBoxEdit1.SelectedItem.ToString() == "Scale 4")
		{
			for (int l = 0; l < PreprimaryAssessmentScale.Scale4.Length; l++)
			{
				dt.Rows.Add(PreprimaryAssessmentScale.Scale4[l], PreprimaryAssessmentScale.Scale4_ShortCodes[l]);
			}
		}
		else
		{
			dt.Rows.Add(string.Empty, string.Empty);
		}
		myGridControl1.DataSource = dt.DefaultView;
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		try
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "DELETE FROM tbl_AssessmentScale",
				CommandType = CommandType.Text
			};
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			sqlConnection.Open();
			for (int i = 0; i < myGridView1.RowCount; i++)
			{
				SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "INSERT INTO tbl_AssessmentScale ([Key],ShortCode) VALUES (@Key,@ShortCode)",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@Key", SqlDbType.VarChar, 50);
				sqlParameter.Value = myGridView1.GetRowCellValue(i, "Key").ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@ShortCode", SqlDbType.VarChar, 2);
				sqlParameter.Value = myGridView1.GetRowCellValue(i, "ShortCode").ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			sqlConnection.Close();
			XtraMessageBox.Show("Assessment Scale set successfully.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadAssessmentScales()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_AssessmentScale", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AssessmentScale");
			myGridControl1.DataSource = dataSet.Tables[0].DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void chkUseOrdinalScale_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_AssessmentScaleType", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ScaleType");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "INSERT INTO tbl_AssessmentScaleType (UseOrdinalScale) VALUES (@UseOrdinalScale)",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@UseOrdinalScale", SqlDbType.Bit);
				sqlParameter.Value = Convert.ToBoolean(chkUseOrdinalScale.EditValue);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
			else
			{
				SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection2.Open();
				SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "UPDATE tbl_AssessmentScaleType SET UseOrdinalScale=@UseOrdinalScale",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@UseOrdinalScale", SqlDbType.Bit);
				sqlParameter2.Value = Convert.ToBoolean(chkUseOrdinalScale.EditValue);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
				sqlConnection2.Close();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void AssessmentScalecs_Load(object sender, EventArgs e)
	{
		chkUseOrdinalScale.Checked = PreprimaryAssessmentScale.OrdinalScaleInUse;
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
		this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
		this.myGridControl1 = new AlienAge.CustomGrid.MyGridControl();
		this.myGridView1 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.chkUseOrdinalScale = new DevExpress.XtraEditors.CheckEdit();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.myGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.myGridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkUseOrdinalScale.Properties).BeginInit();
		base.SuspendLayout();
		this.comboBoxEdit1.Location = new System.Drawing.Point(100, 39);
		this.comboBoxEdit1.Name = "comboBoxEdit1";
		this.comboBoxEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.comboBoxEdit1.Properties.Appearance.Options.UseFont = true;
		this.comboBoxEdit1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10f);
		this.comboBoxEdit1.Properties.AppearanceDropDown.Options.UseFont = true;
		this.comboBoxEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.comboBoxEdit1.Properties.Items.AddRange(new object[4] { "Scale 1", "Scale 2", "Scale 3", "Scale 4" });
		this.comboBoxEdit1.Size = new System.Drawing.Size(446, 24);
		this.comboBoxEdit1.TabIndex = 0;
		this.comboBoxEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(comboBoxEdit1_Closed);
		this.myGridControl1.Location = new System.Drawing.Point(12, 69);
		this.myGridControl1.MainView = this.myGridView1;
		this.myGridControl1.Name = "myGridControl1";
		this.myGridControl1.Size = new System.Drawing.Size(534, 371);
		this.myGridControl1.TabIndex = 1;
		this.myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.myGridView1 });
		this.myGridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.myGridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.myGridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.myGridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.DetailTip.Options.UseFont = true;
		this.myGridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.Empty.Options.UseFont = true;
		this.myGridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.myGridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.EvenRow.Options.UseBackColor = true;
		this.myGridView1.Appearance.EvenRow.Options.UseFont = true;
		this.myGridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.myGridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.myGridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.FixedLine.Options.UseFont = true;
		this.myGridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.myGridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.myGridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.myGridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.GroupButton.Options.UseFont = true;
		this.myGridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.myGridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.myGridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.GroupRow.Options.UseFont = true;
		this.myGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.myGridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
		this.myGridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.myGridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.myGridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.HorzLine.Options.UseFont = true;
		this.myGridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.OddRow.Options.UseFont = true;
		this.myGridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.Preview.Options.UseFont = true;
		this.myGridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.Row.Options.UseFont = true;
		this.myGridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.myGridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.myGridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.myGridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.VertLine.Options.UseFont = true;
		this.myGridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.myGridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[2] { this.gridColumn1, this.gridColumn2 });
		this.myGridView1.GridControl = this.myGridControl1;
		this.myGridView1.Name = "myGridView1";
		this.myGridView1.OptionsBehavior.Editable = false;
		this.myGridView1.OptionsCustomization.AllowColumnMoving = false;
		this.myGridView1.OptionsCustomization.AllowColumnResizing = false;
		this.myGridView1.OptionsCustomization.AllowFilter = false;
		this.myGridView1.OptionsCustomization.AllowGroup = false;
		this.myGridView1.OptionsCustomization.AllowSort = false;
		this.myGridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.myGridView1.OptionsView.ShowGroupPanel = false;
		this.myGridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.myGridView1.OptionsView.ShowIndicator = false;
		this.gridColumn1.Caption = "Key";
		this.gridColumn1.FieldName = "Key";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 367;
		this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
		this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColumn2.Caption = "Short Code";
		this.gridColumn2.FieldName = "ShortCode";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn2.Width = 150;
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(12, 461);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(210, 23);
		this.simpleButton1.TabIndex = 2;
		this.simpleButton1.Text = "Set Scale";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(336, 461);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(210, 23);
		this.simpleButton2.TabIndex = 3;
		this.simpleButton2.Text = "Close";
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl1.Location = new System.Drawing.Point(12, 47);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(81, 16);
		this.labelControl1.TabIndex = 4;
		this.labelControl1.Text = "Ordinal Scale:";
		this.chkUseOrdinalScale.Location = new System.Drawing.Point(100, 12);
		this.chkUseOrdinalScale.Name = "chkUseOrdinalScale";
		this.chkUseOrdinalScale.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.chkUseOrdinalScale.Properties.Appearance.Options.UseFont = true;
		this.chkUseOrdinalScale.Properties.Caption = "Use Ordinal Scale Assessment";
		this.chkUseOrdinalScale.Size = new System.Drawing.Size(446, 21);
		this.chkUseOrdinalScale.TabIndex = 5;
		this.chkUseOrdinalScale.CheckedChanged += new System.EventHandler(chkUseOrdinalScale_CheckedChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(558, 496);
		base.Controls.Add(this.chkUseOrdinalScale);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.myGridControl1);
		base.Controls.Add(this.comboBoxEdit1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "AssessmentScalecs";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Assessment Scale";
		base.Load += new System.EventHandler(AssessmentScalecs_Load);
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.myGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.myGridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkUseOrdinalScale.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
