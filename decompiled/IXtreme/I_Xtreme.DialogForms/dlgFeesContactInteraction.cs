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

    // ── Info bar ──────────────────────────────────────────────────────────────
    private LabelControl lblContactNum, lblStudentCount, lblTotalBalance, lblPayPct;

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
    private ComboBoxEdit  cboOutcome;
    private MemoEdit      memoNote;
    private LabelControl  lblPromiseDate, lblPromiseAmount;
    private DateEdit      dtePromiseDate;
    private SpinEdit      txtPromiseAmount;
    private SimpleButton  btnSave, btnClear;

    // ── State ─────────────────────────────────────────────────────────────────
    private readonly List<GuardianWorklistRow> _worklist;
    private int _currentIndex;
    private int _editContactId = -1;
    private readonly FeesFollowUpService _service = new FeesFollowUpService();

    public dlgFeesContactInteraction(List<GuardianWorklistRow> worklist, int startIndex)
    {
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
        this.Size            = new Size(900, 720);
        this.StartPosition   = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.Sizable;

        // ── Navigation bar ────────────────────────────────────────────────────
        var navBar = new Panel { Dock = DockStyle.Top, Height = 44 };

        this.btnPrev = new SimpleButton { Text = "← Prev", Location = new Point(8, 8), Width = 80 };
        this.btnPrev.Click += (s, e) => Navigate(-1);

        this.btnNext = new SimpleButton { Text = "Next →", Location = new Point(800, 8), Width = 80 };
        this.btnNext.Click += (s, e) => Navigate(+1);

        this.lblTitle = new LabelControl
        {
            AutoSizeMode = LabelAutoSizeMode.None,
            Size         = new Size(700, 22),
            Location     = new Point(96, 12),
            Appearance   = { Font = new Font("Tahoma", 11F, FontStyle.Bold) },
        };
        navBar.Controls.AddRange(new Control[] { btnPrev, btnNext, lblTitle });

        // ── Info bar ──────────────────────────────────────────────────────────
        var infoBar = new Panel { Dock = DockStyle.Top, Height = 28 };

        this.lblContactNum   = new LabelControl { Location = new Point(8, 6),   AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(200, 18) };
        this.lblStudentCount = new LabelControl { Location = new Point(220, 6),  AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(120, 18) };
        this.lblTotalBalance = new LabelControl { Location = new Point(350, 6),  AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(200, 18) };
        this.lblPayPct       = new LabelControl { Location = new Point(560, 6),  AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(160, 18) };
        infoBar.Controls.AddRange(new Control[] { lblContactNum, lblStudentCount, lblTotalBalance, lblPayPct });

        // ── Contact log panel (Bottom) ─────────────────────────────────────────
        var logPanel = new Panel { Dock = DockStyle.Bottom, Height = 220 };

        var lblChannel = new LabelControl { Text = "Channel:", Location = new Point(8, 10) };
        this.rgChannel = new DevExpress.XtraEditors.RadioGroup();
        this.rgChannel.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[]
        {
            new(ContactChannel.SMS,      "SMS"),
            new(ContactChannel.Phone,    "Phone"),
            new(ContactChannel.InPerson, "InPerson"),
        });
        this.rgChannel.Properties.Columns = 3;
        this.rgChannel.SelectedIndex = 1;    // Phone
        this.rgChannel.Location = new Point(70, 4);
        this.rgChannel.Size     = new Size(280, 36);

        this.lblContactDate = new LabelControl { Text = "Date:", Location = new Point(360, 12) };
        this.dteContactDate = new DateEdit
        {
            Location  = new Point(392, 6),
            Width     = 120,
            EditValue = DateTime.Today,
        };

        this.cboOutcome = new ComboBoxEdit();
        this.cboOutcome.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        foreach (ContactOutcome o in Enum.GetValues(typeof(ContactOutcome)))
            this.cboOutcome.Properties.Items.Add(o);
        this.cboOutcome.SelectedIndex = -1;
        this.cboOutcome.Location      = new Point(8, 48);
        this.cboOutcome.Width         = 200;
        this.cboOutcome.SelectedIndexChanged += (s, e) =>
        {
            bool promised = cboOutcome.SelectedItem is ContactOutcome o2 && o2 == ContactOutcome.Promised;
            lblPromiseDate.Visible  = dtePromiseDate.Visible  = promised;
            lblPromiseAmount.Visible = txtPromiseAmount.Visible = promised;
        };

        this.lblPromiseDate  = new LabelControl { Text = "Promise date:",   Location = new Point(220, 52), Visible = false };
        this.dtePromiseDate  = new DateEdit     { Location = new Point(310, 47), Width = 120, Visible = false };
        this.lblPromiseAmount = new LabelControl { Text = "Promise amount:", Location = new Point(440, 52), Visible = false };
        this.txtPromiseAmount = new SpinEdit    { Location = new Point(545, 47), Width = 110, Visible = false };
        this.txtPromiseAmount.Properties.IsFloatValue = true;
        this.txtPromiseAmount.Properties.MaskSettings.Set("mask", "N0");

        this.memoNote = new MemoEdit { Location = new Point(8, 80), Size = new Size(560, 80) };

        this.btnSave = new SimpleButton { Text = "Save Contact", Location = new Point(8, 168), Width = 120 };
        this.btnSave.Click += BtnSave_Click;

        this.btnClear = new SimpleButton { Text = "Clear", Location = new Point(136, 168), Width = 80 };
        this.btnClear.Click += (s, e) => ResetContactForm();

        logPanel.Controls.AddRange(new Control[]
        {
            lblChannel, rgChannel, lblContactDate, dteContactDate,
            cboOutcome, lblPromiseDate, dtePromiseDate,
            lblPromiseAmount, txtPromiseAmount,
            memoNote, btnSave, btnClear,
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
        studentsPanel.Controls.Add(this.gridStudents);

        // ── History grid (Fill) ───────────────────────────────────────────────
        this.gridHistory     = new DevExpress.XtraGrid.GridControl { Dock = DockStyle.Fill };
        this.gridViewHistory = new GridView();
        this.gridHistory.MainView = this.gridViewHistory;
        this.gridHistory.ViewCollection.Add(this.gridViewHistory);
        this.gridViewHistory.OptionsView.ShowGroupPanel = false;
        this.gridViewHistory.OptionsBehavior.Editable   = false;
        this.gridViewHistory.MouseDown += GridViewHistory_MouseDown;

        // ── Assemble ──────────────────────────────────────────────────────────
        this.Controls.Add(this.gridHistory);     // Fill
        this.Controls.Add(studentsPanel);        // Top (after logPanel so z-order correct)
        this.Controls.Add(logPanel);             // Bottom
        this.Controls.Add(infoBar);              // Top
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

    private void LoadCurrent()
    {
        var g = Current;

        // Navigation buttons
        btnPrev.Enabled = _currentIndex > 0;
        btnNext.Enabled = _currentIndex < _worklist.Count - 1;
        Text            = $"Contact Interaction — {g.GuardianLabel} ({_currentIndex + 1} of {_worklist.Count})";
        lblTitle.Text   = g.GuardianLabel;

        // Info bar
        bool noPhone = g.GuardianContact.StartsWith("NOCONTACT-", StringComparison.Ordinal);
        lblContactNum.Text   = noPhone ? "(no phone on file)" : g.GuardianContact;
        lblStudentCount.Text = $"{g.StudentCount} student{(g.StudentCount == 1 ? "" : "s")}";
        lblTotalBalance.Text = $"Balance: UGX {g.TotalBalance:N0}";
        lblPayPct.Text       = $"Paid: {g.PaymentPercent:F1}%  (Pacing: {g.PacingGap:P0} behind)";

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
        if (_studentsColumnsConfigured) return;
        _studentsColumnsConfigured = true;

        HideStudCol("TotalBilled");
        HideStudCol("TotalPaid");

        SetStudCaption("FullName",       "Name");
        SetStudCaption("ClassId",        "Class");
        SetStudCaption("Balance",        "Balance (UGX)");
        SetStudCaption("PaymentPercent", "% Paid");

        var colBal = gridViewStudents.Columns["Balance"];
        if (colBal != null)
        {
            colBal.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
            colBal.DisplayFormat.FormatString = "N0";
        }

        gridViewStudents.BestFitColumns();
    }

    private void HideStudCol(string field)
    {
        var c = gridViewStudents.Columns[field];
        if (c != null) c.Visible = false;
    }

    private void SetStudCaption(string field, string caption)
    {
        var c = gridViewStudents.Columns[field];
        if (c != null) c.Caption = caption;
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

        void SetH(string f, string c) { var col = gridViewHistory.Columns[f]; if (col != null) col.Caption = c; }
        SetH("ContactDate",   "Date");
        SetH("Channel",       "Channel");
        SetH("Outcome",       "Outcome");
        SetH("Note",          "Note");
        SetH("LoggedBy",      "Logged By");
        SetH("PromiseDate",   "Promise Date");
        SetH("PromiseAmount", "Promise Amt");

        var colAmt = gridViewHistory.Columns["PromiseAmount"];
        if (colAmt != null)
        {
            colAmt.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
            colAmt.DisplayFormat.FormatString = "N0";
        }

        gridViewHistory.BestFitColumns();
        var noteCol = gridViewHistory.Columns["Note"];
        if (noteCol != null) noteCol.Width = Math.Min(noteCol.Width, 200);
    }

    private void GridViewStudents_CustomColumnDisplayText(object sender,
        DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
    {
        if (e.Column.FieldName == "PaymentPercent" && e.Value is decimal pct)
            e.DisplayText = $"{pct:F1}%";
    }

    // ── History right-click (Edit / Delete) ───────────────────────────────────

    private void GridViewHistory_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;
        var hit = gridViewHistory.CalcHitInfo(new Point(e.X, e.Y));
        if (!hit.InRow) return;
        var dataRow = gridViewHistory.GetDataRow(hit.RowHandle);
        if (dataRow == null) return;

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
        if (Enum.TryParse(row["Outcome"]?.ToString(), out ContactOutcome oc))
        {
            cboOutcome.SelectedItem = oc;
        }
        memoNote.Text = row["Note"]?.ToString() ?? "";
        if (row["PromiseDate"] != DBNull.Value && DateTime.TryParse(row["PromiseDate"]?.ToString(), out DateTime pd))
            dtePromiseDate.EditValue = pd;
        if (row["PromiseAmount"] != DBNull.Value && decimal.TryParse(row["PromiseAmount"]?.ToString(), out decimal pa))
            txtPromiseAmount.Value = pa;

        btnSave.Text = "Update Contact";
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
            var nums = Current.Students.Select(s => s.StudentNumber);
            gridHistory.DataSource = _service.GetGuardianContactHistory(Current.GuardianContact, nums);
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    // ── Contact log form ──────────────────────────────────────────────────────

    private void ResetContactForm()
    {
        _editContactId          = -1;
        dteContactDate.EditValue = DateTime.Today;
        rgChannel.SelectedIndex  = 1;   // Phone
        cboOutcome.SelectedIndex = -1;
        memoNote.Text            = "";
        dtePromiseDate.EditValue = null;
        txtPromiseAmount.Value   = 0;
        lblPromiseDate.Visible   = dtePromiseDate.Visible   = false;
        lblPromiseAmount.Visible = txtPromiseAmount.Visible = false;
        btnSave.Text             = "Save Contact";
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        if (dteContactDate.DateTime.Date > DateTime.Today)
        {
            XtraMessageBox.Show("Contact date cannot be in the future.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (cboOutcome.SelectedItem == null)
        {
            XtraMessageBox.Show("Please select a contact outcome before saving.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var channel = (ContactChannel)rgChannel.EditValue;
        var outcome = (ContactOutcome)cboOutcome.SelectedItem;

        var entry = new FeesContactLog
        {
            StudentNumber = Current.Students.Count > 0 ? Current.Students[0].StudentNumber : "",
            ContactDate   = dteContactDate.DateTime,
            LoggedBy      = CurrentUser.GetSystemUser(),
            Channel       = channel,
            Outcome       = outcome,
            Note          = string.IsNullOrWhiteSpace(memoNote.Text) ? null : memoNote.Text,
            PromiseDate   = outcome == ContactOutcome.Promised
                            ? dtePromiseDate.DateTime.Date : (DateTime?)null,
            PromiseAmount = outcome == ContactOutcome.Promised && txtPromiseAmount.Value > 0
                            ? (decimal?)txtPromiseAmount.Value : null,
        };

        if (outcome == ContactOutcome.Promised && !entry.PromiseDate.HasValue)
        {
            XtraMessageBox.Show("Please set a promise date when outcome is 'Promised'.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            if (_editContactId >= 0)
            {
                entry.ContactId = _editContactId;
                _service.UpdateContact(entry);
            }
            else
            {
                _service.LogGuardianContact(Current.GuardianContact, entry);
            }

            var nums = Current.Students.Select(s => s.StudentNumber);
            gridHistory.DataSource = _service.GetGuardianContactHistory(Current.GuardianContact, nums);
            ResetContactForm();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
