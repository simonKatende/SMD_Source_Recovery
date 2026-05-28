using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrFeesFollowUp : XtraUserControl
{
    // ── filter controls ──────────────────────────────────────────────────────
    private ComboBoxEdit cboClass;
    private SpinEdit     spnMinBalance;
    private SimpleButton btnRefresh;

    // ── worklist grid ─────────────────────────────────────────────────────────
    private DevExpress.XtraGrid.GridControl gridWorklist;
    private GridView                        gridViewWorklist;

    // ── state ─────────────────────────────────────────────────────────────────
    private readonly FeesFollowUpService _service = new FeesFollowUpService();
    private bool _columnsConfigured = false;
    private string _currentSemester;

    public usrFeesFollowUp()
    {
        InitializeComponent();
    }

    // ── InitializeComponent ───────────────────────────────────────────────────

    private void InitializeComponent()
    {
        this.SuspendLayout();

        // Filter panel
        var filterPanel = new Panel { Dock = DockStyle.Top, Height = 44 };

        this.cboClass = new ComboBoxEdit();
        this.cboClass.Properties.Items.AddRange(new object[] { "All classes" });
        this.cboClass.SelectedIndex = 0;
        this.cboClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        this.cboClass.Location = new Point(8, 10);
        this.cboClass.Width    = 160;
        filterPanel.Controls.Add(this.cboClass);

        var lblMin = new LabelControl { Text = "Min balance (UGX):", Location = new Point(180, 14) };
        filterPanel.Controls.Add(lblMin);

        this.spnMinBalance = new SpinEdit { Location = new Point(310, 8), Width = 120 };
        this.spnMinBalance.Properties.IsFloatValue = false;
        this.spnMinBalance.Properties.MinValue     = 0;
        this.spnMinBalance.Properties.MaxValue     = 10_000_000;
        this.spnMinBalance.Value = 0;
        filterPanel.Controls.Add(this.spnMinBalance);

        this.btnRefresh = new SimpleButton { Text = "Refresh", Location = new Point(440, 8), Width = 90 };
        this.btnRefresh.Click += (s, e) => LoadWorklist();
        filterPanel.Controls.Add(this.btnRefresh);

        // Worklist grid
        this.gridWorklist     = new DevExpress.XtraGrid.GridControl { Dock = DockStyle.Fill };
        this.gridViewWorklist = new GridView();
        this.gridWorklist.MainView = this.gridViewWorklist;
        this.gridWorklist.ViewCollection.Add(this.gridViewWorklist);

        this.gridViewWorklist.OptionsView.ShowGroupPanel = false;
        this.gridViewWorklist.OptionsBehavior.Editable   = false;
        this.gridViewWorklist.OptionsSelection.EnableAppearanceFocusedRow = true;

        this.gridViewWorklist.CustomUnboundColumnData  += GridViewWorklist_UnboundData;
        this.gridViewWorklist.CustomColumnDisplayText  += GridViewWorklist_CustomColumnDisplayText;
        this.gridViewWorklist.RowStyle                 += GridViewWorklist_RowStyle;
        this.gridViewWorklist.DoubleClick              += GridViewWorklist_DoubleClick;

        this.Controls.Add(this.gridWorklist);
        this.Controls.Add(filterPanel);

        this.Load += usrFeesFollowUp_Load;
        this.ResumeLayout(false);
    }

    // ── Lifecycle ─────────────────────────────────────────────────────────────

    private void usrFeesFollowUp_Load(object sender, EventArgs e) => LoadWorklist();

    // ── Public ribbon API ─────────────────────────────────────────────────────

    public void OpenSettings()
    {
        using var dlg = new FollowUpSettings();
        if (dlg.ShowDialog(this) == DialogResult.OK)
            LoadWorklist();
    }

    public void OpenContactView()
    {
        int handle = gridViewWorklist.FocusedRowHandle;
        if (handle < 0) return;
        var row = gridViewWorklist.GetRow(handle) as GuardianWorklistRow;
        OpenInteraction(row);
    }

    public void PrintPreviewWorklist() => gridWorklist.ShowPrintPreview();

    public void PrintWorklist()
    {
        gridWorklist.ShowPrintPreview();
    }

    public void ExportWorklistToExcel()
    {
        using var dlg = new SaveFileDialog
        {
            Filter   = "Excel files (*.xlsx)|*.xlsx",
            FileName = "FeesFollowUp_Worklist.xlsx",
        };
        if (dlg.ShowDialog() != DialogResult.OK) return;
        gridViewWorklist.ExportToXlsx(dlg.FileName);
    }

    // ── Data ──────────────────────────────────────────────────────────────────

    private void LoadWorklist()
    {
        _columnsConfigured = false;   // reconfigure on each load (class list may change)
        string classFilter = cboClass.SelectedIndex <= 0 ? "" : cboClass.SelectedItem?.ToString() ?? "";
        decimal minBal     = (decimal)spnMinBalance.Value;

        var rows = _service.GetGuardianWorklist(classFilter, minBal);
        gridWorklist.DataSource = rows;
        ConfigureWorklistColumns();

        // Rebuild class combo from distinct classes in returned data
        var classes = rows.SelectMany(r => r.Students).Select(s => s.ClassId)
                          .Where(c => !string.IsNullOrEmpty(c)).Distinct().OrderBy(c => c).ToList();
        string selected = cboClass.SelectedIndex > 0 ? cboClass.SelectedItem?.ToString() : null;
        cboClass.Properties.Items.Clear();
        cboClass.Properties.Items.Add("All classes");
        cboClass.Properties.Items.AddRange(classes.Cast<object>().ToArray());
        cboClass.SelectedIndex = selected != null ? cboClass.Properties.Items.IndexOf(selected) : 0;
        if (cboClass.SelectedIndex < 0) cboClass.SelectedIndex = 0;
    }

    // ── Grid configuration ────────────────────────────────────────────────────

    private void ConfigureWorklistColumns()
    {
        if (_columnsConfigured) return;
        _columnsConfigured = true;

        // # — unbound row counter
        var colNum = new DevExpress.XtraGrid.Columns.GridColumn
        {
            FieldName    = "#",
            Caption      = "#",
            UnboundType  = DevExpress.Data.UnboundColumnType.Integer,
        };
        colNum.OptionsColumn.AllowEdit = false;
        colNum.OptionsColumn.ReadOnly  = true;
        colNum.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
        colNum.Width    = 36;
        colNum.MinWidth = 36;
        colNum.MaxWidth = 36;
        gridViewWorklist.Columns.Add(colNum);
        colNum.VisibleIndex = 0;

        // Hide internal key column
        HideCol("GuardianContact");
        HideCol("Students");
        HideCol("StudentCount");   // shown via unbound caption column below
        HideCol("TotalBilled");
        HideCol("TotalPaid");
        HideCol("PacingGap");
        HideCol("LatestPromiseDate");
        HideCol("LatestPromiseAmount");
        HideCol("PaymentsSinceLatestPromise");

        // Captions
        SetCaption("GuardianLabel",    "Guardian");
        SetCaption("TotalBalance",     "Balance (UGX)");
        SetCaption("PaymentPercent",   "% Paid");
        SetCaption("Tier",             "Priority");
        SetCaption("LastContactDate",  "Last Contact");
        SetCaption("LastOutcome",      "Last Outcome");

        // Format Balance
        var colBal = gridViewWorklist.Columns["TotalBalance"];
        if (colBal != null)
        {
            colBal.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
            colBal.DisplayFormat.FormatString = "N0";
        }

        // Unbound "Students" count column
        var colStudents = new DevExpress.XtraGrid.Columns.GridColumn
        {
            FieldName   = "StudentCountDisplay",
            Caption     = "Students",
            UnboundType = DevExpress.Data.UnboundColumnType.Integer,
        };
        colStudents.OptionsColumn.AllowEdit = false;
        colStudents.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
        colStudents.Width    = 60;
        colStudents.MinWidth = 60;
        colStudents.MaxWidth = 80;
        gridViewWorklist.Columns.Add(colStudents);

        gridViewWorklist.BestFitColumns();

        // Pin # and Students columns
        colNum.Width    = 36;
        colNum.MinWidth = 36;
        colNum.MaxWidth = 36;
        colStudents.Width = 60;
    }

    private void HideCol(string field)
    {
        var c = gridViewWorklist.Columns[field];
        if (c != null) c.Visible = false;
    }

    private void SetCaption(string field, string caption)
    {
        var c = gridViewWorklist.Columns[field];
        if (c != null) c.Caption = caption;
    }

    // ── Grid event handlers ───────────────────────────────────────────────────

    private void GridViewWorklist_UnboundData(object sender,
        DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
    {
        if (!e.IsGetData) return;
        if (e.Column.FieldName == "#")
            e.Value = e.ListSourceRowIndex + 1;
        else if (e.Column.FieldName == "StudentCountDisplay")
        {
            var row = gridViewWorklist.GetRow(e.ListSourceRowIndex) as GuardianWorklistRow;
            e.Value = row?.StudentCount ?? 0;
        }
    }

    private void GridViewWorklist_CustomColumnDisplayText(object sender,
        DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
    {
        if (e.Column.FieldName == "Tier" && e.Value is PriorityTier tier)
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
        else if (e.Column.FieldName == "LastOutcome" && e.Value is ContactOutcome outcome)
        {
            e.DisplayText = outcome switch
            {
                ContactOutcome.Contacted        => "Contacted",
                ContactOutcome.NoAnswer         => "No Answer",
                ContactOutcome.ContactUnavailable => "Unavailable",
                ContactOutcome.ContactOff       => "Phone Off",
                ContactOutcome.Promised         => "Promised",
                ContactOutcome.Refused          => "Refused",
                _                               => e.DisplayText,
            };
        }
        else if (e.Column.FieldName == "PaymentPercent" && e.Value is decimal pct)
        {
            e.DisplayText = $"{pct:F1}%";
        }
    }

    private void GridViewWorklist_RowStyle(object sender,
        DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
    {
        var row = gridViewWorklist.GetRow(e.RowHandle) as GuardianWorklistRow;
        if (row == null) return;
        switch (row.Tier)
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

    private void GridViewWorklist_DoubleClick(object sender, EventArgs e)
    {
        var pt  = gridWorklist.PointToClient(Cursor.Position);
        var hit = gridViewWorklist.CalcHitInfo(pt);
        if (!hit.InRow) return;
        var row = gridViewWorklist.GetRow(hit.RowHandle) as GuardianWorklistRow;
        OpenInteraction(row);
    }

    // ── Interaction dialog helper ─────────────────────────────────────────────

    private void OpenInteraction(GuardianWorklistRow row)
    {
        if (row == null) return;
        var worklist = gridWorklist.DataSource as List<GuardianWorklistRow>
                       ?? new List<GuardianWorklistRow> { row };
        int idx = worklist.IndexOf(row);
        if (idx < 0) idx = 0;
        using var dlg = new dlgFeesContactInteraction(worklist, idx);
        dlg.ShowDialog(this);
        LoadWorklist();   // refresh after contact may have been logged
    }
}
