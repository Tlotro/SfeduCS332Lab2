using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Task2
{
    public partial class Form1 : Form
    {
        Bitmap drawboard;
        private Point startPoint;
        private bool isDrawing;
        private Color selectedC;

        public Form1()
        {
            InitializeComponent();
            drawboard = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = drawboard;
            ClearBitmap();
            selectedC = Color.Black;
            button2.BackColor = selectedC;
            comboBox1.SelectedIndex = 0;
            isDrawing = false;
        }

        private void DrawBres(int x0, int x1, int y0, int y1, Color color)
        {
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }

            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }

            int dx = x1 - x0;
            int dy = Math.Abs(y1 - y0);
            int error = dx / 2;
            int ystep = (y0 < y1) ? 1 : -1;
            int y = y0;

            for (int x = x0; x <= x1; x++)
            {
                if (steep)
                {
                    drawboard.SetPixel(y, x, color);
                }
                else
                {
                    drawboard.SetPixel(x, y, color);
                }

                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
        }
        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private void DrawWu(int x0, int x1, int y0, int y1, Color color)
        {
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                int temp;
                temp = x0; x0 = y0; y0 = temp;
                temp = x1; x1 = y1; y1 = temp;
            }
            if (x0 > x1)
            {
                int temp;
                temp = x0; x0 = x1; x1 = temp;
                temp = y0; y0 = y1; y1 = temp;
            }

            int dx = x1 - x0;
            int dy = y1 - y0;
            float gradient = (float)dy / (float)dx;

            float y = y0 + gradient;

            for (int x = x0 + 1; x <= x1; x++)
            {
                int yInt = (int)y;
                float yFraction = y - yInt;

                if (steep)
                {
                    SetPixelWithAlpha(yInt, x, 1 - yFraction,color);
                    SetPixelWithAlpha(yInt + 1, x, yFraction,color);
                }
                else
                {
                    SetPixelWithAlpha(x, yInt, 1 - yFraction,color);
                    SetPixelWithAlpha(x, yInt + 1, yFraction,color);
                }

                y += gradient;
            }
        }

        private void SetPixelWithAlpha(int x, int y, float alpha, Color c)
        {
            if (x < 0 || x >= drawboard.Width || y < 0 || y >= drawboard.Height)
                return;

            Color existingColor = drawboard.GetPixel(x, y);
            int newR = (int)(existingColor.R * (1 - alpha) + c.R * alpha);
            int newG = (int)(existingColor.G * (1 - alpha) + c.G * alpha);
            int newB = (int)(existingColor.B * (1 - alpha) + c.B * alpha);

            drawboard.SetPixel(x, y, Color.FromArgb(newR, newG, newB));
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isDrawing)
            {
                // Первое нажатие: устанавливаем начальную точку
                startPoint = e.Location;
                isDrawing = true;
            }
            else
            {
                // Второе нажатие: устанавливаем конечную точку и рисуем линию
                if (comboBox1.SelectedIndex == 0)
                {
                    DrawBres(startPoint.X, e.X, startPoint.Y, e.Y, selectedC);
                }
                else { DrawWu(startPoint.X, e.X, startPoint.Y, e.Y, selectedC); };
                pictureBox1.Invalidate(); // Обновляем PictureBox
                isDrawing = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearBitmap();
        }

        private void ClearBitmap()
        {
            using (Graphics g = Graphics.FromImage(drawboard))
            {
                g.Clear(Color.White);
            }
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = selectedC; // Устанавливаем текущий выбранный цвет

                // Показываем диалог и проверяем, был ли выбран цвет
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedC = colorDialog.Color; // Сохраняем выбранный цвет
                }
            }
        }
    }
}
