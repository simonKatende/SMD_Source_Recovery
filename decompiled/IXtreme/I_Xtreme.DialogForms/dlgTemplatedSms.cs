using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;

namespace I_Xtreme.DialogForms;

/// <summary>
/// Send a fees SMS to one guardian family from the interaction window. Shows exactly what will
/// be sent before sending: one message with the family total, or one message per child.
/// </summary>
public class dlgTemplatedSms : XtraForm
{
    private readonly FeesFollowUpService _service = new FeesFollowUpService();
    private ComboBoxEdit  _cboTemplate;
    private RadioGroup    _rgStyle;
    private MemoEdit      _memoTemplate, _memoPreview;
    private SimpleButton  _btnSend, _btnCancel;
    private LabelControl  _lblRecipient, _lblStudents, _lblCount;

    // Inputs -- set before ShowDialog()
    public string              RecipientPhone { get; set; }
    public GuardianWorklistRow Guardian       { get; set; }

    // Outputs
    public string   SentSummary { get; private set; }
    public SmsStyle StyleUsed   { get; private set; }

    private readonly string[] _templateKeys  = { "Promise reminder (before the date)", "Promise due today", "Promise overdue", "Balance reminder", "Write my own message" };
    private readonly string[] _templateTypes = { "3DayBefore",                         "DayOf",             "Overdue",         "General",          null };

    private FeesFollowUpSettings _settings;
    private string _school;
    private List<string> _messages = new List<string>();

    // The promise the message is about (the missed instalment first, else the next one due).
    private DateTime _promiseDate = DateTime.Today;
    private decimal  _promisedAmount;
    private string   _promiseStudentNumber;
    private bool     _hasPromise;

    public dlgTemplatedSms() { InitializeComponent(); }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        try
        {
            _settings = _service.GetSettings();
            _school   = _service.GetSchoolName();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not load SMS settings.\n\n{ex.Message}", "Send SMS",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        ReadPromise();
        _lblRecipient.Text = $"To: {RecipientPhone}";
        _lblStudents.Text  = "Children: " + string.Join(", ", Students.Select(s => $"{s.FullName} ({s.ClassId})"));
        _rgStyle.EditValue = Guardian?.SmsStyle ?? SmsStyle.FamilyTotal;
        _rgStyle.Enabled   = Students.Count > 1;

        // Pick the message that fits where the promise stands today.
        int index = 3;   // balance reminder
        if (_hasPromise)
        {
            int days = (DateTime.Today - _promiseDate.Date).Days;
            index = days < 0 ? 0 : days == 0 ? 1 : 2;
        }
        _cboTemplate.SelectedIndex = index;   // fires ApplyTemplate
    }

    private List<StudentSummary> Students => Guardian?.Students ?? new List<StudentSummary>();

    private void ReadPromise()
    {
        var promise = Guardian?.Promise;
        if (promise == null || !promise.HasPromise) return;
        var inst = promise.EarliestMissed ?? promise.NextDue;
        if (inst == null) return;   // every instalment kept: nothing to remind about
        var plan = promise.ActivePlans.First(p => p.Instalments.Contains(inst));
        _hasPromise           = true;
        _promiseDate          = inst.DueDate;
        _promisedAmount       = inst.Amount.HasValue && inst.Amount.Value > 0m ? inst.AmountOutstanding : 0m;
        _promiseStudentNumber = plan.IsFamily ? null : plan.StudentNumber;
    }

