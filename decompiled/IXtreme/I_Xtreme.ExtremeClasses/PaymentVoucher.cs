namespace I_Xtreme.ExtremeClasses;

internal class PaymentVoucher
{
	public static string VoucherNo { get; set; }

	public static long VoucherTotal { get; set; }

	public static void SetVoucherInformation(string _VoucherNo, long _VoucherTotal)
	{
		VoucherNo = _VoucherNo;
		VoucherTotal = _VoucherTotal;
	}
}
