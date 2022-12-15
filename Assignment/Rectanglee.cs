using System.Drawing;
using System.Runtime.InteropServices;

namespace Assignment
{
    public class Rectanglee : BasicShape
    {
        //Declaring variables
        private int width, height;

        //Constructor of this class
        public Rectanglee(Graphics illustrate, Pen pen, int xPosition, int yPosition, int width, int height) : base(pen, illustrate, xPosition, yPosition)
        {
            //Assigning the received parameters to the global variables
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