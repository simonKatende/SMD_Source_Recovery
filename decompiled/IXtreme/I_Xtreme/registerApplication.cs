using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.Security;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace I_Xtreme;

public class registerApplication : XtraForm
{
	private IContainer components = null;

	private SimpleButton simpleButton1;

	private LabelControl labelControl1;

	private LabelControl labelControl3;

	private Timer timer1;

	private LinkLabel linkLabel1;

	private TextEdit txtSerialNumber;

	public registerApplication()
	{
		InitializeComponent();
		txtSerialNumber.Focus();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		try
		{
			string text = FingerPrint.GenerateRequestCode(FingerPrint.SchoolName, FingerPrint.ContactNo, FingerPrint.Village, FingerPrint.SchoolType, FingerPrint.Category);
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("SELECT * FROM tbl_StudentIDSNo WHERE _vvvv='{0}'", CryptorEngine.Encrypt("MainKeyValidator")), DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "securityKeys");
			DataTable dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(string.Format("SELECT _pppp,_vvvv,_ssss FROM tbl_StudentIDSNo WHERE _vvvv='{0}' AND _pppp LIKE '%{1}%'", CryptorEngine.Encrypt("ClientKeyValidator"), text), DataConnection.ConnectToDatabase());
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "_securityCheck");
				DataTable dataTable2 = new DataTable();
				dataTable2 = dataSet2.Tables[0];
				if (dataTable2.Rows.Count == 0)
				{
					string text2 = txtSerialNumber.Text;
					string text3 = SerialNumber.TestDays(txtSerialNumber.Text);
					string text4 = SerialNumber.SchoolCode(txtSerialNumber.Text);
					if (text2.Contains("-"))
					{
						using (SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(string.Format("SELECT * FROM tbl_StudentIDSNo WHERE _vvvv='{0}'", CryptorEngine.Encrypt("ClientKeyValidator")), DataConnection.ConnectToDatabase()))
						{
							using DataSet dataSet3 = new DataSet();
							sqlDataAdapter3.Fill(dataSet3, "securityKeys");
							DataTable dataTable3 = dataSet3.Tables[0];
							if (dataTable3.Rows.Count < 10)
							{
								foreach (DataRow row in dataTable.Rows)
								{
									if (text2 == SerialNumber.GetSerialNumberiXtremeTrial(row["_pppp"].ToString(), text4))
									{
										using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
										sqlConnection.Open();
										using SqlCommand sqlCommand = new SqlCommand
										{
											Connection = sqlConnection,
											CommandText = "INSERT INTO tbl_StudentIDSNo (_pppp,_pppppp,_pppppppp,_pppppppppp,_vvvv,_wwww,_xxxx,_ssss,_ttppp,_ccccc) VALUES (@_pppp,@_pppppp,@_pppppppp,@_pppppppppp,@_vvvv,@_wwww,@_xxxx,@_ssss,@_ttppp,@_ccccc)",
											CommandType = CommandType.Text
										};
										SqlParameter sqlParameter = sqlCommand.Parameters.Add("@_pppp", SqlDbType.VarChar, 200);
										sqlParameter.Value = text + text3;
										sqlParameter.Direction = ParameterDirection.Input;
										sqlParameter = sqlCommand.Parameters.Add("@_pppppp", SqlDbType.VarChar, 200);
										sqlParameter.Value = CryptorEngine.Encrypt("TrialVersion");
										sqlParameter.Direction = ParameterDirection.Input;
										sqlParameter = sqlCommand.Parameters.Add("@_pppppppp", SqlDbType.VarChar, 200);
										sqlParameter.Value = CryptorEngine.Encrypt(DateTime.Now.ToShortDateString());
										sqlParameter.Direction = ParameterDirection.Input;
										sqlParameter = sqlCommand.Parameters.Add("@_pppppppppp", SqlDbType.VarChar, 200);
										sqlParameter.Value = CryptorEngine.Encrypt(DateTime.Now.ToShortDateString());
										sqlParameter.Direction = ParameterDirection.Input;
										sqlParameter = sqlCommand.Parameters.Add("@_vvvv", SqlDbType.VarChar, 200);
										sqlParameter.Value = CryptorEngine.Encrypt("ClientKeyValidator");
										sqlParameter.Direction = ParameterDirection.Input;
										sqlParameter = sqlCommand.Parameters.Add("@_wwww", SqlDbType.VarChar, 200);
										sqlParameter.Value = SystemInformation.ComputerName;
										sqlParameter.Direction = ParameterDirection.Input;
										sqlParameter = sqlCommand.Parameters.Add("@_xxxx", SqlDbType.VarChar, 200);
										sqlParameter.Value = CryptorEngine.Encrypt("Activated");
										sqlParameter.Direction = ParameterDirection.Input;
										sqlParameter = sqlCommand.Parameters.Add("@_ssss", SqlDbType.VarChar, 200);
										sqlParameter.Value = CryptorEngine.Encrypt(text2);
										sqlParameter.Direction = ParameterDirection.Input;
										sqlParameter = sqlCommand.Parameters.Add("@_ttppp", SqlDbType.VarChar, 200);
										sqlParameter.Value = text;
										sqlParameter.Direction = ParameterDirection.Input;
										sqlParameter = sqlCommand.Parameters.Add("@_ccccc", SqlDbType.VarChar, 200);
										sqlParameter.Value = text4;
										sqlParameter.Direction = ParameterDirection.Input;
										if (sqlCommand.ExecuteNonQuery() > 0)
										{
											sqlConnection.Close();
											XtraMessageBox.Show("Application successfully registered", "Product registration", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
											Dispose();
										}
									}
									else
									{
										XtraMessageBox.Show("You have entered an Invalid Product Key, please check your key and try again.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
									}
								}
								return;
							}
							if (dataTable3.Rows.Count == 10)
							{
								XtraMessageBox.Show("You are allowed to add a maximum of Ten (10) clients only during the product trial period.", "School Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
							return;
						}
					}
					if (!text2.Contains("-"))
					{
						foreach (DataRow row2 in dataTable.Rows)
						{
							if (text2 == SerialNumber.GetSerialNumberiXtreme(row2["_pppp"].ToString(), text4))
							{
								using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
								sqlConnection2.Open();
								using SqlCommand sqlCommand2 = new SqlCommand
								{
									Connection = sqlConnection2,
									CommandText = "INSERT INTO tbl_StudentIDSNo (_pppp,_pppppp,_pppppppp,_pppppppppp,_vvvv,_wwww,_xxxx,_ssss,_ttppp,_ccccc)VALUES(@_pppp,@_pppppp,@_pppppppp,@_pppppppppp,@_vvvv,@_wwww,@_xxxx,@_ssss,@_ttppp,@_ccccc)",
									CommandType = CommandType.Text
								};
								SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@_pppp", SqlDbType.VarChar, 200);
								sqlParameter2.Value = text;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand2.Parameters.Add("@_pppppp", SqlDbType.VarChar, 200);
								sqlParameter2.Value = CryptorEngine.Encrypt("FullVersion");
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand2.Parameters.Add("@_pppppppp", SqlDbType.VarChar, 200);
								sqlParameter2.Value = CryptorEngine.Encrypt(DateTime.Now.ToShortDateString());
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand2.Parameters.Add("@_pppppppppp", SqlDbType.VarChar, 200);
								sqlParameter2.Value = CryptorEngine.Encrypt(DateTime.Now.ToShortDateString());
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand2.Parameters.Add("@_vvvv", SqlDbType.VarChar, 200);
								sqlParameter2.Value = CryptorEngine.Encrypt("ClientKeyValidator");
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand2.Parameters.Add("@_wwww", SqlDbType.VarChar, 200);
								sqlParameter2.Value = SystemInformation.ComputerName;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand2.Parameters.Add("@_xxxx", SqlDbType.VarChar, 200);
								sqlParameter2.Value = CryptorEngine.Encrypt("Activated");
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand2.Parameters.Add("@_ssss", SqlDbType.VarChar, 200);
								sqlParameter2.Value = CryptorEngine.Encrypt(text2);
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand2.Parameters.Add("@_ttppp", SqlDbType.VarChar, 200);
								sqlParameter2.Value = text;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand2.Parameters.Add("@_ccccc", SqlDbType.VarChar, 200);
								sqlParameter2.Value = text4;
								sqlParameter2.Direction = ParameterDirection.Input;
								if (sqlCommand2.ExecuteNonQuery() > 0)
								{
									sqlConnection2.Close();
									XtraMessageBox.Show("Application successfully registered", "Product registration", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									Dispose();
								}
							}
							else
							{
								XtraMessageBox.Show("You have entered an Invalid Product Key, please check your key and try again.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}
						}
						return;
					}
					XtraMessageBox.Show($"Please use the correct product key.", "Fake Product Key", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					if (dataTable2.Rows.Count <= 0)
					{
						return;
					}
					string text5 = txtSerialNumber.Text;
					string text6 = SerialNumber.TestDays(txtSerialNumber.Text);
					string text7 = SerialNumber.SchoolCode(txtSerialNumber.Text);
					if (text5.Contains("-"))
					{
						foreach (DataRow row3 in dataTable.Rows)
						{
							if (text5 == SerialNumber.GetSerialNumberiXtremeTrial(row3["_pppp"].ToString(), text7))
							{
								using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
								sqlConnection3.Open();
								using SqlCommand sqlCommand3 = new SqlCommand
								{
									Connection = sqlConnection3,
									CommandText = $"UPDATE tbl_StudentIDSNo SET _pppp=@_pppp,_pppppp=@_pppppp,_pppppppp=@_pppppppp,_pppppppppp=@_pppppppppp,_wwww=@_wwww,_xxxx=@_xxxx,_ssss=@_ssss,_ccccc=@_ccccc WHERE _vvvv=@_vvvv AND _ttppp=@_ttppp",
									CommandType = CommandType.Text
								};
								SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@_pppp", SqlDbType.VarChar, 200);
								sqlParameter3.Value = text + text6;
								sqlParameter3.Direction = ParameterDirection.Input;
								sqlParameter3 = sqlCommand3.Parameters.Add("@_pppppp", SqlDbType.VarChar, 200);
								sqlParameter3.Value = CryptorEngine.Encrypt("TrialVersion");
								sqlParameter3.Direction = ParameterDirection.Input;
								sqlParameter3 = sqlCommand3.Parameters.Add("@_pppppppp", SqlDbType.VarChar, 200);
								sqlParameter3.Value = CryptorEngine.Encrypt(DateTime.Now.ToShortDateString());
								sqlParameter3.Direction = ParameterDirection.Input;
								sqlParameter3 = sqlCommand3.Parameters.Add("@_pppppppppp", SqlDbType.VarChar, 200);
								sqlParameter3.Value = CryptorEngine.Encrypt(DateTime.Now.ToShortDateString());
								sqlParameter3.Direction = ParameterDirection.Input;
								sqlParameter3 = sqlCommand3.Parameters.Add("@_vvvv", SqlDbType.VarChar, 200);
								sqlParameter3.Value = CryptorEngine.Encrypt("ClientKeyValidator");
								sqlParameter3.Direction = ParameterDirection.Input;
								sqlParameter3 = sqlCommand3.Parameters.Add("@_wwww", SqlDbType.VarChar, 200);
								sqlParameter3.Value = SystemInformation.ComputerName;
								sqlParameter3.Direction = ParameterDirection.Input;
								sqlParameter3 = sqlCommand3.Parameters.Add("@_xxxx", SqlDbType.VarChar, 200);
								sqlParameter3.Value = CryptorEngine.Encrypt("Activated");
								sqlParameter3.Direction = ParameterDirection.Input;
								sqlParameter3 = sqlCommand3.Parameters.Add("@_ssss", SqlDbType.VarChar, 200);
								sqlParameter3.Value = CryptorEngine.Encrypt(text5);
								sqlParameter3.Direction = ParameterDirection.Input;
								sqlParameter3 = sqlCommand3.Parameters.Add("@_ttppp", SqlDbType.VarChar, 200);
								sqlParameter3.Value = text;
								sqlParameter3.Direction = ParameterDirection.Input;
								sqlParameter3 = sqlCommand3.Parameters.Add("@_ccccc", SqlDbType.VarChar, 200);
								sqlParameter3.Value = text7;
								sqlParameter3.Direction = ParameterDirection.Input;
								if (sqlCommand3.ExecuteNonQuery() > 0)
								{
									sqlConnection3.Close();
									XtraMessageBox.Show("Application successfully registered", "Product registration", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									Dispose();
								}
							}
							else
							{
								XtraMessageBox.Show("You have entered an Invalid Product Key, please check your key and try again.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}
						}
						return;
					}
					if (!text5.Contains("-"))
					{
						foreach (DataRow row4 in dataTable.Rows)
						{
							if (text5 == SerialNumber.GetSerialNumberiXtreme(row4["_pppp"].ToString(), text7))
							{
								using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
								sqlConnection4.Open();
								using SqlCommand sqlCommand4 = new SqlCommand
								{
									Connection = sqlConnection4,
									CommandText = $"UPDATE tbl_StudentIDSNo SET _pppp=@_pppp, _pppppp=@_pppppp,_pppppppp=@_pppppppp,_pppppppppp=@_pppppppppp,_wwww=@_wwww,_xxxx=@_xxxx,_ssss=@_ssss,_ccccc=@_ccccc WHERE _ttppp=@_ttppp AND _vvvv=@_vvvv",
									CommandType = CommandType.Text
								};
								SqlParameter sqlParameter4 = sqlCommand4.Parameters.Add("@_pppp", SqlDbType.VarChar, 200);
								sqlParameter4.Value = text;
								sqlParameter4.Direction = ParameterDirection.Input;
								sqlParameter4 = sqlCommand4.Parameters.Add("@_pppppp", SqlDbType.VarChar, 200);
								sqlParameter4.Value = CryptorEngine.Encrypt("FullVersion");
								sqlParameter4.Direction = ParameterDirection.Input;
								sqlParameter4 = sqlCommand4.Parameters.Add("@_pppppppp", SqlDbType.VarChar, 200);
								sqlParameter4.Value = CryptorEngine.Encrypt(DateTime.Now.ToShortDateString());
								sqlParameter4.Direction = ParameterDirection.Input;
								sqlParameter4 = sqlCommand4.Parameters.Add("@_pppppppppp", SqlDbType.VarChar, 200);
								sqlParameter4.Value = CryptorEngine.Encrypt(DateTime.Now.ToShortDateString());
								sqlParameter4.Direction = ParameterDirection.Input;
								sqlParameter4 = sqlCommand4.Parameters.Add("@_vvvv", SqlDbType.VarChar, 200);
								sqlParameter4.Value = CryptorEngine.Encrypt("ClientKeyValidator");
								sqlParameter4.Direction = ParameterDirection.Input;
								sqlParameter4 = sqlCommand4.Parameters.Add("@_wwww", SqlDbType.VarChar, 200);
								sqlParameter4.Value = SystemInformation.ComputerName;
								sqlParameter4.Direction = ParameterDirection.Input;
								sqlParameter4 = sqlCommand4.Parameters.Add("@_xxxx", SqlDbType.VarChar, 200);
								sqlParameter4.Value = CryptorEngine.Encrypt("Activated");
								sqlParameter4.Direction = ParameterDirection.Input;
								sqlParameter4 = sqlCommand4.Parameters.Add("@_ssss", SqlDbType.VarChar, 200);
								sqlParameter4.Value = CryptorEngine.Encrypt(text5);
								sqlParameter4.Direction = ParameterDirection.Input;
								sqlParameter4 = sqlCommand4.Parameters.Add("@_ttppp", SqlDbType.VarChar, 200);
								sqlParameter4.Value = text;
								sqlParameter4.Direction = ParameterDirection.Input;
								sqlParameter4 = sqlCommand4.Parameters.Add("@_ccccc", SqlDbType.VarChar, 200);
								sqlParameter4.Value = text7;
								sqlParameter4.Direction = ParameterDirection.Input;
								if (sqlCommand4.ExecuteNonQuery() > 0)
								{
									sqlConnection4.Close();
									XtraMessageBox.Show("Application successfully registered", "Product registration", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									Dispose();
								}
							}
							else
							{
								XtraMessageBox.Show("You have entered an Invalid Product Key, please check your key and try again.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}
						}
						return;
					}
					XtraMessageBox.Show($"Please use the correct product key.", "Fake Product Key", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				XtraMessageBox.Show("Please register your application from the database server first.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (txtSerialNumber.Text.Length == 30)
		{
			simpleButton1.Enabled = true;
		}
		else
		{
			simpleButton1.Enabled = false;
		}
	}

	private void registerApplication_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start("http://www.alienage.co.ug/productkeysamples");
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
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.linkLabel1 = new System.Windows.Forms.LinkLabel();
		this.txtSerialNumber = new DevExpress.XtraEditors.TextEdit();
		((System.ComponentModel.ISupportInitialize)this.txtSerialNumber.Properties).BeginInit();
		base.SuspendLayout();
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(389, 149);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(68, 26);
		this.simpleButton1.TabIndex = 18;
		this.simpleButton1.Text = "Register";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl1.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseForeColor = true;
		this.labelControl1.Location = new System.Drawing.Point(12, 27);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(215, 25);
		this.labelControl1.TabIndex = 20;
		this.labelControl1.Text = "Enter your product key";
		this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Gray;
		this.labelControl3.Appearance.Options.UseFont = true;
		this.labelControl3.Appearance.Options.UseForeColor = true;
		this.labelControl3.Location = new System.Drawing.Point(12, 70);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(447, 38);
		this.labelControl3.TabIndex = 21;
		this.labelControl3.Text = "Your product key is 30 characters and is typically found in your\r\nproduct packaging";
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.linkLabel1.AutoSize = true;
		this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 9f);
		this.linkLabel1.Location = new System.Drawing.Point(12, 121);
		this.linkLabel1.Name = "linkLabel1";
		this.linkLabel1.Size = new System.Drawing.Size(152, 14);
		this.linkLabel1.TabIndex = 22;
		this.linkLabel1.TabStop = true;
		this.linkLabel1.Text = "See product key examples";
		this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
		this.txtSerialNumber.Location = new System.Drawing.Point(12, 149);
		this.txtSerialNumber.Name = "txtSerialNumber";
		this.txtSerialNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.txtSerialNumber.Properties.Appearance.Options.UseFont = true;
		this.txtSerialNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtSerialNumber.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtSerialNumber.Properties.MaxLength = 30;
		this.txtSerialNumber.Size = new System.Drawing.Size(371, 26);
		this.txtSerialNumber.TabIndex = 23;
		base.Appearance.BackColor = System.Drawing.Color.White;
		base.Appearance.Options.UseBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(469, 200);
		base.Controls.Add(this.txtSerialNumber);
		base.Controls.Add(this.linkLabel1);
		base.Controls.Add(this.labelControl3);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.simpleButton1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.Name = "registerApplication";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Register Application";
		base.Load += new System.EventHandler(registerApplication_Load);
		((System.ComponentModel.ISupportInitialize)this.txtSerialNumber.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
