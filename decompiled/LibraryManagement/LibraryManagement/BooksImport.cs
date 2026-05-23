using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraWizard;
using LibraryManagement.Properties;
using Microsoft.Office.Interop.Excel;

namespace LibraryManagement;

public class BooksImport : XtraForm
{
	private int k = 0;

	private Workbook workBook;

	public StartOrStopTimer StartTimer;

	private IContainer components = null;

	private WizardControl wizardControl1;

	private WelcomeWizardPage welcomeWizardPage1;

	private DevExpress.XtraWizard.WizardPage wizardPage1;

	private CompletionWizardPage completionWizardPage1;

	private SimpleButton simpleButton2;

	private TextEdit txtSource;

	private LabelControl labelControl1;

	private LabelControl labelControl10;

	private DevExpress.XtraWizard.WizardPage wizardPage2;

	private LayoutControl layoutControl1;

	private GridControl gridControl1;

	private GridView gridView1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private ListBoxControl listBoxControl1;

	private LayoutControlItem layoutControlItem2;

	private System.Windows.Forms.Timer timer1;

	private LabelControl labelControl6;

	private LabelControl labelControl2;

	private DevExpress.XtraWizard.WizardPage wizardPage4;

	private ProgressBarControl progressBarStudents;

	private LabelControl lblCurrentStudent;

	private DevExpress.XtraWizard.WizardPage wizardPage5;

	private GridControl gridControl2;

	private GridView gridView2;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private RepositoryItemPictureEdit repositoryItemPictureEdit1;

	private GridColumn gridColumn3;

	private RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;

	private LabelControl lblDescriptionStatus;

	private CheckEdit checkEdit1;

	public BooksImport()
	{
		InitializeComponent();
	}

	private void SetWizardPageButtons(bool buttonState)
	{
		wizardPage4.AllowNext = buttonState;
		wizardPage4.AllowBack = buttonState;
	}

