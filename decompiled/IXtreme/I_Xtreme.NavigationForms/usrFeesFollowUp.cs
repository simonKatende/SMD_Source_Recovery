using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

/// <summary>
/// The Fees Follow-up dashboard: where collections stand, what the team has done today,
/// what parents have promised, and where the money is still outstanding.
/// </summary>
public class usrFeesFollowUp : XtraUserControl
{
    public event Action<string> NavigationRequested;

    // ── Tiles ─────────────────────────────────────────────────────────────────
    private sealed class Tile
    {
        public Label Value;
        public Label Sub;
        public Color NormalColor;
    }
    private readonly Dictionary<string, Tile> _tiles = new Dictionary<string, Tile>();
    private FlowLayoutPanel _kpiPanel;
    private LabelControl    _banner;
    private LabelControl    _lblHeader;

    // ── Detail tabs ───────────────────────────────────────────────────────────
    private XtraTabControl _tabs;
    private GridControl _gridClass, _gridWeekly, _gridPromises, _gridPriority, _gridTop5, _gridTeam;
    private GridView    _viewClass, _viewWeekly, _viewPromises, _viewPriority, _viewTop5, _viewTeam;
    private ChartControl _chart;
    private LabelControl _lblTrendNote;

    // ── State ─────────────────────────────────────────────────────────────────
    private readonly FeesFollowUpService _service = new FeesFollowUpService();
    // Terms for which the "dates not set" question has already been asked in this session.
    private static readonly HashSet<string> _askedAboutTerm = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    public usrFeesFollowUp()
    {
        InitializeComponent();
    }

    // ── Layout ────────────────────────────────────────────────────────────────

    private void InitializeComponent()
    {
        this.SuspendLayout();

        // Detail tabs (Fill)
        _tabs = new XtraTabControl { Dock = DockStyle.Fill };
        var pageClass    = new XtraTabPage { Text = "Collection by class" };
        var pageTrend    = new XtraTabPage { Text = "Week by week" };
        var pagePromises = new XtraTabPage { Text = "Promises" };
        var pageChase    = new XtraTabPage { Text = "Who to chase" };
        var pageTeam     = new XtraTabPage { Text = "Team activity" };
        _tabs.TabPages.AddRange(new[] { pageClass, pageTrend, pagePromises, pageChase, pageTeam });

        BuildClassPage(pageClass);
        BuildTrendPage(pageTrend);
        BuildPromisesPage(pagePromises);
        BuildChasePage(pageChase);
        BuildTeamPage(pageTeam);

        // Tiles (Top, grows with its content)
        _kpiPanel = new FlowLayoutPanel
        {
            Dock          = DockStyle.Top,
            AutoSize      = true,
            AutoSizeMode  = AutoSizeMode.GrowAndShrink,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents  = true,
            Padding       = new Padding(4, 0, 4, 4),
        };

        AddSection("Money");
        AddTile("payable",     "Total Payable (UGX)",       Color.DarkSlateGray);
        AddTile("collected",   "Collected (UGX)",           Color.DarkGreen);
        AddTile("outstanding", "Outstanding (UGX)",         Color.DarkRed);
        AddTile("rate",        "Collected So Far (%)",      Color.SeaGreen);
        AddTile("week",        "Collected This Week (UGX)", Color.SeaGreen);
        AddTile("behind",      "Behind Target (UGX)",       Color.DarkRed);

        AddSection("Follow-up today");
        AddTile("daily",     "Today's Calls",           Color.DarkOrange,
            () => NavigationRequested?.Invoke("daily_worklist"));
        AddTile("guardians", "Families Owing",          Color.DarkBlue,
            () => NavigationRequested?.Invoke("guardian_worklist"));
        AddTile("zeropaid",  "Students Paid Nothing",   Color.OrangeRed,
            () => NavigationRequested?.Invoke("student_zeropaid"));
        AddTile("cleared",   "Students Cleared",        Color.ForestGreen);
        AddTile("enrolled",  "Students Billed",         Color.DimGray);
        AddTile("termweek",  "Week of Term",            Color.SlateBlue);

        AddSection("Promises and reminders");
        AddTile("duetoday", "Promises Due Today",        Color.DarkOrange, OpenReports);
        AddTile("dueweek",  "Due in Next 7 Days",        Color.SteelBlue,  OpenReports);
        AddTile("missed",   "Missed Promises",           Color.Crimson,    OpenReports);
        AddTile("keptrate", "Promises Kept (%)",         Color.ForestGreen, OpenReports);
        AddTile("sms",      "Reminders Sent This Week",  Color.SlateBlue);
        AddTile("auto",     "Automatic Reminders",       Color.DimGray, OpenSettings);

        // Header (Top)
        var header = new Panel { Dock = DockStyle.Top, Height = 34 };
        _lblHeader = new LabelControl { Location = new Point(10, 8), AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(820, 18) };
        _lblHeader.Appearance.Font = new Font("Tahoma", 10.5f, FontStyle.Bold);
        var btnRefresh = new SimpleButton { Text = "Refresh", Width = 76, Location = new Point(840, 5) };
        btnRefresh.Click += (s, e) => LoadDashboard();
        header.Controls.AddRange(new Control[] { _lblHeader, btnRefresh });

        // Banner (Top)
        _banner = new LabelControl
        {
            Dock         = DockStyle.Top,
            Visible      = false,
            AutoSizeMode = LabelAutoSizeMode.None,
            Height       = 26,
            Cursor       = Cursors.Hand,
        };
        _banner.Appearance.BackColor = Color.LightGoldenrodYellow;
        _banner.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
        _banner.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        _banner.Click += (s, e) => OpenSettings();

        // Fill first, then top-docked in reverse visual order.
        this.Controls.Add(_tabs);
        this.Controls.Add(_kpiPanel);
        this.Controls.Add(header);
        this.Controls.Add(_banner);

        this.Load += usrFeesFollowUp_Load;
        this.ResumeLayout(false);
    }

