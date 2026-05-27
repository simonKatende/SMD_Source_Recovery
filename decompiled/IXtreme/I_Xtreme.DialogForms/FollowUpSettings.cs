using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.DialogForms;

public class FollowUpSettings : XtraForm
{
    private IContainer components = null;
    private SpinEdit spnStaleness;
    private SimpleButton btnOK;
    private SimpleButton btnCancel;
    private LabelControl lblStaleness;
    private readonly FeesFollowUpService service = new FeesFollowUpService();

    public FollowUpSettings()
    {
        InitializeComponent();
        spnStaleness.Value = service.GetStalenessThresholdDays();
    }

    private void InitializeComponent()
    {
        this.lblStaleness = new LabelControl { Text = "Flag as overdue after (days):", Location = new System.Drawing.Point(12, 18) };
        this.spnStaleness = new SpinEdit { Location = new System.Drawing.Point(200, 14), Width = 80 };
        this.spnStaleness.Properties.IsFloatValue = false;
        this.spnStaleness.Properties.MinValue = 0;
        this.spnStaleness.Properties.MaxValue = 365;
        this.btnOK = new SimpleButton { Text = "OK", Location = new System.Drawing.Point(95, 54), Width = 75 };
        this.btnCancel = new SimpleButton { Text = "Cancel", Location = new System.Drawing.Point(175, 54), Width = 75 };
        this.btnOK.Click += (s, e) =>
        {
            service.SetStalenessThresholdDays((int)spnStaleness.Value);
            base.DialogResult = DialogResult.OK;
            Dispose();
        };
        this.btnCancel.Click += (s, e) => { base.DialogResult = DialogResult.Cancel; Dispose(); };
        this.ClientSize = new System.Drawing.Size(295, 90);
        this.Controls.Add(lblStaleness);
        this.Controls.Add(spnStaleness);
        this.Controls.Add(btnOK);
        this.Controls.Add(btnCancel);
        this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Follow-up Settings";
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }
}
