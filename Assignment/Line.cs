using System.Drawing;

namespace Assignment
{
    public class Line
    {
        //Declaring variables
        private Graphics illustrate;
        private Pen pen;
        private int xPosition, yPosition;
        private int toXPos, toYPos;

        //Constructor of this class
        public Line(Graphics illustrate, Pen pen, int xPosition, int yPosition, int toXPos, int toYPos)
        {
            //Assigning the received parameters to the global variables
            this.illustrate = illustrate;
            this.pen = pen;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.toXPos = toXPos;
            this.toYPos = toYPos;
        }

        // Function responsible to draw the Desired shape
        public void Draw()
        {
            illustrate.DrawLine(pen, xPosition, yPosition, toXPos, toYPos);
        }
    }
}