using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;

namespace I_Xtreme.DialogForms;

/// <summary>
/// Fees Follow-up settings, written as plain sentences and grouped on four tabs:
/// Term, Daily list, SMS reminders, Advanced.
/// </summary>
public class FollowUpSettings : XtraForm
{
    private IContainer components = null;

    private XtraTabControl tabs;
    private XtraTabPage pageTerm, pageDaily, pageSms, pageAdvanced;

    // Term
    private LabelControl lblTermName, lblTermNotice, lblTermWeek;
    private DateEdit  dteTermStart;
    private DateEdit  dteTermEnd;
    private SpinEdit  spnCollectionGoal;

    // Daily list
    private SpinEdit  spnStaleness;
    private SpinEdit  spnHighBalAmt, spnHighBalDays;
    private SpinEdit  spnMedBalAmt,  spnMedBalDays;
    private SpinEdit  spnPartialCoverage;
    private SpinEdit  spnPromiseResurface;

    // SMS reminders
    private CheckEdit    chkAuto;
    private TimeEdit     timeAuto;
    private LabelControl lblAutoStatus;
    private SimpleButton btnScheduledTask;
    private RadioGroup   rgSmsStyle;
    private SpinEdit     spnGeneralCooldown;
    private ComboBoxEdit cboMessage;
    private MemoEdit     memoMessage, memoPreview;
    private LabelControl lblMessageInfo;
    private int          _messageIndex = -1;

    // Advanced
    private SpinEdit spnCriticalShortfall, spnEscWeeks, spnEscThreshold, spnCallReqWindow;

    private SimpleButton btnOK, btnCancel, btnRestore;

    private readonly FeesFollowUpService _service = new FeesFollowUpService();
    private FeesFollowUpSettings _loaded;
    private string _school = "";

    // The four messages, in the order shown in the drop-down.
    private static readonly string[] MessageTypes = { "3DayBefore", "DayOf", "Overdue", "General" };
    private static readonly string[] MessageNames =
    {
        "Promise reminder — 3 days before the date",
        "Promise reminder — on the day",
        "Promise reminder — when overdue",
        "Balance reminder — no promise made",
    };
    private readonly string[] _messages = new string[4];

    private const string TaskName = "SMD Fees Promise Reminders";

    public FollowUpSettings()
    {
        InitializeComponent();
        LoadValues(_service.GetSettings());
        try { _school = _service.GetSchoolName(); }
        catch (Exception ex) { Debug.WriteLine($"FollowUpSettings: school name unavailable for the SMS preview: {ex.Message}"); }
        cboMessage.SelectedIndex = 0;
        UpdateTermWeek();
        UpdateAutoStatus();
    }

    private void LoadValues(FeesFollowUpSettings s)
    {
        _loaded = s;
        lblTermName.Text = $"Current term:  {FeesTerm.DisplayName(s.WorkingSemester)}";
        lblTermNotice.Visible = s.TermDatesNeedSetting;

        dteTermStart.EditValue  = (object)s.TermStartDate ?? null;
        dteTermEnd.EditValue    = (object)s.TermEndDate   ?? null;
        spnCollectionGoal.Value = (decimal)(s.CollectionGoal * 100.0);

        spnStaleness.Value        = s.StaleThresholdDays;
        spnHighBalAmt.Value       = s.StaleHighBalanceAmount;
        spnHighBalDays.Value      = s.StaleHighBalanceDays;
        spnMedBalAmt.Value        = s.StaleMedBalanceAmount;
        spnMedBalDays.Value       = s.StaleMedBalanceDays;
        spnPartialCoverage.Value  = (decimal)(s.PartialPromiseCoverageThreshold * 100);
        spnPromiseResurface.Value = s.PromiseResurfaceDays;

        chkAuto.Checked          = s.AutoRemindersEnabled;
        timeAuto.Time            = DateTime.Today + AutoReminderSchedule.ParseTime(s.AutoReminderTime);
        rgSmsStyle.EditValue     = s.DefaultSmsStyle;
        spnGeneralCooldown.Value = s.GeneralReminderCooldownDays;
        for (int i = 0; i < MessageTypes.Length; i++)
            _messages[i] = FeesFollowUpService.TemplateFor(MessageTypes[i], s);

        spnCriticalShortfall.Value = (decimal)s.CriticalShortfallPoints;
        spnEscWeeks.Value          = s.NoProgressEscalationWeeks;
        spnEscThreshold.Value      = (decimal)s.NoProgressPaymentThreshold;
        spnCallReqWindow.Value     = s.CallRequiredWindowDays;
    }

