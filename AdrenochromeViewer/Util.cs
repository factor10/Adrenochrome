using System;
using System.Drawing;

namespace AdrenochromeViewer
{
    class Util
    {
        public static Rectangle AdaptProportionalRect(
            Rectangle rectMax,
            int nRealWidth,
            int nRealHeight,
            bool fillOut)
        {
            int nWidth;
            int nHeight;

            if (rectMax.Width < 1 || rectMax.Height < 1 || nRealHeight < 1 || nRealHeight < 1)
                return Rectangle.Empty;

            var sMaxRatio = (decimal)rectMax.Width / rectMax.Height;
            var sRealRatio = (decimal)nRealWidth / nRealHeight;

            if ((sMaxRatio < sRealRatio) ^ fillOut)
            {
                nWidth = Math.Min(rectMax.Width, nRealWidth);
                nHeight = (int)(nWidth / sRealRatio);
            }
            else
            {
                nHeight = Math.Min(rectMax.Height, nRealHeight);
                nWidth = (int)(nHeight * sRealRatio);
            }

            return new Rectangle(
                rectMax.X + (rectMax.Width - nWidth) / 2,
                rectMax.Y + (rectMax.Height - nHeight) / 2,
                nWidth,
                nHeight);
        }

    }
}
