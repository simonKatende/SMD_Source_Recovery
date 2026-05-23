using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace AlienAge.CustomGrid;

public class MyBandedGridView : BandedGridView
{
	protected override string ViewName => "MyBandedGridView";

	public MyBandedGridView()
		: this(null)
	{
	}

	public MyBandedGridView(GridControl grid)
		: base(grid)
	{
	}
}
