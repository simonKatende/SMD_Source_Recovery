using System;

namespace I_Xtreme.Models;

public class FeesPayment
{
	public long PaymentId { get; set; }

	public decimal? AmountBilled { get; set; }

	public decimal? AmountPaid { get; set; }

	public string Particulars { get; set; }

	public string SchoolRef { get; set; }

	public string StudentNo { get; set; }

	public string Lin { get; set; }

	public string TelcomCarrier { get; set; }

	public string TransactionRef { get; set; }

	public Guid? TransactionUniqueId { get; set; }

	public DateTime? TrxDate { get; set; }

	public bool? IsSynched { get; set; }

	public string Name { get; set; }

	public string Term { get; set; }

	public string StudentClass { get; set; }

	public string StudentStream { get; set; }

	public bool? TrxDropped { get; set; }

	public bool? IsAdjusted { get; set; }

	public decimal? OldBill { get; set; }

	public string AdjustmentParticular { get; set; }

	public string AdjustedBy { get; set; }

	public DateTime? AdjustmentDate { get; set; }

	public long? LocalPaymentId { get; set; }
}
