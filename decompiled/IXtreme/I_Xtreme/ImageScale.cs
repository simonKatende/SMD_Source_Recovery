using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using AlienAge.Connectivity;

namespace I_Xtreme;

public class ImageScale : Form
{
	private IContainer components = null;

	private Button button1;

	private Label label1;

	public ImageScale()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			label1.Text = "Please wait...";
			button1.Enabled = false;
			Application.DoEvents();
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT StudentNumber,Picture FROM tbl_Stud", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "studentImages");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				byte[] array = new byte[0];
				array = (byte[])row["Picture"];
				Image image;
				using (MemoryStream stream = new MemoryStream(array))
				{
					image = Image.FromStream(stream);
				}
				Image image2 = image;
				int num = image2.Height;
				int num2 = image2.Width;
				int num3 = 250;
				int num4 = 220;
				num = num * num4 / num2;
				num2 = num4;
				if (num > num3)
				{
					num2 = num2 * num3 / num;
					num = num3;
				}
				Bitmap bitmap = new Bitmap(image2, num2, num);
				using MemoryStream memoryStream = new MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Png);
				memoryStream.Position = 0L;
				byte[] array2 = new byte[memoryStream.Length + 1];
				memoryStream.Read(array2, 0, array2.Length);
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "UPDATE students SET Picture=@Picture WHERE StudentNumber=@StudentNumber",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
					sqlParameter.Value = row["StudentNumber"];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Picture", SqlDbType.Image);
					sqlParameter.Value = array2;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			MessageBox.Show("Operation successfully executed", "Success");
			label1.Text = string.Empty;
			button1.Enabled = true;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Error");
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
		this.button1 = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.button1.Location = new System.Drawing.Point(102, 35);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 0;
		this.button1.Text = "Execute";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(2, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(279, 23);
		this.label1.TabIndex = 1;
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(284, 59);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.button1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "ImageScale";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Image Scaling";
		base.ResumeLayout(false);
	}
}
