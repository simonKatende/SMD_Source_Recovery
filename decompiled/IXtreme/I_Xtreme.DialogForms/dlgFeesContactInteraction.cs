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
    private Label        _lblGuardianName, _lblContacts, _lblBalance, _lblBalanceRight;

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
            Height    = 80,
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
        this._infoPanel.Controls.AddRange(new Control[]
        {
            _lblGuardianName, _lblContacts, _lblBalance, _lblBalanceRight,
        });
        this._infoPanel.Resize += (s, e) =>
        {
            if (_lblBalanceRight != null)
                _lblBalanceRight.Location = new Point(
                    _infoPanel.ClientSize.Width - _lblBalanceRight.Width - 12, 20);
        };

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
            this.cboOutcome.Properties.Items.Add(o);
        this.cboOutcome.SelectedIndex = -1;
        this.cboOutcome.Location      = new Point(70, 46);
        this.cboOutcome.Width         = 200;
        this.cboOutcome.SelectedIndexChanged += (s, e) =>
        {
            bool promised = cboOutcome.SelectedItem is ContactOutcome o2 && o2 == ContactOutcome.Promised;
            lblPromiseDate.Visible   = dtePromiseDate.Visible   = promised;
            lblPromiseAmount.Visible = txtPromiseAmount.Visible = promised;
        };

        this.lblPromiseDate   = new LabelControl { Text = "Promise date:",   Location = new Point(282, 52), Visible = false };
        this.dtePromiseDate   = new DateEdit     { Location = new Point(370, 47), Width = 120, Visible = false };
        this.lblPromiseAmount = new LabelControl { Text = "Promise amount:", Location = new Point(500, 52), Visible = false };
        this.txtPromiseAmount = new SpinEdit     { Location = new Point(600, 47), Width = 110, Visible = false };
        this.txtPromiseAmount.Properties.IsFloatValue = true;
        this.txtPromiseAmount.Properties.MaskSettings.Set("mask", "N0");

        this.memoNote = new MemoEdit { Location = new Point(8, 80), Size = new Size(560, 80) };

        this.btnSave = new SimpleButton { Text = "Save", Location = new Point(8, 168), Width = 80 };
        this.btnSave.Click += BtnSave_Click;

        this.btnSaveNext = new SimpleButton { Text = "Save & Next", Location = new Point(96, 168), Width = 110 };
        this.btnSaveNext.Click += BtnSaveNext_Click;

        this.btnClear = new SimpleButton { Text = "Clear", Location = new Point(214, 168), Width = 80 };
        this.btnClear.Click += (s, e) => ResetContactForm();

        logPanel.Controls.AddRange(new Control[]
        {
            lblChannel, rgChannel, lblContactDate, dteContactDate,
            lblOutcome, cboOutcome,
            lblPromiseDate, dtePromiseDate,
            lblPromiseAmount, txtPromiseAmount,
            memoNote, btnSave, btnSaveNext, btnClear,
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
        Text = $"Contact Interaction — {g.GuardianLabel} ({_currentIndex + 1} of {_worklist.Count})";

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
        using var dlg = new StudentFeesPayment("SingleStudentPayment");
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
        if (Enum.TryParse(row["Outcome"]?.ToString(), out ContactOutcome oc))
        {
            cboOutcome.SelectedItem = oc;
        }
        memoNote.Text = row["Note"]?.ToString() ?? "";
        if (row["PromiseDate"] != DBNull.Value && DateTime.TryParse(row["PromiseDate"]?.ToString(), out DateTime pd))
            dtePromiseDate.EditValue = pd;
        if (row["PromiseAmount"] != DBNull.Value && decimal.TryParse(row["PromiseAmount"]?.ToString(), out decimal pa))
            txtPromiseAmount.Value = pa;

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
        _editContactId           = -1;
        dteContactDate.EditValue = DateTime.Today;
        rgChannel.SelectedIndex  = 1;   // Phone
        cboOutcome.SelectedIndex = -1;
        memoNote.Text            = "";
        dtePromiseDate.EditValue = null;
        txtPromiseAmount.Value   = 0;
        lblPromiseDate.Visible   = dtePromiseDate.Visible   = false;
        lblPromiseAmount.Visible = txtPromiseAmount.Visible = false;
        btnSave.Text             = "Save";
    }

    private bool TrySaveContact()
    {
        if (dteContactDate.DateTime.Date > DateTime.Today)
        {
            XtraMessageBox.Show("Contact date cannot be in the future.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (cboOutcome.SelectedItem == null)
        {
            XtraMessageBox.Show("Please select a contact outcome before saving.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        var channel = (ContactChannel)rgChannel.EditValue;
        var outcome = (ContactOutcome)cboOutcome.SelectedItem;

        if (outcome == ContactOutcome.Promised && dtePromiseDate.EditValue == null)
        {
            XtraMessageBox.Show("Please set a promise date when outcome is 'Promised'.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

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
            return true;
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return false;
        }
    }

    // Opens the SMS dialog; on success sets outcome=Contacted and fills note with sent message.
    private void RgChannel_EditValueChanged(object sender, EventArgs e)
    {
        bool isSms = rgChannel.EditValue is ContactChannel ch && ch == ContactChannel.SMS;
        if (!isSms) return;

        if (Current.GuardianContact.StartsWith("NOCONTACT-", StringComparison.Ordinal))
        {
            XtraMessageBox.Show("No phone number on file for this guardian.",
                "Cannot Send SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            rgChannel.SelectedIndex = 1;   // reset to Phone
            return;
        }

        using var smsForm = new SMSGuardian();
        smsForm.txtReceipient.Text = Current.GuardianContact;
        if (smsForm.ShowDialog(this) == DialogResult.OK)
        {
            // Auto-fill outcome = Contacted
            int idx = cboOutcome.Properties.Items.IndexOf(ContactOutcome.Contacted);
            if (idx < 0) idx = cboOutcome.Properties.Items.IndexOf("Contacted");
            if (idx >= 0) cboOutcome.SelectedIndex = idx;
            // Fill note with the sent message body
            if (!string.IsNullOrEmpty(smsForm.SentMessage))
                memoNote.Text = smsForm.SentMessage;
            // Auto-save — no manual click required for SMS interactions
            TrySaveContact();
        }
        else
        {
            // SMS dialog was cancelled — revert channel to Phone
            rgChannel.SelectedIndex = 1;
        }
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        if (!TrySaveContact()) return;
    }

    private void BtnSaveNext_Click(object sender, EventArgs e)
    {
        if (!TrySaveContact()) return;
        if (_currentIndex < _worklist.Count - 1)
            LoadGuardian(_currentIndex + 1);
        else
            this.DialogResult = DialogResult.OK;
    }
}
