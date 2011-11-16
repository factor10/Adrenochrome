using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AdrenochromeViewer
{
    public partial class FPortLow : Form
    {
        private Bitmap _bmp;

        public FPortLow()
        {
            InitializeComponent();
            _bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            Text = string.Format("{0}x{1}", ClientSize.Width, ClientSize.Height);
            using ( var g = Graphics.FromImage(_bmp))
                g.Clear( Color.Black );
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Owner == null)
                return;
            Location = new Point(Owner.Right - Width - 16, Owner.Bottom - Height - 16);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled( _bmp, Point.Empty );
        }

        public void SetImage( Bitmap bmp )
        {
            if (bmp == null)
                return;
            var rect = Util.AdaptProportionalRect(
                new Rectangle(Point.Empty, _bmp.Size),
                bmp.Width,
                bmp.Height,
                true);
            using (var g = Graphics.FromImage(_bmp))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(
                    bmp,
                    rect,
                    new Rectangle(Point.Empty, bmp.Size),
                    GraphicsUnit.Pixel);
            }
            Invalidate();
        }

    }
}
