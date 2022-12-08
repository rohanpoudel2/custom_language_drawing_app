using System.Drawing;

namespace Assignment
{
    public class Square
    {
        private Graphics illustrate;
        private Pen pen;
        private int xPosition, yPosition, size;
        public Square(Graphics illustrate,Pen pen, int xPosition, int yPosition, int size)
        {
            this.illustrate = illustrate;
            this.pen = pen;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.size = size;
        }

        public void Draw()
        {
            illustrate.DrawRectangle(pen, xPosition, yPosition, xPosition + size, yPosition + size);
        }
    }
}