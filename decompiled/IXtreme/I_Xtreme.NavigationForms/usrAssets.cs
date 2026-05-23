using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.NavigationForms;

public class usrAssets : XtraUserControl
{
	private SqlTransaction trancs;

	private IContainer components = null;

	private LayoutControl layoutControl4;

	private TextEdit txtItemOid;

	private TextEdit txtLifeSpan;

	private GridControl gridControl8;

	private GridView gridView1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private RepositoryItemMemoEdit repositoryItemMemoEdit2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private GridColumn gridColumn7;

	private GridColumn gridColumn8;

	private GridColumn gridColumn9;

	private DateEdit dtDeprDate;

	private RadioGroup radioGrDepreMethod;

	private SimpleButton simpleButton21;

	private TextEdit txtDepreciation;

	private TextEdit txtItemDepreRate;

	private CheckEdit chkIsDepreciable;

	private TextEdit txtItemInitialCost;

	private TextEdit txtItemQty;

	private TextEdit txtItemName;

	private MemoEdit txtItemDescription;

	private TextEdit txtItemUnits;

	private LayoutControlGroup layoutControlGroup45;

	private LayoutControlGroup layoutControlGroup46;

	private LayoutControlItem layoutControlItem10;

	private LayoutControlItem layoutControlItem11;

	private LayoutControlItem layoutControlItem12;

	private LayoutControlItem layoutControlItem13;

	private LayoutControlItem layoutControlItem14;

	private LayoutControlItem layoutControlItem64;

	private LayoutControlItem layoutControlItem16;

	private LayoutControlItem layoutControlItem34;

	private LayoutControlItem layoutControlItem36;

	private LayoutControlItem layoutControlItem15;

	private LayoutControlItem layoutControlItem9;

	private EmptySpaceItem emptySpaceItem10;

	private LayoutControlItem layoutControlItem65;

	private LayoutControlItem layoutControlItem86;

	private LayoutControlItem layoutControlItem63;

	private DXValidationProvider dxValidationProvider8;

	public usrAssets()
	{
		InitializeComponent();
	}