    // ── Layout helpers ────────────────────────────────────────────────────────

    private static SpinEdit Spin(int width, decimal min, decimal max)
    {
        var spin = new SpinEdit { Width = width };
        spin.Properties.IsFloatValue = false;
        spin.Properties.MinValue     = min;
        spin.Properties.MaxValue     = max;
        spin.Properties.MaskSettings.Set("mask", "N0");
        spin.Properties.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
        spin.Properties.DisplayFormat.FormatString = "N0";
        spin.Properties.EditFormat.FormatType      = DevExpress.Utils.FormatType.Numeric;
        spin.Properties.EditFormat.FormatString    = "N0";
        return spin;
    }

    /// <summary>
    /// Lay out one setting as a sentence ("Call again after [7] days.") with a grey explanation
    /// underneath. Parts are strings (text) or controls (editors). Returns the Y for the next row.
    /// </summary>
    private static int Sentence(XtraTabPage page, int y, string help, params object[] parts)
    {
        int x = 18;
        foreach (object part in parts)
        {
            if (part is string text)
            {
                var lbl = new LabelControl { Text = text, Location = new Point(x, y + 3) };
                page.Controls.Add(lbl);
                x += TextRenderer.MeasureText(text, DevExpress.Utils.AppearanceObject.DefaultFont).Width + 4;
            }
            else if (part is Control editor)
            {
                editor.Location = new Point(x, y);
                page.Controls.Add(editor);
                x += editor.Width + 6;
            }
        }
        if (string.IsNullOrEmpty(help)) return y + 34;

        var lblHelp = new LabelControl
        {
            Text = help, Location = new Point(18, y + 26),
            AutoSizeMode = LabelAutoSizeMode.Vertical, Width = 640,
        };
        lblHelp.Appearance.ForeColor = Color.DimGray;
        lblHelp.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
        page.Controls.Add(lblHelp);
        int helpHeight = TextRenderer.MeasureText(help, DevExpress.Utils.AppearanceObject.DefaultFont,
            new Size(640, 0), TextFormatFlags.WordBreak).Height;
        return y + 30 + helpHeight + 14;
    }

    private static LabelControl Heading(XtraTabPage page, int y, string text)
    {
        var lbl = new LabelControl { Text = text, Location = new Point(18, y) };
        lbl.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
        page.Controls.Add(lbl);
        return lbl;
    }

    private void InitializeComponent()
    {
        this.Text            = "Follow-up Settings";
        this.ClientSize      = new Size(700, 600);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox     = false;
        this.MinimizeBox     = false;
        this.StartPosition   = FormStartPosition.CenterParent;
        this.AutoScroll      = true;   // still usable on a very small screen

        tabs = new XtraTabControl { Location = new Point(8, 8), Size = new Size(684, 540) };
        pageTerm     = new XtraTabPage { Text = "Term" };
        pageDaily    = new XtraTabPage { Text = "Daily list" };
        pageSms      = new XtraTabPage { Text = "SMS reminders" };
        pageAdvanced = new XtraTabPage { Text = "Advanced" };
        tabs.TabPages.AddRange(new[] { pageTerm, pageDaily, pageSms, pageAdvanced });

        BuildTermPage();
        BuildDailyPage();
        BuildSmsPage();
        BuildAdvancedPage();

        btnRestore = new SimpleButton { Text = "Restore recommended settings", Location = new Point(8, 560), Width = 200 };
        btnRestore.ToolTip = "Puts the settings on the tab you are looking at back to the recommended values";
        btnRestore.Click += (s, e) => RestoreCurrentTab();
        btnOK = new SimpleButton { Text = "Save", Location = new Point(524, 560), Width = 80 };
        btnOK.Click += (s, e) => Save();
        btnCancel = new SimpleButton { Text = "Cancel", Location = new Point(612, 560), Width = 80 };
        btnCancel.Click += (s, e) => { base.DialogResult = DialogResult.Cancel; Close(); };

        this.CancelButton = btnCancel;
        this.Controls.AddRange(new Control[] { tabs, btnRestore, btnOK, btnCancel });
    }

