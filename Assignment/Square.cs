using System.Drawing;

namespace Assignment
{
    public class Square
    {
        //Declaring variables
        private Graphics illustrate;
        private Pen pen;
        private int xPosition, yPosition, size;

        //Constructor of this class
        public Square(Graphics illustrate,Pen pen, int xPosition, int yPosition, int size)
        {
            //Assigning the received parameters to the global variables
            this.illustrate = illustrate;
            this.pen = pen;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.size = size;
        }

        // Function responsible to draw the Desired shape
        public void Draw()
        {
            illustrate.DrawRectangle(pen, xPosition, yPosition, size,  size);
        }

        //Overloading the Draw function with a parameter. Function to be used to draw filled shapes
        public void Draw(SolidBrush brush)
        {
            illustrate.FillRectangle(brush, xPosition, yPosition, size, size);
        }
    }
}