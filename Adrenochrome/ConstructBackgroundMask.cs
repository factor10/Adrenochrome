using System.Drawing;
using System.Drawing.Imaging;

namespace Adrenochrome
{
    public static class ConstructBackgroundMask
    {
        private const int X = 2;
        private const int Y = 2;
        private const int W = 20;
        private const int H = 50;

        public static Pixel[] Execute(
            Bitmap source,
            int toleranceLo,
            int toleranceHi,
            bool medianFilter,
            int smoothingRounds )
        {
            var bgColor = (Pixel) HistogramAndBgColor.FindBackgroundColor(source, X, Y, W, H);

            var rect = new Rectangle(Point.Empty, source.Size);
            var bdS = source.LockBits(rect, ImageLockMode.ReadWrite, source.PixelFormat);

            var result = new Pixel[rect.Width*rect.Height];
            var result2 = new Pixel[rect.Width*rect.Height];

            var colorClose = new ColorClose(
                bgColor,
                2,
                3);

            var colorClose2 = new ColorClose(
                new Pixel(), 
                toleranceLo,
                toleranceHi);

            unsafe
            {
                fixed (Pixel* pResult = result, pResult2 = result2)
                {
                    // why -1? - will figure that out some other day!
                    for (var y = 0; y < bdS.Height  - 1; y++)
                    {
                        var pS = (Pixel*)((byte*) bdS.Scan0 + y*bdS.Stride);
                        var pD = pResult + y*rect.Width;
                        var bg = bgColor;
                        for (var x = bdS.Width / 2; x > 0; x--, pS = (Pixel*)((byte*)pS + 3), pD++ )
                        {
                            if (colorClose.Calculate(*pS) < 0.01f)
                            {
                                bg = *pS;
                                bg.A = 0;
                            }
                            else
                                bg.A = (byte) (255*colorClose2.Calculate(*pS, bg));
                            *pD = bg;
                        }

                        pS = (Pixel*)((byte*)bdS.Scan0 + y * bdS.Stride + rect.Width * 3 - 3);
                        pD = pResult + y * rect.Width + rect.Width - 1;
                        bg = bgColor;
                        for (var x = (bdS.Width + 1) / 2; x > 0; x--, pS = (Pixel*)((byte*)pS - 3), pD--)
                        {
                            if (colorClose.Calculate(*pS) < 0.01f)
                            {
                                bg = *pS;
                                bg.A = 0;
                            }
                            else
                                bg.A = (byte)(255 * colorClose2.Calculate(*pS, bg));
                            *pD = bg;
                        }

                    }

                    var p1 = pResult;
                    var p2 = pResult2;
                    for (var i = rect.Height * rect.Width; i > 0; i--, p1++, p2++)
                        *p2 = *p1;
                    for (var i = smoothingRounds ; i > 0; i--)
                    {
                        softenAlpha(pResult, pResult2, rect.Width, rect.Height);
                        softenAlpha(pResult2, pResult, rect.Width, rect.Height);
                    }
                }
            }
            source.UnlockBits(bdS);
            return result;
        }

        public static void CalculatePercentageSpread(
            Pixel[] mask,
            out int foreground,
            out int background)
        {
            unsafe
            {
                fixed (Pixel* pm = mask)
                {
                    long fcount = 0, bcount = 0;
                    var p = pm;
                    for (var i = mask.Length; i > 0; i--, p++)
                        if ( p->A < 10 )
                            bcount++;
                        else if (p->A > 245)
                            fcount++;
                    foreground = (int)(100 * fcount / mask.Length);
                    background = (int) (100*bcount/mask.Length);
                }
            }
        }

        private static unsafe void softenAlpha(Pixel* pS, Pixel* pD, int width, int height)
        {
            pS += width + 1;
            pD += width + 1;
            for (var i = (height - 2) * width - 2; i > 0; i--, pS++, pD++ )
            {
                var v =
                    pS[-width - 1].A + pS[-width].A + pS[-width + 1].A +
                    pS[-1].A + pS[0].A + pS[1].A +
                    pS[width - 1].A + pS[width].A + pS[width + 1].A;
                v /= 9;
                if (v < pD->A)
                    pD->A = (byte) v;
            }
        }

    }

}
