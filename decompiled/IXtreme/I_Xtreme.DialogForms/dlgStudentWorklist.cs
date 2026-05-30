using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.GeneralReports;
using I_Xtreme.Models;

namespace I_Xtreme.DialogForms;

public class dlgStudentWorklist : XtraForm
{
    private readonly FeesFollowUpService _service = new FeesFollowUpService();
    private List<StudentWorklistRow> _allRows = new List<StudentWorklistRow>();
    private List<string> _allClasses = new List<string>();
    private GridControl _grid;
    private GridView _view;
    private TextEdit _txtSearch;
    private ComboBoxEdit _cboClass;
    private SpinEdit _spnMinBalance;
    private bool _columnsConfigured;
    private bool _classesLoaded;

    public dlgStudentWorklist()
    {
        this.Text          = "Student Worklist — All Students with Outstanding Fees";
        this.Size          = new Size(1350, 680);
        this.StartPosition = FormStartPosition.CenterParent;
        BuildLayout();
        this.Load += (s, e) => LoadData();
    }

    // ── Layout ────────────────────────────────────────────────────────────────

    private void BuildLayout()
    {
        this.SuspendLayout();

        // ── Top panel ─────────────────────────────────────────────────────────
        var topPanel = new Panel { Dock = DockStyle.Top, Height = 48 };

        // Class filter
        var lblClass = new Label
        {
            Text     = "Class:",
            Location = new Point(8, 14),
            AutoSize = true,
        };
        _cboClass = new ComboBoxEdit
        {
            Location = new Point(50, 10),
            Width    = 120,
        };
        _cboClass.Properties.Items.Add("All classes");
        _cboClass.SelectedIndex = 0;
        _cboClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

        // Min balance filter
        var lblMinBal = new Label
        {
            Text     = "Min Balance:",
            Location = new Point(182, 14),
            AutoSize = true,
        };
        _spnMinBalance = new SpinEdit
        {
            Location = new Point(262, 10),
            Width    = 100,
        };
        _spnMinBalance.Properties.MinValue = 0;
        _spnMinBalance.Properties.Increment = 1000;

        // Search box
        _txtSearch = new TextEdit
        {
            Location = new Point(374, 10),
            Width    = 280,
        };
        _txtSearch.Properties.NullText = "Search name, student#, ID, guardian, contact...";
        _txtSearch.EditValueChanged += TxtSearch_EditValueChanged;

        var btnRefresh = new SimpleButton { Text = "Refresh", Width = 80 };
        var btnPrint   = new SimpleButton { Text = "Print",   Width = 80 };
        var btnExport  = new SimpleButton { Text = "Export",  Width = 80 };

        btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Anchor   = AnchorStyles.Top | AnchorStyles.Right;
        btnExport.Anchor  = AnchorStyles.Top | AnchorStyles.Right;

        PositionTopButtons(topPanel, btnRefresh, btnPrint, btnExport);

        topPanel.Controls.AddRange(new Control[] { lblClass, _cboClass, lblMinBal, _spnMinBalance,
            _txtSearch, btnRefresh, btnPrint, btnExport });
        topPanel.Resize += (s, e) => PositionTopButtons(topPanel, btnRefresh, btnPrint, btnExport);

        btnRefresh.Click               += (s, e) => LoadData();
        btnPrint.Click                 += BtnPrint_Click;
        btnExport.Click                += BtnExport_Click;
        _cboClass.SelectedIndexChanged  += (s, e) => LoadData();
        _spnMinBalance.EditValueChanged += (s, e) => LoadData();

        // ── Grid ──────────────────────────────────────────────────────────────
        _grid = new GridControl { Dock = DockStyle.Fill };
        _view = new GridView();
        _grid.MainView = _view;
        _grid.ViewCollection.Add(_view);

        _view.OptionsView.ShowGroupPanel    = false;
        _view.OptionsView.ShowAutoFilterRow = false;
        _view.OptionsBehavior.Editable      = false;
        _view.OptionsDetail.SmartDetailExpand = false;

        _view.RowStyle    += View_RowStyle;
        _view.DoubleClick += View_DoubleClick;

        // ── Assemble ──────────────────────────────────────────────────────────
        this.Controls.Add(_grid);      // Fill
        this.Controls.Add(topPanel);   // Top

        this.ResumeLayout(false);
    }

    private static void PositionTopButtons(Panel panel, params SimpleButton[] buttons)
    {
        int x = panel.ClientSize.Width - 8;
        foreach (var btn in buttons)
        {
            x -= btn.Width;
            btn.Location = new Point(x, 10);
            x -= 4;
        }
    }

