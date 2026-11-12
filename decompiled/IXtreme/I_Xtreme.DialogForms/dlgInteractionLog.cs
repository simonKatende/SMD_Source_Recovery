using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraTab;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;

namespace I_Xtreme.DialogForms;

/// <summary>
/// Follow-up reports that can be printed or exported to Excel:
///   - Interactions: who was contacted in a date range, and how they responded.
///   - Promises: every promise / payment plan still in force this term, and whether it was kept.
/// </summary>
public class dlgInteractionLog : XtraForm
{
    private XtraTabControl tabs;
    private XtraTabPage    pageInteractions, pagePromises;

    // Interactions tab
    private DateEdit     dteFrom, dteTo;
    private ComboBoxEdit cboOutcome, cboOfficer;
    private SimpleButton btnLoad;
    private GridControl  grid;
    private GridView     view;
    private LabelControl lblSummary;
    private DataTable    _interactions;

    // Promises tab
    private ComboBoxEdit cboPromiseStatus;
    private GridControl  gridPromises;
    private GridView     viewPromises;
    private LabelControl lblPromiseSummary;
    private List<PromiseReportRow> _promises;

    private SimpleButton btnPreview, btnPrint, btnExport, btnClose;

    private const string AllOutcomes = "All responses";
    private const string AllOfficers = "Everyone";
    private const string AllStatuses = "All promises";

    private readonly FeesFollowUpService _service = new FeesFollowUpService();

    public dlgInteractionLog()
    {
        InitializeComponent();
        // Default range = current Sun-Sat school week
        DateTime today      = DateTime.Today;
        DateTime weekSunday = today.AddDays(-(int)today.DayOfWeek);
        dteFrom.EditValue = weekSunday;
        dteTo.EditValue   = weekSunday.AddDays(6);
        LoadInteractions();
    }

    private void InitializeComponent()
    {
        this.ClientSize    = new Size(1180, 640);
        this.MinimumSize   = new Size(900, 480);
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text          = "Follow-up Reports";
        this.MinimizeBox   = false;
        this.MaximizeBox   = true;

        tabs = new XtraTabControl { Dock = DockStyle.Fill };
        pageInteractions = new XtraTabPage { Text = "Parents contacted" };
        pagePromises     = new XtraTabPage { Text = "Promises && payment plans" };
        tabs.TabPages.AddRange(new[] { pageInteractions, pagePromises });
        tabs.SelectedPageChanged += (s, e) =>
        {
            if (e.Page == pagePromises && _promises == null) LoadPromises();
        };

        BuildInteractionsPage();
        BuildPromisesPage();

        // Bottom bar: the three things people ask for.
        var bottom = new Panel { Dock = DockStyle.Bottom, Height = 44 };
        btnPreview = new SimpleButton { Text = "Preview",         Width = 90,  Location = new Point(12, 9) };
        btnPrint   = new SimpleButton { Text = "Print",           Width = 90,  Location = new Point(108, 9) };
        btnExport  = new SimpleButton { Text = "Export to Excel", Width = 120, Location = new Point(204, 9) };
        btnClose   = new SimpleButton { Text = "Close", Width = 90, Anchor = AnchorStyles.Top | AnchorStyles.Right };
        bottom.Resize += (s, e) => btnClose.Location = new Point(bottom.ClientSize.Width - 102, 9);
        btnPreview.Click += (s, e) => Output(preview: true);
        btnPrint.Click   += (s, e) => Output(preview: false);
        btnExport.Click  += (s, e) => Export();
        btnClose.Click   += (s, e) => Close();
        bottom.Controls.AddRange(new Control[] { btnPreview, btnPrint, btnExport, btnClose });

        this.Controls.Add(tabs);
        this.Controls.Add(bottom);
        this.CancelButton = btnClose;
    }

    // ── Interactions tab ──────────────────────────────────────────────────────

