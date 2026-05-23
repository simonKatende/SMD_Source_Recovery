using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraGrid.Drawing;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.Drawing;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace AlienAge.CustomGrid;

public class MyAdvBandedGridPainter : AdvBandedGridPainter
{
	public MyAdvBandedGridPainter(AdvBandedGridView view)
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
		Pen buttonFace = SystemPens.ButtonFace;
		if (base.View.OptionsView.ShowVerticalLines == DefaultBoolean.True)
		{
			foreach (GridColumnInfoArgs item in e.ViewInfo.ColumnsInfo)
			{
				int num = item.Bounds.Right - 1;
				if ((item.Column != null && item.Column.Fixed != 0) || ((viewRects.FixedLeft.IsEmpty || num > viewRects.FixedLeft.Right) && (viewRects.FixedRight.IsEmpty || num < viewRects.FixedRight.Left - 3)))
				{
					e.Graphics.DrawLine(buttonFace, num, emptyRows.Top, num, emptyRows.Bottom);
				}
			}
			if (!viewRects.FixedRight.IsEmpty)
			{
				e.Graphics.DrawLine(buttonFace, viewRects.FixedRight.Left - 1, emptyRows.Top, viewRects.FixedRight.Left - 1, emptyRows.Bottom);
			}
		}
		if (base.View.OptionsView.ShowHorizontalLines == DefaultBoolean.True)
		{
			int minRowHeight = e.ViewInfo.MinRowHeight;
			for (int i = emptyRows.Top + minRowHeight; i < emptyRows.Bottom; i += minRowHeight)
			{
				e.Graphics.DrawLine(buttonFace, emptyRows.Left, i, viewRects.DataRectRight.Right - 1, i);
			}
		}
	}
}
