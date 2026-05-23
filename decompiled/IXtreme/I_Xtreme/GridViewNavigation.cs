namespace I_Xtreme;

internal class GridViewNavigation
{
	public static void NavigateForward()
	{
		PrintableControl.GridViewControl.FocusedRowHandle = PrintableControl.GridViewControl.FocusedRowHandle + 1;
	}

	public static void NavigateBack()
	{
		PrintableControl.GridViewControl.FocusedRowHandle = PrintableControl.GridViewControl.FocusedRowHandle - 1;
	}
}