	private void AddSets()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_FixedAssets_Value WHERE AssetName = '{txtItemName.Text}'", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Assets");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count >= 1)
			{
				XtraMessageBox.Show("This Item already exists. Please change the name of the item", "Duplicate entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			trancs = sqlConnection.BeginTransaction();
			float result = (float.TryParse(txtItemQty.Text, out result) ? result : 1f);
			double result2 = (double.TryParse(txtItemInitialCost.Text, out result2) ? result2 : 0.0);
			float result3 = (float.TryParse(txtLifeSpan.Text, out result3) ? result3 : 0f);
			double result4 = (double.TryParse(txtItemDepreRate.Text, out result4) ? result4 : 10.0);
			string value = string.Empty;
			if (radioGrDepreMethod.SelectedIndex == 0)
			{
				value = "Straight Line Method";
			}
			else if (radioGrDepreMethod.SelectedIndex == 1)
			{
				value = "Declining Balance Method";
			}
			DateTime dateTime = dtDeprDate.DateTime;
			Guid guid = new Guid(txtItemOid.Text);
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trancs,
				CommandText = "INSERT INTO tbl_FixedAssets_Value (Oid,AssetName,Description,Qty,units,IsDepreciable,DepreMethod,DepreRate,InitialCost,lifeSpan,AssetValue,Year,CalcDate)VALUES(@Oid,@AssetName,@Description,@Qty,@units,@IsDepreciable,@DepreMethod,@DepreRate,@InitialCost,@lifeSpan,@AssetValue,@Year,@CalcDate)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Oid", SqlDbType.UniqueIdentifier);
				sqlParameter.Value = guid;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@AssetName", SqlDbType.VarChar, 50);
				sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtItemName.Text);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Description", SqlDbType.VarChar, 150);
				sqlParameter.Value = txtItemDescription.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Qty", SqlDbType.Float);
				sqlParameter.Value = result;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@units", SqlDbType.VarChar, 30);
				sqlParameter.Value = txtItemUnits.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@IsDepreciable", SqlDbType.Bit);
				sqlParameter.Value = chkIsDepreciable.EditValue;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@DepreMethod", SqlDbType.VarChar, 50);
				sqlParameter.Value = value;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@DepreRate", SqlDbType.Float);
				sqlParameter.Value = result4;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@InitialCost", SqlDbType.Money);
				sqlParameter.Value = result2;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@lifeSpan", SqlDbType.Float);
				sqlParameter.Value = result3;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@AssetValue", SqlDbType.Money);
				sqlParameter.Value = result2;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Year", SqlDbType.Int);
				sqlParameter.Value = Convert.ToInt32(dateTime.Year);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@CalcDate", SqlDbType.DateTime);
				sqlParameter.Value = dateTime.ToShortDateString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trancs,
				CommandText = "INSERT INTO tbl_FixedAssets (Oid,InitialCost,DeprRate,DepreAmount,AssetValue,Year) VALUES (@Oid,@InitialCost,@DeprRate,@DepreAmount,@AssetValue,@Year)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@Oid", SqlDbType.UniqueIdentifier);
				sqlParameter2.Value = guid;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@InitialCost", SqlDbType.Money);
				sqlParameter2.Value = result2;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@DeprRate", SqlDbType.Float);
				sqlParameter2.Value = result4;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@DepreAmount", SqlDbType.Money);
				sqlParameter2.Value = Convert.ToDouble(txtDepreciation.Text);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@AssetValue", SqlDbType.Money);
				sqlParameter2.Value = result2;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Year", SqlDbType.VarChar, 30);
				sqlParameter2.Value = Convert.ToInt32(dateTime.Year);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@CalcDate", SqlDbType.DateTime);
				sqlParameter2.Value = dateTime.ToShortDateString();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand3 = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trancs,
				CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,_date,month,year,debit,credit,captureDate,Narration) VALUES (@accNo,@particulars,@_date,@month,@year,@debit,@credit,@captureDate,@Narration)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@accNo", SqlDbType.Int);
				sqlParameter3.Value = 4001;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
				sqlParameter3.Value = "Fixed Assets";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@_date", SqlDbType.DateTime);
				sqlParameter3.Value = dateTime.ToLongDateString();
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@month", SqlDbType.VarChar, 9);
				sqlParameter3.Value = dateTime.ToString("MMMM");
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@year", SqlDbType.Int);
				sqlParameter3.Value = dateTime.Year;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@debit", SqlDbType.Money);
				sqlParameter3.Value = result2;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@credit", SqlDbType.Money);
				sqlParameter3.Value = 0;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
				sqlParameter3.Value = dateTime.ToOADate();
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@Narration", SqlDbType.VarChar);
				sqlParameter3.Value = $"{txtItemName.Text} -{txtItemDescription.Text}";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlCommand3.ExecuteNonQuery();
			}
			trancs.Commit();
			CustomDialog.ShowCustomDialog("Item added successfully");
			sqlConnection.Close();
			txtItemOid.Text = Guid.NewGuid().ToString();
			LoadAssets();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadAssets()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_FixedAssets_Value", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Assets");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			gridControl8.DataSource = dataTable.DefaultView;
			GridColumnSummaryItem gridColumnSummaryItem = new GridColumnSummaryItem();
			gridColumnSummaryItem.SetSummary(SummaryItemType.Sum, "{0:#,#.0}");
			gridColumnSummaryItem.FieldName = "AssetValue";
			gridView1.Columns["AssetValue"].SummaryItem.Assign(gridColumnSummaryItem);
			gridView1.GroupSummary.Clear();
			gridView1.GroupSummary.AddRange(new GridSummaryItem[1]
			{
				new GridGroupSummaryItem(SummaryItemType.Sum, "AssetValue", null, "Total Assets = {0:#,#.0}")
			});
			gridView1.UpdateSummary();
			PrintableControl.SavePrintableControl(gridControl8);
			PrintableControl.SavePrintableControl(gridView1);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void txtLifeSpan_TextChanged(object sender, EventArgs e)
	{
		dxValidationProvider8.RemoveControlError(txtLifeSpan);
		double result = (double.TryParse(txtLifeSpan.Text, out result) ? result : 0.0);
		double result2 = (double.TryParse(txtItemInitialCost.Text, out result2) ? result2 : 0.0);
		double num = result2 / result;
		double num2 = num / result2 * 100.0;
	}

	private void txtItemInitialCost_TextChanged(object sender, EventArgs e)
	{
		dxValidationProvider8.RemoveControlError(txtItemInitialCost);
		double result = (double.TryParse(txtLifeSpan.Text, out result) ? result : 0.0);
		double result2 = (double.TryParse(txtItemInitialCost.Text, out result2) ? result2 : 0.0);
		double num = result2 / result;
		double num2 = num / result2 * 100.0;
		txtDepreciation.Text = num.ToString();
		txtItemDepreRate.Text = num2.ToString();
	}

	private void simpleButton21_Click(object sender, EventArgs e)
	{
		if (txtItemName.Text == string.Empty || txtItemQty.Text == string.Empty || txtItemUnits.Text == string.Empty || txtLifeSpan.Text == string.Empty || txtItemInitialCost.Text == string.Empty)
		{
			dxValidationProvider8.Validate();
		}
		else
		{
			AddSets();
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
		this.components = new System.ComponentModel.Container();
		this.layoutControl4 = new DevExpress.XtraLayout.LayoutControl();
		this.txtItemOid = new DevExpress.XtraEditors.TextEdit();
		this.txtLifeSpan = new DevExpress.XtraEditors.TextEdit();
		this.gridControl8 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.dtDeprDate = new DevExpress.XtraEditors.DateEdit();
		this.radioGrDepreMethod = new DevExpress.XtraEditors.RadioGroup();
		this.simpleButton21 = new DevExpress.XtraEditors.SimpleButton();
		this.txtDepreciation = new DevExpress.XtraEditors.TextEdit();
		this.txtItemDepreRate = new DevExpress.XtraEditors.TextEdit();
		this.chkIsDepreciable = new DevExpress.XtraEditors.CheckEdit();
		this.txtItemInitialCost = new DevExpress.XtraEditors.TextEdit();
		this.txtItemQty = new DevExpress.XtraEditors.TextEdit();
		this.txtItemName = new DevExpress.XtraEditors.TextEdit();
		this.txtItemDescription = new DevExpress.XtraEditors.MemoEdit();
		this.txtItemUnits = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup45 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlGroup46 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem64 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem65 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem86 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem63 = new DevExpress.XtraLayout.LayoutControlItem();
		this.dxValidationProvider8 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl4).BeginInit();
		this.layoutControl4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtItemOid.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtLifeSpan.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtDeprDate.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtDeprDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.radioGrDepreMethod.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDepreciation.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtItemDepreRate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkIsDepreciable.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtItemInitialCost.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtItemQty.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtItemName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtItemDescription.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtItemUnits.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup45).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup46).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem64).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem16).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem34).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem36).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem65).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem86).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem63).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider8).BeginInit();
		base.SuspendLayout();
		this.layoutControl4.Controls.Add(this.txtItemOid);
		this.layoutControl4.Controls.Add(this.txtLifeSpan);
		this.layoutControl4.Controls.Add(this.gridControl8);
		this.layoutControl4.Controls.Add(this.dtDeprDate);
		this.layoutControl4.Controls.Add(this.radioGrDepreMethod);
		this.layoutControl4.Controls.Add(this.simpleButton21);
		this.layoutControl4.Controls.Add(this.txtDepreciation);
		this.layoutControl4.Controls.Add(this.txtItemDepreRate);
		this.layoutControl4.Controls.Add(this.chkIsDepreciable);
		this.layoutControl4.Controls.Add(this.txtItemInitialCost);
		this.layoutControl4.Controls.Add(this.txtItemQty);
		this.layoutControl4.Controls.Add(this.txtItemName);
		this.layoutControl4.Controls.Add(this.txtItemDescription);
		this.layoutControl4.Controls.Add(this.txtItemUnits);
		this.layoutControl4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl4.Location = new System.Drawing.Point(0, 0);
		this.layoutControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.layoutControl4.Name = "layoutControl4";
		this.layoutControl4.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(327, 67, 840, 503);
		this.layoutControl4.Root = this.layoutControlGroup45;
		this.layoutControl4.Size = new System.Drawing.Size(1264, 738);
		this.layoutControl4.TabIndex = 1;
		this.layoutControl4.Text = "layoutControl4";
		this.txtItemOid.Location = new System.Drawing.Point(5, 5);
		this.txtItemOid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtItemOid.Name = "txtItemOid";
		this.txtItemOid.Properties.ReadOnly = true;
		this.txtItemOid.Size = new System.Drawing.Size(248, 26);
		this.txtItemOid.StyleController = this.layoutControl4;
		this.txtItemOid.TabIndex = 20;
		this.txtLifeSpan.Location = new System.Drawing.Point(174, 365);
		this.txtLifeSpan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtLifeSpan.Name = "txtLifeSpan";
		this.txtLifeSpan.Properties.Mask.EditMask = "f";
		this.txtLifeSpan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtLifeSpan.Size = new System.Drawing.Size(79, 26);
		this.txtLifeSpan.StyleController = this.layoutControl4;
		this.txtLifeSpan.TabIndex = 19;
		this.txtLifeSpan.TextChanged += new System.EventHandler(txtLifeSpan_TextChanged);
		this.gridControl8.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
		this.gridControl8.Location = new System.Drawing.Point(259, 5);
		this.gridControl8.MainView = this.gridView1;
		this.gridControl8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.gridControl8.Name = "gridControl8";
		this.gridControl8.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemMemoEdit2 });
		this.gridControl8.Size = new System.Drawing.Size(1000, 728);
		this.gridControl8.TabIndex = 18;
		this.gridControl8.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[9] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6, this.gridColumn7, this.gridColumn8, this.gridColumn9 });
		this.gridView1.GridControl = this.gridControl8;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridView1.OptionsCustomization.AllowGroup = false;
		this.gridView1.OptionsView.ShowFooter = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridColumn1.Caption = "Item";
		this.gridColumn1.FieldName = "AssetName";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 131;
		this.gridColumn2.Caption = "Description";
		this.gridColumn2.ColumnEdit = this.repositoryItemMemoEdit2;
		this.gridColumn2.FieldName = "Description";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn2.Width = 247;
		this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
		this.gridColumn3.Caption = "Qty";
		this.gridColumn3.FieldName = "Qty";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 2;
		this.gridColumn3.Width = 45;
		this.gridColumn4.Caption = "Units";
		this.gridColumn4.FieldName = "units";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 3;
		this.gridColumn4.Width = 162;
		this.gridColumn5.Caption = "InitialCost";
		this.gridColumn5.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn5.FieldName = "InitialCost";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 4;
		this.gridColumn5.Width = 137;
		this.gridColumn6.Caption = "Life Span (Yrs)";
		this.gridColumn6.FieldName = "lifeSpan";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 5;
		this.gridColumn6.Width = 72;
		this.gridColumn7.Caption = "Dep. Rate";
		this.gridColumn7.FieldName = "DepreRate";
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.Visible = true;
		this.gridColumn7.VisibleIndex = 6;
		this.gridColumn7.Width = 102;
		this.gridColumn8.Caption = "Year";
		this.gridColumn8.FieldName = "Year";
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 7;
		this.gridColumn9.Caption = "Asset Value";
		this.gridColumn9.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn9.FieldName = "AssetValue";
		this.gridColumn9.Name = "gridColumn9";
		this.gridColumn9.Visible = true;
		this.gridColumn9.VisibleIndex = 8;
		this.gridColumn9.Width = 209;
		this.dtDeprDate.EditValue = null;
		this.dtDeprDate.Location = new System.Drawing.Point(174, 493);
		this.dtDeprDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.dtDeprDate.Name = "dtDeprDate";
		this.dtDeprDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtDeprDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtDeprDate.Size = new System.Drawing.Size(79, 26);
		this.dtDeprDate.StyleController = this.layoutControl4;
		this.dtDeprDate.TabIndex = 17;
		this.radioGrDepreMethod.Location = new System.Drawing.Point(5, 296);
		this.radioGrDepreMethod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.radioGrDepreMethod.Name = "radioGrDepreMethod";
		this.radioGrDepreMethod.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Straight line method"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Declining Balance Method")
		});
		this.radioGrDepreMethod.Size = new System.Drawing.Size(248, 63);
		this.radioGrDepreMethod.StyleController = this.layoutControl4;
		this.radioGrDepreMethod.TabIndex = 16;
		this.simpleButton21.Location = new System.Drawing.Point(5, 525);
		this.simpleButton21.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.simpleButton21.Name = "simpleButton21";
		this.simpleButton21.Size = new System.Drawing.Size(248, 32);
		this.simpleButton21.StyleController = this.layoutControl4;
		this.simpleButton21.TabIndex = 15;
		this.simpleButton21.Text = "Add Item";
		this.simpleButton21.Click += new System.EventHandler(simpleButton21_Click);
		this.txtDepreciation.Location = new System.Drawing.Point(174, 461);
		this.txtDepreciation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtDepreciation.Name = "txtDepreciation";
		this.txtDepreciation.Properties.ReadOnly = true;
		this.txtDepreciation.Size = new System.Drawing.Size(79, 26);
		this.txtDepreciation.StyleController = this.layoutControl4;
		this.txtDepreciation.TabIndex = 13;
		this.txtItemDepreRate.Location = new System.Drawing.Point(174, 429);
		this.txtItemDepreRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtItemDepreRate.Name = "txtItemDepreRate";
		this.txtItemDepreRate.Properties.ReadOnly = true;
		this.txtItemDepreRate.Size = new System.Drawing.Size(79, 26);
		this.txtItemDepreRate.StyleController = this.layoutControl4;
		this.txtItemDepreRate.TabIndex = 12;
		this.chkIsDepreciable.EditValue = true;
		this.chkIsDepreciable.Location = new System.Drawing.Point(5, 245);
		this.chkIsDepreciable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.chkIsDepreciable.Name = "chkIsDepreciable";
		this.chkIsDepreciable.Properties.Caption = "Is Depreciable";
		this.chkIsDepreciable.Size = new System.Drawing.Size(248, 23);
		this.chkIsDepreciable.StyleController = this.layoutControl4;
		this.chkIsDepreciable.TabIndex = 11;
		this.txtItemInitialCost.Location = new System.Drawing.Point(174, 397);
		this.txtItemInitialCost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtItemInitialCost.Name = "txtItemInitialCost";
		this.txtItemInitialCost.Properties.Mask.EditMask = "n";
		this.txtItemInitialCost.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtItemInitialCost.Size = new System.Drawing.Size(79, 26);
		this.txtItemInitialCost.StyleController = this.layoutControl4;
		this.txtItemInitialCost.TabIndex = 9;
		this.txtItemInitialCost.TextChanged += new System.EventHandler(txtItemInitialCost_TextChanged);
		this.txtItemQty.Location = new System.Drawing.Point(174, 181);
		this.txtItemQty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtItemQty.Name = "txtItemQty";
		this.txtItemQty.Properties.Mask.EditMask = "f";
		this.txtItemQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtItemQty.Size = new System.Drawing.Size(79, 26);
		this.txtItemQty.StyleController = this.layoutControl4;
		this.txtItemQty.TabIndex = 7;
		this.txtItemName.Location = new System.Drawing.Point(174, 37);
		this.txtItemName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtItemName.Name = "txtItemName";
		this.txtItemName.Size = new System.Drawing.Size(79, 26);
		this.txtItemName.StyleController = this.layoutControl4;
		this.txtItemName.TabIndex = 5;
		this.txtItemDescription.Location = new System.Drawing.Point(5, 91);
		this.txtItemDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtItemDescription.Name = "txtItemDescription";
		this.txtItemDescription.Size = new System.Drawing.Size(248, 84);
		this.txtItemDescription.StyleController = this.layoutControl4;
		this.txtItemDescription.TabIndex = 6;
		this.txtItemUnits.Location = new System.Drawing.Point(174, 213);
		this.txtItemUnits.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtItemUnits.Name = "txtItemUnits";
		this.txtItemUnits.Size = new System.Drawing.Size(79, 26);
		this.txtItemUnits.StyleController = this.layoutControl4;
		this.txtItemUnits.TabIndex = 8;
		this.layoutControlGroup45.CustomizationFormText = "layoutControlGroup45";
		this.layoutControlGroup45.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup45.GroupBordersVisible = false;
		this.layoutControlGroup45.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlGroup46, this.layoutControlItem63 });
		this.layoutControlGroup45.Name = "layoutControlGroup45";
		this.layoutControlGroup45.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup45.Size = new System.Drawing.Size(1264, 738);
		this.layoutControlGroup45.TextVisible = false;
		this.layoutControlGroup46.CustomizationFormText = "Add/Edit Item";
		this.layoutControlGroup46.GroupBordersVisible = false;
		this.layoutControlGroup46.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[14]
		{
			this.layoutControlItem10, this.layoutControlItem11, this.layoutControlItem12, this.layoutControlItem13, this.layoutControlItem14, this.layoutControlItem64, this.layoutControlItem16, this.layoutControlItem34, this.layoutControlItem36, this.layoutControlItem15,
			this.layoutControlItem9, this.emptySpaceItem10, this.layoutControlItem65, this.layoutControlItem86
		});
		this.layoutControlGroup46.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup46.Name = "layoutControlGroup46";
		this.layoutControlGroup46.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup46.Size = new System.Drawing.Size(254, 734);
		this.layoutControlGroup46.Text = "Add/Edit Item";
		this.layoutControlItem10.Control = this.txtItemName;
		this.layoutControlItem10.CustomizationFormText = "Name";
		this.layoutControlItem10.Location = new System.Drawing.Point(0, 32);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(254, 32);
		this.layoutControlItem10.Text = "Name";
		this.layoutControlItem10.TextSize = new System.Drawing.Size(166, 19);
		this.layoutControlItem11.Control = this.txtItemDescription;
		this.layoutControlItem11.CustomizationFormText = "Description";
		this.layoutControlItem11.Location = new System.Drawing.Point(0, 64);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(254, 112);
		this.layoutControlItem11.Text = "Description";
		this.layoutControlItem11.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem11.TextSize = new System.Drawing.Size(166, 19);
		this.layoutControlItem12.Control = this.txtItemQty;
		this.layoutControlItem12.CustomizationFormText = "Qty";
		this.layoutControlItem12.Location = new System.Drawing.Point(0, 176);
		this.layoutControlItem12.Name = "layoutControlItem12";
		this.layoutControlItem12.Size = new System.Drawing.Size(254, 32);
		this.layoutControlItem12.Text = "Qty";
		this.layoutControlItem12.TextSize = new System.Drawing.Size(166, 19);
		this.layoutControlItem13.Control = this.txtItemUnits;
		this.layoutControlItem13.CustomizationFormText = "Units";
		this.layoutControlItem13.Location = new System.Drawing.Point(0, 208);
		this.layoutControlItem13.Name = "layoutControlItem13";
		this.layoutControlItem13.Size = new System.Drawing.Size(254, 32);
		this.layoutControlItem13.Text = "Units";
		this.layoutControlItem13.TextSize = new System.Drawing.Size(166, 19);
		this.layoutControlItem14.Control = this.txtItemInitialCost;
		this.layoutControlItem14.CustomizationFormText = "Initial cost";
		this.layoutControlItem14.Location = new System.Drawing.Point(0, 392);
		this.layoutControlItem14.Name = "layoutControlItem14";
		this.layoutControlItem14.Size = new System.Drawing.Size(254, 32);
		this.layoutControlItem14.Text = "Initial cost";
		this.layoutControlItem14.TextSize = new System.Drawing.Size(166, 19);
		this.layoutControlItem64.Control = this.radioGrDepreMethod;
		this.layoutControlItem64.CustomizationFormText = "Depreciate items using:";
		this.layoutControlItem64.Location = new System.Drawing.Point(0, 269);
		this.layoutControlItem64.Name = "layoutControlItem64";
		this.layoutControlItem64.Size = new System.Drawing.Size(254, 91);
		this.layoutControlItem64.Text = "Depreciate items using:";
		this.layoutControlItem64.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem64.TextSize = new System.Drawing.Size(166, 19);
		this.layoutControlItem16.Control = this.chkIsDepreciable;
		this.layoutControlItem16.CustomizationFormText = "layoutControlItem16";
		this.layoutControlItem16.Location = new System.Drawing.Point(0, 240);
		this.layoutControlItem16.Name = "layoutControlItem16";
		this.layoutControlItem16.Size = new System.Drawing.Size(254, 29);
		this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem16.TextVisible = false;
		this.layoutControlItem34.Control = this.txtItemDepreRate;
		this.layoutControlItem34.CustomizationFormText = "Depreciation rate";
		this.layoutControlItem34.Location = new System.Drawing.Point(0, 424);
		this.layoutControlItem34.Name = "layoutControlItem34";
		this.layoutControlItem34.Size = new System.Drawing.Size(254, 32);
		this.layoutControlItem34.Text = "Depreciation rate";
		this.layoutControlItem34.TextSize = new System.Drawing.Size(166, 19);
		this.layoutControlItem36.Control = this.txtDepreciation;
		this.layoutControlItem36.CustomizationFormText = "Depreciation";
		this.layoutControlItem36.Location = new System.Drawing.Point(0, 456);
		this.layoutControlItem36.Name = "layoutControlItem36";
		this.layoutControlItem36.Size = new System.Drawing.Size(254, 32);
		this.layoutControlItem36.Text = "Depreciation";
		this.layoutControlItem36.TextSize = new System.Drawing.Size(166, 19);
		this.layoutControlItem15.Control = this.simpleButton21;
		this.layoutControlItem15.CustomizationFormText = "layoutControlItem15";
		this.layoutControlItem15.Location = new System.Drawing.Point(0, 520);
		this.layoutControlItem15.Name = "layoutControlItem15";
		this.layoutControlItem15.Size = new System.Drawing.Size(254, 38);
		this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem15.TextVisible = false;
		this.layoutControlItem9.Control = this.dtDeprDate;
		this.layoutControlItem9.CustomizationFormText = "Date";
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 488);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(254, 32);
		this.layoutControlItem9.Text = "Date";
		this.layoutControlItem9.TextSize = new System.Drawing.Size(166, 19);
		this.emptySpaceItem10.AllowHotTrack = false;
		this.emptySpaceItem10.CustomizationFormText = "emptySpaceItem10";
		this.emptySpaceItem10.Location = new System.Drawing.Point(0, 558);
		this.emptySpaceItem10.Name = "emptySpaceItem10";
		this.emptySpaceItem10.Size = new System.Drawing.Size(254, 176);
		this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem65.Control = this.txtLifeSpan;
		this.layoutControlItem65.CustomizationFormText = "Life span (Yrs)";
		this.layoutControlItem65.Location = new System.Drawing.Point(0, 360);
		this.layoutControlItem65.Name = "layoutControlItem65";
		this.layoutControlItem65.Size = new System.Drawing.Size(254, 32);
		this.layoutControlItem65.Text = "Life span (Yrs)";
		this.layoutControlItem65.TextSize = new System.Drawing.Size(166, 19);
		this.layoutControlItem86.Control = this.txtItemOid;
		this.layoutControlItem86.CustomizationFormText = "layoutControlItem86";
		this.layoutControlItem86.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem86.Name = "layoutControlItem86";
		this.layoutControlItem86.Size = new System.Drawing.Size(254, 32);
		this.layoutControlItem86.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem86.TextVisible = false;
		this.layoutControlItem86.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutControlItem63.Control = this.gridControl8;
		this.layoutControlItem63.CustomizationFormText = "layoutControlItem63";
		this.layoutControlItem63.Location = new System.Drawing.Point(254, 0);
		this.layoutControlItem63.Name = "layoutControlItem63";
		this.layoutControlItem63.Size = new System.Drawing.Size(1006, 734);
		this.layoutControlItem63.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem63.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl4);
		base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		base.Name = "usrAssets";
		base.Size = new System.Drawing.Size(1264, 738);
		((System.ComponentModel.ISupportInitialize)this.layoutControl4).EndInit();
		this.layoutControl4.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtItemOid.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtLifeSpan.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtDeprDate.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtDeprDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.radioGrDepreMethod.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDepreciation.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtItemDepreRate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkIsDepreciable.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtItemInitialCost.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtItemQty.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtItemName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtItemDescription.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtItemUnits.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup45).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup46).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem64).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem16).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem34).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem36).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem65).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem86).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem63).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider8).EndInit();
		base.ResumeLayout(false);
	}
}
