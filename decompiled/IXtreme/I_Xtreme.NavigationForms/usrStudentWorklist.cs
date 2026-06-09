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

public class usrStudentWorklist : XtraUserControl
{
    private readonly FeesFollowUpService _service = new FeesFollowUpService();
    private readonly Predicate<StudentWorklistRow> _filter;
    private List<StudentWorklistRow> _allRows = new List<StudentWorklistRow>();
    private GridControl  _grid;
    private GridView     _view;
    private TextEdit     _txtSearch;
    private ComboBoxEdit _cboClass;
    private SpinEdit     _spnMinBalance;
    private bool         _columnsConfigured;
    private bool         _classesLoaded;

    public usrStudentWorklist(Predicate<StudentWorklistRow> filter = null)
    {
        _filter = filter;
        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(I_Xtreme.DialogForms.WaitForm1));
        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormDescription("Loading Student Worklist...");
        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SendCommand(I_Xtreme.DialogForms.WaitForm1.WaitFormCommand.LoadFeesFollowUp, 0);
        System.Threading.Thread.Sleep(25);
        BuildLayout();
        LoadData();
        DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
    }

    private void BuildLayout()
    {
        this.SuspendLayout();

        var topPanel = new Panel { Dock = DockStyle.Top, Height = 48 };

        var lblClass = new Label { Text = "Class:", Location = new Point(8, 14), AutoSize = true };
        _cboClass = new ComboBoxEdit { Location = new Point(50, 10), Width = 120 };
        _cboClass.Properties.Items.Add("All classes");
        _cboClass.SelectedIndex = 0;
        _cboClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

        var lblMin = new Label { Text = "Min Balance:", Location = new Point(182, 14), AutoSize = true };
        _spnMinBalance = new SpinEdit { Location = new Point(262, 10), Width = 100 };
        _spnMinBalance.Properties.MinValue  = 0;
        _spnMinBalance.Properties.Increment = 1000;

        _txtSearch = new TextEdit { Location = new Point(374, 10), Width = 280 };
        _txtSearch.Properties.NullText = "Search name, student#, ID, guardian, contact...";
        _txtSearch.EditValueChanged += TxtSearch_EditValueChanged;

        var btnRefresh = new SimpleButton
        {
            Text     = "Refresh",
            Width    = 70,
            Location = new Point(658, 10),
            Anchor   = AnchorStyles.Top | AnchorStyles.Left,
        };
        topPanel.Controls.AddRange(new Control[] { lblClass, _cboClass, lblMin, _spnMinBalance, _txtSearch, btnRefresh });

        btnRefresh.Click               += (s, e) => LoadData();
        _cboClass.SelectedIndexChanged  += (s, e) => LoadData();
        _spnMinBalance.EditValueChanged += (s, e) => LoadData();

        _grid = new GridControl { Dock = DockStyle.Fill };
        _view = new GridView();
        _grid.MainView = _view;
        _grid.ViewCollection.Add(_view);
        _view.OptionsView.ShowGroupPanel    = false;
        _view.OptionsView.ShowAutoFilterRow = false;
        _view.OptionsBehavior.Editable      = false;
        _view.OptionsDetail.SmartDetailExpand = false;
        _view.RowStyle   += View_RowStyle;
        _view.DoubleClick += View_DoubleClick;

        this.Controls.Add(_grid);
        this.Controls.Add(topPanel);
        this.ResumeLayout(false);
    }

    private void LoadData()
    {
        try
        {
            string cf = _cboClass.SelectedIndex <= 0 ? "" : _cboClass.SelectedItem?.ToString() ?? "";
            decimal mb = _spnMinBalance.Value;

            _allRows = _service.GetStudentWorklist(cf, mb);
            if (_filter != null)
                _allRows = _allRows.Where(r => _filter(r)).ToList();
            _grid.DataSource = _allRows;
            ConfigureColumns();

            if (string.IsNullOrEmpty(cf) && mb == 0)
            {
                var classes = _allRows.Select(r => r.ClassId)
                    .Where(c => !string.IsNullOrEmpty(c)).Distinct().OrderBy(c => c).ToList();
                string sel = _cboClass.SelectedIndex > 0 ? _cboClass.SelectedItem?.ToString() : null;
                _cboClass.Properties.Items.Clear();
                _cboClass.Properties.Items.Add("All classes");
                _cboClass.Properties.Items.AddRange(classes.Cast<object>().ToArray());
                int idx = sel != null ? _cboClass.Properties.Items.IndexOf(sel) : 0;
                _cboClass.SelectedIndex = idx >= 0 ? idx : 0;
                _classesLoaded = true;
            }
            else if (!_classesLoaded)
            {
                var all2 = _service.GetStudentWorklist("", 0);
                var classes = all2.Select(r => r.ClassId)
                    .Where(c => !string.IsNullOrEmpty(c)).Distinct().OrderBy(c => c).ToList();
                _cboClass.Properties.Items.Clear();
                _cboClass.Properties.Items.Add("All classes");
                _cboClass.Properties.Items.AddRange(classes.Cast<object>().ToArray());
                _cboClass.SelectedIndex = 0;
                _classesLoaded = true;
            }
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not load student worklist.\n\n{ex.Message}",
                "Fees Follow-up", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
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

        AddCol("FullName",            "Name",           180);
        AddCol("StudentNumber",       "Stud#",          100);
        AddCol("StudentId",           "ID",              90);
        AddCol("ClassId",             "Class",           55);
        AddCol("DayBoarder",          "D/B",             42);
        AddNumCol("TotalBilled",      "Payable (UGX)",  100);
        AddNumCol("TotalPaid",        "Paid (UGX)",     100);
        AddNumCol("Balance",          "Balance (UGX)",  100);
        AddPctCol("PaymentPercent",   "% Paid",          65);
        AddCol("PaymentStatus",       "Status",          80);
        AddTierCol("Tier",            "Priority",       110);
        AddCol("GuardianLabel",       "Guardian",       160);
        AddCol("GuardianContact",     "Contact",        110);
        AddDateCol("LastContactDate", "Last Contact",    95);
        AddOutcomeCol("LastOutcome",  "Last Outcome",   110);
        AddNumCol("RemindersSentCount", "Reminders",     80);
        AddDateCol("LastReminderDate",  "Last Reminder", 110);
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
        col.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
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
            e.DisplayText = t switch
            {
                PriorityTier.Critical      => "Critical",
                PriorityTier.BrokenPromise => "Missed Promise",
                PriorityTier.Stale         => "Contact Overdue",
                PriorityTier.CallRequired  => "Call Required",
                PriorityTier.Current       => "Up to Date",
                _                          => e.DisplayText,
            };
        };
    }

    private void AddDateCol(string field, string caption, int width)
    {
        var col = AddCol(field, caption, width);
        col.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.DateTime;
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
        var row = _view.GetRow(e.RowHandle) as StudentWorklistRow;
        if (row == null) return;
        switch (row.Tier)
        {
            case PriorityTier.Critical:      e.Appearance.BackColor = Color.FromArgb(252, 228, 228); e.HighPriority = true; break;
            case PriorityTier.BrokenPromise: e.Appearance.BackColor = Color.FromArgb(251, 224, 216); e.HighPriority = true; break;
            case PriorityTier.Stale:         e.Appearance.BackColor = Color.FromArgb(252, 246, 221); e.HighPriority = true; break;
            case PriorityTier.CallRequired:  e.Appearance.BackColor = Color.FromArgb(226, 232, 245); e.HighPriority = true; break;
        }
    }

    private void TxtSearch_EditValueChanged(object sender, EventArgs e)
    {
        string q = (_txtSearch.Text ?? "").Trim().ToLower();
        _grid.DataSource = string.IsNullOrEmpty(q) ? _allRows :
            _allRows.Where(r =>
                r.FullName.ToLower().Contains(q) ||
                r.StudentNumber.Contains(q) ||
                (r.StudentId ?? "").Contains(q) ||
                r.GuardianContact.Contains(q) ||
                r.GuardianLabel.ToLower().Contains(q)
            ).ToList();
    }

    private void View_DoubleClick(object sender, EventArgs e)
    {
        var pt  = _grid.PointToClient(Cursor.Position);
        var hit = _view.CalcHitInfo(pt);
        if (!hit.InRow) return;
        var row = _view.GetRow(hit.RowHandle) as StudentWorklistRow;
        if (row == null) return;

        var guardianRows = _service.GetGuardianWorklist("", 0);
        var guardianRow  = guardianRows.FirstOrDefault(g => g.GuardianContact == row.GuardianKey);
        if (guardianRow == null)
        {
            XtraMessageBox.Show("Could not locate the guardian record. Please refresh and try again.",
                "Fees Follow-up", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        int idx = guardianRows.IndexOf(guardianRow);
        using var dlg = new dlgFeesContactInteraction(guardianRows, idx);
        dlg.ShowDialog(this.FindForm());
        LoadData();
    }

    public void Print(bool preview = false)
    {
        var ps   = new PrintingSystem();
        var link = new PrintableComponentLink(ps);
        if (preview)
            PrintableControl.PreviewControl("Student Worklist", DateTime.Today.ToString("dd-MMM-yyyy"), link, IsLandScape: true, _grid);
        else
            PrintableControl.PrintControl("Student Worklist", DateTime.Today.ToString("dd-MMM-yyyy"), link, IsLandScape: true, _grid);
    }

    public void Export()
    {
        var ps   = new PrintingSystem();
        var link = new PrintableComponentLink(ps);
        PrintableControl.ExportControl("Student Worklist", DateTime.Today.ToString("dd-MMM-yyyy"), link, _grid);
    }
}