    private void BuildInteractionsPage()
    {
        var top = new Panel { Dock = DockStyle.Top, Height = 66 };

        var lblFrom = new LabelControl { Text = "From:", Location = new Point(10, 14) };
        dteFrom = new DateEdit { Location = new Point(46, 10), Width = 112 };
        var lblTo = new LabelControl { Text = "To:", Location = new Point(170, 14) };
        dteTo = new DateEdit { Location = new Point(192, 10), Width = 112 };

        var btnToday = new SimpleButton { Text = "Today", Location = new Point(316, 9), Width = 62 };
        btnToday.Click += (s, e) => SetRange(DateTime.Today, DateTime.Today);
        var btnWeek = new SimpleButton { Text = "This week", Location = new Point(382, 9), Width = 76 };
        btnWeek.Click += (s, e) =>
        {
            DateTime sun = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            SetRange(sun, sun.AddDays(6));
        };
        var btnMonth = new SimpleButton { Text = "This month", Location = new Point(462, 9), Width = 82 };
        btnMonth.Click += (s, e) =>
        {
            var first = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            SetRange(first, first.AddMonths(1).AddDays(-1));
        };

        var lblOutcome = new LabelControl { Text = "Response:", Location = new Point(560, 14) };
        cboOutcome = new ComboBoxEdit { Location = new Point(616, 10), Width = 150 };
        cboOutcome.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        cboOutcome.Properties.Items.Add(AllOutcomes);
        foreach (ContactOutcome o in Enum.GetValues(typeof(ContactOutcome)))
            cboOutcome.Properties.Items.Add(dlgFeesContactInteraction.OutcomeText(o));
        cboOutcome.SelectedIndex = 0;
        cboOutcome.SelectedIndexChanged += (s, e) => ApplyInteractionFilter();

        var lblOfficer = new LabelControl { Text = "Logged by:", Location = new Point(780, 14) };
        cboOfficer = new ComboBoxEdit { Location = new Point(840, 10), Width = 130 };
        cboOfficer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        cboOfficer.Properties.Items.Add(AllOfficers);
        cboOfficer.SelectedIndex = 0;
        cboOfficer.SelectedIndexChanged += (s, e) => ApplyInteractionFilter();

        btnLoad = new SimpleButton { Text = "Show", Location = new Point(984, 9), Width = 70 };
        btnLoad.Click += (s, e) => LoadInteractions();

        lblSummary = new LabelControl
        {
            Location = new Point(10, 42), AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(1100, 16),
        };
        lblSummary.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);

        top.Controls.AddRange(new Control[]
        {
            lblFrom, dteFrom, lblTo, dteTo, btnToday, btnWeek, btnMonth,
            lblOutcome, cboOutcome, lblOfficer, cboOfficer, btnLoad, lblSummary,
        });

        grid = new GridControl { Dock = DockStyle.Fill };
        view = new GridView();
        grid.MainView = view;
        grid.ViewCollection.Add(view);
        view.OptionsView.ShowGroupPanel     = false;
        view.OptionsView.ShowAutoFilterRow  = true;
        view.OptionsView.RowAutoHeight      = true;
        view.OptionsBehavior.Editable       = false;
        view.OptionsPrint.AutoWidth         = true;

        var colDate = AddCol(view, "ContactDate", "Date", 110);
        colDate.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.DateTime;
        colDate.DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm";
        AddCol(view, "GuardianDisplay", "Parent / Guardian", 150);
        AddCol(view, "Phone",           "Phone",             95);
        AddCol(view, "StudentName",     "Children",          170);
        AddCol(view, "Classes",         "Class",             70);
        AddCol(view, "Channel",         "How",               60);
        AddCol(view, "OutcomeText",     "Response",          115);
        var colNote = AddCol(view, "Note", "Notes", 220);
        colNote.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit { WordWrap = true };
        AddCol(view, "PaymentPlan",     "Promise / payment plan", 170);
        AddMoneyCol(view, "FamilyBalance", "Balance now (UGX)", 105);
        AddCol(view, "LoggedBy",        "Logged by",         85);
        AddCol(view, "Term",            "Term",              85);

