using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme.DialogForms;

public class GradingSystemChange : XtraForm
{
	private int w = 0;

	private IContainer components = null;

	private ProgressBarControl progressBarControl1;

	private Timer timer1;

	public GradingSystemChange()
	{
		InitializeComponent();
	}

	private void ChangeGradingSystem()
	{
		try
		{
			progressBarControl1.Position = 0;
			progressBarControl1.Properties.Maximum = 6;
			List<string> list = new List<string>();
			list.AddRange(new string[7] { "A", "B", "C", "D", "E", "O", "F" });
			List<double> list2 = new List<double>();
			list2.AddRange(new double[7] { 1.0, 2.4, 3.4, 4.4, 5.4, 6.4, 7.4 });
			List<double> list3 = new List<double>();
			list3.AddRange(new double[7] { 2.33, 3.33, 4.33, 5.33, 6.33, 7.33, 9.0 });
			List<int> list4 = new List<int>();
			list4.AddRange(new int[7] { 6, 5, 4, 3, 2, 1, 0 });
			for (int i = 0; i < 7; i++)
			{
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "UPDATE ALevelGradingScale SET Debut=@Debut,[End]=@End,Points=@Points WHERE Category=@Category",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar, 2);
					sqlParameter.Value = list[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Debut", SqlDbType.Float);
					sqlParameter.Value = list2[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@End", SqlDbType.Float);
					sqlParameter.Value = list3[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Points", SqlDbType.Int);
					sqlParameter.Value = list4[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				Application.DoEvents();
				progressBarControl1.Position = i;
				sqlConnection.Close();
				if (i == 6)
				{
					Close();
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void GradingSystemChange_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		w++;
		if (w == 5)
		{
			timer1.Enabled = false;
			w = 0;
			ChangeGradingSystem();
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
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.progressBarControl1.Location = new System.Drawing.Point(0, 0);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.ShowProgressInTaskBar = true;
		this.progressBarControl1.Size = new System.Drawing.Size(281, 33);
		this.progressBarControl1.TabIndex = 0;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(281, 33);
		base.ControlBox = false;
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "GradingSystemChange";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Changing grading system...";
		base.Load += new System.EventHandler(GradingSystemChange_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
