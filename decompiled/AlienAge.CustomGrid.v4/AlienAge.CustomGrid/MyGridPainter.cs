using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraGrid.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace AlienAge.CustomGrid;

public class MyGridPainter : GridPainter
{
	public MyGridPainter(GridView view)
		: base(view)
	{
	}

	protected override void DrawRows(GridViewDrawArgs e)
	{
		base.DrawRows(e);
		DrawEmptyAreaLines(e);
	}

	protected virtual void DrawEmptyAreaLines(GridViewDrawArgs e)
	{
		GridViewRects viewRects = e.ViewInfo.ViewRects;
		Rectangle emptyRows = viewRects.EmptyRows;
		if (emptyRows.IsEmpty)
		{
			return;
		}
		Pen scrollBar = SystemPens.ScrollBar;
		if (base.View.OptionsView.ShowVerticalLines == DefaultBoolean.Default || base.View.OptionsView.ShowVerticalLines == DefaultBoolean.True)
		{
			foreach (GridColumnInfoArgs item in e.ViewInfo.ColumnsInfo)
			{
				int num = item.Bounds.Right - 1;
				if ((item.Column != null && item.Column.Fixed != 0) || ((viewRects.FixedLeft.IsEmpty || num > viewRects.FixedLeft.Right) && (viewRects.FixedRight.IsEmpty || num < viewRects.FixedRight.Left - 3)))
				{
					e.Graphics.DrawLine(scrollBar, num, emptyRows.Top, num, emptyRows.Bottom);
				}
			}
			if (!viewRects.FixedRight.IsEmpty)
			{
				e.Graphics.DrawLine(scrollBar, viewRects.FixedRight.Left - 1, emptyRows.Top, viewRects.FixedRight.Left - 1, emptyRows.Bottom);
			}
		}
		if (base.View.OptionsView.ShowHorizontalLines == DefaultBoolean.Default || base.View.OptionsView.ShowHorizontalLines == DefaultBoolean.True)
		{
			int minRowHeight = e.ViewInfo.MinRowHeight;
			for (int i = emptyRows.Top + minRowHeight; i < emptyRows.Bottom; i += minRowHeight)
			{
				e.Graphics.DrawLine(scrollBar, emptyRows.Left, i, viewRects.DataRectRight.Right - 1, i);
			}
		}
	}
}
