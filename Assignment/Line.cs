using System.Drawing;

namespace Assignment
{
    class Line : BasicShape
    {
        //Declaring variables
        private int toXPos, toYPos;

        //Constructor of this class
        public Line(Graphics illustrate, Pen pen, int xPosition, int yPosition, int toXPos, int toYPos) : base(pen, illustrate, xPosition, yPosition)
        {
            //Assigning the received parameters to the global variables
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