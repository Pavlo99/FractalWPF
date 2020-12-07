using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Controls;

namespace FractalWPF.Model
{
    class Drawer
    {
        delegate void TrigonometricFunction(ref double oldReal, ref double oldImagine, out double newReal, out double newImagine, double cReal, double cImagine);
        TrigonometricFunction TFunction;
        Drawer()
        {
            TFunction += cosinus;
        }
        public void DrawFractal(Graphics panel, Pen pen, ProgressBar progressBar, double cReal, double cImagine, double scaling, int colorMode, int width, int height)
        {
            double newReal, newImagine, oldReal, oldImagine;
            double zoom = scaling, moveX = 0, moveY = 0;
            int maxIterations = 300;
            Random rnd = new Random();
            int rConst = colorMode * rnd.Next(255);
            int gConst = colorMode * rnd.Next(255);
            int bConst = colorMode * rnd.Next(255);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++) 
                {
                    newReal = 1.5 * (x - width / 2) / (0.5 * zoom * width) + moveX;
                    newImagine = 1.5 * (y - height/ 2) / (0.5 * zoom * height) + moveY;
                    int i;
                    for(i = 0; i < maxIterations;)
                    {
                        oldReal = newReal;
                        oldImagine = newImagine;
                        TFunction(ref oldReal, ref oldImagine, out newReal, out newImagine, cReal, cImagine);
                        ++i;
                        if (Math.Abs(Math.Abs(oldImagine) - Math.Abs(newImagine)) < 0.01) break;
                    }
                    pen.Color = Color.FromArgb(255, (i * 9 * rConst) % 255, (i * 9 * gConst), (i * 9 * bConst) % 255);
                    panel.DrawRectangle(pen, x, y, 1, 1);
                }
                progressBar.Value += 1;
            }
        }
        public void cosinus(ref double oldReal, ref double oldImagine, out double newReal, out double newImagine, double cReal, double cImagine)
        {
            newReal = Math.Cos(oldReal) * Math.Cosh(oldImagine) + cReal;
            newImagine = Math.Sin(oldReal) * Math.Sinh(oldImagine) + cReal;
        }
    }
}
