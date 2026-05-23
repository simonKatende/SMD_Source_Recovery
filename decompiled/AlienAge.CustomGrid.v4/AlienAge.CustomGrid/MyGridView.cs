using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace AlienAge.CustomGrid;

public class MyGridView : GridView
{
	protected override string ViewName => "MyGridView";

	public MyGridView()
		: this(null)
	{
	}

	public MyGridView(GridControl grid)
		: base(grid)
	{
	}
}
