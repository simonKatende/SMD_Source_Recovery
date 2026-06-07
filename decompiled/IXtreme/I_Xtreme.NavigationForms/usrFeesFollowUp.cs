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
    private readonly Label[] _kpiValues = new Label[12];
    public event Action<string> NavigationRequested;
    private FlowLayoutPanel  _kpiPanel;

    // ── Priority breakdown grid ───────────────────────────────────────────────
    private GridControl _gridPriority;
    private GridView    _viewPriority;

    // ── Top 5 by balance grid ─────────────────────────────────────────────────
    private GridControl _gridTop5;
    private GridView    _viewTop5;

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
        _viewTop5.OptionsDetail.SmartDetailExpand = false;

        var colGuardian = new DevExpress.XtraGrid.Columns.GridColumn
            { FieldName = "GuardianLabel", Caption = "Guardian", Width = 200, VisibleIndex = 0 };
        colGuardian.OptionsColumn.AllowEdit = false;

        var colBalance = new DevExpress.XtraGrid.Columns.GridColumn
            { FieldName = "TotalBalance", Caption = "Balance (UGX)", Width = 140, VisibleIndex = 1 };
        colBalance.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
        colBalance.DisplayFormat.FormatString = "N0";
        colBalance.OptionsColumn.AllowEdit    = false;

        var colStudents = new DevExpress.XtraGrid.Columns.GridColumn
            { FieldName = "StudentCount", Caption = "Students", Width = 70, VisibleIndex = 2 };
        colStudents.OptionsColumn.AllowEdit = false;

        var colTier = new DevExpress.XtraGrid.Columns.GridColumn
        {
            FieldName   = "TierDisplay",
            Caption     = "Priority",
            UnboundType = DevExpress.Data.UnboundColumnType.String,
            Width       = 120,
            VisibleIndex = 3,
        };
        colTier.OptionsColumn.AllowEdit = false;

        _viewTop5.Columns.AddRange(new[] { colGuardian, colBalance, colStudents, colTier });
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
        _viewPriority.OptionsDetail.SmartDetailExpand = false;

        var colPrio = new DevExpress.XtraGrid.Columns.GridColumn
        {
            FieldName    = "TierDisplay",
            Caption      = "Priority",
            UnboundType  = DevExpress.Data.UnboundColumnType.String,
            Width        = 160,
            VisibleIndex = 0,
        };
        colPrio.OptionsColumn.AllowEdit = false;

        var colGuardianCount = new DevExpress.XtraGrid.Columns.GridColumn
            { FieldName = "GuardianCount", Caption = "Guardians", Width = 90, VisibleIndex = 1 };
        colGuardianCount.OptionsColumn.AllowEdit = false;

        var colPrioBalance = new DevExpress.XtraGrid.Columns.GridColumn
            { FieldName = "TotalBalance", Caption = "Total Balance (UGX)", Width = 160, VisibleIndex = 2 };
        colPrioBalance.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
        colPrioBalance.DisplayFormat.FormatString = "N0";
        colPrioBalance.OptionsColumn.AllowEdit    = false;

        _viewPriority.Columns.AddRange(new[] { colPrio, colGuardianCount, colPrioBalance });
        _viewPriority.CustomUnboundColumnData += ViewPriority_UnboundData;
        _viewPriority.RowStyle += ViewPriority_RowStyle;

        // Section 1 — KPI strip (9 cards)
        _kpiPanel = new FlowLayoutPanel
        {
            Dock          = DockStyle.Top,
            Height        = 200,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents  = true,
            AutoScroll    = false,
        };
        // Row 1: financial totals
        _kpiPanel.Controls.Add(BuildKpiCard(0, "Total Payable (UGX)",     Color.DarkSlateGray));
        _kpiPanel.Controls.Add(BuildKpiCard(1, "Total Collected (UGX)",   Color.DarkGreen));
        _kpiPanel.Controls.Add(BuildKpiCard(2, "Total Outstanding (UGX)", Color.DarkRed));
        _kpiPanel.Controls.Add(BuildKpiCard(3, "Collection Rate (%)",     Color.SeaGreen));
        _kpiPanel.Controls.Add(BuildKpiCard(4, "Total Enrolled",          Color.DimGray));
        _kpiPanel.Controls.Add(BuildKpiCard(11, "Collected This Week (UGX)", Color.SeaGreen));
        // Row 2: follow-up activity (some tiles are clickable)
        _kpiPanel.Controls.Add(BuildKpiCard(5,  "Cleared (Nil Balance)",  Color.ForestGreen));
        _kpiPanel.Controls.Add(BuildKpiCard(6,  "Guardians w/ Balance",   Color.DarkBlue,
            () => NavigationRequested?.Invoke("guardian_worklist")));
        _kpiPanel.Controls.Add(BuildKpiCard(7,  "Today's Remaining",      Color.DarkOrange,
            () => NavigationRequested?.Invoke("daily_worklist")));
        _kpiPanel.Controls.Add(BuildKpiCard(8,  "Broken Promises",        Color.Crimson));
        _kpiPanel.Controls.Add(BuildKpiCard(9,  "Zero Paid",              Color.OrangeRed,
            () => NavigationRequested?.Invoke("student_zeropaid")));
        _kpiPanel.Controls.Add(BuildKpiCard(10, "Term Week",              Color.SlateBlue));

        // Add controls — bottom-docked first, then top-docked in reverse visual order
        this.Controls.Add(lblTop5);
        this.Controls.Add(_gridTop5);
        this.Controls.Add(lblPriority);
        this.Controls.Add(_gridPriority);
        this.Controls.Add(_kpiPanel);

        this.Load += usrFeesFollowUp_Load;
        this.ResumeLayout(false);
    }

    // ── KPI card builder ──────────────────────────────────────────────────────

    private GroupControl BuildKpiCard(int idx, string caption, Color valueColor, Action onClick = null)
    {
        var grp = new GroupControl { Width = 185, Height = 90, Text = caption };
        var lbl = new Label
        {
            Text      = "—",
            Font      = new Font("Tahoma", 16, FontStyle.Bold),
            ForeColor = valueColor,
            Dock      = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        grp.Controls.Add(lbl);
        _kpiValues[idx] = lbl;
        if (onClick != null)
        {
            grp.Cursor = Cursors.Hand;
            lbl.Cursor = Cursors.Hand;
            grp.Click += (s, e) => onClick();
            lbl.Click += (s, e) => onClick();
        }
        return grp;
    }

    // ── Lifecycle ─────────────────────────────────────────────────────────────

    private void usrFeesFollowUp_Load(object sender, EventArgs e) => LoadDashboard();

    // ── Dashboard data ────────────────────────────────────────────────────────

    public void LoadDashboard()
    {
        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(I_Xtreme.DialogForms.WaitForm1));
        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormDescription("Loading Fees Follow-up Dashboard...");
        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SendCommand(I_Xtreme.DialogForms.WaitForm1.WaitFormCommand.LoadFeesFollowUp, 0);
        System.Threading.Thread.Sleep(25);
        try
        {
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
        finally
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
        }
    }

    private void UpdateKpiStrip(DashboardData data)
    {
        // Row 1: financial totals
        _kpiValues[0].Text  = $"{data.TotalPayable:N0}";
        _kpiValues[1].Text  = $"{data.TotalCollected:N0}";
        _kpiValues[2].Text  = $"{data.TotalOutstanding:N0}";
        _kpiValues[3].Text  = $"{data.CollectionRate:F1}%";
        _kpiValues[4].Text  = $"{data.TotalEnrolled}";
        _kpiValues[11].Text = $"{data.CollectedThisWeek:N0}";
        // Row 2: follow-up activity
        _kpiValues[5].Text  = $"{data.NilBalanceStudents}";
        _kpiValues[6].Text  = $"{data.TotalGuardiansWithBalance}";
        _kpiValues[7].Text  = $"{data.DailyListRemaining} / {data.DailyListTotal}";
        _kpiValues[8].Text  = $"{data.BrokenPromiseCount}";
        _kpiValues[9].Text  = $"{data.ZeroPaidStudents}";
        _kpiValues[10].Text = data.TermWeekDisplay;
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
            case PriorityTier.CallRequired:
                e.Appearance.BackColor = Color.DarkSlateBlue;
                e.Appearance.ForeColor = Color.White;
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
        PriorityTier.CallRequired  => "Call Required",
        PriorityTier.Current       => "Up to Date",
        _                          => tier.ToString(),
    };

    // ── Public ribbon API ─────────────────────────────────────────────────────

    public void OpenSettings()
    {
        using var dlg = new FollowUpSettings();
        if (dlg.ShowDialog(this) == DialogResult.OK)
            LoadDashboard();
    }

    public void SendReminders()
    {
        try
        {
            using var dlg = new I_Xtreme.DialogForms.dlgSendRemindersPreview();
            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                LoadDashboard();
        }
        catch (Exception ex)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(
                $"Could not open reminder preview.\n\n{ex.Message}",
                "Fees Follow-up", System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Warning);
        }
    }

    // Stubs kept for legacy ribbon items that reference these
    public void PrintPreviewWorklist() { }
    public void PrintWorklist()        { }
    public void ExportWorklistToExcel() { }
    public void OpenContactView()       { }
}
