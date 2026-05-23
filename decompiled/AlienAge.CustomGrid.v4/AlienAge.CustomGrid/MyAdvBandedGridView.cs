using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace AlienAge.CustomGrid;

public class MyAdvBandedGridView : AdvBandedGridView
{
	protected override string ViewName => "MyAdvBandedGridView";

	public MyAdvBandedGridView()
		: this(null)
	{
	}

	public MyAdvBandedGridView(GridControl grid)
		: base(grid)
	{
	}
}
