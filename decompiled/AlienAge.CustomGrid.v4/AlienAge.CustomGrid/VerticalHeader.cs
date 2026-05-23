using System.Drawing;
using System.Drawing.Drawing2D;
using DevExpress.XtraGrid.Views.Grid;

namespace AlienAge.CustomGrid;

public class VerticalHeader
{
	public static void VerticalAlignGridHeader(ColumnHeaderCustomDrawEventArgs e)
	{
		if (e.Column != null)
		{
			e.Info.Caption = "";
			e.Painter.DrawObject(e.Info);
			GraphicsState gstate = e.Graphics.Save();
			Rectangle captionRect = e.Info.CaptionRect;
			StringFormat stringFormat = new StringFormat();
			stringFormat.Trimming = StringTrimming.EllipsisWord;
			stringFormat.FormatFlags |= StringFormatFlags.FitBlackBox;
			if (e.Column.Caption == "Horizontal")
			{
				stringFormat.LineAlignment = StringAlignment.Far;
			}
			else
			{
				e.Graphics.RotateTransform(270f);
				SizeF sizeF = e.Graphics.MeasureString(e.Column.Caption, e.Appearance.Font);
				int x = ((!(sizeF.Width > (float)e.Bounds.Height)) ? (-e.Bounds.Bottom + (e.Bounds.Height - (int)sizeF.Width) / 2) : (-e.Bounds.Bottom));
				captionRect.X = x;
				captionRect.Y = e.Info.CaptionRect.X + (e.Info.CaptionRect.Width - (int)sizeF.Height) / 2;
				captionRect.Width = e.Bounds.Height;
				captionRect.Height = e.Bounds.Width;
			}
			e.Handled = true;
			e.Graphics.DrawString(e.Column.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache), captionRect, stringFormat);
			e.Graphics.Restore(gstate);
		}
	}
}
