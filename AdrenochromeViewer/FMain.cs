using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdrenochromeViewer
{
    public partial class FMain : Form
    {
        private Bitmap _bmp;
        private Point _offset = Point.Empty;
        private Point _mouse;

        private FPortLow _portLow;

        public event MouseEventHandler MouseMoveOverPicture;

        public FMain()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            var tool = new FTool();
            tool.Show(this);

            _portLow = new FPortLow();
            _portLow.Show(this);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (_bmp == null)
            {
                base.OnPaintBackground(e);
                return;
            }

            var rect = new Rectangle(_offset, _bmp.Size);
            if (rect.Y > 0)
                e.Graphics.FillRectangle(Brushes.Blue, 0, 0, ClientSize.Width, rect.Y);
            if (rect.Bottom < ClientSize.Height )
                e.Graphics.FillRectangle(Brushes.Blue, 0, rect.Bottom, ClientSize.Width, ClientSize.Height - rect.Bottom);
            if (rect.X > 0)
                e.Graphics.FillRectangle(Brushes.Blue, 0, 0, rect.X, ClientSize.Height);
            if (rect.Right < ClientSize.Width)
                e.Graphics.FillRectangle(Brushes.Blue, rect.Right, 0, ClientSize.Width - rect.Right, ClientSize.Height );
            e.Graphics.DrawImage(
                _bmp,
                new Rectangle(_offset, _bmp.Size),
                new Rectangle(Point.Empty, _bmp.Size),
                GraphicsUnit.Pixel);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _mouse = e.Location;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                _offset.Offset(e.X - _mouse.X, e.Y - _mouse.Y);
                _mouse = e.Location;
                Invalidate();
            }

            if (MouseMoveOverPicture != null && _bmp != null)
            {
                var x = e.X - _offset.X;
                var y = e.Y - _offset.Y;
                if (new Rectangle(Point.Empty, _bmp.Size).Contains(x, y))
                    MouseMoveOverPicture(this,
                                         new MouseEventArgs(e.Button, e.Clicks, x, y, e.Delta));
            }
        }

        public void SetImage( Bitmap bmp )
        {
            _bmp = bmp;
            Invalidate();
            _portLow.SetImage( bmp );
        }

    }

}
