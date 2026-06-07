using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.DialogForms;

public class dlgInteractionLog : XtraForm
{
    private DateEdit dteFrom;
    private DateEdit dteTo;
    private SimpleButton btnLoad;
    private GridControl grid;
    private GridView view;

    private readonly FeesFollowUpService _service = new FeesFollowUpService();

    public dlgInteractionLog()
    {
        InitializeComponent();
        // Default range = current Sun-Sat school week
        DateTime today      = DateTime.Today;
        DateTime weekSunday = today.AddDays(-(int)today.DayOfWeek);
        dteFrom.EditValue = weekSunday;
        dteTo.EditValue   = weekSunday.AddDays(6);
        LoadGrid();
    }

    private void InitializeComponent()
    {
        var lblFrom = new LabelControl { Text = "From:", Location = new System.Drawing.Point(12, 16) };
        this.dteFrom = new DateEdit { Location = new System.Drawing.Point(56, 12), Width = 120 };
        var lblTo = new LabelControl { Text = "To:", Location = new System.Drawing.Point(192, 16) };
        this.dteTo = new DateEdit { Location = new System.Drawing.Point(220, 12), Width = 120 };
        this.btnLoad = new SimpleButton { Text = "Load", Location = new System.Drawing.Point(356, 11), Width = 75 };
        this.btnLoad.Click += (s, e) => LoadGrid();

        this.grid = new GridControl
        {
            Location = new System.Drawing.Point(12, 44),
            Size     = new System.Drawing.Size(860, 460),
            Anchor   = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
        };
        this.view = new GridView();
        this.grid.MainView = this.view;
        this.grid.ViewCollection.Add(this.view);
        this.view.OptionsView.ShowGroupPanel = false;
        this.view.OptionsBehavior.Editable   = false;

        AddCol("ContactDate",  "Date / Time", 130).DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm";
        view.Columns["ContactDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
        AddCol("StudentName",     "Student",  160);
        AddCol("GuardianDisplay", "Guardian", 160);
        AddCol("Channel",         "Channel",   80);
        AddOutcomeCol();
        AddCol("Note",         "Note",      220);
        var colPd = AddCol("PromiseDate", "Promise Date", 100);
        colPd.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.DateTime;
        colPd.DisplayFormat.FormatString = "dd-MMM-yyyy";
        var colPa = AddCol("PromiseAmount", "Promise Amt", 100);
        colPa.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
        colPa.DisplayFormat.FormatString = "N0";
        AddCol("LoggedBy",     "Logged By", 100);
        // Hide the technical key column if present
        var idCol = AddCol("ContactId", "Id", 0);
        idCol.Visible = false;

        this.ClientSize = new System.Drawing.Size(884, 516);
        this.Controls.AddRange(new Control[] { lblFrom, dteFrom, lblTo, dteTo, btnLoad, grid });
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "View Interactions";
        this.MinimizeBox = false;
        this.MaximizeBox = true;
    }

    private GridColumn AddCol(string field, string caption, int width)
    {
        var col = new GridColumn
        {
            FieldName    = field,
            Caption      = caption,
            Width        = width,
            VisibleIndex = view.Columns.Count,
        };
        col.OptionsColumn.AllowEdit = false;
        view.Columns.Add(col);
        return col;
    }

    private void AddOutcomeCol()
    {
        var col = AddCol("Outcome", "Outcome", 100);
        view.CustomColumnDisplayText += (s, e) =>
        {
            if (e.Column != col || e.Value == null) return;
            e.DisplayText = e.Value.ToString() switch
            {
                "Contacted"          => "Contacted",
                "NoAnswer"           => "No Answer",
                "ContactUnavailable" => "Unavailable",
                "ContactOff"         => "Phone Off",
                "Promised"           => "Promised",
                "Refused"            => "Refused",
                _                    => e.DisplayText,
            };
        };
    }

    private void LoadGrid()
    {
        try
        {
            DateTime from = dteFrom.DateTime == DateTime.MinValue ? DateTime.Today : dteFrom.DateTime.Date;
            DateTime to   = dteTo.DateTime   == DateTime.MinValue ? DateTime.Today : dteTo.DateTime.Date;
            if (to < from)
            {
                XtraMessageBox.Show("'To' date must be on or after 'From' date.", "View Interactions",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grid.DataSource = _service.GetInteractionsByDateRange(from, to);
            view.RefreshData();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not load interactions.\n\n{ex.Message}", "View Interactions",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
