using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;
using I_Xtreme;

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

    private LabelControl lblParentHeader;
    private LabelControl lblRecentPayments;
    private DevExpress.XtraGrid.GridControl gridHistory;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewHistory;
    private System.Windows.Forms.Panel rightPanel;
    private System.Windows.Forms.Panel headerPanel;

    private System.Windows.Forms.Panel newContactPanel;
    private RadioGroup rgChannel;
    private ComboBoxEdit cboOutcome;
    private MemoEdit memoNote;
    private SimpleButton btnSave;

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

        this.rightPanel = new System.Windows.Forms.Panel { Dock = DockStyle.Fill };
        this.headerPanel = new System.Windows.Forms.Panel { Dock = DockStyle.Top, Height = 64 };

        this.lblParentHeader = new DevExpress.XtraEditors.LabelControl();
        this.lblParentHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
        this.lblParentHeader.Location = new System.Drawing.Point(8, 6);
        this.lblParentHeader.AutoSizeMode = LabelAutoSizeMode.None;
        this.lblParentHeader.Size = new System.Drawing.Size(560, 22);
        this.lblParentHeader.Text = "(select a parent)";

        this.lblRecentPayments = new DevExpress.XtraEditors.LabelControl();
        this.lblRecentPayments.Location = new System.Drawing.Point(8, 32);
        this.lblRecentPayments.AutoSizeMode = LabelAutoSizeMode.None;
        this.lblRecentPayments.Size = new System.Drawing.Size(560, 28);
        this.lblRecentPayments.Text = "";

        this.headerPanel.Controls.Add(this.lblParentHeader);
        this.headerPanel.Controls.Add(this.lblRecentPayments);

        this.gridHistory = new DevExpress.XtraGrid.GridControl { Dock = DockStyle.Fill };
        this.gridViewHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
        this.gridHistory.MainView = this.gridViewHistory;
        this.gridHistory.ViewCollection.Add(this.gridViewHistory);
        this.gridViewHistory.OptionsBehavior.Editable = false;
        this.gridViewHistory.OptionsView.ShowGroupPanel = false;

        this.newContactPanel = new System.Windows.Forms.Panel { Dock = DockStyle.Bottom, Height = 200 };

        this.rgChannel = new DevExpress.XtraEditors.RadioGroup();
        this.rgChannel.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[]
        {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(Models.ContactChannel.SMS, "SMS"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(Models.ContactChannel.Phone, "Phone"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(Models.ContactChannel.InPerson, "InPerson"),
        });
        this.rgChannel.Properties.Columns = 3;
        this.rgChannel.SelectedIndex = 1; // default to Phone
        this.rgChannel.Location = new System.Drawing.Point(8, 8);
        this.rgChannel.Size = new System.Drawing.Size(400, 36);

        this.cboOutcome = new DevExpress.XtraEditors.ComboBoxEdit();
        this.cboOutcome.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        foreach (Models.ContactOutcome o in System.Enum.GetValues(typeof(Models.ContactOutcome)))
            this.cboOutcome.Properties.Items.Add(o);
        this.cboOutcome.SelectedIndex = 1; // default Contacted
        this.cboOutcome.Location = new System.Drawing.Point(8, 52);
        this.cboOutcome.Width = 200;

        this.memoNote = new DevExpress.XtraEditors.MemoEdit();
        this.memoNote.Location = new System.Drawing.Point(8, 84);
        this.memoNote.Size = new System.Drawing.Size(560, 70);

        this.btnSave = new DevExpress.XtraEditors.SimpleButton { Text = "Save" };
        this.btnSave.Location = new System.Drawing.Point(8, 162);
        this.btnSave.Width = 100;
        this.btnSave.Click += BtnSave_Click;

        this.newContactPanel.Controls.Add(this.rgChannel);
        this.newContactPanel.Controls.Add(this.cboOutcome);
        this.newContactPanel.Controls.Add(this.memoNote);
        this.newContactPanel.Controls.Add(this.btnSave);

        this.rightPanel.Controls.Add(this.newContactPanel);
        this.rightPanel.Controls.Add(this.gridHistory);
        this.rightPanel.Controls.Add(this.headerPanel);

        this.splitContainer.Panel2.Controls.Add(this.rightPanel);

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
        if (e.FocusedRowHandle < 0 || e.FocusedRowHandle >= currentRows.Count)
        {
            lblParentHeader.Text = "(select a parent)";
            lblRecentPayments.Text = "";
            gridHistory.DataSource = null;
            return;
        }
        var row = currentRows[e.FocusedRowHandle];
        lblParentHeader.Text = $"{row.FullName}  •  {row.ClassId}  •  Balance UGX {row.Balance:N0}";

        var payments = service.GetRecentPayments(row.StudentNumber, 3);
        if (payments.Rows.Count == 0)
        {
            lblRecentPayments.Text = "Last 3 payments: (none)";
        }
        else
        {
            var parts = new System.Collections.Generic.List<string>();
            foreach (System.Data.DataRow p in payments.Rows)
            {
                decimal amt = p["Credit"] is decimal d ? d : 0m;
                var dt = p["PaymentDate"] is System.DateTime pd ? pd : System.DateTime.MinValue;
                parts.Add($"{amt:N0} ({dt:yyyy-MM-dd})");
            }
            lblRecentPayments.Text = "Last 3 payments: " + string.Join(", ", parts);
        }

        gridHistory.DataSource = service.GetContactHistory(row.StudentNumber);
    }

    private void BtnSave_Click(object sender, System.EventArgs e)
    {
        int rh = gridViewWorklist.FocusedRowHandle;
        if (rh < 0 || rh >= currentRows.Count)
        {
            XtraMessageBox.Show("Select a parent on the worklist first.",
                "School Management Dynamics", System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Information);
            return;
        }
        var row = currentRows[rh];
        var channel = (Models.ContactChannel)rgChannel.EditValue;
        var outcome = (Models.ContactOutcome)cboOutcome.SelectedItem;

        if (channel == Models.ContactChannel.SMS)
        {
            // Task 9 wires this up.
            XtraMessageBox.Show("SMS save flow lands in a later task.",
                "School Management Dynamics", System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Information);
            return;
        }

        var entry = new Models.FeesContactLog
        {
            StudentNumber = row.StudentNumber,
            ContactDate = System.DateTime.Now,
            LoggedBy = CurrentUser.GetSystemUser(),
            Channel = channel,
            Outcome = outcome,
            Note = string.IsNullOrWhiteSpace(memoNote.Text) ? null : memoNote.Text,
        };
        try
        {
            service.LogContact(entry);
            memoNote.Text = "";
            gridHistory.DataSource = service.GetContactHistory(row.StudentNumber);
        }
        catch (System.Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Hand);
        }
    }
}
