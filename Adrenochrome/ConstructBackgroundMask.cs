using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Adrenochrome
{

    public static class ConstructBackgroundMask
    {
        private unsafe delegate void Softener(Pixel* pS, Pixel* pD, int width, int height);

        private const int X = 2;
        private const int Y = 2;
        private const int W = 20;
        private const int H = 50;

        public static Pixel[] Execute(
            Bitmap source,
            int toleranceLo,
            int toleranceHi,
            int softenMethod,
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

                    Softener softenAlpha;
                    if ( softenMethod == 0 )
                        softenAlpha = softenAlpha1;
                    else
                        softenAlpha = softenAlpha2;

                    //var p1 = pResult;
                    //var p2 = pResult2;
                    //for (var i = rect.Height * rect.Width; i > 0; i--, p1++, p2++)
                    //    *p2 = *p1;
                    softenColor(pResult, pResult2, rect.Width, rect.Height);
                    softenColor(pResult2, pResult, rect.Width, rect.Height);
                    for (var i = smoothingRounds; i > 0; i--)
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

        private static unsafe void softenColor(Pixel* pS, Pixel* pD, int width, int height)
        {
            pS += width + 1;
            pD += width + 1;
            for (var i = (height - 2)*width - 2; i > 0; i--, pS++, pD++)
            {
                pD->R = (byte) ((
                                    pS[-width - 1].R + pS[-width].R + pS[-width + 1].R +
                                    pS[-1].A + pS[0].R + pS[1].R +
                                    pS[width - 1].R + pS[width].R + pS[width + 1].R + 5)/9);
                pD->G = (byte) ((
                                    pS[-width - 1].G + pS[-width].G + pS[-width + 1].G +
                                    pS[-1].G + pS[0].G + pS[1].G +
                                    pS[width - 1].G + pS[width].G + pS[width + 1].G + 5)/9);
                pD->B = (byte) ((
                                    pS[-width - 1].B + pS[-width].B + pS[-width + 1].B +
                                    pS[-1].B + pS[0].B + pS[1].B +
                                    pS[width - 1].B + pS[width].B + pS[width + 1].B + 5)/9);
                pD->A = pS->A;
            }
        }

        private static unsafe void softenAlpha1(Pixel* pS, Pixel* pD, int width, int height)
        {
            pS += width + 1;
            pD += width + 1;
            for (var i = (height - 2) * width - 2; i > 0; i--, pS++, pD++ )
            {
                var v =
                    pS[-width - 1].A + pS[-width].A + pS[-width + 1].A +
                    pS[-1].A + pS[0].A + pS[1].A +
                    pS[width - 1].A + pS[width].A + pS[width + 1].A + 5;
                v /= 9;
                if (v < pD->A)
                    pD->A = (byte) v;
            }
        }

        private static unsafe void softenAlpha2(Pixel* pS, Pixel* pD, int width, int height)
        {
            var x01 = -2*width - 1;
            var x02 = -2*width;
            var x03 = -2*width + 1;

            var x04 = -width - 2;
            var x05 = -width - 1;
            var x06 = -width;
            var x07 = -width + 1;
            var x08 = -width + 2;

            var x09 = width - 2;
            var x10 = width - 1;
            var x11 = width;
            var x12 = width + 1;
            var x13 = width + 2;

            var x14 = 2*width - 1;
            var x15 = 2*width;
            var x16 = 2*width + 1;

            pS += 2*(width + 1);
            pD += 2*(width + 1);
            for (var i = (height - 4)*width - 4; i > 0; i--, pS++, pD++)
            {
                var v =
                    pS[x01].A + pS[x02].A + pS[x03].A +
                    pS[x04].A + pS[x05].A + pS[x06].A + pS[x07].A + pS[x08].A +
                    pS[-2].A + pS[-1].A + pS[0].A + pS[1].A + pS[2].A +
                    pS[x09].A + pS[x10].A + pS[x11].A + pS[x12].A + pS[x13].A +
                    pS[x14].A + pS[x15].A + pS[x16].A;
                v /= 21;
                if (v < pD->A)
                    pD->A = (byte) v;
            }
        }

    }

}
