using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Adrenochrome
{
    public class Blender
    {
        public readonly TableEntry[] BlendTable = new TableEntry[256];

        public Blender()
        {
            for (var i = 0; i < 256; i++)
                BlendTable[i] = new TableEntry(i, 8, 0.5, 0.5); 
        }

        public void Execute(
            Bitmap result,
            Bitmap foreground,
            Bitmap background,
            Pixel[] theMask)
        {
            var rect = new Rectangle(Point.Empty, foreground.Size);
            var bdSrc = foreground.LockBits(rect, ImageLockMode.ReadWrite, foreground.PixelFormat);
            var bdDst = result.LockBits(rect, ImageLockMode.ReadWrite, result.PixelFormat);
            var bdBack = background.LockBits(rect, ImageLockMode.ReadWrite, background.PixelFormat);

            unsafe
            {
                fixed (Pixel* pMask = theMask)
                fixed (TableEntry* pBlendTable = BlendTable)
                {
                    for (var y = 0; y < bdSrc.Height - 1; y++)
                    {
                        var pS = (Pixel*) ((byte*) bdSrc.Scan0 + y*bdSrc.Stride);
                        var pD = (Pixel*) ((byte*) bdDst.Scan0 + y*bdDst.Stride);
                        var pB = (Pixel*) ((byte*) bdBack.Scan0 + y*bdBack.Stride);
                        var pM = pMask + y*rect.Width;
                        for (var x = bdSrc.Width; x > 0;
                                    x--,
                                    pS = (Pixel*) ((byte*) pS + 3),
                                    pD = (Pixel*) ((byte*) pD + 3),
                                    pB = (Pixel*) ((byte*) pB + 3),
                                    pM++)
                            switch (pM->A)
                            {
                                case 0:
                                    *pD = *pB;
                                    break;
                                case 255:
                                    *pD = *pS;
                                    break;
                                default:
                                    var z = pBlendTable[pM->A];
                                    var r = z.Foreground * Math.Max(pS->R - z.GreenExtract * pM->R, 0) + z.Mask * pB->R;
                                    var g = z.Foreground * Math.Max(pS->G - z.GreenExtract * pM->G, 0) + z.Mask * pB->G;
                                    var b = z.Foreground * Math.Max(pS->B - z.GreenExtract * pM->B, 0) + z.Mask * pB->B;
                                    pD->R = (byte)(r > 255 ? 255 : r);
                                    pD->G = (byte) (g > 255 ? 255 : g);
                                    pD->B = (byte) (b > 255 ? 255 : b);
                                    break;
                            }
                    }
                }
            }
            foreground.UnlockBits(bdSrc);
            result.UnlockBits(bdDst);
            background.UnlockBits(bdBack);
        }

        public void Execute(
            Bitmap result,
            Bitmap foreground,
            Pixel[] theMask)
        {
            var rect = new Rectangle(Point.Empty, foreground.Size);
            var bdSrc = foreground.LockBits(rect, ImageLockMode.ReadWrite, foreground.PixelFormat);
            var bdDst = result.LockBits(rect, ImageLockMode.ReadWrite, result.PixelFormat);

            unsafe
            {
                fixed (Pixel* pMask = theMask)
                fixed (TableEntry* pBlendTable = BlendTable)
                {
                    for (var y = 0; y < bdSrc.Height - 1; y++)
                    {
                        var pS = (Pixel*) ((byte*) bdSrc.Scan0 + y*bdSrc.Stride);
                        var pD = (Pixel*) ((byte*) bdDst.Scan0 + y*bdDst.Stride);
                        var pM = pMask + y*rect.Width;
                        for (var x = bdSrc.Width;
                             x > 0;
                             x--,
                             pS = (Pixel*) ((byte*) pS + 3),
                             pD = (Pixel*) ((byte*) pD + 4),
                             pM++)
                            switch (pM->A)
                            {
                                case 0:
                                    *pD = new Pixel();
                                    break;
                                case 255:
                                    *pD = *pS;
                                    pD->A = 255;
                                    break;
                                default:
                                    var z = pBlendTable[pM->A];
                                    var mask = 1f - z.Mask;
                                    if (mask < 0.0001f)
                                        mask = 0.0001f;  // guard against divide by zero if someone altered the curves
                                    var r = z.Foreground*Math.Max(pS->R - z.GreenExtract*pM->R, 0)/mask;
                                    var g = z.Foreground*Math.Max(pS->G - z.GreenExtract*pM->G, 0)/mask;
                                    var b = z.Foreground*Math.Max(pS->B - z.GreenExtract*pM->B, 0)/mask;
                                    pD->R = (byte) (r > 255 ? 255 : r);
                                    pD->G = (byte) (g > 255 ? 255 : g);
                                    pD->B = (byte) (b > 255 ? 255 : b);
                                    pD->A = (byte) (mask*255);
                                    break;
                            }
                    }
                }
            }
            foreground.UnlockBits(bdSrc);
            result.UnlockBits(bdDst);
        }

        public struct TableEntry
        {
            public float Mask;
            public float Foreground;
            public float GreenExtract;

            public TableEntry(int z, int knee, double foregroundBend, double greenBend )
            {
                var k = 255f - knee;
                var mask = Math.Min(1f, (k + knee - z)/k);
                Mask = (float)Math.Pow(mask, foregroundBend);
                Foreground = (float)Math.Sqrt(z / 255.0);
                GreenExtract = (float)Math.Pow(mask, greenBend);
            }

            //public TableEntry(int z, int knee)
            //{
            //    var k = 255f - knee;
            //    var mask = Math.Min(1f, (k + knee - z)/k);
            //    Mask = 1 - (1 - mask) * (1 - mask) * (1 - mask) * (1 - mask);
            //    Foreground = 1-mask;
            //    GreenExtract = 1 - (1 - mask) * (1 - mask);
            //}

            //public TableEntry(int z, int knee)
            //{
            //    Mask = 1 - z / 255f;
            //    Foreground = (float) Math.Sqrt(z/255.0);
            //    GreenExtract = Mask * Mask;
            //}

            //public TableEntry(int z, int knee)
            //{
            //    var k = 255f - knee;
            //    Mask = Math.Min(1f, (k + knee - z) / k);
            //    Foreground = 1 - Mask * Mask;
            //    //Foreground = (float) Math.Sqrt(z/255.0);
            //    var m = 1f - z / 255f;
            //    GreenExtract = Mask * m;
            //}

        }
    }

}
