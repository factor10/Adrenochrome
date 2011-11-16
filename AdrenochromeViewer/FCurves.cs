using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Adrenochrome;

namespace AdrenochromeViewer
{
    public partial class FCurves : Form
    {
        public delegate void CurvesChangedEventHandler( object sender, byte[] c1, byte[] c2, byte[] c3 );
        public event CurvesChangedEventHandler CurvesChanged;

        private readonly byte[][][] _x = new byte[8][][];
        private int _checkedButtonIndex;

        private FCurves()
        {
            InitializeComponent();
        }

        public FCurves(Blender blender)
        {
            InitializeComponent();

            var bc1 = new byte[256];
            var bc2 = new byte[256];
            var bc3 = new byte[256];
            var i = 0;
            foreach ( var te in blender.BlendTable )
            {
                bc1[i] = (byte)Math.Round(te.Mask * 255);
                bc2[i] = (byte)Math.Round(te.GreenExtract * 255);
                bc3[i] = (byte)Math.Round(te.Foreground * 255);
                i++;
            }
            c1.Curve = bc1;
            c2.Curve = bc2;
            c3.Curve = bc3;

            for ( var j = 0 ; j <= _x.GetUpperBound(0) ; j++ )
            {
                _x[j] = new[] { (byte[])bc1.Clone(), (byte[])bc2.Clone(), (byte[])bc3.Clone() };
                var btn = new RadioButton
                              {
                                  Appearance = Appearance.Button,
                                  TextAlign = ContentAlignment.MiddleCenter,
                                  Bounds = new Rectangle(c3.Left + j*32, c3.Bottom + 8, 28, 28),
                                  Text = string.Format( "&{0}", j + 1),
                                  Checked = j == 0,
                                  Visible = true,
                                  UseMnemonic = true
                              };
                var k = j;
                btn.Click += (s, e) => btnClick(k);
                Controls.Add(btn);
            }
        }

        public void SetMarker(int marker)
        {
            c1.Marker = marker;
            c2.Marker = marker;
            c3.Marker = marker;
        }

        private void btnClick( int index )
        {
            _checkedButtonIndex = index;
            c1.Curve = _x[index][0];
            c2.Curve = _x[index][1];
            c3.Curve = _x[index][2];
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Owner != null)
                Location = new Point(Owner.Left + 16, Owner.Bottom - Height - 16);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            CurvesChanged = null;
        }

        private void curveChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var bc1 = c1.Curve;
            var bc2 = c2.Curve;
            var bc3 = c3.Curve;

            _x[_checkedButtonIndex][0] = bc1;
            _x[_checkedButtonIndex][1] = bc2;
            _x[_checkedButtonIndex][2] = bc3;

            if ( CurvesChanged != null )
                CurvesChanged(this, bc1, bc2, bc3);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var z = _x[_checkedButtonIndex];
            var bend1 = (double) numBendBlend.Value / 10;
            var bend2 = (double)numBendGreen.Value / 10;
            for (var i = 0; i < 256; i++)
            {
                var te = new Blender.TableEntry(i, (int)numKnee.Value, bend1, bend2);
                z[0][i] = (byte)Math.Round(te.Mask * 255);
                z[1][i] = (byte)Math.Round(te.GreenExtract * 255);
                z[2][i] = (byte)Math.Round(te.Foreground * 255);
            }
            btnClick(_checkedButtonIndex);
        }

    }

}