    // ── Term ──────────────────────────────────────────────────────────────────

    private void BuildTermPage()
    {
        lblTermName = Heading(pageTerm, 16, "Current term:");
        var lblTermSource = new LabelControl
        {
            Text = "The term is chosen in the application's term setup. Fees Follow-up always works in that term: " +
                   "calls, promises and reminders from earlier terms are kept as history but no longer drive the lists.",
            Location = new Point(18, 40), AutoSizeMode = LabelAutoSizeMode.Vertical, Width = 640,
        };
        lblTermSource.Appearance.ForeColor = Color.DimGray;
        lblTermSource.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
        pageTerm.Controls.Add(lblTermSource);

        lblTermNotice = new LabelControl
        {
            Text = "  The dates for this term have not been entered yet. Please enter them below.",
            Location = new Point(18, 84), AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(640, 24), Visible = false,
        };
        lblTermNotice.Appearance.BackColor = Color.LightGoldenrodYellow;
        lblTermNotice.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
        pageTerm.Controls.Add(lblTermNotice);

        dteTermStart = new DateEdit { Width = 120 };
        dteTermEnd   = new DateEdit { Width = 120 };
        dteTermStart.EditValueChanged += (s, e) => UpdateTermWeek();
        dteTermEnd.EditValueChanged   += (s, e) => UpdateTermWeek();

        int y = 124;
        y = Sentence(pageTerm, y, null, "This term starts on", dteTermStart, "and ends on", dteTermEnd, ".");
        lblTermWeek = new LabelControl { Location = new Point(18, y - 6), AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(640, 16) };
        lblTermWeek.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
        pageTerm.Controls.Add(lblTermWeek);
        var lblWhyDates = new LabelControl
        {
            Text = "These dates tell the system how far through the term we are, and so how much each family " +
                   "should have paid by now. Without them, nobody can be marked Critical.",
            Location = new Point(18, y + 14), AutoSizeMode = LabelAutoSizeMode.Vertical, Width = 640,
        };
        lblWhyDates.Appearance.ForeColor = Color.DimGray;
        lblWhyDates.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
        pageTerm.Controls.Add(lblWhyDates);

        spnCollectionGoal = Spin(60, 1, 100);
        Sentence(pageTerm, y + 66,
            "The school's target. Families are expected to pay towards it steadily through the term. Recommended: 98.",
            "By the end of term we aim to collect", spnCollectionGoal, "% of all fees.");
    }

    private void UpdateTermWeek()
    {
        DateTime? start = dteTermStart.EditValue as DateTime?;
        DateTime? end   = dteTermEnd.EditValue as DateTime?;
        if (!start.HasValue || !end.HasValue)
        {
            lblTermWeek.Text = "";
            return;
        }
        if (end.Value.Date <= start.Value.Date)
        {
            lblTermWeek.Text = "The end date must be after the start date.";
            lblTermWeek.Appearance.ForeColor = Color.Firebrick;
            return;
        }
        var (week, total) = FeesTerm.WeekOfTerm(DateTime.Today, start, end);
        lblTermWeek.Appearance.ForeColor = Color.SeaGreen;
        lblTermWeek.Text = week == 0
            ? $"The term has not started yet ({total} weeks long)."
            : DateTime.Today > end.Value.Date
                ? $"This term has ended ({total} weeks long)."
                : $"Today is in week {week} of {total}.";
    }

