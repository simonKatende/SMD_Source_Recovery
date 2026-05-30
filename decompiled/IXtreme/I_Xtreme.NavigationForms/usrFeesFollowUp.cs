using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrFeesFollowUp : XtraUserControl
{
    // ── KPI strip ─────────────────────────────────────────────────────────────
    private readonly Label[] _kpiValues = new Label[5];
    private FlowLayoutPanel  _kpiPanel;

    // ── Priority breakdown grid ───────────────────────────────────────────────
    private GridControl _gridPriority;
    private GridView    _viewPriority;

    // ── Top 5 by balance grid ─────────────────────────────────────────────────
    private GridControl _gridTop5;
    private GridView    _viewTop5;

    // ── Quick actions panel ───────────────────────────────────────────────────
    private Panel _actionPanel;

    // ── State ─────────────────────────────────────────────────────────────────
    private readonly FeesFollowUpService _service = new FeesFollowUpService();

    public usrFeesFollowUp()
    {
        InitializeComponent();
    }

    // ── InitializeComponent ───────────────────────────────────────────────────

    private void InitializeComponent()
    {
        this.SuspendLayout();

        // Section 4 — Quick actions (added first so Fill grids stack above it)
        _actionPanel = new Panel { Dock = DockStyle.Bottom, Height = 60 };
        var btnRefresh = new SimpleButton
        {
            Text   = "Refresh",
            Width  = 100,
            Height = 30,
            Location = new Point(8, 14),
        };
        btnRefresh.Click += (s, e) => LoadDashboard();

        var btnDaily = new SimpleButton
        {
            Text   = "Open Daily Worklist",
            Width  = 150,
            Height = 30,
            Location = new Point(116, 14),
        };
        btnDaily.Click += (s, e) => OpenDailyWorklist();

        var btnGuardian = new SimpleButton
        {
            Text   = "Guardian Worklist",
            Width  = 150,
            Height = 30,
            Location = new Point(274, 14),
        };
        btnGuardian.Click += (s, e) => OpenGuardianWorklist();

        var btnStudent = new SimpleButton
        {
            Text   = "Student Worklist",
            Width  = 150,
            Height = 30,
            Location = new Point(432, 14),
        };
        btnStudent.Click += (s, e) => OpenStudentWorklist();

        _actionPanel.Controls.AddRange(new Control[]
        {
            btnRefresh, btnDaily, btnGuardian, btnStudent,
        });

        // Section 3 — Top 5 by balance
        var lblTop5 = new LabelControl
        {
            Text     = "Top 5 Guardians by Outstanding Balance",
            Dock     = DockStyle.Top,
            AutoSize = false,
            Height   = 20,
        };

        _gridTop5 = new GridControl { Dock = DockStyle.Top, Height = 180 };
        _viewTop5 = new GridView();
        _gridTop5.MainView = _viewTop5;
        _gridTop5.ViewCollection.Add(_viewTop5);
        _viewTop5.OptionsView.ShowGroupPanel   = false;
        _viewTop5.OptionsBehavior.Editable     = false;

        var colGuardian = new DevExpress.XtraGrid.Columns.GridColumn
        {
            FieldName = "GuardianLabel",
            Caption   = "Guardian",
            Width     = 200,
        };
        colGuardian.OptionsColumn.AllowEdit = false;

        var colBalance = new DevExpress.XtraGrid.Columns.GridColumn
        {
            FieldName = "TotalBalance",
            Caption   = "Balance (UGX)",
            Width     = 140,
        };
        colBalance.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
        colBalance.DisplayFormat.FormatString = "N0";
        colBalance.OptionsColumn.AllowEdit    = false;

        var colStudents = new DevExpress.XtraGrid.Columns.GridColumn
        {
            FieldName = "StudentCount",
            Caption   = "Students",
            Width     = 70,
        };
        colStudents.OptionsColumn.AllowEdit = false;

        var colTier = new DevExpress.XtraGrid.Columns.GridColumn
        {
            FieldName   = "TierDisplay",
            Caption     = "Priority",
            UnboundType = DevExpress.Data.UnboundColumnType.String,
            Width       = 120,
        };
        colTier.OptionsColumn.AllowEdit = false;

        _viewTop5.Columns.AddRange(new[]
        {
            colGuardian, colBalance, colStudents, colTier,
        });
        _viewTop5.CustomUnboundColumnData += ViewTop5_UnboundData;
        _viewTop5.RowStyle += ViewTop5_RowStyle;

        // Section 2 — Priority breakdown
        var lblPriority = new LabelControl
        {
            Text     = "Balance by Priority Tier",
            Dock     = DockStyle.Top,
            AutoSize = false,
            Height   = 20,
        };

        _gridPriority = new GridControl { Dock = DockStyle.Top, Height = 110 };
        _viewPriority = new GridView();
        _gridPriority.MainView = _viewPriority;
        _gridPriority.ViewCollection.Add(_viewPriority);
        _viewPriority.OptionsView.ShowGroupPanel = false;
        _viewPriority.OptionsBehavior.Editable   = false;

        var colPrio = new DevExpress.XtraGrid.Columns.GridColumn
        {
            FieldName   = "TierDisplay",
            Caption     = "Priority",
            UnboundType = DevExpress.Data.UnboundColumnType.String,
            Width       = 160,
        };
        colPrio.OptionsColumn.AllowEdit = false;

        var colGuardianCount = new DevExpress.XtraGrid.Columns.GridColumn
        {
            FieldName = "GuardianCount",
            Caption   = "Guardians",
            Width     = 90,
        };
        colGuardianCount.OptionsColumn.AllowEdit = false;

        var colPrioBalance = new DevExpress.XtraGrid.Columns.GridColumn
        {
            FieldName = "TotalBalance",
            Caption   = "Total Balance (UGX)",
            Width     = 160,
        };
        colPrioBalance.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
        colPrioBalance.DisplayFormat.FormatString = "N0";
        colPrioBalance.OptionsColumn.AllowEdit    = false;

        _viewPriority.Columns.AddRange(new[]
        {
            colPrio, colGuardianCount, colPrioBalance,
        });
        _viewPriority.CustomUnboundColumnData += ViewPriority_UnboundData;
        _viewPriority.RowStyle += ViewPriority_RowStyle;

        // Section 1 — KPI strip
        _kpiPanel = new FlowLayoutPanel
        {
            Dock          = DockStyle.Top,
            Height        = 100,
            FlowDirection = FlowDirection.LeftToRight,
            AutoScroll    = true,
        };
        _kpiPanel.Controls.Add(BuildKpiCard(0, "Total Outstanding (UGX)", Color.DarkRed));
        _kpiPanel.Controls.Add(BuildKpiCard(1, "Collection Rate (%)",     Color.DarkGreen));
        _kpiPanel.Controls.Add(BuildKpiCard(2, "Guardians with Balance",  Color.DarkBlue));
        _kpiPanel.Controls.Add(BuildKpiCard(3, "Today's Remaining",       Color.DarkOrange));
        _kpiPanel.Controls.Add(BuildKpiCard(4, "Broken Promises",         Color.Crimson));

        // Add controls — bottom-docked first, then top-docked in reverse visual order
        this.Controls.Add(_actionPanel);
        this.Controls.Add(lblTop5);
        this.Controls.Add(_gridTop5);
        this.Controls.Add(lblPriority);
        this.Controls.Add(_gridPriority);
        this.Controls.Add(_kpiPanel);

        this.Load += usrFeesFollowUp_Load;
        this.ResumeLayout(false);
    }

    // ── KPI card builder ──────────────────────────────────────────────────────

    private GroupControl BuildKpiCard(int idx, string caption, Color valueColor)
    {
        var grp = new GroupControl { Width = 190, Height = 90, Text = caption };
        var lbl = new Label
        {
            Text      = "—",
            Font      = new Font("Tahoma", 18, FontStyle.Bold),
            ForeColor = valueColor,
            Dock      = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        grp.Controls.Add(lbl);
        _kpiValues[idx] = lbl;
        return grp;
    }

    // ── Lifecycle ─────────────────────────────────────────────────────────────

    private void usrFeesFollowUp_Load(object sender, EventArgs e) => LoadDashboard();

    // ── Dashboard data ────────────────────────────────────────────────────────

    private void LoadDashboard()
    {
        try
        {
            _service.CheckAndSendSmsReminders();
            var data = _service.GetDashboardData();
            UpdateKpiStrip(data);
            UpdatePriorityBreakdown(data);
            UpdateTopByBalance(data);
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(
                $"Could not load dashboard data.\n\n{ex.Message}",
                "Fees Follow-up",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Warning);
        }
    }

    private void UpdateKpiStrip(DashboardData data)
    {
        _kpiValues[0].Text = $"{data.TotalOutstanding:N0}";
        _kpiValues[1].Text = $"{data.CollectionRate:F1}%";
        _kpiValues[2].Text = $"{data.TotalGuardiansWithBalance}";
        _kpiValues[3].Text = $"{data.DailyListRemaining} / {data.DailyListTotal}";
        _kpiValues[4].Text = $"{data.BrokenPromiseCount}";
    }

    private void UpdatePriorityBreakdown(DashboardData data)
    {
        _gridPriority.DataSource = data.ByPriority;
        _viewPriority.RefreshData();
    }

    private void UpdateTopByBalance(DashboardData data)
    {
        _gridTop5.DataSource = data.TopByBalance;
        _viewTop5.RefreshData();
    }

    // ── Grid unbound columns ──────────────────────────────────────────────────

    private void ViewPriority_UnboundData(object sender,
        DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
    {
        if (!e.IsGetData || e.Column.FieldName != "TierDisplay") return;
        var row = _viewPriority.GetRow(e.ListSourceRowIndex) as PriorityGroupStats;
        e.Value = TierDisplayName(row?.Tier ?? PriorityTier.Current);
    }

    private void ViewTop5_UnboundData(object sender,
        DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
    {
        if (!e.IsGetData || e.Column.FieldName != "TierDisplay") return;
        var row = _viewTop5.GetRow(e.ListSourceRowIndex) as GuardianWorklistRow;
        e.Value = TierDisplayName(row?.Tier ?? PriorityTier.Current);
    }

    // ── Grid row styles ───────────────────────────────────────────────────────

    private void ViewPriority_RowStyle(object sender,
        DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
    {
        var row = _viewPriority.GetRow(e.RowHandle) as PriorityGroupStats;
        if (row == null) return;
        ApplyTierStyle(e, row.Tier);
    }

    private void ViewTop5_RowStyle(object sender,
        DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
    {
        var row = _viewTop5.GetRow(e.RowHandle) as GuardianWorklistRow;
        if (row == null) return;
        ApplyTierStyle(e, row.Tier);
    }

    private static void ApplyTierStyle(DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e, PriorityTier tier)
    {
        switch (tier)
        {
            case PriorityTier.Critical:
                e.Appearance.BackColor = Color.OrangeRed;
                e.Appearance.ForeColor = Color.White;
                e.HighPriority = true;
                break;
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

    // ── Helper ────────────────────────────────────────────────────────────────

    private static string TierDisplayName(PriorityTier tier) => tier switch
    {
        PriorityTier.Critical      => "Critical",
        PriorityTier.BrokenPromise => "Missed Promise",
        PriorityTier.Stale         => "Contact Overdue",
        PriorityTier.Current       => "Up to Date",
        _                          => tier.ToString(),
    };

    // ── Public ribbon API ─────────────────────────────────────────────────────

    public void OpenDailyWorklist()
    {
        using var dlg = new dlgDailyWorklist();
        dlg.ShowDialog(this);
        LoadDashboard();
    }

    public void OpenGuardianWorklist()
    {
        using var dlg = new dlgGuardianWorklist();
        dlg.ShowDialog(this);
        LoadDashboard();
    }

    public void OpenStudentWorklist()
    {
        using var dlg = new dlgStudentWorklist();
        dlg.ShowDialog(this);
        LoadDashboard();
    }

    public void OpenSettings()
    {
        using var dlg = new FollowUpSettings();
        if (dlg.ShowDialog(this) == DialogResult.OK)
            LoadDashboard();
    }

    // ── Legacy ribbon stubs — kept until Task 11 restructures the ribbon ──────
    // These were on the old worklist-grid design. They are no-ops here;
    // Task 11 will remove or replace the ribbon buttons that call them.

    public void OpenContactView() { }

    public void PrintPreviewWorklist() { }

    public void PrintWorklist() { }

    public void ExportWorklistToExcel() { }
}
