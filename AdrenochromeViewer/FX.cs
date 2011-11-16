using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AdrenochromeViewer
{
    public partial class FX : Form
    {
        private Bitmap _back;
        private Bitmap _fore;

        private FX()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(_back, 0, 0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(_fore, 0, 0);
        }

        public static DialogResult showDialog( Form parent, Bitmap fore, Bitmap back )
        {
            using ( var dlg = new FX())
            {
                dlg._fore = fore;
                dlg._back = back;
                return dlg.ShowDialog(parent);
            }

        }

    }
}
