using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class AddAccounts : XtraForm
{
	private DataTable dt;

	private SqlTransaction trans;

	public StartOrStopTimer StartTimer;

	private string CreationMode = string.Empty;

	private int category = 0;

	private IContainer components = null;

	private LayoutControl layoutControl21;

	private SimpleButton simpleButton22;

	private ComboBoxEdit cboAccountCategories;

	private LayoutControlGroup layoutControlGroup47;

	private LayoutControlItem layoutControlItem66;

	private LayoutControlItem layoutControlAccountName;

	private LayoutControlItem layoutControlItem71;

	private LayoutControlGroup layoutControlGroup1;

	private EmptySpaceItem emptySpaceItem1;

	private ComboBoxEdit txtAccountName;

	private System.Windows.Forms.Timer timer1;

	private SimpleButton simpleButton1;

	private LayoutControlItem layoutControlItem1;

	public AddAccounts(bool IsReadOnly, string _CreationMode)
	{
		InitializeComponent();
		CreationMode = _CreationMode;
		FinalAccounts.LoadAccounts(cboAccountCategories);
		cboAccountCategories.Properties.ReadOnly = IsReadOnly;
		if (cboAccountCategories.Properties.ReadOnly)
		{
			cboAccountCategories.SelectedItem = "3.FIXED ASSETS";
		}
	}

	private void AppendAccounts()
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = $"SELECT * FROM tbl_generalAccounts WHERE categoryId={Convert.ToDouble(category)} AND accName='{txtAccountName.Text}'",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (!sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				trans = sqlConnection.BeginTransaction();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandText = "INSERT INTO tbl_generalAccounts (categoryId,accNo,accName)VALUES(@categoryId,@accNo,@accName)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@categoryId", SqlDbType.Int);
					sqlParameter.Value = Convert.ToDouble(category);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@accNo", SqlDbType.Int);
					sqlParameter.Value = FinalAccounts.GetNextAccountNumber(category);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@accName", SqlDbType.VarChar, 50);
					sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtAccountName.Text);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				if (cboAccountCategories.SelectedItem.ToString() == "3.FIXED ASSETS")
				{
					using SqlCommand sqlCommand3 = new SqlCommand
					{
						Connection = sqlConnection,
						Transaction = trans,
						CommandText = "INSERT INTO tbl_StockCategories (category) VALUES (@category)",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@category", SqlDbType.VarChar, 50);
					sqlParameter2.Value = txtAccountName.Text.ToUpper();
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlCommand3.ExecuteNonQuery();
				}
				if (cboAccountCategories.SelectedItem.ToString() == "3.FIXED ASSETS")
				{
					trans.Commit();
					sqlConnection.Close();
					if (CreationMode == "MainCreation")
					{
						StartTimer(timerStatus: true);
						txtAccountName.Text = string.Empty;
						txtAccountName.Focus();
					}
					else
					{
						base.DialogResult = DialogResult.OK;
						Close();
					}
				}
				else
				{
					trans.Commit();
					sqlConnection.Close();
					StartTimer(timerStatus: true);
					txtAccountName.Text = string.Empty;
					txtAccountName.Focus();
				}
			}
			else
			{
				sqlDataReader.Close();
				sqlConnection.Close();
				XtraMessageBox.Show("This account already exists", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton22_Click(object sender, EventArgs e)
	{
		AppendAccounts();
	}

	private void cboAccountCategories_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cboAccountCategories.SelectedIndex > -1)
		{
			category = Convert.ToInt32(FinalAccounts.CategoryNumber(cboAccountCategories));
		}
	}

	private int FocusedAccountNo()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT accNo FROM tbl_generalAccounts WHERE accName='" + txtAccountName.Text + "'", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "ActiveAccountNo");
		string value = string.Empty;
		foreach (DataRow row in dataSet.Tables[0].Rows)
		{
			value = row["accNo"].ToString();
		}
		return Convert.ToInt32(value);
	}

	private void GetLoaningAgents()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Tel AS RefNum,Name FROM tbl_debtors", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "LoaningAgents");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			txtAccountName.Properties.Items.Clear();
			ComboBoxItemCollection items = txtAccountName.Properties.Items;
			object[] items2 = new string[1] { "-Select Debtor-" };
			items.AddRange(items2);
			foreach (DataRow row in dt.Rows)
			{
				txtAccountName.Properties.Items.Add(row["Name"]).ToString();
			}
			txtAccountName.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void GetSuppliers()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT SupplierCode AS RefNum, Company AS Name FROM tbl_Suppliers", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Suppliers");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			txtAccountName.Properties.Items.Clear();
			ComboBoxItemCollection items = txtAccountName.Properties.Items;
			object[] items2 = new string[1] { "-Select Supplier-" };
			items.AddRange(items2);
			foreach (DataRow row in dt.Rows)
			{
				txtAccountName.Properties.Items.Add(row["Name"]).ToString();
			}
			txtAccountName.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void GetEmployees()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT StaffId AS RefNum,StaffName AS Name FROM Staff", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Employees");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			txtAccountName.Properties.Items.Clear();
			ComboBoxItemCollection items = txtAccountName.Properties.Items;
			object[] items2 = new string[1] { "-Select Employee-" };
			items.AddRange(items2);
			foreach (DataRow row in dt.Rows)
			{
				txtAccountName.Properties.Items.Add(row["Name"]);
			}
			txtAccountName.SelectedIndex = 0;
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
		this.layoutControl21 = new DevExpress.XtraLayout.LayoutControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton22 = new DevExpress.XtraEditors.SimpleButton();
		this.cboAccountCategories = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtAccountName = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlGroup47 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem66 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem71 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlAccountName = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl21).BeginInit();
		this.layoutControl21.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.cboAccountCategories.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAccountName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup47).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem66).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem71).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlAccountName).BeginInit();
		base.SuspendLayout();
		this.layoutControl21.Controls.Add(this.simpleButton1);
		this.layoutControl21.Controls.Add(this.simpleButton22);
		this.layoutControl21.Controls.Add(this.cboAccountCategories);
		this.layoutControl21.Controls.Add(this.txtAccountName);
		this.layoutControl21.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl21.Location = new System.Drawing.Point(0, 0);
		this.layoutControl21.Name = "layoutControl21";
		this.layoutControl21.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(564, 77, 465, 514);
		this.layoutControl21.Root = this.layoutControlGroup47;
		this.layoutControl21.Size = new System.Drawing.Size(343, 165);
		this.layoutControl21.TabIndex = 1;
		this.layoutControl21.Text = "layoutControl21";
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton1.Location = new System.Drawing.Point(173, 138);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(166, 23);
		this.simpleButton1.StyleController = this.layoutControl21;
		this.simpleButton1.TabIndex = 5;
		this.simpleButton1.Text = "Close";
		this.simpleButton22.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton22.Appearance.Options.UseFont = true;
		this.simpleButton22.Location = new System.Drawing.Point(4, 138);
		this.simpleButton22.Name = "simpleButton22";
		this.simpleButton22.Size = new System.Drawing.Size(165, 23);
		this.simpleButton22.StyleController = this.layoutControl21;
		this.simpleButton22.TabIndex = 4;
		this.simpleButton22.Text = "Add Account";
		this.simpleButton22.Click += new System.EventHandler(simpleButton22_Click);
		this.cboAccountCategories.EnterMoveNextControl = true;
		this.cboAccountCategories.Location = new System.Drawing.Point(4, 25);
		this.cboAccountCategories.Name = "cboAccountCategories";
		this.cboAccountCategories.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboAccountCategories.Properties.Appearance.Options.UseFont = true;
		this.cboAccountCategories.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboAccountCategories.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboAccountCategories.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboAccountCategories.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboAccountCategories.Size = new System.Drawing.Size(335, 26);
		this.cboAccountCategories.StyleController = this.layoutControl21;
		this.cboAccountCategories.TabIndex = 0;
		this.cboAccountCategories.SelectedIndexChanged += new System.EventHandler(cboAccountCategories_SelectedIndexChanged);
		this.txtAccountName.Location = new System.Drawing.Point(4, 76);
		this.txtAccountName.Name = "txtAccountName";
		this.txtAccountName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtAccountName.Properties.Appearance.Options.UseFont = true;
		this.txtAccountName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtAccountName.Properties.AppearanceDropDown.Options.UseFont = true;
		this.txtAccountName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtAccountName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.txtAccountName.Properties.MaxLength = 35;
		this.txtAccountName.Size = new System.Drawing.Size(335, 26);
		this.txtAccountName.StyleController = this.layoutControl21;
		this.txtAccountName.TabIndex = 2;
		this.layoutControlGroup47.CustomizationFormText = "layoutControlGroup47";
		this.layoutControlGroup47.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup47.GroupBordersVisible = false;
		this.layoutControlGroup47.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem66, this.layoutControlGroup1, this.layoutControlAccountName });
		this.layoutControlGroup47.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup47.Name = "layoutControlGroup47";
		this.layoutControlGroup47.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup47.Size = new System.Drawing.Size(343, 165);
		this.layoutControlGroup47.Text = "layoutControlGroup47";
		this.layoutControlGroup47.TextVisible = false;
		this.layoutControlItem66.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem66.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem66.Control = this.cboAccountCategories;
		this.layoutControlItem66.CustomizationFormText = "Category";
		this.layoutControlItem66.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem66.Name = "layoutControlItem66";
		this.layoutControlItem66.Size = new System.Drawing.Size(339, 51);
		this.layoutControlItem66.Text = "Ledger Account";
		this.layoutControlItem66.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem66.TextSize = new System.Drawing.Size(101, 18);
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem71, this.emptySpaceItem1, this.layoutControlItem1 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 102);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(339, 59);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlItem71.Control = this.simpleButton22;
		this.layoutControlItem71.CustomizationFormText = "layoutControlItem71";
		this.layoutControlItem71.Location = new System.Drawing.Point(0, 32);
		this.layoutControlItem71.Name = "layoutControlItem71";
		this.layoutControlItem71.Size = new System.Drawing.Size(169, 27);
		this.layoutControlItem71.Text = "layoutControlItem71";
		this.layoutControlItem71.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem71.TextToControlDistance = 0;
		this.layoutControlItem71.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
		this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(339, 32);
		this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.emptySpaceItem1.Text = "emptySpaceItem1";
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.Control = this.simpleButton1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(169, 32);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(170, 27);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlAccountName.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.layoutControlAccountName.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlAccountName.Control = this.txtAccountName;
		this.layoutControlAccountName.CustomizationFormText = "Account Name";
		this.layoutControlAccountName.Location = new System.Drawing.Point(0, 51);
		this.layoutControlAccountName.Name = "layoutControlAccountName";
		this.layoutControlAccountName.Size = new System.Drawing.Size(339, 51);
		this.layoutControlAccountName.Text = "Major Account";
		this.layoutControlAccountName.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlAccountName.TextSize = new System.Drawing.Size(101, 18);
		this.timer1.Enabled = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(343, 165);
		base.Controls.Add(this.layoutControl21);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddAccounts";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Account Category";
		((System.ComponentModel.ISupportInitialize)this.layoutControl21).EndInit();
		this.layoutControl21.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.cboAccountCategories.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAccountName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup47).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem66).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem71).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlAccountName).EndInit();
		base.ResumeLayout(false);
	}
}
