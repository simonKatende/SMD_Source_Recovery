using System;

namespace I_Xtreme;

internal class FPutils
{
	public struct FP_IMAGE_DATA
	{
		public int dwWidth;

		public int dwHeight;

		public IntPtr pbyImage;
	}

	public static int FP_SUCCESS = 0;

	public static int FP_CONNECTION_ERR = 1;

	public static int FP_TIMEOUT = 2;

	public static int FP_ENROLL_FAIL = 3;

	public static int FP_PARAM_ERR = 4;

	public static int FP_EXTRACT_FAIL = 5;

	public static int FP_MATCH_FAIL = 6;

	public static int FP_FTP_MAX = 512;

	public static int FP_IMAGE_WIDTH = 256;

	public static int FP_IMAGE_HEIGHT = 360;

	public static int FP_BMP_HEADER = 1078;

	public static int FPModule_OpenDevice()
	{
		if (IntPtr.Size == 4)
		{
			return FPutils_x86.FPModule_OpenDevice();
		}
		return FPutils_x64.FPModule_OpenDevice();
	}

	public static int FPModule_CloseDevice()
	{
		if (IntPtr.Size == 4)
		{
			return FPutils_x86.FPModule_CloseDevice();
		}
		return FPutils_x64.FPModule_CloseDevice();
	}

	public static int FPModule_DetectFinger(ref int pdwFpstatus)
	{
		if (IntPtr.Size == 4)
		{
			return FPutils_x86.FPModule_DetectFinger(ref pdwFpstatus);
		}
		return FPutils_x64.FPModule_DetectFinger(ref pdwFpstatus);
	}

	public static int FPModule_CaptureImage(byte[] pbyImageData, ref int pdwWidth, ref int pdwHeight)
	{
		if (IntPtr.Size == 4)
		{
			return FPutils_x86.FPModule_CaptureImage(pbyImageData, ref pdwWidth, ref pdwHeight);
		}
		return FPutils_x64.FPModule_CaptureImage(pbyImageData, ref pdwWidth, ref pdwHeight);
	}

	public static int FPModule_SetTimeout(int dwSecond)
	{
		if (IntPtr.Size == 4)
		{
			return FPutils_x86.FPModule_SetTimeout(dwSecond);
		}
		return FPutils_x64.FPModule_SetTimeout(dwSecond);
	}

	public static int FPModule_GetTimeout(ref int pdwSecond)
	{
		if (IntPtr.Size == 4)
		{
			return FPutils_x86.FPModule_GetTimeout(ref pdwSecond);
		}
		return FPutils_x64.FPModule_GetTimeout(ref pdwSecond);
	}

	public static int FPModule_SetCollectTimes(int dwTimes)
	{
		if (IntPtr.Size == 4)
		{
			return FPutils_x86.FPModule_SetCollectTimes(dwTimes);
		}
		return FPutils_x64.FPModule_SetCollectTimes(dwTimes);
	}

	public static int FPModule_GetCollectTimes(ref int pdwTimes)
	{
		if (IntPtr.Size == 4)
		{
			return FPutils_x86.FPModule_GetCollectTimes(ref pdwTimes);
		}
		return FPutils_x64.FPModule_GetCollectTimes(ref pdwTimes);
	}

	public static int FPModule_InstallMessageHandler(FPMsg.FpMessageHandler msgHandler)
	{
		if (IntPtr.Size == 4)
		{
			return FPutils_x86.FPModule_InstallMessageHandler(msgHandler);
		}
		return FPutils_x64.FPModule_InstallMessageHandler(msgHandler);
	}

	public static int FPModule_FpEnroll(byte[] pbyFpTemplate)
	{
		if (IntPtr.Size == 4)
		{
			return FPutils_x86.FPModule_FpEnroll(pbyFpTemplate);
		}
		return FPutils_x64.FPModule_FpEnroll(pbyFpTemplate);
	}

	public static int FPModule_GetQuality(byte[] pbyFpTemplate)
	{
		if (IntPtr.Size == 4)
		{
			return FPutils_x86.FPModule_GetQuality(pbyFpTemplate);
		}
		return FPutils_x64.FPModule_GetQuality(pbyFpTemplate);
	}

	public static int FPModule_MatchTemplate(byte[] pbyFpTemplate1, byte[] pbyFpTemplate2, int dwSecurityLevel)
	{
		if (IntPtr.Size == 4)
		{
			return FPutils_x86.FPModule_MatchTemplate(pbyFpTemplate1, pbyFpTemplate2, dwSecurityLevel);
		}
		return FPutils_x64.FPModule_MatchTemplate(pbyFpTemplate1, pbyFpTemplate2, dwSecurityLevel);
	}

	public static int FPModule_GetDeviceInfo(byte[] pbyDeviceInfo)
	{
		if (IntPtr.Size == 4)
		{
			return FPutils_x86.FPModule_GetDeviceInfo(pbyDeviceInfo);
		}
		return FPutils_x64.FPModule_GetDeviceInfo(pbyDeviceInfo);
	}

	public static int FPModule_GetSDKVersion(byte[] pbySDKVersion)
	{
		if (IntPtr.Size == 4)
		{
			return FPutils_x86.FPModule_GetSDKVersion(pbySDKVersion);
		}
		return FPutils_x64.FPModule_GetSDKVersion(pbySDKVersion);
	}

	public static int ImgBufferToBmpBuffer(byte[] src, int X, int Y, byte[] des)
	{
		byte[] array = new byte[1100];
		byte[] array2 = new byte[58]
		{
			66, 77, 0, 0, 0, 0, 0, 0, 0, 0,
			54, 4, 0, 0, 40, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 1, 0, 8, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0
		};
		int num = array2.Length;
		Buffer.BlockCopy(array2, 0, array, 0, array2.Length);
		int num2 = X;
		array[18] = (byte)((uint)num2 & 0xFFu);
		num2 >>= 8;
		array[19] = (byte)((uint)num2 & 0xFFu);
		num2 >>= 8;
		array[20] = (byte)((uint)num2 & 0xFFu);
		num2 >>= 8;
		array[21] = (byte)((uint)num2 & 0xFFu);
		num2 = Y;
		array[22] = (byte)((uint)num2 & 0xFFu);
		num2 >>= 8;
		array[23] = (byte)((uint)num2 & 0xFFu);
		num2 >>= 8;
		array[24] = (byte)((uint)num2 & 0xFFu);
		num2 >>= 8;
		array[25] = (byte)((uint)num2 & 0xFFu);
		int num3 = 0;
		for (int i = 54; i < 1078; i += 4)
		{
			array[i] = (array[i + 1] = (array[i + 2] = (byte)num3));
			array[i + 3] = 0;
			num3++;
		}
		Buffer.BlockCopy(array, 0, des, 0, 1078);
		for (int i = 0; i < Y; i++)
		{
			Buffer.BlockCopy(src, i * X, des, 1078 + (Y - 1 - i) * X, X);
		}
		return 1;
	}
}
