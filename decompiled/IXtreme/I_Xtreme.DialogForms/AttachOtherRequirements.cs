using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class AttachOtherRequirements : XtraForm
{
	private string conString = "";

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private ComboBoxEdit cboStudyStatus;

	private ComboBoxEdit cboClass;

	private MemoEdit txtOtherReq;

	private LayoutControlGroup Root;

	private LayoutControlItem layoutControlItem1;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private ComboBoxEdit cboStream;

	private LayoutControlItem layoutControlItem7;

	private TextEdit cboTerm;

	public AttachOtherRequirements()
	{
		InitializeComponent();
		Classes.LoadComboWithClasses(new ComboBoxEdit[1] { cboClass });
		cboTerm.Text = WorkingSemesters.GetWorkingSemester();
	}

	private void cboClass_EditValueChanged(object sender, EventArgs e)
	{
		Stream.LoadStreams(cboClass.Text, cboStream);
		cboStream.Properties.Items.Add("All Streams");
		cboStream.Properties.Sorted = true;
		cboStream.SelectedIndex = 1;
	}

	private void GetStudentsForRequirements()
	{
		try
		{
			Application.DoEvents();
			simpleButton1.Text = "Please wait...";
			simpleButton1.Enabled = false;
			string text = cboClass.Text;
			string text2 = "";
			switch (text)
			{
			default:
				if (!(text == "S.4"))
				{
					XtraMessageBox.Show("This class is not supported now", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Application.DoEvents();
					simpleButton1.Text = "Append Requirements";
					simpleButton1.Enabled = true;
					break;
				}
				goto case "S.1";
			case "S.1":
			case "S.2":
			case "S.3":
			{
				text2 = "UPDATE tbl_Scores_OL_Report SET OtherRequirements=@OtherRequirements WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId";
				conString = DataConnection.ConnectToDatabase();
				string text3 = "";
				text3 = ((cboStudyStatus.SelectedItem.ToString() == "All" && cboStream.SelectedItem.ToString() == "All Streams") ? $"SELECT fullName,StudentNumber FROM tbl_Stud WHERE ClassId = '{cboClass.Text}'" : ((cboStudyStatus.SelectedItem.ToString() != "All" && cboStream.SelectedItem.ToString() == "All Streams") ? $"SELECT fullName,StudentNumber FROM tbl_Stud WHERE ClassId = '{cboClass.Text}' AND StudyStatus = '{cboStudyStatus.Text}'" : ((!(cboStudyStatus.SelectedItem.ToString() == "All") || !(cboStream.SelectedItem.ToString() != "All Streams")) ? $"SELECT fullName,StudentNumber FROM tbl_Stud WHERE ClassId='{cboClass.Text}' AND StreamId='{cboStream.Text}' AND StudyStatus='{cboStudyStatus.Text}'" : $"SELECT fullName,StudentNumber FROM tbl_Stud WHERE ClassId = '{cboClass.Text}' AND StreamId = '{cboStream.Text}'")));
				using (SqlConnection sqlConnection = new SqlConnection(conString))
				{
					sqlConnection.Open();
					using SqlCommand sqlCommand = new SqlCommand(text3, sqlConnection);
					using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						using SqlConnection sqlConnection2 = new SqlConnection(conString);
						sqlConnection2.Open();
						using SqlCommand sqlCommand2 = new SqlCommand
						{
							Connection = sqlConnection2,
							CommandText = text2,
							CommandType = CommandType.Text
						};
						SqlParameter sqlParameter = sqlCommand2.Parameters.AddWithValue("@OtherRequirements", txtOtherReq.Text);
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.AddWithValue("@StudentNumber", sqlDataReader["StudentNumber"]);
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.AddWithValue("@SemesterId", cboTerm.Text);
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
					}
				}
				XtraMessageBox.Show("All processes completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				Application.DoEvents();
				simpleButton1.Text = "Append Requirements";
				simpleButton1.Enabled = true;
				break;
			}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Application.DoEvents();
			simpleButton1.Text = "Append Requirements";
			simpleButton1.Enabled = true;
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		GetStudentsForRequirements();
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
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.cboClass = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.cboStudyStatus = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.txtOtherReq = new DevExpress.XtraEditors.MemoEdit();
		this.cboStream = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.cboTerm = new DevExpress.XtraEditors.TextEdit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboStudyStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtOtherReq.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboTerm.Properties).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.cboStream);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.cboStudyStatus);
		this.layoutControl1.Controls.Add(this.cboClass);
		this.layoutControl1.Controls.Add(this.txtOtherReq);
		this.layoutControl1.Controls.Add(this.cboTerm);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(310, 181);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[8] { this.layoutControlItem1, this.emptySpaceItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.Root.Size = new System.Drawing.Size(310, 181);
		this.Root.TextVisible = false;
		this.layoutControlItem1.Control = this.cboTerm;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(306, 24);
		this.layoutControlItem1.Text = "Term";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(65, 13);
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 131);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(306, 20);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.cboClass.Location = new System.Drawing.Point(81, 28);
		this.cboClass.Name = "cboClass";
		this.cboClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboClass.Size = new System.Drawing.Size(225, 20);
		this.cboClass.StyleController = this.layoutControl1;
		this.cboClass.TabIndex = 5;
		this.cboClass.EditValueChanged += new System.EventHandler(cboClass_EditValueChanged);
		this.layoutControlItem2.Control = this.cboClass;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(306, 24);
		this.layoutControlItem2.Text = "Class";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(65, 13);
		this.cboStudyStatus.EditValue = "All";
		this.cboStudyStatus.Location = new System.Drawing.Point(81, 76);
		this.cboStudyStatus.Name = "cboStudyStatus";
		this.cboStudyStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboStudyStatus.Properties.Items.AddRange(new object[3] { "All", "B", "D" });
		this.cboStudyStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboStudyStatus.Size = new System.Drawing.Size(225, 20);
		this.cboStudyStatus.StyleController = this.layoutControl1;
		this.cboStudyStatus.TabIndex = 6;
		this.layoutControlItem3.Control = this.cboStudyStatus;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(306, 24);
		this.layoutControlItem3.Text = "Study Status";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(65, 13);
		this.simpleButton1.Location = new System.Drawing.Point(4, 155);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(149, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 7;
		this.simpleButton1.Text = "Attach Requirements";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.layoutControlItem4.Control = this.simpleButton1;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 151);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(153, 26);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(157, 155);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(149, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 8;
		this.simpleButton2.Text = "Close";
		this.layoutControlItem5.Control = this.simpleButton2;
		this.layoutControlItem5.Location = new System.Drawing.Point(153, 151);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(153, 26);
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem6.Control = this.txtOtherReq;
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 96);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(306, 35);
		this.layoutControlItem6.Text = "Requirements";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(65, 13);
		this.txtOtherReq.Location = new System.Drawing.Point(81, 100);
		this.txtOtherReq.Name = "txtOtherReq";
		this.txtOtherReq.Properties.MaxLength = 80;
		this.txtOtherReq.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtOtherReq.Size = new System.Drawing.Size(225, 31);
		this.txtOtherReq.StyleController = this.layoutControl1;
		this.txtOtherReq.TabIndex = 9;
		this.cboStream.Location = new System.Drawing.Point(81, 52);
		this.cboStream.Name = "cboStream";
		this.cboStream.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboStream.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboStream.Size = new System.Drawing.Size(225, 20);
		this.cboStream.StyleController = this.layoutControl1;
		this.cboStream.TabIndex = 10;
		this.layoutControlItem7.Control = this.cboStream;
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(306, 24);
		this.layoutControlItem7.Text = "Stream";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(65, 13);
		this.cboTerm.Location = new System.Drawing.Point(81, 4);
		this.cboTerm.Name = "cboTerm";
		this.cboTerm.Properties.ReadOnly = true;
		this.cboTerm.Size = new System.Drawing.Size(225, 20);
		this.cboTerm.StyleController = this.layoutControl1;
		this.cboTerm.TabIndex = 4;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(310, 181);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "AttachOtherRequirements";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Attach Next Term Requirements";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboStudyStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtOtherReq.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboTerm.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
