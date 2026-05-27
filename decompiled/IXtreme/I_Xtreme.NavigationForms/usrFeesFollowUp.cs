using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;

namespace I_Xtreme.NavigationForms;

public class usrFeesFollowUp : UserControl
{
    private IContainer components = null;
    private SplitContainerControl splitContainer;

    private ComboBoxEdit cboClassFilter;
    private SpinEdit txtMinBalance;
    private SimpleButton btnRefresh;
    private DevExpress.XtraGrid.GridControl gridWorklist;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewWorklist;
    private System.Windows.Forms.Panel leftPanel;

    private readonly FeesFollowUpService service = new FeesFollowUpService();
    private List<WorklistRow> currentRows = new List<WorklistRow>();

    public usrFeesFollowUp()
    {
        InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
        ((System.ComponentModel.ISupportInitialize)this.splitContainer).BeginInit();
        this.splitContainer.SuspendLayout();
        this.SuspendLayout();

        this.splitContainer.Dock = DockStyle.Fill;
        this.splitContainer.Horizontal = false;       // vertical split
        this.splitContainer.SplitterPosition = 700;   // tuned later
        this.splitContainer.Name = "splitContainer";

        // Class filter combo
        this.cboClassFilter = new DevExpress.XtraEditors.ComboBoxEdit();
        this.cboClassFilter.Properties.Items.Add("All Classes");
        this.cboClassFilter.SelectedIndex = 0;
        this.cboClassFilter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

        // Min balance
        this.txtMinBalance = new DevExpress.XtraEditors.SpinEdit();
        this.txtMinBalance.Properties.IsFloatValue = false;
        this.txtMinBalance.Properties.MaskSettings.Set("mask", "N0");
        this.txtMinBalance.Value = 0;

        // Refresh button
        this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
        this.btnRefresh.Text = "Refresh";
        this.btnRefresh.Click += BtnRefresh_Click;

        // Grid
        this.gridWorklist = new DevExpress.XtraGrid.GridControl();
        this.gridViewWorklist = new DevExpress.XtraGrid.Views.Grid.GridView();
        this.gridWorklist.MainView = this.gridViewWorklist;
        this.gridWorklist.ViewCollection.Add(this.gridViewWorklist);
        this.gridViewWorklist.OptionsSelection.MultiSelect = false;
        this.gridViewWorklist.OptionsBehavior.Editable = false;
        this.gridViewWorklist.OptionsView.ShowGroupPanel = false;
        this.gridViewWorklist.FocusedRowChanged += GridViewWorklist_FocusedRowChanged;
        this.gridViewWorklist.RowStyle += GridViewWorklist_RowStyle;

        // Layout: stack filter bar above grid in the left panel of split container
        this.leftPanel = new System.Windows.Forms.Panel();
        this.leftPanel.Dock = DockStyle.Fill;

        var filterStrip = new System.Windows.Forms.Panel();
        filterStrip.Height = 36;
        filterStrip.Dock = DockStyle.Top;
        this.cboClassFilter.Location = new System.Drawing.Point(8, 8);
        this.cboClassFilter.Width = 160;
        this.txtMinBalance.Location = new System.Drawing.Point(176, 8);
        this.txtMinBalance.Width = 120;
        this.btnRefresh.Location = new System.Drawing.Point(304, 7);
        this.btnRefresh.Width = 80;
        filterStrip.Controls.Add(this.cboClassFilter);
        filterStrip.Controls.Add(this.txtMinBalance);
        filterStrip.Controls.Add(this.btnRefresh);

        this.gridWorklist.Dock = DockStyle.Fill;
        this.leftPanel.Controls.Add(this.gridWorklist);
        this.leftPanel.Controls.Add(filterStrip);

        this.splitContainer.Panel1.Controls.Add(this.leftPanel);

        this.Controls.Add(this.splitContainer);
        this.Name = "usrFeesFollowUp";
        this.Size = new System.Drawing.Size(1280, 720);

        this.Load += usrFeesFollowUp_Load;

        ((System.ComponentModel.ISupportInitialize)this.splitContainer).EndInit();
        this.splitContainer.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private void usrFeesFollowUp_Load(object sender, System.EventArgs e)
    {
        LoadClasses();
        LoadWorklist();
    }

    private void LoadClasses()
    {
        using var conn = new System.Data.SqlClient.SqlConnection(AlienAge.Connectivity.DataConnection.ConnectToDatabase());
        using var da = new System.Data.SqlClient.SqlDataAdapter(
            "SELECT DISTINCT ClassId FROM tbl_Stud WHERE ClassId IS NOT NULL ORDER BY ClassId", conn);
        var dt = new System.Data.DataTable();
        da.Fill(dt);
        cboClassFilter.Properties.Items.Clear();
        cboClassFilter.Properties.Items.Add("All Classes");
        foreach (System.Data.DataRow r in dt.Rows)
        {
            cboClassFilter.Properties.Items.Add(r["ClassId"].ToString());
        }
        cboClassFilter.SelectedIndex = 0;
    }

    private void LoadWorklist()
    {
        string classFilter = cboClassFilter.Text == "All Classes" ? "" : cboClassFilter.Text;
        decimal minBalance = (decimal)txtMinBalance.Value;
        currentRows = service.GetWorklist(classFilter, minBalance);
        gridWorklist.DataSource = currentRows;
    }

    private void GridViewWorklist_RowStyle(object sender,
        DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
    {
        if (e.RowHandle < 0) return;
        var row = gridViewWorklist.GetRow(e.RowHandle) as WorklistRow;
        if (row == null) return;
        switch (row.Tier)
        {
            case PriorityTier.BrokenPromise:
                e.Appearance.BackColor = Color.LightCoral;
                e.HighPriority = true;
                break;
            case PriorityTier.Stale:
                e.Appearance.BackColor = Color.LightYellow;
                e.HighPriority = true;
                break;
        }
    }

    private void BtnRefresh_Click(object sender, System.EventArgs e) => LoadWorklist();

    private void GridViewWorklist_FocusedRowChanged(object sender,
        DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
        // Hook for Task 6 (parent detail panel).
    }
}
