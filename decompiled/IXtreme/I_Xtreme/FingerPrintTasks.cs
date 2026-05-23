using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using I_Xtreme.Properties;

namespace I_Xtreme;

public class FingerPrintTasks : XtraForm
{
	private int capturedInt = 0;

	private int iRet = FPutils.FP_SUCCESS;

	private int index = 0;

	private byte[] image = new byte[FPutils.FP_IMAGE_WIDTH * FPutils.FP_IMAGE_HEIGHT];

	private byte[] bmp = new byte[FPutils.FP_IMAGE_WIDTH * FPutils.FP_IMAGE_HEIGHT + FPutils.FP_BMP_HEADER];

	private byte[] tempArray = new byte[FPutils.FP_FTP_MAX * 5000];

	private int nTemp = 0;

	private static FPMsg.FpMessageHandler FpMessageHandler;

	private string studentno = string.Empty;

	private SqlTransaction trans;

	private SqlConnection con;

	private IContainer components = null;

	private SimpleButton FPModule_MatchTemplate;

	private Label MsgBox;

	private PictureBox fpImageBox;

	private SimpleButton FPModule_GetTimeout;

	private SimpleButton FPModule_FpEnroll;

	private SimpleButton FPModule_CaptureImage;

	private SimpleButton FPModule_DetectFinger;

	private SimpleButton FPModule_SetTimeout;

	private SimpleButton FPModule_GetDeviceInfo;

	private SimpleButton FPModule_GetSDKVersion;

	private SimpleButton FPModule_CloseDevice;

	private SimpleButton FPModule_OpenDevice;

	private ComboBoxEdit cboDeviceInfo;

	private Label label1;

	public FingerPrintTasks(string _studentno)
	{
		InitializeComponent();
		FpMessageHandler = FpMessageCallback;
		FPutils.FPModule_InstallMessageHandler(FpMessageHandler);
		GC.KeepAlive(FpMessageHandler);
		studentno = _studentno;
		con = new SqlConnection(DataConnection.ConnectToDatabase());
		OpenDevice();
		GetDeviceInformation();
	}

	private bool AlreadyCaptured()
	{
		con.Open();
		bool result = false;
		SqlCommand sqlCommand = new SqlCommand
		{
			Connection = con,
			CommandText = "SELECT StudentNumber,BiometricData FROM tbl_Stud WHERE (BiometricData IS NOT NULL OR BiometricData<>'' ) AND StudentNumber='" + studentno + "'",
			CommandType = CommandType.Text
		};
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		try
		{
			if (sqlDataReader.HasRows)
			{
				if (sqlDataReader.Read())
				{
					result = true;
					capturedInt = (int)sqlDataReader["BiometricData"];
				}
			}
			else
			{
				result = false;
			}
		}
		catch
		{
		}
		finally
		{
			sqlDataReader.Close();
			con.Close();
		}
		return result;
	}

	private void FpMessageCallback(FPMsg.FP_MSG_TYPE_T enMsgType, IntPtr pMsgData)
	{
		switch (enMsgType)
		{
		case FPMsg.FP_MSG_TYPE_T.FP_MSG_RISE_FINGER:
			MsgBox.Text = "Lift and rest your finger";
			break;
		case FPMsg.FP_MSG_TYPE_T.FP_MSG_PRESS_FINGER:
			MsgBox.Text = "Place Your Finger";
			break;
		case FPMsg.FP_MSG_TYPE_T.FP_MSG_ENROLL_TIME:
		{
			int[] array = new int[1];
			Marshal.Copy(pMsgData, array, 0, 1);
			MsgBox.Text = "Enroll Time" + array[0];
			index = array[0];
			break;
		}
		case FPMsg.FP_MSG_TYPE_T.FP_MSG_CAPTURED_IMAGE:
		{
			object obj = Marshal.PtrToStructure(pMsgData, typeof(FPutils.FP_IMAGE_DATA));
			FPutils.FP_IMAGE_DATA fP_IMAGE_DATA = (FPutils.FP_IMAGE_DATA)obj;
			Marshal.Copy(fP_IMAGE_DATA.pbyImage, this.image, 0, fP_IMAGE_DATA.dwWidth * fP_IMAGE_DATA.dwHeight);
			FPutils.ImgBufferToBmpBuffer(this.image, fP_IMAGE_DATA.dwWidth, fP_IMAGE_DATA.dwHeight, bmp);
			MemoryStream memoryStream = new MemoryStream(bmp, writable: true);
			memoryStream.Position = 0L;
			Image image = Image.FromStream(memoryStream);
			image.Save(Application.StartupPath + "//Enroll" + index + ".bmp");
			fpImageBox.Image = image;
			break;
		}
		}
		Application.DoEvents();
	}