        pageInteractions.Controls.Add(grid);
        pageInteractions.Controls.Add(top);
    }

    private void SetRange(DateTime from, DateTime to)
    {
        dteFrom.EditValue = from;
        dteTo.EditValue   = to;
        LoadInteractions();
    }

    private void LoadInteractions()
    {
        DateTime from = dteFrom.DateTime == DateTime.MinValue ? DateTime.Today : dteFrom.DateTime.Date;
        DateTime to   = dteTo.DateTime   == DateTime.MinValue ? DateTime.Today : dteTo.DateTime.Date;
        if (to < from)
        {
            XtraMessageBox.Show("The 'To' date must be on or after the 'From' date.", "Follow-up Reports",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Cursor = Cursors.WaitCursor;
        try
        {
            _interactions = _service.GetInteractionsReport(from, to);
            _interactions.Columns.Add("OutcomeText", typeof(string));
            foreach (DataRow row in _interactions.Rows)
                row["OutcomeText"] = Enum.TryParse(row["Outcome"]?.ToString(), out ContactOutcome oc)
                    ? dlgFeesContactInteraction.OutcomeText(oc) : row["Outcome"]?.ToString();

            // Officers who logged something in this range
            string keep = cboOfficer.SelectedItem as string ?? AllOfficers;
            cboOfficer.Properties.Items.Clear();
            cboOfficer.Properties.Items.Add(AllOfficers);
            foreach (string officer in _interactions.AsEnumerable()
                         .Select(r => (r["LoggedBy"] as string ?? "").Trim())
                         .Where(n => n != "").Distinct().OrderBy(n => n))
                cboOfficer.Properties.Items.Add(officer);
            cboOfficer.SelectedItem = cboOfficer.Properties.Items.Contains(keep) ? keep : AllOfficers;

            ApplyInteractionFilter();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not load the interactions.\n\n{ex.Message}", "Follow-up Reports",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private static string Quote(string value) => "'" + (value ?? "").Replace("'", "''") + "'";

    private void ApplyInteractionFilter()
    {
        if (_interactions == null) return;
        var filters = new List<string>();
        if (cboOutcome.SelectedIndex > 0) filters.Add($"OutcomeText = {Quote(cboOutcome.Text)}");
        if (cboOfficer.SelectedIndex > 0) filters.Add($"LoggedBy = {Quote(cboOfficer.Text)}");

        var dv = new DataView(_interactions) { RowFilter = string.Join(" AND ", filters) };
        grid.DataSource = dv;

        int total    = dv.Count;
        int families = dv.Cast<DataRowView>().Select(r => r["GuardianKey"]?.ToString()).Distinct().Count();
        int reached  = dv.Cast<DataRowView>().Count(r =>
            r["Outcome"]?.ToString() is "Contacted" or "Promised" or "Refused");
        var promises = dv.Cast<DataRowView>().Where(r => r["Outcome"]?.ToString() == "Promised").ToList();
        decimal promised = promises.Sum(r => r["PromiseAmount"] == DBNull.Value ? 0m : Convert.ToDecimal(r["PromiseAmount"]));
        lblSummary.Text = total == 0
            ? "Nothing was logged in this period."
            : $"{total} interaction(s) with {families} family(ies)   ·   {reached} reached   ·   " +
              $"{promises.Count} promise(s)" + (promised > 0 ? $" worth UGX {promised:N0}" : "");
    }

    // ── Promises tab ──────────────────────────────────────────────────────────

    private void BuildPromisesPage()
    {
        var top = new Panel { Dock = DockStyle.Top, Height = 66 };
        var lblShow = new LabelControl { Text = "Show:", Location = new Point(10, 14) };
        cboPromiseStatus = new ComboBoxEdit { Location = new Point(46, 10), Width = 170 };
        cboPromiseStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        cboPromiseStatus.Properties.Items.AddRange(new object[]
            { AllStatuses, "Still to be paid", "Missed", "Kept", "Due in the next 7 days" });
        cboPromiseStatus.SelectedIndex = 0;
        cboPromiseStatus.SelectedIndexChanged += (s, e) => ApplyPromiseFilter();

        var btnRefresh = new SimpleButton { Text = "Refresh", Location = new Point(228, 9), Width = 70 };
        btnRefresh.Click += (s, e) => LoadPromises();

        var lblHint = new LabelControl
        {
            Text = "Promises still in force this term. A promise replaced by a newer one is not listed.",
            Location = new Point(312, 14),
        };
        lblHint.Appearance.ForeColor = Color.DimGray;

        lblPromiseSummary = new LabelControl
        {
            Location = new Point(10, 42), AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(1100, 16),
        };
        lblPromiseSummary.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
        top.Controls.AddRange(new Control[] { lblShow, cboPromiseStatus, btnRefresh, lblHint, lblPromiseSummary });

        gridPromises = new GridControl { Dock = DockStyle.Fill };
        viewPromises = new GridView();
        gridPromises.MainView = viewPromises;
        gridPromises.ViewCollection.Add(viewPromises);
        viewPromises.OptionsView.ShowGroupPanel    = false;
        viewPromises.OptionsView.ShowAutoFilterRow = true;
        viewPromises.OptionsView.ShowFooter        = true;
        viewPromises.OptionsBehavior.Editable      = false;
        viewPromises.OptionsPrint.AutoWidth        = true;

        AddCol(viewPromises, "GuardianLabel", "Parent / Guardian", 160);
        AddCol(viewPromises, "Phone",         "Phone",             95);
        AddCol(viewPromises, "Students",      "Children",          180);
        AddCol(viewPromises, "Classes",       "Class",             70);
        AddCol(viewPromises, "PromiseFor",    "Promise for",       100);
        var due = AddCol(viewPromises, "DueDate", "Pay by", 90);
        due.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.DateTime;
        due.DisplayFormat.FormatString = "dd-MMM-yyyy";
        AddMoneyCol(viewPromises, "AmountPromised",    "Promised (UGX)",   105, total: true);
        AddMoneyCol(viewPromises, "AmountPaid",        "Paid (UGX)",       100, total: true);
        AddMoneyCol(viewPromises, "AmountOutstanding", "Still due (UGX)",  105, total: true);
        AddCol(viewPromises, "StatusText",    "Status",            95);
        AddMoneyCol(viewPromises, "FamilyBalance",     "Balance now (UGX)", 110);
        var logged = AddCol(viewPromises, "LoggedOn", "Promised on", 90);
        logged.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.DateTime;
        logged.DisplayFormat.FormatString = "dd-MMM-yyyy";
        AddCol(viewPromises, "LoggedBy",      "Logged by",         85);

        viewPromises.RowStyle += (s, e) =>
        {
            if (viewPromises.GetRow(e.RowHandle) is PromiseRowView row)
            {
                if (row.Status == "Missed")    e.Appearance.BackColor = Color.FromArgb(251, 224, 216);
                else if (row.Status == "Kept") e.Appearance.BackColor = Color.FromArgb(226, 243, 228);
                else if (row.DueDate.Date == DateTime.Today) e.Appearance.BackColor = Color.FromArgb(252, 246, 221);
            }
        };

        pagePromises.Controls.Add(gridPromises);
        pagePromises.Controls.Add(top);
    }

    // Adds the plain-language status to a report row for display, printing and export.
    private sealed class PromiseRowView : PromiseReportRow
    {
        public string StatusText => Status switch
        {
            "Kept"    => "Kept",
            "Missed"  => "Missed",
            "Pending" => DueDate.Date == DateTime.Today ? "Due today" : "To be paid",
            _         => Status,
        };

        public PromiseRowView(PromiseReportRow r)
        {
            GuardianLabel = r.GuardianLabel; Phone = r.Phone; Students = r.Students; Classes = r.Classes;
            PromiseFor = r.PromiseFor; LoggedOn = r.LoggedOn; LoggedBy = r.LoggedBy; DueDate = r.DueDate;
            AmountPromised = r.AmountPromised; AmountPaid = r.AmountPaid; AmountOutstanding = r.AmountOutstanding;
            Status = r.Status; FamilyBalance = r.FamilyBalance;
        }
    }

    private void LoadPromises()
    {
        Cursor = Cursors.WaitCursor;
        try
        {
            _promises = _service.GetPromiseReport();
            ApplyPromiseFilter();
        }
        catch (Exception ex)
        {
            _promises = null;
            XtraMessageBox.Show($"Could not load the promises.\n\n{ex.Message}", "Follow-up Reports",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void ApplyPromiseFilter()
    {
        if (_promises == null) return;
        DateTime today = DateTime.Today;
        IEnumerable<PromiseReportRow> rows = cboPromiseStatus.SelectedIndex switch
        {
            1 => _promises.Where(r => r.Status == "Pending"),
            2 => _promises.Where(r => r.Status == "Missed"),
            3 => _promises.Where(r => r.Status == "Kept"),
            4 => _promises.Where(r => r.Status == "Pending" && r.DueDate.Date <= today.AddDays(7)),
            _ => _promises,
        };
        var shown = rows.Select(r => new PromiseRowView(r)).ToList();
        gridPromises.DataSource = shown;

        lblPromiseSummary.Text = shown.Count == 0
            ? "No promises to show."
            : $"{shown.Count} promise line(s)   ·   " +
              $"Kept: {shown.Count(r => r.Status == "Kept")}   ·   " +
              $"To be paid: {shown.Count(r => r.Status == "Pending")} (UGX {shown.Where(r => r.Status == "Pending").Sum(r => r.AmountOutstanding):N0})   ·   " +
              $"Missed: {shown.Count(r => r.Status == "Missed")} (UGX {shown.Where(r => r.Status == "Missed").Sum(r => r.AmountOutstanding):N0})";
    }

    // ── Grid helpers ──────────────────────────────────────────────────────────

    private static GridColumn AddCol(GridView v, string field, string caption, int width)
    {
        var col = new GridColumn
        {
            FieldName    = field,
            Caption      = caption,
            Width        = width,
            VisibleIndex = v.Columns.Count,
        };
        col.OptionsColumn.AllowEdit = false;
        v.Columns.Add(col);
        return col;
    }

    private static GridColumn AddMoneyCol(GridView v, string field, string caption, int width, bool total = false)
    {
        var col = AddCol(v, field, caption, width);
        col.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
        col.DisplayFormat.FormatString = "N0";
        if (total)
        {
            col.SummaryItem.SummaryType   = DevExpress.Data.SummaryItemType.Sum;
            col.SummaryItem.DisplayFormat = "{0:N0}";
        }
        return col;
    }

    // ── Print / export ────────────────────────────────────────────────────────

    private (GridControl grid, string title, string subtitle) CurrentReport()
    {
        if (tabs.SelectedTabPage == pagePromises)
            return (gridPromises, "Promises and Payment Plans",
                $"{FeesTerm.DisplayName(_service.GetWorkingSemester())}  -  {cboPromiseStatus.Text}  -  as at {DateTime.Today:dd-MMM-yyyy}");

        string who = cboOfficer.SelectedIndex > 0 ? $"  -  logged by {cboOfficer.Text}" : "";
        string what = cboOutcome.SelectedIndex > 0 ? $"  -  {cboOutcome.Text}" : "";
        return (grid, "Parents Contacted",
            $"{dteFrom.DateTime:dd-MMM-yyyy} to {dteTo.DateTime:dd-MMM-yyyy}{what}{who}");
    }

    private bool HasRows(GridControl g)
    {
        if (g.MainView is GridView gv && gv.RowCount > 0) return true;
        XtraMessageBox.Show("There is nothing to print or export yet.", "Follow-up Reports",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        return false;
    }

    private void Output(bool preview)
    {
        var (g, title, subtitle) = CurrentReport();
        if (!HasRows(g)) return;
        try
        {
            var link = new PrintableComponentLink(new PrintingSystem());
            if (preview) PrintableControl.PreviewControl(title, subtitle, link, IsLandScape: true, g);
            else         PrintableControl.PrintControl(title, subtitle, link, IsLandScape: true, g);
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not print the report \"{title}\".\n\n{ex.Message}", "Follow-up Reports",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void Export()
    {
        var (g, title, subtitle) = CurrentReport();
        if (!HasRows(g)) return;
        try
        {
            var link = new PrintableComponentLink(new PrintingSystem());
            PrintableControl.ExportControl(title, subtitle, link, g);
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not export the report \"{title}\".\n\n{ex.Message}", "Follow-up Reports",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
