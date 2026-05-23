using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class NewDispense : XtraForm
{
	public ItemDispenseInitialization DispenseInitialization;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private MemoEdit memoEdit1;

	private TextEdit textEdit2;

	private TextEdit textEdit1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private Timer timer1;

	private DateEdit dtDispenseDate;

	private LayoutControlItem layoutControlItem6;

	public NewDispense()
	{
		InitializeComponent();
	}

	private void NewDispense_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			Dispose();
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_WasteDispense (_Date,DispTo,Mob,Notes,Status) VALUES (@_Date,@DispTo,@Mob,@Notes,@Status)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@_Date", SqlDbType.DateTime);
			sqlParameter.Value = dtDispenseDate.DateTime.ToShortDateString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@DispTo", SqlDbType.VarChar, 50);
			sqlParameter.Value = textEdit1.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Mob", SqlDbType.VarChar, 10);
			sqlParameter.Value = textEdit2.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Notes", SqlDbType.VarChar, 200);
			sqlParameter.Value = memoEdit1.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar, 5);
			sqlParameter.Value = "Open";
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				sqlConnection.Close();
				DispenseInitialization(textEdit1.Text, textEdit2.Text, memoEdit1.Text, dtDispenseDate.DateTime.ToString("dd-MMM-yy"));
				Dispose();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (textEdit1.Text != string.Empty && textEdit2.Text != string.Empty && dtDispenseDate.EditValue != null)
		{
			simpleButton1.Enabled = true;
		}
		else
		{
			simpleButton1.Enabled = false;
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
		this.dtDispenseDate = new DevExpress.XtraEditors.DateEdit();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
		this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dtDispenseDate.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtDispenseDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.dtDispenseDate);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.memoEdit1);
		this.layoutControl1.Controls.Add(this.textEdit2);
		this.layoutControl1.Controls.Add(this.textEdit1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(284, 261);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.dtDispenseDate.EditValue = null;
		this.dtDispenseDate.EnterMoveNextControl = true;
		this.dtDispenseDate.Location = new System.Drawing.Point(40, 2);
		this.dtDispenseDate.Name = "dtDispenseDate";
		this.dtDispenseDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtDispenseDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtDispenseDate.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtDispenseDate.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtDispenseDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.dtDispenseDate.Size = new System.Drawing.Size(242, 20);
		this.dtDispenseDate.StyleController = this.layoutControl1;
		this.dtDispenseDate.TabIndex = 0;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(144, 237);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(138, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 4;
		this.simpleButton2.Text = "Cancel";
		this.simpleButton1.Location = new System.Drawing.Point(2, 237);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(138, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 4;
		this.simpleButton1.Text = "Continue";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.memoEdit1.Location = new System.Drawing.Point(2, 90);
		this.memoEdit1.Name = "memoEdit1";
		this.memoEdit1.Properties.MaxLength = 300;
		this.memoEdit1.Size = new System.Drawing.Size(280, 143);
		this.memoEdit1.StyleController = this.layoutControl1;
		this.memoEdit1.TabIndex = 3;
		this.textEdit2.EnterMoveNextControl = true;
		this.textEdit2.Location = new System.Drawing.Point(40, 50);
		this.textEdit2.Name = "textEdit2";
		this.textEdit2.Properties.MaxLength = 10;
		this.textEdit2.Size = new System.Drawing.Size(242, 20);
		this.textEdit2.StyleController = this.layoutControl1;
		this.textEdit2.TabIndex = 2;
		this.textEdit1.EnterMoveNextControl = true;
		this.textEdit1.Location = new System.Drawing.Point(40, 26);
		this.textEdit1.Name = "textEdit1";
		this.textEdit1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.textEdit1.Properties.MaxLength = 50;
		this.textEdit1.Size = new System.Drawing.Size(242, 20);
		this.textEdit1.StyleController = this.layoutControl1;
		this.textEdit1.TabIndex = 1;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[6] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(284, 261);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.textEdit1;
		this.layoutControlItem1.CustomizationFormText = "Name:";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(284, 24);
		this.layoutControlItem1.Text = "Name:";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(35, 13);
		this.layoutControlItem2.Control = this.textEdit2;
		this.layoutControlItem2.CustomizationFormText = "Mob. #";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(284, 24);
		this.layoutControlItem2.Text = "Mob. #";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(35, 13);
		this.layoutControlItem3.Control = this.memoEdit1;
		this.layoutControlItem3.CustomizationFormText = "Notes";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(284, 163);
		this.layoutControlItem3.Text = "Notes";
		this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem3.TextSize = new System.Drawing.Size(35, 13);
		this.layoutControlItem4.Control = this.simpleButton1;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 235);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(142, 26);
		this.layoutControlItem4.Text = "layoutControlItem4";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextToControlDistance = 0;
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlItem5.Control = this.simpleButton2;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(142, 235);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(142, 26);
		this.layoutControlItem5.Text = "layoutControlItem5";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextToControlDistance = 0;
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem6.Control = this.dtDispenseDate;
		this.layoutControlItem6.CustomizationFormText = "Date:";
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(284, 24);
		this.layoutControlItem6.Text = "Date:";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(35, 13);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(284, 261);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.Name = "NewDispense";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Dispense To";
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(NewDispense_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dtDispenseDate.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtDispenseDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		base.ResumeLayout(false);
	}
}