    // ── Data ──────────────────────────────────────────────────────────────────

    private void LoadData()
    {
        try
        {
            string classFilter = _cboClass.SelectedIndex <= 0 ? "" : _cboClass.SelectedItem?.ToString() ?? "";
            decimal minBal = _spnMinBalance.Value;

            _allRows = _service.GetStudentWorklist(classFilter, minBal);
            _grid.DataSource = _allRows;
            ConfigureColumns();

            // Only rebuild class list when loading all classes with no balance filter
            if (string.IsNullOrEmpty(classFilter) && _spnMinBalance.Value == 0)
            {
                _allClasses = _allRows
                    .Select(r => r.ClassId)
                    .Where(c => !string.IsNullOrEmpty(c))
                    .Distinct().OrderBy(c => c).ToList();

                string selected = _cboClass.SelectedIndex > 0 ? _cboClass.SelectedItem?.ToString() : null;
                _cboClass.Properties.Items.Clear();
                _cboClass.Properties.Items.Add("All classes");
                _cboClass.Properties.Items.AddRange(_allClasses.Cast<object>().ToArray());
                int idx = selected != null ? _cboClass.Properties.Items.IndexOf(selected) : 0;
                _cboClass.SelectedIndex = idx >= 0 ? idx : 0;
                _classesLoaded = true;
            }
            else if (!_classesLoaded)
            {
                // First load with a non-zero balance — load class list from an unfiltered query
                var allUnfiltered = _service.GetStudentWorklist("", 0);
                _allClasses = allUnfiltered
                    .Select(r => r.ClassId)
                    .Where(c => !string.IsNullOrEmpty(c))
                    .Distinct().OrderBy(c => c).ToList();
                string selected = _cboClass.SelectedIndex > 0 ? _cboClass.SelectedItem?.ToString() : null;
                _cboClass.Properties.Items.Clear();
                _cboClass.Properties.Items.Add("All classes");
                _cboClass.Properties.Items.AddRange(_allClasses.Cast<object>().ToArray());
                int idx = selected != null ? _cboClass.Properties.Items.IndexOf(selected) : 0;
                _cboClass.SelectedIndex = idx >= 0 ? idx : 0;
                _classesLoaded = true;
            }
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not load student worklist.\n\n{ex.Message}",
                "Fees Follow-up", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    // ── Column configuration ──────────────────────────────────────────────────

    private void ConfigureColumns()
    {
        if (_columnsConfigured) return;
        _columnsConfigured = true;

        _view.Columns.Clear();

        // # (row number - unbound int)
        var colNum = _view.Columns.AddField("#");
        colNum.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
        colNum.VisibleIndex = 0; colNum.Width = 36; colNum.OptionsColumn.AllowEdit = false;
        _view.CustomUnboundColumnData += (s, e) => {
            if (e.Column == colNum && e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        };

        AddCol("FullName",        "Name",            180);
        AddCol("StudentNumber",   "Stud#",           100);
        AddCol("StudentId",       "ID",               90);
        AddCol("ClassId",         "Class",            55);
        AddCol("DayBoarder",      "D/B",              42);
        AddNumCol("TotalBilled",  "Payable (UGX)",   100);
        AddNumCol("TotalPaid",    "Paid (UGX)",      100);
        AddNumCol("Balance",      "Balance (UGX)",   100);
        AddPctCol("PaymentPercent", "% Paid",         65);
        AddCol("PaymentStatus",   "Status",           80);
        AddTierCol("Tier",        "Priority",        110);
        AddCol("GuardianLabel",   "Guardian",        160);
        AddCol("GuardianContact", "Contact",         110);
        AddDateCol("LastContactDate", "Last Contact",  95);
        AddOutcomeCol("LastOutcome",  "Last Outcome", 110);
    }

    private GridColumn AddCol(string fieldName, string caption, int width)
    {
        var col = _view.Columns.AddField(fieldName);
        col.Caption = caption;
        col.Width   = width;
        col.OptionsColumn.AllowEdit = false;
        col.VisibleIndex = _view.Columns.Count - 1;
        return col;
    }

    private GridColumn AddNumCol(string fieldName, string caption, int width)
    {
        var col = AddCol(fieldName, caption, width);
        col.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
        col.DisplayFormat.FormatString = "N0";
        return col;
    }

    private void AddPctCol(string fieldName, string caption, int width)
    {
        var col = AddCol(fieldName, caption, width);
        _view.CustomColumnDisplayText += (s, e) =>
        {
            if (e.Column == col && e.Value is decimal pct)
                e.DisplayText = $"{pct:F1}%";
        };
    }

    private void AddTierCol(string fieldName, string caption, int width)
    {
        var col = AddCol(fieldName, caption, width);
        _view.CustomColumnDisplayText += (s, e) =>
        {
            if (e.Column != col) return;
            if (e.Value is PriorityTier tier)
            {
                e.DisplayText = tier switch
                {
                    PriorityTier.Critical      => "Critical",
                    PriorityTier.BrokenPromise => "Missed Promise",
                    PriorityTier.Stale         => "Contact Overdue",
                    PriorityTier.Current       => "Up to Date",
                    _                          => e.DisplayText,
                };
            }
        };
    }

    private void AddDateCol(string fieldName, string caption, int width)
    {
        var col = AddCol(fieldName, caption, width);
        col.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.DateTime;
        col.DisplayFormat.FormatString = "dd-MMM-yyyy";
    }

    private void AddOutcomeCol(string fieldName, string caption, int width)
    {
        var col = AddCol(fieldName, caption, width);
        _view.CustomColumnDisplayText += (s, e) =>
        {
            if (e.Column != col) return;
            if (e.Value is ContactOutcome outcome)
            {
                e.DisplayText = outcome switch
                {
                    ContactOutcome.Contacted          => "Contacted",
                    ContactOutcome.NoAnswer           => "No Answer",
                    ContactOutcome.ContactUnavailable => "Unavailable",
                    ContactOutcome.ContactOff         => "Phone Off",
                    ContactOutcome.Promised           => "Promised",
                    ContactOutcome.Refused            => "Refused",
                    _                                 => e.DisplayText,
                };
            }
        };
    }

    // ── Row coloring ──────────────────────────────────────────────────────────

    private void View_RowStyle(object sender, RowStyleEventArgs e)
    {
        var row = _view.GetRow(e.RowHandle) as StudentWorklistRow;
        if (row == null) return;
        switch (row.Tier)
        {
            case PriorityTier.Critical:
                e.Appearance.BackColor = Color.OrangeRed;
                e.Appearance.ForeColor = Color.White;
                e.HighPriority = true; break;
            case PriorityTier.BrokenPromise:
                e.Appearance.BackColor = Color.LightCoral;
                e.HighPriority = true; break;
            case PriorityTier.Stale:
                e.Appearance.BackColor = Color.LightYellow;
                e.HighPriority = true; break;
        }
    }

    // ── Search ────────────────────────────────────────────────────────────────

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

    // ── Double-click → interaction dialog ────────────────────────────────────

    private void View_DoubleClick(object sender, EventArgs e)
    {
        var pt  = _grid.PointToClient(Cursor.Position);
        var hit = _view.CalcHitInfo(pt);
        if (!hit.InRow) return;
        var row = _view.GetRow(hit.RowHandle) as StudentWorklistRow;
        if (row == null) return;

        // Load full guardian worklist to get the GuardianWorklistRow with students list
        var guardianRows = _service.GetGuardianWorklist("", 0);
        var guardianRow  = guardianRows.FirstOrDefault(g => g.GuardianContact == row.GuardianKey);
        if (guardianRow == null)
        {
            XtraMessageBox.Show("Could not locate the guardian record. Please refresh and try again.",
                "Fees Follow-up", System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Warning);
            return;
        }

        int idx = guardianRows.IndexOf(guardianRow);
        using var dlg = new dlgFeesContactInteraction(guardianRows, idx);
        dlg.ShowDialog(this);
        LoadData();
    }

    // ── Print ─────────────────────────────────────────────────────────────────

    private void BtnPrint_Click(object sender, EventArgs e)
    {
        var rpt  = new rptStudentWorklist(_allRows);
        var tool = new ReportPrintTool(rpt);
        tool.ShowRibbonPreview();
    }

    // ── Export ────────────────────────────────────────────────────────────────

    private void BtnExport_Click(object sender, EventArgs e)
    {
        using var save = new SaveFileDialog
        {
            Filter   = "Excel (*.xlsx)|*.xlsx",
            FileName = $"StudentWorklist_{DateTime.Today:yyyyMMdd}.xlsx",
        };
        if (save.ShowDialog() == DialogResult.OK)
        {
            var btnExport = ((Control)sender);
            btnExport.Enabled = false;
            try { _view.ExportToXlsx(save.FileName); }
            finally { btnExport.Enabled = true; }
        }
    }
}
