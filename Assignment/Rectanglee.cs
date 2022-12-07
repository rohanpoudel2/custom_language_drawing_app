using System.Drawing;

namespace Assignment
{
    public class Rectanglee
    {
        private Graphics illustrate;
        private Pen pen;
        private int xPosition, yPosition, width, height;

        public Rectanglee(Graphics illustrate, Pen pen, int xPosition, int yPosition, int width, int height)
        {
            this.illustrate = illustrate;
            this.pen = pen;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            illustrate.DrawRectangle(pen, xPosition, yPosition, width, height);
        }
    }
}