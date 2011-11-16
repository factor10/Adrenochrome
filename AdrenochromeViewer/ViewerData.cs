using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Adrenochrome;

namespace AdrenochromeViewer
{
    public class ViewerData
    {
        public Pixel[] TheMask;

        private Bitmap _bmpOrg;
        private Bitmap _bmpBack;
        private Bitmap _bmpNew;

        private string _foregroundFilename;
        private string _backgroundFilename;

        private readonly Blender _blender = new Blender();

        public Bitmap Result
        {
            get { return _bmpNew; }
        }

        public Blender Blender
        {
            get { return _blender; }
        }

        private bool setNewForeground(string fn)
        {
            if (!loadSafeBitmap(fn, ref _bmpOrg))
                return false;
            if (_bmpNew == null || _bmpNew.Size != _bmpOrg.Size)
                _bmpNew = (Bitmap)_bmpOrg.Clone();
            _foregroundFilename = fn;
            return true;
        }

        private bool setNewBackground(string fn)
        {
            if (_bmpOrg == null || !loadSafeBitmap(fn, ref _bmpBack))
                return false;
            using (var bmpTemp = _bmpBack)
            {
                _bmpBack = new Bitmap(_bmpOrg.Width, _bmpOrg.Height, PixelFormat.Format24bppRgb);
                var rect = Util.AdaptProportionalRect(
                    new Rectangle(Point.Empty, _bmpOrg.Size),
                    bmpTemp.Width * 100,
                    bmpTemp.Height * 100,
                    true);
                using (var g = Graphics.FromImage(_bmpBack))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(
                        bmpTemp,
                        rect,
                        new Rectangle(Point.Empty, bmpTemp.Size),
                        GraphicsUnit.Pixel);
                }
            }
            _backgroundFilename = fn;
            return true;
        }

        private static bool loadSafeBitmap(string fn, ref Bitmap bmp)
        {
            try
            {
                var bmpTemp = (Bitmap)Image.FromFile(fn);
                if (bmpTemp.PixelFormat != PixelFormat.Format24bppRgb)
                    return false;
                if (bmp != null)
                    bmp.Dispose();
                bmp = bmpTemp;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Bitmap Foreground
        {
            get { return _bmpOrg; }
        }

        public Bitmap Background
        {
            get { return _bmpBack; }
        }

        public void Blend()
        {
            if ( TheMask != null )
                _blender.Execute(
                    _bmpNew,
                    _bmpOrg,
                    _bmpBack,
                    TheMask);
        }

        public bool ChangeBackground(string background)
        {
            if (TheMask == null)
                return false;
            if (!setNewBackground(background))
                return false;
            Blend();
            return true;
        }

        public bool CreateMask(
            int toleranceLo,
            int toleranceHi,
            int smoothingMethod,
            int smoothingRounds,
            string foreground,
            string background)
        {
            if (string.IsNullOrEmpty(foreground) || string.IsNullOrEmpty(background))
                return false;

            var didUpdateForeground = false;
            if (foreground != _foregroundFilename)
                if (!setNewForeground(foreground))
                    return false;
                else
                    didUpdateForeground = true;
            if (background != _backgroundFilename || didUpdateForeground)
                if (!setNewBackground(background))
                    return false;

            TheMask = ConstructBackgroundMask.Execute(
                _bmpOrg,
                toleranceLo,
                toleranceHi,
                smoothingMethod,
                smoothingRounds);
            return true;
        }

    }

}
