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
    private SimpleButton btnOK, btnCancel;

    private readonly FeesFollowUpService _service = new FeesFollowUpService();

    public FollowUpSettings()
    {
        InitializeComponent();
        var s = _service.GetSettings();
        spnStaleness.Value          = s.StaleThresholdDays;
        dteTermStart.EditValue      = (object)s.TermStartDate ?? DBNull.Value;
        dteTermEnd.EditValue        = (object)s.TermEndDate   ?? DBNull.Value;
        spnCriticalThreshold.Value  = (decimal)(s.CriticalPacingGapThreshold * 100); // stored as 0..1, shown as 0..100%
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

        // Buttons
        this.btnOK = new SimpleButton
            { Text = "OK", Location = new System.Drawing.Point(130, 158), Width = 75 };
        this.btnCancel = new SimpleButton
            { Text = "Cancel", Location = new System.Drawing.Point(214, 158), Width = 75 };

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
                StaleThresholdDays          = (int)spnStaleness.Value,
                TermStartDate               = termStart,
                TermEndDate                 = termEnd,
                CriticalPacingGapThreshold  = (double)(spnCriticalThreshold.Value / 100m),
            });
            base.DialogResult = DialogResult.OK;
            Dispose();
        };
        this.btnCancel.Click += (s, e) => { base.DialogResult = DialogResult.Cancel; Dispose(); };

        this.ClientSize = new System.Drawing.Size(320, 196);
        this.Controls.AddRange(new Control[]
        {
            lblStaleness, spnStaleness,
            lblTermStart, dteTermStart,
            lblTermEnd,   dteTermEnd,
            lblCritical,  spnCriticalThreshold,
            btnOK, btnCancel,
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
