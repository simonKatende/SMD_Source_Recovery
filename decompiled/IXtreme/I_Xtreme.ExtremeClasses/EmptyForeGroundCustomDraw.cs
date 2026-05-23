using System.Drawing;
using DevExpress.XtraGrid.Views.Base;

namespace I_Xtreme.ExtremeClasses;

internal class EmptyForeGroundCustomDraw
{
	public static void DrawEmptyForeGround(CustomDrawEventArgs e, string msg)
	{
		e.Graphics.DrawString(msg, new Font("Tahoma", 12f), new SolidBrush(Color.LightGray), new RectangleF(e.Bounds.Size.Width / 2 - 130, e.Bounds.Size.Height / 2, e.Bounds.Width, 100f));
	}
}
