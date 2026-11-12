using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrDailyWorklist : XtraUserControl
{
    private readonly FeesFollowUpService _service = new FeesFollowUpService();
    private List<GuardianWorklistRow> _allRows = new List<GuardianWorklistRow>();
    private GridControl _grid;
    private GridView    _view;
    private TextEdit    _txtSearch;
    private bool        _columnsConfigured;
    private LabelControl _banner;
    private LabelControl _lblProgress;
    private ProgressBarControl _progress;
    private RadioGroup   _rgShow;
    private SimpleButton _btnStart;
    private bool         _loading;

    // Which part of today's list is showing.
    private enum ShowFilter { ToDo, TryAgain, Done, All }

    public usrDailyWorklist()
    {
        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(I_Xtreme.DialogForms.WaitForm1));
        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormDescription("Loading Daily Worklist...");
        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SendCommand(I_Xtreme.DialogForms.WaitForm1.WaitFormCommand.LoadFeesFollowUp, 0);
        System.Threading.Thread.Sleep(25);
        BuildLayout();
        LoadData();
        DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
    }

    private void BuildLayout()
    {
        this.SuspendLayout();

        var topPanel = new Panel { Dock = DockStyle.Top, Height = 84 };

        // Row 1: where the team stands today.
        _progress = new ProgressBarControl { Location = new Point(8, 8), Size = new Size(220, 18) };
        _progress.Properties.Minimum = 0;
        _progress.Properties.Maximum = 100;
        _progress.Properties.ShowTitle = true;
        _progress.Properties.PercentView = true;
        _lblProgress = new LabelControl
        {
            Location = new Point(238, 10), AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(760, 16),
        };
        _lblProgress.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);

        // Row 2: start calling, choose what to see, search.
        _btnStart = new SimpleButton { Text = "Start calling", Width = 110, Location = new Point(8, 44) };
        _btnStart.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
        _btnStart.ToolTip = "Open the next family that has not been called today";
        _btnStart.Click += (s, e) => StartCalling();

        _rgShow = new RadioGroup { Location = new Point(126, 38), Size = new Size(470, 34) };
        _rgShow.Properties.Items.AddRange(new[]
        {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(ShowFilter.ToDo,     "To call"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(ShowFilter.TryAgain, "Try again"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(ShowFilter.Done,     "Done"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(ShowFilter.All,      "All"),
        });
        _rgShow.Properties.Columns = 4;
        _rgShow.EditValue = ShowFilter.ToDo;
        _rgShow.EditValueChanged += (s, e) => { if (!_loading) ApplyView(null); };

        _txtSearch = new TextEdit { Location = new Point(606, 45), Width = 280 };
        _txtSearch.Properties.NullText = "Search guardian name, contact, student...";
        _txtSearch.EditValueChanged += TxtSearch_EditValueChanged;

        var btnRefresh = new SimpleButton
        {
            Text     = "Refresh",
            Width    = 70,
            Location = new Point(892, 44),
            Anchor   = AnchorStyles.Top | AnchorStyles.Left,
        };
        topPanel.Controls.AddRange(new Control[] { _progress, _lblProgress, _btnStart, _rgShow, _txtSearch, btnRefresh });
        btnRefresh.Click += (s, e) => LoadData();

        _grid = new GridControl { Dock = DockStyle.Fill };
        _view = new GridView();
        _grid.MainView = _view;
        _grid.ViewCollection.Add(_view);
        _view.OptionsView.ShowGroupPanel    = false;
        _view.OptionsView.ShowAutoFilterRow = false;
        _view.OptionsBehavior.Editable      = false;
        _view.OptionsDetail.SmartDetailExpand = false;
        _view.RowStyle   += View_RowStyle;
        _view.RowCellStyle += View_RowCellStyle;
        _view.DoubleClick += View_DoubleClick;

        _banner = new LabelControl
        {
            Dock      = DockStyle.Top,
            Visible   = false,
            AutoSizeMode = LabelAutoSizeMode.None,
            Height    = 24,
            Text      = "Term dates are not set for this term, so nobody can be marked Critical. Set them in Follow-up Settings.",
        };
        _banner.Appearance.BackColor = Color.LightGoldenrodYellow;
        _banner.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        this.Controls.Add(_banner);

        this.Controls.Add(_grid);
        this.Controls.Add(topPanel);
        this.ResumeLayout(false);
    }

    private void LoadData() => LoadData(FocusedKey());

    /// <summary>Reload today's list and put the cursor back on the given family (or the next one to call).</summary>
    private void LoadData(string keepKey)
    {
        try
        {
            _allRows = _service.GetDailyWorklist(0);
            _banner.Visible = !_service.AreTermDatesConfigured();
            ConfigureColumns();
            ApplyView(keepKey);
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not load daily worklist.\n\n{ex.Message}",
                "Fees Follow-up", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private string FocusedKey() => (_view?.GetFocusedRow() as GuardianWorklistRow)?.GuardianContact;

    private ShowFilter CurrentFilter => _rgShow.EditValue is ShowFilter f ? f : ShowFilter.ToDo;

    private static bool Matches(GuardianWorklistRow r, ShowFilter filter) => filter switch
    {
        ShowFilter.ToDo     => r.TodayStatus == TodayStatus.NotCalled,
        ShowFilter.TryAgain => r.TodayStatus == TodayStatus.Tried,
        ShowFilter.Done     => r.TodayStatus == TodayStatus.Done,
        _                   => true,
    };

    /// <summary>Show the chosen part of the list, update the progress strip, and restore the cursor.</summary>
    private void ApplyView(string keepKey)
    {
        var progress = DailyListLogic.Progress(_allRows);
        _progress.Position = progress.Percent;
        _lblProgress.Text  = progress.Summary;
        _btnStart.Enabled  = progress.NotCalled + progress.Tried > 0;
        _btnStart.Text     = progress.Worked == 0 ? "Start calling" : "Continue calling";

        // Counts on the choices, so the team sees what is left without switching views.
        _loading = true;
        _rgShow.Properties.Items[0].Description = $"To call ({progress.NotCalled})";
        _rgShow.Properties.Items[1].Description = $"Try again ({progress.Tried})";
        _rgShow.Properties.Items[2].Description = $"Done ({progress.Done})";
        _rgShow.Properties.Items[3].Description = $"All ({progress.Total})";
        // Nothing left to call: show what there is rather than an empty screen.
        if (CurrentFilter == ShowFilter.ToDo && progress.NotCalled == 0 && progress.Total > 0)
            _rgShow.EditValue = progress.Tried > 0 ? ShowFilter.TryAgain : ShowFilter.All;
        _loading = false;

        // EditValue, not Text: an empty DevExpress editor reports its grey prompt as Text.
        string q = (_txtSearch.EditValue as string ?? "").Trim().ToLower();
        var filter = CurrentFilter;
        var shown = _allRows.Where(r => Matches(r, filter) && (q == "" ||
                r.GuardianLabel.ToLower().Contains(q) ||
                r.GuardianContact.Contains(q) ||
                (r.Contact2 ?? "").Contains(q) ||
                r.Students.Any(st => st.FullName.ToLower().Contains(q) || st.StudentNumber.Contains(q))))
            .ToList();
        _grid.DataSource = shown;

        // Back to the family that was selected; otherwise the top row, which is the next to call.
        int index = keepKey == null ? -1 : shown.FindIndex(r => r.GuardianContact == keepKey);
        _view.FocusedRowHandle = index >= 0 ? index : (shown.Count > 0 ? 0 : GridControl.InvalidRowHandle);
        if (index >= 0) _view.MakeRowVisible(index);
    }

    /// <summary>Open the interaction window on the next family not yet called today.</summary>
    private void StartCalling()
    {
        int next = DailyListLogic.NextToWork(_allRows, -1);
        if (next < 0)
        {
            XtraMessageBox.Show("Every family on today's list has been worked.", "Daily Worklist",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        OpenInteraction(next);
    }

    private void OpenInteraction(int index)
    {
        string lastKey;
        using (var dlg = new dlgFeesContactInteraction(_allRows, index, () => _service.GetDailyWorklist(0)))
        {
            dlg.ShowDialog(this.FindForm());
            lastKey = dlg.LastGuardianKey;
        }
        LoadData(lastKey);
    }

    private void ConfigureColumns()
    {
        if (_columnsConfigured) return;
        _columnsConfigured = true;
        _view.Columns.Clear();

        var colNum = _view.Columns.AddField("#");
        colNum.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
        colNum.VisibleIndex = 0; colNum.Width = 36; colNum.OptionsColumn.AllowEdit = false;
        _view.CustomUnboundColumnData += (s, e) => { if (e.Column == colNum && e.IsGetData) e.Value = e.ListSourceRowIndex + 1; };

        AddCol("TodayStatusText",     "Today",          80);
        AddCol("GuardianLabel",       "Guardian",      200);
        _view.CustomColumnDisplayText += (s, e) =>
        {
            if (e.Column.FieldName == "GuardianLabel"
                && _view.GetRow(_view.GetRowHandle(e.ListSourceRowIndex)) is GuardianWorklistRow gr
                && gr.IsUnreachable)
                e.DisplayText = (e.Value?.ToString() ?? "") + "  (no phone)";
        };
        AddCol("PhoneDisplay",        "Contact",       120);
        AddCol("Contact2",            "Alt Contact",   120);
        AddCol("StudentNames",        "Students",      200);
        AddNumCol("TotalBalance",     "Balance (UGX)", 120);
        AddPctCol("PaymentPercent",   "% Paid",         70);
        AddTierCol("Tier",            "Priority",      120);
        AddDateCol("LastContactDate", "Last Contact",  100);
        AddOutcomeCol("LastOutcome",  "Last Outcome",  120);
        AddCol("PromiseStatusText",   "Promise",       190);
    }

    private GridColumn AddCol(string field, string caption, int width)
    {
        var col = _view.Columns.AddField(field);
        col.Caption = caption; col.Width = width;
        col.OptionsColumn.AllowEdit = false;
        col.VisibleIndex = _view.Columns.Count - 1;
        return col;
    }

    private GridColumn AddNumCol(string field, string caption, int width)
    {
        var col = AddCol(field, caption, width);
        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        col.DisplayFormat.FormatString = "N0";
        return col;
    }

    private void AddPctCol(string field, string caption, int width)
    {
        var col = AddCol(field, caption, width);
        _view.CustomColumnDisplayText += (s, e) => { if (e.Column == col && e.Value is decimal p) e.DisplayText = $"{p:F1}%"; };
    }

    private void AddTierCol(string field, string caption, int width)
    {
        var col = AddCol(field, caption, width);
        _view.CustomColumnDisplayText += (s, e) =>
        {
            if (e.Column != col || !(e.Value is PriorityTier t)) return;
            string text = t switch
            {
                PriorityTier.Critical      => "Critical",
                PriorityTier.BrokenPromise => "Missed Promise",
                PriorityTier.Stale         => "Contact Overdue",
                PriorityTier.Current       => "Up to Date",
                _                          => e.DisplayText,
            };
            // Append a marker for the orthogonal CallRequired flag (recent overdue SMS).
            if (_view.GetRow(_view.GetRowHandle(e.ListSourceRowIndex)) is GuardianWorklistRow gr && gr.CallRequired)
                text += " + Call";
            e.DisplayText = text;
        };
    }

    private void AddDateCol(string field, string caption, int width)
    {
        var col = AddCol(field, caption, width);
        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
        col.DisplayFormat.FormatString = "dd-MMM-yyyy";
    }

    private void AddOutcomeCol(string field, string caption, int width)
    {
        var col = AddCol(field, caption, width);
        _view.CustomColumnDisplayText += (s, e) =>
        {
            if (e.Column != col || !(e.Value is ContactOutcome o)) return;
            e.DisplayText = o switch
            {
                ContactOutcome.Contacted          => "Contacted",
                ContactOutcome.NoAnswer           => "No Answer",
                ContactOutcome.ContactUnavailable => "Unavailable",
                ContactOutcome.ContactOff         => "Phone Off",
                ContactOutcome.Promised           => "Promised",
                ContactOutcome.Refused            => "Refused",
                _                                 => e.DisplayText,
            };
        };
    }

    private void View_RowStyle(object sender, RowStyleEventArgs e)
    {
        var row = _view.GetRow(e.RowHandle) as GuardianWorklistRow;
        if (row == null) return;
        switch (row.Tier)
        {
            case PriorityTier.Critical:      e.Appearance.BackColor = Color.FromArgb(252, 228, 228); e.HighPriority = true; break;
            case PriorityTier.BrokenPromise: e.Appearance.BackColor = Color.FromArgb(251, 224, 216); e.HighPriority = true; break;
            case PriorityTier.Stale:         e.Appearance.BackColor = Color.FromArgb(252, 246, 221); e.HighPriority = true; break;
        }
        // CallRequired is a flag orthogonal to the risk tier — colour it from the flag (takes precedence).
        if (row.CallRequired)
        {
            e.Appearance.BackColor = Color.FromArgb(226, 232, 245); e.HighPriority = true;
        }
        if (row.IsUnreachable)
        {
            e.Appearance.ForeColor = Color.Gray;
        }
        // Finished for today: calm and out of the way, whatever the priority colour.
        if (row.TodayStatus == TodayStatus.Done)
        {
            e.Appearance.BackColor = Color.FromArgb(232, 245, 233);
            e.Appearance.ForeColor = Color.DimGray;
            e.HighPriority = true;
        }
    }

    private void View_RowCellStyle(object sender, RowCellStyleEventArgs e)
    {
        if (!(_view.GetRow(e.RowHandle) is GuardianWorklistRow row)) return;
        if (e.Column.FieldName == "TodayStatusText")
        {
            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            e.Appearance.ForeColor = row.TodayStatus switch
            {
                TodayStatus.Done  => Color.ForestGreen,
                TodayStatus.Tried => Color.FromArgb(180, 110, 0),
                _                 => Color.SlateGray,
            };
        }
        else if (e.Column.FieldName == "PromiseStatusText" && (row.PromiseDueToday || (row.Promise != null && row.Promise.IsBroken)))
        {
            e.Appearance.ForeColor = Color.Firebrick;
        }
    }

    private void TxtSearch_EditValueChanged(object sender, EventArgs e) => ApplyView(FocusedKey());

    private void View_DoubleClick(object sender, EventArgs e)
    {
        var pt  = _grid.PointToClient(Cursor.Position);
        var hit = _view.CalcHitInfo(pt);
        if (!hit.InRow) return;
        var row = _view.GetRow(hit.RowHandle) as GuardianWorklistRow;
        if (row == null) return;
        int idx = _allRows.IndexOf(row);
        OpenInteraction(idx < 0 ? 0 : idx);
    }

    public void Print(bool preview = false)
    {
        var ps   = new PrintingSystem();
        var link = new PrintableComponentLink(ps);
        if (preview)
            PrintableControl.PreviewControl("Daily Worklist", DateTime.Today.ToString("dd-MMM-yyyy"), link, IsLandScape: true, _grid);
        else
            PrintableControl.PrintControl("Daily Worklist", DateTime.Today.ToString("dd-MMM-yyyy"), link, IsLandScape: true, _grid);
    }

    public void Export()
    {
        var ps   = new PrintingSystem();
        var link = new PrintableComponentLink(ps);
        PrintableControl.ExportControl("Daily Worklist", DateTime.Today.ToString("dd-MMM-yyyy"), link, _grid);
    }
}
