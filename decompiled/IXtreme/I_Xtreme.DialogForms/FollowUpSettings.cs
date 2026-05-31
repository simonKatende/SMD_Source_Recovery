using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;

namespace I_Xtreme.DialogForms;

public class FollowUpSettings : XtraForm
{
    private IContainer components = null;
    private SpinEdit  spnStaleness;
    private DateEdit  dteTermStart;
    private DateEdit  dteTermEnd;
    private SpinEdit  spnCriticalThreshold;
    private MemoEdit  memo2Day;
    private MemoEdit  memoDayOf;
    private MemoEdit  memoOverdue;
    private SimpleButton btnOK, btnCancel, btnResetTemplates;

    private readonly FeesFollowUpService _service = new FeesFollowUpService();

    private const string Default2Day     = "Dear Parent, you promised to pay UGX {promised_amount} for {names} by {date}. Your overall balance is UGX {balance}. Please pay as promised. - {school}";
    private const string DefaultDayOf   = "Dear Parent, today is your promised payment date of UGX {promised_amount} for {names}. Your overall balance is UGX {balance}. Please make your payment today. - {school}";
    private const string DefaultOverdue = "Dear Parent, your payment of UGX {promised_amount} for {names} ({class}) was due on {date} but has not been received. Balance: UGX {balance}. Please pay immediately. - {school}";

    public FollowUpSettings()
    {
        InitializeComponent();
        var s = _service.GetSettings();
        spnStaleness.Value         = s.StaleThresholdDays;
        dteTermStart.EditValue     = (object)s.TermStartDate ?? DBNull.Value;
        dteTermEnd.EditValue       = (object)s.TermEndDate   ?? DBNull.Value;
        spnCriticalThreshold.Value = (decimal)(s.CriticalPacingGapThreshold * 100);
        memo2Day.Text    = !string.IsNullOrWhiteSpace(s.SmsTemplate2Day)    ? s.SmsTemplate2Day    : Default2Day;
        memoDayOf.Text   = !string.IsNullOrWhiteSpace(s.SmsTemplateDayOf)   ? s.SmsTemplateDayOf   : DefaultDayOf;
        memoOverdue.Text = !string.IsNullOrWhiteSpace(s.SmsTemplateOverdue) ? s.SmsTemplateOverdue : DefaultOverdue;
    }

    private void InitializeComponent()
    {
        // Row 1: Staleness
        var lblStaleness = new LabelControl
            { Text = "Flag as overdue after (days):", Location = new System.Drawing.Point(12, 18) };
        this.spnStaleness = new SpinEdit { Location = new System.Drawing.Point(210, 14), Width = 80 };
        this.spnStaleness.Properties.IsFloatValue = false;
        this.spnStaleness.Properties.MinValue     = 0;
        this.spnStaleness.Properties.MaxValue     = 365;

        // Row 2: Term start
        var lblTermStart = new LabelControl
            { Text = "Term start date:", Location = new System.Drawing.Point(12, 54) };
        this.dteTermStart = new DateEdit { Location = new System.Drawing.Point(210, 50), Width = 120 };

        // Row 3: Term end
        var lblTermEnd = new LabelControl
            { Text = "Term end date:", Location = new System.Drawing.Point(12, 90) };
        this.dteTermEnd = new DateEdit { Location = new System.Drawing.Point(210, 86), Width = 120 };

        // Row 4: Critical threshold
        var lblCritical = new LabelControl
            { Text = "Critical tier: pacing gap >= (%):", Location = new System.Drawing.Point(12, 126) };
        this.spnCriticalThreshold = new SpinEdit { Location = new System.Drawing.Point(210, 122), Width = 80 };
        this.spnCriticalThreshold.Properties.IsFloatValue = false;
        this.spnCriticalThreshold.Properties.MinValue     = 0;
        this.spnCriticalThreshold.Properties.MaxValue     = 100;

        // Row 5: 2-day reminder template
        var lbl2Day = new LabelControl
            { Text = "2-day reminder template ({promised_amount},{balance},{names},{class},{date},{school}):", Location = new System.Drawing.Point(12, 162), AutoSize = true };
        this.memo2Day = new MemoEdit { Location = new System.Drawing.Point(12, 180), Size = new System.Drawing.Size(580, 60) };
        this.memo2Day.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

        // Row 6: Day-of reminder template
        var lblDayOf = new LabelControl
            { Text = "Day-of reminder template ({promised_amount},{balance},{names},{class},{date},{school}):", Location = new System.Drawing.Point(12, 248), AutoSize = true };
        this.memoDayOf = new MemoEdit { Location = new System.Drawing.Point(12, 264), Size = new System.Drawing.Size(580, 60) };
        this.memoDayOf.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

        // Row 7: Overdue reminder template
        var lblOverdue = new LabelControl
        {
            Text     = "Overdue reminder template ({promised_amount},{balance},{names},{class},{date},{school}):",
            Location = new System.Drawing.Point(12, 332),
            AutoSize = true,
        };
        this.memoOverdue = new MemoEdit { Location = new System.Drawing.Point(12, 348), Size = new System.Drawing.Size(580, 60) };
        this.memoOverdue.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

        // Buttons
        this.btnResetTemplates = new SimpleButton
            { Text = "Reset Templates", Location = new System.Drawing.Point(12, 422), Width = 120 };
        this.btnOK = new SimpleButton
            { Text = "OK", Location = new System.Drawing.Point(430, 422), Width = 75 };
        this.btnCancel = new SimpleButton
            { Text = "Cancel", Location = new System.Drawing.Point(514, 422), Width = 75 };

        this.btnOK.Click += (s, e) =>
        {
            DateTime? termStart = dteTermStart.DateTime == DateTime.MinValue
                ? (DateTime?)null : dteTermStart.DateTime.Date;
            DateTime? termEnd   = dteTermEnd.DateTime == DateTime.MinValue
                ? (DateTime?)null : dteTermEnd.DateTime.Date;

            if (termStart.HasValue && termEnd.HasValue && termEnd.Value <= termStart.Value)
            {
                XtraMessageBox.Show("Term end date must be after term start date.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _service.SaveSettings(new FeesFollowUpSettings
            {
                StaleThresholdDays         = (int)spnStaleness.Value,
                TermStartDate              = termStart,
                TermEndDate                = termEnd,
                CriticalPacingGapThreshold = (double)(spnCriticalThreshold.Value / 100m),
                SmsTemplate2Day            = memo2Day.Text.Trim(),
                SmsTemplateDayOf           = memoDayOf.Text.Trim(),
                SmsTemplateOverdue         = memoOverdue.Text.Trim(),
            });
            base.DialogResult = DialogResult.OK;
            Dispose();
        };
        this.btnCancel.Click += (s, e) => { base.DialogResult = DialogResult.Cancel; Dispose(); };
        this.btnResetTemplates.Click += (s, e) =>
        {
            memo2Day.Text    = Default2Day;
            memoDayOf.Text   = DefaultDayOf;
            memoOverdue.Text = DefaultOverdue;
        };

        this.ClientSize = new System.Drawing.Size(608, 454);
        this.Controls.AddRange(new Control[]
        {
            lblStaleness, spnStaleness,
            lblTermStart, dteTermStart,
            lblTermEnd,   dteTermEnd,
            lblCritical,  spnCriticalThreshold,
            lbl2Day,      memo2Day,
            lblDayOf,     memoDayOf,
            lblOverdue,   memoOverdue,
            btnResetTemplates, btnOK, btnCancel,
        });
        this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        this.StartPosition   = FormStartPosition.CenterParent;
        this.Text            = "Follow-up Settings";
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }
}
