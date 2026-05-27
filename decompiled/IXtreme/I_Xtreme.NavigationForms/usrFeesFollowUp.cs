using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using I_Xtreme.DialogForms;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;
using I_Xtreme;

namespace I_Xtreme.NavigationForms;

public class usrFeesFollowUp : XtraUserControl
{
    private IContainer components = null;
    private SplitContainerControl splitContainer;

    private ComboBoxEdit cboClassFilter;
    private SpinEdit txtMinBalance;
    private SimpleButton btnRefresh;
    private DevExpress.XtraGrid.GridControl gridWorklist;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewWorklist;
    private System.Windows.Forms.Panel leftPanel;

    private LabelControl lblParentHeader;
    private LabelControl lblRecentPayments;
    private DevExpress.XtraGrid.GridControl gridHistory;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewHistory;
    private System.Windows.Forms.Panel rightPanel;
    private System.Windows.Forms.Panel headerPanel;

    private System.Windows.Forms.Panel newContactPanel;
    private RadioGroup rgChannel;
    private ComboBoxEdit cboOutcome;
    private LabelControl lblPromiseDate;
    private DevExpress.XtraEditors.DateEdit dtePromiseDate;
    private LabelControl lblPromiseAmount;
    private SpinEdit txtPromiseAmount;
    private MemoEdit memoNote;
    private SimpleButton btnSave;
    private SimpleButton btnSaveAndNext;
    private DevExpress.XtraEditors.LabelControl lblContactDate;
    private DevExpress.XtraEditors.DateEdit dteContactDate;

    private readonly FeesFollowUpService service = new FeesFollowUpService();
    private List<WorklistRow> currentRows = new List<WorklistRow>();
    private bool _columnsConfigured = false;
    private bool _historyColumnsConfigured = false;
    private string _currentSemester;

