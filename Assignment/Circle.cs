using System;
using System.Drawing;

namespace Assignment
{
    public class Circle
    {
        private Graphics illustrate;
        private Pen pen;
        private int xPosition, yPosition;
        private int radius;
        public Circle(Graphics illustrate, Pen pen, int xPosition, int yPosition, int radius)
        {
            this.illustrate = illustrate;
            this.pen = pen;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.radius = radius;
        }

        public void Draw()
        {
           illustrate.DrawEllipse(pen, xPosition - radius, yPosition - radius, (radius * 2), (radius * 2));
        }

        public void Draw(SolidBrush brush)
        {
            illustrate.FillEllipse(brush, xPosition - radius, yPosition - radius, (radius * 2), (radius * 2));
        }

    }
}