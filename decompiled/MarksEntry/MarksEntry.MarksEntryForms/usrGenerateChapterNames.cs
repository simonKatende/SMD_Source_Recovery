using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using MarksEntry.MarksEntryClasses;

namespace MarksEntry.MarksEntryForms;

public class usrGenerateChapterNames : XtraUserControl
{
	private string SubjectId = string.Empty;

	private string ClassId = string.Empty;

	private string SemesterId = string.Empty;

	private TextEdit textEdit;

	private MemoEdit memoEdit;

	private LabelControl labelTitle;

	private LabelControl labelCompetency;

	private SimpleButton simpleButton;

	public CloseFlyoutDialog CloseFlyoutDialog;

	private IContainer components = null;

	private SimpleButton simpleButton1;

	private LayoutControl layoutControl1;

	private TabPane tabPane1;

	private LayoutControlGroup Root;

	private LayoutControlItem layoutControlItem1;

	private PanelControl panelControl1;

	public usrGenerateChapterNames(string SubjectId, string ClassId, string SemesterId)
	{
		InitializeComponent();
		Dock = DockStyle.Fill;
		this.SubjectId = SubjectId;
		this.ClassId = ClassId;
		this.SemesterId = SemesterId;
		LoadChapters();
	}

	private void LoadChapters()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT TOP(10) SubjectId,CompetencyNo,Competency,Topic FROM OLevelReportNC WHERE SubjectId='{SubjectId}' AND ClassId='{ClassId}' AND SemesterId='{SemesterId}' GROUP BY SubjectId,Competency,CompetencyNo,Topic", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		int count = dataTable.Rows.Count;
		tabPane1.Pages.Clear();
		for (int i = 0; i < count; i++)
		{
			Font font = new Font("Cascadia Mono", 11f);
			TabNavigationPage tabNavigationPage = new TabNavigationPage
			{
				Name = "Chapter" + (i + 1),
				Caption = "Chapter " + (i + 1)
			};
			textEdit = new TextEdit
			{
				Location = new Point(92, 17),
				Size = new Size(466, 23),
				Name = "txt" + i,
				Text = dataTable.Rows[i]["Topic"].ToString(),
				Font = font
			};
			textEdit.Properties.CharacterCasing = CharacterCasing.Upper;
			memoEdit = new MemoEdit
			{
				Location = new Point(92, 44),
				Size = new Size(466, 214),
				Name = "memo" + i,
				Text = dataTable.Rows[i]["Competency"].ToString(),
				Font = font
			};
			simpleButton = new SimpleButton
			{
				Location = new Point(448, 265),
				Size = new Size(109, 23),
				Text = "Save"
			};
			simpleButton.Click += SimpleButton_Click;
			labelTitle = new LabelControl
			{
				Location = new Point(11, 26),
				Text = "Chapter/Topic"
			};
			labelCompetency = new LabelControl
			{
				Location = new Point(11, 45),
				Text = "Competency"
			};
			tabNavigationPage.Controls.AddRange(new Control[5] { textEdit, memoEdit, simpleButton, labelTitle, labelCompetency });
			tabPane1.Pages.Add(tabNavigationPage);
		}
	}

	private void SimpleButton_Click(object sender, EventArgs e)
	{
		int selectedPageIndex = tabPane1.SelectedPageIndex;
		TextEdit textEdit = new TextEdit();
		MemoEdit memoEdit = new MemoEdit();
		foreach (Control control in tabPane1.Pages[selectedPageIndex].Controls)
		{
			if (control.GetType() == typeof(TextEdit))
			{
				textEdit = (TextEdit)control;
			}
			else if (control.GetType() == typeof(MemoEdit))
			{
				memoEdit = (MemoEdit)control;
			}
		}
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "UPDATE OLevelReportNC SET Topic=@Topic,Competency=@Competency WHERE SubjectId=@SubjectId AND CompetencyNo=@CompetencyNo AND ClassId=@ClassId AND SemesterId=@SemesterId"
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@Topic", textEdit.Text);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", SubjectId);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@CompetencyNo", (selectedPageIndex + 1).ToString());
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Competency", memoEdit.Text);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", ClassId);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", SemesterId);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		CloseFlyoutDialog();
	}

	private void simpleButton3_Click(object sender, EventArgs e)
	{
		MessageBox.Show(tabPane1.SelectedPage.Caption);
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
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.tabPane1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		this.panelControl1.SuspendLayout();
		base.SuspendLayout();
		this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton1.Appearance.BackColor = System.Drawing.Color.Red;
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.simpleButton1.Appearance.Options.UseBackColor = true;
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(7, 8);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(29, 25);
		this.simpleButton1.TabIndex = 1;
		this.simpleButton1.Text = "X";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.layoutControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.layoutControl1.Controls.Add(this.tabPane1);
		this.layoutControl1.Location = new System.Drawing.Point(105, 8);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(599, 358);
		this.layoutControl1.TabIndex = 2;
		this.layoutControl1.Text = "layoutControl1";
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem1 });
		this.Root.Name = "Root";
		this.Root.Size = new System.Drawing.Size(599, 358);
		this.Root.TextVisible = false;
		this.tabPane1.Location = new System.Drawing.Point(12, 12);
		this.tabPane1.Name = "tabPane1";
		this.tabPane1.RegularSize = new System.Drawing.Size(575, 334);
		this.tabPane1.SelectedPage = null;
		this.tabPane1.Size = new System.Drawing.Size(575, 334);
		this.tabPane1.TabIndex = 4;
		this.tabPane1.Text = "tabPane1";
		this.layoutControlItem1.Control = this.tabPane1;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(579, 338);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.panelControl1.Controls.Add(this.simpleButton1);
		this.panelControl1.Dock = System.Windows.Forms.DockStyle.Right;
		this.panelControl1.Location = new System.Drawing.Point(801, 0);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(43, 374);
		this.panelControl1.TabIndex = 3;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.panelControl1);
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrGenerateChapterNames";
		base.Size = new System.Drawing.Size(844, 374);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.tabPane1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		this.panelControl1.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
