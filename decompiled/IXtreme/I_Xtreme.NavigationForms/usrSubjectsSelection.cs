using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrSubjectsSelection : XtraUserControl
{
	private DataTable dt_PWD;

	private DataSet staffDataSet;

	private DataTable staffDataTable;

	private DataSet ds_PWD;

	private IContainer components = null;

	private LayoutControl layoutControl30;

	private SimpleButton simpleButton19;

	private SimpleButton simpleButton18;

	private CheckedListBoxControl chkListSubjects;

	private PictureEdit pictureEdit16;

	private GridControl gridControl14;

	private GridView gridView21;

	private ComboBoxEdit cboClass;

	private LayoutControlGroup layoutSubjectSelection;

	private LayoutControlItem layoutControlItem263;

	private LayoutControlGroup layoutControlGroup63;

	private LayoutControlItem layoutControlItem268;

	private LayoutControlItem layoutControlItem269;

	private EmptySpaceItem emptySpaceItem2;

	private LayoutControlItem layoutControlItem28;

	private EmptySpaceItem emptySpaceItem7;

	private EmptySpaceItem emptySpaceItem8;

	private LayoutControlItem layoutControlItem39;

	private LayoutControlItem layoutControlItem46;

	private GridLookUpEdit gridLookUpEdit1;

	private GridView gridLookUpEdit1View;

	private LayoutControlItem layoutControlItem1;

	private GridColumn gridColumnPic;

	private GridColumn gridColumnName;

	private GridColumn gridColumnContact;

	private GridColumn gridColumnEmail;

	private GridColumn gridColumnID;

	private RepositoryItemPictureEdit repositoryItemPictureEdit1;

	private TextEdit txtStaffId;

	private LayoutControlItem layoutControlItem2;

	private TextEdit txtName;

	private LayoutControlItem layoutControlItem3;

	private System.Windows.Forms.Timer timer1;

	public usrSubjectsSelection()
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Loading Teacher Logins...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.LoadTeacherLogins, 0);
		Thread.Sleep(25);
		InitializeComponent();
		LoadDefaultClasses();
		Classes.LoadComboWithClasses(new ComboBoxEdit[1] { cboClass });
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	public void LoginCallBackFN(bool timerStatus)
	{
		timer1.Enabled = timerStatus;
	}

	private void LoadDefaultClasses()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from OLevelSubjects", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "OLevelSubjects");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			chkListSubjects.Items.Clear();
			foreach (DataRow row in dataTable.Rows)
			{
				chkListSubjects.Items.Add(row["SubjectId"]);
			}
			layoutControlItem28.Text = "Subjects for " + cboClass.SelectedItem.ToString();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadSubjectsForTeachers()
	{
		try
		{
			if (cboClass.SelectedItem.ToString() == "S.1" || cboClass.SelectedItem.ToString() == "S.2" || cboClass.SelectedItem.ToString() == "S.3" || cboClass.SelectedItem.ToString() == "S.4")
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from OLevelSubjects", DataConnection.ConnectToDatabase());
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "OLevelSubjects");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				chkListSubjects.Items.Clear();
				foreach (DataRow row in dataTable.Rows)
				{
					chkListSubjects.Items.Add(row["SubjectId"]);
				}
				layoutControlItem28.Text = "Subjects for " + cboClass.SelectedItem.ToString();
			}
			else
			{
				if (!(cboClass.SelectedItem.ToString() == "S.5") && !(cboClass.SelectedItem.ToString() == "S.6"))
				{
					return;
				}
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("Select * from ALevelSubjects_Categorised", DataConnection.ConnectToDatabase());
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "OLevelSubjects");
				DataTable dataTable2 = new DataTable();
				dataTable2 = dataSet2.Tables[0];
				chkListSubjects.Items.Clear();
				foreach (DataRow row2 in dataTable2.Rows)
				{
					chkListSubjects.Items.Add(row2["PaperId"]);
				}
				layoutControlItem28.Text = "Subjects for " + cboClass.SelectedItem.ToString();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void DeleteSubjectLogin()
	{
		try
		{
			if (gridView21.FocusedRowHandle > -1)
			{
				DialogResult dialogResult = XtraMessageBox.Show("Are you sure you want to delete this User Account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogResult != DialogResult.Yes)
				{
					return;
				}
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "DELETE FROM tbl_subjectLogin WHERE id=@id",
					CommandType = CommandType.Text
				};
				DataRow dataRow = dt_PWD.Rows[gridView21.GetFocusedDataSourceRowIndex()];
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@id", SqlDbType.Int);
				sqlParameter.Value = dataRow["id"];
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
				XtraMessageBox.Show(string.Format("Successfully deleted the User Account for: {0}", dataRow["Name"]), "Success");
				LoadSubjectLogins();
				return;
			}
			XtraMessageBox.Show("Please select a User Account you want to delete from the list", "School Management Dynamics");
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadSubjectLogins()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT l.id,s.StaffName AS Name,l.staffId,l.ClassId AS Class,l.SubjectId AS Subject from tbl_subjectLogin l INNER JOIN Staff s ON l.staffId = s.StaffId", selectConnection);
			ds_PWD = new DataSet();
			sqlDataAdapter.Fill(ds_PWD, "SubjectLogins");
			dt_PWD = new DataTable();
			dt_PWD = ds_PWD.Tables[0];
			gridControl14.DataSource = dt_PWD.DefaultView;
			gridView21.Columns["id"].Visible = false;
			gridView21.Columns["staffId"].Visible = false;
			gridView21.Columns["Name"].GroupIndex = 0;
			gridView21.Columns["Class"].GroupIndex = 1;
			PrintableControl.SavePrintableControl(gridControl14);
			PrintableControl.SavePrintableControl(gridView21);
			timer1.Enabled = false;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void AddSubjectLogin()
	{
		try
		{
			foreach (CheckedListBoxItem item in (IEnumerable)chkListSubjects.CheckedItems)
			{
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"SELECT * FROM tbl_subjectLogin WHERE staffId='{txtStaffId.Text}' AND SubjectId='{item.ToString()}' AND ClassId='{cboClass.SelectedItem}'",
					CommandType = CommandType.Text
				};
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					continue;
				}
				using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "INSERT INTO tbl_subjectLogin(StaffId,StaffName,SubjectId,ClassId,Password,Password2)VALUES(@StaffId,@StaffName,@SubjectId,@ClassId,@Password,@Password2)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@StaffId", SqlDbType.VarChar, 50);
					sqlParameter.Value = txtStaffId.Text.Trim();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@StaffName", SqlDbType.VarChar, 50);
					sqlParameter.Value = txtName.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
					sqlParameter.Value = item.ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@ClassId", SqlDbType.VarChar, 50);
					sqlParameter.Value = cboClass.SelectedItem.ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@Password", SqlDbType.VarChar, 80);
					sqlParameter.Value = " ";
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@Password2", SqlDbType.VarChar, 50);
					sqlParameter.Value = " ";
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
				LoadSubjectLogins();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadSubjectTeachers()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select StaffName AS Name,StaffId,ContactNumber,Pic,Email from Staff Where WorkingStatus='Teaching Staff'", selectConnection);
			staffDataSet = new DataSet();
			sqlDataAdapter.Fill(staffDataSet, "StaffMembers");
			staffDataTable = new DataTable();
			staffDataTable = staffDataSet.Tables[0];
			gridLookUpEdit1.Properties.DataSource = staffDataSet.Tables[0];
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
		LoadSubjectLogins();
	}

	private void usrSubjectsSelection_Load(object sender, EventArgs e)
	{
		LoadSubjectLogins();
	}

	private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
	{
		LoadSubjectTeachers();
		gridLookUpEdit1.Properties.PopupFormSize = new Size(base.Width, 300);
	}

	private void gridLookUpEdit1_Closed(object sender, ClosedEventArgs e)
	{
		try
		{
			if (gridLookUpEdit1View.GetFocusedDataSourceRowIndex() > -1)
			{
				DataRow dataRow = staffDataTable.Rows[gridLookUpEdit1View.GetFocusedDataSourceRowIndex()];
				byte[] array = new byte[0];
				array = (byte[])dataRow["Pic"];
				using (MemoryStream stream = new MemoryStream(array))
				{
					pictureEdit16.Image = Image.FromStream(stream);
				}
				txtName.Text = dataRow["Name"].ToString();
				txtStaffId.Text = dataRow["StaffId"].ToString();
			}
			else
			{
				pictureEdit16.Image = null;
				txtName.Text = string.Empty;
				txtStaffId.Text = string.Empty;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void cboClass_Closed(object sender, ClosedEventArgs e)
	{
		LoadSubjectsForTeachers();
	}

	private void simpleButton18_Click(object sender, EventArgs e)
	{
		AddSubjectLogin();
	}

	private void simpleButton19_Click(object sender, EventArgs e)
	{
		DeleteSubjectLogin();
	}

	private void gridView21_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		LoadSubjectLogins();
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
		this.layoutControl30 = new DevExpress.XtraLayout.LayoutControl();
		this.txtName = new DevExpress.XtraEditors.TextEdit();
		this.txtStaffId = new DevExpress.XtraEditors.TextEdit();
		this.gridLookUpEdit1 = new DevExpress.XtraEditors.GridLookUpEdit();
		this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
		this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumnPic = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumnContact = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumnEmail = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
		this.simpleButton19 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton18 = new DevExpress.XtraEditors.SimpleButton();
		this.chkListSubjects = new DevExpress.XtraEditors.CheckedListBoxControl();
		this.pictureEdit16 = new DevExpress.XtraEditors.PictureEdit();
		this.gridControl14 = new DevExpress.XtraGrid.GridControl();
		this.gridView21 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.cboClass = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutSubjectSelection = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem263 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup63 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem268 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem269 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem46 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl30).BeginInit();
		this.layoutControl30.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStaffId.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridLookUpEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemPictureEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridLookUpEdit1View).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkListSubjects).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit16.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView21).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutSubjectSelection).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem263).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup63).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem268).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem269).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem28).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem39).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem46).BeginInit();
		base.SuspendLayout();
		this.layoutControl30.Controls.Add(this.txtName);
		this.layoutControl30.Controls.Add(this.txtStaffId);
		this.layoutControl30.Controls.Add(this.gridLookUpEdit1);
		this.layoutControl30.Controls.Add(this.simpleButton19);
		this.layoutControl30.Controls.Add(this.simpleButton18);
		this.layoutControl30.Controls.Add(this.chkListSubjects);
		this.layoutControl30.Controls.Add(this.pictureEdit16);
		this.layoutControl30.Controls.Add(this.gridControl14);
		this.layoutControl30.Controls.Add(this.cboClass);
		this.layoutControl30.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl30.Location = new System.Drawing.Point(0, 0);
		this.layoutControl30.Name = "layoutControl30";
		this.layoutControl30.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(23, 51, 502, 560);
		this.layoutControl30.Root = this.layoutSubjectSelection;
		this.layoutControl30.Size = new System.Drawing.Size(722, 459);
		this.layoutControl30.TabIndex = 1;
		this.layoutControl30.Text = "layoutControl30";
		this.txtName.Location = new System.Drawing.Point(4, 28);
		this.txtName.Name = "txtName";
		this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtName.Properties.Appearance.Options.UseFont = true;
		this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtName.Properties.ReadOnly = true;
		this.txtName.Size = new System.Drawing.Size(168, 24);
		this.txtName.StyleController = this.layoutControl30;
		this.txtName.TabIndex = 25;
		this.txtStaffId.Location = new System.Drawing.Point(4, 56);
		this.txtStaffId.Name = "txtStaffId";
		this.txtStaffId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtStaffId.Properties.Appearance.Options.UseFont = true;
		this.txtStaffId.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtStaffId.Properties.ReadOnly = true;
		this.txtStaffId.Size = new System.Drawing.Size(168, 24);
		this.txtStaffId.StyleController = this.layoutControl30;
		this.txtStaffId.TabIndex = 24;
		this.gridLookUpEdit1.EditValue = "";
		this.gridLookUpEdit1.Location = new System.Drawing.Point(4, 4);
		this.gridLookUpEdit1.Name = "gridLookUpEdit1";
		this.gridLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.gridLookUpEdit1.Properties.NullText = "[Select Teacher]";
		this.gridLookUpEdit1.Properties.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemPictureEdit1 });
		this.gridLookUpEdit1.Properties.View = this.gridLookUpEdit1View;
		this.gridLookUpEdit1.Size = new System.Drawing.Size(168, 20);
		this.gridLookUpEdit1.StyleController = this.layoutControl30;
		this.gridLookUpEdit1.TabIndex = 23;
		this.gridLookUpEdit1.QueryPopUp += new System.ComponentModel.CancelEventHandler(gridLookUpEdit1_QueryPopUp);
		this.gridLookUpEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(gridLookUpEdit1_Closed);
		this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
		this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.gridLookUpEdit1View.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[5] { this.gridColumnPic, this.gridColumnName, this.gridColumnContact, this.gridColumnEmail, this.gridColumnID });
		this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
		this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
		this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridLookUpEdit1View.OptionsView.EnableAppearanceEvenRow = true;
		this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
		this.gridLookUpEdit1View.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridLookUpEdit1View.OptionsView.ShowIndicator = false;
		this.gridLookUpEdit1View.RowHeight = 50;
		this.gridColumnPic.Caption = "Picture";
		this.gridColumnPic.ColumnEdit = this.repositoryItemPictureEdit1;
		this.gridColumnPic.FieldName = "Pic";
		this.gridColumnPic.Name = "gridColumnPic";
		this.gridColumnPic.Visible = true;
		this.gridColumnPic.VisibleIndex = 1;
		this.gridColumnPic.Width = 65;
		this.gridColumnName.Caption = "Name";
		this.gridColumnName.FieldName = "Name";
		this.gridColumnName.Name = "gridColumnName";
		this.gridColumnName.Visible = true;
		this.gridColumnName.VisibleIndex = 2;
		this.gridColumnName.Width = 449;
		this.gridColumnContact.Caption = "Contact";
		this.gridColumnContact.FieldName = "ContactNumber";
		this.gridColumnContact.Name = "gridColumnContact";
		this.gridColumnContact.Visible = true;
		this.gridColumnContact.VisibleIndex = 3;
		this.gridColumnContact.Width = 250;
		this.gridColumnEmail.Caption = "Email";
		this.gridColumnEmail.FieldName = "Email";
		this.gridColumnEmail.Name = "gridColumnEmail";
		this.gridColumnEmail.Visible = true;
		this.gridColumnEmail.VisibleIndex = 4;
		this.gridColumnEmail.Width = 266;
		this.gridColumnID.Caption = "ID#";
		this.gridColumnID.FieldName = "StaffId";
		this.gridColumnID.Name = "gridColumnID";
		this.gridColumnID.Visible = true;
		this.gridColumnID.VisibleIndex = 0;
		this.gridColumnID.Width = 64;
		this.simpleButton19.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.simpleButton19.Location = new System.Drawing.Point(281, 231);
		this.simpleButton19.Name = "simpleButton19";
		this.simpleButton19.Size = new System.Drawing.Size(27, 22);
		this.simpleButton19.StyleController = this.layoutControl30;
		this.simpleButton19.TabIndex = 21;
		this.simpleButton19.Text = "<<";
		this.simpleButton19.Click += new System.EventHandler(simpleButton19_Click);
		this.simpleButton18.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.simpleButton18.Location = new System.Drawing.Point(281, 205);
		this.simpleButton18.Name = "simpleButton18";
		this.simpleButton18.Size = new System.Drawing.Size(27, 22);
		this.simpleButton18.StyleController = this.layoutControl30;
		this.simpleButton18.TabIndex = 20;
		this.simpleButton18.Text = ">>";
		this.simpleButton18.Click += new System.EventHandler(simpleButton18_Click);
		this.chkListSubjects.HotTrackItems = true;
		this.chkListSubjects.Location = new System.Drawing.Point(176, 4);
		this.chkListSubjects.Name = "chkListSubjects";
		this.chkListSubjects.Size = new System.Drawing.Size(101, 451);
		this.chkListSubjects.StyleController = this.layoutControl30;
		this.chkListSubjects.TabIndex = 22;
		this.pictureEdit16.Location = new System.Drawing.Point(4, 84);
		this.pictureEdit16.Name = "pictureEdit16";
		this.pictureEdit16.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.pictureEdit16.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit16.Size = new System.Drawing.Size(168, 266);
		this.pictureEdit16.StyleController = this.layoutControl30;
		this.pictureEdit16.TabIndex = 16;
		this.gridControl14.Location = new System.Drawing.Point(312, 4);
		this.gridControl14.MainView = this.gridView21;
		this.gridControl14.Name = "gridControl14";
		this.gridControl14.Size = new System.Drawing.Size(406, 451);
		this.gridControl14.TabIndex = 16;
		this.gridControl14.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView21 });
		this.gridView21.GridControl = this.gridControl14;
		this.gridView21.Name = "gridView21";
		this.gridView21.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView21.OptionsBehavior.Editable = false;
		this.gridView21.OptionsFind.AlwaysVisible = true;
		this.gridView21.OptionsView.ShowGroupPanel = false;
		this.gridView21.OptionsView.ShowIndicator = false;
		this.gridView21.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView21_FocusedRowChanged);
		this.cboClass.EditValue = "S.1";
		this.cboClass.Location = new System.Drawing.Point(4, 354);
		this.cboClass.Name = "cboClass";
		this.cboClass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClass.Size = new System.Drawing.Size(168, 22);
		this.cboClass.StyleController = this.layoutControl30;
		this.cboClass.TabIndex = 1;
		this.cboClass.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboClass_Closed);
		this.layoutSubjectSelection.CustomizationFormText = "layoutControlGroup62";
		this.layoutSubjectSelection.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutSubjectSelection.GroupBordersVisible = false;
		this.layoutSubjectSelection.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[7] { this.layoutControlItem263, this.layoutControlGroup63, this.layoutControlItem28, this.emptySpaceItem7, this.emptySpaceItem8, this.layoutControlItem39, this.layoutControlItem46 });
		this.layoutSubjectSelection.Location = new System.Drawing.Point(0, 0);
		this.layoutSubjectSelection.Name = "layoutSubjectSelection";
		this.layoutSubjectSelection.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutSubjectSelection.Size = new System.Drawing.Size(722, 459);
		this.layoutSubjectSelection.Text = "layoutSubjectSelection";
		this.layoutSubjectSelection.TextVisible = false;
		this.layoutControlItem263.Control = this.gridControl14;
		this.layoutControlItem263.CustomizationFormText = "layoutControlItem263";
		this.layoutControlItem263.Location = new System.Drawing.Point(308, 0);
		this.layoutControlItem263.Name = "layoutControlItem263";
		this.layoutControlItem263.Size = new System.Drawing.Size(410, 455);
		this.layoutControlItem263.Text = "Login Information";
		this.layoutControlItem263.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem263.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem263.TextToControlDistance = 0;
		this.layoutControlItem263.TextVisible = false;
		this.layoutControlGroup63.CustomizationFormText = "layoutControlGroup63";
		this.layoutControlGroup63.GroupBordersVisible = false;
		this.layoutControlGroup63.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[6] { this.layoutControlItem268, this.layoutControlItem269, this.emptySpaceItem2, this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3 });
		this.layoutControlGroup63.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup63.Name = "layoutControlGroup63";
		this.layoutControlGroup63.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup63.Size = new System.Drawing.Size(172, 455);
		this.layoutControlGroup63.Text = "Login Parameters";
		this.layoutControlItem268.Control = this.pictureEdit16;
		this.layoutControlItem268.CustomizationFormText = "layoutControlItem268";
		this.layoutControlItem268.Location = new System.Drawing.Point(0, 80);
		this.layoutControlItem268.Name = "layoutControlItem268";
		this.layoutControlItem268.Size = new System.Drawing.Size(172, 270);
		this.layoutControlItem268.Text = "layoutControlItem268";
		this.layoutControlItem268.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem268.TextToControlDistance = 0;
		this.layoutControlItem268.TextVisible = false;
		this.layoutControlItem269.Control = this.cboClass;
		this.layoutControlItem269.CustomizationFormText = "layoutControlItem269";
		this.layoutControlItem269.Location = new System.Drawing.Point(0, 350);
		this.layoutControlItem269.Name = "layoutControlItem269";
		this.layoutControlItem269.Size = new System.Drawing.Size(172, 26);
		this.layoutControlItem269.Text = "layoutControlItem269";
		this.layoutControlItem269.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem269.TextToControlDistance = 0;
		this.layoutControlItem269.TextVisible = false;
		this.emptySpaceItem2.AllowHotTrack = false;
		this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
		this.emptySpaceItem2.Location = new System.Drawing.Point(0, 376);
		this.emptySpaceItem2.Name = "emptySpaceItem2";
		this.emptySpaceItem2.Size = new System.Drawing.Size(172, 79);
		this.emptySpaceItem2.Text = "emptySpaceItem2";
		this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.Control = this.gridLookUpEdit1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(172, 24);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.txtStaffId;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 52);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(172, 28);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.txtName;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(172, 28);
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem28.Control = this.chkListSubjects;
		this.layoutControlItem28.CustomizationFormText = "layoutControlItem28";
		this.layoutControlItem28.Location = new System.Drawing.Point(172, 0);
		this.layoutControlItem28.Name = "layoutControlItem28";
		this.layoutControlItem28.Size = new System.Drawing.Size(105, 455);
		this.layoutControlItem28.Text = "Subject for S.1";
		this.layoutControlItem28.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem28.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem28.TextToControlDistance = 0;
		this.layoutControlItem28.TextVisible = false;
		this.emptySpaceItem7.AllowHotTrack = false;
		this.emptySpaceItem7.CustomizationFormText = "emptySpaceItem7";
		this.emptySpaceItem7.Location = new System.Drawing.Point(277, 0);
		this.emptySpaceItem7.Name = "emptySpaceItem7";
		this.emptySpaceItem7.Size = new System.Drawing.Size(31, 201);
		this.emptySpaceItem7.Text = "emptySpaceItem7";
		this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
		this.emptySpaceItem8.AllowHotTrack = false;
		this.emptySpaceItem8.CustomizationFormText = "emptySpaceItem8";
		this.emptySpaceItem8.Location = new System.Drawing.Point(277, 253);
		this.emptySpaceItem8.Name = "emptySpaceItem8";
		this.emptySpaceItem8.Size = new System.Drawing.Size(31, 202);
		this.emptySpaceItem8.Text = "emptySpaceItem8";
		this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem39.Control = this.simpleButton18;
		this.layoutControlItem39.CustomizationFormText = "layoutControlItem39";
		this.layoutControlItem39.Location = new System.Drawing.Point(277, 201);
		this.layoutControlItem39.Name = "layoutControlItem39";
		this.layoutControlItem39.Size = new System.Drawing.Size(31, 26);
		this.layoutControlItem39.Text = "layoutControlItem39";
		this.layoutControlItem39.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem39.TextToControlDistance = 0;
		this.layoutControlItem39.TextVisible = false;
		this.layoutControlItem46.Control = this.simpleButton19;
		this.layoutControlItem46.CustomizationFormText = "layoutControlItem46";
		this.layoutControlItem46.Location = new System.Drawing.Point(277, 227);
		this.layoutControlItem46.Name = "layoutControlItem46";
		this.layoutControlItem46.Size = new System.Drawing.Size(31, 26);
		this.layoutControlItem46.Text = "layoutControlItem46";
		this.layoutControlItem46.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem46.TextToControlDistance = 0;
		this.layoutControlItem46.TextVisible = false;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl30);
		base.Name = "usrSubjectsSelection";
		base.Size = new System.Drawing.Size(722, 459);
		base.Load += new System.EventHandler(usrSubjectsSelection_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl30).EndInit();
		this.layoutControl30.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStaffId.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridLookUpEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemPictureEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridLookUpEdit1View).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkListSubjects).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit16.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView21).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutSubjectSelection).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem263).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup63).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem268).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem269).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem28).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem39).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem46).EndInit();
		base.ResumeLayout(false);
	}
}
