using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.DialogForms;

public class AddStockItem : XtraForm
{
	private string depreciationMethod = "Straight Line Method";

	private long itemId = 0L;

	private int category = 4000;

	private SqlTransaction trans;

	private SqlTransaction trans_update;

	private DataTable dtc;

	private DataTable dti;

	public StartOrStopTimer StartTimer;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LabelControl labelControl1;

	private SimpleButton simpleButton2;

	private TextEdit txtAssetValue;

	private TextEdit txtUnitCost;

	private TextEdit txtQty;

	private TextEdit txtItem;

	private MemoEdit txtDescription;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem9;

	private LayoutControlItem layoutControlItem11;

	private LayoutControlItem layoutControlItem13;

	private LayoutControlItem layoutControlItem14;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem15;

	private ComboBoxEdit cboCategory;

	private ComboBoxEdit cboUnits;

	private CheckEdit chkIsDepreciable;

	private ComboBoxEdit cboItemType;

	private LayoutControlItem layoutControlItem12;

	public SimpleButton simpleButton1;

	private System.Windows.Forms.Timer timer1;

	public AddStockItem()
	{
		InitializeComponent();
		LoadStockCategories();
	}

	private void UpdateStockItem()
	{
		try
		{
			DataRow dataRow = dtc.Rows[cboCategory.SelectedIndex - 2];
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			trans_update = sqlConnection.BeginTransaction();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans_update,
				CommandText = "UPDATE tbl_StockItems SET AssetName=@AssetName,ItemType=@ItemType,Description=@Description,Qty=@Qty,units=@units,IsDepreciable=@IsDepreciable,DepreMethod=@DepreMethod,DepreRate=@DepreRate,InitialCost=@InitialCost,lifeSpan=@lifeSpan,AssetValue=@AssetValue,category=@category WHERE id=@id",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@id", SqlDbType.BigInt);
				sqlParameter.Value = itemId;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@AssetName", SqlDbType.VarChar, 50);
				sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtItem.Text);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@ItemType", SqlDbType.VarChar, 30);
				sqlParameter.Value = cboItemType.SelectedItem.ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Description", SqlDbType.VarChar, 150);
				sqlParameter.Value = txtDescription.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Qty", SqlDbType.Int);
				sqlParameter.Value = txtQty.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@units", SqlDbType.VarChar, 30);
				sqlParameter.Value = cboUnits.SelectedItem.ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@IsDepreciable", SqlDbType.Bit);
				sqlParameter.Value = Convert.ToBoolean(chkIsDepreciable.EditValue);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@DepreMethod", SqlDbType.VarChar, 25);
				sqlParameter.Value = depreciationMethod;
				sqlParameter.Direction = ParameterDirection.Input;
				double num = 5.0;
				double result = (double.TryParse(txtAssetValue.Text, out result) ? result : 0.0);
				double num2 = 5.0;
				double result2 = (double.TryParse(txtUnitCost.Text, out result2) ? result2 : 0.0);
				sqlParameter = sqlCommand.Parameters.Add("@DepreRate", SqlDbType.Float);
				sqlParameter.Value = num2;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@InitialCost", SqlDbType.Money);
				sqlParameter.Value = result2;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@lifeSpan", SqlDbType.Float);
				sqlParameter.Value = num;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@AssetValue", SqlDbType.Money);
				sqlParameter.Value = result;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@category", SqlDbType.BigInt);
				sqlParameter.Value = dataRow["id"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			if (cboItemType.SelectedIndex == 0)
			{
				string value = SubAccountNumber(InventoryItem.StockItemName);
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans_update,
					CommandText = "UPDATE tbl_generalAccounts_Sub SET SubAccoutName=@SubAccoutName WHERE subAccountNo=@subAccountNo",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@subAccountNo", SqlDbType.VarChar, 9);
					sqlParameter2.Value = value;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@SubAccoutName", SqlDbType.VarChar, 25);
					sqlParameter2.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtItem.Text);
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				double result3 = (double.TryParse(txtAssetValue.Text, out result3) ? result3 : 0.0);
				using SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans_update,
					CommandText = "UPDATE tbl_StatementOfAffairs SET particulars=@particulars,_date=@_date,month=@month,year=@year,Debit=@Debit,Narration=@Narration WHERE accNo=@accNo",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
				sqlParameter3.Value = value;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
				sqlParameter3.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtItem.Text);
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@_date", SqlDbType.DateTime);
				sqlParameter3.Value = FinalAccounts.BooksBeginningDate.ToShortDateString();
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@month", SqlDbType.VarChar, 9);
				sqlParameter3.Value = FinalAccounts.BooksBeginningDate.ToString("MMM");
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@year", SqlDbType.Int);
				sqlParameter3.Value = FinalAccounts.BooksBeginningDate.Year;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@Debit", SqlDbType.Money);
				sqlParameter3.Value = result3;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@Narration", SqlDbType.VarChar);
				sqlParameter3.Value = "Openning Balance";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlCommand3.ExecuteNonQuery();
			}
			trans_update.Commit();
			sqlConnection.Close();
			StartTimer(timerStatus: true);
			Dispose();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void AddNewStockItem()
	{
		try
		{
			DataRow dataRow = dtc.Rows[cboCategory.SelectedIndex - 2];
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT * FROM tbl_StockItems WHERE AssetName=@AssetName",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@AssetName", SqlDbType.VarChar, 50);
			sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtItem.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (!sqlDataReader.HasRows)
			{
				sqlConnection.Close();
				using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection2.Open();
				string commandText = "INSERT INTO tbl_StockItems (AssetName,ItemType,Description,Qty,units,IsDepreciable,DepreMethod,DepreRate,InitialCost,lifeSpan,AssetValue,category) VALUES (@AssetName,@ItemType,@Description,@Qty,@units,@IsDepreciable,@DepreMethod,@DepreRate,@InitialCost,@lifeSpan,@AssetValue,@category)";
				using SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = commandText,
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@AssetName", SqlDbType.VarChar, 50);
				sqlParameter2.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtItem.Text);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@ItemType", SqlDbType.VarChar, 30);
				sqlParameter2.Value = cboItemType.SelectedItem.ToString();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Description", SqlDbType.VarChar, 150);
				sqlParameter2.Value = txtDescription.Text;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Qty", SqlDbType.Int);
				sqlParameter2.Value = txtQty.Text;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@units", SqlDbType.VarChar, 30);
				sqlParameter2.Value = cboUnits.SelectedItem.ToString();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@IsDepreciable", SqlDbType.Bit);
				sqlParameter2.Value = Convert.ToBoolean(chkIsDepreciable.EditValue);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@DepreMethod", SqlDbType.VarChar, 25);
				sqlParameter2.Value = depreciationMethod;
				sqlParameter2.Direction = ParameterDirection.Input;
				double num = 5.0;
				double result = (double.TryParse(txtAssetValue.Text, out result) ? result : 0.0);
				double num2 = 5.0;
				double result2 = (double.TryParse(txtUnitCost.Text, out result2) ? result2 : 0.0);
				sqlParameter2 = sqlCommand2.Parameters.Add("@DepreRate", SqlDbType.Float);
				sqlParameter2.Value = num2;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@InitialCost", SqlDbType.Money);
				sqlParameter2.Value = result2;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@lifeSpan", SqlDbType.Float);
				sqlParameter2.Value = num;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@AssetValue", SqlDbType.Money);
				sqlParameter2.Value = result;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@category", SqlDbType.BigInt);
				sqlParameter2.Value = Convert.ToInt64(dataRow["id"].ToString());
				sqlParameter2.Direction = ParameterDirection.Input;
				if (sqlCommand2.ExecuteNonQuery() > 0)
				{
					StartTimer(timerStatus: true);
					sqlConnection2.Close();
				}
				return;
			}
			sqlConnection.Close();
			XtraMessageBox.Show("The Item you are adding already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			txtItem.Focus();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadStockCategories()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_StockCategories", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StockCategories");
			dtc = dataSet.Tables[0];
			cboCategory.Properties.Items.Clear();
			ComboBoxItemCollection items = cboCategory.Properties.Items;
			object[] items2 = new string[2] { "Select Category", "-Add New-" };
			items.AddRange(items2);
			foreach (DataRow row in dtc.Rows)
			{
				cboCategory.Properties.Items.Add(row["category"].ToString());
			}
			cboCategory.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (Text.Contains("Add"))
		{
			if (cboItemType.SelectedIndex == 0)
			{
				AppendAccounts();
			}
			else
			{
				AddNewStockItem();
			}
		}
		else if (Text.Contains("Edit"))
		{
			UpdateStockItem();
		}
	}

