using System.Drawing;
using System.Drawing.Imaging;
using AlienAge.ReportHeaders;

namespace I_Xtreme.ExtremeClasses;

internal class WaterMarkImage
{
	private static Bitmap AdjustBrightness(Bitmap Image, int Value)
	{
		float num = (float)Value / 255f;
		Bitmap bitmap = new Bitmap(Image.Width, Image.Height);
		Graphics graphics = Graphics.FromImage(bitmap);
		float[][] newColorMatrix = new float[5][]
		{
			new float[5] { 1f, 0f, 0f, 0f, 0f },
			new float[5] { 0f, 1f, 0f, 0f, 0f },
			new float[5] { 0f, 0f, 1f, 0f, 0f },
			new float[5] { 0f, 0f, 0f, 1f, 0f },
			new float[5] { num, num, num, 1f, 1f }
		};
		ColorMatrix colorMatrix = new ColorMatrix(newColorMatrix);
		ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetColorMatrix(colorMatrix);
		graphics.DrawImage(Image, new Rectangle(0, 0, Image.Width, Image.Height), 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, imageAttributes);
		imageAttributes.Dispose();
		graphics.Dispose();
		return bitmap;
	}

	public static Image BackWaterMarkImage()
	{
		Image schoolLogo = ReportHeader.SchoolLogo;
		return AdjustBrightness((Bitmap)schoolLogo, 139);
	}
}
