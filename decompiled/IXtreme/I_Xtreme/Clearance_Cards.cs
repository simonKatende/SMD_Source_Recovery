using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Card;

namespace I_Xtreme;

public class Clearance_Cards : XtraForm
{
	private IContainer components = null;

	private PanelControl panelControl1;

	private GridControl gridControl1;

	private CardView cardView1;

	private SimpleButton btnPrint;

	private LabelControl labelControl1;

	private ComboBoxEdit cboSemester;

	public Clearance_Cards()
	{
		InitializeComponent();
	}

	private void Clearance_Cards_Load(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Maximized;
		WorkingSemesters.GetSemesters(new ComboBoxEdit[1] { cboSemester });
	}

	private void btnPrint_Click(object sender, EventArgs e)
	{
		gridControl1.ShowPrintPreview();
	}

	private void cboSemester_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cboSemester.SelectedIndex == 0)
		{
			gridControl1.DataSource = null;
			return;
		}
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			string selectCommandText = $"SELECT p.SemesterId AS Semester,s.StudentNumber,s.fullName AS Name,s.StreamId AS Stream,s.ClassId AS Class, SUM(p.Debit) AS TotalRequired,SUM(p.Credit) AS TotalPaid, SUM(p.Debit) - SUM(p.Credit) AS Balance FROM PersonalRequirements p INNER JOIN Students s ON p.StudentNumber = s.StudentNumber WHERE p.SemesterId='{cboSemester.SelectedItem}' GROUP BY s.fullName,s.StudentNumber,s.StreamId,p.SemesterId,s.ClassId";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentIds");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			gridControl1.DataSource = dataTable.DefaultView;
			cardView1.Columns["TotalRequired"].DisplayFormat.FormatType = FormatType.Numeric;
			cardView1.Columns["TotalRequired"].DisplayFormat.FormatString = "{0:#,#.0}";
			cardView1.Columns["TotalPaid"].DisplayFormat.FormatType = FormatType.Numeric;
			cardView1.Columns["TotalPaid"].DisplayFormat.FormatString = "{0:#,#.0}";
			cardView1.Columns["Balance"].DisplayFormat.FormatType = FormatType.Numeric;
			cardView1.Columns["Balance"].DisplayFormat.FormatString = "{0:#,#.0}";
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message);
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
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.cboSemester = new DevExpress.XtraEditors.ComboBoxEdit();
		this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		this.panelControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.cboSemester.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cardView1).BeginInit();
		base.SuspendLayout();
		this.panelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panelControl1.Controls.Add(this.labelControl1);
		this.panelControl1.Controls.Add(this.cboSemester);
		this.panelControl1.Controls.Add(this.btnPrint);
		this.panelControl1.Location = new System.Drawing.Point(2, 4);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(662, 40);
		this.panelControl1.TabIndex = 1;
		this.labelControl1.Location = new System.Drawing.Point(11, 12);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(49, 13);
		this.labelControl1.TabIndex = 2;
		this.labelControl1.Text = "Semester:";
		this.cboSemester.Location = new System.Drawing.Point(83, 9);
		this.cboSemester.Name = "cboSemester";
		this.cboSemester.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSemester.Size = new System.Drawing.Size(189, 20);
		this.cboSemester.TabIndex = 1;
		this.cboSemester.SelectedIndexChanged += new System.EventHandler(cboSemester_SelectedIndexChanged);
		this.btnPrint.Location = new System.Drawing.Point(300, 8);
		this.btnPrint.Name = "btnPrint";
		this.btnPrint.Size = new System.Drawing.Size(75, 23);
		this.btnPrint.TabIndex = 0;
		this.btnPrint.Text = "Print Cards";
		this.btnPrint.Click += new System.EventHandler(btnPrint_Click);
		this.gridControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridControl1.Location = new System.Drawing.Point(2, 51);
		this.gridControl1.MainView = this.cardView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(662, 367);
		this.gridControl1.TabIndex = 2;
		this.gridControl1.UseEmbeddedNavigator = true;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.cardView1 });
		this.cardView1.AppearancePrint.CardCaption.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.cardView1.AppearancePrint.CardCaption.Options.UseFont = true;
		this.cardView1.CardCaptionFormat = "Clearance card: {1}";
		this.cardView1.CardWidth = 250;
		this.cardView1.FocusedCardTopFieldIndex = 0;
		this.cardView1.GridControl = this.gridControl1;
		this.cardView1.Name = "cardView1";
		this.cardView1.OptionsBehavior.FieldAutoHeight = true;
		this.cardView1.OptionsPrint.PrintEmptyFields = false;
		this.cardView1.OptionsView.ShowCardExpandButton = false;
		this.cardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(665, 420);
		base.Controls.Add(this.gridControl1);
		base.Controls.Add(this.panelControl1);
		base.Name = "Clearance_Cards";
		this.Text = "Clearance Cards";
		base.Load += new System.EventHandler(Clearance_Cards_Load);
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		this.panelControl1.ResumeLayout(false);
		this.panelControl1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.cboSemester.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cardView1).EndInit();
		base.ResumeLayout(false);
	}
}
