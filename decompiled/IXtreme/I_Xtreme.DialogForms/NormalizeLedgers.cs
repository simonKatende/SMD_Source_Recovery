using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace I_Xtreme.DialogForms;

public class NormalizeLedgers : XtraForm
{
	private int k = 0;

	private SqlTransaction trans;

	private string Mode = string.Empty;

	private int i = 0;

	private string _Class = string.Empty;

	private IContainer components = null;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private ComboBoxEdit comboBoxEdit1;

	private Timer timer1;

	private ProgressBarControl progressBarStudent;

	private MyGridControl myGridControl1;

	private MyGridView myGridView1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private Timer timer2;

	public NormalizeLedgers(string Mode, string _Class)
	{
		InitializeComponent();
		Classes.LoadComboWithClasses(new ComboBoxEdit[1] { comboBoxEdit1 });
		this.Mode = Mode;
		this._Class = _Class;
		if (Mode == "Cards")
		{
			Text = "Normalizing Ledgers. Please wait....";
			comboBoxEdit1.SelectedItem = _Class;
			simpleButton1.Enabled = false;
			simpleButton2.Enabled = false;
			comboBoxEdit1.ReadOnly = true;
		}
	}

	private void UpdateFeesBalance(string studentClass)
	{
		simpleButton1.Enabled = false;
		simpleButton2.Enabled = false;
		comboBoxEdit1.Properties.ReadOnly = true;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Stud WHERE ClassId='{studentClass}'", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "StudentSelectedClass");
		progressBarStudent.Properties.Maximum = dataSet.Tables[0].Rows.Count;
		this.i = 0;
		foreach (DataRow row in dataSet.Tables[0].Rows)
		{
			this.i++;
			myGridControl1.DataSource = null;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(string.Format("SELECT PaymentId,Debit, Credit,(Debit-Credit) AS Amount FROM FeesPayment WHERE StudentNumber='{0}' ORDER BY PaymentId", row["StudentNumber"]), DataConnection.ConnectToDatabase());
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "PaymentsList");
			myGridControl1.DataSource = dataSet2.Tables[0].DefaultView;
			for (int i = 0; i < myGridView1.RowCount; i++)
			{
				double result = (double.TryParse(myGridView1.GetRowCellValue(i, "Bal").ToString(), out result) ? result : 0.0);
				long num = Convert.ToInt64(myGridView1.GetRowCellValue(i, "PaymentId").ToString());
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				trans = sqlConnection.BeginTransaction();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandText = "UPDATE FeesPayment SET Balance=@Balance WHERE PaymentId=@PaymentId AND StudentNumber=@StudentNumber",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@PaymentId", SqlDbType.BigInt);
					sqlParameter.Value = num;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
					sqlParameter.Value = row["StudentNumber"];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Balance", SqlDbType.Money);
					sqlParameter.Value = result;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandText = string.Format("UPDATE tbl_Stud SET cashOnAccount={0} WHERE StudentNumber='{1}'", result, row["StudentNumber"]),
					CommandType = CommandType.Text
				})
				{
					sqlCommand2.ExecuteNonQuery();
				}
				trans.Commit();
				sqlConnection.Close();
			}
			Application.DoEvents();
			progressBarStudent.Position = this.i;
		}
		if (Mode == "Cards")
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
		XtraMessageBox.Show("Ledger Normalization Complete", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		simpleButton1.Enabled = true;
		simpleButton2.Enabled = true;
		comboBoxEdit1.Properties.ReadOnly = false;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (comboBoxEdit1.SelectedIndex > 0)
		{
			simpleButton1.Enabled = true;
			timer1.Enabled = false;
		}
		else
		{
			simpleButton1.Enabled = false;
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		UpdateFeesBalance(comboBoxEdit1.Text);
	}

	private void myGridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
	{
		GridView gridView = (GridView)sender;
		if (e.Column.FieldName == "Bal" && e.IsGetData)
		{
			decimal num = default(decimal);
			int rowHandle = gridView.GetRowHandle(e.ListSourceRowIndex);
			for (int i = -1; i <= rowHandle - 1; i++)
			{
				num += Convert.ToDecimal(gridView.GetRowCellValue(i + 1, "Amount"));
			}
			e.Value = num;
		}
	}

	private void comboBoxEdit1_QueryPopUp(object sender, CancelEventArgs e)
	{
		timer1.Enabled = true;
	}

	private void NormalizeLedgers_Load(object sender, EventArgs e)
	{
		if (Mode == "Cards")
		{
			timer2.Enabled = true;
		}
	}

	private void timer2_Tick(object sender, EventArgs e)
	{
		k++;
		if (k == 3)
		{
			k = 0;
			timer2.Enabled = false;
			UpdateFeesBalance(comboBoxEdit1.Text);
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
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.progressBarStudent = new DevExpress.XtraEditors.ProgressBarControl();
		this.myGridControl1 = new AlienAge.CustomGrid.MyGridControl();
		this.myGridView1 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.timer2 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.progressBarStudent.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.myGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.myGridView1).BeginInit();
		base.SuspendLayout();
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(8, 86);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(118, 23);
		this.simpleButton1.TabIndex = 1;
		this.simpleButton1.Text = "Execute";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(154, 86);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(118, 23);
		this.simpleButton2.TabIndex = 2;
		this.simpleButton2.Text = "Close";
		this.comboBoxEdit1.Location = new System.Drawing.Point(8, 9);
		this.comboBoxEdit1.Name = "comboBoxEdit1";
		this.comboBoxEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.comboBoxEdit1.Properties.Appearance.Options.UseFont = true;
		this.comboBoxEdit1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.comboBoxEdit1.Properties.AppearanceDropDown.Options.UseFont = true;
		this.comboBoxEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.comboBoxEdit1.Size = new System.Drawing.Size(264, 24);
		this.comboBoxEdit1.TabIndex = 3;
		this.comboBoxEdit1.QueryPopUp += new System.ComponentModel.CancelEventHandler(comboBoxEdit1_QueryPopUp);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.progressBarStudent.Location = new System.Drawing.Point(8, 39);
		this.progressBarStudent.Name = "progressBarStudent";
		this.progressBarStudent.Properties.ShowTitle = true;
		this.progressBarStudent.Size = new System.Drawing.Size(264, 30);
		this.progressBarStudent.TabIndex = 4;
		this.myGridControl1.Location = new System.Drawing.Point(136, -1);
		this.myGridControl1.MainView = this.myGridView1;
		this.myGridControl1.Name = "myGridControl1";
		this.myGridControl1.Size = new System.Drawing.Size(14, 87);
		this.myGridControl1.TabIndex = 5;
		this.myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.myGridView1 });
		this.myGridControl1.Visible = false;
		this.myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[4] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4 });
		this.myGridView1.DetailHeight = 239;
		this.myGridView1.GridControl = this.myGridControl1;
		this.myGridView1.Name = "myGridView1";
		this.myGridView1.OptionsCustomization.AllowColumnMoving = false;
		this.myGridView1.OptionsCustomization.AllowColumnResizing = false;
		this.myGridView1.OptionsCustomization.AllowFilter = false;
		this.myGridView1.OptionsCustomization.AllowGroup = false;
		this.myGridView1.OptionsCustomization.AllowSort = false;
		this.myGridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(myGridView1_CustomUnboundColumnData);
		this.gridColumn1.Caption = "Debit";
		this.gridColumn1.FieldName = "Debit";
		this.gridColumn1.MinWidth = 13;
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 50;
		this.gridColumn2.Caption = "Credit";
		this.gridColumn2.FieldName = "Credit";
		this.gridColumn2.MinWidth = 13;
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn2.Width = 50;
		this.gridColumn3.Caption = "Bal";
		this.gridColumn3.FieldName = "Bal";
		this.gridColumn3.MinWidth = 13;
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 2;
		this.gridColumn3.Width = 50;
		this.gridColumn4.Caption = "Amount";
		this.gridColumn4.FieldName = "Amount";
		this.gridColumn4.MinWidth = 13;
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Width = 50;
		this.timer2.Interval = 500;
		this.timer2.Tick += new System.EventHandler(timer2_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(277, 115);
		base.ControlBox = false;
		base.Controls.Add(this.progressBarStudent);
		base.Controls.Add(this.comboBoxEdit1);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.myGridControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MinimizeBox = false;
		base.Name = "NormalizeLedgers";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Normalize Ledgers";
		base.Load += new System.EventHandler(NormalizeLedgers_Load);
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.progressBarStudent.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.myGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.myGridView1).EndInit();
		base.ResumeLayout(false);
	}
}
