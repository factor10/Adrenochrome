using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Adrenochrome
{
    static class HistogramAndBgColor
    {
        public static void CalculateHistogram(
            Bitmap source,
            Rectangle rect,
            int[] red,
            int[] green,
            int[] blue)
        {
            var bd = source.LockBits(
                new Rectangle(Point.Empty, source.Size),
                ImageLockMode.ReadWrite,
                source.PixelFormat);

            var pixelSize = source.PixelFormat == PixelFormat.Format32bppArgb ? 4 : 3;

            unsafe
            {
                fixed (int* pr = red, pg = green, pb = blue)
                    for (var y = rect.Y; y < rect.Bottom; y++)
                    {
                        var p = (byte*) bd.Scan0 + y*bd.Stride + rect.X*pixelSize;
                        for (var x = rect.Width; x > 0; x--, p += pixelSize)
                        {
                            pr[p[2]]++;
                            pg[p[1]]++;
                            pb[p[0]]++;
                        }
                    }
            }
            source.UnlockBits(bd);
        }

        public static Color FindBackgroundColor(
            Bitmap source,
            int areaX,
            int areaY,
            int areaWidth,
            int areaHeight )
        {
            var ar = new int[256];
            var ag = new int[256];
            var ab = new int[256];
            var w = source.Width / 100f;
            var h = source.Height / 100f;
            CalculateHistogram(
                source,
                new Rectangle((int)(w * areaX), (int)(h * areaY), (int)(w * areaWidth), (int)(h * areaHeight)),
                ar, ag, ab);
            CalculateHistogram(
                source,
                new Rectangle((int)(w * (100 - areaX)), (int)(h * areaY), (int)(w * areaWidth), (int)(h * areaHeight)),
                ar, ag, ab);
            return Color.FromArgb(255, findMaxIndex(ar), findMaxIndex(ag), findMaxIndex(ab));
        }

        private static int findMaxIndex(IEnumerable<int> arr)
        {
            var i = 0;
            var maxIndex = 0;
            var max = 0;
            foreach (var value in arr)
            {
                if (value > max)
                {
                    max = value;
                    maxIndex = i;
                }
                i++;
            }
            return maxIndex;
        }
    }

}
