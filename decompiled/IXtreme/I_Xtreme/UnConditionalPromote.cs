using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme;

public class UnConditionalPromote : XtraForm
{
	private IContainer components = null;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private LabelControl labelControl2;

	private LabelControl lblProgress;

	public UnConditionalPromote()
	{
		InitializeComponent();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		DialogResult dialogResult = XtraMessageBox.Show("Are you sure you want to promote all the students to their respective Proceeding classes?\nNote that you will not be able to undo this action.", "School Management Dynamics", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult == DialogResult.Yes)
		{
			try
			{
				Application.DoEvents();
				lblProgress.Text = "Preparing S.6 class...";
				using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = "UPDATE students SET ClassId='N/A' WHERE ClassId='S.6' ",
						CommandType = CommandType.Text
					})
					{
						sqlCommand.ExecuteNonQuery();
					}
					sqlConnection.Close();
				}
				using (SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Classes Where ClassId='S.6'", selectConnection);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet, "S.5");
					DataTable dataTable = new DataTable();
					dataTable = dataSet.Tables[0];
					foreach (DataRow row in dataTable.Rows)
					{
						Application.DoEvents();
						lblProgress.Text = "Promoting S.5 to S.6...";
						using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
						{
							sqlConnection2.Open();
							using (SqlCommand sqlCommand2 = new SqlCommand
							{
								Connection = sqlConnection2,
								CommandText = string.Format("UPDATE students SET ClassId='S.6',RequiredFees='{0}' WHERE ClassId='S.5' AND StudyStatus='B' AND BursaryStatus='None'", row["TuitionResidents"]),
								CommandType = CommandType.Text
							})
							{
								sqlCommand2.ExecuteNonQuery();
							}
							sqlConnection2.Close();
						}
						using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
						{
							sqlConnection3.Open();
							using (SqlCommand sqlCommand3 = new SqlCommand
							{
								Connection = sqlConnection3,
								CommandText = string.Format("UPDATE students SET ClassId='S.6',RequiredFees='{0}' WHERE ClassId='S.5' AND StudyStatus='D' AND BursaryStatus='None'", row["TuitionNonResidents"]),
								CommandType = CommandType.Text
							})
							{
								sqlCommand3.ExecuteNonQuery();
							}
							sqlConnection3.Close();
						}
						using (SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase()))
						{
							sqlConnection4.Open();
							using (SqlCommand sqlCommand4 = new SqlCommand
							{
								Connection = sqlConnection4,
								CommandText = "UPDATE students SET ClassId='S.6' WHERE ClassId='S.5' AND StudyStatus='B' AND BursaryStatus<>'None'",
								CommandType = CommandType.Text
							})
							{
								sqlCommand4.ExecuteNonQuery();
							}
							sqlConnection4.Close();
						}
						using SqlConnection sqlConnection5 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection5.Open();
						using (SqlCommand sqlCommand5 = new SqlCommand
						{
							Connection = sqlConnection5,
							CommandText = "UPDATE students SET ClassId='S.6' WHERE ClassId='S.5' AND StudyStatus='D' AND BursaryStatus<>'None'",
							CommandType = CommandType.Text
						})
						{
							sqlCommand5.ExecuteNonQuery();
						}
						sqlConnection5.Close();
					}
				}
				Application.DoEvents();
				lblProgress.Text = "Preparing S.4 class...";
				using (SqlConnection sqlConnection6 = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					sqlConnection6.Open();
					using (SqlCommand sqlCommand6 = new SqlCommand
					{
						Connection = sqlConnection6,
						CommandText = "UPDATE students SET ClassId='N/A' WHERE ClassId='S.4' ",
						CommandType = CommandType.Text
					})
					{
						sqlCommand6.ExecuteNonQuery();
					}
					sqlConnection6.Close();
				}
				using (SqlConnection selectConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("SELECT * FROM Classes Where ClassId='S.4'", selectConnection2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "S.4");
					DataTable dataTable2 = new DataTable();
					dataTable2 = dataSet2.Tables[0];
					foreach (DataRow row2 in dataTable2.Rows)
					{
						Application.DoEvents();
						lblProgress.Text = "Promoting S.3 to S.4...";
						using (SqlConnection sqlConnection7 = new SqlConnection(DataConnection.ConnectToDatabase()))
						{
							sqlConnection7.Open();
							using (SqlCommand sqlCommand7 = new SqlCommand
							{
								Connection = sqlConnection7,
								CommandText = string.Format("UPDATE students SET ClassId='S.4',RequiredFees='{0}' WHERE ClassId='S.3' AND StudyStatus='B' AND BursaryStatus='None'", row2["TuitionResidents"]),
								CommandType = CommandType.Text
							})
							{
								sqlCommand7.ExecuteNonQuery();
							}
							sqlConnection7.Close();
						}
						using (SqlConnection sqlConnection8 = new SqlConnection(DataConnection.ConnectToDatabase()))
						{
							sqlConnection8.Open();
							using (SqlCommand sqlCommand8 = new SqlCommand
							{
								Connection = sqlConnection8,
								CommandText = string.Format("UPDATE students SET ClassId='S.4',RequiredFees='{0}' WHERE ClassId='S.3' AND StudyStatus='D' AND BursaryStatus='None'", row2["TuitionNonResidents"]),
								CommandType = CommandType.Text
							})
							{
								sqlCommand8.ExecuteNonQuery();
							}
							sqlConnection8.Close();
						}
						using (SqlConnection sqlConnection9 = new SqlConnection(DataConnection.ConnectToDatabase()))
						{
							sqlConnection9.Open();
							using (SqlCommand sqlCommand9 = new SqlCommand
							{
								Connection = sqlConnection9,
								CommandText = "UPDATE students SET ClassId='S.4'WHERE ClassId='S.3' AND StudyStatus='B' AND BursaryStatus<>'None'",
								CommandType = CommandType.Text
							})
							{
								sqlCommand9.ExecuteNonQuery();
							}
							sqlConnection9.Close();
						}
						using SqlConnection sqlConnection10 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection10.Open();
						using (SqlCommand sqlCommand10 = new SqlCommand
						{
							Connection = sqlConnection10,
							CommandText = "UPDATE students SET ClassId='S.4' WHERE ClassId='S.3' AND StudyStatus='D' AND BursaryStatus<>'None'",
							CommandType = CommandType.Text
						})
						{
							sqlCommand10.ExecuteNonQuery();
						}
						sqlConnection10.Close();
					}
				}
				using (SqlConnection selectConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("SELECT * FROM Classes Where ClassId='S.3'", selectConnection3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3, "S.3");
					DataTable dataTable3 = new DataTable();
					dataTable3 = dataSet3.Tables[0];
					foreach (DataRow row3 in dataTable3.Rows)
					{
						Application.DoEvents();
						lblProgress.Text = "Promoting S.2 to S.3...";
						using (SqlConnection sqlConnection11 = new SqlConnection(DataConnection.ConnectToDatabase()))
						{
							sqlConnection11.Open();
							using (SqlCommand sqlCommand11 = new SqlCommand
							{
								Connection = sqlConnection11,
								CommandText = string.Format("UPDATE students SET ClassId='S.3',RequiredFees='{0}' WHERE ClassId='S.2' AND StudyStatus='B' AND BursaryStatus='None'", row3["TuitionResidents"]),
								CommandType = CommandType.Text
							})
							{
								sqlCommand11.ExecuteNonQuery();
							}
							sqlConnection11.Close();
						}
						using (SqlConnection sqlConnection12 = new SqlConnection(DataConnection.ConnectToDatabase()))
						{
							sqlConnection12.Open();
							using (SqlCommand sqlCommand12 = new SqlCommand
							{
								Connection = sqlConnection12,
								CommandText = string.Format("UPDATE students SET ClassId='S.3',RequiredFees='{0}' WHERE ClassId='S.2' AND StudyStatus='D' AND BursaryStatus='None'", row3["TuitionNonResidents"]),
								CommandType = CommandType.Text
							})
							{
								sqlCommand12.ExecuteNonQuery();
							}
							sqlConnection12.Close();
						}
						using (SqlConnection sqlConnection13 = new SqlConnection(DataConnection.ConnectToDatabase()))
						{
							sqlConnection13.Open();
							using (SqlCommand sqlCommand13 = new SqlCommand
							{
								Connection = sqlConnection13,
								CommandText = "UPDATE students SET ClassId='S.3' WHERE ClassId='S.2' AND StudyStatus='B' AND BursaryStatus<>'None'",
								CommandType = CommandType.Text
							})
							{
								sqlCommand13.ExecuteNonQuery();
							}
							sqlConnection13.Close();
						}
						using SqlConnection sqlConnection14 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection14.Open();
						using (SqlCommand sqlCommand14 = new SqlCommand
						{
							Connection = sqlConnection14,
							CommandText = "UPDATE students SET ClassId='S.3' WHERE ClassId='S.2' AND StudyStatus='D' AND BursaryStatus<>'None'",
							CommandType = CommandType.Text
						})
						{
							sqlCommand14.ExecuteNonQuery();
						}
						sqlConnection14.Close();
					}
				}
				using (SqlConnection selectConnection4 = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter("SELECT * FROM Classes Where ClassId='S.2'", selectConnection4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4, "S.2");
					DataTable dataTable4 = new DataTable();
					dataTable4 = dataSet4.Tables[0];
					foreach (DataRow row4 in dataTable4.Rows)
					{
						Application.DoEvents();
						lblProgress.Text = "Promoting S.1 to S.2...";
						using (SqlConnection sqlConnection15 = new SqlConnection(DataConnection.ConnectToDatabase()))
						{
							sqlConnection15.Open();
							using (SqlCommand sqlCommand15 = new SqlCommand
							{
								Connection = sqlConnection15,
								CommandText = string.Format("UPDATE students SET ClassId='S.2',RequiredFees='{0}' WHERE ClassId='S.1' AND StudyStatus='B' AND BursaryStatus='None'", row4["TuitionResidents"]),
								CommandType = CommandType.Text
							})
							{
								sqlCommand15.ExecuteNonQuery();
							}
							sqlConnection15.Close();
						}
						using (SqlConnection sqlConnection16 = new SqlConnection(DataConnection.ConnectToDatabase()))
						{
							sqlConnection16.Open();
							using (SqlCommand sqlCommand16 = new SqlCommand
							{
								Connection = sqlConnection16,
								CommandText = string.Format("UPDATE students SET ClassId='S.2',RequiredFees='{0}' WHERE ClassId='S.1' AND StudyStatus='D' AND BursaryStatus='None'", row4["TuitionNonResidents"]),
								CommandType = CommandType.Text
							})
							{
								sqlCommand16.ExecuteNonQuery();
							}
							sqlConnection16.Close();
						}
						using (SqlConnection sqlConnection17 = new SqlConnection(DataConnection.ConnectToDatabase()))
						{
							sqlConnection17.Open();
							using (SqlCommand sqlCommand17 = new SqlCommand
							{
								Connection = sqlConnection17,
								CommandText = "UPDATE students SET ClassId='S.2' WHERE ClassId='S.1' AND StudyStatus='B' AND BursaryStatus<>'None'",
								CommandType = CommandType.Text
							})
							{
								sqlCommand17.ExecuteNonQuery();
							}
							sqlConnection17.Close();
						}
						using SqlConnection sqlConnection18 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection18.Open();
						using (SqlCommand sqlCommand18 = new SqlCommand
						{
							Connection = sqlConnection18,
							CommandText = "UPDATE students SET ClassId='S.2' WHERE ClassId='S.1' AND StudyStatus='D' AND BursaryStatus<>'None'",
							CommandType = CommandType.Text
						})
						{
							sqlCommand18.ExecuteNonQuery();
						}
						sqlConnection18.Close();
					}
				}
				lblProgress.Text = "Promotions completed!";
				return;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		dialogResult = DialogResult.Cancel;
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
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.lblProgress = new DevExpress.XtraEditors.LabelControl();
		base.SuspendLayout();
		this.simpleButton1.Location = new System.Drawing.Point(197, 65);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(75, 23);
		this.simpleButton1.TabIndex = 2;
		this.simpleButton1.Text = "Promote";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.Location = new System.Drawing.Point(12, 65);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(75, 23);
		this.simpleButton2.TabIndex = 3;
		this.simpleButton2.Text = "Cancel";
		this.labelControl2.Location = new System.Drawing.Point(12, 12);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(31, 13);
		this.labelControl2.TabIndex = 4;
		this.labelControl2.Text = "Status";
		this.lblProgress.Location = new System.Drawing.Point(59, 12);
		this.lblProgress.Name = "lblProgress";
		this.lblProgress.Size = new System.Drawing.Size(0, 13);
		this.lblProgress.TabIndex = 5;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(284, 103);
		base.Controls.Add(this.lblProgress);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "UnConditionalPromote";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "UnConditional Promote";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
