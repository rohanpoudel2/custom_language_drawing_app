using System.Drawing;

namespace Assignment
{
    class Triangle : BasicShape
    {
        //Declaring variables
        private Point[] points;

        //Constructor of this class
        public Triangle(Graphics illustrate, Pen pen, Point[] points) : base(pen, illustrate, 0, 0)
        {
            //Assigning the received parameters to the global variables
            this.points = points;
        }

        // Function responsible to draw the Desired shape
        public void Draw()
        {
            illustrate.DrawPolygon(pen, points);
        }

        //Overloading the Draw function with a parameter. Function to be used to draw filled shapes
        public void Draw(SolidBrush brush)
        {
            illustrate.FillPolygon(brush, points);
        }
    }
}