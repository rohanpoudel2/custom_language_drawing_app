using System.Drawing;

namespace Assignment
{
    public class Square : BasicShape
    {
        //Declaring variables
        private int size;

        //Constructor of this class
        public Square(Graphics illustrate,Pen pen, int xPosition, int yPosition, int size) : base(pen, illustrate, xPosition, yPosition)
        {
            //Assigning the received parameters to the global variables
            this.size = size;
        }

        // Function responsible to draw the Desired shape
        public override void Draw()
        {
            illustrate.DrawRectangle(pen, xPosition, yPosition, size,  size);
        }

        //Overloading the Draw function with a parameter. Function to be used to draw filled shapes
        public override void Draw(SolidBrush brush)
        {
            illustrate.FillRectangle(brush, xPosition, yPosition, size, size);
        }
    }
}