    // ── Daily list ────────────────────────────────────────────────────────────

    private void BuildDailyPage()
    {
        Heading(pageDaily, 16, "How often should a family be called?");
        spnStaleness   = Spin(60, 1, 365);
        spnHighBalAmt  = Spin(110, 0, 100_000_000);
        spnHighBalDays = Spin(60, 1, 365);
        spnMedBalAmt   = Spin(110, 0, 100_000_000);
        spnMedBalDays  = Spin(60, 1, 365);

        int y = 44;
        y = Sentence(pageDaily, y,
            "A family comes back onto the daily list when this many days pass without anyone reaching them. Recommended: 7.",
            "Call a family again if nobody has spoken to them for", spnStaleness, "days.");
        y = Sentence(pageDaily, y, null,
            "If they owe UGX", spnHighBalAmt, "or more, call again after", spnHighBalDays, "days.");
        y = Sentence(pageDaily, y - 4,
            "Families owing more are called more often. Recommended: 1,000,000 after 3 days and 500,000 after 5 days.",
            "If they owe UGX", spnMedBalAmt, "or more, call again after", spnMedBalDays, "days.");

        Heading(pageDaily, y + 6, "Families who have promised to pay");
        spnPartialCoverage  = Spin(60, 0, 100);
        spnPromiseResurface = Spin(60, 0, 365);
        y = Sentence(pageDaily, y + 34,
            "A family with a promise is left alone until the promise date, but only if the promise covers enough " +
            "of what they owe. They always appear on the day the promise falls due. Recommended: 50.",
            "Leave them off the list while their promise covers at least", spnPartialCoverage, "% of what they owe.");
        Sentence(pageDaily, y,
            "Near the end of term everyone still owing is shown, so nothing is left uncollected. Recommended: 14.",
            "In the last", spnPromiseResurface, "days of term, show them anyway.");
    }

    // ── SMS reminders ─────────────────────────────────────────────────────────

