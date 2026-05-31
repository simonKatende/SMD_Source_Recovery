using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;

namespace I_Xtreme.DialogForms;

public class dlgTemplatedSms : XtraForm
{
    private readonly FeesFollowUpService _service = new FeesFollowUpService();
    private ComboBoxEdit  _cboTemplate;
    private MemoEdit      _memoMessage;
    private SimpleButton  _btnSend, _btnCancel;
    private LabelControl  _lblRecipient, _lblStudents;

    // Inputs -- set before ShowDialog()
    public string               RecipientPhone { get; set; }
    public List<StudentSummary> Students       { get; set; }
    public string               GuardianKey    { get; set; }
    public DateTime?            PromiseDate    { get; set; }
    public decimal              PromisedAmount { get; set; }

    // Output
    public string SentSummary { get; private set; }

    private readonly string[] _templateKeys  = { "3-Day Reminder", "Day-Of Reminder", "Overdue Reminder", "General Reminder", "Freeform" };
    private readonly string[] _templateTypes = { "3DayBefore",     "DayOf",           "Overdue",          "General",          null };

    public dlgTemplatedSms() { InitializeComponent(); }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        _lblRecipient.Text = $"To: {RecipientPhone}";
        string names = string.Join(", ", (Students ?? new List<StudentSummary>())
            .Select(s => $"{s.FullName} ({s.ClassId})"));
        _lblStudents.Text = $"Students: {names}";
        // Pre-select General Reminder when guardian has no promise on record
        int defaultIdx = (PromisedAmount == 0 && PromiseDate == null) ? 3 : 0;
        _cboTemplate.SelectedIndex = defaultIdx;
        ApplyTemplate(defaultIdx);
    }

    private void InitializeComponent()
    {
        this.Text            = "Send Reminder SMS";
        this.Size            = new System.Drawing.Size(700, 420);
        this.StartPosition   = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

        _lblRecipient = new LabelControl
            { Location = new System.Drawing.Point(12, 14), AutoSize = true };
        _lblStudents = new LabelControl
            { Location = new System.Drawing.Point(12, 34), AutoSize = true };

        var lblTemplate = new LabelControl
            { Text = "Template:", Location = new System.Drawing.Point(12, 66) };
        _cboTemplate = new ComboBoxEdit
            { Location = new System.Drawing.Point(90, 62), Width = 220 };
        _cboTemplate.Properties.TextEditStyle =
            DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        _cboTemplate.Properties.Items.AddRange(_templateKeys);
        _cboTemplate.SelectedIndexChanged += (s, e2) => ApplyTemplate(_cboTemplate.SelectedIndex);

        var lblNote = new LabelControl
        {
            Text     = "Message template below -- {names} and {class} are replaced per student at send time:",
            Location = new System.Drawing.Point(12, 100),
            AutoSize = true,
        };
        _memoMessage = new MemoEdit
            { Location = new System.Drawing.Point(12, 118), Size = new System.Drawing.Size(660, 200) };
        _memoMessage.Properties.ScrollBars = ScrollBars.Vertical;

        _btnSend = new SimpleButton
            { Text = "Send", Location = new System.Drawing.Point(516, 332), Width = 80 };
        _btnSend.Click += BtnSend_Click;

        _btnCancel = new SimpleButton
            { Text = "Cancel", Location = new System.Drawing.Point(604, 332), Width = 80 };
        _btnCancel.Click += (s, e2) => { DialogResult = DialogResult.Cancel; Close(); };

        this.Controls.AddRange(new Control[]
            { _lblRecipient, _lblStudents, lblTemplate, _cboTemplate, lblNote, _memoMessage, _btnSend, _btnCancel });
    }

    private void ApplyTemplate(int idx)
    {
        if (idx < 0 || idx >= _templateKeys.Length) return;
        if (_templateTypes[idx] == null) { _memoMessage.Text = ""; return; }

        var      settings = _service.GetSettings();
        string   school   = _service.GetSchoolName();
        DateTime date     = PromiseDate ?? DateTime.Today;
        // Use first student for preview
        var      first    = Students?.FirstOrDefault();
        decimal  balance  = first?.Balance ?? 0m;
        string   name     = first?.FullName ?? "{names}";
        string   cls      = first?.ClassId  ?? "{class}";

        string template = _templateTypes[idx] switch
        {
            "3DayBefore" => !string.IsNullOrWhiteSpace(settings.SmsTemplate2Day)    ? settings.SmsTemplate2Day    : FeesFollowUpService.DefaultPreDue,
            "DayOf"      => !string.IsNullOrWhiteSpace(settings.SmsTemplateDayOf)   ? settings.SmsTemplateDayOf   : FeesFollowUpService.DefaultDayOf,
            "Overdue"    => !string.IsNullOrWhiteSpace(settings.SmsTemplateOverdue) ? settings.SmsTemplateOverdue : FeesFollowUpService.DefaultOverdue,
            "General"    => FeesFollowUpService.DefaultGeneral,
            _            => ""
        };
        _memoMessage.Text = FeesFollowUpService.RenderTemplate(
            template, balance, name, cls, date, school, PromisedAmount);
    }

    private void BtnSend_Click(object sender, EventArgs e)
    {
        string templateText = _memoMessage.Text.Trim();
        if (string.IsNullOrEmpty(templateText))
        {
            XtraMessageBox.Show("Message cannot be empty.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        var failures = new List<string>();
        int sent     = 0;
        string school = _service.GetSchoolName();
        DateTime date = PromiseDate ?? DateTime.Today;
        string reminderType = _templateTypes[_cboTemplate.SelectedIndex] ?? "Manual";

        foreach (var student in Students ?? new List<StudentSummary>())
        {
            string msg = FeesFollowUpService.RenderTemplate(
                templateText, student.Balance, student.FullName, student.ClassId,
                date, school, PromisedAmount);

            if (FeeSmsHelper.TrySend(_service.ConnectionString, RecipientPhone, msg, out string err))
            {
                _service.LogManualReminderSent(RecipientPhone, student.StudentNumber, date, reminderType);
                sent++;
            }
            else
            {
                failures.Add($"{student.FullName}: {err}");
            }
        }

        if (failures.Count > 0)
            XtraMessageBox.Show($"Sent: {sent}. Failed:\n" + string.Join("\n", failures),
                "SMS -- Partial Send", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        SentSummary  = $"Template SMS sent to {sent} student(s)";
        DialogResult = DialogResult.OK;
        Close();
    }
}
