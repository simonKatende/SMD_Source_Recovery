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
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class QtyAmount : XtraForm
{
	public string accountNo = string.Empty;

	public string CheckNo = string.Empty;

	public string VoucherNo = string.Empty;

	public string vote = string.Empty;

	public string sub_vote = string.Empty;

	public DateTime Date = DateTime.Now;

	public string connectionString = DataConnection.ConnectToDatabase();

	private string voucherType = string.Empty;

	private IContainer components = null;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private TextEdit textEdit2;

	private TextEdit textEdit1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem5;

	private LabelControl lblVote;

	private LayoutControlItem layoutControlItem6;

	private LabelControl lblSubVote;

	private LayoutControlItem layoutControlItem7;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem8;

	private TextEdit textEdit3;

	public QtyAmount(string voucherType)
	{
		InitializeComponent();
		this.voucherType = voucherType;
	}

	private void QtyAmount_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}
	}

	private void AddTempItems(string CheckNo, string VoucherNo, DateTime Date, int Qty, double Rate)
	{
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "INSERT INTO tbl_TempVoucher (ChequeNo,VoucherNo,Date,Qty,Rate,accNo,item,ExpenseType,Narration,VoucherType) VALUES (@ChequeNo,@VoucherNo,@Date,@Qty,@Rate,@accNo,@item,@ExpenseType,@Narration,@VoucherType)",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@ChequeNo", SqlDbType.VarChar, 30);
		sqlParameter.Value = CheckNo.ToUpper();
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@VoucherNo", SqlDbType.VarChar, 30);
		sqlParameter.Value = VoucherNo.ToUpper();
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Date", SqlDbType.DateTime);
		sqlParameter.Value = Date.ToShortDateString();
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Qty", SqlDbType.Int);
		sqlParameter.Value = Qty;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Rate", SqlDbType.Float);
		sqlParameter.Value = Rate;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
		sqlParameter.Value = accountNo;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@item", SqlDbType.VarChar, 50);
		sqlParameter.Value = vote;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@ExpenseType", SqlDbType.VarChar, 50);
		sqlParameter.Value = sub_vote;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Narration", SqlDbType.VarChar, 30);
		sqlParameter.Value = textEdit3.Text;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@VoucherType", SqlDbType.VarChar, 50);
		sqlParameter.Value = voucherType;
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() != 0)
		{
			sqlConnection.Close();
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		double result = (double.TryParse(textEdit2.Text, out result) ? result : 0.0);
		if (result > 0.0)
		{
			int result2 = ((!int.TryParse(textEdit1.Text, out result2)) ? 1 : result2);
			AddTempItems(CheckNo, VoucherNo, Date, result2, result);
		}
	}

	private void QtyAmount_Load(object sender, EventArgs e)
	{
		lblVote.Text = $"{vote}";
		lblSubVote.Text = $"{accountNo}-{sub_vote}";
		textEdit3.Text = $"CH#{CheckNo}-V#{VoucherNo}";
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
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.lblSubVote = new DevExpress.XtraEditors.LabelControl();
		this.lblVote = new DevExpress.XtraEditors.LabelControl();
		this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.textEdit3.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		base.SuspendLayout();
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(2, 181);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(141, 25);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 2;
		this.simpleButton1.Text = "OK";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.lblSubVote);
		this.layoutControl1.Controls.Add(this.lblVote);
		this.layoutControl1.Controls.Add(this.textEdit3);
		this.layoutControl1.Controls.Add(this.textEdit2);
		this.layoutControl1.Controls.Add(this.textEdit1);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(5, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(290, 208);
		this.layoutControl1.TabIndex = 10;
		this.layoutControl1.Text = "layoutControl1";
		this.labelControl1.Visible = true;
		this.labelControl1.Location = new System.Drawing.Point(2, 41);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(286, 13);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 14;
		this.lblSubVote.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblSubVote.Location = new System.Drawing.Point(2, 19);
		this.lblSubVote.Name = "lblSubVote";
		this.lblSubVote.Size = new System.Drawing.Size(286, 18);
		this.lblSubVote.StyleController = this.layoutControl1;
		this.lblSubVote.TabIndex = 13;
		this.lblVote.Location = new System.Drawing.Point(2, 2);
		this.lblVote.Name = "lblVote";
		this.lblVote.Size = new System.Drawing.Size(286, 13);
		this.lblVote.StyleController = this.layoutControl1;
		this.lblVote.TabIndex = 12;
		this.textEdit3.Location = new System.Drawing.Point(2, 139);
		this.textEdit3.Name = "textEdit3";
		this.textEdit3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textEdit3.Properties.Appearance.Options.UseFont = true;
		this.textEdit3.Properties.MaxLength = 30;
		this.textEdit3.Size = new System.Drawing.Size(286, 24);
		this.textEdit3.StyleController = this.layoutControl1;
		this.textEdit3.TabIndex = 11;
		this.textEdit2.Location = new System.Drawing.Point(64, 88);
		this.textEdit2.Name = "textEdit2";
		this.textEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textEdit2.Properties.Appearance.Options.UseFont = true;
		this.textEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.textEdit2.Properties.Mask.EditMask = "n0";
		this.textEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.textEdit2.Size = new System.Drawing.Size(224, 26);
		this.textEdit2.StyleController = this.layoutControl1;
		this.textEdit2.TabIndex = 10;
		this.textEdit1.Location = new System.Drawing.Point(64, 58);
		this.textEdit1.Name = "textEdit1";
		this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textEdit1.Properties.Appearance.Options.UseFont = true;
		this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.textEdit1.Properties.Mask.EditMask = "f0";
		this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.textEdit1.Size = new System.Drawing.Size(224, 26);
		this.textEdit1.StyleController = this.layoutControl1;
		this.textEdit1.TabIndex = 9;
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(147, 181);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(141, 25);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 5;
		this.simpleButton2.TabStop = false;
		this.simpleButton2.Text = "Cancel";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[9] { this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem1, this.layoutControlItem2, this.emptySpaceItem1, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7, this.layoutControlItem8 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(290, 208);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem3.Control = this.simpleButton1;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 179);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(145, 29);
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.Control = this.simpleButton2;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(145, 179);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(145, 29);
		this.layoutControlItem4.Text = "layoutControlItem4";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextToControlDistance = 0;
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.textEdit1;
		this.layoutControlItem1.CustomizationFormText = "Qty";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 56);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(290, 30);
		this.layoutControlItem1.Text = "Qty";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(59, 18);
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.textEdit2;
		this.layoutControlItem2.CustomizationFormText = "Rate";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 86);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(290, 30);
		this.layoutControlItem2.Text = "Rate";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(59, 18);
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 165);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(290, 14);
		this.emptySpaceItem1.Text = "emptySpaceItem1";
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem5.Control = this.textEdit3;
		this.layoutControlItem5.CustomizationFormText = "Narration";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 116);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(290, 49);
		this.layoutControlItem5.Text = "Narration";
		this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem5.TextSize = new System.Drawing.Size(59, 18);
		this.layoutControlItem6.Control = this.lblVote;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(290, 17);
		this.layoutControlItem6.Text = "layoutControlItem6";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextToControlDistance = 0;
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem7.Control = this.lblSubVote;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 17);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(290, 22);
		this.layoutControlItem7.Text = "layoutControlItem7";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextToControlDistance = 0;
		this.layoutControlItem7.TextVisible = false;
		this.layoutControlItem8.Control = this.labelControl1;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 39);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(290, 17);
		this.layoutControlItem8.Text = "layoutControlItem8";
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextToControlDistance = 0;
		this.layoutControlItem8.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(295, 208);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "QtyAmount";
		base.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Expense Details";
		base.Load += new System.EventHandler(QtyAmount_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(QtyAmount_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.textEdit3.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		base.ResumeLayout(false);
	}
}
