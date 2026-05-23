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
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class DiscountsAllowed : XtraForm
{
	private SqlTransaction trans;

	private string CreationMode = string.Empty;

	public StartOrStopTimer StartTimer;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private SimpleButton simpleButton3;

	private SimpleButton simpleButton2;

	private TextEdit txtDiscountValue;

	private TextEdit txtDiscountNameShort;

	private TextEdit txtDiscountName;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem9;

	private ComboBoxEdit cboDiscountType;

	private LayoutControlItem layoutControlItem4;

	private LabelControl labelControl1;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem5;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	public DiscountsAllowed(string _CreationMode)
	{
		InitializeComponent();
		CreationMode = _CreationMode;
	}

	private void AddAllowedDiscount()
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			trans = sqlConnection.BeginTransaction();
			string nextSubAccountNumber = FinalAccounts.GetNextSubAccountNumber(2000, 2004);
			double result = (double.TryParse(txtDiscountValue.Text, out result) ? result : 0.0);
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = "INSERT INTO tbl_AllowedDiscounts (DiscountType,LongDescription,ShortDescription,DiscountValue,accNo) VALUES (@DiscountType,@LongDescription,@ShortDescription,@DiscountValue,@accNo)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@DiscountType", SqlDbType.VarChar, 16);
				sqlParameter.Value = cboDiscountType.SelectedItem.ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@LongDescription", SqlDbType.VarChar, 50);
				sqlParameter.Value = txtDiscountName.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@ShortDescription", SqlDbType.VarChar, 19);
				sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtDiscountNameShort.Text);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@DiscountValue", SqlDbType.Money);
				sqlParameter.Value = result;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
				sqlParameter.Value = nextSubAccountNumber;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = "INSERT INTO tbl_generalAccounts_Sub (accNo,subAccountNo,SubAccoutName)VALUES(@accNo,@subAccountNo,@SubAccoutName)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@accNo", SqlDbType.Int);
				sqlParameter2.Value = 2004;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@SubAccoutName", SqlDbType.VarChar, 25);
				sqlParameter2.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtDiscountNameShort.Text);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@subAccountNo", SqlDbType.VarChar, 9);
				sqlParameter2.Value = nextSubAccountNumber;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			trans.Commit();
			sqlConnection.Close();
			txtDiscountName.Text = string.Empty;
			txtDiscountNameShort.Text = string.Empty;
			txtDiscountValue.Text = string.Empty;
			if (CreationMode == "MainCreation")
			{
				StartTimer(timerStatus: true);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		AddAllowedDiscount();
	}

	private void txtDiscountName_TextChanged(object sender, EventArgs e)
	{
	}

	private void DiscountsAllowed_FormClosing(object sender, FormClosingEventArgs e)
	{
		base.DialogResult = DialogResult.OK;
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
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.cboDiscountType = new DevExpress.XtraEditors.ComboBoxEdit();
		this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.txtDiscountValue = new DevExpress.XtraEditors.TextEdit();
		this.txtDiscountNameShort = new DevExpress.XtraEditors.TextEdit();
		this.txtDiscountName = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.cboDiscountType.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDiscountValue.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDiscountNameShort.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDiscountName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.cboDiscountType);
		this.layoutControl1.Controls.Add(this.simpleButton3);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.txtDiscountValue);
		this.layoutControl1.Controls.Add(this.txtDiscountNameShort);
		this.layoutControl1.Controls.Add(this.txtDiscountName);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(457, 183);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "34";
		this.labelControl1.Visible = true;
		this.labelControl1.Location = new System.Drawing.Point(4, 139);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(449, 13);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 14;
		this.cboDiscountType.Location = new System.Drawing.Point(106, 4);
		this.cboDiscountType.Name = "cboDiscountType";
		this.cboDiscountType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboDiscountType.Properties.Appearance.Options.UseFont = true;
		this.cboDiscountType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboDiscountType.Properties.Items.AddRange(new object[2] { "School Bursary", "General Discount" });
		this.cboDiscountType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboDiscountType.Size = new System.Drawing.Size(347, 24);
		this.cboDiscountType.StyleController = this.layoutControl1;
		this.cboDiscountType.TabIndex = 13;
		this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton3.Appearance.Options.UseFont = true;
		this.simpleButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton3.Location = new System.Drawing.Point(230, 156);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(223, 23);
		this.simpleButton3.StyleController = this.layoutControl1;
		this.simpleButton3.TabIndex = 12;
		this.simpleButton3.Text = "Close";
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.Location = new System.Drawing.Point(4, 156);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(222, 23);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 11;
		this.simpleButton2.Text = "Add Discount";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.txtDiscountValue.Location = new System.Drawing.Point(106, 92);
		this.txtDiscountValue.Name = "txtDiscountValue";
		this.txtDiscountValue.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtDiscountValue.Properties.Appearance.Options.UseFont = true;
		this.txtDiscountValue.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtDiscountValue.Properties.Mask.EditMask = "n0";
		this.txtDiscountValue.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtDiscountValue.Size = new System.Drawing.Size(347, 26);
		this.txtDiscountValue.StyleController = this.layoutControl1;
		this.txtDiscountValue.TabIndex = 6;
		this.txtDiscountNameShort.Location = new System.Drawing.Point(106, 32);
		this.txtDiscountNameShort.Name = "txtDiscountNameShort";
		this.txtDiscountNameShort.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtDiscountNameShort.Properties.Appearance.Options.UseFont = true;
		this.txtDiscountNameShort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtDiscountNameShort.Properties.MaxLength = 19;
		this.txtDiscountNameShort.Size = new System.Drawing.Size(347, 26);
		this.txtDiscountNameShort.StyleController = this.layoutControl1;
		this.txtDiscountNameShort.TabIndex = 5;
		this.txtDiscountName.Location = new System.Drawing.Point(106, 62);
		this.txtDiscountName.Name = "txtDiscountName";
		this.txtDiscountName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtDiscountName.Properties.Appearance.Options.UseFont = true;
		this.txtDiscountName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtDiscountName.Properties.MaxLength = 50;
		this.txtDiscountName.Size = new System.Drawing.Size(347, 26);
		this.txtDiscountName.StyleController = this.layoutControl1;
		this.txtDiscountName.TabIndex = 4;
		this.txtDiscountName.TextChanged += new System.EventHandler(txtDiscountName_TextChanged);
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[8] { this.layoutControlItem1, this.layoutControlItem3, this.layoutControlItem8, this.layoutControlItem2, this.layoutControlItem4, this.layoutControlItem9, this.emptySpaceItem1, this.layoutControlItem5 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(457, 183);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.txtDiscountName;
		this.layoutControlItem1.CustomizationFormText = "Discout Name";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 58);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(453, 30);
		this.layoutControlItem1.Text = "Narration";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(99, 18);
		this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem3.Control = this.txtDiscountValue;
		this.layoutControlItem3.CustomizationFormText = "Discount Value";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 88);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(453, 30);
		this.layoutControlItem3.Text = "Discount Value";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(99, 18);
		this.layoutControlItem8.Control = this.simpleButton2;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 152);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(226, 27);
		this.layoutControlItem8.Text = "layoutControlItem8";
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextToControlDistance = 0;
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.txtDiscountNameShort;
		this.layoutControlItem2.CustomizationFormText = "Short Name";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(453, 30);
		this.layoutControlItem2.Text = "Discount Name";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(99, 18);
		this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem4.Control = this.cboDiscountType;
		this.layoutControlItem4.CustomizationFormText = "Discout Type";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(453, 28);
		this.layoutControlItem4.Text = "Discout Type";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(99, 18);
		this.layoutControlItem9.Control = this.simpleButton3;
		this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
		this.layoutControlItem9.Location = new System.Drawing.Point(226, 152);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(227, 27);
		this.layoutControlItem9.Text = "layoutControlItem9";
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextToControlDistance = 0;
		this.layoutControlItem9.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 118);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(453, 17);
		this.emptySpaceItem1.Text = "emptySpaceItem1";
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.Control = this.labelControl1;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 135);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(453, 17);
		this.layoutControlItem5.Text = "layoutControlItem5";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextToControlDistance = 0;
		this.layoutControlItem5.TextVisible = false;
		this.gridColumn1.Caption = "Discount Type";
		this.gridColumn1.FieldName = "DiscountType";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn2.Caption = "Discount";
		this.gridColumn2.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn2.FieldName = "ShortDescription";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 0;
		this.gridColumn2.Width = 494;
		this.gridColumn3.Caption = "Rate";
		this.gridColumn3.FieldName = "DiscountValue";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 1;
		this.gridColumn3.Width = 218;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(457, 183);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "DiscountsAllowed";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Discounts Allowed";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(DiscountsAllowed_FormClosing);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.cboDiscountType.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDiscountValue.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDiscountNameShort.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDiscountName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		base.ResumeLayout(false);
	}
}
