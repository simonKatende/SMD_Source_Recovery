using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace LibraryManagement.DialogForms;

public class AddLocations : XtraForm
{
	private long locID = 0L;

	public string addMethod = "";

	public StartOrStopTimer StartTimer;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private TextEdit txtLocation;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private EmptySpaceItem emptySpaceItem1;

	public AddLocations()
	{
		InitializeComponent();
	}

	private void AddBookLocations()
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT * FROM tbl_BookLocations WHERE Location=@Location",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Location", SqlDbType.VarChar, 50);
			sqlParameter.Value = txtLocation.Text.ToUpper();
			sqlParameter.Direction = ParameterDirection.Input;
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (!sqlDataReader.HasRows)
			{
				sqlConnection.Close();
				using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection2.Open();
				using SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "INSERT INTO tbl_BookLocations (Location) VALUES (@Location)",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@Location", SqlDbType.VarChar, 50);
				sqlParameter2.Value = txtLocation.Text.ToUpper();
				sqlParameter2.Direction = ParameterDirection.Input;
				if (sqlCommand2.ExecuteNonQuery() > 0)
				{
					sqlConnection2.Close();
					if (addMethod == "Instant")
					{
						base.DialogResult = DialogResult.OK;
						Close();
					}
					else
					{
						StartTimer(timerStatus: true);
					}
				}
				return;
			}
			sqlConnection.Close();
			XtraMessageBox.Show("Sorry! You cannot to that,the location you are adding already exists.", "Duplicate Entry Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void UpdateLocation()
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "UPDATE tbl_BookLocations SET Location = @Location WHERE LocID=@LocID",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@LocID", SqlDbType.BigInt);
		sqlParameter.Value = locID;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Location", SqlDbType.VarChar, 50);
		sqlParameter.Value = txtLocation.Text.ToUpper();
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			sqlConnection.Close();
			Close();
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		if (Text.Contains("Add"))
		{
			AddBookLocations();
		}
		else if (Text.Contains("Edit"))
		{
			UpdateLocation();
		}
	}

	private void AddLocations_Load(object sender, EventArgs e)
	{
		if (Text.Contains("Add"))
		{
			simpleButton2.Text = "Add Location";
			simpleButton1.Text = "Close";
		}
		else if (Text.Contains("Edit"))
		{
			simpleButton2.Text = "Update Location";
			simpleButton1.Text = "Cancel";
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
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtLocation = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtLocation.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.txtLocation);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(284, 84);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.simpleButton2.Location = new System.Drawing.Point(4, 58);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(136, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 6;
		this.simpleButton2.Text = "Add Location";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.simpleButton1.Location = new System.Drawing.Point(144, 58);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(136, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 5;
		this.simpleButton1.Text = "Close";
		this.txtLocation.Location = new System.Drawing.Point(51, 4);
		this.txtLocation.Name = "txtLocation";
		this.txtLocation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtLocation.Size = new System.Drawing.Size(229, 22);
		this.txtLocation.StyleController = this.layoutControl1;
		this.txtLocation.TabIndex = 4;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[4] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.emptySpaceItem1 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(284, 84);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.txtLocation;
		this.layoutControlItem1.CustomizationFormText = "Category:";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(280, 26);
		this.layoutControlItem1.Text = "Location:";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(44, 13);
		this.layoutControlItem2.Control = this.simpleButton1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(140, 54);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(140, 26);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.simpleButton2;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 54);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(140, 26);
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 26);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(280, 28);
		this.emptySpaceItem1.Text = "emptySpaceItem1";
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(284, 84);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddLocations";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Add Book Location";
		base.Load += new System.EventHandler(AddLocations_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtLocation.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		base.ResumeLayout(false);
	}
}
