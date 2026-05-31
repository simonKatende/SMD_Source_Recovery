using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;

namespace I_Xtreme.DialogForms;

public class dlgSendRemindersPreview : XtraForm
{
    private readonly FeesFollowUpService _service = new FeesFollowUpService();
    private List<ReminderItem> _items = new();
    private GridControl _grid;
    private GridView    _view;
    private SimpleButton _btnSend, _btnCancel, _btnDelete;
    private LabelControl _lblCount;

    public dlgSendRemindersPreview()
    {
        InitializeComponent();
        LoadPreview();
    }

    private void InitializeComponent()
    {
        this.Text            = "Send Reminders — Preview";
        this.Size            = new Size(1050, 620);
        this.StartPosition   = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.Sizable;

        _lblCount = new LabelControl
        {
            Text     = "Loading...",
            Location = new Point(12, 12),
            AutoSize = true,
        };

        _btnDelete = new SimpleButton
        {
            Text     = "Remove Selected",
            Location = new Point(12, 540),
            Width    = 130,
            Anchor   = AnchorStyles.Bottom | AnchorStyles.Left,
        };
        _btnDelete.Click += BtnDelete_Click;

        _btnSend = new SimpleButton
        {
            Text     = "Send All",
            Location = new Point(850, 540),
            Width    = 90,
            Anchor   = AnchorStyles.Bottom | AnchorStyles.Right,
        };
        _btnSend.Click += BtnSend_Click;

        _btnCancel = new SimpleButton
        {
            Text     = "Cancel",
            Location = new Point(948, 540),
            Width    = 80,
            Anchor   = AnchorStyles.Bottom | AnchorStyles.Right,
        };
        _btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

        _grid = new GridControl
        {
            Location = new Point(12, 36),
            Size     = new Size(1014, 492),
            Anchor   = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
        };
        _view = new GridView();
        _grid.MainView = _view;
        _grid.ViewCollection.Add(_view);
        _view.OptionsView.ShowGroupPanel      = false;
        _view.OptionsBehavior.Editable        = false;
        _view.OptionsSelection.MultiSelect    = true;
        _view.OptionsDetail.SmartDetailExpand = false;

        this.Controls.AddRange(new Control[] { _lblCount, _grid, _btnDelete, _btnSend, _btnCancel });
    }

    private void LoadPreview()
    {
        try
        {
            _items = _service.GetRemindersPreview();
            _grid.DataSource = _items;
            ConfigureColumns();
            UpdateCount();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not load reminder preview.\n\n{ex.Message}",
                "Send Reminders", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private bool _columnsConfigured;
    private void ConfigureColumns()
    {
        if (_columnsConfigured) return;
        _columnsConfigured = true;
        _view.Columns.Clear();

        AddCol("StudentName",   "Student",        160);
        AddCol("ClassId",       "Class",            50);
        AddCol("Phone",         "Phone",           120);
        AddCol("ReminderType",  "Reminder",        100);
        AddDateCol("PromiseDate", "Promise Date",  100);
        AddNumCol("PromisedAmount", "Promised (UGX)", 110);
        AddNumCol("Balance",    "Balance (UGX)",   110);
        AddCol("Message",       "Message",         360);

        _view.CustomColumnDisplayText += (s, e) =>
        {
            if (e.Column.FieldName == "ReminderType" && e.Value is string rt)
                e.DisplayText = rt switch
                {
                    "3DayBefore" => "3 Days Before",
                    "DayOf"      => "Due Today",
                    "Overdue"    => "Overdue",
                    _            => rt,
                };
        };
        _view.RowStyle += (s, e) =>
        {
            var row = _view.GetRow(e.RowHandle) as ReminderItem;
            if (row == null) return;
            if (row.ReminderType == "Overdue")
            {
                e.Appearance.BackColor = Color.LightCoral;
                e.HighPriority = true;
            }
            else if (row.ReminderType == "DayOf")
            {
                e.Appearance.BackColor = Color.LightYellow;
                e.HighPriority = true;
            }
        };
    }

    private void AddCol(string field, string caption, int width)
    {
        var col = _view.Columns.AddField(field);
        col.Caption = caption; col.Width = width;
        col.OptionsColumn.AllowEdit = false;
        col.VisibleIndex = _view.Columns.Count - 1;
    }
    private void AddNumCol(string field, string caption, int width)
    {
        AddCol(field, caption, width);
        var col = _view.Columns[field];
        col.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
        col.DisplayFormat.FormatString = "N0";
    }
    private void AddDateCol(string field, string caption, int width)
    {
        AddCol(field, caption, width);
        var col = _view.Columns[field];
        col.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.DateTime;
        col.DisplayFormat.FormatString = "dd-MMM-yyyy";
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
        var selected = _view.GetSelectedRows()
            .Select(h => _view.GetRow(h) as ReminderItem)
            .Where(r => r != null)
            .ToList();
        if (selected.Count == 0)
        {
            XtraMessageBox.Show("Select one or more rows to remove.", "Remove",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        foreach (var item in selected) _items.Remove(item);
        _grid.DataSource = null;
        _grid.DataSource = _items;
        UpdateCount();
    }

    private void BtnSend_Click(object sender, EventArgs e)
    {
        if (_items.Count == 0)
        {
            XtraMessageBox.Show("No reminders to send.", "Send Reminders",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        _btnSend.Enabled = false;
        try
        {
            var result = _service.ExecuteSendReminders(_items);
            string summary = $"Sent: {result.TotalSent}";
            if (result.HasFailures)
                summary += $"\n\nFailed ({result.Failures.Count}):\n" + string.Join("\n", result.Failures);
            XtraMessageBox.Show(summary, "Send Reminders — Complete",
                MessageBoxButtons.OK,
                result.HasFailures ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Error sending reminders.\n\n{ex.Message}",
                "Send Reminders", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            _btnSend.Enabled = true;
        }
    }

    private void UpdateCount()
    {
        int preDue  = _items.Count(i => i.ReminderType == "3DayBefore");
        int dayOf   = _items.Count(i => i.ReminderType == "DayOf");
        int overdue = _items.Count(i => i.ReminderType == "Overdue");
        _lblCount.Text =
            $"{_items.Count} reminder(s) queued   —   " +
            $"3-day: {preDue}   Due today: {dayOf}   Overdue: {overdue}";
    }
}
