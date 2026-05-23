using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;

namespace AlienAge.CustomGrid;

public class MyBandedGridViewInfoRegistrator : BandedGridInfoRegistrator
{
	public override string ViewName => "MyBandedGridView";

	public override BaseView CreateView(GridControl grid)
	{
		return new MyBandedGridView(grid);
	}

	public override BaseViewPainter CreatePainter(BaseView view)
	{
		return new MyBandedGridPainter(view as MyBandedGridView);
	}
}
