using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WplacePaletteConverter.Extensions
{
	internal static class BitmapExt
	{
		public static Bitmap ResizeWithoutInterpolation(this Bitmap src, PictureBox pictureBox)
		{
			int height = (int)(src.Height * ((double)pictureBox.ClientSize.Width / src.Width));
			int width = pictureBox.ClientSize.Width;

			if (height > pictureBox.ClientSize.Height)
			{
				width = (int)(src.Width * ((double)pictureBox.ClientSize.Height / src.Height));
				height = pictureBox.ClientSize.Height;
			}

			Bitmap dest = new(width, height, src.PixelFormat);
			using Graphics g = Graphics.FromImage(dest);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
			g.DrawImage(src, new Rectangle(0, 0, width, height));

			return dest;
		}

		public static Bitmap ApplyContrast(this Bitmap src, float contrast)
		{
			Bitmap dest = new(src.Width, src.Height, src.PixelFormat);
			float offset = (1.0f - contrast) / 2.0f * 255.0f;

			unsafe
			{
				var rect = new Rectangle(0, 0, src.Width, src.Height);
				BitmapData srcData = src.LockBits(rect, ImageLockMode.ReadOnly, src.PixelFormat);
				BitmapData destData = dest.LockBits(rect, ImageLockMode.WriteOnly, src.PixelFormat);

				int bytesPerPixel = Image.GetPixelFormatSize(src.PixelFormat) / 8;
				int height = srcData.Height;
				int widthInBytes = srcData.Width * bytesPerPixel;

				byte* srcBase = (byte*)srcData.Scan0;
				byte* destBase = (byte*)destData.Scan0;

				for (int y = 0; y < height; y++)
				{
					byte* srcRow = srcBase + (y * srcData.Stride);
					byte* destRow = destBase + (y * destData.Stride);

					for (int x = 0; x < widthInBytes; x += bytesPerPixel)
					{
						destRow[x] = (byte)Math.Clamp(srcRow[x] * contrast + offset, 0, 255); // B
						destRow[x + 1] = (byte)Math.Clamp(srcRow[x + 1] * contrast + offset, 0, 255); // G
						destRow[x + 2] = (byte)Math.Clamp(srcRow[x + 2] * contrast + offset, 0, 255); // R

						// If there's an alpha channel
						if (bytesPerPixel == 4)
							destRow[x + 3] = srcRow[x + 3];
					}
				}

				src.UnlockBits(srcData);
				dest.UnlockBits(destData);
			}

			return dest;
		}

		public static Bitmap ResizeForDGV(this Bitmap btmp, DataGridView dgv)
		{
			double height = dgv.RowTemplate.Height;
			double width = height / btmp.Height * btmp.Width;

			return new(btmp, new((int)width, (int)height));
		}

	}
}
