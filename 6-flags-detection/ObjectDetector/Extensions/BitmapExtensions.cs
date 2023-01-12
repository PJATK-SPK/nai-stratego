// Authors: Sandro Sobczynski, Marcel Pankanin

using Microsoft.ML.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace ObjectDetector.Extensions
{
    public static class BitmapExtensions
    {
        /// <summary>
        /// Convert Bitmap to MLImage for ML.NET
        /// </summary>
        [SupportedOSPlatform("windows")]
        public static MLImage ToMLImage(this Bitmap bmp, int width, int height)
        {
            if (bmp.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new NotSupportedException("Only 32bppArgb is supported");
            }

            var destRect = new Rectangle(0, 0, width, height);
            using var resized = new Bitmap(width, height);

            resized.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

            using (var graphics = Graphics.FromImage(resized))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(bmp, destRect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            var data = resized.LockBits(new Rectangle(0, 0, resized.Width, resized.Height), ImageLockMode.ReadOnly, resized.PixelFormat);
            var bytes = new byte[data.Stride * data.Height];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
            resized.UnlockBits(data);
            return MLImage.CreateFromPixels(resized.Width, resized.Height, MLPixelFormat.Bgra32, bytes);
        }
    }
}
