using System;
using System.Data;
using System.Drawing;

namespace Assignment
{
    public class Circle : BasicShape
    {
        //Declaring variables
        private int radius;

        //Constructor of this class
        public Circle(Graphics illustrate, Pen pen, int xPosition, int yPosition, int radius) : base(pen, illustrate, xPosition, yPosition)
        {
            //Assigning the received parameters to the global variables
            this.radius = radius;
        }
 
        // Function responsible to draw the Desired shape
        public override void Draw()
        {
           illustrate.DrawEllipse(pen, xPosition - radius, yPosition - radius, (radius * 2), (radius * 2));
        }

        //Overloading the Draw function with a parameter. Function to be used to draw filled shapes
        public override void Draw(SolidBrush brush)
        {
            illustrate.FillEllipse(brush, xPosition - radius, yPosition - radius, (radius * 2), (radius * 2));
        }

    }
}