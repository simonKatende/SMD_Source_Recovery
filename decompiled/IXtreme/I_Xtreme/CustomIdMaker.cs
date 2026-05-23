using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace I_Xtreme;

public class CustomIdMaker : XtraForm
{
	private IContainer components = null;

	private CheckedListBoxControl checkedListBoxControl1;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private DateEdit dateEdit1;

	private DateEdit dateEdit2;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private ComboBoxEdit comboBoxEdit1;

	public CustomIdMaker()
	{
		InitializeComponent();
	}

	private void LoadEmployeeList(string classId)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT fullName AS Name, StudentNumber AS StudNo FROM tbl_Stud WHERE ClassId='{classId}'", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StaffList");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			checkedListBoxControl1.Items.Clear();
			foreach (DataRow row in dataTable.Rows)
			{
				checkedListBoxControl1.Items.Add(string.Format("{0}${1}", row["Name"], row["StudNo"]));
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void CreateIds(DateTime issueDate, DateTime validityDate)
	{
		foreach (CheckedListBoxItem item in (IEnumerable)checkedListBoxControl1.CheckedItems)
		{
			string text = item.ToString().Trim();
			int num = text.IndexOf('$') + 1;
			string value = text.Substring(num, text.Length - num);
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_StudentIds (StudentNumber,IssueYear,IssueDate,Validity) VALUES (@StudentNumber,@IssueYear,@IssueDate,@Validity)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter.Value = value;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@IssueYear", SqlDbType.Int);
			sqlParameter.Value = issueDate.Year;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@IssueDate", SqlDbType.DateTime);
			sqlParameter.Value = issueDate.ToShortDateString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Validity", SqlDbType.DateTime);
			sqlParameter.Value = validityDate.ToShortDateString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
		}
		XtraMessageBox.Show("Success");
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		WaitDialogForm waitDialogForm = new WaitDialogForm();
		waitDialogForm.Caption = "Creating IDs. Please wait";
		CreateIds(dateEdit1.DateTime, dateEdit2.DateTime);
		waitDialogForm.Close();
	}

	private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
	{
		LoadEmployeeList(comboBoxEdit1.SelectedItem.ToString());
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
		this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
		this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
		((System.ComponentModel.ISupportInitialize)this.checkedListBoxControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties.VistaTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit2.Properties.VistaTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).BeginInit();
		base.SuspendLayout();
		this.checkedListBoxControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.checkedListBoxControl1.Location = new System.Drawing.Point(2, 35);
		this.checkedListBoxControl1.Name = "checkedListBoxControl1";
		this.checkedListBoxControl1.Size = new System.Drawing.Size(522, 397);
		this.checkedListBoxControl1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
		this.checkedListBoxControl1.TabIndex = 0;
		this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton1.Location = new System.Drawing.Point(449, 438);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(75, 23);
		this.simpleButton1.TabIndex = 1;
		this.simpleButton1.Text = "Cancel";
		this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.simpleButton2.Location = new System.Drawing.Point(2, 438);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(75, 23);
		this.simpleButton2.TabIndex = 2;
		this.simpleButton2.Text = "Create";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.dateEdit1.EditValue = null;
		this.dateEdit1.Location = new System.Drawing.Point(59, 13);
		this.dateEdit1.Name = "dateEdit1";
		this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dateEdit1.Size = new System.Drawing.Size(100, 20);
		this.dateEdit1.TabIndex = 3;
		this.dateEdit2.EditValue = null;
		this.dateEdit2.Location = new System.Drawing.Point(226, 13);
		this.dateEdit2.Name = "dateEdit2";
		this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dateEdit2.Size = new System.Drawing.Size(100, 20);
		this.dateEdit2.TabIndex = 4;
		this.labelControl1.Location = new System.Drawing.Point(2, 16);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(51, 13);
		this.labelControl1.TabIndex = 5;
		this.labelControl1.Text = "Issue date";
		this.labelControl2.Location = new System.Drawing.Point(165, 16);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(55, 13);
		this.labelControl2.TabIndex = 6;
		this.labelControl2.Text = "Expiry date";
		this.comboBoxEdit1.Location = new System.Drawing.Point(360, 12);
		this.comboBoxEdit1.Name = "comboBoxEdit1";
		this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.comboBoxEdit1.Properties.Items.AddRange(new object[6] { "S.1", "S.2", "S.3", "S.4", "S.5", "S.6" });
		this.comboBoxEdit1.Size = new System.Drawing.Size(153, 20);
		this.comboBoxEdit1.TabIndex = 7;
		this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(comboBoxEdit1_SelectedIndexChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(525, 463);
		base.Controls.Add(this.comboBoxEdit1);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.dateEdit2);
		base.Controls.Add(this.dateEdit1);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.checkedListBoxControl1);
		base.Name = "CustomIdMaker";
		this.Text = "CustomIdMaker";
		((System.ComponentModel.ISupportInitialize)this.checkedListBoxControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties.VistaTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit2.Properties.VistaTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
