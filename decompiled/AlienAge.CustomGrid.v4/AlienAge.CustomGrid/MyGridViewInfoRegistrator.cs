using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;

namespace AlienAge.CustomGrid;

public class MyGridViewInfoRegistrator : GridInfoRegistrator
{
	public override string ViewName => "MyGridView";

	public override BaseView CreateView(GridControl grid)
	{
		return new MyGridView(grid);
	}

	public override BaseViewPainter CreatePainter(BaseView view)
	{
		return new MyGridPainter(view as MyGridView);
	}
}
