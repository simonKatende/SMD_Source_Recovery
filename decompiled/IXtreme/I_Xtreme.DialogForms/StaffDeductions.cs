using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.Utils.Animation;
using DevExpress.Utils.BehaviorSource;
using DevExpress.Utils.Behaviors;
using DevExpress.Utils.Behaviors.Common;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Behaviors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class StaffDeductions : XtraForm
{
	private string _staffid = string.Empty;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private TextEdit txtRate;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private DXValidationProvider dxValidationProvider1;

	private MRUEdit txtItem;

	private BehaviorManager behaviorManager1;

	private LayoutControlItem layoutControlItem5;

	private TransitionManager transitionManager1;

	private AlertControl alertControl1;

	public StaffDeductions(string StaffId)
	{
		InitializeComponent();
		LoadEmployeeDeductions();
		_staffid = StaffId;
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		while (dxValidationProvider1.Validate())
		{
			if (dxValidationProvider1.GetInvalidControls().Count != 0)
			{
				continue;
			}
			string text = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtItem.Text);
			double result = (double.TryParse(txtRate.Text, out result) ? result : 0.0);
			if (DataModel.SaveData("tbl_PayrollDeductions", new string[3] { "StaffId", "Item", "Rate" }, new object[3] { _staffid, text, result }) == 1)
			{
				SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "SELECT Item FROM tbl_EmployeeDeductions WHERE Item=@Item",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Item", SqlDbType.VarChar, 50);
				sqlParameter.Value = text;
				sqlParameter.Direction = ParameterDirection.Input;
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (!sqlDataReader.HasRows)
				{
					sqlDataReader.Close();
					SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = "INSERT INTO tbl_EmployeeDeductions (Item) VALUES (@Item)",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@Item", SqlDbType.VarChar, 50);
					sqlParameter2.Value = text;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
					sqlConnection.Close();
					LoadEmployeeDeductions();
				}
				txtItem.Text = string.Empty;
				txtRate.Text = string.Empty;
			}
			break;
		}
	}

	private void LoadEmployeeDeductions()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_EmployeeDeductions", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		txtItem.Properties.Items.Clear();
		foreach (DataRow row in dataTable.Rows)
		{
			txtItem.Properties.Items.Add(row["Item"]);
		}
	}

	private void StaffDeductions_FormClosed(object sender, FormClosedEventArgs e)
	{
		base.DialogResult = DialogResult.OK;
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
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.Utils.Animation.Transition transition = new DevExpress.Utils.Animation.Transition();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.txtItem = new DevExpress.XtraEditors.MRUEdit();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtRate = new DevExpress.XtraEditors.TextEdit();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
		this.transitionManager1 = new DevExpress.Utils.Animation.TransitionManager(this.components);
		this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtRate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.behaviorManager1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.txtItem);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.txtRate);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(491, 163);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.dxValidationProvider1.SetIconAlignment(this.txtItem, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtItem.Location = new System.Drawing.Point(40, 4);
		this.txtItem.Name = "txtItem";
		this.txtItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.txtItem.Properties.Items.AddRange(new object[3] { "gggggggggggggggggggg", "hhhhhhhhhhhhhhhhhhhhh", "sssssssssssssssssssss" });
		this.txtItem.Size = new System.Drawing.Size(447, 28);
		this.txtItem.StyleController = this.layoutControl1;
		this.txtItem.TabIndex = 8;
		conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.txtItem, conditionValidationRule);
		this.simpleButton2.Location = new System.Drawing.Point(4, 127);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(239, 32);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 7;
		this.simpleButton2.Text = "Close";
		this.simpleButton1.Location = new System.Drawing.Point(247, 127);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(240, 32);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 6;
		this.simpleButton1.Text = "Save";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.behaviorManager1.SetBehaviors(this.txtRate, new DevExpress.Utils.Behaviors.Behavior[2]
		{
			DevExpress.Utils.Behaviors.Common.FileIconBehavior.Create(typeof(DevExpress.XtraEditors.Behaviors.FileIconBehaviorSourceForTextEdit)),
			DevExpress.Utils.Behaviors.Common.FilePathBehavior.Create(typeof(DevExpress.XtraEditors.Behaviors.FilePathBehaviorSourceForTextEdit))
		});
		this.txtRate.Location = new System.Drawing.Point(40, 36);
		this.txtRate.Name = "txtRate";
		this.txtRate.Size = new System.Drawing.Size(447, 28);
		this.txtRate.StyleController = this.layoutControl1;
		this.txtRate.TabIndex = 5;
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[5] { this.emptySpaceItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.Root.Size = new System.Drawing.Size(491, 163);
		this.Root.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 64);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(487, 59);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.Control = this.txtRate;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 32);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(487, 32);
		this.layoutControlItem2.Text = "Rate";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(33, 19);
		this.layoutControlItem3.Control = this.simpleButton1;
		this.layoutControlItem3.Location = new System.Drawing.Point(243, 123);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(244, 36);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.Control = this.simpleButton2;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 123);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(243, 36);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlItem5.Control = this.txtItem;
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(487, 32);
		this.layoutControlItem5.Text = "Item";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(33, 19);
		transition.BarWaitingIndicatorProperties.Caption = "";
		transition.BarWaitingIndicatorProperties.Description = "";
		transition.Control = this;
		transition.LineWaitingIndicatorProperties.AnimationElementCount = 5;
		transition.LineWaitingIndicatorProperties.Caption = "";
		transition.LineWaitingIndicatorProperties.Description = "";
		transition.RingWaitingIndicatorProperties.AnimationElementCount = 5;
		transition.RingWaitingIndicatorProperties.Caption = "";
		transition.RingWaitingIndicatorProperties.Description = "";
		transition.ShowWaitingIndicator = DevExpress.Utils.DefaultBoolean.True;
		transition.WaitingIndicatorProperties.Caption = "";
		transition.WaitingIndicatorProperties.Description = "";
		this.transitionManager1.Transitions.Add(transition);
		this.transitionManager1.UseDirectXPaint = DevExpress.Utils.DefaultBoolean.True;
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.behaviorManager1.SetBehaviors(this, new DevExpress.Utils.Behaviors.Behavior[1] { DevExpress.Utils.Behaviors.Common.PersistenceBehavior.Create(typeof(DevExpress.Utils.BehaviorSource.PersistenceBehaviorSourceForForm), null, DevExpress.Utils.Behaviors.Common.Storage.Registry) });
		base.ClientSize = new System.Drawing.Size(491, 163);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "StaffDeductions";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Staff Deductions";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(StaffDeductions_FormClosed);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtRate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.behaviorManager1).EndInit();
		base.ResumeLayout(false);
	}
}
