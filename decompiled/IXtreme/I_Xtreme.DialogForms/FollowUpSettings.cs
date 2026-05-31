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
    private SpinEdit spnPartialCoverage;
    private SpinEdit spnHighBalAmt, spnHighBalDays;
    private SpinEdit spnMedBalAmt,  spnMedBalDays;
    private SpinEdit spnEscWeeks,   spnEscThreshold;
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
        spnPartialCoverage.Value = (decimal)(s.PartialPromiseCoverageThreshold * 100);
        spnHighBalAmt.Value      = (decimal)s.StaleHighBalanceAmount;
        spnHighBalDays.Value     = s.StaleHighBalanceDays;
        spnMedBalAmt.Value       = (decimal)s.StaleMedBalanceAmount;
        spnMedBalDays.Value      = s.StaleMedBalanceDays;
        spnEscWeeks.Value        = s.NoProgressEscalationWeeks;
        spnEscThreshold.Value    = (decimal)s.NoProgressPaymentThreshold;
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

        // Row 5: Partial promise coverage
        var lblPartial = new LabelControl
            { Text = "Exclude from daily list only if promise covers >= (%):",
              Location = new System.Drawing.Point(12, 162) };
        this.spnPartialCoverage = new SpinEdit
            { Location = new System.Drawing.Point(340, 158), Width = 80 };
        this.spnPartialCoverage.Properties.IsFloatValue = false;
        this.spnPartialCoverage.Properties.MinValue     = 0;
        this.spnPartialCoverage.Properties.MaxValue     = 100;

        // Row 6: Balance-tiered staleness section header
        var lblTierHeader = new LabelControl
            { Text = "Balance-tiered staleness (overrides base threshold above):",
              Location = new System.Drawing.Point(12, 198), AutoSize = true };

        // Row 7: High-balance tier
        var lblHighAmt = new LabelControl
            { Text = "High balance >=", Location = new System.Drawing.Point(12, 226) };
        this.spnHighBalAmt = new SpinEdit
            { Location = new System.Drawing.Point(110, 222), Width = 110 };
        this.spnHighBalAmt.Properties.IsFloatValue  = false;
        this.spnHighBalAmt.Properties.MinValue      = 0;
        this.spnHighBalAmt.Properties.MaxValue      = 100_000_000;
        var lblHighMid = new LabelControl
            { Text = "UGX → stale after", Location = new System.Drawing.Point(226, 226) };
        this.spnHighBalDays = new SpinEdit
            { Location = new System.Drawing.Point(326, 222), Width = 60 };
        this.spnHighBalDays.Properties.IsFloatValue = false;
        this.spnHighBalDays.Properties.MinValue     = 1;
        this.spnHighBalDays.Properties.MaxValue     = 365;
        var lblHighEnd = new LabelControl
            { Text = "days", Location = new System.Drawing.Point(392, 226) };

        // Row 8: Medium-balance tier
        var lblMedAmt = new LabelControl
            { Text = "Medium balance >=", Location = new System.Drawing.Point(12, 258) };
        this.spnMedBalAmt = new SpinEdit
            { Location = new System.Drawing.Point(120, 254), Width = 110 };
        this.spnMedBalAmt.Properties.IsFloatValue  = false;
        this.spnMedBalAmt.Properties.MinValue      = 0;
        this.spnMedBalAmt.Properties.MaxValue      = 100_000_000;
        var lblMedMid = new LabelControl
            { Text = "UGX → stale after", Location = new System.Drawing.Point(236, 258) };
        this.spnMedBalDays = new SpinEdit
            { Location = new System.Drawing.Point(336, 254), Width = 60 };
        this.spnMedBalDays.Properties.IsFloatValue = false;
        this.spnMedBalDays.Properties.MinValue     = 1;
        this.spnMedBalDays.Properties.MaxValue     = 365;
        var lblMedEnd = new LabelControl
            { Text = "days", Location = new System.Drawing.Point(402, 258) };

        // Row 9: No-progress escalation weeks
        var lblEscWeeks = new LabelControl
            { Text = "Escalate to Critical if no payment progress after (weeks):",
              Location = new System.Drawing.Point(12, 294) };
        this.spnEscWeeks = new SpinEdit
            { Location = new System.Drawing.Point(340, 290), Width = 80 };
        this.spnEscWeeks.Properties.IsFloatValue = false;
        this.spnEscWeeks.Properties.MinValue     = 0;
        this.spnEscWeeks.Properties.MaxValue     = 52;

        // Row 10: No-progress payment threshold
        var lblEscThreshold = new LabelControl
            { Text = "\"No progress\" means paid < (%) of billed:",
              Location = new System.Drawing.Point(12, 330) };
        this.spnEscThreshold = new SpinEdit
            { Location = new System.Drawing.Point(340, 326), Width = 80 };
        this.spnEscThreshold.Properties.IsFloatValue = false;
        this.spnEscThreshold.Properties.MinValue     = 0;
        this.spnEscThreshold.Properties.MaxValue     = 100;

        // Row 5: 2-day reminder template
        var lbl2Day = new LabelControl
            { Text = "2-day reminder template ({promised_amount},{balance},{names},{class},{date},{school}):", Location = new System.Drawing.Point(12, 360), AutoSize = true };
        this.memo2Day = new MemoEdit { Location = new System.Drawing.Point(12, 378), Size = new System.Drawing.Size(580, 60) };
        this.memo2Day.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

        // Row 6: Day-of reminder template
        var lblDayOf = new LabelControl
            { Text = "Day-of reminder template ({promised_amount},{balance},{names},{class},{date},{school}):", Location = new System.Drawing.Point(12, 446), AutoSize = true };
        this.memoDayOf = new MemoEdit { Location = new System.Drawing.Point(12, 462), Size = new System.Drawing.Size(580, 60) };
        this.memoDayOf.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

        // Row 7: Overdue reminder template
        var lblOverdue = new LabelControl
        {
            Text     = "Overdue reminder template ({promised_amount},{balance},{names},{class},{date},{school}):",
            Location = new System.Drawing.Point(12, 530),
            AutoSize = true,
        };
        this.memoOverdue = new MemoEdit { Location = new System.Drawing.Point(12, 546), Size = new System.Drawing.Size(580, 60) };
        this.memoOverdue.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

        // Buttons
        this.btnResetTemplates = new SimpleButton
            { Text = "Reset Templates", Location = new System.Drawing.Point(12, 620), Width = 120 };
        this.btnOK = new SimpleButton
            { Text = "OK", Location = new System.Drawing.Point(430, 620), Width = 75 };
        this.btnCancel = new SimpleButton
            { Text = "Cancel", Location = new System.Drawing.Point(514, 620), Width = 75 };

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
                PartialPromiseCoverageThreshold = (double)(spnPartialCoverage.Value / 100m),
                StaleHighBalanceAmount          = spnHighBalAmt.Value,
                StaleHighBalanceDays            = (int)spnHighBalDays.Value,
                StaleMedBalanceAmount           = spnMedBalAmt.Value,
                StaleMedBalanceDays             = (int)spnMedBalDays.Value,
                NoProgressEscalationWeeks       = (int)spnEscWeeks.Value,
                NoProgressPaymentThreshold      = (double)spnEscThreshold.Value,
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

        this.ClientSize = new System.Drawing.Size(608, 652);
        this.Controls.AddRange(new Control[]
        {
            lblStaleness, spnStaleness,
            lblTermStart, dteTermStart,
            lblTermEnd,   dteTermEnd,
            lblCritical,  spnCriticalThreshold,
            lblPartial,  spnPartialCoverage,
            lblTierHeader,
            lblHighAmt,  spnHighBalAmt, lblHighMid, spnHighBalDays, lblHighEnd,
            lblMedAmt,   spnMedBalAmt,  lblMedMid,  spnMedBalDays,  lblMedEnd,
            lblEscWeeks, spnEscWeeks,
            lblEscThreshold, spnEscThreshold,
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
