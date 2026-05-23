namespace I_Xtreme.Taxes;

internal class TaxCalculations
{
	private static double withHoldingTax { get; set; }

	private static bool deductWithHoldingTax { get; set; }

	private static double WithHoldingTaxPercentage => withHoldingTax;

	public static bool DeductWithHoldingTax => deductWithHoldingTax;

	public static double WithHoldingTax(double totalAmount)
	{
		return WithHoldingTaxPercentage / 100.0 * totalAmount;
	}

	public static string TaxName()
	{
		return "WithHoldingTax";
	}
}
