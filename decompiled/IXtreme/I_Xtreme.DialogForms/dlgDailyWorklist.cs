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

public class dlgDailyWorklist : XtraForm
{
    private readonly FeesFollowUpService _service = new FeesFollowUpService();
    private List<GuardianWorklistRow> _allRows = new List<GuardianWorklistRow>();
    private GridControl _grid;
    private GridView _view;
    private TextEdit _txtSearch;
    private bool _columnsConfigured;

    public dlgDailyWorklist()
    {
        this.Text          = $"Daily Follow-up Worklist — {DateTime.Today:dd-MMM-yyyy}";
        this.Size          = new Size(1150, 680);
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

        _txtSearch = new TextEdit
        {
            Location = new Point(8, 10),
            Width    = 320,
        };
        _txtSearch.Properties.NullText = "Search guardian name, contact, student...";
        _txtSearch.EditValueChanged += TxtSearch_EditValueChanged;

        var btnRefresh = new SimpleButton { Text = "Refresh", Width = 80 };
        var btnPrint   = new SimpleButton { Text = "Print",   Width = 80 };
        var btnExport  = new SimpleButton { Text = "Export",  Width = 80 };

        btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Anchor   = AnchorStyles.Top | AnchorStyles.Right;
        btnExport.Anchor  = AnchorStyles.Top | AnchorStyles.Right;

        // Position buttons on the right at design time; will be repositioned in Resize
        PositionTopButtons(topPanel, btnRefresh, btnPrint, btnExport);

        topPanel.Controls.AddRange(new Control[] { _txtSearch, btnRefresh, btnPrint, btnExport });
        topPanel.Resize += (s, e) => PositionTopButtons(topPanel, btnRefresh, btnPrint, btnExport);

        btnRefresh.Click += (s, e) => LoadData();
        btnPrint.Click   += BtnPrint_Click;
        btnExport.Click  += BtnExport_Click;

        // ── Grid ──────────────────────────────────────────────────────────────
        _grid = new GridControl { Dock = DockStyle.Fill };
        _view = new GridView();
        _grid.MainView = _view;
        _grid.ViewCollection.Add(_view);

        _view.OptionsView.ShowGroupPanel        = false;
        _view.OptionsView.ShowAutoFilterRow     = false;
        _view.OptionsBehavior.Editable          = false;

        _view.RowStyle   += View_RowStyle;
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
            _allRows = _service.GetDailyWorklist(0);
            _grid.DataSource = _allRows;
            ConfigureColumns();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not load daily worklist.\n\n{ex.Message}",
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

        AddCol("GuardianLabel",    "Guardian",       200);
        AddCol("GuardianContact",  "Contact",        120);
        AddCol("Contact2",         "Alt Contact",    120);
        AddCol("StudentNames",     "Students",       200);
        AddNumCol("TotalBalance",  "Balance (UGX)",  120);
        AddPctCol("PaymentPercent", "% Paid",         70);
        AddTierCol("Tier",         "Priority",       120);
        AddDateCol("LastContactDate", "Last Contact", 100);
        AddOutcomeCol("LastOutcome",  "Last Outcome", 120);
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
        col.DisplayFormat.FormatString = "{0:dd-MMM-yyyy}";
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
        var row = _view.GetRow(e.RowHandle) as GuardianWorklistRow;
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
                r.GuardianLabel.ToLower().Contains(q) ||
                r.GuardianContact.Contains(q) ||
                (r.Contact2 ?? "").Contains(q) ||
                r.Students.Any(st =>
                    st.FullName.ToLower().Contains(q) ||
                    st.StudentNumber.Contains(q) ||
                    (st.StudentId ?? "").Contains(q))
            ).ToList();
    }

    // ── Double-click → interaction dialog ────────────────────────────────────

    private void View_DoubleClick(object sender, EventArgs e)
    {
        var pt  = _grid.PointToClient(Cursor.Position);
        var hit = _view.CalcHitInfo(pt);
        if (!hit.InRow) return;
        var row = _view.GetRow(hit.RowHandle) as GuardianWorklistRow;
        if (row == null) return;

        // Find row in _allRows (not filtered list) to pass full worklist for navigation
        int idx = _allRows.IndexOf(row);
        if (idx < 0) idx = 0;
        using var dlg = new dlgFeesContactInteraction(_allRows, idx);
        dlg.ShowDialog(this);
        LoadData();   // refresh — contacted rows may disappear from daily list
    }

    // ── Print ─────────────────────────────────────────────────────────────────

    private void BtnPrint_Click(object sender, EventArgs e)
    {
        var rpt  = new rptDailyWorklist(_allRows);
        var tool = new ReportPrintTool(rpt);
        tool.ShowRibbonPreview();
    }

    // ── Export ────────────────────────────────────────────────────────────────

    private void BtnExport_Click(object sender, EventArgs e)
    {
        using var save = new SaveFileDialog
        {
            Filter   = "Excel (*.xlsx)|*.xlsx",
            FileName = $"DailyWorklist_{DateTime.Today:yyyyMMdd}.xlsx",
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