	private void InsertToSql()
	{
		SetWizardPageButtons(buttonState: false);
		k = 0;
		progressBarStudents.Position = 0;
		string connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={txtSource.Text};Extended Properties=Excel 8.0";
		using OleDbConnection selectConnection = new OleDbConnection(connectionString);
		using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter($"select * from [{listBoxControl1.SelectedItem.ToString()}$]", selectConnection))
		{
			using DataSet dataSet = new DataSet();
			oleDbDataAdapter.Fill(dataSet, "scoreSheet");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			progressBarStudents.Properties.Maximum = dataTable.Rows.Count;
			foreach (DataRow row in dataTable.Rows)
			{
				System.Windows.Forms.Application.DoEvents();
				lblCurrentStudent.Text = "Importing data...";
				double result = (double.TryParse(row["COST"].ToString(), out result) ? result : 0.0);
				int result2 = (int.TryParse(row["PUBLICATIONYEAR"].ToString(), out result2) ? result2 : 0);
				long result3 = (long.TryParse(row["CATEGORY"].ToString(), out result3) ? result3 : 0);
				long result4 = (long.TryParse(row["LOCATIONINLIBRARY"].ToString(), out result4) ? result4 : 0);
				using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = "INSERT INTO tbl_Books (CatID,Title,Ref,Author,YearOfPublication,Publisher,MonitaryValue,LocID,LocalCode) VALUES (@CatID,@Title,@Ref,@Author,@YearOfPublication,@Publisher,@MonitaryValue,@LocID,@LocalCode)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter = sqlCommand.Parameters.Add("@CatID", SqlDbType.BigInt);
						sqlParameter.Value = result3;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Title", SqlDbType.VarChar, 100);
						sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(row["Title"].ToString().ToLower());
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Ref", SqlDbType.VarChar, 50);
						sqlParameter.Value = row["ISBN"].ToString().ToUpper();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Author", SqlDbType.VarChar, 100);
						sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(row["Author"].ToString().ToLower());
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@YearOfPublication", SqlDbType.Int);
						sqlParameter.Value = result2;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Publisher", SqlDbType.VarChar, 50);
						sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(row["Publisher"].ToString().ToLower());
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@MonitaryValue", SqlDbType.Money);
						sqlParameter.Value = result;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@LocID", SqlDbType.BigInt);
						sqlParameter.Value = result4;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@LocalCode", SqlDbType.VarChar, 9);
						sqlParameter.Value = LocalCode.GetNextBookNumber();
						sqlParameter.Direction = ParameterDirection.Input;
						if (sqlCommand.ExecuteNonQuery() > 0)
						{
							sqlConnection.Close();
						}
					}
					System.Windows.Forms.Application.DoEvents();
					k++;
					progressBarStudents.Position = k;
				}
				if (k == dataTable.Rows.Count)
				{
					lblCurrentStudent.Text = "Data Import Successful.";
					StartTimer(timerStatus: true);
				}
			}
		}
		SetWizardPageButtons(buttonState: true);
	}

	public void GetSheetsNames(string path)
	{
		Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
		workBook = application.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
		listBoxControl1.Items.Clear();
		foreach (Worksheet worksheet in workBook.Worksheets)
		{
			listBoxControl1.Items.Add(worksheet.Name.ToString());
		}
	}

	private void LoadDataHeaders()
	{
		try
		{
			string connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={txtSource.Text};Extended Properties=Excel 8.0";
			using OleDbConnection selectConnection = new OleDbConnection(connectionString);
			using OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter($"select * from [{listBoxControl1.SelectedItem.ToString()}$]", selectConnection);
			using DataSet dataSet = new DataSet();
			oleDbDataAdapter.Fill(dataSet, "scoreSheet");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			gridControl1.DataSource = dataTable.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Title = "Open excel file",
			RestoreDirectory = true,
			Filter = "Excel Workbook (*.Xlsx)|*.Xlsx|Excel Workbook 2003 (*.xls)|*.xls|All files (*.*)|*.*"
		};
		if (openFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(openFileDialog.FileName))
		{
			txtSource.Text = openFileDialog.FileName;
			GetSheetsNames(openFileDialog.FileName);
		}
	}

	private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
	{
		LoadDataHeaders();
		ValidateColumns();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (wizardControl1.SelectedPage == wizardPage1 && !string.IsNullOrEmpty(txtSource.Text))
		{
			wizardPage1.AllowNext = true;
		}
		else if (wizardControl1.SelectedPage == wizardPage1 && string.IsNullOrEmpty(txtSource.Text))
		{
			wizardPage1.AllowNext = false;
		}
		else if (wizardControl1.SelectedPage == wizardPage5 && lblDescriptionStatus.Text.Contains("invalid"))
		{
			wizardPage5.AllowNext = false;
		}
		else if (wizardControl1.SelectedPage == wizardPage5 && lblDescriptionStatus.Text.Contains("Good"))
		{
			wizardPage5.AllowNext = true;
		}
	}

	private void wizardPage2_Validating(object sender, CancelEventArgs e)
	{
		if (listBoxControl1.ItemCount == 1)
		{
			e.Cancel = false;
		}
	}

	private void ValidateColumns()
	{
		bool flag = false;
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("ColumnName", typeof(string));
		dataTable.Columns.Add("Status", typeof(Image));
		dataTable.Columns.Add("Description", typeof(string));
		if (gridView1.Columns.Contains(gridView1.Columns["CATEGORY"]))
		{
			dataTable.Rows.Add("CATEGORY", Resources.columnOK, "OK");
		}
		else
		{
			flag = true;
			dataTable.Rows.Add("CATEGORY", Resources.columnNone, "Column Not Found");
		}
		if (gridView1.Columns.Contains(gridView1.Columns["ISBN"]))
		{
			dataTable.Rows.Add("ISBN", Resources.columnOK, "OK");
		}
		else
		{
			flag = true;
			dataTable.Rows.Add("ISBN", Resources.columnNone, "Column Not Found");
		}
		if (gridView1.Columns.Contains(gridView1.Columns["AUTHOR"]))
		{
			dataTable.Rows.Add("AUTHOR", Resources.columnOK, "OK");
		}
		else
		{
			flag = true;
			dataTable.Rows.Add("AUTHOR", Resources.columnNone, "Column Not Found");
		}
		if (gridView1.Columns.Contains(gridView1.Columns["PUBLISHER"]))
		{
			dataTable.Rows.Add("PUBLISHER", Resources.columnOK, "OK");
		}
		else
		{
			flag = true;
			dataTable.Rows.Add("PUBLISHER", Resources.columnNone, "Column Not Found");
		}
		if (gridView1.Columns.Contains(gridView1.Columns["PUBLICATIONYEAR"]))
		{
			dataTable.Rows.Add("PUBLICATIONYEAR", Resources.columnOK, "OK");
		}
		else
		{
			flag = true;
			dataTable.Rows.Add("PUBLICATIONYEAR", Resources.columnNone, "Column Not Found");
		}
		if (gridView1.Columns.Contains(gridView1.Columns["LOCATIONINLIBRARY"]))
		{
			dataTable.Rows.Add("LOCATIONINLIBRARY", Resources.columnOK, "OK");
		}
		else
		{
			flag = true;
			dataTable.Rows.Add("LOCATIONINLIBRARY", Resources.columnNone, "Column Not Found");
		}
		if (gridView1.Columns.Contains(gridView1.Columns["COST"]))
		{
			dataTable.Rows.Add("COST", Resources.columnOK, "OK");
		}
		else
		{
			flag = true;
			dataTable.Rows.Add("COST", Resources.columnNone, "Column Not Found");
		}
		gridControl2.DataSource = dataTable.DefaultView;
		if (flag)
		{
			lblDescriptionStatus.Text = "Your spreadsheet contains invalid columns or invalid data entries.\nRead the error descriptions above and edit your spreadsheet accordingly.";
		}
		else
		{
			lblDescriptionStatus.Text = "Everything seems fine! You are Good To Go.";
		}
	}

	private void wizardPage5_PageCommit(object sender, EventArgs e)
	{
		InsertToSql();
	}

	private void StudentImport_FormClosed(object sender, FormClosedEventArgs e)
	{
		try
		{
			if (txtSource.Text != string.Empty)
			{
				workBook.Close(Type.Missing, Type.Missing, Type.Missing);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
	{
		try
		{
			if (checkEdit1.Checked)
			{
				Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Import_Log.html");
			}
		}
		catch (FileNotFoundException ex)
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
		this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
		this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
		this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
		this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.txtSource = new DevExpress.XtraEditors.TextEdit();
		this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
		this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
		this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.wizardPage4 = new DevExpress.XtraWizard.WizardPage();
		this.lblCurrentStudent = new DevExpress.XtraEditors.LabelControl();
		this.progressBarStudents = new DevExpress.XtraEditors.ProgressBarControl();
		this.wizardPage5 = new DevExpress.XtraWizard.WizardPage();
		this.lblDescriptionStatus = new DevExpress.XtraEditors.LabelControl();
		this.gridControl2 = new DevExpress.XtraGrid.GridControl();
		this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.wizardControl1).BeginInit();
		this.wizardControl1.SuspendLayout();
		this.wizardPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtSource.Properties).BeginInit();
		this.completionWizardPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.checkEdit1.Properties).BeginInit();
		this.wizardPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.listBoxControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		this.wizardPage4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.progressBarStudents.Properties).BeginInit();
		this.wizardPage5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemPictureEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemHyperLinkEdit1).BeginInit();
		base.SuspendLayout();
		this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
		this.wizardControl1.Controls.Add(this.wizardPage1);
		this.wizardControl1.Controls.Add(this.completionWizardPage1);
		this.wizardControl1.Controls.Add(this.wizardPage2);
		this.wizardControl1.Controls.Add(this.wizardPage4);
		this.wizardControl1.Controls.Add(this.wizardPage5);
		this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.wizardControl1.Location = new System.Drawing.Point(0, 0);
		this.wizardControl1.Name = "wizardControl1";
		this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[6] { this.welcomeWizardPage1, this.wizardPage1, this.wizardPage2, this.wizardPage5, this.wizardPage4, this.completionWizardPage1 });
		this.wizardControl1.Size = new System.Drawing.Size(672, 501);
		this.wizardControl1.FinishClick += new System.ComponentModel.CancelEventHandler(wizardControl1_FinishClick);
		this.welcomeWizardPage1.IntroductionText = "This wizard simplifies the importation of books records by guiding the user through a series of simple steps";
		this.welcomeWizardPage1.Name = "welcomeWizardPage1";
		this.welcomeWizardPage1.Size = new System.Drawing.Size(455, 368);
		this.wizardPage1.Controls.Add(this.labelControl6);
		this.wizardPage1.Controls.Add(this.labelControl2);
		this.wizardPage1.Controls.Add(this.labelControl1);
		this.wizardPage1.Controls.Add(this.labelControl10);
		this.wizardPage1.Controls.Add(this.simpleButton2);
		this.wizardPage1.Controls.Add(this.txtSource);
		this.wizardPage1.DescriptionText = "From this page you can select the excel file which contains the data you wish to import";
		this.wizardPage1.Name = "wizardPage1";
		this.wizardPage1.Size = new System.Drawing.Size(640, 356);
		this.wizardPage1.Text = "Datasource";
		this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl6.Location = new System.Drawing.Point(14, 70);
		this.labelControl6.Name = "labelControl6";
		this.labelControl6.Size = new System.Drawing.Size(416, 26);
		this.labelControl6.TabIndex = 51;
		this.labelControl6.Text = "Note that  your excel data sheet must contain the following data columns.\r\nThe order of the columns does not matter:";
		this.labelControl2.Location = new System.Drawing.Point(14, 38);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(50, 13);
		this.labelControl2.TabIndex = 47;
		this.labelControl2.Text = "File Name:";
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl1.Location = new System.Drawing.Point(14, 11);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(150, 13);
		this.labelControl1.TabIndex = 46;
		this.labelControl1.Text = "Specify the source of data.";
		this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl10.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.labelControl10.Location = new System.Drawing.Point(14, 106);
		this.labelControl10.Name = "labelControl10";
		this.labelControl10.Padding = new System.Windows.Forms.Padding(3);
		this.labelControl10.Size = new System.Drawing.Size(577, 25);
		this.labelControl10.TabIndex = 45;
		this.labelControl10.Text = "Category, ISBN, Title, Author, Publisher, PublicationYear, LocationInLibrary,Cost\r\n";
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.Location = new System.Drawing.Point(492, 30);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(117, 21);
		this.simpleButton2.TabIndex = 6;
		this.simpleButton2.Text = "Browse";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.txtSource.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtSource.EditValue = "";
		this.txtSource.Location = new System.Drawing.Point(70, 31);
		this.txtSource.Name = "txtSource";
		this.txtSource.Properties.NullText = "Browse for excel data source";
		this.txtSource.Properties.NullValuePrompt = "Browse for excel data source";
		this.txtSource.Properties.ReadOnly = true;
		this.txtSource.Size = new System.Drawing.Size(416, 20);
		this.txtSource.TabIndex = 5;
		this.completionWizardPage1.Controls.Add(this.checkEdit1);
		this.completionWizardPage1.Name = "completionWizardPage1";
		this.completionWizardPage1.Size = new System.Drawing.Size(455, 368);
		this.checkEdit1.EditValue = true;
		this.checkEdit1.Location = new System.Drawing.Point(10, 317);
		this.checkEdit1.Name = "checkEdit1";
		this.checkEdit1.Properties.Caption = "Show import report.";
		this.checkEdit1.Size = new System.Drawing.Size(432, 19);
		this.checkEdit1.TabIndex = 0;
		this.wizardPage2.Controls.Add(this.layoutControl1);
		this.wizardPage2.DescriptionText = " Columns belonging to the selected datasheet";
		this.wizardPage2.Name = "wizardPage2";
		this.wizardPage2.Size = new System.Drawing.Size(640, 356);
		this.wizardPage2.Text = "Datasource columns";
		this.wizardPage2.Validating += new System.ComponentModel.CancelEventHandler(wizardPage2_Validating);
		this.layoutControl1.Controls.Add(this.listBoxControl1);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(640, 356);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.listBoxControl1.Location = new System.Drawing.Point(2, 2);
		this.listBoxControl1.Name = "listBoxControl1";
		this.listBoxControl1.Size = new System.Drawing.Size(113, 352);
		this.listBoxControl1.StyleController = this.layoutControl1;
		this.listBoxControl1.TabIndex = 5;
		this.listBoxControl1.SelectedIndexChanged += new System.EventHandler(listBoxControl1_SelectedIndexChanged);
		this.gridControl1.Location = new System.Drawing.Point(119, 2);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(519, 352);
		this.gridControl1.TabIndex = 4;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlItem1, this.layoutControlItem2 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(640, 356);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(117, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(523, 356);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.listBoxControl1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(117, 356);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.wizardPage4.Controls.Add(this.lblCurrentStudent);
		this.wizardPage4.Controls.Add(this.progressBarStudents);
		this.wizardPage4.DescriptionText = "Please wait for a little time as the wizard does the work.";
		this.wizardPage4.Name = "wizardPage4";
		this.wizardPage4.Size = new System.Drawing.Size(640, 356);
		this.wizardPage4.Text = "Import Progress";
		this.lblCurrentStudent.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblCurrentStudent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblCurrentStudent.Location = new System.Drawing.Point(18, 174);
		this.lblCurrentStudent.Name = "lblCurrentStudent";
		this.lblCurrentStudent.Size = new System.Drawing.Size(598, 13);
		this.lblCurrentStudent.TabIndex = 2;
		this.progressBarStudents.Location = new System.Drawing.Point(18, 132);
		this.progressBarStudents.Name = "progressBarStudents";
		this.progressBarStudents.Properties.ShowTitle = true;
		this.progressBarStudents.Size = new System.Drawing.Size(598, 35);
		this.progressBarStudents.TabIndex = 1;
		this.wizardPage5.Controls.Add(this.lblDescriptionStatus);
		this.wizardPage5.Controls.Add(this.gridControl2);
		this.wizardPage5.DescriptionText = "This page will help you identify the most relevant data columns";
		this.wizardPage5.Name = "wizardPage5";
		this.wizardPage5.Size = new System.Drawing.Size(640, 356);
		this.wizardPage5.Text = "Columns Validation";
		this.wizardPage5.PageCommit += new System.EventHandler(wizardPage5_PageCommit);
		this.lblDescriptionStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblDescriptionStatus.Location = new System.Drawing.Point(4, 276);
		this.lblDescriptionStatus.Name = "lblDescriptionStatus";
		this.lblDescriptionStatus.Size = new System.Drawing.Size(0, 16);
		this.lblDescriptionStatus.TabIndex = 1;
		this.gridControl2.Location = new System.Drawing.Point(0, 0);
		this.gridControl2.MainView = this.gridView2;
		this.gridControl2.Name = "gridControl2";
		this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[2] { this.repositoryItemPictureEdit1, this.repositoryItemHyperLinkEdit1 });
		this.gridControl2.Size = new System.Drawing.Size(640, 269);
		this.gridControl2.TabIndex = 0;
		this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridColumn1, this.gridColumn2, this.gridColumn3 });
		this.gridView2.GridControl = this.gridControl2;
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsBehavior.Editable = false;
		this.gridView2.OptionsView.ShowGroupExpandCollapseButtons = false;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.gridView2.OptionsView.ShowIndicator = false;
		this.gridView2.RowHeight = 24;
		this.gridColumn1.Caption = "DATA COLUMN";
		this.gridColumn1.FieldName = "ColumnName";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 117;
		this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
		this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColumn2.Caption = "STATUS";
		this.gridColumn2.ColumnEdit = this.repositoryItemPictureEdit1;
		this.gridColumn2.FieldName = "Status";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn2.Width = 82;
		this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
		this.gridColumn3.Caption = "DESCRIPTION";
		this.gridColumn3.ColumnEdit = this.repositoryItemHyperLinkEdit1;
		this.gridColumn3.FieldName = "Description";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 2;
		this.gridColumn3.Width = 439;
		this.repositoryItemHyperLinkEdit1.AutoHeight = false;
		this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(672, 501);
		base.Controls.Add(this.wizardControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "BooksImport";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Import Books Wizard";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(StudentImport_FormClosed);
		((System.ComponentModel.ISupportInitialize)this.wizardControl1).EndInit();
		this.wizardControl1.ResumeLayout(false);
		this.wizardPage1.ResumeLayout(false);
		this.wizardPage1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtSource.Properties).EndInit();
		this.completionWizardPage1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.checkEdit1.Properties).EndInit();
		this.wizardPage2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.listBoxControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		this.wizardPage4.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.progressBarStudents.Properties).EndInit();
		this.wizardPage5.ResumeLayout(false);
		this.wizardPage5.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemPictureEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemHyperLinkEdit1).EndInit();
		base.ResumeLayout(false);
	}
}
