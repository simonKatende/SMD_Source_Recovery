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
using LibraryManagement.DialogForms;

namespace LibraryManagement;

public class AddBooks : XtraForm
{
	private DataTable dtCat;

	private DataTable dtLoc;

	public StartOrStopTimer StartTimer;

	private IContainer components = null;

	private TextEdit txtBookRef;

	private ComboBoxEdit cboBookLocation;

	private TextEdit txtBYOP;

	private TextEdit txtBValue;

	private TextEdit txtBTitle;

	private ComboBoxEdit cboBookCategory;

	private MemoEdit txtBookDetails;

	private SimpleButton simpleButton1;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem9;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem10;

	private SimpleButton simpleButton2;

	private LayoutControlItem layoutControlItem11;

	private TextEdit txtBPublisher;

	private TextEdit txtBAuthor;

	private TextEdit txtBookId;

	private LayoutControlItem layoutControlItem13;

	private TextEdit txtLocalCode;

	private LayoutControlItem layoutControlItem14;

	public AddBooks()
	{
		InitializeComponent();
		LoadLibraryDefaults();
	}

	private void LoadBookCategories()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_BookCategories", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "BookCategories");
			dtCat = new DataTable();
			dtCat = dataSet.Tables[0];
			cboBookCategory.Properties.Items.Clear();
			cboBookCategory.Properties.Items.AddRange(new object[2] { "-Select Category-", "-Add New-" });
			foreach (DataRow row in dtCat.Rows)
			{
				cboBookCategory.Properties.Items.Add(row["Category"]);
			}
			cboBookCategory.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadBookLocation()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_BookLocations", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "BookLocation");
			dtLoc = new DataTable();
			dtLoc = dataSet.Tables[0];
			cboBookLocation.Properties.Items.Clear();
			cboBookLocation.Properties.Items.AddRange(new object[2] { "-Select Location-", "-Add New-" });
			foreach (DataRow row in dtLoc.Rows)
			{
				cboBookLocation.Properties.Items.Add(row["Location"]);
			}
			cboBookLocation.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadLibraryDefaults()
	{
		LoadBookCategories();
		LoadBookLocation();
	}

