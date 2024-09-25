using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    class CustomPointComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            if (x.X == y.X && x.Y == y.Y)
                return 0;

            if (x.Y > y.Y || (x.Y==y.Y && x.X > y.X))
                return 1;
            else
            return -1;
        }
    }
    public partial class Form1 : Form
    {
        Bitmap BMP;
        Bitmap PBMP;
        int penradius = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void ActionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((ComboBox)sender).SelectedIndex)
            {
                case 0:
                    ColorButton.Enabled = true;
                    ColorButton.Visible = true;
                    pictureBoxPattern.Enabled = false;
                    pictureBoxPattern.Visible = false;
                    LoadPatternButton.Enabled = false;
                    LoadPatternButton.Visible = false;
                    PenSizeBox.Enabled = true;
                    PenSizeBox.Visible = true;
                    break;
                case 1:
                    ColorButton.Enabled = true;
                    ColorButton.Visible = true;
                    pictureBoxPattern.Enabled = false;
                    pictureBoxPattern.Visible = false;
                    LoadPatternButton.Enabled = false;
                    LoadPatternButton.Visible = false;
                    PenSizeBox.Enabled = false;
                    PenSizeBox.Visible = false;
                    break;
                case 2:
                    LoadPatternButton.Enabled = true;
                    LoadPatternButton.Visible = true;
                    pictureBoxPattern.Enabled = true;
                    pictureBoxPattern.Visible = true;
                    ColorButton.Enabled = false;
                    ColorButton.Visible = false;
                    PenSizeBox.Enabled = false;
                    PenSizeBox.Visible = false;
                    break;
                case 3:
                    ColorButton.Enabled = true;
                    ColorButton.Visible = true;
                    pictureBoxPattern.Enabled = false;
                    pictureBoxPattern.Visible = false;
                    LoadPatternButton.Enabled = false;
                    LoadPatternButton.Visible = false;
                    PenSizeBox.Enabled = false;
                    PenSizeBox.Visible = false;
                    break;
            }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ColorButton.BackColor = colorDialog1.Color;
            ColorButton.ForeColor = colorDialog1.Color;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadFileDialog.ShowDialog();
            BMP = new Bitmap(LoadFileDialog.FileName);
            pictureBox1.Image = BMP;
        }

        private void LoadPatternButton_Click(object sender, EventArgs e)
        {
            LoadPatternDialog.ShowDialog();
            PBMP = new Bitmap(LoadPatternDialog.FileName);
            pictureBoxPattern.Image = PBMP;
        }

        private void DrawLine(int X, int Y, Color filledColor)
        {
            int x = X+1;
            int y = Y;
            while (x < BMP.Width && BMP.GetPixel(x, y) == filledColor)
            {
                BMP.SetPixel(x, y, colorDialog1.Color);
                x++;
            }
            int limright = x-1;
            x = X;
            while (x >= 0 && BMP.GetPixel(x, y) == filledColor)
            {
                BMP.SetPixel(x, y, colorDialog1.Color);
                x--;
            }
            int limleft = x+1;
            for (int i = limleft; i <= limright; i++)
            {
                if (y-1 >= 0 && BMP.GetPixel(i,y-1)==filledColor)
                    DrawLine(i, y-1, filledColor);
                if (y+1 < BMP.Height && BMP.GetPixel(i, y + 1) == filledColor)
                    DrawLine(i, y+1, filledColor);
            }
        }

        private void DrawPattern(int X, int Y, int SHX, int SHY, Color filledColor)
        {
            int x = X + 1;
            int y = Y;
            while (x < BMP.Width && BMP.GetPixel(x, y) == filledColor)
            {
                BMP.SetPixel(x, y, PBMP.GetPixel((x-SHX+((SHX-x)/PBMP.Width+1)*PBMP.Width) % PBMP.Width, (y-SHY + ((SHY - y) / PBMP.Height + 1) * PBMP.Height) % PBMP.Height));
                x++;
            }
            int limright = x - 1;
            x = X;
            while (x >= 0 && BMP.GetPixel(x, y) == filledColor)
            {
                BMP.SetPixel(x, y, PBMP.GetPixel((x-SHX+ ((SHX - x) / PBMP.Width + 1) * PBMP.Width) % PBMP.Width, (y - SHY + ((SHY - y) / PBMP.Height + 1) * PBMP.Height) % PBMP.Height));
                x--;
            }
            int limleft = x + 1;
            for (int i = limleft; i <= limright; i++)
            {
                if (y - 1 >= 0 && BMP.GetPixel(i, y - 1) == filledColor && PBMP.GetPixel((i - SHX+ ((SHX - i) / PBMP.Width + 1) * PBMP.Width) % PBMP.Width, (y - SHY - 1 + ((SHY - y) / PBMP.Height + 1) * PBMP.Height) % PBMP.Height) != filledColor)
                    DrawPattern(i, y - 1, SHX, SHY, filledColor);
                if (y + 1 < BMP.Height && BMP.GetPixel(i, y + 1) == filledColor && PBMP.GetPixel((i - SHX+ ((SHX - i) / PBMP.Width + 1) * PBMP.Width) % PBMP.Width, (y - SHY + 1 + ((SHY - y) / PBMP.Height + 1) * PBMP.Height) % PBMP.Height) != filledColor)
                    DrawPattern(i, y + 1, SHX, SHY, filledColor);
            }
        }

        private void PutTheDamnedPointIntoTheDamnedListFunction(List<Point> DamnedList,Point DamnedPoint)
        {
            CustomPointComparer comparer = new CustomPointComparer();
            int i = DamnedList.BinarySearch(DamnedPoint,comparer); 
            if (i < 0) i = ~i;
            DamnedList.Insert(i, DamnedPoint);
        }

        private List<Point> GetOutline(int X, int Y)
        {
            Point[] shifts = { new Point(0, 1), new Point(1, 1), new Point(1, 0), new Point(1, -1), new Point(0, -1), new Point(-1, -1), new Point(-1, 0), new Point(-1, 1) };
            Color innerColor = BMP.GetPixel(X, Y);
            while (BMP.GetPixel(X, Y) == innerColor)
            {
                if (X > BMP.Width)
                    return null;
                X++;
            }
            int startX = X;
            int startY = Y;
            Color borderColor = BMP.GetPixel(X, Y);
            List<Point> res = new List<Point>();
            res.Add(new Point(X, Y));
            int direction = 0;
            for (int i = 0; i < 8; i++)
            {
                Point CP = shifts[(i + direction) % 8];
                if (BMP.GetPixel(X + CP.X, Y + CP.Y) == borderColor)
                {
                    PutTheDamnedPointIntoTheDamnedListFunction(res, new Point(X + CP.X, Y + CP.Y));
                    X += CP.X;
                    Y += CP.Y;
                    direction = (direction + 6 + i) % 8;
                    break;
                }
            }
            while (X != startX || Y != startY)
            for (int i = 0; i < 8; i++)
            {
                Point CP = shifts[(i+direction)%8];
                if (BMP.GetPixel(X+CP.X,Y+CP.Y)==borderColor)
                {
                    PutTheDamnedPointIntoTheDamnedListFunction(res, new Point(X + CP.X, Y + CP.Y));
                    X += CP.X;
                    Y+= CP.Y;
                    direction = (direction + 6+i) % 8;
                    break;
                }
            }

            return res;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null && (ActionBox.SelectedIndex > 0))
            {
                Point mousepos = GetCoords(e.Location.X, e.Location.Y);
                if (mousepos.X < BMP.Width && mousepos.X >= 0 && mousepos.Y < BMP.Height && mousepos.Y >= 0)
                {
                    Color filledColor = BMP.GetPixel(mousepos.X, mousepos.Y);
                    switch (ActionBox.SelectedIndex)
                    {
                        case 1:
                            DrawLine(mousepos.X, mousepos.Y, filledColor);
                        break;
                        case 2:
                            DrawPattern(mousepos.X, mousepos.Y, (mousepos.X+PBMP.Width/2)% PBMP.Width, (mousepos.Y+PBMP.Height/2)%PBMP.Height, filledColor);
                        break;
                        case 3:
                            foreach (Point p in GetOutline(mousepos.X, mousepos.Y))
                                BMP.SetPixel(p.X, p.Y, colorDialog1.Color);
                        break;
                    }
                    pictureBox1.Image = BMP;
                }
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ActionBox.SelectedIndex == 0 && (Control.MouseButtons & MouseButtons.Left) != 0 )
            {
                Point mousepos = GetCoords(e.Location.X, e.Location.Y);
                if (mousepos.X < BMP.Width && mousepos.X >= 0 && mousepos.Y < BMP.Height && mousepos.Y >= 0)
                    for (int i = Math.Max(0, mousepos.X-penradius+1); i <= Math.Min(BMP.Width,mousepos.X+penradius-1); i++)
                        for (int j = Math.Max(0, mousepos.Y - penradius + 1); j <= Math.Min(BMP.Height, mousepos.Y + penradius - 1); j++)
                            BMP.SetPixel(i, j, colorDialog1.Color);
                pictureBox1.Image = BMP;
            }
        }

        private Point GetCoords(int mouseX, int mouseY)
        {
            int realW = pictureBox1.Image.Width;
            int realH = pictureBox1.Image.Height;
            int currentW = pictureBox1.ClientRectangle.Width;
            int currentH = pictureBox1.ClientRectangle.Height;
            double zoomW = (currentW / (double)realW);
            double zoomH = (currentH / (double)realH);
            double zoomActual = Math.Min(zoomW, zoomH);
            double padX = zoomActual == zoomW ? 0 : (currentW - (zoomActual * realW)) / 2;
            double padY = zoomActual == zoomH ? 0 : (currentH - (zoomActual * realH)) / 2;

            int realX = (int)((mouseX - padX) / zoomActual);
            int realY = (int)((mouseY - padY) / zoomActual);
            return new Point(realX, realY);
        }

        private void NewCanvasButton_Click(object sender, EventArgs e)
        {
            int X, Y;
            if (int.TryParse(NewCanvasX.Text,out X) && int.TryParse(NewCanvasY.Text, out Y))
            {
                BMP = new Bitmap(X,Y);
                for (int i = 0; i < X; i++) 
                    for (int j = 0; j < Y; j++)
                        BMP.SetPixel(i, j, Color.White);
                pictureBox1.Image = BMP;
            }
        }

        private void PenSizeBox_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(PenSizeBox.Text, out penradius);
        }
    }
}
