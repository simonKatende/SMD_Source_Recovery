using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace I_Xtreme;

internal class StudentGatePasses
{
	public static void CreateStudentGatePass(string passType, string _studentNumber, string _name, string _class, string _stream, string _db, string _guardian, Image _pic, string _sex, double _amount, string _amountInWords)
	{
		try
		{
			Image image = null;
			image = _pic;
			int height = image.Height;
			int width = image.Width;
			height = height * 220 / width;
			width = 220;
			if (height > 250)
			{
				width = width * 250 / height;
				height = 250;
			}
			Bitmap bitmap = new Bitmap(image, width, height);
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Png);
			memoryStream.Position = 0L;
			byte[] array = new byte[memoryStream.Length + 1];
			memoryStream.Read(array, 0, array.Length);
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_GatePass (StudentNumber,Name,Class,Stream,DB,Guardian,CreatedBy,SemesterId,CreateDate,PassType,pic,Sex,amount,amountInWords)VALUES(@StudentNumber,@Name,@Class,@Stream,@DB,@Guardian,@CreatedBy,@SemesterId,@CreateDate,@PassType,@pic,@Sex,@amount,@amountInWords)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
				sqlParameter.Value = _studentNumber;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50);
				sqlParameter.Value = _name;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Class", SqlDbType.VarChar, 3);
				sqlParameter.Value = _class;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Stream", SqlDbType.VarChar, 50);
				sqlParameter.Value = _stream;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@DB", SqlDbType.VarChar, 1);
				sqlParameter.Value = _db;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Guardian", SqlDbType.VarChar, 50);
				sqlParameter.Value = _guardian;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 30);
				sqlParameter.Value = CurrentUser.GetSystemUser();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 30);
				sqlParameter.Value = WorkingSemesters.GetWorkingSemester();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@CreateDate", SqlDbType.DateTime);
				sqlParameter.Value = DateTime.Now.ToLongDateString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@PassType", SqlDbType.VarChar, 50);
				sqlParameter.Value = passType;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Pic", SqlDbType.Image);
				sqlParameter.Value = array;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Sex", SqlDbType.VarChar, 1);
				sqlParameter.Value = _sex;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@amount", SqlDbType.Money);
				sqlParameter.Value = _amount;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@amountInWords", SqlDbType.VarChar);
				sqlParameter.Value = _amountInWords;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	public static void ShowFeesGatePass()
	{
		try
		{
			int num = 0;
			using (SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT MAX (passNo) AS PassNumber FROM tbl_GatePass", selectConnection);
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "GatePass");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					num = Convert.ToInt32(row["PassNumber"].ToString());
				}
			}
			using gatePass gatePass2 = new gatePass();
			gatePass2.PassNos.Value = num;
			gatePass2.PassNos.Visible = false;
			ReportPrintTool reportPrintTool = new ReportPrintTool(gatePass2);
			reportPrintTool.ShowRibbonPreviewDialog();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	public static void ShowMedicalGatePass()
	{
		try
		{
			int num = 0;
			using (SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT MAX (passNo) AS PassNumber FROM tbl_GatePass", selectConnection);
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "GatePass");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					num = Convert.ToInt32(row["PassNumber"].ToString());
				}
			}
			using gatePass_Medical gatePass_Medical2 = new gatePass_Medical();
			gatePass_Medical2.PassNos2.Value = num;
			gatePass_Medical2.PassNos2.Visible = false;
			ReportPrintTool reportPrintTool = new ReportPrintTool(gatePass_Medical2);
			reportPrintTool.ShowRibbonPreviewDialog();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}
}
