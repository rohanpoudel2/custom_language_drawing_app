using System.Drawing;

namespace Assignment
{
    public class Line
    {
        private Graphics illustrate;
        private Pen pen;
        private int xPosition, yPosition;
        private int toXPos, toYPos;

        public Line(Graphics illustrate, Pen pen, int xPosition, int yPosition, int toXPos, int toYPos)
        {
            this.illustrate = illustrate;
            this.pen = pen;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.toXPos = toXPos;
            this.toYPos = toYPos;
        }

        public void Draw()
        {
            illustrate.DrawLine(pen, xPosition, yPosition, toXPos, toYPos);
        }
    }
}