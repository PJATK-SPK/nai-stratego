// Authors: Sandro Sobczynski, Marcel Pankanin

using AForge.Imaging;
using Core.Models;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Core.Extensions
{
    public static class BitmapExtensions
    {
        /// <summary>
        /// Crop bitmap to input bbox coords.
        /// </summary>
        public static Bitmap Crop(this Bitmap input, BoundingBox<int> bbox)
            => Crop(input, bbox.X, bbox.Y, bbox.Width, bbox.Height);

        public static Bitmap Crop(this Bitmap input, int x, int y, int w, int h)
            => input.Clone(new Rectangle(x, y, w, h), input.PixelFormat);

        /// <summary>
        /// Draw bounding box on bitmap
        /// </summary>
        public static void DrawBBox(this Bitmap bmp, BoundingBox<int> bbox, Color color, string? label = null)
        {
            var searchZone = new Rectangle(
              bbox.Left,
              bbox.Top,
              bbox.Right - bbox.Left,
              bbox.Bottom - bbox.Top);

            DrawRectangle(bmp, searchZone, color, label);
        }

        /// <summary>
        /// Draw rectangle on bitmap
        /// </summary>
        public static void DrawRectangle(this Bitmap bmp, Rectangle searchZone, Color color, string? label = null)
        {
            BitmapData data = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, bmp.PixelFormat);

            Drawing.Rectangle(data, searchZone, color);
            bmp.UnlockBits(data);

            if (label != null)
                DrawText(bmp, new XY(searchZone.X + 5, searchZone.Y + 5), color, label);
        }

        /// <summary>
        /// Draw text on bitmap
        /// </summary>
        public static void DrawText(this Bitmap bmp, XY pos, Color color, string text)
        {
            var rectf = new RectangleF(pos.X, pos.Y, bmp.Width - pos.X, 50);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(text, new Font("Tahoma", 12, FontStyle.Bold), new SolidBrush(color), rectf);
            g.Flush();
        }
    }
}