    public usrFeesFollowUp()
    {
        InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
        ((System.ComponentModel.ISupportInitialize)this.splitContainer).BeginInit();
        this.splitContainer.SuspendLayout();
        this.SuspendLayout();

        this.splitContainer.Dock = DockStyle.Fill;
        this.splitContainer.Horizontal = true;        // left panel | right panel
        this.splitContainer.SplitterPosition = 680;   // worklist width
        this.splitContainer.Name = "splitContainer";

        // Class filter combo
        this.cboClassFilter = new DevExpress.XtraEditors.ComboBoxEdit();
        this.cboClassFilter.Properties.Items.Add("All Classes");
        this.cboClassFilter.SelectedIndex = 0;
        this.cboClassFilter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

        // Min balance
        this.txtMinBalance = new DevExpress.XtraEditors.SpinEdit();
        this.txtMinBalance.Properties.IsFloatValue = false;
        this.txtMinBalance.Properties.MaskSettings.Set("mask", "N0");
        this.txtMinBalance.Value = 0;

        // Refresh button
        this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
        this.btnRefresh.Text = "Refresh";
        this.btnRefresh.Click += BtnRefresh_Click;

        // Grid
        this.gridWorklist = new DevExpress.XtraGrid.GridControl();
        this.gridViewWorklist = new DevExpress.XtraGrid.Views.Grid.GridView();
        this.gridWorklist.MainView = this.gridViewWorklist;
        this.gridWorklist.ViewCollection.Add(this.gridViewWorklist);
        this.gridViewWorklist.OptionsSelection.MultiSelect = false;
        this.gridViewWorklist.OptionsBehavior.Editable = false;
        this.gridViewWorklist.OptionsView.ShowGroupPanel = false;
        this.gridViewWorklist.FocusedRowChanged += GridViewWorklist_FocusedRowChanged;
        this.gridViewWorklist.RowStyle += GridViewWorklist_RowStyle;
        this.gridViewWorklist.CustomUnboundColumnData += GridViewWorklist_UnboundData;

        // Layout: stack filter bar above grid in the left panel of split container
        this.leftPanel = new System.Windows.Forms.Panel();
        this.leftPanel.Dock = DockStyle.Fill;

        var filterStrip = new System.Windows.Forms.Panel();
        filterStrip.Height = 36;
        filterStrip.Dock = DockStyle.Top;
        this.cboClassFilter.Location = new System.Drawing.Point(8, 8);
        this.cboClassFilter.Width = 160;
        this.txtMinBalance.Location = new System.Drawing.Point(176, 8);
        this.txtMinBalance.Width = 120;
        this.btnRefresh.Location = new System.Drawing.Point(304, 7);
        this.btnRefresh.Width = 80;
        filterStrip.Controls.Add(this.cboClassFilter);
        filterStrip.Controls.Add(this.txtMinBalance);
        filterStrip.Controls.Add(this.btnRefresh);
        var btnSettings = new DevExpress.XtraEditors.SimpleButton { Text = "Settings" };
        btnSettings.Location = new System.Drawing.Point(396, 7);
        btnSettings.Width = 80;
        btnSettings.Click += (s, e) =>
        {
            using var dlg = new FollowUpSettings();
            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                LoadWorklist();   // refresh because staleness threshold may have changed
        };
        filterStrip.Controls.Add(btnSettings);

        this.gridWorklist.Dock = DockStyle.Fill;
        this.leftPanel.Controls.Add(this.gridWorklist);
        this.leftPanel.Controls.Add(filterStrip);

        this.splitContainer.Panel1.Controls.Add(this.leftPanel);

        this.rightPanel = new System.Windows.Forms.Panel { Dock = DockStyle.Fill };
        this.headerPanel = new System.Windows.Forms.Panel { Dock = DockStyle.Top, Height = 64 };

        this.lblParentHeader = new DevExpress.XtraEditors.LabelControl();
        this.lblParentHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
        this.lblParentHeader.Location = new System.Drawing.Point(8, 6);
        this.lblParentHeader.AutoSizeMode = LabelAutoSizeMode.None;
        this.lblParentHeader.Size = new System.Drawing.Size(560, 22);
        this.lblParentHeader.Text = "(select a parent)";

        this.lblRecentPayments = new DevExpress.XtraEditors.LabelControl();
        this.lblRecentPayments.Location = new System.Drawing.Point(8, 32);
        this.lblRecentPayments.AutoSizeMode = LabelAutoSizeMode.None;
        this.lblRecentPayments.Size = new System.Drawing.Size(560, 28);
        this.lblRecentPayments.Text = "";

        this.headerPanel.Controls.Add(this.lblParentHeader);
        this.headerPanel.Controls.Add(this.lblRecentPayments);

        this.gridHistory = new DevExpress.XtraGrid.GridControl { Dock = DockStyle.Fill };
        this.gridViewHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
        this.gridHistory.MainView = this.gridViewHistory;
        this.gridHistory.ViewCollection.Add(this.gridViewHistory);
        this.gridViewHistory.OptionsBehavior.Editable = false;
        this.gridViewHistory.OptionsView.ShowGroupPanel = false;
        this.gridViewHistory.CustomUnboundColumnData += GridViewHistory_UnboundData;

        this.newContactPanel = new System.Windows.Forms.Panel { Dock = DockStyle.Bottom, Height = 200 };

        this.rgChannel = new DevExpress.XtraEditors.RadioGroup();
        this.rgChannel.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[]
        {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(Models.ContactChannel.SMS, "SMS"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(Models.ContactChannel.Phone, "Phone"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(Models.ContactChannel.InPerson, "InPerson"),
        });
        this.rgChannel.Properties.Columns = 3;
        this.rgChannel.SelectedIndex = 1; // default to Phone
        this.rgChannel.Location = new System.Drawing.Point(8, 8);
        this.rgChannel.Size = new System.Drawing.Size(300, 36);

        this.lblContactDate = new DevExpress.XtraEditors.LabelControl
        {
            Text     = "Date:",
            Location = new System.Drawing.Point(312, 14),
        };

        this.dteContactDate = new DevExpress.XtraEditors.DateEdit();
        ((System.ComponentModel.ISupportInitialize)this.dteContactDate.Properties).BeginInit();
        this.dteContactDate.Location  = new System.Drawing.Point(342, 8);
        this.dteContactDate.Width     = 120;
        this.dteContactDate.EditValue = System.DateTime.Today;
        ((System.ComponentModel.ISupportInitialize)this.dteContactDate.Properties).EndInit();

        this.cboOutcome = new DevExpress.XtraEditors.ComboBoxEdit();
        this.cboOutcome.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        foreach (Models.ContactOutcome o in System.Enum.GetValues(typeof(Models.ContactOutcome)))
            this.cboOutcome.Properties.Items.Add(o);
        this.cboOutcome.SelectedIndex = 1; // default Contacted
        this.cboOutcome.Location = new System.Drawing.Point(8, 52);
        this.cboOutcome.Width = 200;

        this.cboOutcome.SelectedIndexChanged += (s, ev) =>
        {
            bool promised = (Models.ContactOutcome)cboOutcome.SelectedItem == Models.ContactOutcome.Promised;
            lblPromiseDate.Visible = dtePromiseDate.Visible = promised;
            lblPromiseAmount.Visible = txtPromiseAmount.Visible = promised;
        };

        this.lblPromiseDate = new DevExpress.XtraEditors.LabelControl
        { Text = "Promise date:", Location = new System.Drawing.Point(220, 56), Visible = false };
        this.dtePromiseDate = new DevExpress.XtraEditors.DateEdit
        { Location = new System.Drawing.Point(300, 52), Width = 120, Visible = false };

        this.lblPromiseAmount = new DevExpress.XtraEditors.LabelControl
        { Text = "Promise amount:", Location = new System.Drawing.Point(430, 56), Visible = false };
        this.txtPromiseAmount = new DevExpress.XtraEditors.SpinEdit
        { Location = new System.Drawing.Point(530, 52), Width = 110, Visible = false };
        this.txtPromiseAmount.Properties.IsFloatValue = true;
        this.txtPromiseAmount.Properties.MaskSettings.Set("mask", "N0");

        this.memoNote = new DevExpress.XtraEditors.MemoEdit();
        this.memoNote.Location = new System.Drawing.Point(8, 84);
        this.memoNote.Size = new System.Drawing.Size(560, 70);

        this.btnSave = new DevExpress.XtraEditors.SimpleButton { Text = "Save" };
        this.btnSave.Location = new System.Drawing.Point(8, 162);
        this.btnSave.Width = 100;
        this.btnSave.Click += BtnSave_Click;

        this.btnSaveAndNext = new DevExpress.XtraEditors.SimpleButton { Text = "Save & next →" };
        this.btnSaveAndNext.Location = new System.Drawing.Point(116, 162);
        this.btnSaveAndNext.Width = 130;
        this.btnSaveAndNext.Click += BtnSaveAndNext_Click;
        this.newContactPanel.Controls.Add(this.btnSaveAndNext);

        this.newContactPanel.Controls.Add(this.rgChannel);
        this.newContactPanel.Controls.Add(this.lblContactDate);
        this.newContactPanel.Controls.Add(this.dteContactDate);
        this.newContactPanel.Controls.Add(this.cboOutcome);
        this.newContactPanel.Controls.Add(this.lblPromiseDate);
        this.newContactPanel.Controls.Add(this.dtePromiseDate);
        this.newContactPanel.Controls.Add(this.lblPromiseAmount);
        this.newContactPanel.Controls.Add(this.txtPromiseAmount);
        this.newContactPanel.Controls.Add(this.memoNote);
        this.newContactPanel.Controls.Add(this.btnSave);

        this.rightPanel.Controls.Add(this.newContactPanel);
        this.rightPanel.Controls.Add(this.gridHistory);
        this.rightPanel.Controls.Add(this.headerPanel);

        this.splitContainer.Panel2.Controls.Add(this.rightPanel);

        this.Controls.Add(this.splitContainer);
        this.Name = "usrFeesFollowUp";
        this.Size = new System.Drawing.Size(1280, 720);

        this.Load += usrFeesFollowUp_Load;

        ((System.ComponentModel.ISupportInitialize)this.splitContainer).EndInit();
        this.splitContainer.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private void usrFeesFollowUp_Load(object sender, System.EventArgs e)
    {
        LoadClasses();
        LoadWorklist();
    }

    private void LoadClasses()
    {
        using var conn = new System.Data.SqlClient.SqlConnection(AlienAge.Connectivity.DataConnection.ConnectToDatabase());
        using var da = new System.Data.SqlClient.SqlDataAdapter(
            "SELECT DISTINCT ClassId FROM tbl_Stud WHERE ClassId IS NOT NULL ORDER BY ClassId", conn);
        var dt = new System.Data.DataTable();
        da.Fill(dt);
        cboClassFilter.Properties.Items.Clear();
        cboClassFilter.Properties.Items.Add("All Classes");
        foreach (System.Data.DataRow r in dt.Rows)
        {
            cboClassFilter.Properties.Items.Add(r["ClassId"].ToString());
        }
        cboClassFilter.SelectedIndex = 0;
    }

    private void LoadWorklist()
    {
        string classFilter = cboClassFilter.Text == "All Classes" ? "" : cboClassFilter.Text;
        decimal minBalance = (decimal)txtMinBalance.Value;
        currentRows = service.GetWorklist(classFilter, minBalance);
        _currentSemester = service.GetCurrentSemester();
        gridWorklist.DataSource = currentRows;
        ConfigureWorklistColumns();
    }

    private void GridViewWorklist_RowStyle(object sender,
        DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
    {
        if (e.RowHandle < 0) return;
        var row = gridViewWorklist.GetRow(e.RowHandle) as WorklistRow;
        if (row == null) return;
        switch (row.Tier)
        {
            case PriorityTier.BrokenPromise:
                e.Appearance.BackColor = Color.LightCoral;
                e.HighPriority = true;
                break;
            case PriorityTier.Stale:
                e.Appearance.BackColor = Color.LightYellow;
                e.HighPriority = true;
                break;
        }
    }

    private void BtnRefresh_Click(object sender, System.EventArgs e) => LoadWorklist();

    private void GridViewWorklist_FocusedRowChanged(object sender,
        DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
        if (e.FocusedRowHandle < 0)
        {
            lblParentHeader.Text = "(select a parent)";
            lblRecentPayments.Text = "";
            gridHistory.DataSource = null;
            return;
        }
        var row = gridViewWorklist.GetRow(e.FocusedRowHandle) as WorklistRow;
        if (row == null) return;
        lblParentHeader.Text = $"{row.FullName}  •  {row.ClassId}  •  Balance UGX {row.Balance:N0}";

        try
        {
            var payments = service.GetRecentPayments(row.StudentNumber, topN: 2, semester: _currentSemester);
            string payLabel = _currentSemester != null
                ? $"Last 2 payments ({_currentSemester}):"
                : "Last 2 payments:";
            if (payments.Rows.Count == 0)
            {
                lblRecentPayments.Text = $"{payLabel} (none)";
            }
            else
            {
                var parts = new System.Collections.Generic.List<string>();
                foreach (System.Data.DataRow p in payments.Rows)
                {
                    decimal amt = p["Credit"] is decimal d ? d : 0m;
                    var dt = p["PaymentDate"] is System.DateTime pd ? pd : System.DateTime.MinValue;
                    parts.Add($"{amt:N0} ({dt:yyyy-MM-dd})");
                }
                lblRecentPayments.Text = payLabel + " " + string.Join(", ", parts);
            }

            gridHistory.DataSource = service.GetContactHistory(row.StudentNumber);
            ConfigureHistoryColumns();
        }
        catch (System.Exception ex)
        {
            lblRecentPayments.Text = $"(error loading details: {ex.Message})";
        }
    }

    private void BtnSaveAndNext_Click(object sender, System.EventArgs e)
    {
        int rh = gridViewWorklist.FocusedRowHandle;
        BtnSave_Click(sender, e);
        if (rh >= 0 && rh < gridViewWorklist.RowCount - 1)
        {
            gridViewWorklist.FocusedRowHandle = rh + 1;
        }
    }

    private void BtnSave_Click(object sender, System.EventArgs e)
    {
        int rh = gridViewWorklist.FocusedRowHandle;
        var row = gridViewWorklist.GetFocusedRow() as WorklistRow;
        if (rh < 0 || row == null)
        {
            XtraMessageBox.Show("Select a parent on the worklist first.",
                "School Management Dynamics", System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Information);
            return;
        }
        if (dteContactDate.DateTime.Date > System.DateTime.Today)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(
                "Contact date cannot be in the future.",
                "Validation",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Warning);
            return;
        }
        var channel = (Models.ContactChannel)rgChannel.EditValue;
        var outcome = (Models.ContactOutcome)cboOutcome.SelectedItem;

        if (channel == Models.ContactChannel.SMS)
        {
            if (string.IsNullOrEmpty(row.PriorityContact) || row.PriorityContact.Length < 10)
            {
                XtraMessageBox.Show("No valid contact number on file for this parent.",
                    "School Management Dynamics", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Hand);
                return;
            }
            using var dlg = new SMSGuardian();
            dlg.txtReceipient.Text = row.PriorityContact;
            if (dlg.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return; // user cancelled or send failed; do not log
            // SMSGuardian closed via successful send; write the contact log entry
            var smsEntry = new Models.FeesContactLog
            {
                StudentNumber = row.StudentNumber,
                ContactDate = dteContactDate.DateTime,
                LoggedBy = CurrentUser.GetSystemUser(),
                Channel = Models.ContactChannel.SMS,
                Outcome = outcome,
                Note = $"SMS: {memoNote.Text}".Trim(),
                PromiseDate = outcome == Models.ContactOutcome.Promised ? dtePromiseDate.DateTime.Date : (System.DateTime?)null,
                PromiseAmount = (outcome == Models.ContactOutcome.Promised && txtPromiseAmount.Value > 0)
                    ? (decimal?)txtPromiseAmount.Value
                    : null,
            };
            try
            {
                service.LogContact(smsEntry);
                memoNote.Text = "";
                dteContactDate.EditValue = System.DateTime.Today;
                dtePromiseDate.EditValue = null;
                txtPromiseAmount.Value = 0;
                gridHistory.DataSource = service.GetContactHistory(row.StudentNumber);
            }
            catch (System.Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Hand);
            }
            return;
        }

        if (outcome == Models.ContactOutcome.Promised && dtePromiseDate.DateTime == System.DateTime.MinValue)
        {
            XtraMessageBox.Show("Promise date is required when outcome is 'Promised'.",
                "School Management Dynamics", System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Hand);
            return;
        }

        var entry = new Models.FeesContactLog
        {
            StudentNumber = row.StudentNumber,
            ContactDate = dteContactDate.DateTime,
            LoggedBy = CurrentUser.GetSystemUser(),
            Channel = channel,
            Outcome = outcome,
            Note = string.IsNullOrWhiteSpace(memoNote.Text) ? null : memoNote.Text,
            PromiseDate = outcome == Models.ContactOutcome.Promised ? dtePromiseDate.DateTime.Date : (System.DateTime?)null,
            PromiseAmount = (outcome == Models.ContactOutcome.Promised && txtPromiseAmount.Value > 0)
                ? (decimal?)txtPromiseAmount.Value
                : null,
        };
        try
        {
            service.LogContact(entry);
            memoNote.Text = "";
            dteContactDate.EditValue = System.DateTime.Today;
            dtePromiseDate.EditValue = null;
            txtPromiseAmount.Value = 0;
            gridHistory.DataSource = service.GetContactHistory(row.StudentNumber);
        }
        catch (System.Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Hand);
        }
    }

    private void ConfigureWorklistColumns()
    {
        if (_columnsConfigured) return;
        _columnsConfigured = true;

        var colNum = new DevExpress.XtraGrid.Columns.GridColumn();
        colNum.FieldName = "#";
        colNum.Caption   = "#";
        colNum.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
        colNum.OptionsColumn.AllowEdit = false;
        colNum.OptionsColumn.ReadOnly  = true;
        colNum.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
        colNum.Width = 36;
        gridViewWorklist.Columns.Add(colNum);
        colNum.VisibleIndex = 0;

        foreach (string name in new[] { "StudentNumber", "PaymentsSinceLatestPromise", "LatestPromiseAmount", "LatestPromiseDate" })
        {
            var col = gridViewWorklist.Columns[name];
            if (col != null) col.Visible = false;
        }

        var colBalance = gridViewWorklist.Columns["Balance"];
        if (colBalance != null)
        {
            colBalance.Caption = "Balance (UGX)";
            colBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colBalance.DisplayFormat.FormatString = "N0";
            colBalance.Width = 120;
        }

        void SetCaption(string field, string caption)
        {
            var c = gridViewWorklist.Columns[field];
            if (c != null) c.Caption = caption;
        }
        SetCaption("FullName", "Name");
        SetCaption("ClassId", "Class");
        SetCaption("PriorityContact", "Contact");
        SetCaption("LastContactDate", "Last Contact");
        SetCaption("LastOutcome", "Last Outcome");
        SetCaption("Tier", "Priority");

        gridViewWorklist.CustomColumnDisplayText += GridViewWorklist_CustomColumnDisplayText;

        gridViewWorklist.BestFitColumns();
        var colNumFixed = gridViewWorklist.Columns["#"];
        if (colNumFixed != null) colNumFixed.Width = 36; // BestFit must not expand the # column
    }

    private void ConfigureHistoryColumns()
    {
        if (_historyColumnsConfigured) return;
        _historyColumnsConfigured = true;

        var colNumH = new DevExpress.XtraGrid.Columns.GridColumn();
        colNumH.FieldName = "#";
        colNumH.Caption   = "#";
        colNumH.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
        colNumH.OptionsColumn.AllowEdit = false;
        colNumH.OptionsColumn.ReadOnly  = true;
        colNumH.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
        colNumH.Width = 36;
        gridViewHistory.Columns.Add(colNumH);
        colNumH.VisibleIndex = 0;

        var colAmt = gridViewHistory.Columns["PromiseAmount"];
        if (colAmt != null)
        {
            colAmt.Caption = "Promise Amount";
            colAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colAmt.DisplayFormat.FormatString = "N0";
            colAmt.Width = 110;
        }

        var colDate = gridViewHistory.Columns["ContactDate"];
        if (colDate != null) { colDate.Caption = "Contact Date"; colDate.Width = 90; }

        var colPD = gridViewHistory.Columns["PromiseDate"];
        if (colPD != null) { colPD.Caption = "Promise Date"; colPD.Width = 90; }

        gridViewHistory.OptionsView.ShowGroupPanel = false;
        gridViewHistory.OptionsBehavior.Editable = false;

        gridViewHistory.BestFitColumns();
        var noteCol = gridViewHistory.Columns["Note"];
        if (noteCol != null) noteCol.Width = System.Math.Min(noteCol.Width, 200);
        var colNumHFixed = gridViewHistory.Columns["#"];
        if (colNumHFixed != null) colNumHFixed.Width = 36;
    }

    private void GridViewWorklist_UnboundData(object sender,
        DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
    {
        if (e.Column.FieldName == "#" && e.IsGetData)
            e.Value = e.ListSourceRowIndex + 1;
    }

    private void GridViewHistory_UnboundData(object sender,
        DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
    {
        if (e.Column.FieldName == "#" && e.IsGetData)
            e.Value = e.ListSourceRowIndex + 1;
    }

    private void GridViewWorklist_CustomColumnDisplayText(object sender,
        DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
    {
        if (e.Column.FieldName == "Tier" && e.Value is PriorityTier tier)
        {
            e.DisplayText = tier switch
            {
                PriorityTier.BrokenPromise => "Missed Promise",
                PriorityTier.Stale        => "Contact Overdue",
                PriorityTier.Current      => "Up to Date",
                _                          => e.DisplayText,
            };
        }
        else if (e.Column.FieldName == "LastOutcome" && e.Value is ContactOutcome outcome)
        {
            e.DisplayText = outcome switch
            {
                ContactOutcome.NoAnswer     => "No Answer",
                ContactOutcome.Contacted    => "Contacted",
                ContactOutcome.Promised     => "Promised Payment",
                ContactOutcome.Refused      => "Refused",
                ContactOutcome.WrongContact => "Wrong Contact",
                _                           => e.DisplayText,
            };
        }
    }
}
