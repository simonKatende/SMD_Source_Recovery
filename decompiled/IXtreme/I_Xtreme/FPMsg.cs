using System;
using System.Runtime.InteropServices;

namespace I_Xtreme;

internal class FPMsg
{
	public enum FP_MSG_TYPE_T
	{
		FP_MSG_PRESS_FINGER,
		FP_MSG_RISE_FINGER,
		FP_MSG_ENROLL_TIME,
		FP_MSG_CAPTURED_IMAGE
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void FpMessageHandler(FP_MSG_TYPE_T enMsgType, IntPtr pMsgData);
}
