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
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class BudgetInitialization : XtraForm
{
	public string BudgetType = string.Empty;

	public string BudgetPeriod = string.Empty;

	public BudgetParameters InitializeBudget;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LabelControl labelControl1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private TextEdit txtYear;

	private ComboBoxEdit cboTerm;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem5;

	private Timer timer1;

	private ComboBoxEdit comboBoxEdit1;

	private LayoutControlItem layoutControlItem6;

	public BudgetInitialization()
	{
		InitializeComponent();
		WorkingSemesters.GetSemesters(new ComboBoxEdit[1] { cboTerm });
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		if (comboBoxEdit1.SelectedIndex == 0)
		{
			text = cboTerm.SelectedItem.ToString();
		}
		else if (comboBoxEdit1.SelectedIndex == 1)
		{
			text = txtYear.Text;
		}
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "SELECT * FROM tbl_budgetCategories WHERE Category=@Category",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar, 50);
		sqlParameter.Value = comboBoxEdit1.SelectedItem.ToString() + "_" + text;
		sqlParameter.Direction = ParameterDirection.Input;
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		if (!sqlDataReader.HasRows)
		{
			sqlDataReader.Close();
			SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_budgetCategories (Category) VALUES (@Category)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@Category", SqlDbType.VarChar, 50);
			sqlParameter2.Value = comboBoxEdit1.SelectedItem.ToString() + "_" + text;
			sqlParameter2.Direction = ParameterDirection.Input;
			if (sqlCommand2.ExecuteNonQuery() > 0)
			{
				sqlConnection.Close();
				BudgetPeriod = text;
				BudgetType = comboBoxEdit1.SelectedItem.ToString();
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}
		else
		{
			sqlDataReader.Close();
			XtraMessageBox.Show("You have already set a budget with the selected parameters", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void comboBoxEdit1_Closed(object sender, ClosedEventArgs e)
	{
		if (comboBoxEdit1.SelectedIndex == 0)
		{
			cboTerm.Properties.ReadOnly = false;
			txtYear.ReadOnly = true;
		}
		else if (comboBoxEdit1.SelectedIndex == 1)
		{
			cboTerm.Properties.ReadOnly = true;
			txtYear.ReadOnly = false;
		}
		else
		{
			cboTerm.Properties.ReadOnly = true;
			txtYear.ReadOnly = true;
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtYear = new DevExpress.XtraEditors.TextEdit();
		this.cboTerm = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtYear.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboTerm.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.comboBoxEdit1);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.txtYear);
		this.layoutControl1.Controls.Add(this.cboTerm);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(395, 185);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.comboBoxEdit1.Location = new System.Drawing.Point(2, 24);
		this.comboBoxEdit1.Name = "comboBoxEdit1";
		this.comboBoxEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.comboBoxEdit1.Properties.Appearance.Options.UseFont = true;
		this.comboBoxEdit1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.comboBoxEdit1.Properties.AppearanceDropDown.Options.UseFont = true;
		this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.comboBoxEdit1.Properties.Items.AddRange(new object[2] { "Termly", "Annual" });
		this.comboBoxEdit1.Size = new System.Drawing.Size(391, 26);
		this.comboBoxEdit1.StyleController = this.layoutControl1;
		this.comboBoxEdit1.TabIndex = 9;
		this.comboBoxEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(comboBoxEdit1_Closed);
		this.labelControl1.Location = new System.Drawing.Point(2, 112);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(391, 13);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 8;
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(200, 158);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(193, 25);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 7;
		this.simpleButton2.Text = "Close";
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(2, 158);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(194, 25);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 6;
		this.simpleButton1.Text = "Continue";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.txtYear.Location = new System.Drawing.Point(94, 84);
		this.txtYear.Name = "txtYear";
		this.txtYear.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtYear.Properties.Appearance.Options.UseFont = true;
		this.txtYear.Properties.MaxLength = 4;
		this.txtYear.Properties.ReadOnly = true;
		this.txtYear.Size = new System.Drawing.Size(299, 24);
		this.txtYear.StyleController = this.layoutControl1;
		this.txtYear.TabIndex = 5;
		this.cboTerm.Location = new System.Drawing.Point(94, 54);
		this.cboTerm.Name = "cboTerm";
		this.cboTerm.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboTerm.Properties.Appearance.Options.UseFont = true;
		this.cboTerm.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.cboTerm.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboTerm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboTerm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboTerm.Properties.ReadOnly = true;
		this.cboTerm.Size = new System.Drawing.Size(299, 26);
		this.cboTerm.StyleController = this.layoutControl1;
		this.cboTerm.TabIndex = 4;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[7] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.emptySpaceItem1, this.layoutControlItem5, this.layoutControlItem6 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(395, 185);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.cboTerm;
		this.layoutControlItem1.CustomizationFormText = "Term of Study:";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 52);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(395, 30);
		this.layoutControlItem1.Text = "Term";
		this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(89, 19);
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.txtYear;
		this.layoutControlItem2.CustomizationFormText = "Year:";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 82);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(395, 28);
		this.layoutControlItem2.Text = "Year";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(89, 19);
		this.layoutControlItem3.Control = this.simpleButton1;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 156);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(198, 29);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.Control = this.simpleButton2;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(198, 156);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(197, 29);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 127);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(395, 29);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.Control = this.labelControl1;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 110);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(395, 17);
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f);
		this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem6.Control = this.comboBoxEdit1;
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(395, 52);
		this.layoutControlItem6.Text = "Budget Type";
		this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem6.TextSize = new System.Drawing.Size(89, 19);
		this.timer1.Enabled = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(395, 185);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "BudgetInitialization";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Budget Initialization";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtYear.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboTerm.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		base.ResumeLayout(false);
	}
}