	private void UpdateBooks()
	{
		double result = (double.TryParse(txtBValue.Text, out result) ? result : 0.0);
		DataRow dataRow = dtCat.Rows[cboBookCategory.SelectedIndex - 2];
		DataRow dataRow2 = dtLoc.Rows[cboBookLocation.SelectedIndex - 2];
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "UPDATE tbl_Books SET CatID=@CatID,Title=@Title,Ref=@Ref,Author=@Author,YearOfPublication=@YearOfPublication,Publisher=@Publisher,MonitaryValue=@MonitaryValue,LocID=@LocID,Details=@Details WHERE BookId=@BookId",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@BookId", SqlDbType.BigInt);
		sqlParameter.Value = txtBookId.Text;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@CatID", SqlDbType.BigInt);
		sqlParameter.Value = dataRow["CatId"];
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Title", SqlDbType.VarChar, 50);
		sqlParameter.Value = txtBTitle.Text.ToUpper();
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Ref", SqlDbType.VarChar, 50);
		sqlParameter.Value = txtBookRef.Text;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Author", SqlDbType.VarChar, 50);
		sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtBAuthor.Text);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@YearOfPublication", SqlDbType.Int);
		sqlParameter.Value = txtBYOP.Text;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Publisher", SqlDbType.VarChar, 50);
		sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtBPublisher.Text);
		sqlParameter.Direction = ParameterDirection.Input;
		double result2 = (double.TryParse(txtBValue.Text, out result2) ? result2 : 0.0);
		sqlParameter = sqlCommand.Parameters.Add("@MonitaryValue", SqlDbType.Money);
		sqlParameter.Value = result2;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@LocID", SqlDbType.BigInt);
		sqlParameter.Value = dataRow2["LocID"];
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Details", SqlDbType.VarChar, 100);
		sqlParameter.Value = txtBookDetails.Text;
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			Close();
			StartTimer(timerStatus: true);
		}
	}

	private void SaveBook()
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = $"SELECT Title,Ref FROM tbl_Books WHERE LocalCode='{txtLocalCode.Text.ToUpper()}'",
			CommandType = CommandType.Text
		};
		using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		if (sqlDataReader.HasRows)
		{
			sqlConnection.Close();
			XtraMessageBox.Show("The Local Code you have entered already exists. Please use another reference", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		sqlConnection.Close();
		DataRow dataRow = dtCat.Rows[cboBookCategory.SelectedIndex - 2];
		DataRow dataRow2 = dtLoc.Rows[cboBookLocation.SelectedIndex - 2];
		double result = (double.TryParse(txtBValue.Text, out result) ? result : 0.0);
		using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection2.Open();
		using SqlCommand sqlCommand2 = new SqlCommand
		{
			Connection = sqlConnection2,
			CommandText = "INSERT INTO tbl_Books (CatID,Title,Ref,Author,YearOfPublication,Publisher,MonitaryValue,LocID,Details,LocalCode) VALUES (@CatID,@Title,@Ref,@Author,@YearOfPublication,@Publisher,@MonitaryValue,@LocID,@Details,@LocalCode)",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@CatID", SqlDbType.BigInt);
		sqlParameter.Value = dataRow["CatId"];
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand2.Parameters.Add("@Title", SqlDbType.VarChar, 50);
		sqlParameter.Value = txtBTitle.Text.ToUpper();
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand2.Parameters.Add("@Ref", SqlDbType.VarChar, 50);
		sqlParameter.Value = txtBookRef.Text;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand2.Parameters.Add("@Author", SqlDbType.VarChar, 50);
		sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtBAuthor.Text);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand2.Parameters.Add("@YearOfPublication", SqlDbType.Int);
		sqlParameter.Value = txtBYOP.Text;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand2.Parameters.Add("@Publisher", SqlDbType.VarChar, 50);
		sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtBPublisher.Text);
		sqlParameter.Direction = ParameterDirection.Input;
		double result2 = (double.TryParse(txtBValue.Text, out result2) ? result2 : 0.0);
		sqlParameter = sqlCommand2.Parameters.Add("@MonitaryValue", SqlDbType.Money);
		sqlParameter.Value = result2;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand2.Parameters.Add("@LocID", SqlDbType.BigInt);
		sqlParameter.Value = dataRow2["LocID"];
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand2.Parameters.Add("@Details", SqlDbType.VarChar, 100);
		sqlParameter.Value = txtBookDetails.Text;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand2.Parameters.Add("@LocalCode", SqlDbType.VarChar, 9);
		sqlParameter.Value = txtLocalCode.Text.ToUpper();
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand2.ExecuteNonQuery() > 0)
		{
			sqlConnection2.Close();
			txtBTitle.Text = string.Empty;
			txtBYOP.Text = string.Empty;
			txtBPublisher.Text = string.Empty;
			txtBAuthor.Text = string.Empty;
			txtBookDetails.Text = string.Empty;
			txtBookRef.Text = string.Empty;
			txtBValue.Text = string.Empty;
			txtLocalCode.Text = string.Empty;
			StartTimer(timerStatus: true);
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (Text == "Add New Book")
		{
			SaveBook();
		}
		else
		{
			UpdateBooks();
		}
	}

	private void AddBooks_Load(object sender, EventArgs e)
	{
		if (Text == "Add New Book")
		{
			simpleButton2.Text = "Close";
			simpleButton1.Text = "Save";
		}
		else
		{
			simpleButton2.Text = "Cancel";
			simpleButton1.Text = "Update";
			LoadBooksForEditing();
		}
	}

	private void cboBookCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cboBookCategory.SelectedIndex != 1)
		{
			return;
		}
		using AddCategory addCategory = new AddCategory
		{
			Text = "Add Category",
			addMethod = "Instant"
		};
		if (addCategory.ShowDialog() == DialogResult.OK)
		{
			LoadBookCategories();
		}
	}

	private void cboBookLocation_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cboBookLocation.SelectedIndex != 1)
		{
			return;
		}
		using AddLocations addLocations = new AddLocations
		{
			Text = "Add Book Location",
			addMethod = "Instant"
		};
		if (addLocations.ShowDialog() == DialogResult.OK)
		{
			LoadBookLocation();
		}
	}

	private void LoadBooksForEditing()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_Books WHERE BookId=" + EditableFields.FieldID, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "EditableBook");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				txtBookId.Text = row["BookId"].ToString();
				txtBAuthor.Text = row["Author"].ToString();
				txtBookDetails.Text = row["Details"].ToString();
				txtBookRef.Text = row["Ref"].ToString();
				txtBPublisher.Text = row["Publisher"].ToString();
				txtBTitle.Text = row["Title"].ToString();
				txtBValue.Text = row["MonitaryValue"].ToString();
				txtBYOP.Text = row["YearOfPublication"].ToString();
				txtLocalCode.Text = row["LocalCode"].ToString();
				cboBookCategory.SelectedItem = LoadBookCategoryRef(Convert.ToInt64(row["CatID"].ToString()));
				cboBookLocation.SelectedItem = LoadBookLocationRef(Convert.ToInt64(row["LocID"].ToString()));
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private string LoadBookLocationRef(long locID)
	{
		string result = "";
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Location FROM tbl_BookLocations WHERE LocID=" + locID, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "BookLocation");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				result = row["Location"].ToString();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
		return result;
	}

	private string LoadBookCategoryRef(long catID)
	{
		string result = "";
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Category FROM tbl_BookCategories WHERE CatId=" + catID, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "BookCategories");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				result = row["Category"].ToString();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
		return result;
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
		this.txtBookRef = new DevExpress.XtraEditors.TextEdit();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.txtLocalCode = new DevExpress.XtraEditors.TextEdit();
		this.txtBookId = new DevExpress.XtraEditors.TextEdit();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtBookDetails = new DevExpress.XtraEditors.MemoEdit();
		this.txtBValue = new DevExpress.XtraEditors.TextEdit();
		this.cboBookLocation = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtBYOP = new DevExpress.XtraEditors.TextEdit();
		this.cboBookCategory = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtBTitle = new DevExpress.XtraEditors.TextEdit();
		this.txtBPublisher = new DevExpress.XtraEditors.TextEdit();
		this.txtBAuthor = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.txtBookRef.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtLocalCode.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtBookId.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtBookDetails.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtBValue.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboBookLocation.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtBYOP.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboBookCategory.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtBTitle.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtBPublisher.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtBAuthor.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).BeginInit();
		base.SuspendLayout();
		this.txtBookRef.EnterMoveNextControl = true;
		this.txtBookRef.Location = new System.Drawing.Point(330, 54);
		this.txtBookRef.Name = "txtBookRef";
		this.txtBookRef.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtBookRef.Size = new System.Drawing.Size(151, 22);
		this.txtBookRef.StyleController = this.layoutControl1;
		this.txtBookRef.TabIndex = 2;
		this.layoutControl1.Controls.Add(this.txtLocalCode);
		this.layoutControl1.Controls.Add(this.txtBookId);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.txtBookRef);
		this.layoutControl1.Controls.Add(this.txtBookDetails);
		this.layoutControl1.Controls.Add(this.txtBValue);
		this.layoutControl1.Controls.Add(this.cboBookLocation);
		this.layoutControl1.Controls.Add(this.txtBYOP);
		this.layoutControl1.Controls.Add(this.cboBookCategory);
		this.layoutControl1.Controls.Add(this.txtBTitle);
		this.layoutControl1.Controls.Add(this.txtBPublisher);
		this.layoutControl1.Controls.Add(this.txtBAuthor);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(485, 402);
		this.layoutControl1.TabIndex = 24;
		this.layoutControl1.Text = "layoutControl1";
		this.txtLocalCode.Location = new System.Drawing.Point(90, 54);
		this.txtLocalCode.Name = "txtLocalCode";
		this.txtLocalCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtLocalCode.Size = new System.Drawing.Size(150, 22);
		this.txtLocalCode.StyleController = this.layoutControl1;
		this.txtLocalCode.TabIndex = 1;
		this.txtBookId.Location = new System.Drawing.Point(4, 4);
		this.txtBookId.Name = "txtBookId";
		this.txtBookId.Properties.ReadOnly = true;
		this.txtBookId.Size = new System.Drawing.Size(477, 20);
		this.txtBookId.StyleController = this.layoutControl1;
		this.txtBookId.TabIndex = 12;
		this.simpleButton2.Location = new System.Drawing.Point(244, 376);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(237, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 11;
		this.simpleButton2.Text = "Close";
		this.simpleButton1.Location = new System.Drawing.Point(4, 376);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(236, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 10;
		this.simpleButton1.Text = "Save";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.txtBookDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.txtBookDetails.Location = new System.Drawing.Point(7, 252);
		this.txtBookDetails.Name = "txtBookDetails";
		this.txtBookDetails.Size = new System.Drawing.Size(474, 120);
		this.txtBookDetails.StyleController = this.layoutControl1;
		this.txtBookDetails.TabIndex = 9;
		this.txtBValue.EnterMoveNextControl = true;
		this.txtBValue.Location = new System.Drawing.Point(90, 210);
		this.txtBValue.Name = "txtBValue";
		this.txtBValue.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtBValue.Properties.Mask.EditMask = "n";
		this.txtBValue.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtBValue.Size = new System.Drawing.Size(391, 22);
		this.txtBValue.StyleController = this.layoutControl1;
		this.txtBValue.TabIndex = 8;
		this.cboBookLocation.EnterMoveNextControl = true;
		this.cboBookLocation.Location = new System.Drawing.Point(90, 184);
		this.cboBookLocation.Name = "cboBookLocation";
		this.cboBookLocation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboBookLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboBookLocation.Size = new System.Drawing.Size(391, 22);
		this.cboBookLocation.StyleController = this.layoutControl1;
		this.cboBookLocation.TabIndex = 7;
		this.cboBookLocation.SelectedIndexChanged += new System.EventHandler(cboBookLocation_SelectedIndexChanged);
		this.txtBYOP.EnterMoveNextControl = true;
		this.txtBYOP.Location = new System.Drawing.Point(90, 106);
		this.txtBYOP.Name = "txtBYOP";
		this.txtBYOP.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtBYOP.Properties.Mask.EditMask = "f0";
		this.txtBYOP.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtBYOP.Size = new System.Drawing.Size(391, 22);
		this.txtBYOP.StyleController = this.layoutControl1;
		this.txtBYOP.TabIndex = 4;
		this.cboBookCategory.EnterMoveNextControl = true;
		this.cboBookCategory.Location = new System.Drawing.Point(90, 28);
		this.cboBookCategory.Name = "cboBookCategory";
		this.cboBookCategory.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboBookCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboBookCategory.Size = new System.Drawing.Size(391, 22);
		this.cboBookCategory.StyleController = this.layoutControl1;
		this.cboBookCategory.TabIndex = 0;
		this.cboBookCategory.SelectedIndexChanged += new System.EventHandler(cboBookCategory_SelectedIndexChanged);
		this.txtBTitle.EnterMoveNextControl = true;
		this.txtBTitle.Location = new System.Drawing.Point(90, 80);
		this.txtBTitle.Name = "txtBTitle";
		this.txtBTitle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtBTitle.Size = new System.Drawing.Size(391, 22);
		this.txtBTitle.StyleController = this.layoutControl1;
		this.txtBTitle.TabIndex = 3;
		this.txtBPublisher.EnterMoveNextControl = true;
		this.txtBPublisher.Location = new System.Drawing.Point(90, 158);
		this.txtBPublisher.Name = "txtBPublisher";
		this.txtBPublisher.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtBPublisher.Size = new System.Drawing.Size(391, 22);
		this.txtBPublisher.StyleController = this.layoutControl1;
		this.txtBPublisher.TabIndex = 6;
		this.txtBAuthor.EnterMoveNextControl = true;
		this.txtBAuthor.Location = new System.Drawing.Point(90, 132);
		this.txtBAuthor.Name = "txtBAuthor";
		this.txtBAuthor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtBAuthor.Size = new System.Drawing.Size(391, 22);
		this.txtBAuthor.StyleController = this.layoutControl1;
		this.txtBAuthor.TabIndex = 5;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[13]
		{
			this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem7, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem10, this.layoutControlItem11,
			this.layoutControlItem13, this.layoutControlItem6, this.layoutControlItem14
		});
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(485, 402);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.cboBookCategory;
		this.layoutControlItem1.CustomizationFormText = "Category:";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem1.Size = new System.Drawing.Size(481, 26);
		this.layoutControlItem1.Text = "Category:";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(80, 13);
		this.layoutControlItem2.Control = this.txtBTitle;
		this.layoutControlItem2.CustomizationFormText = "Title:";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 76);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem2.Size = new System.Drawing.Size(481, 26);
		this.layoutControlItem2.Text = "Title:";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(80, 13);
		this.layoutControlItem3.Control = this.txtBYOP;
		this.layoutControlItem3.CustomizationFormText = "Publication Year:";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 102);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem3.Size = new System.Drawing.Size(481, 26);
		this.layoutControlItem3.Text = "Publication Year:";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(80, 13);
		this.layoutControlItem4.Control = this.txtBAuthor;
		this.layoutControlItem4.CustomizationFormText = "Author";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 128);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem4.Size = new System.Drawing.Size(481, 26);
		this.layoutControlItem4.Text = "Author";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(80, 13);
		this.layoutControlItem5.Control = this.txtBPublisher;
		this.layoutControlItem5.CustomizationFormText = "Publisher";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 154);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem5.Size = new System.Drawing.Size(481, 26);
		this.layoutControlItem5.Text = "Publisher";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(80, 13);
		this.layoutControlItem7.Control = this.cboBookLocation;
		this.layoutControlItem7.CustomizationFormText = "Location In Lib:";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 180);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem7.Size = new System.Drawing.Size(481, 26);
		this.layoutControlItem7.Text = "Location In Lib:";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(80, 13);
		this.layoutControlItem8.Control = this.txtBValue;
		this.layoutControlItem8.CustomizationFormText = "Monetary Value:";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 206);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem8.Size = new System.Drawing.Size(481, 26);
		this.layoutControlItem8.Text = "Monetary Value:";
		this.layoutControlItem8.TextSize = new System.Drawing.Size(80, 13);
		this.layoutControlItem9.Control = this.txtBookDetails;
		this.layoutControlItem9.CustomizationFormText = "Any Other Info.";
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 232);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem9.Size = new System.Drawing.Size(481, 140);
		this.layoutControlItem9.Text = "Any Other Info.";
		this.layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem9.TextSize = new System.Drawing.Size(80, 13);
		this.layoutControlItem10.Control = this.simpleButton1;
		this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
		this.layoutControlItem10.Location = new System.Drawing.Point(0, 372);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(240, 26);
		this.layoutControlItem10.Text = "layoutControlItem10";
		this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem10.TextToControlDistance = 0;
		this.layoutControlItem10.TextVisible = false;
		this.layoutControlItem11.Control = this.simpleButton2;
		this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem11.Location = new System.Drawing.Point(240, 372);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(241, 26);
		this.layoutControlItem11.Text = "layoutControlItem11";
		this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem11.TextToControlDistance = 0;
		this.layoutControlItem11.TextVisible = false;
		this.layoutControlItem13.Control = this.txtBookId;
		this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
		this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem13.Name = "layoutControlItem13";
		this.layoutControlItem13.Size = new System.Drawing.Size(481, 24);
		this.layoutControlItem13.Text = "layoutControlItem13";
		this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem13.TextToControlDistance = 0;
		this.layoutControlItem13.TextVisible = false;
		this.layoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutControlItem6.Control = this.txtBookRef;
		this.layoutControlItem6.CustomizationFormText = "ISBN:";
		this.layoutControlItem6.Location = new System.Drawing.Point(240, 50);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem6.Size = new System.Drawing.Size(241, 26);
		this.layoutControlItem6.Text = "ISBN:";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(80, 13);
		this.layoutControlItem14.Control = this.txtLocalCode;
		this.layoutControlItem14.CustomizationFormText = "Local Code:";
		this.layoutControlItem14.Location = new System.Drawing.Point(0, 50);
		this.layoutControlItem14.Name = "layoutControlItem14";
		this.layoutControlItem14.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem14.Size = new System.Drawing.Size(240, 26);
		this.layoutControlItem14.Text = "Local Code:";
		this.layoutControlItem14.TextSize = new System.Drawing.Size(80, 13);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(485, 402);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddBooks";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Add New Book";
		base.Load += new System.EventHandler(AddBooks_Load);
		((System.ComponentModel.ISupportInitialize)this.txtBookRef.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtLocalCode.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtBookId.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtBookDetails.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtBValue.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboBookLocation.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtBYOP.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboBookCategory.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtBTitle.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtBPublisher.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtBAuthor.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).EndInit();
		base.ResumeLayout(false);
	}
}
