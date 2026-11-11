using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;

namespace I_Xtreme.DialogForms;

public class dlgFeesContactInteraction : XtraForm
{
    // ── Navigation ────────────────────────────────────────────────────────────
    private SimpleButton btnPrev, btnNext;
    private LabelControl lblTitle;
    private DevExpress.XtraEditors.SearchLookUpEdit _searchEdit;

    // ── Info panel (structured header) ────────────────────────────────────────
    private Panel        _infoPanel;
    private Label        _lblGuardianName, _lblContacts, _lblBalance, _lblBalanceRight, _lblTier;
    private Label        _lblToday, _lblPromise;
    private ComboBoxEdit _cboSmsStyle;
    private bool         _loadingRow;

    // ── Students grid ─────────────────────────────────────────────────────────
    private DevExpress.XtraGrid.GridControl gridStudents;
    private GridView                        gridViewStudents;

    // ── History grid ──────────────────────────────────────────────────────────
    private DevExpress.XtraGrid.GridControl gridHistory;
    private GridView                        gridViewHistory;

    // ── Contact log form ──────────────────────────────────────────────────────
    private DevExpress.XtraEditors.RadioGroup rgChannel;
    private DateEdit      dteContactDate;
    private LabelControl  lblContactDate;
    private LabelControl  lblOutcome;
    private ComboBoxEdit  cboOutcome;
    private MemoEdit      memoNote;
    private LabelControl  lblPromiseDate, lblPromiseAmount;
    private DateEdit      dtePromiseDate;
    private SpinEdit      txtPromiseAmount;
    private SimpleButton  btnSave, btnSaveNext, btnClear;
    private ComboBoxEdit  _cboPromiseStudent;
    private LabelControl  _lblPromiseStudent;

    // ── Payment plan (one or more dated instalments) ──────────────────────────
    private class InstalmentRow
    {
        public DateTime? DueDate { get; set; }
        public decimal?  Amount  { get; set; }
    }
    private const string WholeFamily = "Whole family";
    private System.ComponentModel.BindingList<InstalmentRow> _plan = new System.ComponentModel.BindingList<InstalmentRow>();
    private DevExpress.XtraGrid.GridControl gridPlan;
    private GridView                        gridViewPlan;
    private LabelControl  lblPlan, lblPlanTotal;
    private SimpleButton  btnAddInstalment, btnRemoveInstalment;

    // ── State ─────────────────────────────────────────────────────────────────
    private readonly List<GuardianWorklistRow> _worklist;
    private int _currentIndex;
    private int _editContactId = -1;
    private readonly FeesFollowUpService _service = new FeesFollowUpService();
    private readonly Func<List<GuardianWorklistRow>> _reloadRows;

    /// <summary>The guardian key showing when the window closed, so the list can return to it.</summary>
    public string LastGuardianKey => _worklist.Count > 0 ? Current.GuardianContact : null;

    /// <param name="reloadRows">Fetches fresh rows after a save so the family shown is up to date
    /// (defaults to the guardian worklist of families owing).</param>
    public dlgFeesContactInteraction(List<GuardianWorklistRow> worklist, int startIndex,
        Func<List<GuardianWorklistRow>> reloadRows = null)
    {
        _reloadRows   = reloadRows ?? (() => _service.GetGuardianWorklist("", 0));
        _worklist     = worklist;
        _currentIndex = Math.Max(0, Math.Min(startIndex, worklist.Count - 1));
        InitializeComponent();
        LoadCurrent();
    }

    private GuardianWorklistRow Current => _worklist[_currentIndex];

    // ── InitializeComponent ───────────────────────────────────────────────────

    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.Text            = "Contact Interaction";
        this.Size            = new Size(900, 760);
        this.StartPosition   = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.Sizable;

