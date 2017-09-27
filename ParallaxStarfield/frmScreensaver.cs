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
    public partial class frmScreensaver : Form
    {
        private bool previewMode;
        private Point mouseLocation;

        private List<StarTrail> stars = new List<StarTrail>();
        private Random rng;

        private bool initialized = false;

        public frmScreensaver(Rectangle bounds)
        {
            InitializeComponent();
            Location = bounds.Location;
            Size = bounds.Size;
            Init(Settings.Default.StarCount);
        }

        public frmScreensaver(IntPtr handle)
        {
            InitializeComponent();

            // Set the preview window as the parent of this window
            Win32Interop.SetParent(Handle, handle);

            // Make this a child window so it will close when the parent dialog closes
            // GWL_STYLE = -16, WS_CHILD = 0x40000000
            Win32Interop.SetWindowLong(Handle, -16, new IntPtr(Win32Interop.GetWindowLong(Handle, -16) | 0x40000000));

            // Place our window inside the parent
            Rectangle ParentRect;
            Win32Interop.GetClientRect(handle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);

            previewMode = true;

            Init(Settings.Default.StarCount / 5);
        }

        private void frmScreensaver_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;
        }

        private void frmScreensaver_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!previewMode)
            {
                Application.Exit();
            }
        }

        private void frmScreensaver_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmScreensaver_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseLocation.IsEmpty)
            {
                // Terminate if mouse is moved a significant distance
                if (Math.Abs(mouseLocation.X - e.X) > 5 || Math.Abs(mouseLocation.Y - e.Y) > 5)
                {
                    Application.Exit();
                }
            }

            mouseLocation = e.Location;
        }

        private void Init(long count)
        {
            rng = new Random();
            for (long i = 0; i < count; i++)
            {
                StarTrail star = new StarTrail();
                stars.Add(star);
            }
            initialized = true;
            Invalidate();
        }

        private void frmScreensaver_Paint(object sender, PaintEventArgs e)
        {
            if (initialized)
            {
                Pen starPen = new Pen(Settings.Default.StarColor, 2f);
                Point centerPoint = new Point(e.ClipRectangle.Width / 2, e.ClipRectangle.Height / 2);
                double maxPathLength = Hypotenuse(centerPoint.X, centerPoint.Y);
                double baseTrailLength = Settings.Default.WarpFactor >= 1 ? Settings.Default.WarpFactor * maxPathLength * 0.01 : 1.0;
                if (baseTrailLength < 1.0) baseTrailLength = 1.0;

                foreach (var star in stars)
                {
                    double cosTheta = Math.Cos(star.Angle);
                    double sinTheta = Math.Sin(star.Angle);

                    if (star.Valid)
                    {
                        star.PathStart += Settings.Default.WarpFactor * star.Distance * 5.0;
                        if (Math.Abs(star.PathStart * cosTheta) > centerPoint.X || Math.Abs(star.PathStart * sinTheta) > centerPoint.Y) star.Valid = false;
                    }
                    
                    // Separate from previous if condition due to the fact that this star may have been invalidated
                    if (!star.Valid)
                    {
                        star.Angle = rng.NextDouble() * Math.PI * 2;
                        star.Distance = rng.NextDouble() + 0.5;
                        star.PathStart = 0;
                        star.Valid = true;
                    }

                    double trailLength = baseTrailLength * star.Distance;
                    double startX = cosTheta * star.PathStart;
                    double startY = sinTheta * star.PathStart;
                    double endX = cosTheta * (star.PathStart + trailLength);
                    double endY = sinTheta * (star.PathStart + trailLength);
                    PointF start = new PointF((float)startX + centerPoint.X, centerPoint.Y - (float)startY);
                    PointF end = new PointF((float)endX + centerPoint.X, centerPoint.Y - (float)endY);
                    e.Graphics.DrawLine(starPen, start, end);
                }
                Invalidate();
            }
        }

        private double Hypotenuse(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }

        class StarTrail
        {
            public bool Valid { get; set; }
            public double PathStart { get; set; }

            /// <summary>
            /// Angle of the path
            /// </summary>
            public double Angle { get; set; }

            /// <summary>
            /// Used as speed multiplier and as a trail length multiplier
            /// </summary>
            public double Distance { get; set; }

        }
    }
}