	private void GetFingerPrintData()
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandType = CommandType.Text,
			CommandText = "SELECT FingerData,DataCount FROM FingerArchive WHERE Id='xyz'"
		};
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		if (!sqlDataReader.HasRows)
		{
			nTemp = 0;
			tempArray = new byte[FPutils.FP_FTP_MAX * 5000];
		}
		else if (sqlDataReader.Read())
		{
			nTemp = (int)sqlDataReader["DataCount"];
			tempArray = (byte[])sqlDataReader["FingerData"];
		}
	}

	private void SaveTemp(byte[] szTmp, int count, byte[] studData)
	{
		using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
		{
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandType = CommandType.Text,
				CommandText = "SELECT * FROM FingerArchive WHERE Id='xyz'"
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (!sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				trans = sqlConnection.BeginTransaction();
				using SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandType = CommandType.Text,
					CommandText = "INSERT INTO FingerArchive (Id,FingerData,DataCount) VALUES (@Id,@FingerData,@DataCount)"
				};
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@Id", SqlDbType.VarChar, 3);
				sqlParameter.Value = "xyz";
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@FingerData", SqlDbType.VarBinary);
				sqlParameter.Value = szTmp;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@DataCount", SqlDbType.Int);
				sqlParameter.Value = count;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			else
			{
				sqlDataReader.Close();
				trans = sqlConnection.BeginTransaction();
				using SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandType = CommandType.Text,
					CommandText = "UPDATE FingerArchive SET FingerData=@FingerData,DataCount=@DataCount WHERE Id=@Id"
				};
				SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@Id", SqlDbType.VarChar, 3);
				sqlParameter2.Value = "xyz";
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand3.Parameters.Add("@FingerData", SqlDbType.VarBinary);
				sqlParameter2.Value = szTmp;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand3.Parameters.Add("@DataCount", SqlDbType.Int);
				sqlParameter2.Value = count;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand3.ExecuteNonQuery();
			}
			using SqlCommand sqlCommand4 = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandType = CommandType.Text,
				CommandText = "UPDATE tbl_Stud SET BiometricData=@BiometricData,FingerData=@FingerData WHERE StudentNumber=@StudentNumber"
			};
			SqlParameter sqlParameter3 = sqlCommand4.Parameters.Add("@BiometricData", SqlDbType.Int);
			sqlParameter3.Value = count;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand4.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 20);
			sqlParameter3.Value = studentno;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand4.Parameters.Add("@FingerData", SqlDbType.VarBinary);
			sqlParameter3.Value = studData;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlCommand4.ExecuteNonQuery();
			trans.Commit();
			sqlConnection.Close();
		}
		GetFingerPrintData();
	}

	public KeyValuePair<string, string> ValidateStudent(int fingerid)
	{
		KeyValuePair<string, string> result = new KeyValuePair<string, string>("", "Not Found");
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandType = CommandType.Text,
			CommandText = "SELECT fullName,StudentNumber FROM tbl_Stud WHERE BiometricData=" + fingerid
		};
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		if (sqlDataReader.HasRows)
		{
			if (sqlDataReader.Read())
			{
				result = new KeyValuePair<string, string>(sqlDataReader["StudentNumber"].ToString(), sqlDataReader["fullName"].ToString());
			}
			sqlConnection.Close();
		}
		return result;
	}

	private void OpenDevice()
	{
		iRet = FPutils.FPModule_OpenDevice();
		if (iRet == FPutils.FP_SUCCESS)
		{
			MsgBox.Text = "OpenDevice OK";
		}
		else
		{
			XtraMessageBox.Show("Fingerprint reader not detected", "Open device failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void FPModule_OpenDevice_Click(object sender, EventArgs e)
	{
		OpenDevice();
	}

	private void FPModule_GetSDKVersion_Click(object sender, EventArgs e)
	{
		byte[] array = new byte[64];
		iRet = FPutils.FPModule_GetSDKVersion(array);
		if (iRet == FPutils.FP_SUCCESS)
		{
			MsgBox.Text = Encoding.Default.GetString(array);
		}
		else
		{
			XtraMessageBox.Show("GetSDKVersion failed");
		}
	}

	private void GetDeviceInformation()
	{
		byte[] array = new byte[64];
		iRet = FPutils.FPModule_GetDeviceInfo(array);
		if (iRet == FPutils.FP_SUCCESS)
		{
			cboDeviceInfo.Properties.Items.Add(Encoding.Default.GetString(array));
			cboDeviceInfo.SelectedIndex = 0;
		}
		else
		{
			cboDeviceInfo.Properties.Items.Add("GetDeviceInfo failed");
			cboDeviceInfo.SelectedIndex = 0;
		}
	}

	private void FPModule_GetDeviceInfo_Click(object sender, EventArgs e)
	{
		byte[] array = new byte[64];
		iRet = FPutils.FPModule_GetDeviceInfo(array);
		if (iRet == FPutils.FP_SUCCESS)
		{
			MsgBox.Text = Encoding.Default.GetString(array);
		}
		else
		{
			XtraMessageBox.Show("GetDeviceInfo failed");
		}
	}

	private void FPModule_SetTimeout_Click(object sender, EventArgs e)
	{
		iRet = FPutils.FPModule_SetTimeout(15);
		if (iRet == FPutils.FP_SUCCESS)
		{
			MsgBox.Text = "SetTimeout success:" + 15 + "s";
		}
		else
		{
			XtraMessageBox.Show("SetTimeout failed");
		}
	}

	private void FPModule_GetTimeout_Click(object sender, EventArgs e)
	{
		int pdwSecond = 0;
		iRet = FPutils.FPModule_GetTimeout(ref pdwSecond);
		if (iRet == FPutils.FP_SUCCESS)
		{
			MsgBox.Text = "GetTimeout success:" + pdwSecond + "s";
		}
		else
		{
			XtraMessageBox.Show("GetTimeout failed");
		}
	}

	private void FPModule_DetectFinger_Click(object sender, EventArgs e)
	{
		int pdwFpstatus = 0;
		iRet = FPutils.FPModule_DetectFinger(ref pdwFpstatus);
		if (iRet == FPutils.FP_SUCCESS)
		{
			MsgBox.Text = "DetectFinger success:" + pdwFpstatus;
		}
		else
		{
			XtraMessageBox.Show("DetectFinger failed");
		}
	}

	private void FPModule_CaptureImage_Click(object sender, EventArgs e)
	{
		int pdwWidth = 0;
		int pdwHeight = 0;
		iRet = FPutils.FPModule_CaptureImage(this.image, ref pdwWidth, ref pdwHeight);
		if (iRet == FPutils.FP_SUCCESS)
		{
			FPutils.ImgBufferToBmpBuffer(this.image, pdwWidth, pdwHeight, bmp);
			MemoryStream memoryStream = new MemoryStream(bmp, writable: true);
			memoryStream.Position = 0L;
			Image image = Image.FromStream(memoryStream);
			image.Save(Application.StartupPath + "//CaptureImage.bmp");
			fpImageBox.Image = image;
		}
		else
		{
			XtraMessageBox.Show("CaptureImage failed");
		}
	}

	private void FPModule_FpEnroll_Click(object sender, EventArgs e)
	{
		GetFingerPrintData();
		if (AlreadyCaptured())
		{
			int num = capturedInt;
			int fP_FTP_MAX = FPutils.FP_FTP_MAX;
			int num2 = tempArray.Length - fP_FTP_MAX;
			byte[] destinationArray = new byte[num2];
			Array.Copy(tempArray, 0, destinationArray, 0, num);
			Array.Copy(tempArray, num + fP_FTP_MAX, destinationArray, num, tempArray.Length - (num + fP_FTP_MAX));
			nTemp--;
		}
		FPModule_FpEnroll.Text = "Enrolling...";
		FPModule_FpEnroll.Enabled = false;
		Application.DoEvents();
		byte[] array = new byte[FPutils.FP_FTP_MAX];
		FPutils.FPModule_SetCollectTimes(3);
		iRet = FPutils.FPModule_FpEnroll(array);
		if (iRet == FPutils.FP_SUCCESS)
		{
			Buffer.BlockCopy(array, 0, tempArray, nTemp * FPutils.FP_FTP_MAX, FPutils.FP_FTP_MAX);
			FPModule_FpEnroll.Text = "Saving data...";
			FPModule_FpEnroll.Enabled = false;
			Application.DoEvents();
			SaveTemp(tempArray, nTemp + 1, array);
			Dispose();
		}
		else
		{
			XtraMessageBox.Show("FpEnroll failed");
			FPModule_FpEnroll.Text = "Start Enroll";
			FPModule_FpEnroll.Enabled = true;
			fpImageBox.Image = Resources.backup;
		}
	}

	private void FPModule_MatchTemplate_Click(object sender, EventArgs e)
	{
		byte[] array = new byte[FPutils.FP_FTP_MAX];
		byte[] array2 = new byte[FPutils.FP_FTP_MAX];
		GetFingerPrintData();
		FPutils.FPModule_SetCollectTimes(1);
		iRet = FPutils.FPModule_FpEnroll(array);
		if (iRet == FPutils.FP_SUCCESS)
		{
			for (int i = 0; i < nTemp; i++)
			{
				Buffer.BlockCopy(tempArray, i * FPutils.FP_FTP_MAX, array2, 0, FPutils.FP_FTP_MAX);
				if (FPutils.FPModule_MatchTemplate(array, array2, 3) == FPutils.FP_SUCCESS)
				{
					KeyValuePair<string, string> keyValuePair = ValidateStudent(i);
					MsgBox.Text = "Name: " + keyValuePair.Value + ", StudentNo: " + keyValuePair.Key;
					fpImageBox.Image = Resources.backup;
					return;
				}
			}
			MsgBox.Text = "MatchTemplate failed";
			fpImageBox.Image = Resources.backup;
		}
		else
		{
			XtraMessageBox.Show("MatchTemplate failed");
			fpImageBox.Image = Resources.backup;
		}
	}

	private void CloseDevice()
	{
		iRet = FPutils.FPModule_CloseDevice();
	}

	private void FPModule_CloseDevice_Click(object sender, EventArgs e)
	{
		iRet = FPutils.FPModule_CloseDevice();
		if (iRet == FPutils.FP_SUCCESS)
		{
			MsgBox.Text = "CloseDevice success";
		}
		else
		{
			XtraMessageBox.Show("CloseDevice failed");
		}
	}

	private void FingerPrintTasks_FormClosing(object sender, FormClosingEventArgs e)
	{
		CloseDevice();
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
		this.FPModule_MatchTemplate = new DevExpress.XtraEditors.SimpleButton();
		this.MsgBox = new System.Windows.Forms.Label();
		this.fpImageBox = new System.Windows.Forms.PictureBox();
		this.FPModule_GetTimeout = new DevExpress.XtraEditors.SimpleButton();
		this.FPModule_FpEnroll = new DevExpress.XtraEditors.SimpleButton();
		this.FPModule_CaptureImage = new DevExpress.XtraEditors.SimpleButton();
		this.FPModule_DetectFinger = new DevExpress.XtraEditors.SimpleButton();
		this.FPModule_SetTimeout = new DevExpress.XtraEditors.SimpleButton();
		this.FPModule_GetDeviceInfo = new DevExpress.XtraEditors.SimpleButton();
		this.FPModule_GetSDKVersion = new DevExpress.XtraEditors.SimpleButton();
		this.FPModule_CloseDevice = new DevExpress.XtraEditors.SimpleButton();
		this.FPModule_OpenDevice = new DevExpress.XtraEditors.SimpleButton();
		this.cboDeviceInfo = new DevExpress.XtraEditors.ComboBoxEdit();
		this.label1 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.fpImageBox).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboDeviceInfo.Properties).BeginInit();
		base.SuspendLayout();
		this.FPModule_MatchTemplate.Appearance.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FPModule_MatchTemplate.Appearance.Options.UseFont = true;
		this.FPModule_MatchTemplate.Location = new System.Drawing.Point(12, 151);
		this.FPModule_MatchTemplate.Name = "FPModule_MatchTemplate";
		this.FPModule_MatchTemplate.Size = new System.Drawing.Size(264, 39);
		this.FPModule_MatchTemplate.TabIndex = 24;
		this.FPModule_MatchTemplate.Text = "FPModule_MatchTemplate";
		this.FPModule_MatchTemplate.Visible = false;
		this.FPModule_MatchTemplate.Click += new System.EventHandler(FPModule_MatchTemplate_Click);
		this.MsgBox.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.MsgBox.ForeColor = System.Drawing.Color.Blue;
		this.MsgBox.Location = new System.Drawing.Point(296, 364);
		this.MsgBox.Name = "MsgBox";
		this.MsgBox.Size = new System.Drawing.Size(260, 96);
		this.MsgBox.TabIndex = 23;
		this.MsgBox.Text = "Welcome";
		this.MsgBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.fpImageBox.Image = I_Xtreme.Properties.Resources.backup;
		this.fpImageBox.Location = new System.Drawing.Point(299, 33);
		this.fpImageBox.Name = "fpImageBox";
		this.fpImageBox.Size = new System.Drawing.Size(257, 312);
		this.fpImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.fpImageBox.TabIndex = 22;
		this.fpImageBox.TabStop = false;
		this.FPModule_GetTimeout.Appearance.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FPModule_GetTimeout.Appearance.Options.UseFont = true;
		this.FPModule_GetTimeout.Location = new System.Drawing.Point(12, 376);
		this.FPModule_GetTimeout.Name = "FPModule_GetTimeout";
		this.FPModule_GetTimeout.Size = new System.Drawing.Size(103, 39);
		this.FPModule_GetTimeout.TabIndex = 21;
		this.FPModule_GetTimeout.Text = "FPModule_GetTimeout";
		this.FPModule_GetTimeout.Visible = false;
		this.FPModule_GetTimeout.Click += new System.EventHandler(FPModule_GetTimeout_Click);
		this.FPModule_FpEnroll.Appearance.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FPModule_FpEnroll.Appearance.Options.UseFont = true;
		this.FPModule_FpEnroll.Location = new System.Drawing.Point(12, 93);
		this.FPModule_FpEnroll.Name = "FPModule_FpEnroll";
		this.FPModule_FpEnroll.Size = new System.Drawing.Size(264, 29);
		this.FPModule_FpEnroll.TabIndex = 20;
		this.FPModule_FpEnroll.Text = "Start Enroll";
		this.FPModule_FpEnroll.Click += new System.EventHandler(FPModule_FpEnroll_Click);
		this.FPModule_CaptureImage.Appearance.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FPModule_CaptureImage.Appearance.Options.UseFont = true;
		this.FPModule_CaptureImage.Location = new System.Drawing.Point(121, 376);
		this.FPModule_CaptureImage.Name = "FPModule_CaptureImage";
		this.FPModule_CaptureImage.Size = new System.Drawing.Size(155, 39);
		this.FPModule_CaptureImage.TabIndex = 19;
		this.FPModule_CaptureImage.Text = "FPModule_CaptureImage";
		this.FPModule_CaptureImage.Visible = false;
		this.FPModule_CaptureImage.Click += new System.EventHandler(FPModule_CaptureImage_Click);
		this.FPModule_DetectFinger.Appearance.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FPModule_DetectFinger.Appearance.Options.UseFont = true;
		this.FPModule_DetectFinger.Location = new System.Drawing.Point(12, 421);
		this.FPModule_DetectFinger.Name = "FPModule_DetectFinger";
		this.FPModule_DetectFinger.Size = new System.Drawing.Size(103, 39);
		this.FPModule_DetectFinger.TabIndex = 18;
		this.FPModule_DetectFinger.Text = "FPModule_DetectFinger";
		this.FPModule_DetectFinger.Visible = false;
		this.FPModule_DetectFinger.Click += new System.EventHandler(FPModule_DetectFinger_Click);
		this.FPModule_SetTimeout.Appearance.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FPModule_SetTimeout.Appearance.Options.UseFont = true;
		this.FPModule_SetTimeout.Location = new System.Drawing.Point(12, 331);
		this.FPModule_SetTimeout.Name = "FPModule_SetTimeout";
		this.FPModule_SetTimeout.Size = new System.Drawing.Size(264, 39);
		this.FPModule_SetTimeout.TabIndex = 17;
		this.FPModule_SetTimeout.Text = "FPModule_SetTimeout";
		this.FPModule_SetTimeout.Visible = false;
		this.FPModule_SetTimeout.Click += new System.EventHandler(FPModule_SetTimeout_Click);
		this.FPModule_GetDeviceInfo.Appearance.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FPModule_GetDeviceInfo.Appearance.Options.UseFont = true;
		this.FPModule_GetDeviceInfo.Location = new System.Drawing.Point(12, 286);
		this.FPModule_GetDeviceInfo.Name = "FPModule_GetDeviceInfo";
		this.FPModule_GetDeviceInfo.Size = new System.Drawing.Size(264, 39);
		this.FPModule_GetDeviceInfo.TabIndex = 16;
		this.FPModule_GetDeviceInfo.Text = "FPModule_GetDeviceInfo";
		this.FPModule_GetDeviceInfo.Visible = false;
		this.FPModule_GetDeviceInfo.Click += new System.EventHandler(FPModule_GetDeviceInfo_Click);
		this.FPModule_GetSDKVersion.Appearance.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FPModule_GetSDKVersion.Appearance.Options.UseFont = true;
		this.FPModule_GetSDKVersion.Location = new System.Drawing.Point(12, 241);
		this.FPModule_GetSDKVersion.Name = "FPModule_GetSDKVersion";
		this.FPModule_GetSDKVersion.Size = new System.Drawing.Size(264, 39);
		this.FPModule_GetSDKVersion.TabIndex = 15;
		this.FPModule_GetSDKVersion.Text = "FPModule_GetSDKVersion";
		this.FPModule_GetSDKVersion.Visible = false;
		this.FPModule_GetSDKVersion.Click += new System.EventHandler(FPModule_GetSDKVersion_Click);
		this.FPModule_CloseDevice.Appearance.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FPModule_CloseDevice.Appearance.Options.UseFont = true;
		this.FPModule_CloseDevice.Location = new System.Drawing.Point(121, 421);
		this.FPModule_CloseDevice.Name = "FPModule_CloseDevice";
		this.FPModule_CloseDevice.Size = new System.Drawing.Size(155, 39);
		this.FPModule_CloseDevice.TabIndex = 14;
		this.FPModule_CloseDevice.Text = "FPModule_CloseDevice";
		this.FPModule_CloseDevice.Visible = false;
		this.FPModule_CloseDevice.Click += new System.EventHandler(FPModule_CloseDevice_Click);
		this.FPModule_OpenDevice.Appearance.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FPModule_OpenDevice.Appearance.Options.UseFont = true;
		this.FPModule_OpenDevice.Location = new System.Drawing.Point(12, 196);
		this.FPModule_OpenDevice.Name = "FPModule_OpenDevice";
		this.FPModule_OpenDevice.Size = new System.Drawing.Size(264, 39);
		this.FPModule_OpenDevice.TabIndex = 13;
		this.FPModule_OpenDevice.Text = "FPModule_OpenDevice";
		this.FPModule_OpenDevice.Visible = false;
		this.FPModule_OpenDevice.Click += new System.EventHandler(FPModule_OpenDevice_Click);
		this.cboDeviceInfo.Location = new System.Drawing.Point(12, 63);
		this.cboDeviceInfo.Name = "cboDeviceInfo";
		this.cboDeviceInfo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.cboDeviceInfo.Properties.Appearance.Options.UseFont = true;
		this.cboDeviceInfo.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11f);
		this.cboDeviceInfo.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboDeviceInfo.Size = new System.Drawing.Size(264, 24);
		this.cboDeviceInfo.TabIndex = 25;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Tahoma", 11f);
		this.label1.Location = new System.Drawing.Point(12, 33);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(132, 18);
		this.label1.TabIndex = 26;
		this.label1.Text = "Device Information";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(589, 475);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.cboDeviceInfo);
		base.Controls.Add(this.FPModule_MatchTemplate);
		base.Controls.Add(this.MsgBox);
		base.Controls.Add(this.fpImageBox);
		base.Controls.Add(this.FPModule_GetTimeout);
		base.Controls.Add(this.FPModule_FpEnroll);
		base.Controls.Add(this.FPModule_CaptureImage);
		base.Controls.Add(this.FPModule_DetectFinger);
		base.Controls.Add(this.FPModule_SetTimeout);
		base.Controls.Add(this.FPModule_GetDeviceInfo);
		base.Controls.Add(this.FPModule_GetSDKVersion);
		base.Controls.Add(this.FPModule_CloseDevice);
		base.Controls.Add(this.FPModule_OpenDevice);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FingerPrintTasks";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Capture Fingerprint";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FingerPrintTasks_FormClosing);
		((System.ComponentModel.ISupportInitialize)this.fpImageBox).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboDeviceInfo.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
