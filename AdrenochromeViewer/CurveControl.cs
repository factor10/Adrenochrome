using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AdrenochromeViewer
{
    public partial class CurveControl : UserControl
    {
        private readonly byte[] _curve = new byte[256];
        private Point _lastMousePos;
        private int _marker = -1;

        public event EventHandler CurveChanged;

        private Bitmap _bmp = new Bitmap(258, 258);

        public CurveControl()
        {
            InitializeComponent();
        }

        [Browsable(false),
        DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        public byte[] Curve
        {
            get { return (byte[])_curve.Clone(); }
            set
            {
                if (value != null && value.Length == 256)
                    value.CopyTo(_curve, 0);
                createBackground();
            }
        }

        [Browsable(false),
        DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        public int Marker
        {
            get { return _marker; }
            set
            {
                _marker = value;
                Invalidate();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled( _bmp, Point.Empty );
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if ( _marker >= 0 )
            e.Graphics.DrawLine( SystemPens.ControlDark, 1+_marker, 0, 1+_marker, 258 );
        }

        private void createBackground()
        {
            using (var g = Graphics.FromImage(_bmp))
            {
                g.Clear(SystemColors.ControlLightLight);
                for (var i = 65; i <= 193; i += 64)
                {
                    g.DrawLine(SystemPens.Control, 0, i, 256, i);
                    g.DrawLine(SystemPens.Control, i, 0, i, 256);

                }
                if (_curve != null)
                    for (var x = 0; x < 255; x++)
                        g.DrawLine(Pens.Black, x + 1, 256 - _curve[x], x + 2, 256 - _curve[x + 1]);
            }
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _lastMousePos = e.Location;
        }

        private static Point screenToLocal(Point p)
        {
            return new Point(
                Math.Max(0, Math.Min(255, p.X - 1)),
                255 - Math.Max(0, Math.Min(255, p.Y)));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            var p = screenToLocal(e.Location);
            var lp = screenToLocal(_lastMousePos);
            var f = (float) lp.Y;
            var dx = p.X - lp.X;
            var dy = p.Y - lp.Y;
            var slope = dy != 0 ? (float) dy/Math.Abs(dx) : 0;
            while (true)
            {
                _curve[lp.X] = (byte) f;
                if (lp.X == p.X)
                    break;
                f += slope;
                lp.X += Math.Sign(p.X - lp.X);
            }
            _lastMousePos = e.Location;
            createBackground();

            if (CurveChanged != null)
                CurveChanged(this, EventArgs.Empty);
        }

    }

}
