using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace MarksEntry;

public class ImportScores : XtraForm
{
	private IContainer components = null;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private GroupControl groupControl1;

	private SimpleButton simpleButton12;

	private LabelControl labelControl10;

	private ListBoxControl listBoxControl1;

	private Timer timer1;

	public TextEdit txtSource;

	public ImportScores()
	{
		InitializeComponent();
	}

	private void LoadDataHeaders()
	{
		string connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={ImportScoresFromExcel.ExcelFilePath};Extended Properties=Excel 8.0";
		using OleDbConnection selectConnection = new OleDbConnection(connectionString);
		using OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter("select * from [ScoreSheet$]", selectConnection);
		using DataSet dataSet = new DataSet();
		oleDbDataAdapter.Fill(dataSet, "scoreSheet");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		listBoxControl1.Items.Clear();
		foreach (DataColumn column in dataTable.Columns)
		{
			listBoxControl1.Items.Add(column.Caption);
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Title = "Open excel file",
			RestoreDirectory = true,
			Filter = "Excel 97-2003 (*.xls) Work book|*.xls"
		};
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		string commandText = $"SELECT * FROM tbl_filesExported WHERE fileName='{openFileDialog.SafeFileName}'";
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = commandText,
			CommandType = CommandType.Text
		};
		using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		if (sqlDataReader.HasRows)
		{
			txtSource.Text = openFileDialog.SafeFileName;
			ImportScoresFromExcel.SaveExcelPath(openFileDialog.FileName);
			LoadDataHeaders();
		}
		else
		{
			XtraMessageBox.Show("Sorry, we can't do that. Only files Exported from this system can be imported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton12_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (listBoxControl1.Items.Count > 0)
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
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtSource = new DevExpress.XtraEditors.TextEdit();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
		this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
		this.simpleButton12 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
		this.timer1 = new System.Windows.Forms.Timer();
		((System.ComponentModel.ISupportInitialize)this.txtSource.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).BeginInit();
		this.groupControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.listBoxControl1).BeginInit();
		base.SuspendLayout();
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(4, 327);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(163, 23);
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "Continue";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.txtSource.Location = new System.Drawing.Point(3, 69);
		this.txtSource.Name = "txtSource";
		this.txtSource.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtSource.Properties.NullText = "Browse for excel data source";
		this.txtSource.Properties.NullValuePrompt = "Browse for excel data source";
		this.txtSource.Properties.ReadOnly = true;
		this.txtSource.Size = new System.Drawing.Size(281, 22);
		this.txtSource.TabIndex = 3;
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.Location = new System.Drawing.Point(290, 70);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(45, 21);
		this.simpleButton2.TabIndex = 4;
		this.simpleButton2.Text = "Browse";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.groupControl1.Controls.Add(this.listBoxControl1);
		this.groupControl1.Location = new System.Drawing.Point(1, 95);
		this.groupControl1.Name = "groupControl1";
		this.groupControl1.Size = new System.Drawing.Size(334, 227);
		this.groupControl1.TabIndex = 6;
		this.groupControl1.Text = "Source columns";
		this.listBoxControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.listBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.listBoxControl1.Location = new System.Drawing.Point(2, 21);
		this.listBoxControl1.Name = "listBoxControl1";
		this.listBoxControl1.Size = new System.Drawing.Size(330, 204);
		this.listBoxControl1.TabIndex = 0;
		this.simpleButton12.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton12.Location = new System.Drawing.Point(170, 327);
		this.simpleButton12.Name = "simpleButton12";
		this.simpleButton12.Size = new System.Drawing.Size(163, 23);
		this.simpleButton12.TabIndex = 34;
		this.simpleButton12.Text = "Close";
		this.simpleButton12.Click += new System.EventHandler(simpleButton12_Click);
		this.labelControl10.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		this.labelControl10.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.labelControl10.Location = new System.Drawing.Point(0, 2);
		this.labelControl10.Name = "labelControl10";
		this.labelControl10.Padding = new System.Windows.Forms.Padding(3);
		this.labelControl10.Size = new System.Drawing.Size(335, 58);
		this.labelControl10.TabIndex = 44;
		this.labelControl10.Text = "NOTE:\r\nIf you altered the file name after exporting it, importing will not work\r\nImport sheets matching with Logged in Semester, Class and Subject\r\nSource sheets should be of excel 97-2003 format\r\n";
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(339, 354);
		base.Controls.Add(this.labelControl10);
		base.Controls.Add(this.simpleButton12);
		base.Controls.Add(this.groupControl1);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.txtSource);
		base.Controls.Add(this.simpleButton1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "ImportScores";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Import Scores";
		((System.ComponentModel.ISupportInitialize)this.txtSource.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).EndInit();
		this.groupControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.listBoxControl1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
