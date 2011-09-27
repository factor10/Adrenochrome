using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Adrenochrome;

namespace AdrenochromeViewer
{
    public partial class FTool : Form
    {
        private readonly ViewerData _viewerData = new ViewerData();
        private FCurves _blender;

        public FTool()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var owner = Owner as FMain;
            if (owner == null)
                return;

            Location = new Point( Owner.Right - Width - 16, 20);
            owner.MouseMoveOverPicture += ownerMouseMoveOverPicture;
            try
            {
                var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                while (true)
                {
                    path = Path.GetDirectoryName(path);
                    if ( selectPath(cboForeground, Path.Combine(path,"foregrounds")) | selectPath(cboBackground,Path.Combine(path,"backgrounds")))
                        break;
                }
            }
            catch
            {
            }
        }

        private void ownerMouseMoveOverPicture(object sender, MouseEventArgs e)
        {
            if (_blender == null || _viewerData.TheMask == null )
                return;
            _blender.SetMarker(_viewerData.TheMask[e.Y*_viewerData.Result.Width+e.X].A);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if ( e.CloseReason == CloseReason.UserClosing )
                Owner.Close();
        }

        private bool selectPath( ComboBox cbo, string path )
        {
            if (!Directory.Exists(path))
                return false;
            cbo.Items.Clear();
            foreach (var fn in Directory.GetFiles(path, "*.jpg"))
                cbo.Items.Add(fn);
            if (cbo.Items.Count == 0)
                return false;
            cbo.SelectedIndex = 0;
            return true;
        }

        private void userSelectPath(ComboBox cbo)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Välj mapp";
                if (dlg.ShowDialog() == DialogResult.OK)
                    selectPath(cbo,dlg.SelectedPath);
            }
        }

        private void btnForeground_Click(object sender, EventArgs e)
        {
            userSelectPath(cboForeground);
        }

        private void btnBackground_Click(object sender, EventArgs e)
        {
            userSelectPath(cboBackground);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var foreground = cboForeground.SelectedItem as string;
            for (var i = lstHistory.Items.Count - 1; i >= 0; i-- )
                if ((lstHistory.Items[i] as OneView).Foreground != foreground)
                    lstHistory.Items.RemoveAt( i );
            Cursor = Cursors.WaitCursor;
            var unit = new OneView(
                _viewerData,
                foreground,
                cboBackground.SelectedItem as string,
                 trackTolLo.Value,
                 trackTolHi.Value,
                 chkMedian.Checked,
                 trackSoften.Value );
            lstHistory.Items.Insert(0, unit);
            lstHistory.SelectedIndex = 0;
            Cursor = Cursors.Default;
        }

        private void cbo_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = Path.GetFileName((string)e.ListItem);
        }

        private void cboBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_viewerData.ChangeBackground(cboBackground.SelectedItem as string))
                (Owner as FMain).SetImage(_viewerData.Result);
        }

        private void lstHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var view = lstHistory.SelectedItem as OneView;
            if (view == null)
                return;
            _viewerData.TheMask = view.TheMask;
            _viewerData.Blend();
            (Owner as FMain).SetImage(_viewerData.Result);
            var q = 100 - view.ForegroundPercentage - view.BackgroundPercentage;
            lblSpread.Text = string.Format("{0}% motiv / {1}% bakgrund / {2}% gränsland",
                view.ForegroundPercentage,
                view.BackgroundPercentage,
                q);
            lblSpread.BackColor = q > 10 ? Color.Red : Color.LightGreen;
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (_viewerData.Result == null)
                return;
            using ( var dlg = new SaveFileDialog())
            {
                dlg.Filter = "Jpeg|*.jpg";
                dlg.DefaultExt = ".jpg";
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;
                JpegSaver.saveWithDefaultCompression(
                    dlg.FileName,
                    _viewerData.Result);
            }
        }


        private void chkBlender_CheckedChanged(object sender, EventArgs e)
        {
            if ( chkBlender.Checked )
            {
                _blender = new FCurves( _viewerData.Blender );
                _blender.FormClosed += blenderFormClosed;
                _blender.CurvesChanged += blenderCurvesChanged;
                _blender.Show( Owner );
            }
            else
            {
                _blender.Close();
                _blender = null;
            }
        }

        void blenderCurvesChanged(object sender, byte[] c1, byte[] c2, byte[] c3)
        {
            var te = _viewerData.Blender.BlendTable;
            for (var i = 0; i < 256; i++)
                te[i] = new Blender.TableEntry()
                {
                    Mask = c1[i] / 255f,
                    SquareMask = c2[i] / 255f,
                    SquareRoot = c3[i] / 255f
                };
            _viewerData.Blend();
            (Owner as FMain).SetImage(_viewerData.Result);
        }

        void blenderFormClosed(object sender, FormClosedEventArgs e)
        {
            chkBlender.Checked = false;
        }

    }

}
