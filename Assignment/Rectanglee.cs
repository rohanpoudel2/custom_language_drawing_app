using System.Drawing;
using System.Runtime.InteropServices;

namespace Assignment
{
    public class Rectanglee
    {
        //Declaring variables
        private Graphics illustrate;
        private Pen pen;
        private int xPosition, yPosition, width, height;

        //Constructor of this class
        public Rectanglee(Graphics illustrate, Pen pen, int xPosition, int yPosition, int width, int height)
        {
            //Assigning the received parameters to the global variables
            this.illustrate = illustrate;
            this.pen = pen;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.width = width;
            this.height = height;
        }

        // Function responsible to draw the Desired shape
        public void Draw()
        {
            illustrate.DrawRectangle(pen, xPosition, yPosition, width, height);
        }

        //Overloading the Draw function with a parameter. Function to be used to draw filled shapes
        public void Draw(SolidBrush brush)
        {
            illustrate.FillRectangle(brush, xPosition, yPosition, width, height);
        }
    }
}