using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenGL_lesson_CSharp
{
    public partial class Form1 : Form
    {
        Bitmap image = new Bitmap(100, 100);
        int lx = 0, ly = 0;
        int cx = 0, cy = 0;
        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(this_MouseWheel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Capture)
            {
                int dx = e.X - lx;
                int dy = e.Y - ly;
                cx += dx;
                cy += dy;
                lx = e.X;
                ly = e.Y;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lx = e.X;
            ly = e.Y;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            image = new Bitmap("res.png");
            pictureBox1.Invalidate();
            Resize = 1;
        }

        void this_MouseWheel(object sender, MouseEventArgs e)
        {
            image = new Bitmap("res.png");
            if (e.Delta > 0)
                Resize *= 1.5;
            else
                Resize /= 1.5;
            image = ResizeBitmap(image, (int)(image.Width * Resize), (int)(image.Height * Resize));
            pictureBox1.Invalidate();
        }

        private static Bitmap ResizeBitmap(Bitmap sourceBMP, int width, int height)
        {
            Bitmap bmp = new Bitmap(sourceBMP, new Size(width, height));
            return System.Drawing.Image.FromHbitmap(bmp.GetHbitmap());

            //Bitmap result = new Bitmap(width, height);
            //using (Graphics g = Graphics.FromImage(result))
            //    g.DrawImage(sourceBMP, 0, 0, width, height);
            //return result;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(image, cx, cy);
        }
        double Resize = 1;
    }
}
