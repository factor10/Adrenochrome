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
                BlendTable[i] = new TableEntry(i); 
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
                                    var r = z.SquareRoot * Math.Max(pS->R - z.SquareMask * pM->R, 0) + z.Mask * pB->R;
                                    var g = z.SquareRoot * Math.Max(pS->G - z.SquareMask * pM->G, 0) + z.Mask * pB->G;
                                    var b = z.SquareRoot * Math.Max(pS->B - z.SquareMask * pM->B, 0) + z.Mask * pB->B;
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

        public struct TableEntry
        {
            public float Mask;
            public float SquareRoot;
            public float SquareMask;

            public TableEntry(int z)
            {
                Mask = 1f - z / 255f;
                SquareRoot = (float)Math.Sqrt(z / 255.0);
                SquareMask = Mask * Mask;
            }
        }
    }

}