    private void BuildSmsPage()
    {
        Heading(pageSms, 12, "Automatic promise reminders");
        chkAuto  = new CheckEdit { Text = "Send promise reminders automatically every day at", Width = 290 };
        timeAuto = new TimeEdit { Width = 70 };
        timeAuto.Properties.Mask.EditMask = "HH:mm";
        timeAuto.Properties.Mask.UseMaskAsDisplayFormat = true;
        chkAuto.CheckedChanged += (s, e) => timeAuto.Enabled = chkAuto.Checked;

        int y = Sentence(pageSms, 36,
            "Parents who made a promise are reminded 3 days before, on the day, and when it is overdue. " +
            "Parents who have paid what they promised are not reminded. " +
            "Balance reminders to parents with no promise are never sent automatically.",
            chkAuto, timeAuto);

        lblAutoStatus = new LabelControl { Location = new Point(18, y - 8), AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(420, 16) };
        lblAutoStatus.Appearance.ForeColor = Color.SeaGreen;
        btnScheduledTask = new SimpleButton
        {
            Text = "Also send when the application is closed…", Location = new Point(446, y - 12), Width = 220,
        };
        btnScheduledTask.ToolTip = "Sets this computer to send the reminders at the chosen time even if nobody opens the application. " +
                                   "The computer must be switched on and logged in.";
        btnScheduledTask.Click += (s, e) => CreateScheduledTask();
        pageSms.Controls.Add(lblAutoStatus);
        pageSms.Controls.Add(btnScheduledTask);

        y += 20;
        Heading(pageSms, y, "Families with more than one child");
        rgSmsStyle = new RadioGroup { Location = new Point(18, y + 22), Size = new Size(640, 28) };
        rgSmsStyle.Properties.Items.AddRange(new[]
        {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(SmsStyle.FamilyTotal, "One message with the family total (recommended)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(SmsStyle.PerChild,    "A separate message for each child"),
        });
        rgSmsStyle.Properties.Columns = 2;
        rgSmsStyle.EditValueChanged += (s, e) => UpdateMessagePreview();
        pageSms.Controls.Add(rgSmsStyle);
        var lblStyleHelp = new LabelControl
        {
            Text = "Used for every family unless a different choice has been set for that family on its interaction window.",
            Location = new Point(18, y + 54),
        };
        lblStyleHelp.Appearance.ForeColor = Color.DimGray;
        pageSms.Controls.Add(lblStyleHelp);

        spnGeneralCooldown = Spin(60, 1, 365);
        y = Sentence(pageSms, y + 78, null,
            "Wait at least", spnGeneralCooldown, "days before sending the same family another balance reminder.");

        // The four messages
        Heading(pageSms, y, "Wording of the messages");
        cboMessage = new ComboBoxEdit { Location = new Point(18, y + 22), Width = 330 };
        cboMessage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        cboMessage.Properties.Items.AddRange(MessageNames);
        cboMessage.SelectedIndexChanged += (s, e) => ShowMessage(cboMessage.SelectedIndex);

        // Buttons that drop a fill-in word into the message at the cursor.
        int bx = 356;
        foreach (var (caption, token) in new[]
                 {
                     ("Names", "{names}"), ("Class", "{class}"), ("Balance", "{balance}"),
                     ("Amount", "{promised_amount}"), ("Date", "{date}"), ("School", "{school}"),
                 })
        {
            var b = new SimpleButton { Text = caption, Location = new Point(bx, y + 21), Width = 50, Height = 22 };
            b.ToolTip = $"Insert {token} — replaced with the real value when the message is sent";
            b.Click += (s, e) =>
            {
                memoMessage.Focus();
                memoMessage.SelectedText = token;
            };
            pageSms.Controls.Add(b);
            bx += 52;
        }

        memoMessage = new MemoEdit { Location = new Point(18, y + 50), Size = new Size(648, 62) };
        memoMessage.Properties.ScrollBars = ScrollBars.Vertical;
        memoMessage.Properties.MaxLength  = 900;
        memoMessage.EditValueChanged += (s, e) => UpdateMessagePreview();

        var lblPreview = new LabelControl { Text = "What a parent with two children would receive.  Words inside [[ ]] are left out when the parent gave no amount.", Location = new Point(18, y + 118) };
        lblPreview.Appearance.ForeColor = Color.DimGray;
        memoPreview = new MemoEdit { Location = new Point(18, y + 136), Size = new Size(648, 74) };
        memoPreview.Properties.ReadOnly   = true;
        memoPreview.Properties.ScrollBars = ScrollBars.Vertical;
        memoPreview.Properties.Appearance.BackColor = Color.FromArgb(247, 249, 252);
        memoPreview.TabStop = false;
        lblMessageInfo = new LabelControl { Location = new Point(18, y + 214), AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(648, 14) };

        pageSms.Controls.AddRange(new Control[] { cboMessage, memoMessage, lblPreview, memoPreview, lblMessageInfo });
    }

    private void StoreMessage()
    {
        if (_messageIndex >= 0) _messages[_messageIndex] = memoMessage.Text.Trim();
    }

    private void ShowMessage(int index)
    {
        if (index < 0) return;
        StoreMessage();
        _messageIndex    = -1;            // do not store while swapping the text
        memoMessage.Text = _messages[index] ?? "";
        _messageIndex    = index;
        UpdateMessagePreview();
    }

    private void UpdateMessagePreview()
    {
        if (_messageIndex < 0 || memoPreview == null) return;
        var sample = new List<StudentSummary>
        {
            new StudentSummary { StudentNumber = "1", FullName = "Aisha Nakato", ClassId = "P.3", Balance = 250_000m },
            new StudentSummary { StudentNumber = "2", FullName = "Brian Nakato", ClassId = "P.6", Balance = 400_000m },
        };
        bool promiseMessage = MessageTypes[_messageIndex] != "General";
        var style = rgSmsStyle.EditValue is SmsStyle st ? st : SmsStyle.FamilyTotal;
        var messages = FamilySms.Compose(style, memoMessage.Text.Trim(), sample, DateTime.Today.AddDays(3),
            string.IsNullOrWhiteSpace(_school) ? "Your School" : _school, promiseMessage ? 300_000m : 0m);

        memoPreview.Text = string.Join(Environment.NewLine + Environment.NewLine, messages);
        if (messages.Count == 0)
        {
            lblMessageInfo.Text = "This message is empty. An empty message is replaced by the recommended wording.";
            lblMessageInfo.Appearance.ForeColor = Color.DarkOrange;
            return;
        }
        int longest = messages.Max(m => m.Length);
        int parts   = messages.Max(FamilySms.SegmentCount);
        lblMessageInfo.Appearance.ForeColor = parts > 1 ? Color.DarkOrange : Color.DimGray;
        lblMessageInfo.Text = $"{messages.Count} SMS for this family   ·   about {longest} characters each" +
            (parts > 1 ? $"   ·   long: each is charged as {parts} SMS" : "   ·   fits in one SMS");
    }

    private void UpdateAutoStatus()
    {
        timeAuto.Enabled = chkAuto.Checked;
        try
        {
            var last = _service.GetLastAutoRun();
            lblAutoStatus.Text = last == null
                ? "Automatic reminders have not run yet."
                : $"Last automatic run: {last.StartedAt:dd-MMM-yyyy HH:mm} — {last.SentCount} sent" +
                  (last.FailedCount > 0 ? $", {last.FailedCount} failed" : "");
        }
        catch (Exception ex)
        {
            lblAutoStatus.Text = "";
            Debug.WriteLine($"FollowUpSettings: could not read the last automatic reminder run: {ex.Message}");
        }
    }

    /// <summary>
    /// Create (or replace) a Windows scheduled task for the signed-in user that starts this
    /// application in its no-window "send fee reminders" mode every day at the chosen time.
    /// </summary>
    private void CreateScheduledTask()
    {
        if (!chkAuto.Checked)
        {
            XtraMessageBox.Show("Tick \"Send promise reminders automatically\" first.", "Follow-up Settings",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        string time = timeAuto.Time.ToString("HH:mm");
        if (XtraMessageBox.Show(
                $"Set this computer to send promise reminders every day at {time}, even when the application is closed?\n\n" +
                "The computer must be switched on and logged in at that time. " +
                "Reminders are still sent only once a day, whichever computer sends first.",
                "Follow-up Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        try
        {
            string exe = Application.ExecutablePath;
            var psi = new ProcessStartInfo
            {
                FileName  = "schtasks.exe",
                Arguments = $"/Create /F /SC DAILY /ST {time} /TN \"{TaskName}\" " +
                            $"/TR \"\\\"{exe}\\\" {Program.SendFeeRemindersSwitch}\"",
                UseShellExecute        = false,
                CreateNoWindow         = true,
                RedirectStandardOutput = true,
                RedirectStandardError  = true,
            };
            using var proc = Process.Start(psi);
            string output = proc.StandardOutput.ReadToEnd();
            string error  = proc.StandardError.ReadToEnd();
            proc.WaitForExit();
            if (proc.ExitCode != 0)
                throw new InvalidOperationException(string.IsNullOrWhiteSpace(error) ? output : error);

            XtraMessageBox.Show(
                $"Done. This computer will send the promise reminders every day at {time}.\n\n" +
                "Remember to press Save so the automatic setting is kept.",
                "Follow-up Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(
                $"Windows could not create the daily task \"{TaskName}\".\n\n{ex.Message}",
                "Follow-up Settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    // ── Advanced ──────────────────────────────────────────────────────────────

    private void BuildAdvancedPage()
    {
        var intro = new LabelControl
        {
            Text = "These settings decide who is marked Critical. Most schools never need to change them.",
            Location = new Point(18, 16),
        };
        intro.Appearance.ForeColor = Color.DimGray;
        pageAdvanced.Controls.Add(intro);

        spnCriticalShortfall = Spin(60, 0, 100);
        spnEscWeeks          = Spin(60, 0, 52);
        spnEscThreshold      = Spin(60, 0, 100);
        spnCallReqWindow     = Spin(60, 1, 365);

        int y = 46;
        y = Sentence(pageAdvanced, y,
            "Example: half-way through the term a family should have paid about 49%. With this set to 25, a family " +
            "that has paid less than 24% and has made no promise is marked Critical. Recommended: 25.",
            "Mark a family Critical when they have paid", spnCriticalShortfall,
            "% less than they should have by now.");
        y = Sentence(pageAdvanced, y,
            "Catches families who keep being called but hardly pay. Set the weeks to 0 to switch this off. " +
            "Recommended: 4 weeks and 30%.",
            "Also mark them Critical after", spnEscWeeks, "weeks of follow-up if they have paid less than",
            spnEscThreshold, "%.");
        Sentence(pageAdvanced, y,
            "An overdue SMS that gets no payment should be followed by a phone call. The family is pushed up the " +
            "list for this many days. Recommended: 14.",
            "After an overdue SMS, mark the family \"needs a call\" for", spnCallReqWindow, "days.");
    }

    // ── Restore / save ────────────────────────────────────────────────────────

    private void RestoreCurrentTab()
    {
        var d = new FeesFollowUpSettings();   // property defaults are the recommended values
        if (tabs.SelectedTabPage == pageTerm)
        {
            spnCollectionGoal.Value = (decimal)(d.CollectionGoal * 100.0);   // dates are left alone
        }
        else if (tabs.SelectedTabPage == pageDaily)
        {
            spnStaleness.Value        = d.StaleThresholdDays;
            spnHighBalAmt.Value       = d.StaleHighBalanceAmount;
            spnHighBalDays.Value      = d.StaleHighBalanceDays;
            spnMedBalAmt.Value        = d.StaleMedBalanceAmount;
            spnMedBalDays.Value       = d.StaleMedBalanceDays;
            spnPartialCoverage.Value  = (decimal)(d.PartialPromiseCoverageThreshold * 100);
            spnPromiseResurface.Value = d.PromiseResurfaceDays;
        }
        else if (tabs.SelectedTabPage == pageSms)
        {
            rgSmsStyle.EditValue     = d.DefaultSmsStyle;
            spnGeneralCooldown.Value = d.GeneralReminderCooldownDays;
            for (int i = 0; i < MessageTypes.Length; i++)
                _messages[i] = FamilySms.DefaultTemplate(MessageTypes[i]);
            int showing = _messageIndex;
            _messageIndex = -1;
            ShowMessage(showing < 0 ? 0 : showing);
        }
        else
        {
            spnCriticalShortfall.Value = (decimal)d.CriticalShortfallPoints;
            spnEscWeeks.Value          = d.NoProgressEscalationWeeks;
            spnEscThreshold.Value      = (decimal)d.NoProgressPaymentThreshold;
            spnCallReqWindow.Value     = d.CallRequiredWindowDays;
        }
    }

    private bool Problem(XtraTabPage page, Control focus, string message)
    {
        tabs.SelectedTabPage = page;
        focus?.Focus();
        XtraMessageBox.Show(message, "Follow-up Settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
    }

    private bool CheckInputs(out DateTime? termStart, out DateTime? termEnd)
    {
        termStart = dteTermStart.EditValue as DateTime?;
        termEnd   = dteTermEnd.EditValue as DateTime?;
        if (termStart.HasValue) termStart = termStart.Value.Date;
        if (termEnd.HasValue)   termEnd   = termEnd.Value.Date;

        if (termStart.HasValue != termEnd.HasValue)
            return Problem(pageTerm, termStart.HasValue ? dteTermEnd : dteTermStart,
                "Please enter both the start date and the end date of the term (or leave both empty).");
        if (termStart.HasValue && termEnd.Value <= termStart.Value)
            return Problem(pageTerm, dteTermEnd, "The term end date must be after the term start date.");
        if (termStart.HasValue && (termEnd.Value - termStart.Value).TotalDays > 200)
            return Problem(pageTerm, dteTermEnd, "These dates make the term longer than 200 days. Please check them.");

        if (spnMedBalAmt.Value > spnHighBalAmt.Value)
            return Problem(pageDaily, spnMedBalAmt,
                "The second balance level must be lower than the first one (the first is for the largest balances).");

        StoreMessage();
        for (int i = 0; i < _messages.Length; i++)
        {
            string m = _messages[i] ?? "";
            if (m.Length > 0 && !m.Contains("{balance}") && !m.Contains("{names}"))
            {
                cboMessage.SelectedIndex = i;
                return Problem(pageSms, memoMessage,
                    $"The message \"{MessageNames[i]}\" mentions neither the children's names nor the balance. " +
                    "Use the Names or Balance button to add one, so the parent knows what the message is about.");
            }
            int open = m.Count(c => c == '{'), close = m.Count(c => c == '}');
            if (open != close)
            {
                cboMessage.SelectedIndex = i;
                return Problem(pageSms, memoMessage,
                    $"The message \"{MessageNames[i]}\" has an unfinished {{ }} word. Remove it or use the buttons to insert it again.");
            }
        }
        return true;
    }

    private void Save()
    {
        if (!CheckInputs(out DateTime? termStart, out DateTime? termEnd)) return;
        try
        {
            _service.SaveSettings(new FeesFollowUpSettings
            {
                StaleThresholdDays              = (int)spnStaleness.Value,
                TermStartDate                   = termStart,
                TermEndDate                     = termEnd,
                SmsTemplate2Day                 = _messages[0],
                SmsTemplateDayOf                = _messages[1],
                SmsTemplateOverdue              = _messages[2],
                SmsTemplateGeneral              = _messages[3],
                PartialPromiseCoverageThreshold = (double)(spnPartialCoverage.Value / 100m),
                StaleHighBalanceAmount          = spnHighBalAmt.Value,
                StaleHighBalanceDays            = (int)spnHighBalDays.Value,
                StaleMedBalanceAmount           = spnMedBalAmt.Value,
                StaleMedBalanceDays             = (int)spnMedBalDays.Value,
                NoProgressEscalationWeeks       = (int)spnEscWeeks.Value,
                NoProgressPaymentThreshold      = (double)spnEscThreshold.Value,
                CollectionGoal                  = (double)(spnCollectionGoal.Value / 100m),
                CriticalShortfallPoints         = (double)spnCriticalShortfall.Value,
                CallRequiredWindowDays          = (int)spnCallReqWindow.Value,
                PromiseResurfaceDays            = (int)spnPromiseResurface.Value,
                GeneralReminderCooldownDays     = (int)spnGeneralCooldown.Value,
                DefaultSmsStyle                 = rgSmsStyle.EditValue is SmsStyle st ? st : SmsStyle.FamilyTotal,
                AutoRemindersEnabled            = chkAuto.Checked,
                AutoReminderTime                = timeAuto.Time.ToString("HH:mm"),
                // Retired from the rules but still stored, so keep whatever was there.
                CriticalPacingGapThreshold      = _loaded?.CriticalPacingGapThreshold ?? 0.50,
            });
            base.DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"The settings could not be saved.\n\n{ex.Message}", "Follow-up Settings",
                MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }
}
