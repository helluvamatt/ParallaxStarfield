using ParallaxStarfield.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallaxStarfield
{
    public partial class frmConfig : Form
    {
        private Color starColor;
        private float warpFactor;

        public frmConfig(IntPtr owner)
        {
            InitializeComponent();
            if (owner != IntPtr.Zero)
            {
                Win32Interop.SetParent(Handle, owner);
            }
            fldStarCount.Value = Settings.Default.StarCount;
            tbWarpFactor.Value = (int)(Settings.Default.WarpFactor * 10);
            starColor = Settings.Default.StarColor;
            btnStarColor.Invalidate();
        }

        private void btnStarColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.Color = starColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                starColor = dlg.Color;
                btnStarColor.Invalidate();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Settings.Default.StarCount = (long) fldStarCount.Value;
            Settings.Default.StarColor = starColor;
            Settings.Default.WarpFactor = warpFactor;
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnStarColor_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = e.ClipRectangle;
            r.Inflate(-4, -4);
            e.Graphics.FillRectangle(new SolidBrush(starColor), r);
        }

        private void tbWarpFactor_ValueChanged(object sender, EventArgs e)
        {
            warpFactor = tbWarpFactor.Value / 10f;
            lblWarpFactorValue.Text = string.Format("{0:0.0} c", warpFactor);
        }
    }
}
