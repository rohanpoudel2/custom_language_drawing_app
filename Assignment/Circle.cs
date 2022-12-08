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
           illustrate.DrawEllipse(pen, xPosition, yPosition, xPosition + (radius * 2), yPosition + (radius * 2));
        }

        public void Draw(SolidBrush brush)
        {
            illustrate.FillEllipse(brush, xPosition, yPosition, xPosition+(radius * 2), yPosition + (radius *2));
        }

    }
}