	private void AddStockItem_Load(object sender, EventArgs e)
	{
		if (Text.Contains("Edit"))
		{
			LoadInventoryItemForEditing();
		}
	}

	private void LoadInventoryItemForEditing()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT i.id AS Itemid, c.category,i.AssetName,i.Description,i.Qty,i.InitialCost,(i.Qty * i.InitialCost) AS CostPrice,i.IsDepreciable,i.DepreMethod,i.DepreRate,i.lifeSpan,i.AssetValue,i.units,i.ItemType FROM tbl_StockItems i INNER JOIN tbl_StockCategories c ON i.category=c.id WHERE i.id={InventoryItem.StockCategoryID}", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StockItemsForEditing");
			dti = new DataTable();
			dti = dataSet.Tables[0];
			foreach (DataRow row in dti.Rows)
			{
				txtAssetValue.Text = row["AssetValue"].ToString();
				txtDescription.Text = row["Description"].ToString();
				txtItem.Text = row["AssetName"].ToString();
				txtQty.Text = row["Qty"].ToString();
				txtUnitCost.Text = row["InitialCost"].ToString();
				cboCategory.SelectedItem = row["category"].ToString();
				cboItemType.SelectedItem = row["ItemType"].ToString();
				cboUnits.SelectedItem = row["units"].ToString();
				chkIsDepreciable.Checked = Convert.ToBoolean(row["IsDepreciable"].ToString());
				itemId = Convert.ToInt64(row["Itemid"].ToString());
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void AddStockItem_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			Close();
		}
		else if (e.Control && e.KeyCode == Keys.Return)
		{
			if (Text.Contains("Add"))
			{
				AddNewStockItem();
			}
			else if (Text.Contains("Edit"))
			{
				UpdateStockItem();
			}
		}
	}

	private void txtQty_TextChanged(object sender, EventArgs e)
	{
		int result = ((!int.TryParse(txtQty.Text, out result)) ? 1 : result);
		double result2 = (double.TryParse(txtUnitCost.Text, out result2) ? result2 : 0.0);
		txtAssetValue.Text = ((double)result * result2).ToString();
	}

	private void txtUnitCost_TextChanged(object sender, EventArgs e)
	{
		int result = ((!int.TryParse(txtQty.Text, out result)) ? 1 : result);
		double result2 = (double.TryParse(txtUnitCost.Text, out result2) ? result2 : 0.0);
		txtAssetValue.Text = ((double)result * result2).ToString();
	}

	private void cboCategory_Closed(object sender, ClosedEventArgs e)
	{
		if (cboCategory.SelectedItem.ToString() == "-Add New-" && cboItemType.SelectedIndex == 0)
		{
			using (AddAccounts addAccounts = new AddAccounts(IsReadOnly: true, "SubCreation"))
			{
				if (addAccounts.ShowDialog() == DialogResult.OK)
				{
					LoadStockCategories();
				}
				return;
			}
		}
		if (!(cboCategory.SelectedItem.ToString() == "-Add New-") || cboItemType.SelectedIndex != 1)
		{
			return;
		}
		using AddStockCategory addStockCategory = new AddStockCategory();
		if (addStockCategory.ShowDialog() == DialogResult.OK)
		{
			LoadStockCategories();
		}
	}

	private void AppendAccounts()
	{
		try
		{
			DataRow dataRow = dtc.Rows[cboCategory.SelectedIndex - 2];
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = $"SELECT * FROM tbl_generalAccounts_Sub WHERE accNo={AccountNumber(cboCategory.SelectedItem.ToString())} AND SubAccoutName='{txtItem.Text}'",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (!sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				string nextSubAccountNumber = FinalAccounts.GetNextSubAccountNumber(category, AccountNumber(cboCategory.SelectedItem.ToString()));
				trans = sqlConnection.BeginTransaction();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandText = "INSERT INTO tbl_generalAccounts_Sub (accNo,subAccountNo,SubAccoutName,RefNo)VALUES(@accNo,@subAccountNo,@SubAccoutName,@RefNo)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@accNo", SqlDbType.Int);
					sqlParameter.Value = AccountNumber(cboCategory.SelectedItem.ToString());
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@subAccountNo", SqlDbType.VarChar, 9);
					sqlParameter.Value = nextSubAccountNumber;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@SubAccoutName", SqlDbType.VarChar, 25);
					sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtItem.Text);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@RefNo", SqlDbType.VarChar, 25);
					sqlParameter.Value = string.Empty;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				string commandText = "INSERT INTO tbl_StockItems (AssetName,ItemType,Description,Qty,units,IsDepreciable,DepreMethod,DepreRate,InitialCost,lifeSpan,AssetValue,category) VALUES (@AssetName,@ItemType,@Description,@Qty,@units,@IsDepreciable,@DepreMethod,@DepreRate,@InitialCost,@lifeSpan,@AssetValue,@category)";
				using (SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandText = commandText,
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@AssetName", SqlDbType.VarChar, 50);
					sqlParameter2.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtItem.Text);
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand3.Parameters.Add("@ItemType", SqlDbType.VarChar, 30);
					sqlParameter2.Value = cboItemType.SelectedItem.ToString();
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand3.Parameters.Add("@Description", SqlDbType.VarChar, 150);
					sqlParameter2.Value = txtDescription.Text;
					sqlParameter2.Direction = ParameterDirection.Input;
					double num = 5.0;
					double result = (double.TryParse(txtAssetValue.Text, out result) ? result : 0.0);
					double num2 = 5.0;
					double result2 = (double.TryParse(txtUnitCost.Text, out result2) ? result2 : 0.0);
					int result3 = ((!int.TryParse(txtQty.Text, out result3)) ? 1 : result3);
					sqlParameter2 = sqlCommand3.Parameters.Add("@Qty", SqlDbType.Int);
					sqlParameter2.Value = result3;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand3.Parameters.Add("@units", SqlDbType.VarChar, 30);
					sqlParameter2.Value = cboUnits.SelectedItem.ToString();
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand3.Parameters.Add("@IsDepreciable", SqlDbType.Bit);
					sqlParameter2.Value = Convert.ToBoolean(chkIsDepreciable.EditValue);
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand3.Parameters.Add("@DepreMethod", SqlDbType.VarChar, 25);
					sqlParameter2.Value = depreciationMethod;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand3.Parameters.Add("@DepreRate", SqlDbType.Float);
					sqlParameter2.Value = num2;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand3.Parameters.Add("@InitialCost", SqlDbType.Money);
					sqlParameter2.Value = result2;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand3.Parameters.Add("@lifeSpan", SqlDbType.Float);
					sqlParameter2.Value = num;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand3.Parameters.Add("@AssetValue", SqlDbType.Money);
					sqlParameter2.Value = result;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand3.Parameters.Add("@category", SqlDbType.BigInt);
					sqlParameter2.Value = Convert.ToInt64(dataRow["id"].ToString());
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlCommand3.ExecuteNonQuery();
				}
				trans.Commit();
				sqlConnection.Close();
				StartTimer(timerStatus: true);
			}
			else
			{
				sqlDataReader.Close();
				sqlConnection.Close();
				XtraMessageBox.Show("This account already exists", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private int AccountNumber(string AccountName)
	{
		int result = 0;
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT accNo FROM tbl_generalAccounts WHERE accName='{AccountName}'", DataConnection.ConnectToDatabase()))
		{
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StockCategories");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				result = Convert.ToInt32(row["accNo"].ToString());
			}
		}
		return result;
	}

	private string SubAccountNumber(string AccountName)
	{
		string result = string.Empty;
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT subAccountNo FROM tbl_generalAccounts_Sub WHERE SubAccoutName='{AccountName}'", DataConnection.ConnectToDatabase()))
		{
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StockItems");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				result = row["subAccountNo"].ToString();
			}
		}
		return result;
	}

	private void cboCategory_QueryPopUp(object sender, CancelEventArgs e)
	{
		cboCategory.SelectedIndex = 0;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (cboItemType.SelectedIndex > -1 && cboCategory.SelectedIndex > 1 && !string.IsNullOrEmpty(txtItem.Text) && !string.IsNullOrEmpty(txtQty.Text))
		{
			simpleButton1.Enabled = true;
		}
		else
		{
			simpleButton1.Enabled = false;
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.cboItemType = new DevExpress.XtraEditors.ComboBoxEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtAssetValue = new DevExpress.XtraEditors.TextEdit();
		this.txtUnitCost = new DevExpress.XtraEditors.TextEdit();
		this.txtQty = new DevExpress.XtraEditors.TextEdit();
		this.txtItem = new DevExpress.XtraEditors.TextEdit();
		this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
		this.cboCategory = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboUnits = new DevExpress.XtraEditors.ComboBoxEdit();
		this.chkIsDepreciable = new DevExpress.XtraEditors.CheckEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.cboItemType.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAssetValue.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtUnitCost.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtQty.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDescription.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboCategory.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboUnits.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkIsDepreciable.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.cboItemType);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.txtAssetValue);
		this.layoutControl1.Controls.Add(this.txtUnitCost);
		this.layoutControl1.Controls.Add(this.txtQty);
		this.layoutControl1.Controls.Add(this.txtItem);
		this.layoutControl1.Controls.Add(this.txtDescription);
		this.layoutControl1.Controls.Add(this.cboCategory);
		this.layoutControl1.Controls.Add(this.cboUnits);
		this.layoutControl1.Controls.Add(this.chkIsDepreciable);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(438, 355);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.cboItemType.EnterMoveNextControl = true;
		this.cboItemType.Location = new System.Drawing.Point(81, 2);
		this.cboItemType.Name = "cboItemType";
		this.cboItemType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboItemType.Properties.Appearance.Options.UseFont = true;
		this.cboItemType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboItemType.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboItemType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboItemType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboItemType.Properties.Items.AddRange(new object[2] { "Fixed Asset", "Stock Item" });
		this.cboItemType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboItemType.Size = new System.Drawing.Size(355, 24);
		this.cboItemType.StyleController = this.layoutControl1;
		this.cboItemType.TabIndex = 1;
		this.labelControl1.Location = new System.Drawing.Point(2, 314);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(434, 13);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 18;
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(222, 331);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(214, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 17;
		this.simpleButton2.Text = "Cancel";
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(2, 331);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(216, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 12;
		this.simpleButton1.Text = "Save";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.txtAssetValue.EditValue = "0";
		this.txtAssetValue.EnterMoveNextControl = true;
		this.txtAssetValue.Location = new System.Drawing.Point(81, 249);
		this.txtAssetValue.Name = "txtAssetValue";
		this.txtAssetValue.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtAssetValue.Properties.Appearance.Options.UseFont = true;
		this.txtAssetValue.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtAssetValue.Properties.DisplayFormat.FormatString = "{0:#,#.0}";
		this.txtAssetValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.txtAssetValue.Properties.ReadOnly = true;
		this.txtAssetValue.Size = new System.Drawing.Size(355, 24);
		this.txtAssetValue.StyleController = this.layoutControl1;
		this.txtAssetValue.TabIndex = 11;
		this.txtUnitCost.EditValue = "0";
		this.txtUnitCost.EnterMoveNextControl = true;
		this.txtUnitCost.Location = new System.Drawing.Point(81, 221);
		this.txtUnitCost.Name = "txtUnitCost";
		this.txtUnitCost.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtUnitCost.Properties.Appearance.Options.UseFont = true;
		this.txtUnitCost.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtUnitCost.Properties.DisplayFormat.FormatString = "{0:#,#.0}";
		this.txtUnitCost.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.txtUnitCost.Properties.EditFormat.FormatString = "{0:#,#.0}";
		this.txtUnitCost.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.txtUnitCost.Properties.Mask.EditMask = "n";
		this.txtUnitCost.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtUnitCost.Size = new System.Drawing.Size(355, 24);
		this.txtUnitCost.StyleController = this.layoutControl1;
		this.txtUnitCost.TabIndex = 7;
		this.txtUnitCost.TextChanged += new System.EventHandler(txtUnitCost_TextChanged);
		this.txtQty.EditValue = "1";
		this.txtQty.EnterMoveNextControl = true;
		this.txtQty.Location = new System.Drawing.Point(81, 193);
		this.txtQty.Name = "txtQty";
		this.txtQty.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtQty.Properties.Appearance.Options.UseFont = true;
		this.txtQty.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtQty.Properties.Mask.EditMask = "f0";
		this.txtQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtQty.Size = new System.Drawing.Size(137, 24);
		this.txtQty.StyleController = this.layoutControl1;
		this.txtQty.TabIndex = 5;
		this.txtQty.TextChanged += new System.EventHandler(txtQty_TextChanged);
		this.txtItem.EnterMoveNextControl = true;
		this.txtItem.Location = new System.Drawing.Point(81, 58);
		this.txtItem.Name = "txtItem";
		this.txtItem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtItem.Properties.Appearance.Options.UseFont = true;
		this.txtItem.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtItem.Size = new System.Drawing.Size(208, 24);
		this.txtItem.StyleController = this.layoutControl1;
		this.txtItem.TabIndex = 2;
		this.txtDescription.Location = new System.Drawing.Point(2, 105);
		this.txtDescription.Name = "txtDescription";
		this.txtDescription.Size = new System.Drawing.Size(434, 84);
		this.txtDescription.StyleController = this.layoutControl1;
		this.txtDescription.TabIndex = 4;
		this.cboCategory.EnterMoveNextControl = true;
		this.cboCategory.Location = new System.Drawing.Point(81, 30);
		this.cboCategory.Name = "cboCategory";
		this.cboCategory.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboCategory.Properties.Appearance.Options.UseFont = true;
		this.cboCategory.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboCategory.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboCategory.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboCategory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboCategory.Size = new System.Drawing.Size(355, 24);
		this.cboCategory.StyleController = this.layoutControl1;
		this.cboCategory.TabIndex = 0;
		this.cboCategory.QueryPopUp += new System.ComponentModel.CancelEventHandler(cboCategory_QueryPopUp);
		this.cboCategory.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboCategory_Closed);
		this.cboUnits.EditValue = "-----";
		this.cboUnits.EnterMoveNextControl = true;
		this.cboUnits.Location = new System.Drawing.Point(298, 193);
		this.cboUnits.Name = "cboUnits";
		this.cboUnits.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboUnits.Properties.Appearance.Options.UseFont = true;
		this.cboUnits.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboUnits.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboUnits.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboUnits.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboUnits.Properties.Items.AddRange(new object[13]
		{
			"-----", "Acre(s)", "Bag(s)", "Bottle(s)", "Box(es)", "Decimals", "Hactre(s)", "Kg", "Litre(s)", "Meter(s)",
			"Pc(s)", "Sack(s)", "Tin(s)"
		});
		this.cboUnits.Properties.Sorted = true;
		this.cboUnits.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboUnits.Size = new System.Drawing.Size(138, 24);
		this.cboUnits.StyleController = this.layoutControl1;
		this.cboUnits.TabIndex = 6;
		this.chkIsDepreciable.EditValue = null;
		this.chkIsDepreciable.EnterMoveNextControl = true;
		this.chkIsDepreciable.Location = new System.Drawing.Point(293, 58);
		this.chkIsDepreciable.Name = "chkIsDepreciable";
		this.chkIsDepreciable.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.chkIsDepreciable.Properties.Appearance.Options.UseFont = true;
		this.chkIsDepreciable.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
		this.chkIsDepreciable.Properties.Caption = "Item is depreciatable";
		this.chkIsDepreciable.Size = new System.Drawing.Size(143, 20);
		this.chkIsDepreciable.StyleController = this.layoutControl1;
		this.chkIsDepreciable.TabIndex = 3;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[13]
		{
			this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem11, this.layoutControlItem13, this.layoutControlItem14, this.emptySpaceItem1, this.layoutControlItem15, this.layoutControlItem9,
			this.layoutControlItem6, this.layoutControlItem5, this.layoutControlItem12
		});
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(438, 355);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.cboCategory;
		this.layoutControlItem1.CustomizationFormText = "Category:";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem1.Size = new System.Drawing.Size(438, 28);
		this.layoutControlItem1.Text = "Category:";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 16);
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.txtItem;
		this.layoutControlItem2.CustomizationFormText = "Item:";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 56);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem2.Size = new System.Drawing.Size(291, 28);
		this.layoutControlItem2.Text = "Item:";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 16);
		this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem3.Control = this.txtDescription;
		this.layoutControlItem3.CustomizationFormText = "Description:";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 84);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(438, 107);
		this.layoutControlItem3.Text = "Description:";
		this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem3.TextSize = new System.Drawing.Size(72, 16);
		this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem4.Control = this.txtQty;
		this.layoutControlItem4.CustomizationFormText = "Qty:";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 191);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem4.Size = new System.Drawing.Size(220, 28);
		this.layoutControlItem4.Text = "Qty:";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 16);
		this.layoutControlItem11.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem11.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem11.Control = this.txtAssetValue;
		this.layoutControlItem11.CustomizationFormText = "Asset Value:";
		this.layoutControlItem11.Location = new System.Drawing.Point(0, 247);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem11.Size = new System.Drawing.Size(438, 28);
		this.layoutControlItem11.Text = "Asset Value:";
		this.layoutControlItem11.TextSize = new System.Drawing.Size(72, 16);
		this.layoutControlItem13.Control = this.simpleButton1;
		this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
		this.layoutControlItem13.Location = new System.Drawing.Point(0, 329);
		this.layoutControlItem13.Name = "layoutControlItem13";
		this.layoutControlItem13.Size = new System.Drawing.Size(220, 26);
		this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem13.TextVisible = false;
		this.layoutControlItem14.Control = this.simpleButton2;
		this.layoutControlItem14.CustomizationFormText = "layoutControlItem14";
		this.layoutControlItem14.Location = new System.Drawing.Point(220, 329);
		this.layoutControlItem14.Name = "layoutControlItem14";
		this.layoutControlItem14.Size = new System.Drawing.Size(218, 26);
		this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem14.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 275);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(438, 37);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem15.Control = this.labelControl1;
		this.layoutControlItem15.CustomizationFormText = "layoutControlItem15";
		this.layoutControlItem15.Location = new System.Drawing.Point(0, 312);
		this.layoutControlItem15.Name = "layoutControlItem15";
		this.layoutControlItem15.Size = new System.Drawing.Size(438, 17);
		this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem15.TextVisible = false;
		this.layoutControlItem9.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem9.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem9.Control = this.txtUnitCost;
		this.layoutControlItem9.CustomizationFormText = "Unit Cost:";
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 219);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem9.Size = new System.Drawing.Size(438, 28);
		this.layoutControlItem9.Text = "Selling Price";
		this.layoutControlItem9.TextSize = new System.Drawing.Size(72, 16);
		this.layoutControlItem6.Control = this.chkIsDepreciable;
		this.layoutControlItem6.CustomizationFormText = "IsDepreciable:";
		this.layoutControlItem6.Location = new System.Drawing.Point(291, 56);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(147, 28);
		this.layoutControlItem6.Text = "IsDepreciable:";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = true;
		this.layoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.layoutControlItem5.Control = this.cboUnits;
		this.layoutControlItem5.CustomizationFormText = "Units:";
		this.layoutControlItem5.Location = new System.Drawing.Point(220, 191);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(218, 28);
		this.layoutControlItem5.Text = "Units:";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(72, 13);
		this.layoutControlItem12.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem12.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem12.Control = this.cboItemType;
		this.layoutControlItem12.CustomizationFormText = "Item Type:";
		this.layoutControlItem12.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem12.Name = "layoutControlItem12";
		this.layoutControlItem12.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem12.Size = new System.Drawing.Size(438, 28);
		this.layoutControlItem12.Text = "Item Type:";
		this.layoutControlItem12.TextSize = new System.Drawing.Size(72, 16);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(438, 355);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.Name = "AddStockItem";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Add New Stock Item";
		base.Load += new System.EventHandler(AddStockItem_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(AddStockItem_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.cboItemType.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAssetValue.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtUnitCost.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtQty.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDescription.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboCategory.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboUnits.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkIsDepreciable.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).EndInit();
		base.ResumeLayout(false);
	}
}
