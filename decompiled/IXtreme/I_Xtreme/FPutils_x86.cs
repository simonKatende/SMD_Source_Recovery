using System;
using System.Runtime.InteropServices;

namespace I_Xtreme;

internal class FPutils_x86
{
	[DllImport("FPModule_SDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int FPModule_OpenDevice();

	[DllImport("FPModule_SDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int FPModule_CloseDevice();

	[DllImport("FPModule_SDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int FPModule_DetectFinger(ref int pdwFpstatus);

	[DllImport("FPModule_SDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int FPModule_CaptureImage(byte[] pbyImageData, ref int pdwWidth, ref int pdwHeight);

	[DllImport("FPModule_SDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int FPModule_SetTimeout(int dwSecond);

	[DllImport("FPModule_SDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int FPModule_GetTimeout(ref int pdwSecond);

	[DllImport("FPModule_SDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int FPModule_SetCollectTimes(int dwTimes);

	[DllImport("FPModule_SDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int FPModule_GetCollectTimes(ref int pdwTimes);

	[DllImport("FPModule_SDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int FPModule_InstallMessageHandler(FPMsg.FpMessageHandler msgHandler);

	[DllImport("FPModule_SDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int FPModule_FpEnroll(byte[] pbyFpTemplate);

	[DllImport("FPModule_SDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int FPModule_GetQuality(byte[] pbyFpTemplate);

	[DllImport("FPModule_SDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int FPModule_MatchTemplate(byte[] pbyFpTemplate1, byte[] pbyFpTemplate2, int dwSecurityLevel);

	[DllImport("FPModule_SDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int FPModule_GetDeviceInfo(byte[] pbyDeviceInfo);

	[DllImport("FPModule_SDK.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int FPModule_GetSDKVersion(byte[] pbySDKVersion);

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