    private void InitializeComponent()
    {
        this.Text            = "Send SMS to Parent";
        this.ClientSize      = new Size(720, 560);
        this.StartPosition   = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox     = false;
        this.MinimizeBox     = false;

        _lblRecipient = new LabelControl { Location = new Point(12, 12), AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(690, 16) };
        _lblRecipient.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
        _lblStudents  = new LabelControl { Location = new Point(12, 32), AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(690, 16) };

        var lblStyle = new LabelControl { Text = "Send as:", Location = new Point(12, 64) };
        _rgStyle = new RadioGroup { Location = new Point(90, 56), Size = new Size(470, 30) };
        _rgStyle.Properties.Items.AddRange(new[]
        {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(SmsStyle.FamilyTotal, "One message with the family total"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(SmsStyle.PerChild,    "A separate message for each child"),
        });
        _rgStyle.Properties.Columns = 2;
        _rgStyle.EditValueChanged += (s, e) => RefreshPreview();

        var lblTemplate = new LabelControl { Text = "Message:", Location = new Point(12, 100) };
        _cboTemplate = new ComboBoxEdit { Location = new Point(90, 96), Width = 300 };
        _cboTemplate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        _cboTemplate.Properties.Items.AddRange(_templateKeys);
        _cboTemplate.SelectedIndexChanged += (s, e) => ApplyTemplate(_cboTemplate.SelectedIndex);

        var lblEdit = new LabelControl
        {
            Text = "Wording (you can change it). Words in { } are filled in automatically: {names}  {class}  {balance}  {promised_amount}  {date}  {school}",
            Location = new Point(12, 130), AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(696, 16),
        };
        lblEdit.Appearance.ForeColor = Color.DimGray;
        _memoTemplate = new MemoEdit { Location = new Point(12, 150), Size = new Size(696, 90) };
        _memoTemplate.Properties.ScrollBars = ScrollBars.Vertical;
        _memoTemplate.EditValueChanged += (s, e) => RefreshPreview();

        var lblPreview = new LabelControl { Text = "This is exactly what the parent will receive:", Location = new Point(12, 252) };
        lblPreview.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
        _memoPreview = new MemoEdit { Location = new Point(12, 272), Size = new Size(696, 210) };
        _memoPreview.Properties.ReadOnly   = true;
        _memoPreview.Properties.ScrollBars = ScrollBars.Vertical;
        _memoPreview.Properties.Appearance.BackColor = Color.FromArgb(247, 249, 252);
        _memoPreview.TabStop = false;

        _lblCount = new LabelControl { Location = new Point(12, 492), AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(500, 16) };

        _btnSend = new SimpleButton { Text = "Send", Location = new Point(532, 520), Width = 84 };
        _btnSend.Click += BtnSend_Click;
        _btnCancel = new SimpleButton { Text = "Cancel", Location = new Point(624, 520), Width = 84 };
        _btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

        this.AcceptButton = null;
        this.CancelButton = _btnCancel;
        this.Controls.AddRange(new Control[]
        {
            _lblRecipient, _lblStudents, lblStyle, _rgStyle, lblTemplate, _cboTemplate,
            lblEdit, _memoTemplate, lblPreview, _memoPreview, _lblCount, _btnSend, _btnCancel,
        });
    }

    private void ApplyTemplate(int idx)
    {
        if (idx < 0 || idx >= _templateKeys.Length || _settings == null) return;
        string type = _templateTypes[idx];
        _memoTemplate.Text = type == null ? "" : FeesFollowUpService.TemplateFor(type, _settings);
        if (type == null) _memoTemplate.Focus();
        RefreshPreview();
    }

    // The children a message is about: the one child for a child-specific promise reminder,
    // otherwise every listed child in the family.
    private List<StudentSummary> ScopeFor(string type)
    {
        if (type != null && type != "General" && !string.IsNullOrWhiteSpace(_promiseStudentNumber))
        {
            var one = Students.Where(s => string.Equals(s.StudentNumber, _promiseStudentNumber,
                StringComparison.OrdinalIgnoreCase)).ToList();
            if (one.Count > 0) return one;
        }
        return Students;
    }

    private void RefreshPreview()
    {
        if (_settings == null || _cboTemplate.SelectedIndex < 0) return;
        string type  = _templateTypes[_cboTemplate.SelectedIndex];
        var    style = _rgStyle.EditValue is SmsStyle st ? st : SmsStyle.FamilyTotal;
        bool promiseMessage = type != null && type != "General";

        // Never the same text twice: a message with no child-specific words goes out once.
        _messages = FamilySms.Compose(style, _memoTemplate.Text.Trim(), ScopeFor(type),
                promiseMessage ? _promiseDate : DateTime.Today, _school,
                promiseMessage ? _promisedAmount : 0m, _promiseStudentNumber)
            .Distinct().ToList();

        if (_messages.Count == 0)
        {
            _memoPreview.Text = "";
            _lblCount.Text    = "Nothing to send yet.";
            _btnSend.Enabled  = false;
            return;
        }

        var lines = new List<string>();
        for (int i = 0; i < _messages.Count; i++)
        {
            if (_messages.Count > 1) lines.Add($"— Message {i + 1} of {_messages.Count} —");
            lines.Add(_messages[i]);
            lines.Add($"({_messages[i].Length} characters)");
            lines.Add("");
        }
        _memoPreview.Text = string.Join(Environment.NewLine, lines);

        int parts = _messages.Sum(FamilySms.SegmentCount);
        _lblCount.Text = _messages.Count == 1
            ? $"1 SMS will be sent" + (parts > 1 ? $" (long message: charged as {parts})" : "")
            : $"{_messages.Count} SMS will be sent" + (parts > _messages.Count ? $" (charged as {parts})" : "");
        _lblCount.Appearance.ForeColor = promiseMessage && !_hasPromise ? Color.DarkOrange : Color.Black;
        if (promiseMessage && !_hasPromise)
            _lblCount.Text += "   ·   This family has no open promise, so the date shown is today.";
        _btnSend.Enabled = true;
    }

    private void BtnSend_Click(object sender, EventArgs e)
    {
        if (_messages.Count == 0)
        {
            XtraMessageBox.Show("The message is empty.", "Send SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (_messages.Any(m => m.Contains("{") && m.Contains("}")))
        {
            XtraMessageBox.Show("The message still contains a word in { } that could not be filled in. " +
                "Check the spelling of the words in brackets.", "Send SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string type = _templateTypes[_cboTemplate.SelectedIndex] ?? "Manual";
        var failures = new List<string>();
        int sent = 0;
        _btnSend.Enabled = false;
        Cursor = Cursors.WaitCursor;
        try
        {
            foreach (string msg in _messages)
            {
                if (FeeSmsHelper.TrySend(_service.ConnectionString, RecipientPhone, msg, out string err))
                    sent++;
                else
                    failures.Add(err);
            }

            if (sent > 0)
            {
                try
                {
                    _service.LogManualReminderSent(Guardian.GuardianContact,
                        type == "Manual" || type == "General" ? DateTime.Today : _promiseDate, type);
                }
                catch (Exception logEx)
                {
                    failures.Add($"The SMS was sent, but recording it failed: {logEx.Message}");
                }
            }
        }
        finally
        {
            Cursor = Cursors.Default;
            _btnSend.Enabled = true;
        }

        if (failures.Count > 0)
            XtraMessageBox.Show($"Sent: {sent} of {_messages.Count}.\n\n" + string.Join("\n", failures.Distinct()),
                "Send SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        if (sent > 0)
        {
            StyleUsed    = _rgStyle.EditValue is SmsStyle st ? st : SmsStyle.FamilyTotal;
            SentSummary  = (sent == 1 ? "SMS sent: " : $"{sent} SMS sent. First: ") + _messages[0];
            DialogResult = DialogResult.OK;
            Close();
        }
        // If nothing was sent the reasons are shown above and the window stays open.
    }
}
