using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;

namespace AlienAge.CustomGrid;

public class MyAdvBandedGridViewInfoRegistrator : AdvBandedGridInfoRegistrator
{
	public override string ViewName => "MyAdvBandedGridView";

	public override BaseView CreateView(GridControl grid)
	{
		return new MyAdvBandedGridView(grid);
	}

	public override BaseViewPainter CreatePainter(BaseView view)
	{
		return new MyAdvBandedGridPainter(view as MyAdvBandedGridView);
	}
}
