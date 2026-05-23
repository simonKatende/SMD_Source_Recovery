using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class Combinations : XtraForm
{
	private DataTable dt;

	private StringBuilder ShortCombination;

	private StringBuilder FullCombination;

	private int m = -1;

	private List<string> shortCodes;

	private List<string> fullCodes;

	private int id = 0;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private GridControl gridControl2;

	private GridView gridView2;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private GridControl gridControl1;

	private GridView gridView1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private EmptySpaceItem emptySpaceItem1;

	private EmptySpaceItem emptySpaceItem2;

	private LayoutControlItem layoutControlItem5;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private GridColumn gridColumn7;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem1;

	private LabelControl labelControl2;

	private LayoutControlItem layoutControlItem6;

	private EmptySpaceItem emptySpaceItem3;

	public Combinations()
	{
		InitializeComponent();
	}

	private void LoadSubjects()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM ALevelSubjects Order By Category", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Subjects");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			gridControl2.DataSource = dt.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void Combinations_Load(object sender, EventArgs e)
	{
		LoadSubjects();
		LoadCombinations();
		shortCodes = new List<string>();
		fullCodes = new List<string>();
	}

	private void LoadCombinations()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_SubjectCombinations", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Combs");
			gridControl1.DataSource = dataSet.Tables[0].DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		int[] selectedRows = gridView2.GetSelectedRows();
		if (selectedRows.Count() == 5)
		{
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "INSERT INTO tbl_SubjectCombinations (combFull,combShort) VALUES (@combFull,@combShort)",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@combFull", SqlDbType.VarChar, 12);
				sqlParameter.Value = labelControl2.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@combShort", SqlDbType.VarChar, 12);
				sqlParameter.Value = labelControl1.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				if (sqlCommand.ExecuteNonQuery() > 0)
				{
					sqlConnection.Close();
					LoadCombinations();
					LoadSubjects();
					labelControl1.Text = string.Empty;
					labelControl2.Text = string.Empty;
					for (int i = 0; i < gridView2.RowCount; i++)
					{
						gridView2.UnselectRow(i);
					}
					ShortCombination.Clear();
					FullCombination.Clear();
					shortCodes.Clear();
					fullCodes.Clear();
					m = -1;
				}
				return;
			}
		}
		XtraMessageBox.Show("Please select up to 5 subjects", "Invalid Selectin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private void gridView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		string empty3 = string.Empty;
		empty = gridView2.GetRowCellValue(e.ControllerRow, "SubjectId").ToString();
		if (gridView2.GetRowCellValue(e.ControllerRow, "Category").ToString() == "1 Group")
		{
			empty2 = empty switch
			{
				"Arabic" => "Ar", 
				"Agriculture" => "Ag", 
				"Fine Art" => "FA", 
				"English Lit." => "Li", 
				"Entreprenuership" => "En", 
				_ => gridView2.GetRowCellValue(e.ControllerRow, "ShortCode").ToString().Substring(0, 1), 
			};
			empty3 = gridView2.GetRowCellValue(e.ControllerRow, "ShortCode").ToString();
		}
		else
		{
			empty2 = "/" + gridView2.GetRowCellValue(e.ControllerRow, "ShortCode");
			empty3 = "/" + gridView2.GetRowCellValue(e.ControllerRow, "ShortCode");
		}
		if (e.Action == CollectionChangeAction.Add)
		{
			m++;
			if (m == 5)
			{
				XtraMessageBox.Show("You have reached the maximum allowed number of subjects", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				gridView2.UnselectRow(e.ControllerRow);
				return;
			}
			shortCodes.Add(empty2);
			fullCodes.Add(empty3);
		}
		else
		{
			shortCodes.Remove(empty2);
			fullCodes.Remove(empty3);
			m--;
		}
		ShortCombination = new StringBuilder();
		FullCombination = new StringBuilder();
		for (int i = 0; i < shortCodes.Count; i++)
		{
			ShortCombination.Append(shortCodes[i]);
			FullCombination.Append(fullCodes[i]);
		}
		labelControl1.Text = ShortCombination.ToString();
		labelControl2.Text = FullCombination.ToString();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "DELETE FROM tbl_SubjectCombinations WHERE combID=@combID",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@combID", id);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
		LoadCombinations();
	}

	private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (gridView1.FocusedRowHandle > -1)
		{
			id = Convert.ToInt32(gridView1.GetRowCellValue(e.FocusedRowHandle, "combID"));
		}
	}

	private void gridView1_RowClick(object sender, RowClickEventArgs e)
	{
		if (gridView1.FocusedRowHandle > -1)
		{
			id = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "combID"));
		}
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.gridControl2 = new DevExpress.XtraGrid.GridControl();
		this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem3).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.labelControl2);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.gridControl2);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(576, 451);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f);
		this.labelControl2.Appearance.Options.UseFont = true;
		this.labelControl2.Location = new System.Drawing.Point(462, 4);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(110, 24);
		this.labelControl2.StyleController = this.layoutControl1;
		this.labelControl2.TabIndex = 10;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Location = new System.Drawing.Point(4, 4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(110, 24);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 9;
		this.gridControl2.Location = new System.Drawing.Point(4, 32);
		this.gridControl2.MainView = this.gridView2;
		this.gridControl2.Name = "gridControl2";
		this.gridControl2.Size = new System.Drawing.Size(256, 415);
		this.gridControl2.TabIndex = 8;
		this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[4] { this.gridColumn4, this.gridColumn5, this.gridColumn6, this.gridColumn7 });
		this.gridView2.GridControl = this.gridControl2;
		this.gridView2.GroupFormat = "{1}{2}";
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView2.OptionsCustomization.AllowGroup = false;
		this.gridView2.OptionsCustomization.AllowSort = false;
		this.gridView2.OptionsFilter.AllowFilterEditor = false;
		this.gridView2.OptionsMenu.EnableColumnMenu = false;
		this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView2.OptionsSelection.MultiSelect = true;
		this.gridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
		this.gridView2.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.gridView2.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView2.OptionsView.ShowIndicator = false;
		this.gridView2.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView2.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(gridView2_SelectionChanged);
		this.gridColumn4.Caption = "Subject";
		this.gridColumn4.FieldName = "SubjectId";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 1;
		this.gridColumn5.Caption = "SubjectName";
		this.gridColumn5.FieldName = "SubjectName";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn6.Caption = "ShortCode";
		this.gridColumn6.FieldName = "ShortCode";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn7.Caption = "Category";
		this.gridColumn7.FieldName = "Category";
		this.gridColumn7.Name = "gridColumn7";
		this.simpleButton2.Location = new System.Drawing.Point(264, 224);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(26, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 7;
		this.simpleButton2.Text = ">>";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.simpleButton1.Location = new System.Drawing.Point(264, 250);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(26, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 6;
		this.simpleButton1.Text = "<<";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.gridControl1.Location = new System.Drawing.Point(294, 32);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(278, 415);
		this.gridControl1.TabIndex = 5;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridColumn1, this.gridColumn2, this.gridColumn3 });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsCustomization.AllowGroup = false;
		this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridView1_RowClick);
		this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
		this.gridColumn1.Caption = "combID";
		this.gridColumn1.FieldName = "combID";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn2.Caption = "Full Comb.";
		this.gridColumn2.FieldName = "combFull";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 0;
		this.gridColumn2.Width = 130;
		this.gridColumn3.Caption = "Short Comb.";
		this.gridColumn3.FieldName = "combShort";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 1;
		this.gridColumn3.Width = 146;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[9] { this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.emptySpaceItem1, this.emptySpaceItem2, this.layoutControlItem5, this.layoutControlItem1, this.layoutControlItem6, this.emptySpaceItem3 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(576, 451);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem2.Control = this.gridControl1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(290, 28);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(282, 419);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.simpleButton1;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(260, 246);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(30, 26);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.Control = this.simpleButton2;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(260, 220);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(30, 26);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(260, 28);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(30, 192);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.emptySpaceItem2.AllowHotTrack = false;
		this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
		this.emptySpaceItem2.Location = new System.Drawing.Point(260, 272);
		this.emptySpaceItem2.Name = "emptySpaceItem2";
		this.emptySpaceItem2.Size = new System.Drawing.Size(30, 175);
		this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.Control = this.gridControl2;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(260, 419);
		this.layoutControlItem5.Text = "Principal Subjects";
		this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem1.Control = this.labelControl1;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(114, 28);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem6.Control = this.labelControl2;
		this.layoutControlItem6.Location = new System.Drawing.Point(458, 0);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(114, 28);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.emptySpaceItem3.AllowHotTrack = false;
		this.emptySpaceItem3.Location = new System.Drawing.Point(114, 0);
		this.emptySpaceItem3.Name = "emptySpaceItem3";
		this.emptySpaceItem3.Size = new System.Drawing.Size(344, 28);
		this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(576, 451);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Combinations";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Subject Combinations";
		base.Load += new System.EventHandler(Combinations_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem3).EndInit();
		base.ResumeLayout(false);
	}
}
