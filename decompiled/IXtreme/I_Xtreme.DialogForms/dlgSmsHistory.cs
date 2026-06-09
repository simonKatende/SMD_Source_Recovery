using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace I_Xtreme.DialogForms;

public class dlgSmsHistory : XtraForm
{
    private readonly string _connectionString;
    private readonly string _initialFilter;
    private TextEdit _txtSearch;
    private GridControl _grid;
    private GridView _view;
    private DataTable _all;

    public dlgSmsHistory(string connectionString, string initialFilter = "")
    {
        _connectionString = connectionString;
        _initialFilter = initialFilter ?? "";
        InitializeComponent();
        LoadData();
        _txtSearch.Text = _initialFilter;   // after data is bound, so the first filter pass has rows
    }

    private void InitializeComponent()
    {
        this.Text = "SMS History";
        this.ClientSize = new System.Drawing.Size(820, 520);
        this.StartPosition = FormStartPosition.CenterParent;

        _txtSearch = new TextEdit { Location = new System.Drawing.Point(12, 12), Width = 520 };
        _txtSearch.Properties.NullValuePrompt = "Search recipient or message…";
        _txtSearch.EditValueChanged += (s, e) => ApplyFilter();

        _grid = new GridControl { Location = new System.Drawing.Point(12, 44),
            Size = new System.Drawing.Size(796, 464),
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };
        _view = new GridView(_grid);
        _grid.MainView = _view;
        _view.OptionsBehavior.Editable = false;
        _view.OptionsView.ColumnAutoWidth = false;

        this.Controls.Add(_txtSearch);
        this.Controls.Add(_grid);
    }

    private void LoadData()
    {
        try
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var da = new SqlDataAdapter(
                "SELECT [date] AS Sent, recipients AS Recipient, message AS Message, response AS Response " +
                "FROM tbl_SMSLog ORDER BY [date] DESC", conn);
            _all = new DataTable();
            da.Fill(_all);
            _grid.DataSource = _all.DefaultView;   // bind once; ApplyFilter only mutates RowFilter
            ConfigureColumns();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not load SMS history.\n\n{ex.Message}", "SMS History",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void ConfigureColumns()
    {
        if (_view.Columns["Sent"] is { } c0) { c0.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; c0.DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm"; c0.Width = 130; }
        if (_view.Columns["Recipient"] is { } c1) c1.Width = 120;
        if (_view.Columns["Message"]   is { } c2) c2.Width = 420;
        if (_view.Columns["Response"]  is { } c3) c3.Width = 90;
    }

    private void ApplyFilter()
    {
        if (_all == null) return;
        // Escape DataColumn.Expression specials: ' (string delim) and [ (column/char-class).
        string q = (_txtSearch?.Text ?? "").Trim().Replace("'", "''").Replace("[", "[[]");
        try
        {
            _all.DefaultView.RowFilter = string.IsNullOrEmpty(q) ? "" :
                $"CONVERT(Recipient, 'System.String') LIKE '%{q}%' OR CONVERT(Message, 'System.String') LIKE '%{q}%'";
        }
        catch (System.Data.EvaluateException)
        {
            _all.DefaultView.RowFilter = "";   // never let a malformed filter expression crash the dialog
        }
    }
}
