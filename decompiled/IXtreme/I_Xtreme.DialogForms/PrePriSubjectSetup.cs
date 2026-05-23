using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;

namespace I_Xtreme.DialogForms;

public class PrePriSubjectSetup : XtraForm
{
	public StartOrStopTimer StartTimer;

	private IContainer components = null;

	private ComboBoxEdit cboCategory;

	private TextEdit txtSubject;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private LabelControl labelControl3;

	private DXValidationProvider dxValidationProvider1;

	public PrePriSubjectSetup()
	{
		InitializeComponent();
		LoadSubjectCategories();
	}

	private void LoadSubjectCategories()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT SubGroup FROM OLevelSubjects WHERE ClassLevel='PrePrimary' GROUP By SubGroup", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SubGroups");
			cboCategory.Properties.Items.Clear();
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				cboCategory.Properties.Items.Add(row["SubGroup"].ToString());
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		while (dxValidationProvider1.Validate())
		{
			if (dxValidationProvider1.GetInvalidControls().Count != 0)
			{
				continue;
			}
			string value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSubject.Text.ToLower());
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT * FROM OLevelSubjects WHERE SubjectId=@SubjectId",
				CommandType = CommandType.Text
			};
			sqlCommand.Parameters.AddWithValue("subjectId", value);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (!sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				string empty = string.Empty;
				using SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "INSERT INTO OLevelSubjects (ClassLevel,SubGroup,SubjectId,SubjectName,ShortCode)VALUES(@ClassLevel,@SubGroup,@SubjectId,@SubjectName,@ShortCode)",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@ClassLevel", SqlDbType.VarChar, 10);
				sqlParameter.Value = "PrePrimary";
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@SubGroup", SqlDbType.VarChar, 50);
				sqlParameter.Value = cboCategory.Text.ToUpper();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
				sqlParameter.Value = value;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@SubjectName", SqlDbType.VarChar, 50);
				sqlParameter.Value = value;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@ShortCode", SqlDbType.VarChar, 2);
				sqlParameter.Value = empty;
				sqlParameter.Direction = ParameterDirection.Input;
				if (sqlCommand2.ExecuteNonQuery() > 0)
				{
					sqlConnection.Close();
					LoadSubjectCategories();
					txtSubject.Text = string.Empty;
					StartTimer(timerStatus: true);
				}
				break;
			}
			sqlDataReader.Close();
			sqlConnection.Close();
			break;
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
		this.cboCategory = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtSubject = new DevExpress.XtraEditors.TextEdit();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		((System.ComponentModel.ISupportInitialize)this.cboCategory.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSubject.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).BeginInit();
		base.SuspendLayout();
		this.dxValidationProvider1.SetIconAlignment(this.cboCategory, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.cboCategory.Location = new System.Drawing.Point(81, 12);
		this.cboCategory.Name = "cboCategory";
		this.cboCategory.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboCategory.Properties.Appearance.Options.UseFont = true;
		this.cboCategory.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboCategory.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboCategory.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboCategory.Properties.MaxLength = 50;
		this.cboCategory.Size = new System.Drawing.Size(376, 24);
		this.cboCategory.TabIndex = 0;
		conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule.ErrorText = "This value is required";
		this.dxValidationProvider1.SetValidationRule(this.cboCategory, conditionValidationRule);
		this.dxValidationProvider1.SetIconAlignment(this.txtSubject, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtSubject.Location = new System.Drawing.Point(81, 42);
		this.txtSubject.Name = "txtSubject";
		this.txtSubject.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtSubject.Properties.Appearance.Options.UseFont = true;
		this.txtSubject.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtSubject.Properties.MaxLength = 50;
		this.txtSubject.Size = new System.Drawing.Size(376, 24);
		this.txtSubject.TabIndex = 1;
		conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule2.ErrorText = "This value is required";
		this.dxValidationProvider1.SetValidationRule(this.txtSubject, conditionValidationRule2);
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(12, 105);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(190, 23);
		this.simpleButton1.TabIndex = 2;
		this.simpleButton1.Text = "Add";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(261, 105);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(190, 23);
		this.simpleButton2.TabIndex = 3;
		this.simpleButton2.Text = "Close";
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl1.Location = new System.Drawing.Point(12, 20);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(51, 16);
		this.labelControl1.TabIndex = 4;
		this.labelControl1.Text = "Category";
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl2.Location = new System.Drawing.Point(12, 50);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(43, 16);
		this.labelControl2.TabIndex = 5;
		this.labelControl2.Text = "Subject";
		this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl3.Visible = true;
		this.labelControl3.Location = new System.Drawing.Point(12, 75);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(445, 24);
		this.labelControl3.TabIndex = 6;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(469, 140);
		base.Controls.Add(this.labelControl3);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.txtSubject);
		base.Controls.Add(this.cboCategory);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "PrePriSubjectSetup";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Pre Primary subjects setup";
		((System.ComponentModel.ISupportInitialize)this.cboCategory.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSubject.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
