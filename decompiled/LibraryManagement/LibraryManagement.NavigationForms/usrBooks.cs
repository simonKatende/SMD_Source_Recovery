using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace LibraryManagement.NavigationForms;

public class usrBooks : XtraUserControl
{
	private DataSet dsBooks;

	private DataTable dtBooks;

	private IContainer components = null;

	private GridControl gridControl1;

	private GridView gridView1;

	private Timer timer1;

	private GridColumn gridColCategory;

	private GridColumn gridColISBN;

	private GridColumn gridColTitle;

	private GridColumn gridColAuthor;

	private GridColumn gridColPublisher;

	private GridColumn gridColYOP;

	private GridColumn gridColLocalCode;

	public usrBooks()
	{
		InitializeComponent();
		timer1.Enabled = true;
	}

	public void BooksCallBackFN(bool timerStatus)
	{
		timer1.Enabled = timerStatus;
	}

	private void LoadBooks()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT tbl_Books.*, tbl_BookLocations.Location, tbl_BookCategories.Category FROM tbl_Books LEFT OUTER JOIN tbl_BookLocations ON tbl_Books.LocID = tbl_BookLocations.LocID LEFT OUTER JOIN tbl_BookCategories ON tbl_Books.CatID = tbl_BookCategories.CatId", selectConnection);
			dsBooks = new DataSet();
			sqlDataAdapter.Fill(dsBooks, "libraryBooks");
			dtBooks = new DataTable();
			dtBooks = dsBooks.Tables[0];
			gridControl1.DataSource = dtBooks.DefaultView;
			timer1.Enabled = false;
			PrintableControl.SavePrintableControl(gridControl1);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		LoadBooks();
	}

	private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		DataRow dataRow = dtBooks.Rows[gridView1.GetFocusedDataSourceRowIndex()];
		EditableFields.SetEditableFieldValues(Convert.ToInt64(dataRow["BookId"].ToString()), "Books");
	}

	private void gridView1_RowClick(object sender, RowClickEventArgs e)
	{
		DataRow dataRow = dtBooks.Rows[gridView1.GetFocusedDataSourceRowIndex()];
		EditableFields.SetEditableFieldValues(Convert.ToInt64(dataRow["BookId"].ToString()), "Books");
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColCategory = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColISBN = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColTitle = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColAuthor = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColPublisher = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColYOP = new DevExpress.XtraGrid.Columns.GridColumn();
		this.timer1 = new System.Windows.Forms.Timer();
		this.gridColLocalCode = new DevExpress.XtraGrid.Columns.GridColumn();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		base.SuspendLayout();
		this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl1.Location = new System.Drawing.Point(0, 0);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(671, 526);
		this.gridControl1.TabIndex = 0;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[7] { this.gridColCategory, this.gridColISBN, this.gridColLocalCode, this.gridColTitle, this.gridColAuthor, this.gridColPublisher, this.gridColYOP });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.GroupCount = 1;
		this.gridView1.GroupFormat = "{1} {2}";
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsFind.AlwaysVisible = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColCategory, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridView1_RowClick);
		this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
		this.gridColCategory.Caption = "Category";
		this.gridColCategory.FieldName = "Category";
		this.gridColCategory.Name = "gridColCategory";
		this.gridColCategory.Visible = true;
		this.gridColCategory.VisibleIndex = 0;
		this.gridColISBN.Caption = "ISBN";
		this.gridColISBN.FieldName = "Ref";
		this.gridColISBN.Name = "gridColISBN";
		this.gridColISBN.Visible = true;
		this.gridColISBN.VisibleIndex = 0;
		this.gridColISBN.Width = 103;
		this.gridColTitle.Caption = "Title";
		this.gridColTitle.FieldName = "Title";
		this.gridColTitle.Name = "gridColTitle";
		this.gridColTitle.Visible = true;
		this.gridColTitle.VisibleIndex = 2;
		this.gridColTitle.Width = 161;
		this.gridColAuthor.Caption = "Author";
		this.gridColAuthor.FieldName = "Author";
		this.gridColAuthor.Name = "gridColAuthor";
		this.gridColAuthor.Visible = true;
		this.gridColAuthor.VisibleIndex = 3;
		this.gridColAuthor.Width = 137;
		this.gridColPublisher.Caption = "Publisher";
		this.gridColPublisher.FieldName = "Publisher";
		this.gridColPublisher.Name = "gridColPublisher";
		this.gridColPublisher.Visible = true;
		this.gridColPublisher.VisibleIndex = 4;
		this.gridColPublisher.Width = 136;
		this.gridColYOP.Caption = "Pub. Year";
		this.gridColYOP.FieldName = "YearOfPublication";
		this.gridColYOP.Name = "gridColYOP";
		this.gridColYOP.Visible = true;
		this.gridColYOP.VisibleIndex = 5;
		this.gridColYOP.Width = 78;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.gridColLocalCode.Caption = "Local Code";
		this.gridColLocalCode.FieldName = "LocalCode";
		this.gridColLocalCode.Name = "gridColLocalCode";
		this.gridColLocalCode.Visible = true;
		this.gridColLocalCode.VisibleIndex = 1;
		this.gridColLocalCode.Width = 97;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.gridControl1);
		base.Name = "usrBooks";
		base.Size = new System.Drawing.Size(671, 526);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		base.ResumeLayout(false);
	}
}
