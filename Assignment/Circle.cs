using System;
using System.Drawing;

namespace Assignment
{
    public class Circle
    {
        //Declaring variables
        private Graphics illustrate;
        private Pen pen;
        private int xPosition, yPosition;
        private int radius;

        //Constructor of this class
        public Circle(Graphics illustrate, Pen pen, int xPosition, int yPosition, int radius)
        {
            //Assigning the received parameters to the global variables
            this.illustrate = illustrate;
            this.pen = pen;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.radius = radius;
        }

        // Function responsible to draw the Desired shape
        public void Draw()
        {
           illustrate.DrawEllipse(pen, xPosition - radius, yPosition - radius, (radius * 2), (radius * 2));
        }

        //Overloading the Draw function with a parameter. Function to be used to draw filled shapes
        public void Draw(SolidBrush brush)
        {
            illustrate.FillEllipse(brush, xPosition - radius, yPosition - radius, (radius * 2), (radius * 2));
        }

    }
}