        // ── Navigation bar ────────────────────────────────────────────────────
        var navBar = new System.Windows.Forms.TableLayoutPanel
        {
            Dock        = DockStyle.Top,
            Height      = 44,
            ColumnCount = 3,
            RowCount    = 1,
            Padding     = new Padding(4),
        };
        navBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));   // Prev
        navBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));   // Search
        navBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));   // Next

        this.btnPrev = new SimpleButton { Text = "← Prev", Dock = DockStyle.Fill };
        this.btnPrev.Click += (s, e) => Navigate(-1);

        this.btnNext = new SimpleButton { Text = "Next →", Dock = DockStyle.Fill };
        this.btnNext.Click += (s, e) => Navigate(+1);

        // Search lookup
        this._searchEdit = new DevExpress.XtraEditors.SearchLookUpEdit { Dock = DockStyle.Fill };
        this._searchEdit.Properties.DataSource    = _worklist;
        this._searchEdit.Properties.DisplayMember = "GuardianLabel";
        this._searchEdit.Properties.ValueMember   = "GuardianContact";
        this._searchEdit.Properties.NullText      = "Search by guardian name, contact, or student...";
        var slv = this._searchEdit.Properties.View;
        slv.OptionsView.ShowGroupPanel          = false;
        slv.OptionsBehavior.AutoPopulateColumns = false;
        slv.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            { FieldName = "GuardianLabel",   Caption = "Guardian",  Width = 200, VisibleIndex = 0 });
        slv.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            { FieldName = "GuardianContact", Caption = "Contact",   Width = 120, VisibleIndex = 1 });
        slv.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            { FieldName = "StudentNames",    Caption = "Students",  Width = 280, VisibleIndex = 2 });
        this._searchEdit.EditValueChanged += (s2, e2) =>
        {
            if (this._searchEdit.EditValue == null || this._searchEdit.EditValue == DBNull.Value) return;
            string contact = this._searchEdit.EditValue.ToString();
            int idx = _worklist.FindIndex(g => g.GuardianContact == contact);
            if (idx >= 0 && idx != _currentIndex) { _currentIndex = idx; LoadCurrent(); }
        };

        navBar.Controls.Add(btnPrev,       0, 0);
        navBar.Controls.Add(_searchEdit,   1, 0);
        navBar.Controls.Add(btnNext,       2, 0);

        // ── Info panel (structured header) ────────────────────────────────────
        this._infoPanel = new Panel
        {
            Dock      = DockStyle.Top,
            Height    = 104,
            BackColor = Color.FromArgb(245, 245, 245),
        };

        this._lblGuardianName = new Label
        {
            Font     = new Font("Tahoma", 13, FontStyle.Bold),
            Location = new Point(8, 6),
            AutoSize = true,
        };
        this._lblContacts = new Label
        {
            Font      = new Font("Consolas", 11),
            Location  = new Point(8, 32),
            AutoSize  = true,
            ForeColor = Color.Navy,
        };
        this._lblBalance = new Label
        {
            Font      = new Font("Tahoma", 9),
            ForeColor = Color.DimGray,
            Location  = new Point(8, 58),
            AutoSize  = true,
        };
        // Right-side balance — large, bold, right-anchored
        this._lblBalanceRight = new Label
        {
            Font      = new Font("Tahoma", 18, FontStyle.Bold),
            ForeColor = Color.DarkRed,
            AutoSize  = true,
            Anchor    = AnchorStyles.Top | AnchorStyles.Right,
        };
        // Priority tier badge — right-anchored below balance
        this._lblTier = new Label
        {
            Font      = new Font("Tahoma", 9, FontStyle.Bold),
            AutoSize  = true,
            Padding   = new Padding(6, 2, 6, 2),
            Anchor    = AnchorStyles.Top | AnchorStyles.Right,
        };
        // Today's status and promise position — the two things an officer needs at a glance.
        this._lblToday = new Label
        {
            Font     = new Font("Tahoma", 9, FontStyle.Bold),
            Location = new Point(8, 80),
            AutoSize = true,
            Padding  = new Padding(6, 2, 6, 2),
        };
        this._lblPromise = new Label
        {
            Font      = new Font("Tahoma", 9),
            Location  = new Point(130, 82),
            AutoSize  = true,
            ForeColor = Color.FromArgb(60, 60, 60),
        };
        // How this family wants its fees SMS — remembered once chosen.
        var lblSmsStyle = new Label
        {
            Text = "SMS to this family:", Font = new Font("Tahoma", 8.25f), AutoSize = true,
            Anchor = AnchorStyles.Top | AnchorStyles.Right, Name = "lblSmsStyle",
        };
        this._cboSmsStyle = new ComboBoxEdit { Width = 190, Anchor = AnchorStyles.Top | AnchorStyles.Right };
        this._cboSmsStyle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        this._cboSmsStyle.Properties.Items.AddRange(new object[] { "One message, family total", "Separate message per child" });
        this._cboSmsStyle.SelectedIndexChanged += CboSmsStyle_SelectedIndexChanged;

        this._infoPanel.Controls.AddRange(new Control[]
        {
            _lblGuardianName, _lblContacts, _lblBalance, _lblBalanceRight, _lblTier,
            _lblToday, _lblPromise, lblSmsStyle, _cboSmsStyle,
        });
        this._infoPanel.Resize += (s, e) =>
        {
            if (_lblBalanceRight != null)
                _lblBalanceRight.Location = new Point(
                    _infoPanel.ClientSize.Width - _lblBalanceRight.Width - 12, 20);
            if (_lblTier != null)
                _lblTier.Location = new Point(
                    _infoPanel.ClientSize.Width - _lblTier.Width - 12, 56);
            if (_cboSmsStyle != null)
            {
                _cboSmsStyle.Location = new Point(_infoPanel.ClientSize.Width - _cboSmsStyle.Width - 12, 78);
                var lbl = _infoPanel.Controls["lblSmsStyle"];
                if (lbl != null) lbl.Location = new Point(_cboSmsStyle.Left - lbl.Width - 6, 82);
            }
        };

        // ── Contact log panel (Bottom) ─────────────────────────────────────────
        var logPanel = new Panel { Dock = DockStyle.Bottom, Height = 246 };

        var lblChannel = new LabelControl { Text = "Channel:", Location = new Point(8, 10) };
        this.rgChannel = new DevExpress.XtraEditors.RadioGroup();
        this.rgChannel.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[]
        {
            new(ContactChannel.SMS,      "SMS"),
            new(ContactChannel.Phone,    "Phone"),
            new(ContactChannel.InPerson, "In person"),
        });
        this.rgChannel.Properties.Columns = 3;
        this.rgChannel.SelectedIndex = 1;    // Phone
        this.rgChannel.Location = new Point(70, 4);
        this.rgChannel.Size     = new Size(280, 36);
        this.rgChannel.EditValueChanged += RgChannel_EditValueChanged;

        this.lblContactDate = new LabelControl { Text = "Date:", Location = new Point(360, 12) };
        this.dteContactDate = new DateEdit
        {
            Location  = new Point(392, 6),
            Width     = 120,
            EditValue = DateTime.Today,
        };

        this.lblOutcome = new LabelControl { Text = "Outcome:", Location = new Point(8, 52) };

        this.cboOutcome = new ComboBoxEdit();
        this.cboOutcome.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        foreach (ContactOutcome o in Enum.GetValues(typeof(ContactOutcome)))
            this.cboOutcome.Properties.Items.Add(new OutcomeItem(o));
        this.cboOutcome.SelectedIndex = -1;
        this.cboOutcome.Location      = new Point(70, 46);
        this.cboOutcome.Width         = 200;
        this.cboOutcome.SelectedIndexChanged += (s, e) =>
            ShowPromiseControls(SelectedOutcome == ContactOutcome.Promised);

        // Promise date/amount editors are kept (hidden) for compatibility; the payment plan
        // grid below is what the officer fills in.
        this.lblPromiseDate   = new LabelControl { Text = "Promise date:",   Location = new Point(282, 52), Visible = false };
        this.dtePromiseDate   = new DateEdit     { Location = new Point(370, 47), Width = 120, Visible = false };
        this.lblPromiseAmount = new LabelControl { Text = "Promise amount:", Location = new Point(500, 52), Visible = false };
        this.txtPromiseAmount = new SpinEdit     { Location = new Point(600, 47), Width = 110, Visible = false };
        this.txtPromiseAmount.Properties.IsFloatValue = true;
        this.txtPromiseAmount.Properties.MaskSettings.Set("mask", "N0");

        this._lblPromiseStudent = new LabelControl
        {
            Text     = "Promise is for:",
            Location = new System.Drawing.Point(290, 52),
            Visible  = false,
        };
        this._cboPromiseStudent = new ComboBoxEdit
        {
            Location = new System.Drawing.Point(376, 47),
            Width    = 240,
            Visible  = false,
        };
        this._cboPromiseStudent.Properties.TextEditStyle =
            DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

        this.memoNote = new MemoEdit { Location = new Point(8, 80), Size = new Size(430, 118) };
        this.memoNote.Properties.NullValuePrompt = "Notes from the conversation…";
        this.memoNote.Properties.MaxLength = 500;

        // Payment plan: when the parent will pay, and how much each time.
        this.lblPlan = new LabelControl
        {
            Text = "Payment plan — when will they pay, and how much?",
            Location = new Point(450, 80), Visible = false,
        };
        this.lblPlan.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
        this.gridPlan = new DevExpress.XtraGrid.GridControl
        {
            Location = new Point(450, 98), Size = new Size(320, 82), Visible = false, DataSource = _plan,
        };
        this.gridViewPlan = new GridView();
        this.gridPlan.MainView = this.gridViewPlan;
        this.gridPlan.ViewCollection.Add(this.gridViewPlan);
        this.gridViewPlan.OptionsView.ShowGroupPanel   = false;
        this.gridViewPlan.OptionsView.ShowIndicator    = false;
        this.gridViewPlan.OptionsCustomization.AllowSort   = false;
        this.gridViewPlan.OptionsCustomization.AllowFilter = false;
        this.gridViewPlan.OptionsMenu.EnableColumnMenu     = false;
        var colDue = new DevExpress.XtraGrid.Columns.GridColumn
            { FieldName = "DueDate", Caption = "Pay by", VisibleIndex = 0, Width = 130 };
        colDue.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.DateTime;
        colDue.DisplayFormat.FormatString = "dd-MMM-yyyy";
        var colAmt = new DevExpress.XtraGrid.Columns.GridColumn
            { FieldName = "Amount", Caption = "Amount (UGX)", VisibleIndex = 1, Width = 150 };
        colAmt.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
        colAmt.DisplayFormat.FormatString = "N0";
        this.gridViewPlan.Columns.AddRange(new[] { colDue, colAmt });
        this.gridViewPlan.CellValueChanged += (s, e) => UpdatePlanTotal();

        this.btnAddInstalment = new SimpleButton
            { Text = "+ Add a date", Location = new Point(776, 98), Width = 104, Visible = false };
        this.btnAddInstalment.Click += (s, e) =>
        {
            gridViewPlan.CloseEditor();
            _plan.Add(new InstalmentRow());
            gridViewPlan.FocusedRowHandle = _plan.Count - 1;
            UpdatePlanTotal();
        };
        this.btnRemoveInstalment = new SimpleButton
            { Text = "Remove", Location = new Point(776, 126), Width = 104, Visible = false };
        this.btnRemoveInstalment.Click += (s, e) =>
        {
            gridViewPlan.CloseEditor();
            if (_plan.Count <= 1) { _plan[0].DueDate = null; _plan[0].Amount = null; gridViewPlan.RefreshData(); }
            else if (gridViewPlan.GetFocusedRow() is InstalmentRow row) _plan.Remove(row);
            UpdatePlanTotal();
        };
        this.lblPlanTotal = new LabelControl
        {
            Location = new Point(450, 184), AutoSizeMode = LabelAutoSizeMode.None,
            Size = new Size(430, 14), Visible = false,
        };
        this.lblPlanTotal.Appearance.ForeColor = Color.DimGray;

        this.btnSave = new SimpleButton { Text = "Save", Location = new Point(8, 208), Width = 80 };
        this.btnSave.Click += BtnSave_Click;

        this.btnSaveNext = new SimpleButton { Text = "Save && Next", Location = new Point(96, 208), Width = 110 };
        this.btnSaveNext.ToolTip = "Save, then open the next family that has not been called today";
        this.btnSaveNext.Click += BtnSaveNext_Click;

        this.btnClear = new SimpleButton { Text = "Clear", Location = new Point(214, 208), Width = 80 };
        this.btnClear.Click += (s, e) => ResetContactForm();

        logPanel.Controls.AddRange(new Control[]
        {
            lblChannel, rgChannel, lblContactDate, dteContactDate,
            lblOutcome, cboOutcome,
            lblPromiseDate, dtePromiseDate,
            lblPromiseAmount, txtPromiseAmount,
            _lblPromiseStudent, _cboPromiseStudent,
            memoNote,
            lblPlan, gridPlan, btnAddInstalment, btnRemoveInstalment, lblPlanTotal,
            btnSave, btnSaveNext, btnClear,
        });

        // ── Students grid ─────────────────────────────────────────────────────
        var studentsPanel = new Panel { Dock = DockStyle.Top, Height = 160 };
        this.gridStudents     = new DevExpress.XtraGrid.GridControl { Dock = DockStyle.Fill };
        this.gridViewStudents = new GridView();
        this.gridStudents.MainView = this.gridViewStudents;
        this.gridStudents.ViewCollection.Add(this.gridViewStudents);
        this.gridViewStudents.OptionsView.ShowGroupPanel     = false;
        this.gridViewStudents.OptionsBehavior.Editable       = false;
        this.gridViewStudents.CustomColumnDisplayText       += GridViewStudents_CustomColumnDisplayText;
        this.gridStudents.MouseDoubleClick                  += GridStudents_MouseDoubleClick;
        studentsPanel.Controls.Add(this.gridStudents);

        // ── History grid (Fill) ───────────────────────────────────────────────
        this.gridHistory     = new DevExpress.XtraGrid.GridControl { Dock = DockStyle.Fill };
        this.gridViewHistory = new GridView();
        this.gridHistory.MainView = this.gridViewHistory;
        this.gridHistory.ViewCollection.Add(this.gridViewHistory);
        this.gridViewHistory.OptionsView.ShowGroupPanel = false;
        this.gridViewHistory.OptionsBehavior.Editable   = false;
        this.gridViewHistory.MouseDown += GridViewHistory_MouseDown;
        this.gridViewHistory.RowStyle  += GridViewHistory_RowStyle;

        // ── Assemble ──────────────────────────────────────────────────────────
        this.Controls.Add(this.gridHistory);     // Fill
        this.Controls.Add(studentsPanel);        // Top (after logPanel so z-order correct)
        this.Controls.Add(logPanel);             // Bottom
        this.Controls.Add(this._infoPanel);      // Top
        this.Controls.Add(navBar);               // Top

        this.ResumeLayout(false);
    }

    // ── Navigation ────────────────────────────────────────────────────────────

    private void Navigate(int delta)
    {
        int next = _currentIndex + delta;
        if (next < 0 || next >= _worklist.Count) return;
        _currentIndex = next;
        LoadCurrent();
    }

    private void LoadGuardian(int index)
    {
        _currentIndex = index;
        LoadCurrent();
    }

    private void LoadCurrent()
    {
        var g = Current;

        // Navigation buttons
        btnPrev.Enabled = _currentIndex > 0;
        btnNext.Enabled = _currentIndex < _worklist.Count - 1;
        var progress = DailyListLogic.Progress(_worklist);
        Text = $"Contact Interaction — {g.GuardianLabel}   ({_currentIndex + 1} of {_worklist.Count}  ·  {progress.Worked} worked today)";

        // Structured info header
        bool noPhone = g.GuardianContact.StartsWith("NOCONTACT-", StringComparison.Ordinal);
        _lblGuardianName.Text = g.GuardianLabel;
        _lblContacts.Text     = noPhone
            ? "(no phone on file)"
            : $"Contact: {g.GuardianContact}     Alt: {(!string.IsNullOrEmpty(g.Contact2) ? g.Contact2 : "—")}";
        decimal hdrPayable = g.Students.Sum(s => s.TotalBilled);
        decimal hdrPaid    = g.Students.Sum(s => s.TotalPaid);
        _lblBalance.Text = $"{g.StudentCount} student(s)   ·   UGX {hdrPayable:N0} payable   ·   UGX {hdrPaid:N0} paid   ·   {g.PaymentPercent:F1}% paid";

        // Right-side balance badge
        if (g.TotalBalance <= 0)
        {
            string creditNote = g.TotalBalance < 0 ? $" (cr {Math.Abs(g.TotalBalance):N0})" : "";
            _lblBalanceRight.Text      = $"CLEARED{creditNote}";
            _lblBalanceRight.ForeColor = Color.ForestGreen;
        }
        else
        {
            _lblBalanceRight.Text      = $"UGX {g.TotalBalance:N0}";
            _lblBalanceRight.ForeColor = Color.DarkRed;
        }
        // Reposition after text change (AutoSize recalculates Width)
        _lblBalanceRight.Location = new Point(
            _infoPanel.ClientSize.Width - _lblBalanceRight.Width - 12, 20);

        // Priority tier badge
        (string tierText, Color tierBack, Color tierFore) = g.Tier switch
        {
            PriorityTier.Critical      => ("Critical",        Color.OrangeRed,                      Color.White),
            PriorityTier.BrokenPromise => ("Missed Promise",  Color.FromArgb(200, 80, 80),           Color.White),
            PriorityTier.Stale         => ("Contact Overdue", Color.FromArgb(180, 140, 0),           Color.White),
            PriorityTier.CallRequired  => ("Call Required",   Color.DarkSlateBlue,                   Color.White),
            _                          => ("Up to Date",      Color.ForestGreen,                     Color.White),
        };
        _lblTier.Text      = tierText;
        _lblTier.BackColor = tierBack;
        _lblTier.ForeColor = tierFore;
        _lblTier.Location  = new Point(
            _infoPanel.ClientSize.Width - _lblTier.Width - 12, 56);

        // Today's status badge
        (string todayText, Color todayBack) = g.TodayStatus switch
        {
            TodayStatus.Done  => ("Today: Done",                 Color.ForestGreen),
            TodayStatus.Tried => ($"Today: {g.TodayStatusText}", Color.FromArgb(180, 140, 0)),
            _                 => ("Today: Not called",           Color.SlateGray),
        };
        _lblToday.Text      = todayText;
        _lblToday.BackColor = todayBack;
        _lblToday.ForeColor = Color.White;

        // Promise position
        string promiseText = g.Promise != null && g.Promise.HasPromise
            ? "Promise: " + g.Promise.StatusText
              + (g.Promise.ActivePlans.Sum(p => p.Instalments.Count) > 1
                    ? $"  ({g.Promise.ActivePlans.Sum(p => p.Instalments.Count)} instalments)" : "")
            : "No promise this term";
        _lblPromise.Text      = promiseText;
        _lblPromise.Location  = new Point(_lblToday.Right + 10, 82);
        _lblPromise.ForeColor = g.Promise != null && g.Promise.IsBroken ? Color.Firebrick : Color.FromArgb(60, 60, 60);

        // SMS style for this family
        _loadingRow = true;
        _cboSmsStyle.SelectedIndex = g.SmsStyle == SmsStyle.PerChild ? 1 : 0;
        _cboSmsStyle.Enabled       = g.Students.Count > 1;
        _loadingRow = false;

        // Who the promise is for: the whole family (usual), or one child.
        _cboPromiseStudent.Properties.Items.Clear();
        _cboPromiseStudent.Properties.Items.Add(WholeFamily);
        if (g.Students.Count > 1)
            foreach (var st in g.Students)
                _cboPromiseStudent.Properties.Items.Add(st);
        _cboPromiseStudent.SelectedIndex = 0;

        // Students grid
        gridStudents.DataSource = g.Students;
        ConfigureStudentsColumns();

        // History grid
        var nums = g.Students.Select(s => s.StudentNumber);
        gridHistory.DataSource = _service.GetGuardianContactHistory(g.GuardianContact, nums);
        ConfigureHistoryColumns();

        ResetContactForm();
    }

    // ── Grid configuration ────────────────────────────────────────────────────

    private bool _studentsColumnsConfigured = false;

    private void ConfigureStudentsColumns()
    {
        if (_studentsColumnsConfigured && gridViewStudents.Columns.Count > 0) return;
        _studentsColumnsConfigured = true;

        // Hide columns not explicitly listed
        var keep = new HashSet<string>
        {
            "StudentNumber", "StudentId", "FullName", "ClassId",
            "DayBoarder", "TotalBilled", "TotalPaid", "Balance", "PaymentPercent",
        };
        foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridViewStudents.Columns)
        {
            if (!keep.Contains(col.FieldName))
                col.Visible = false;
        }

        void SetStud(string field, string caption, int width)
        {
            var c = gridViewStudents.Columns[field];
            if (c == null) return;
            c.Caption = caption;
            c.Width   = width;
        }

        SetStud("StudentNumber",  "Student#",      110);
        SetStud("StudentId",      "Student ID",    100);
        SetStud("FullName",       "Name",          200);
        SetStud("ClassId",        "Class",          60);
        SetStud("DayBoarder",     "D/B",            45);
        SetStud("TotalBilled",    "Total Payable", 110);
        SetStud("TotalPaid",      "Total Paid",    110);
        SetStud("Balance",        "Balance (UGX)", 110);
        SetStud("PaymentPercent", "% Paid",         70);

        var colPaid = gridViewStudents.Columns["TotalPaid"];
        if (colPaid != null)
        {
            colPaid.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
            colPaid.DisplayFormat.FormatString = "N0";
        }

        var colBilled = gridViewStudents.Columns["TotalBilled"];
        if (colBilled != null)
        {
            colBilled.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
            colBilled.DisplayFormat.FormatString = "N0";
        }

        var colBal = gridViewStudents.Columns["Balance"];
        if (colBal != null)
        {
            colBal.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
            colBal.DisplayFormat.FormatString = "N0";
        }
    }

    private bool _historyColumnsConfigured = false;

    private void ConfigureHistoryColumns()
    {
        if (_historyColumnsConfigured) return;
        _historyColumnsConfigured = true;

        var colId = gridViewHistory.Columns["ContactId"];
        if (colId != null) colId.Visible = false;
        var colGK = gridViewHistory.Columns["GuardianKey"];
        if (colGK != null) colGK.Visible = false;
        var colSN = gridViewHistory.Columns["StudentNumber"];
        if (colSN != null) colSN.Visible = false;
        // The payment plan column replaces the single promise date / amount.
        foreach (string hidden in new[] { "PromiseScope", "SemesterId", "PromiseDate", "PromiseAmount" })
        {
            var hc = gridViewHistory.Columns[hidden];
            if (hc != null) hc.Visible = false;
        }

        void SetH(string f, string c) { var col = gridViewHistory.Columns[f]; if (col != null) col.Caption = c; }
        SetH("ContactDate",   "Date");
        SetH("Channel",       "Channel");
        SetH("Outcome",       "Outcome");
        SetH("Note",          "Note");
        SetH("LoggedBy",      "Logged By");
        SetH("PaymentPlan",   "Payment Plan");
        SetH("Term",          "Term");

        // Configure the auto-generated StudentName column (already created by DevExpress from the DataTable)
        var studentCol = gridViewHistory.Columns["StudentName"];
        if (studentCol != null)
        {
            studentCol.Caption = "Student";
            studentCol.Width   = 150;
            studentCol.OptionsColumn.AllowEdit = false;
            var outcomeCol = gridViewHistory.Columns["Outcome"];
            studentCol.VisibleIndex = outcomeCol != null ? outcomeCol.VisibleIndex + 1 : 3;
        }

        gridViewHistory.CustomColumnDisplayText += (s, e) =>
        {
            if (e.Column.FieldName == "StudentName"
                && (e.Value == null || e.Value == DBNull.Value || string.IsNullOrEmpty(e.Value.ToString())))
                e.DisplayText = "Whole family";
            else if (e.Column.FieldName == "Outcome" && Enum.TryParse(e.Value?.ToString(), out ContactOutcome oc))
                e.DisplayText = OutcomeText(oc);
        };

        var colAmt = gridViewHistory.Columns["PromiseAmount"];
        if (colAmt != null)
        {
            colAmt.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
            colAmt.DisplayFormat.FormatString = "N0";
        }

        gridViewHistory.BestFitColumns();
        var noteCol = gridViewHistory.Columns["Note"];
        if (noteCol != null) noteCol.Width = Math.Min(noteCol.Width, 200);
        if (studentCol != null && studentCol.Width < 150) studentCol.Width = 150;
    }

    // Interactions from earlier terms are history only: shown greyed.
    private void GridViewHistory_RowStyle(object sender, RowStyleEventArgs e)
    {
        var row = gridViewHistory.GetDataRow(e.RowHandle);
        if (row == null) return;
        string sem = row["SemesterId"] as string;
        if (!string.Equals(sem, _service.GetWorkingSemester(), StringComparison.OrdinalIgnoreCase))
            e.Appearance.ForeColor = Color.Gray;
    }

    internal static string OutcomeText(ContactOutcome o) => o switch
    {
        ContactOutcome.Contacted          => "Spoke to parent",
        ContactOutcome.NoAnswer           => "No answer",
        ContactOutcome.ContactUnavailable => "Number unavailable",
        ContactOutcome.ContactOff         => "Phone off",
        ContactOutcome.Promised           => "Promised to pay",
        ContactOutcome.Refused            => "Refused",
        _                                 => o.ToString(),
    };

    private sealed class OutcomeItem
    {
        public ContactOutcome Value { get; }
        public OutcomeItem(ContactOutcome value) { Value = value; }
        public override string ToString() => OutcomeText(Value);
    }

    private ContactOutcome? SelectedOutcome => (cboOutcome.SelectedItem as OutcomeItem)?.Value;

    private void SelectOutcome(ContactOutcome outcome)
    {
        foreach (object item in cboOutcome.Properties.Items)
            if (item is OutcomeItem oi && oi.Value == outcome) { cboOutcome.SelectedItem = item; return; }
    }

    private void ShowPromiseControls(bool promised)
    {
        _lblPromiseStudent.Visible = _cboPromiseStudent.Visible = promised;
        lblPlan.Visible = gridPlan.Visible = lblPlanTotal.Visible = promised;
        btnAddInstalment.Visible = btnRemoveInstalment.Visible = promised;
        if (promised && _plan.Count == 0) _plan.Add(new InstalmentRow());
        if (promised) UpdatePlanTotal();
    }

    private void UpdatePlanTotal()
    {
        var dated = _plan.Where(r => r.DueDate.HasValue).ToList();
        decimal total = dated.Sum(r => r.Amount ?? 0m);
        decimal balance = Current.TotalBalance;
        if (dated.Count == 0)
            lblPlanTotal.Text = "Leave the amount empty if they promised to clear the whole balance.";
        else if (dated.Count == 1 && !(dated[0].Amount > 0m))
            lblPlanTotal.Text = $"Promise to clear the balance (UGX {balance:N0}) by {dated[0].DueDate:dd-MMM}.";
        else
            lblPlanTotal.Text = $"Plan total UGX {total:N0} of UGX {balance:N0} owed"
                + (total < balance ? $"   ·   UGX {balance - total:N0} not covered" : "");
    }

    private void CboSmsStyle_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_loadingRow) return;
        var style = _cboSmsStyle.SelectedIndex == 1 ? SmsStyle.PerChild : SmsStyle.FamilyTotal;
        if (style == Current.SmsStyle && Current.SmsStyleIsOwn) return;
        try
        {
            _service.SetGuardianSmsStyle(Current.GuardianContact, style, CurrentUser.GetSystemUser());
            Current.SmsStyle      = style;
            Current.SmsStyleIsOwn = true;
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not save the SMS choice for this family.\n\n{ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    private void GridViewStudents_CustomColumnDisplayText(object sender,
        DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
    {
        if (e.Column.FieldName == "PaymentPercent" && e.Value is decimal pct)
            e.DisplayText = $"{pct:F1}%";
    }

    // ── Student grid double-click → open payment form ─────────────────────────

    private void GridStudents_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        var pt  = gridStudents.PointToClient(Cursor.Position);
        var hit = gridViewStudents.CalcHitInfo(pt);
        if (!hit.InRow) return;
        var student = gridViewStudents.GetRow(hit.RowHandle) as StudentSummary;
        if (student == null) return;

        StudentOptions.SetActiveStudent(student.StudentNumber);
        StudentOptions.SetActiveClass(student.ClassId);
        StudentOptions.SetPaymentMode("SingleStudent");
        using var dlg = new StudentFeesPayment("SingleStudentPayment", viewOnly: true);
        dlg.ShowDialog(this);
    }

    // ── History right-click (Edit / Delete) ───────────────────────────────────

    private void GridViewHistory_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;
        var hit = gridViewHistory.CalcHitInfo(new Point(e.X, e.Y));
        if (!hit.InRow) return;
        var dataRow = gridViewHistory.GetDataRow(hit.RowHandle);
        if (dataRow == null) return;

        string ch = dataRow["Channel"]?.ToString() ?? "";
        if (ch == "SMS") return;   // SMS entries are not editable

        int contactId = Convert.ToInt32(dataRow["ContactId"]);

        var menu = new System.Windows.Forms.ContextMenuStrip();
        menu.Items.Add("Edit",   null, (s2, e2) => BeginEditContact(dataRow, contactId));
        menu.Items.Add("Delete", null, (s2, e2) => DeleteHistoryContact(contactId));
        menu.Show(Control.MousePosition);
    }

    private void BeginEditContact(System.Data.DataRow row, int contactId)
    {
        _editContactId = contactId;

        if (DateTime.TryParse(row["ContactDate"]?.ToString(), out DateTime cd))
            dteContactDate.EditValue = cd;
        if (Enum.TryParse(row["Channel"]?.ToString(), out ContactChannel ch))
            rgChannel.EditValue = ch;
        ContactOutcome oc = default;
        if (Enum.TryParse(row["Outcome"]?.ToString(), out oc))
        {
            SelectOutcome(oc);
        }
        memoNote.Text = row["Note"]?.ToString() ?? "";

        // Payment plan: stored instalments, or the single promise on rows logged before plans existed.
        _plan.Clear();
        try
        {
            foreach (var inst in _service.GetInstalments(contactId))
                _plan.Add(new InstalmentRow { DueDate = inst.DueDate, Amount = inst.Amount });
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not load the payment plan for this entry.\n\n{ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        if (_plan.Count == 0 && row["PromiseDate"] != DBNull.Value)
            _plan.Add(new InstalmentRow
            {
                DueDate = Convert.ToDateTime(row["PromiseDate"]),
                Amount  = row["PromiseAmount"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["PromiseAmount"]),
            });
        if (_plan.Count == 0) _plan.Add(new InstalmentRow());

        // Who the promise was for.
        _cboPromiseStudent.SelectedIndex = 0;
        if (string.Equals(row["PromiseScope"] as string, "Student", StringComparison.OrdinalIgnoreCase))
        {
            string sn = row["StudentNumber"]?.ToString() ?? "";
            for (int i = 1; i < _cboPromiseStudent.Properties.Items.Count; i++)
                if (_cboPromiseStudent.Properties.Items[i] is StudentSummary st
                    && string.Equals(st.StudentNumber, sn, StringComparison.OrdinalIgnoreCase))
                    _cboPromiseStudent.SelectedIndex = i;
        }
        ShowPromiseControls(oc == ContactOutcome.Promised && cboOutcome.SelectedItem != null);

        btnSave.Text = "Update";
    }

    private void DeleteHistoryContact(int contactId)
    {
        var confirm = XtraMessageBox.Show(
            "Delete this contact record?", "Confirm Delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        try
        {
            _service.DeleteContact(contactId);
            RefreshCurrentRow();
            LoadCurrent();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    // ── Contact log form ──────────────────────────────────────────────────────

    private void ResetContactForm()
    {
        _editContactId           = -1;
        dteContactDate.EditValue = DateTime.Today;
        rgChannel.EditValueChanged -= RgChannel_EditValueChanged;   // resetting must not open the SMS window
        rgChannel.SelectedIndex  = 1;   // Phone
        rgChannel.EditValueChanged += RgChannel_EditValueChanged;
        cboOutcome.SelectedIndex = -1;
        memoNote.Text            = "";
        _plan.Clear();
        ShowPromiseControls(false);
        if (_cboPromiseStudent.Properties.Items.Count > 0)
            _cboPromiseStudent.SelectedIndex = 0;
        btnSave.Text             = "Save";
    }

    private bool TrySaveContact()
    {
        gridViewPlan.CloseEditor();
        gridViewPlan.UpdateCurrentRow();

        if (dteContactDate.DateTime.Date > DateTime.Today)
        {
            XtraMessageBox.Show("Contact date cannot be in the future.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (cboOutcome.SelectedItem == null)
        {
            XtraMessageBox.Show("Please choose what happened (the outcome) before saving.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        var channel = (ContactChannel)rgChannel.EditValue;
        var outcome = SelectedOutcome.Value;

        // Payment plan (only for a promise). Rows left completely empty are ignored.
        List<PromiseInstalment> instalments = null;
        string promiseStudentNumber = null;
        if (outcome == ContactOutcome.Promised)
        {
            if (_plan.Any(r => !r.DueDate.HasValue && r.Amount > 0m))
            {
                XtraMessageBox.Show("One line of the payment plan has an amount but no date.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            instalments = _plan.Where(r => r.DueDate.HasValue)
                .Select(r => new PromiseInstalment
                {
                    DueDate = r.DueDate.Value.Date,
                    Amount  = r.Amount > 0m ? r.Amount : null,
                }).ToList();
            // Dates are checked against the day of the conversation, so an old entry can be corrected.
            if (!PromiseEvaluator.ValidateInstalments(instalments, dteContactDate.DateTime.Date, out string problem))
            {
                XtraMessageBox.Show(problem, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_cboPromiseStudent.SelectedItem is StudentSummary oneChild)
                promiseStudentNumber = oneChild.StudentNumber;
        }

        var entry = new FeesContactLog
        {
            // Keep the time of day for entries made today so same-day entries stay in order.
            ContactDate   = dteContactDate.DateTime.Date == DateTime.Today ? DateTime.Now : dteContactDate.DateTime.Date,
            LoggedBy      = CurrentUser.GetSystemUser(),
            Channel       = channel,
            Outcome       = outcome,
            Note          = string.IsNullOrWhiteSpace(memoNote.Text) ? null : memoNote.Text.Trim(),
            StudentNumber = promiseStudentNumber,   // blank = whole family
        };

        try
        {
            if (_editContactId >= 0)
            {
                entry.ContactId = _editContactId;
                _service.UpdateContact(entry, instalments);
            }
            else
            {
                _service.LogGuardianContact(Current.GuardianContact, entry, instalments);
            }

            RefreshCurrentRow();
            LoadCurrent();
            return true;
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return false;
        }
    }

    /// <summary>
    /// Re-read the family on screen after a change so its balance, promise, priority and
    /// "today" status are current. Falls back to the rows already loaded if the reload fails.
    /// </summary>
    private void RefreshCurrentRow()
    {
        string key = Current.GuardianContact;
        Cursor = Cursors.WaitCursor;
        try
        {
            var fresh = _reloadRows().FirstOrDefault(r => r.GuardianContact == key);
            if (fresh != null) _worklist[_currentIndex] = fresh;
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"The entry was saved, but this family could not be refreshed.\n\n{ex.Message}",
                "Fees Follow-up", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    // Opens the SMS dialog; on success sets outcome=Contacted and fills note with sent message.
    private void RgChannel_EditValueChanged(object sender, EventArgs e)
    {
        bool isSms = rgChannel.EditValue is ContactChannel ch && ch == ContactChannel.SMS;
        if (!isSms) return;

        string phone = Current.GuardianContact.StartsWith("NOCONTACT-", StringComparison.Ordinal)
            ? Current.Contact2 : Current.GuardianContact;
        if (string.IsNullOrWhiteSpace(phone) || phone.StartsWith("NOCONTACT-", StringComparison.Ordinal))
        {
            XtraMessageBox.Show("No phone number on file for this guardian.",
                "Cannot Send SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            rgChannel.SelectedIndex = 1;   // revert to Phone
            return;
        }

        using var smsForm = new dlgTemplatedSms
        {
            RecipientPhone = phone,
            Guardian       = Current,
        };
        if (smsForm.ShowDialog(this) == DialogResult.OK)
        {
            SelectOutcome(ContactOutcome.Contacted);
            string summary = smsForm.SentSummary ?? "SMS sent";
            memoNote.Text = summary.Length > 500 ? summary.Substring(0, 500) : summary;
            TrySaveContact();
        }
        else
        {
            rgChannel.SelectedIndex = 1;   // revert to Phone on cancel
        }
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        if (!TrySaveContact()) return;
    }

    private void BtnSaveNext_Click(object sender, EventArgs e)
    {
        if (!TrySaveContact()) return;
        // Go to the next family nobody has called today (then ones to try again), not just the next row.
        int next = DailyListLogic.NextToWork(_worklist, _currentIndex);
        if (next >= 0)
        {
            LoadGuardian(next);
            return;
        }
        XtraMessageBox.Show("Every family on this list has been worked today.", "Fees Follow-up",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
    }
}
