using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private bool shouldDrawTriangle = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            shouldDrawTriangle = true;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (shouldDrawTriangle)
            {
                PointF v1 = new PointF(50, 50);
                PointF v2 = new PointF(200, 100);
                PointF v3 = new PointF(100, 250);

                Color c1 = GetColorFromComboBox(comboBox1);
                Color c2 = GetColorFromComboBox(comboBox2);
                Color c3 = GetColorFromComboBox(comboBox3);

                DrawGradientTriangle(e.Graphics, v1, v2, v3, c1, c2, c3);
            }
        }

        private Color GetColorFromComboBox(ComboBox comboBox)
        {
            switch (comboBox.SelectedItem.ToString())
            {
                case "Red":
                    return Color.Red;
                case "Green":
                    return Color.Green;
                case "Blue":
                    return Color.Blue;
                case "Yellow":
                    return Color.Yellow;
                case "Purple":
                    return Color.Purple;
                case "Orange":
                    return Color.Orange;
                case "White":
                    return Color.White;
                case "Lime":
                    return Color.Lime;
                case "Pink":
                    return Color.LightPink;
                default:
                    return Color.Black;
            }
        }

        private void DrawGradientTriangle(Graphics g, PointF v1, PointF v2, PointF v3, Color c1, Color c2, Color c3)
        {
            if (v1.Y > v2.Y)
            {
                Swap(ref v1, ref v2);
                Swap(ref c1, ref c2);
            }
            if (v1.Y > v3.Y)
            {
                Swap(ref v1, ref v3);
                Swap(ref c1, ref c3);
            }
            if (v2.Y > v3.Y)
            {
                Swap(ref v2, ref v3);
                Swap(ref c2, ref c3);
            }

            for (float y = v1.Y; y <= v3.Y; y++)
            {
                bool secondHalf = y > v2.Y || v2.Y == v1.Y;
                float segmentHeight = secondHalf ? v3.Y - v2.Y : v2.Y - v1.Y;
                float alpha = (y - v1.Y) / (v3.Y - v1.Y);
                float beta = (y - (secondHalf ? v2.Y : v1.Y)) / segmentHeight;

                PointF A = v1.Add((v3.Subtract(v1)).Multiply(alpha));
                PointF B = secondHalf ? v2.Add((v3.Subtract(v2)).Multiply(beta)) : v1.Add((v2.Subtract(v1)).Multiply(beta));

                Color colorA = InterpolateColor(c1, c3, alpha);
                Color colorB = secondHalf ? InterpolateColor(c2, c3, beta) : InterpolateColor(c1, c2, beta);

                if (A.X > B.X)
                {
                    Swap(ref A, ref B);
                    Swap(ref colorA, ref colorB);
                }

                for (float x = A.X; x <= B.X; x++)
                {
                    float phi = B.X == A.X ? 1f : (x - A.X) / (B.X - A.X);
                    Color color = InterpolateColor(colorA, colorB, phi);
                    g.FillRectangle(new SolidBrush(color), x, y, 1, 1);
                }
            }
        }

        private void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private Color InterpolateColor(Color c1, Color c2, float t)
        {
            int r = (int)(c1.R + (c2.R - c1.R) * t);
            int g = (int)(c1.G + (c2.G - c1.G) * t);
            int b = (int)(c1.B + (c2.B - c1.B) * t);
            return Color.FromArgb(r, g, b);
        }
    }

    public static class PointFExtensions
    {
        public static PointF Subtract(this PointF p1, PointF p2)
        {
            return new PointF(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static PointF Add(this PointF p1, PointF p2)
        {
            return new PointF(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static PointF Multiply(this PointF p, float scalar)
        {
            return new PointF(p.X * scalar, p.Y * scalar);
        }
    }
}
