using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WplacePaletteConverter.Views.CustomControls
{
    public class ZoomablePictureBox : PictureBox
    {
        private float _zoom = 1.0f;
        private Point _panStart;
        private PointF _offset = PointF.Empty;
        private bool _panning = false;

        public ZoomablePictureBox()
        {
            MouseWheel += ZoomablePictureBox_MouseWheel;
            MouseDown += ZoomablePictureBox_MouseDown;
            MouseMove += ZoomablePictureBox_MouseMove;
            MouseUp += ZoomablePictureBox_MouseUp;
            Paint += ZoomablePictureBox_Paint;
            DoubleBuffered = true;
        }

        private void ZoomablePictureBox_MouseWheel(object? sender, MouseEventArgs e)
        {
            float oldZoom = _zoom;
            if (e.Delta > 0)
                _zoom *= 1.1f; // Zoom In
            else
                _zoom /= 1.1f; // Zoom Out

            if (_zoom < 0.1f) _zoom = 0.1f;
            if (_zoom > 10f) _zoom = 10f;

            float scale = _zoom / oldZoom;
            _offset.X = e.X - scale * (e.X - _offset.X);
            _offset.Y = e.Y - scale * (e.Y - _offset.Y);

            Invalidate();
        }

        private void ZoomablePictureBox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _panning = true;
            _panStart = e.Location;
        }

        private void ZoomablePictureBox_MouseMove(object? sender, MouseEventArgs e)
        {
            if (!_panning)
                return;

            _offset.X += e.X - _panStart.X;
            _offset.Y += e.Y - _panStart.Y;
            _panStart = e.Location;

            Invalidate();
        }

        private void ZoomablePictureBox_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _panning = false;
        }

        private void ZoomablePictureBox_Paint(object? sender, PaintEventArgs e)
        {
            if (Image == null)
                return;

            e.Graphics.Clear(BackColor);
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            e.Graphics.TranslateTransform(_offset.X, _offset.Y);
            e.Graphics.ScaleTransform(_zoom, _zoom);

            e.Graphics.DrawImage(Image, new Rectangle(0, 0, Image.Width, Image.Height));
        }

        public void ResetView()
        {
            _zoom = 1.0f;
            _offset = PointF.Empty;

            if (this.Image != null)
            {
                float centerX = (this.Width - this.Image.Width) / 2f;
                float centerY = (this.Height - this.Image.Height) / 2f;
                _offset = new PointF(centerX, centerY);
            }

            this.Invalidate();
        }

        public Point GetPixelCoordinates(Point p)
        {
            if (Image == null)
                return new(-1, -1);

            PointF imgPoint = new((p.X - _offset.X) / _zoom, (p.Y - _offset.Y) / _zoom);

            if (imgPoint.X >= 0 && imgPoint.Y >= 0 &&
                imgPoint.X < Image.Width && imgPoint.Y < Image.Height)
            {
                return new((int)imgPoint.X, (int)imgPoint.Y);
            }

            return new(-1, -1); // Return invalid point if out of bounds
        }

        public Color GetPixel(Point p)
        {
            if (_panning)
            {
                _offset.X += p.X - _panStart.X;
                _offset.Y += p.Y - _panStart.Y;
                _panStart = p;
                Invalidate();
            }
            else if (Image != null)
            {
                Point imgPoint = GetPixelCoordinates(p);

                if (imgPoint.X >= 0)
                {
                    Bitmap bmp = (Bitmap)Image;
                    return bmp.GetPixel(imgPoint.X, imgPoint.Y);
                }
            }

            return Color.Empty; // Return empty color if out of bounds or no image
        }
    }
}