    private void AddSection(string title)
    {
        var lbl = new Label
        {
            Text      = title.ToUpperInvariant(),
            Font      = new Font("Tahoma", 7.5f, FontStyle.Bold),
            ForeColor = Color.Gray,
            AutoSize  = false,
            Size      = new Size(600, 16),
            Margin    = new Padding(4, 6, 3, 0),
        };
        // Start each section on its own line.
        if (_kpiPanel.Controls.Count > 0)
            _kpiPanel.SetFlowBreak(_kpiPanel.Controls[_kpiPanel.Controls.Count - 1], true);
        _kpiPanel.Controls.Add(lbl);
        _kpiPanel.SetFlowBreak(lbl, true);
    }

    private void AddTile(string key, string caption, Color valueColor, Action onClick = null)
    {
        var grp = new GroupControl { Width = 178, Height = 78, Text = caption, Margin = new Padding(3, 2, 3, 2) };
        var value = new Label
        {
            Text      = "—",
            Font      = new Font("Tahoma", 14, FontStyle.Bold),
            ForeColor = valueColor,
            Dock      = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        var sub = new Label
        {
            Text      = "",
            Font      = new Font("Tahoma", 7.5f),
            ForeColor = Color.DimGray,
            Dock      = DockStyle.Bottom,
            Height    = 15,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        grp.Controls.Add(value);
        grp.Controls.Add(sub);
        _tiles[key] = new Tile { Value = value, Sub = sub, NormalColor = valueColor };
        if (onClick != null)
        {
            foreach (Control c in new Control[] { grp, value, sub })
            {
                c.Cursor = Cursors.Hand;
                c.Click += (s, e) => onClick();
            }
            grp.AppearanceCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Underline);
        }
        _kpiPanel.Controls.Add(grp);
    }

    private void SetTile(string key, string value, string sub = "", Color? color = null)
    {
        var t = _tiles[key];
        t.Value.Text      = value;
        t.Sub.Text        = sub ?? "";
        t.Value.ForeColor = color ?? t.NormalColor;
    }

    private static GridView NewGrid(Control parent, out GridControl grid, DockStyle dock = DockStyle.Fill)
    {
        grid = new GridControl { Dock = dock };
        var view = new GridView();
        grid.MainView = view;
        grid.ViewCollection.Add(view);
        view.OptionsView.ShowGroupPanel       = false;
        view.OptionsView.ShowIndicator        = false;
        view.OptionsBehavior.Editable         = false;
        view.OptionsDetail.SmartDetailExpand  = false;
        parent.Controls.Add(grid);
        return view;
    }

    private static GridColumn Col(GridView view, string field, string caption, int width, string format = null)
    {
        var col = new GridColumn { FieldName = field, Caption = caption, Width = width, VisibleIndex = view.Columns.Count };
        col.OptionsColumn.AllowEdit = false;
        if (format != null)
        {
            col.DisplayFormat.FormatType = format.StartsWith("d", StringComparison.Ordinal) && format.Contains("MMM")
                ? DevExpress.Utils.FormatType.DateTime : DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = format;
        }
        view.Columns.Add(col);
        return col;
    }

    private static void Total(GridView view, string field, string format = "{0:N0}")
    {
        view.OptionsView.ShowFooter = true;
        view.Columns[field].SummaryItem.SummaryType   = DevExpress.Data.SummaryItemType.Sum;
        view.Columns[field].SummaryItem.DisplayFormat = format;
    }

    private void BuildClassPage(XtraTabPage page)
    {
        _viewClass = NewGrid(page, out _gridClass);
        Col(_viewClass, "ClassId",     "Class",             90);
        Col(_viewClass, "Students",    "Students",          70);
        Col(_viewClass, "Billed",      "Payable (UGX)",     130, "N0");
        Col(_viewClass, "Paid",        "Collected (UGX)",   130, "N0");
        Col(_viewClass, "Outstanding", "Outstanding (UGX)", 130, "N0");
        Col(_viewClass, "PercentPaid", "% Collected",       90,  "F1");
        Col(_viewClass, "Cleared",     "Cleared",           70);
        Col(_viewClass, "ZeroPaid",    "Paid nothing",      90);
        foreach (string f in new[] { "Students", "Billed", "Paid", "Outstanding", "Cleared", "ZeroPaid" }) Total(_viewClass, f);
        // Classes furthest behind are listed first; shade the ones under the line needed today.
        _viewClass.RowCellStyle += (s, e) =>
        {
            if (e.Column.FieldName != "PercentPaid") return;
            if (!(_viewClass.GetRow(e.RowHandle) is ClassCollectionRow row)) return;
            if (_requiredToday > 0 && row.PercentPaid < _requiredToday)
                e.Appearance.ForeColor = Color.Firebrick;
            else
                e.Appearance.ForeColor = Color.ForestGreen;
            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
        };
    }

    private double _requiredToday;

    private void BuildTrendPage(XtraTabPage page)
    {
        _chart = new ChartControl { Dock = DockStyle.Fill };
        _chart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
        _chart.Legend.AlignmentVertical   = LegendAlignmentVertical.BottomOutside;
        _chart.Legend.Direction           = LegendDirection.LeftToRight;
        page.Controls.Add(_chart);

        _viewWeekly = NewGrid(page, out _gridWeekly, DockStyle.Bottom);
        _gridWeekly.Height = 170;
        Col(_viewWeekly, "Week",          "Week",                 60);
        Col(_viewWeekly, "WeekStarting",  "Week starting",        110, "dd-MMM-yyyy");
        Col(_viewWeekly, "Collected",     "Collected (UGX)",      140, "N0");
        Col(_viewWeekly, "CumulativePct", "Collected so far (%)", 140, "F1");
        Col(_viewWeekly, "RequiredPct",   "Needed by then (%)",   140, "F1");
        Col(_viewWeekly, "GapPct",        "Ahead / behind (pts)", 140, "+0.0;-0.0;0.0");
        _viewWeekly.RowCellStyle += (s, e) =>
        {
            if (e.Column.FieldName == "GapPct" && _viewWeekly.GetRow(e.RowHandle) is WeeklyCollectionRow row)
                e.Appearance.ForeColor = row.GapPct < 0 ? Color.Firebrick : Color.ForestGreen;
        };

        _lblTrendNote = new LabelControl
        {
            Dock = DockStyle.Top, AutoSizeMode = LabelAutoSizeMode.None, Height = 22,
            Text = "  Set the term dates in Follow-up Settings to see collections week by week.",
        };
        _lblTrendNote.Appearance.ForeColor = Color.DimGray;
        page.Controls.Add(_lblTrendNote);
    }

    // One line of the promises summary grid.
    private sealed class PipelineRow
    {
        public string  Line   { get; set; }
        public int     Count  { get; set; }
        public decimal Amount { get; set; }
    }

    private void BuildPromisesPage(XtraTabPage page)
    {
        _viewPromises = NewGrid(page, out _gridPromises);
        Col(_viewPromises, "Line",   "Promises this term", 260);
        Col(_viewPromises, "Count",  "How many",           100);
        Col(_viewPromises, "Amount", "Amount (UGX)",       160, "N0");

        var bar = new Panel { Dock = DockStyle.Top, Height = 36 };
        var btn = new SimpleButton { Text = "Open the promises report…", Location = new Point(8, 6), Width = 190 };
        btn.Click += (s, e) => OpenReports();
        var hint = new LabelControl { Text = "Print or export the full list of promises and payment plans.", Location = new Point(208, 11) };
        hint.Appearance.ForeColor = Color.DimGray;
        bar.Controls.AddRange(new Control[] { btn, hint });
        page.Controls.Add(bar);
    }

    private void BuildChasePage(XtraTabPage page)
    {
        var right = new Panel { Dock = DockStyle.Fill };
        _viewTop5 = NewGrid(right, out _gridTop5);
        Col(_viewTop5, "GuardianLabel",     "Largest balances — guardian", 220);
        Col(_viewTop5, "TotalBalance",      "Balance (UGX)",               130, "N0");
        Col(_viewTop5, "StudentCount",      "Students",                     70);
        var tier = Col(_viewTop5, "TierDisplay", "Priority", 130);
        tier.UnboundType = DevExpress.Data.UnboundColumnType.String;
        Col(_viewTop5, "PromiseStatusText", "Promise",                     200);
        _viewTop5.CustomUnboundColumnData += ViewTop5_UnboundData;
        _viewTop5.RowStyle += ViewTop5_RowStyle;

        var left = new Panel { Dock = DockStyle.Left, Width = 440 };
        _viewPriority = NewGrid(left, out _gridPriority);
        var prio = Col(_viewPriority, "TierDisplay", "Priority", 170);
        prio.UnboundType = DevExpress.Data.UnboundColumnType.String;
        Col(_viewPriority, "GuardianCount", "Families",            90);
        Col(_viewPriority, "TotalBalance",  "They owe (UGX)",     160, "N0");
        _viewPriority.CustomUnboundColumnData += ViewPriority_UnboundData;
        _viewPriority.RowStyle += ViewPriority_RowStyle;

        page.Controls.Add(right);
        page.Controls.Add(left);
    }

    private void BuildTeamPage(XtraTabPage page)
    {
        _viewTeam = NewGrid(page, out _gridTeam);
        Col(_viewTeam, "Officer",          "Officer",                    180);
        Col(_viewTeam, "ContactsToday",    "Contacts today",             110);
        Col(_viewTeam, "ContactsThisWeek", "Contacts this week",         130);
        Col(_viewTeam, "ReachedThisWeek",  "Parents reached this week",  170);
        Col(_viewTeam, "PromisesThisWeek", "Promises this week",         130);
        Col(_viewTeam, "PromisedThisWeek", "Amount promised (UGX)",      160, "N0");
        foreach (string f in new[] { "ContactsToday", "ContactsThisWeek", "ReachedThisWeek", "PromisesThisWeek", "PromisedThisWeek" })
            Total(_viewTeam, f);
    }

    // ── Lifecycle ─────────────────────────────────────────────────────────────

    private void usrFeesFollowUp_Load(object sender, EventArgs e) => LoadDashboard();

    // ── Dashboard data ────────────────────────────────────────────────────────

    public void LoadDashboard()
    {
        DashboardData data = null;
        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(I_Xtreme.DialogForms.WaitForm1));
        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormDescription("Loading Fees Follow-up Dashboard...");
        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SendCommand(I_Xtreme.DialogForms.WaitForm1.WaitFormCommand.LoadFeesFollowUp, 0);
        System.Threading.Thread.Sleep(25);
        try
        {
            data = _service.GetDashboardData();
            UpdateHeader(data);
            UpdateTiles(data);
            UpdateTabs(data);
        }
        catch (Exception ex)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
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

        // New term in the application and its dates not entered yet: remind once per session.
        if (data != null && data.TermDatesNeedSetting && _askedAboutTerm.Add(data.TermName))
        {
            if (XtraMessageBox.Show(
                    $"The application is now working in {data.TermName}, but the start and end dates for this term " +
                    "have not been entered in Fees Follow-up.\n\n" +
                    "Until they are set, the system cannot tell which families are falling behind.\n\n" +
                    "Enter the term dates now?",
                    "Fees Follow-up — new term", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                OpenSettings();
        }
    }

    private void UpdateHeader(DashboardData data)
    {
        string week = data.TermDatesConfigured && data.CurrentTermWeek > 0
            ? $"   ·   Week {data.CurrentTermWeek} of {data.TotalTermWeeks}"
            : "";
        _lblHeader.Text = $"{data.TermName}{week}   ·   as at {data.AsOf:dd-MMM-yyyy HH:mm}";
        _banner.Visible = !data.TermDatesConfigured;
        _banner.Text    = $"The dates for {data.TermName} have not been set, so nobody can be marked Critical. Click here to set them.";
    }

    private void UpdateTiles(DashboardData data)
    {
        bool dated = data.TermDatesConfigured;
        _requiredToday = dated ? data.RequiredRateToday : 0.0;

        // Money
        SetTile("payable",     $"{data.TotalPayable:N0}");
        SetTile("collected",   $"{data.TotalCollected:N0}");
        SetTile("outstanding", $"{data.TotalOutstanding:N0}", $"{data.TotalGuardiansWithBalance} families");
        bool behindLine = dated && (double)data.CollectionRate < data.RequiredRateToday;
        SetTile("rate", $"{data.CollectionRate:F1}%",
            dated ? $"needed by today: {data.RequiredRateToday:F1}%" : "",
            behindLine ? Color.Firebrick : (Color?)null);
        SetTile("week",   $"{data.CollectedThisWeek:N0}");
        SetTile("behind", dated ? $"{data.AmountBehindPace:N0}" : "—",
            dated ? $"on course for {data.ProjectedCollectionRate:F1}% (goal {data.CollectionGoalPercent:F0}%)" : "set the term dates",
            dated && data.AmountBehindPace == 0 ? Color.ForestGreen : (Color?)null);

        // Follow-up today
        int worked = data.DailyListContacted + data.DailyListTried;
        SetTile("daily", $"{worked} / {data.DailyListTotal}",
            data.DailyListTotal == 0 ? "nobody to call today"
                : $"{data.DailyListContacted} done · {data.DailyListTried} to try again",
            data.DailyListTotal > 0 && worked >= data.DailyListTotal ? Color.ForestGreen : (Color?)null);
        SetTile("guardians", $"{data.TotalGuardiansWithBalance}");
        SetTile("zeropaid",  $"{data.ZeroPaidStudents}");
        SetTile("cleared",   $"{data.NilBalanceStudents}", $"of {data.TotalEnrolled} students");
        SetTile("enrolled",  $"{data.TotalEnrolled}");
        SetTile("termweek",  dated && data.CurrentTermWeek > 0 ? $"{data.CurrentTermWeek} / {data.TotalTermWeeks}" : "—",
            dated ? (data.CurrentTermWeek > 0 ? $"{data.TermProgress * 100:F0}% of term gone" : "term not started") : "set the term dates");

        // Promises and reminders
        var p = data.Promises;
        SetTile("duetoday", $"{p.DueTodayCount}",    p.DueTodayCount > 0 ? $"UGX {p.DueTodayAmount:N0}" : "");
        SetTile("dueweek",  $"{p.DueThisWeekCount}", p.DueThisWeekCount > 0 ? $"UGX {p.DueThisWeekAmount:N0}" : "");
        SetTile("missed",   $"{p.MissedCount}",      p.MissedCount > 0 ? $"UGX {p.MissedAmount:N0}" : "",
            p.MissedCount == 0 ? Color.ForestGreen : (Color?)null);
        SetTile("keptrate", p.KeptCount + p.MissedCount == 0 ? "—" : $"{p.KeptRatePercent:F0}%",
            $"{p.KeptCount} kept · {p.MissedCount} missed");
        SetTile("sms", $"{data.RemindersSentThisWeek}", $"{data.RemindersSentToday} today");
        SetTile("auto", data.AutoRemindersEnabled ? "On" : "Off",
            data.AutoRemindersEnabled
                ? (data.LastAutoReminderRun.HasValue ? $"last ran {data.LastAutoReminderRun:dd-MMM HH:mm}" : $"daily at {data.AutoReminderTime}")
                : "click to switch on",
            data.AutoRemindersEnabled ? Color.ForestGreen : (Color?)null);
    }

    private void UpdateTabs(DashboardData data)
    {
        _gridClass.DataSource = data.ByClass;

        // Week by week
        _gridWeekly.DataSource = data.WeeklyTrend;
        _lblTrendNote.Visible  = !data.TermDatesConfigured;
        _chart.Series.Clear();
        if (data.WeeklyTrend.Count > 0)
        {
            var actual = new Series("Collected so far (%)", ViewType.Line);
            var needed = new Series("Needed by then (%)",   ViewType.Line);
            foreach (var w in data.WeeklyTrend)
            {
                actual.Points.Add(new SeriesPoint($"Wk {w.Week}", Math.Round(w.CumulativePct, 1)));
                needed.Points.Add(new SeriesPoint($"Wk {w.Week}", Math.Round(w.RequiredPct, 1)));
            }
            ((LineSeriesView)actual.View).Color = Color.SeaGreen;
            ((LineSeriesView)actual.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((LineSeriesView)needed.View).Color = Color.IndianRed;
            ((LineSeriesView)needed.View).LineStyle.DashStyle = DashStyle.Dash;
            _chart.Series.AddRange(new[] { actual, needed });
            if (_chart.Diagram is XYDiagram diagram)
            {
                diagram.AxisY.Title.Text = "% of fees collected";
                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            }
        }

        // Promises
        var p = data.Promises;
        _gridPromises.DataSource = new List<PipelineRow>
        {
            new PipelineRow { Line = "Families with a promise in force", Count = p.FamiliesWithPromise, Amount = p.PendingAmount + p.MissedAmount },
            new PipelineRow { Line = "Due today",                         Count = p.DueTodayCount,       Amount = p.DueTodayAmount },
            new PipelineRow { Line = "Due in the next 7 days",            Count = p.DueThisWeekCount,    Amount = p.DueThisWeekAmount },
            new PipelineRow { Line = "Still to be paid (all dates)",      Count = p.PendingCount,        Amount = p.PendingAmount },
            new PipelineRow { Line = "Kept",                              Count = p.KeptCount,           Amount = p.KeptAmount },
            new PipelineRow { Line = "Missed",                            Count = p.MissedCount,         Amount = p.MissedAmount },
        };

        _gridPriority.DataSource = data.ByPriority;
        _gridTop5.DataSource     = data.TopByBalance;
        _gridTeam.DataSource     = data.TeamActivity;
    }

    // ── Grid unbound columns ──────────────────────────────────────────────────

    private void ViewPriority_UnboundData(object sender,
        DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
    {
        if (!e.IsGetData || e.Column.FieldName != "TierDisplay") return;
        var row = _viewPriority.GetRow(_viewPriority.GetRowHandle(e.ListSourceRowIndex)) as PriorityGroupStats;
        e.Value = TierDisplayName(row?.Tier ?? PriorityTier.Current);
    }

    private void ViewTop5_UnboundData(object sender,
        DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
    {
        if (!e.IsGetData || e.Column.FieldName != "TierDisplay") return;
        var row = _viewTop5.GetRow(_viewTop5.GetRowHandle(e.ListSourceRowIndex)) as GuardianWorklistRow;
        string text = TierDisplayName(row?.Tier ?? PriorityTier.Current);
        if (row != null && row.CallRequired) text += " + Call";
        e.Value = text;
    }

    // ── Grid row styles (same soft colours as the worklists) ──────────────────

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
        // CallRequired is a flag orthogonal to the risk tier — colour it from the flag (takes precedence).
        if (row.CallRequired)
        {
            e.Appearance.BackColor = Color.FromArgb(226, 232, 245);
            e.HighPriority = true;
        }
    }

    private static void ApplyTierStyle(DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e, PriorityTier tier)
    {
        switch (tier)
        {
            case PriorityTier.Critical:
                e.Appearance.BackColor = Color.FromArgb(252, 228, 228);
                e.HighPriority = true;
                break;
            case PriorityTier.BrokenPromise:
                e.Appearance.BackColor = Color.FromArgb(251, 224, 216);
                e.HighPriority = true;
                break;
            case PriorityTier.Stale:
                e.Appearance.BackColor = Color.FromArgb(252, 246, 221);
                e.HighPriority = true;
                break;
            case PriorityTier.CallRequired:
                e.Appearance.BackColor = Color.FromArgb(226, 232, 245);
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
        try
        {
            using var dlg = new FollowUpSettings();
            if (dlg.ShowDialog(this) == DialogResult.OK)
                LoadDashboard();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not open Follow-up Settings.\n\n{ex.Message}", "Fees Follow-up",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void OpenReports()
    {
        try
        {
            using var dlg = new dlgInteractionLog();
            dlg.ShowDialog(this);
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not open the follow-up reports.\n\n{ex.Message}", "Fees Follow-up",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
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

    public void SendBalanceReminders()
    {
        try
        {
            using var dlg = new I_Xtreme.DialogForms.dlgSendRemindersPreview(
                I_Xtreme.DialogForms.dlgSendRemindersPreview.ReminderMode.Balance);
            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                LoadDashboard();
        }
        catch (Exception ex)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(
                $"Could not open balance reminders.\n\n{ex.Message}",
                "Send Balance Reminders", System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Warning);
        }
    }

    // Stubs kept for legacy ribbon items that reference these
    public void PrintPreviewWorklist() { }
    public void PrintWorklist()        { }
    public void ExportWorklistToExcel() { }
    public void OpenContactView()       { }
}
