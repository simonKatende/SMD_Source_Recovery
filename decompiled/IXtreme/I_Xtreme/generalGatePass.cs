using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;

namespace I_Xtreme;

public class generalGatePass : XtraForm
{
	public string streamId = string.Empty;

	public string db = string.Empty;

	public string guardian = string.Empty;

	public string sex = string.Empty;

	private string ClassId = string.Empty;

	private IContainer components = null;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private LabelControl labelControl3;

	private LabelControl labelControl5;

	private DateEdit dtReturnDate;

	private TextEdit txtDestination;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private LabelControl labelControl4;

	public LabelControl lblNames;

	public LabelControl lblStudentNo;

	public LabelControl lblCurrentUsers;

	public LabelControl lblSemester;

	private DXValidationProvider dxValidationProvider1;

	private TimeEdit dtRDate;

	public PictureEdit pictureEdit1;

	private LabelControl labelControl6;

	public generalGatePass(string ClassId)
	{
		InitializeComponent();
		this.ClassId = ClassId;
	}

	private void CreateStudentGatePass()
	{
		Image image = pictureEdit1.Image;
		int num = image.Height;
		int num2 = image.Width;
		num = num * 220 / num2;
		num2 = 220;
		if (num > 250)
		{
			num2 = num2 * 250 / num;
			num = 250;
		}
		Bitmap bitmap = new Bitmap(image, num2, num);
		MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, ImageFormat.Png);
		memoryStream.Position = 0L;
		byte[] array = new byte[memoryStream.Length + 1];
		memoryStream.Read(array, 0, array.Length);
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "INSERT INTO tbl_GatePass (StudentNumber,Name,Class,Stream,DB,Guardian,CreatedBy,SemesterId,CreateDate,PassType,pic,Sex,Destination,ReturnDate,ReturnTime) VALUES (@StudentNumber,@Name,@Class,@Stream,@DB,@Guardian,@CreatedBy,@SemesterId,@CreateDate,@PassType,@pic,@Sex,@Destination,@ReturnDate,@ReturnTime)",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter.Value = lblStudentNo.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50);
			sqlParameter.Value = lblNames.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Class", SqlDbType.VarChar, 3);
			sqlParameter.Value = ClassId;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Stream", SqlDbType.VarChar, 50);
			sqlParameter.Value = streamId;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@DB", SqlDbType.VarChar, 1);
			sqlParameter.Value = db;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Guardian", SqlDbType.VarChar, 50);
			sqlParameter.Value = guardian;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 30);
			sqlParameter.Value = CurrentUser.GetSystemUser();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 30);
			sqlParameter.Value = WorkingSemesters.GetWorkingSemester();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@CreateDate", SqlDbType.DateTime);
			sqlParameter.Value = DateTime.Now.ToLongDateString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@PassType", SqlDbType.VarChar, 50);
			sqlParameter.Value = "Student Gatepass";
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Pic", SqlDbType.Image);
			sqlParameter.Value = array;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Sex", SqlDbType.VarChar, 1);
			sqlParameter.Value = sex;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Destination", SqlDbType.VarChar, 50);
			sqlParameter.Value = txtDestination.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@ReturnDate", SqlDbType.DateTime);
			sqlParameter.Value = dtReturnDate.DateTime.ToShortDateString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@ReturnTime", SqlDbType.DateTime);
			sqlParameter.Value = dtRDate.Time.ToShortTimeString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
		}
		sqlConnection.Close();
	}

	private static void ShowGeneralGatePass()
	{
		try
		{
			int num = 0;
			using (SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT MAX (passNo) AS PassNumber FROM tbl_GatePass", selectConnection);
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "GatePass");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					num = Convert.ToInt32(row["PassNumber"].ToString());
				}
			}
			using gatePass_General gatePass_General2 = new gatePass_General();
			gatePass_General2.PassNos3.Value = num;
			gatePass_General2.PassNos3.Visible = false;
			ReportPrintTool reportPrintTool = new ReportPrintTool(gatePass_General2);
			reportPrintTool.ShowRibbonPreviewDialog();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (dtReturnDate.Text != string.Empty || txtDestination.Text != string.Empty)
		{
			CreateStudentGatePass();
			ShowGeneralGatePass();
			Close();
		}
		else
		{
			dxValidationProvider1.Validate();
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		Close();
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
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
		this.dtReturnDate = new DevExpress.XtraEditors.DateEdit();
		this.txtDestination = new DevExpress.XtraEditors.TextEdit();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.lblNames = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentNo = new DevExpress.XtraEditors.LabelControl();
		this.lblCurrentUsers = new DevExpress.XtraEditors.LabelControl();
		this.lblSemester = new DevExpress.XtraEditors.LabelControl();
		this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		this.dtRDate = new DevExpress.XtraEditors.TimeEdit();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.dtReturnDate.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtReturnDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDestination.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtRDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		base.SuspendLayout();
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl1.Location = new System.Drawing.Point(116, 10);
		this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(38, 16);
		this.labelControl1.TabIndex = 0;
		this.labelControl1.Text = "Name:";
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl2.Location = new System.Drawing.Point(23, 147);
		this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(73, 16);
		this.labelControl2.TabIndex = 1;
		this.labelControl2.Text = "Return Date:";
		this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl3.Location = new System.Drawing.Point(20, 175);
		this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(76, 16);
		this.labelControl3.TabIndex = 2;
		this.labelControl3.Text = "Return Time:";
		this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl5.Location = new System.Drawing.Point(28, 203);
		this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.labelControl5.Name = "labelControl5";
		this.labelControl5.Size = new System.Drawing.Size(68, 16);
		this.labelControl5.TabIndex = 4;
		this.labelControl5.Text = "Destination:";
		this.dtReturnDate.EditValue = null;
		this.dtReturnDate.Location = new System.Drawing.Point(106, 139);
		this.dtReturnDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.dtReturnDate.Name = "dtReturnDate";
		this.dtReturnDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.dtReturnDate.Properties.Appearance.Options.UseFont = true;
		this.dtReturnDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.dtReturnDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtReturnDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtReturnDate.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtReturnDate.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtReturnDate.Size = new System.Drawing.Size(323, 24);
		this.dtReturnDate.TabIndex = 5;
		conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsBlank;
		conditionValidationRule.ErrorText = "Return date required";
		this.dxValidationProvider1.SetValidationRule(this.dtReturnDate, conditionValidationRule);
		this.txtDestination.Location = new System.Drawing.Point(106, 195);
		this.txtDestination.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.txtDestination.Name = "txtDestination";
		this.txtDestination.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtDestination.Properties.Appearance.Options.UseFont = true;
		this.txtDestination.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtDestination.Size = new System.Drawing.Size(323, 24);
		this.txtDestination.TabIndex = 7;
		conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsBlank;
		conditionValidationRule2.ErrorText = "Destination is required";
		this.dxValidationProvider1.SetValidationRule(this.txtDestination, conditionValidationRule2);
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(106, 223);
		this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(148, 28);
		this.simpleButton1.TabIndex = 8;
		this.simpleButton1.Text = "Create";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.Location = new System.Drawing.Point(281, 223);
		this.simpleButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(148, 28);
		this.simpleButton2.TabIndex = 9;
		this.simpleButton2.Text = "Cancel";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl4.Location = new System.Drawing.Point(116, 56);
		this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(68, 16);
		this.labelControl4.TabIndex = 10;
		this.labelControl4.Text = "Student No:";
		this.lblNames.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblNames.Location = new System.Drawing.Point(116, 33);
		this.lblNames.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.lblNames.Name = "lblNames";
		this.lblNames.Size = new System.Drawing.Size(0, 19);
		this.lblNames.TabIndex = 11;
		this.lblStudentNo.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStudentNo.Location = new System.Drawing.Point(116, 83);
		this.lblStudentNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.lblStudentNo.Name = "lblStudentNo";
		this.lblStudentNo.Size = new System.Drawing.Size(0, 19);
		this.lblStudentNo.TabIndex = 12;
		this.lblCurrentUsers.Location = new System.Drawing.Point(255, 170);
		this.lblCurrentUsers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.lblCurrentUsers.Name = "lblCurrentUsers";
		this.lblCurrentUsers.Size = new System.Drawing.Size(22, 13);
		this.lblCurrentUsers.TabIndex = 14;
		this.lblCurrentUsers.Text = "User";
		this.lblCurrentUsers.Visible = false;
		this.lblSemester.Location = new System.Drawing.Point(14, 225);
		this.lblSemester.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.lblSemester.Name = "lblSemester";
		this.lblSemester.Size = new System.Drawing.Size(45, 13);
		this.lblSemester.TabIndex = 15;
		this.lblSemester.Text = "Semester";
		this.lblSemester.Visible = false;
		this.dtRDate.EditValue = new System.DateTime(2013, 1, 6, 16, 30, 0, 0);
		this.dtRDate.Location = new System.Drawing.Point(106, 167);
		this.dtRDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.dtRDate.Name = "dtRDate";
		this.dtRDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.dtRDate.Properties.Appearance.Options.UseFont = true;
		this.dtRDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.dtRDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtRDate.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtRDate.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtRDate.Size = new System.Drawing.Size(132, 24);
		this.dtRDate.TabIndex = 16;
		this.pictureEdit1.Location = new System.Drawing.Point(7, 3);
		this.pictureEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(89, 104);
		this.pictureEdit1.TabIndex = 17;
		this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl6.Visible = true;
		this.labelControl6.Location = new System.Drawing.Point(7, 114);
		this.labelControl6.Name = "labelControl6";
		this.labelControl6.Size = new System.Drawing.Size(424, 17);
		this.labelControl6.TabIndex = 18;
		base.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Appearance.Options.UseFont = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(437, 263);
		base.Controls.Add(this.labelControl6);
		base.Controls.Add(this.pictureEdit1);
		base.Controls.Add(this.dtRDate);
		base.Controls.Add(this.lblSemester);
		base.Controls.Add(this.lblCurrentUsers);
		base.Controls.Add(this.lblStudentNo);
		base.Controls.Add(this.lblNames);
		base.Controls.Add(this.labelControl4);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.txtDestination);
		base.Controls.Add(this.dtReturnDate);
		base.Controls.Add(this.labelControl5);
		base.Controls.Add(this.labelControl3);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.Name = "generalGatePass";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Create Gate Pass";
		((System.ComponentModel.ISupportInitialize)this.dtReturnDate.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtReturnDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDestination.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtRDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
